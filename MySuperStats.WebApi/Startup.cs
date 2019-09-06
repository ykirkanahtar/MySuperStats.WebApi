using System.Collections.Generic;
using System.Globalization;
using System.IO;
using AutoMapper;
using CS.Common.EmailProvider;
using CustomFramework.Authorization.Utils;
using CustomFramework.Data.Extensions;
using CustomFramework.WebApiUtils.Extensions;
using CustomFramework.WebApiUtils.Identity.Data;
using CustomFramework.WebApiUtils.Identity.Extensions;
using CustomFramework.WebApiUtils.Resources;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.ApplicationSettings;
using MySuperStats.WebApi.Business;
using MySuperStats.WebApi.Data;
using MySuperStats.WebApi.Data.Repositories;
using MySuperStats.WebApi.Models;
using MySuperStats.WebApi.Resources;
using MySuperStats.WebApi.Validators;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MySuperStats.WebApi
{
    public class Startup
    {
        public static AppSettings AppSettings { get; private set; }
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
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPostgreSqlServer<ApplicationContext>(ConnectionString);

            IdentityModelExtension<User, Role, ApplicationContext>.AddIdentityModel(services, new IdentityModel
            {
                AppName = AppSettings.AppName,
                EmailConfirmationViaUrl = true,
                SenderEmailAddress = "info@mysuperstats.com",
                Token = AppSettings.Token,
                EmailConfig = AppSettings.EmailConfig,
                GeneratedPasswordLength = 0
            }, AppSettings.Token, true);

            services.AddLogging(logging =>
            {
                logging.AddDebug();

            });

            services.AddSwaggerDocumentation();

            services.AddWebApiUtilServices();

            services.AddAutoMapper();

            services.AddSingleton<IToken, Token>(p => AppSettings.Token);
            services.AddSingleton<IEmailConfig, EmailConfig>(p => AppSettings.EmailConfig);
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

            services.AddTransient<IUnitOfWorkIdentity, UnitOfWorkWebApi>();
            services.AddTransient<IUnitOfWorkWebApi, UnitOfWorkWebApi>();
            services.AddScoped<DbContext, ApplicationContext>();
            services.AddScoped<IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>, ApplicationContext>();

            /*********Repositories*********/
            services.AddTransient<IMatchRepository, MatchRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IBasketballStatRepository, BasketballStatRepository>();
            services.AddTransient<IMatchGroupRepository, MatchGroupRepository>();
            services.AddTransient<IMatchGroupUserRepository, MatchGroupUserRepository>();
            services.AddTransient<IMatchGroupTeamRepository, MatchGroupTeamRepository>();
            services.AddTransient<IFootballStatRepository, FootballStatRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            /*********Repositories*********/

            /*********Validators*********/
            services.AddTransient<IValidator<MatchRequest>, MatchValidator>();
            services.AddTransient<IValidator<TeamRequest>, TeamValidator>();
            services.AddTransient<IValidator<BasketballStatRequest>, BasketballStatValidator>();
            services.AddTransient<IValidator<MatchGroupRequest>, MatchGroupValidator>();
            services.AddTransient<IValidator<MatchGroupUserRequest>, MatchGroupUserValidator>();
            services.AddTransient<IValidator<MatchGroupTeamRequest>, MatchGroupTeamValidator>();
            services.AddTransient<IValidator<FootballStatRequest>, FootballStatValidator>();
            /*********Validators*********/

            /*********Managers*********/
            services.AddTransient<IMatchManager, MatchManager>();
            services.AddTransient<IBasketballStatManager, BasketballStatManager>();
            services.AddTransient<ITeamManager, TeamManager>();
            services.AddTransient<IMatchGroupManager, MatchGroupManager>();
            services.AddTransient<IMatchGroupUserManager, MatchGroupUserManager>();
            services.AddTransient<IMatchGroupTeamManager, MatchGroupTeamManager>();
            services.AddTransient<IFootballStatManager, FootballStatManager>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IPermissionChecker, PermissionChecker>();
            /*********Managers*********/

            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

            services.AddMvc(options =>
                {
                    options.Filters.Add(new AuthorizeFilter(policy));
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