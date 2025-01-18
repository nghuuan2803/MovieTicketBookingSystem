using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MTBS.Domain.Abstracts;
using MTBS.Domain.Abstracts.Repositories;
using MTBS.Domain.Entities;
using MTBS.Infrastructure.Implements.Repositories;
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
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServer")
                    //,builder =>
                    //{
                    //    builder.EnableRetryOnFailure(
                    //    maxRetryCount: 3, // Số lần thử lại tối đa
                    //    maxRetryDelay: TimeSpan.FromSeconds(10), // Thời gian chờ giữa các lần thử lại
                    //    errorNumbersToAdd: null); // Null để áp dụng mặc định các lỗi tạm thời
                    //}
                    );
            });
            services.AddIdentity<User,Role>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.User.RequireUniqueEmail = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddSignInManager();
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!))
                };
                o.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];

                        // Chỉ định đường dẫn của hub
                        var path = context.HttpContext.Request.Path;
                        //if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/notificationHub"))
                        if (!string.IsNullOrEmpty(accessToken))
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            //...
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICinemaRepository, CinemaRepository>();
            services.AddScoped<IHallRepository, HallRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<IShowTimeRepository, ShowTimeRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            return services;
        }
    }
}
