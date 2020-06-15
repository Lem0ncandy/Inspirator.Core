using Inspirator.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inspirator.WebAPI.Extensions
{
    public static class DBContextSetUp
    {
        public static void AddDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer()
                    .AddDbContext<MainContext>(options =>
                    {
                        options.UseSqlServer(configuration.GetConnectionString("MainContext"));

                    }, ServiceLifetime.Scoped);
        }
    }
}
