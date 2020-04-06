using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using cojApi.Models;
using cojApi.Services;
using System.Security.Claims;

namespace cojApi
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //, IConfiguration configuration)
        {
            //var _config = configuration;
            var key = Configuration["AppSettings:Secret"];
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(options =>
                        {
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                ValidIssuer = "http://localhost:5000",
                                ValidAudience = "http://localhost:5000",
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                            };

                        });

            services.AddCors(options =>
                        {
                            options.AddPolicy("EnableCORS", builder =>
                                {
                                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                                }
                            );
                        });

            // services.AddDbContext<cojDBContext>(opt =>
            //     opt.UseInMemoryDatabase("cojDBbpr"));

            //On ievos1
            //var connection = @"Server=172.22.120.242,1434;Database=dbCOJ;User Id=sa;Password=sql!2019;";
            //var connection = @"Server=172.22.120.242,1434;Database=dbCOJ_Demo;User Id=sa;Password=sql!2019;";
            var connection = @"Server=172.22.120.242,1434;Database=dbCOJ_Test;User Id=sa;Password=sql!2019;";
            
            //var connection = @"Server=127.0.0.1;Database=dbCOJ_TestDev;User Id=sa;Password=ievolution@2549;";
            //var connection = @"Server=127.0.0.1;Database=dbCOJ_Dev;User Id=sa;Password=ievolution@2549;";

            //On Server
            //var connection = @"Server=BPRDBM01\BPRSQL;Database=dbCOJ;User Id=sa;Password=bpr@2019;"; //--> live
            //var connection = @"Server=BPRDBM01\BPRSQL;Database=dbCOJ_Dev;User Id=sa;Password=bpr@2019;"; //--> Dev
            //var connection = @"Server=BPRDBM01\BPRSQL;Database=dbCOJ_TestDev;User Id=sa;Password=bpr@2019;"; //--> Dev
            

            services.AddDbContext<cojDBContext>(opt => opt.UseSqlServer(connection, pvo => pvo.EnableRetryOnFailure()));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<iEmailService, EmailService>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("EnableCORS");
            app.UseAuthentication();
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
