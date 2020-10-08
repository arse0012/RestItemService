using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace RestItemService
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
            services.AddControllers();

            services.AddCors();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://example.com"));

                options.AddPolicy("AllowAnyOrigin",
                    builder => builder.AllowAnyOrigin());

                options.AddPolicy("AllowAnyOriginGetPost",
                    builder => builder.AllowAnyOrigin().WithMethods("GET", "POST"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Items API",
                    Version = "v1.0",
                    Description = "Example of OpenAPI for api/localItems",
                    TermsOfService = new Uri("http://localhost:5000"),
                    Contact = new OpenApiContact()
                    {
                        Name = "Arsen",
                        Email = "arse0012@edu.easj.dk",
                        Url = new Uri("http://localhost:5000")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "No licence required",
                        Url = new Uri("http://localhost:5000/api/Items")
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Items API v1.0");
                    c.RoutePrefix = "api/help";
                }
            );

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
