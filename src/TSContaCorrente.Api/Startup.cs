using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TSContaCorrente.Api.Models;
using TSContaCorrente.Api.Models.Request;
using TSContaCorrente.Api.Validators;
using TSContaCorrente.Domain.DTOs;
using TSContaCorrente.Domain.Servicos;
using TSContaCorrente.Domain.Validators;
using TSContaCorrente.Infra;
using TSContaCorrente.Infra.Data;
using TSContaCorrente.Infra.Servicos;

namespace TSContaCorrente.Api
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
            services.AddDbContext<AppDbContext>(x => x.UseInMemoryDatabase("AppBd"));

            services.AddMvc().AddFluentValidation(x =>
            {
                x.ImplicitlyValidateChildProperties = true;
                x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddScoped<IValidator<ContaRequest>, ContaRequestValidator>();

            services.AddScoped<IValidator<TransferenciaRequest>, TransferenciaRequestValidator>();
            
            services.AddScoped<IValidator<ContaDTO>, ContaValidator>();
            
            services.AddScoped<IValidator<TransferenciaDTO>, TransferenciaValidator>();

            services.AddScoped<IServicoTransferencia, ServicoTransferencia>();

            services.AddControllers();

            services.AddSwaggerGen();
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Conta API v1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
