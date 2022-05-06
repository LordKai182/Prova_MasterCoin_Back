using API.Security;
using Domain.Commands.Usuario.Adicionar;
using Domain.Interfaces;
using Infra.Repositories;
using Infra.Repositories.Base;
using Infra.Transactions;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace API
{
  
        public static class Setup
        {
            private const string ISSUER = "c1f51f42";
            private const string AUDIENCE = "c6bbbb645024";
            public static void ConfigureAuthentication(this IServiceCollection services)
            {
              
                services.AddCors();
             
            }

            public static void ConfigureMediatR(this IServiceCollection services)
            {

                services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly, typeof(AdicionarUsuarioResquest).GetTypeInfo().Assembly);
                
            }

            public static void ConfigureRepositories(this IServiceCollection services)
            {
                #region INTERFACES

                services.AddScoped<MasterCoinContext, MasterCoinContext>();


                services.AddTransient<IUnitOfWork, UnitOfWork>();

                services.AddTransient<IRepositoryUsuario, RepositoryUsuario>();

               

                #endregion
            }

            public static void ConfigureSwagger(this IServiceCollection services)
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "MasterCoin", Version = "v1" });
                  
                   
             });
                
            }

            public static void ConfigureMVC(this IServiceCollection services)
            {
                services.AddCors();

                services.AddMvc(options =>
                {

                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ssZ";
                    options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
            }

        }
    }

