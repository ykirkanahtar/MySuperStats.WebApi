using AutoMapper;
using BasketballStats.WebApi.Authorization;
using BasketballStats.WebApi.Authorization.Business.Contracts;
using BasketballStats.WebApi.Authorization.Business.Managers;
using BasketballStats.WebApi.Business;
using BasketballStats.WebApi.Business.Contracts;
using BasketballStats.WebApi.Business.Managers;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Data;
using BasketballStats.WebApi.Data.Contracts;
using BasketballStats.WebApi.Extensions;
using BasketballStats.WebApi.Helper;
using BasketballStats.WebApi.ModelData;
using BasketballStats.WebApi.Resources;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using BasketballStats.WebApi.Authorization.Data.DataInitializers;
using BasketballStats.WebApi.AutoMapper;
using Newtonsoft.Json;

namespace BasketballStats.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (ConfigHelper.GetConfigurationValue("AppSettings:DatabaseProvider") == "SqlServer")
            {
                services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SqlApplicationContext"))
                );
            }
            else
            {
                services.AddDbContext<ApplicationContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("PostgresApplicationContext"))
                );
            }

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
                )
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidAudience = Configuration["Tokens:Audience"],
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["Tokens:Issuer"],
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = ctx => Task.CompletedTask,
                        OnAuthenticationFailed = ctx =>
                        {
                            Console.WriteLine(@"Exception:{0}", ctx.Exception.Message);
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Permission", policyBuilder =>
                {
                    policyBuilder.Requirements.Add(new PermissionAuthorizationRequirement());
                });
            });

            services.AddSwaggerDocumentation();

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("tr-TR"),
                };

                options.DefaultRequestCulture = new RequestCulture(culture: "tr-TR", uiCulture: "tr-TR");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders.Insert(0, new AcceptLanguageHeaderRequestCultureProvider());
            });
            
            services.AddCors();

            services
                .AddMvc()
                .AddJsonOptions(options =>
                {
                    JsonConvert.DefaultSettings = () => new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        Formatting = Formatting.Indented
                    };
                });

            services.AddAutoMapper();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<ILocalizationService, LocalizationService>();


            services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationContext>>();
            services.AddScoped<DbContext, ApplicationContext>();
            services.AddTransient<IApiRequestAccessor, ApiRequestAccessor>();
            services.AddTransient<IApiRequest, ApiRequest>();

            /*******Authorization********/
            /**********Managers***********/
            services.AddTransient<IClaimManager, ClaimManager>();
            services.AddTransient<IClientApplicationManager, ClientApplicationManager>();
            services.AddTransient<IClientApplicationUtilManager, ClientApplicationUtilManager>();
            services.AddTransient<IRoleClaimManager, RoleClaimManager>();
            services.AddTransient<IRoleManager, RoleManager>();
            services.AddTransient<IRoleEntityClaimManager, RoleEntityClaimManager>();
            services.AddTransient<IUserClaimManager, UserClaimManager>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IUserEntityClaimManager, UserEntityClaimManager>();
            services.AddTransient<IUserRoleManager, UserRoleManager>();
            services.AddTransient<IUserUtilManager, UserUtilManager>();
            /**********Managers***********/
            /*******Authorization********/


            /*********Managers*********/
            services.AddTransient<IMatchManager, MatchManager>();
            services.AddTransient<IPlayerManager, PlayerManager>();
            services.AddTransient<IStatManager, StatManager>();
            services.AddTransient<ITeamManager, TeamManager>();
            /*********Managers*********/

            /************Seed Data************/
            services.AddTransient<ClientApplicationDataInitializer>();
            services.AddTransient<RoleEntityClaimDataInitializer>();
            services.AddTransient<RoleDataInitializer>();
            services.AddTransient<UserDataInitializer>();
            services.AddTransient<UserRoleDataInitializer>();
            /************Seed Data************/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env
            , UserDataInitializer userDataInitializer
            , RoleDataInitializer roleDataInitializer
            , UserRoleDataInitializer userRoleDataInitializer
            , ClientApplicationDataInitializer clientApplicationDataInitializer
            , RoleEntityClaimDataInitializer roleEntityClaimDataInitializer
        )
        {
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();

            if (Convert.ToBoolean(ConfigHelper.GetConfigurationValue("AppSettings:EnableSeeding")))
            {
                /************Seed Data************/
                userDataInitializer.Seed().Wait();
                roleDataInitializer.Seed().Wait();
                userRoleDataInitializer.Seed().Wait();
                clientApplicationDataInitializer.Seed().Wait();
                roleEntityClaimDataInitializer.Seed().Wait();
                /************Seed Data************/
            }

            app.UseErrorWrappingMiddleware();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseMvc();

            app.UseSwaggerDocumentation();
        }
    }
}
