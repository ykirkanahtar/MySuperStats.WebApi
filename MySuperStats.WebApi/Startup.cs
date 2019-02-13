using AutoMapper;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.ApplicationSettings;
using MySuperStats.WebApi.Business;
using MySuperStats.WebApi.Data;
using MySuperStats.WebApi.Data.Repositories;
using MySuperStats.WebApi.Data.Seeding;
using MySuperStats.WebApi.Resources;
using MySuperStats.WebApi.Validators;
using CustomFramework.Authorization;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Extensions;
using CustomFramework.Data.Extensions;
using CustomFramework.WebApiUtils.Authorization.Data;
using CustomFramework.WebApiUtils.Authorization.Data.Seeding;
using CustomFramework.WebApiUtils.Authorization.Extensions;
using CustomFramework.WebApiUtils.Extensions;
using CustomFramework.WebApiUtils.Filters;
using CustomFramework.WebApiUtils.Resources;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace MySuperStats.WebApi
{
    public class Startup
    {
        public static AppSettings AppSettings { get; private set; }
        public static SeedAuthorizationData SeedAuthorizationData { get; private set; }
        public static SeedWebApiData SeedWebApiData { get; private set; }
        public static string ConnectionString { get; private set; }


        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddUserSecrets<Startup>();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            ConnectionString = Configuration.GetValue<string>("ConnectionStrings:ApplicationContext");

            AppSettings = new AppSettings();
            Configuration.GetSection("AppSettings").Bind(AppSettings);

            //SeedAuthorizationData = new SeedAuthorizationData();
            //Configuration.GetSection("SeedingAuthorizationData").Bind(SeedAuthorizationData);

            //SeedWebApiData = new SeedWebApiData();
            //Configuration.GetSection("SeedingWebApiData").Bind(SeedWebApiData);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPostgreSqlServer<ApplicationContext>(ConnectionString);

            services.AddJwtAuthentication(AppSettings.Token.Audience, AppSettings.Token.Issuer, AppSettings.Token.Key);

            services.AddCustomAuthorization(new List<CustomAuthorizationPolicy>
            {
                new CustomAuthorizationPolicy
                {
                    Name = "Permission",
                    AuthorizationRequirements = new List<IAuthorizationRequirement>
                    {
                        new PermissionAuthorizationRequirement(),
                    }
                }
            });

            services.AddSwaggerDocumentation();

            services.AddWebApiUtilServices();

            services.AddAutoMapper();
            services.AddAuthorizationModels();

            services.AddScoped<IAppSettings, AppSettings>(p => AppSettings);
            services.AddTransient<ILocalizationService, LocalizationService>();

            var cultureInfos = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("tr-TR"),
            };

            services.AddLocalization(options => { options.ResourcesPath = "Resources"; });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
                options.SupportedCultures = cultureInfos;
                options.SupportedUICultures = cultureInfos;
                options.RequestCultureProviders.Insert(0, new AcceptLanguageHeaderRequestCultureProvider());
            });

            services.AddTransient<IUnitOfWorkAuthorization, UnitOfWorkWebApi>();
            services.AddTransient<IUnitOfWorkWebApi, UnitOfWorkWebApi>();
            services.AddScoped<DbContext, ApplicationContext>();
            services.AddScoped<AuthorizationContext, ApplicationContext>();

            /*********Repositories*********/
            services.AddTransient<IMatchRepository, MatchRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IBasketballStatRepository, BasketballStatRepository>();
            services.AddTransient<IMatchGroupRepository, MatchGroupRepository>();
            services.AddTransient<IMatchGroupPlayerRepository, MatchGroupPlayerRepository>();
            services.AddTransient<IMatchGroupTeamRepository, MatchGroupTeamRepository>();
            /*********Repositories*********/

            /*********Validators*********/
            services.AddTransient<IValidator<MatchRequest>, MatchValidator>();
            services.AddTransient<IValidator<TeamRequest>, TeamValidator>();
            services.AddTransient<IValidator<PlayerRequest>, PlayerValidator>();
            services.AddTransient<IValidator<BasketballStatRequest>, BasketballStatValidator>();
            services.AddTransient<IValidator<MatchGroupRequest>, MatchGroupValidator>();
            services.AddTransient<IValidator<MatchGroupPlayerRequest>, MatchGroupPlayerValidator>();
            services.AddTransient<IValidator<MatchGroupTeamRequest>, MatchGroupTeamValidator>();
            /*********Validators*********/

            /*********Managers*********/
            services.AddTransient<IMatchManager, MatchManager>();
            services.AddTransient<IPlayerManager, PlayerManager>();
            services.AddTransient<IBasketballStatManager, BasketballStatManager>();
            services.AddTransient<ITeamManager, TeamManager>();
            services.AddTransient<IMatchGroupManager, MatchGroupManager>();
            services.AddTransient<IMatchGroupPlayerManager, MatchGroupPlayerManager>();
            services.AddTransient<IMatchGroupTeamManager, MatchGroupTeamManager>();
            /*********Managers*********/

            services.AddMvc(options =>
                {
                    options.Filters.Add(typeof(ValidateModelAttribute));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Culture = CultureInfo.CurrentUICulture;
                })
                .AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseSwaggerDocumentation();

            app.UseErrorWrappingMiddleware();

            app.UseMvc();

            app.UseHttpsRedirection();
        }

    }
}
