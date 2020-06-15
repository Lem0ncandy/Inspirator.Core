using System;
using System.IO;
using System.Reflection;
using Autofac;
using Inspirator.Model.DTO;
using Inspirator.WebAPI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;


namespace Inspirator.WebAPI
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
            services.AddDBContext(Configuration);

            services.AddControllers(setup =>
                {
                    setup.ReturnHttpNotAcceptable = true;
                })
                .AddNewtonsoftJson(setup =>
                {
                    setup.SerializerSettings.ContractResolver =
                        new CamelCasePropertyNamesContractResolver();
                })
                .AddXmlDataContractSerializerFormatters()
                .ConfigureApiBehaviorOptions(setup =>
                {
                    setup.InvalidModelStateResponseFactory = context =>
                    {
                        var problemDetails = new ValidationProblemDetails(context.ModelState);
                        problemDetails.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

                        var resultDto = new UnifyResponseDto(Model.DTO.Enum.StatusCode.ParameterErroe, problemDetails.Errors);

                        return new UnprocessableEntityObjectResult(resultDto)
                        {
                            ContentTypes = { "application/problem+json" }
                        };
                    };
                });

            services.AddMvc();

            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Inspirator API", Version = "V1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                setup.IncludeXmlComments(xmlPath);
            });

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            Assembly assemblysRepository = Assembly.Load("Inspirator.Repository");
            Assembly assemblysService = Assembly.Load("Inspirator.Service");

            builder.RegisterAssemblyTypes(assemblysRepository)
                //.Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assemblysService)
                //.Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(setup =>
            {
                setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Inspirator API V1");
            });

            app.UseRouting();

            app.UseCors(options =>
            {
                options.WithOrigins(Configuration.GetSection("WithOrigins").Get<string[]>());
                options.AllowAnyHeader().AllowAnyMethod();
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
