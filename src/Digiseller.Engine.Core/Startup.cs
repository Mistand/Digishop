using System;
using System.Linq;
using Digiseller.Client.Core;
using Digiseller.Client.Core.Enums;
using Digiseller.Engine.Core.Areas.Dashboard.Controllers;
using Digiseller.Engine.Core.Areas.Dashboard.Models.Settings;
using Digiseller.Engine.Core.Attributes;
using Digiseller.Engine.Core.Helpers;
using Digiseller.Engine.Core.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Digiseller.Engine.Core
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            //services.Configure<DigisellerConnection>(Configuration.GetSection("DigisellerConnection"));
            //services.Configure<AdminSettings>(Configuration.GetSection("AdminSettings"));
            //services.Configure<ShopSettings>(Configuration.GetSection("ShopSettings"));

            services.AddSingleton(
                new DigisellerClient(Configuration.GetValue<int>($"{nameof(DigisellerSettings)}:DigisellerId"),
                    Configuration.GetValue<string>($"{nameof(DigisellerSettings)}:DigisellerUid")
                )
            );

            services.AddScoped<AuthAttribute>();

            services.AddSingleton(typeof(IConfProvider), typeof(JsonConfProvider));

            services.AddMemoryCache();
            services.AddSession();
            services.AddCloudscribePagination();
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IConfProvider conf)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStatusCodePagesWithReExecute("/error/{0}");

            app.Use((httpContext, next) =>
            {
                const string url = "/Dashboard/Home/Install";
                if (!conf.Get<MainSettings>().Installed && httpContext.Request.Path != url)
                {
                    Console.WriteLine("Redirected");
                    httpContext.Response.Redirect($"http://{httpContext.Request.Host}{url}");
                }
                return next();
            });

            app.UseSession();
            
            // Session middleware
            app.Use((httpContext, nextMiddleware) =>
            {
                if (!httpContext.Session.Keys.Contains(SessionHelper.KeyCurrency))
                {
                    httpContext.Session.SetCurrency(Currency.RUR);
                }

                if (!httpContext.Session.Keys.Contains(SessionHelper.KeyCart))
                {
                    httpContext.Session.SetCartId(string.Empty);
                }

                return nextMiddleware();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "productListPager",
                    template: "Products/Page-{page:int}",
                    defaults: new { controller = "Product", action = "Index", category = 0 }
                );

                routes.MapRoute(
                    name: "productListCategory",
                    template: "Products/Category-{category:int}",
                    defaults: new { controller = "Product", action = "Index", page = 1 }
                );

                routes.MapRoute(
                    name: "productListCategoryPager",
                    template: "Products/Category-{category:int}/Page-{page:int}",
                    defaults: new { controller = "Product", action = "Index" }
                );


                routes.MapRoute(
                    name: "productListSearch",
                    template: "Products/{search}",
                    defaults: new { controller = "Product", action = "Search", page = 1 }
                );

                routes.MapRoute(
                    name: "productListSearchPager",
                    template: "Products/{search}/Page-{page:int}",
                    defaults: new { controller = "Product", action = "Search" }
                );

                routes.MapRoute(
                    name: "productDetails",
                    template: "Product/{id:int}",
                    defaults: new { controller = "Product", action = "Details" }
                );

                routes.MapRoute(
                    name: "productList",
                    template: "Products/",
                    defaults: new { controller = "Product", action = "Index", category = 0 }
                );

                routes.MapRoute(
                    name: "cartView",
                    template: "Cart/",
                    defaults: new { controller = "Cart", action = "ViewCart" }
                );

                routes.MapRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=Index}/{id?}");
            });
        }
    }
}
