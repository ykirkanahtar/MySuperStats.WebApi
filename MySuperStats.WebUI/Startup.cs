using System;
using System.Globalization;
using System.Reflection;
using AutoMapper;
using CustomFramework.BaseWebApi.Contracts.ApiContracts;
using CustomFramework.BaseWebApi.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using MySuperStats.Contracts.Resources;
using MySuperStats.WebUI.ApplicationSettings;
using MySuperStats.WebUI.AutoMapper;
using MySuperStats.WebUI.Middlewares;
using MySuperStats.WebUI.Utils;

namespace MySuperStats.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IWebApiConnector<WebApiResponse>, WebApiConnector<WebApiResponse>>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IPermissionChecker, PermissionChecker>();
            services.AddTransient<ILocalizationService, LocalizationService>();

            services.AddScoped(sp => sp.GetService<IHttpContextAccessor>().HttpContext.Session);

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login/tr";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied/tr";
                options.SlidingExpiration = true;
            });

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            services.AddSingleton<IEmailSender, EmailSender>();

            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddAutoMapper();

            services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Latest)
            .AddViewLocalization(o => o.ResourcesPath = "Resources")
            .AddModelBindingMessagesLocalizer(services)
            .AddDataAnnotationsLocalization(o =>
            {
                var type = typeof(SharedResources);
                var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
                var factory = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
                var localizer = factory.Create("SharedResources", assemblyName.Name);
                o.DataAnnotationLocalizerProvider = (t, f) => localizer;
            })
            .AddRazorPagesOptions(options =>
            {
                options.Conventions.AddFolderRouteModelConvention("/", model =>
                {
                    foreach (var selector in model.Selectors)
                    {
                        selector.AttributeRouteModel = new AttributeRouteModel
                        {
                            Order = -1,
                            Template = AttributeRouteModel.CombineTemplates(
                                "{culture=tr}",
                                selector.AttributeRouteModel.Template),
                        };
                    }
                });
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var defaultCulture = new CultureInfo("tr");
                var supportedCultures = new CultureInfo[]
                {
                    defaultCulture
                    , new CultureInfo("en")
                };

                options.DefaultRequestCulture = new RequestCulture(defaultCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                options.RequestCultureProviders.Insert(0, new RouteDataRequestCultureProvider()
                {
                    RouteDataStringKey = "culture",
                    UIRouteDataStringKey = "culture",
                    Options = options
                });
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddSingleton(resolver =>
                resolver.GetRequiredService<IOptions<AppSettings>>().Value);

            services.AddAntiforgery(option => option.HeaderName = "XSRF-TOKEN");
            services.AddDataProtection();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

            if (env.IsDevelopment())
            {
                //app.UseExceptionHandler($"/{culture}/Error");
                //app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                //app.UseExceptionHandler($"/{culture}/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Localization için
            var routeBuilder = new RouteBuilder(app)
            {
                DefaultHandler = app.ApplicationServices.GetRequiredService<MvcRouteHandler>(),
            };
            routeBuilder.Routes.Insert(0, AttributeRouting.CreateAttributeMegaRoute(app.ApplicationServices));
            var router = routeBuilder.Build();

            app.Use(async (context, next) =>
            {
                var routeContext = new RouteContext(context);
                await router.RouteAsync(routeContext);

                context.Features[typeof(IRoutingFeature)] = new RoutingFeature()
                {
                    RouteData = routeContext.RouteData
                };

                await next();
            });

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
            //Localization için

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseSession();

            app.UseSessionMiddleware();
            app.UseErrorHandlingMiddleware();

            app.UseMvcWithDefaultRoute();
        }
    }
}