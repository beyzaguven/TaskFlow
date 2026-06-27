using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Application.Interfaces;
using TaskFlow.Application.Services;

namespace TaskFlow.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<IWorkspaceService, WorkspaceService>();

        services.AddScoped<IWorkspaceAuthorizationService, WorkspaceAuthorizationService>();

        services.AddScoped<IProjectService, ProjectService>();

        return services;
    }
}