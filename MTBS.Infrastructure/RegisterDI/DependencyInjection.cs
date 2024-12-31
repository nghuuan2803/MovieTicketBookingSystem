using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MTBS.Domain.Abstracts.Repositories;
using MTBS.Infrastructure.MockData.MockRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Infrastructure.RegisterDI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMovieRepository, MockMovieRepo>();
            //...
            return services;
        }
    }
}
