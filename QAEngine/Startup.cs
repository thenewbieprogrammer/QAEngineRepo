﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QAEngine.Web.Data;
using QAEngine.Web.Models;
using QAEngine.Web.Services;
using MediatR;
using MediatR.Pipeline;
using System.Reflection;
using Microsoft.AspNetCore.SpaServices.Webpack;
using QAEngine.Web.Infrastructure.automapper;
using System.Net.NetworkInformation;
using QAEngine.Web.Infrastructure.mediatR;
using QAEngine.Application.Customers.Command;

namespace QAEngine.Web
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
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            //QAEngine.Web DB Context
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
                ));

            //QAEngine.Persistence DB Context - test if this works ..
            services.AddDbContext<QAEngine.Persistence.QAEngineDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));



            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            //ADD AutoMapper

            var config = new AutoMapper.MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            // ADD MEDIATR

            services.AddMediatR();
            services.AddMediatR(typeof(CreateCustomerCommand).Assembly, typeof(CreateCustomerCommandHandler).Assembly);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                //app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions {HotModuleReplacement = true} );

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
