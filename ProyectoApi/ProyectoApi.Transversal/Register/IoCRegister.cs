using Microsoft.Extensions.DependencyInjection;
using ProyectApi.DataAccess;
using ProyectApi.DataAccess.Contracts;
using ProyectApi.DataAccess.Contracts.Repositorioes;
using ProyectApi.DataAccess.Repositorios;
using ProyectoApi.Aplicacion.Contratos.Servicios;
using ProyectoApi.Aplicacion.Servicios;
using ProyectoApi.Transversal.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoApi.Transversal.Register
{
    //IoC =  inversion of control
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration (this IServiceCollection services)
        {
            AddRegisterServices(services);
            AddRegisterRepositories(services);
            services.AddMvc(option =>
            {
                option.Filters.Add(item: new HttpExceptionFilter());

            });
            return services;
        }

        //Metodo que se usa para colocar los servicios Inyeccion de dependencias
        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            //services.AddTransient<IEspecieRepository, EspecieRepository>();
            services.AddTransient<ISpecieService, SpecieService>();
            services.AddTransient<IProyectDBContext, ProyectDBContext>();
            return services;
        }
        //Metodo que se usa para colocar los repositorios
        private static IServiceCollection AddRegisterRepositories(IServiceCollection services)
        {
            //se agregan cuantos respositorios tengamos en esta caso tenemos solo uno
            //se realiza inyeccion de dependencias: EspecieRepository implementa IEspecieRepository
            services.AddTransient<ISpecieRepository, SpecieRepository>();
            return services;
        }
    }
}
