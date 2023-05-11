using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Shop1.Areas.Admin.Services;
using Shop1.Data;
using Shop1.Services;

namespace Shop1
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
            //AppDbContext configuration
            services.AddDbContext<AppDbContext>(options => options
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            //Services configuration
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<IHomeService, HomeService>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            //Authentication and authorization
            services.AddIdentity<IdentityUser, IdentityRole>(
             options =>
             {
                 options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
             })
                  .AddDefaultTokenProviders()
                  .AddDefaultUI()
                  .AddEntityFrameworkStores<AppDbContext>();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.IsEssential = true;
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddRazorPages().AddRazorRuntimeCompilation();


            services.AddMvc(options => options.EnableEndpointRouting = false);

    

            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    //template: "{area=Customer}/{controller=Home}/{action=Index}/{id?}"
                    template: "{area=Customer}/{controller=Home}/{action=Landing}/{id?}"
                );
            });

            AppDbInitializer.Seed(app);

        }
    }
}

