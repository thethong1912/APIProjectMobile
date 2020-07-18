using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIProjectMobile.Models;
using APIProjectMobile.Repository;
using APIProjectMobile.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace APIProjectMobile
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
            services.AddSwaggerGen(gen =>
            {
                gen.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Project Mobile API", Version = "v1.0" });
            });

            services.AddDbContext<ProjectMobileContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("ProjectMobileDatabase")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IScenarioRepository, ScenarioRepository>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IScenarioService, ScenarioService>();
            services.AddScoped<IEquipmentService, EquipmentService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(UI =>
            {
                UI.SwaggerEndpoint("/swagger/v1.0/swagger.json", "V1.1");
            });

            app.UseMvc();
        }
    }
}
