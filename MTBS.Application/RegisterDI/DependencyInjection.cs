using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MTBS.Application.Helper;
using MTBS.Application.Validators;
using System.Reflection;

namespace MTBS.Application.RegisterDI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DependencyInjection).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Đăng ký ValidationBehavior
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            //...
            return services;
        }
    }
}
