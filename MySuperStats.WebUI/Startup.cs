using System;
using AutoMapper;
using CS.Common.WebApi.Connector;
using CustomFramework.WebApiUtils.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
            services.AddTransient<IWebApiConnector<ApiResponse>, WebApiConnector<ApiResponse>>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(sp => sp.GetService<IHttpContextAccessor>().HttpContext.Session);

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // services.AddIdentity<AppUser, AppRole>(config =>
            //     {
            //         config.SignIn.RequireConfirmedEmail = true;
            //     })
            //     .AddDefaultUI(UIFramework.Bootstrap4)
            //     .AddEntityFrameworkStores<ApplicationDbContext>()
            //     .AddDefaultTokenProviders();

            // services.Configure<IdentityOptions>(options =>
            // {
            //     // Password settings.
            //     options.Password.RequireDigit = true;
            //     options.Password.RequireLowercase = true;
            //     options.Password.RequireNonAlphanumeric = false;
            //     options.Password.RequireUppercase = true;
            //     options.Password.RequiredLength = 6;
            //     options.Password.RequiredUniqueChars = 0;

            //     // Lockout settings.
            //     options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //     options.Lockout.MaxFailedAccessAttempts = 5;
            //     options.Lockout.AllowedForNewUsers = true;

            //     // User settings.
            //     options.User.AllowedUserNameCharacters =
            //         "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            //     options.User.RequireUniqueEmail = false;
            // });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddSingleton(resolver =>
                resolver.GetRequiredService<IOptions<AppSettings>>().Value);

            services.AddAntiforgery(option => option.HeaderName = "X-XSRF-TOKEN");
            services.AddDataProtection();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseExceptionHandler("/Error");
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseSession();

            app.UseSessionMiddleware();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}