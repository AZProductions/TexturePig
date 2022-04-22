using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AntDesign.ProLayout;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;
using TexturePig.Web.Services;
using LoginRadiusSDK.V2;

namespace TexturePig.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddAntDesign();
            services.AddScoped<BrowserWidthService>();
            services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(sp.GetService<NavigationManager>().BaseUri)
            });
            services.Configure<ProSettings>(Configuration.GetSection("ProSettings"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();

            /*LoginRadiusSdkGlobalConfig.ApiKey = "--key";
            LoginRadiusSdkGlobalConfig.ApiSecret = "--secret";
            LoginRadiusSdkGlobalConfig.AppName = "texturepig";
            LoginRadiusSdkGlobalConfig.ApiRequestSigning = "false";
            LoginRadiusSdkGlobalConfig.ConnectionTimeout = 30000; // Connection Timeout (milliseconds)
            //LoginRadiusSdkGlobalConfig.ProxyAddress = "__HTTP_PROXY_ADDRESS__"; // Absolute Proxy URI
            //LoginRadiusSdkGlobalConfig.ProxyCredentials = "__HTTP_PROXY_CREDENTIALS__"; // Proxy Credentials in the format 'USERNAME:PASSWORD'
            LoginRadiusSdkGlobalConfig.RequestRetries = 3;
            LoginRadiusSdkGlobalConfig.ApiRegion = "eu";
            LoginRadiusSdkGlobalConfig.DomainName = "https://api.loginradius.com/";*/


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
