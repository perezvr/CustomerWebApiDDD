using CustomerWebApiDDD.Application.Interfaces;
using CustomerWebApiDDD.Application.Services;
using CustomerWebApiDDD.Domain.Core.Interfaces.Repositories;
using CustomerWebApiDDD.Infrastruture.CrossCutting.Adapter.Interfaces;
using CustomerWebApiDDD.Infrastruture.CrossCutting.Adapter.Maps;
using CustomerWebApiDDD.Infrastruture.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CustomerWebApiDDD
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

            services.AddTransient<ICustomerApplicationService, CustomerApplicationService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerMapper, CustomerMapper>();

            services.AddTransient<IAddressApplicationService, AddressApplicationSerivce>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IAddressMapper, AddressMapper>();

            services.AddSwaggerGen(sw =>
            {
                sw.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomerWebApiDDD", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, System.IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(swUI => swUI.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerWebApiDDD"));

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
