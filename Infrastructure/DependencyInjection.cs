
using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Activities;
using Application.Interfaces.ActivityType;
using Application.Interfaces.Tasks;
using Application.Interfaces.User;
using Application.Services;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            
            services.AddScoped<IActivityTypeService, ActivityTypeService>();
            services.AddScoped<IActivityTypeRepository, ActivityTypeRepository>();
            
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
