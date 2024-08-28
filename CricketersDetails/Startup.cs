using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyDataAccessLayer;
using BussinessLayer;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CricketersDetails
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString(" DbConnection");
            var fromaddress = configuration.GetValue<string>("SMTP:Fromaddress");
            var password = configuration.GetValue<string>("SMTP:Password");
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DbConnection");
            services.AddDbContext<LocationDbContext>(options => options.UseSqlServer(connection));

            services.AddTransient<ICricketersDetailsRepository, CricketersDetailsRepository>();
          
            services.AddTransient<ILocationRepository, LocationRepository>();
                        services.AddTransient<IEmailRepository, EmailRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CricketersDetails", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CricketersDetails v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
