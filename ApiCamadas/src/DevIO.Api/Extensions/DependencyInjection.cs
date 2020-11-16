using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace DevIO.Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection Resolve ( this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IDbConnection>(db => new SqlConnection(
                   configuration.GetConnectionString("conexaoBd")));

            services.AddDbContext<MeuDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("conexaoBd")));



            return services;
        
        }

    }
}
