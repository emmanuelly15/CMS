using BlazorApp1.Areas.Identity;
using BlazorApp1.Data;
using Microsoft.AspNetCore.Builder;
using BlazorApp1.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp1.DbServices;
using BlazorApp1.Authentication;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Api.Authentication;
using Blazored.SessionStorage;
using Topshelf.Runtime;
using Api.Controllers;
using BlazorApp1.Pages;


namespace BlazorApp1
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            string mySqlConnectionStr = Configuration["ConnectionStrings:Default"];
            services.AddDbContextPool<ApplicationDbContext>(options => { options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr), options => options.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: System.TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null));
            });
            

            services.AddControllers();
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtAuthenticationManager.JWT_SECURITY_KEY)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
                
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddBlazoredLocalStorage();
            services.AddBlazoredSessionStorage();
            services.AddSingleton<AdminAccountService>();
            services.AddAuthentication();
            services.AddHttpClient();
            services.AddHttpClient<HttpClient>();
            services.AddScoped<HttpClient>();
           
            services.AddScoped<CustomAuthenticationStateProvider>();
            services.AddAuthenticationCore();
            services.AddSingleton<DeviceService>();
            services.AddSingleton<GroupService>();
            services.AddSingleton<UserService>();
            services.AddSingleton<MailingListService>();
            services.AddSingleton<AdminUserService>();
            services.AddSingleton<DocumentService>();
            services.AddSingleton<ImageUploadService>();
            services.AddScoped<GroupsListService>();
            services.AddScoped<UserListService>();
            services.AddSingleton<DashboardService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               // app.UseDatabaseErrorPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
