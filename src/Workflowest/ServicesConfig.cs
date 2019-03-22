using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Workflowest.Domain;
using Workflowest.Infrastructure;
using Workflowest.Infrastructure.Impl;
using Workflowest.Services;
using Workflowest.Services.Impl;
using Workflowest.Workflows;
using Workflowest.Workflows.Impl;

namespace Workflowest
{
    static class ServicesConfig
    {
        public static void Configure(ServiceCollection services)
        {
            services.AddScoped<IUserPrincipalProvider, UserPrincipalProvider>();
            services.AddScoped<IActorProvider, ActorProvider>();
            services.AddScoped<IService, Service>();

            services.AddScoped<CompetitionOnEditStateMachineConfigurator>();
            services.AddScoped<CompetitionOnModerationStateMachineConfigurator>();
            services.AddScoped<CompetitionOpenedStateMachineConfigurator>();
            services.AddScoped<Func<ECompetitionState, ICompetitionStateMachineConfigurator>>(serviceProvider => state =>
            {
                switch (state)
                {
                    case ECompetitionState.OnEdit:
                        return serviceProvider.GetService<CompetitionOnEditStateMachineConfigurator>();
                    case ECompetitionState.OnModeration:
                        return serviceProvider.GetService<CompetitionOnModerationStateMachineConfigurator>();
                    case ECompetitionState.Opened:
                        return serviceProvider.GetService<CompetitionOpenedStateMachineConfigurator>();
                    default:
                        throw new InvalidOperationException($"Configurator for state {state.ToString()} not found"); 
                }
            });

            services.AddScoped<ICompetitionStateMachineConfigurator, CompetitionStateMachineConfigurator>();
            services.AddScoped<ICompetitionWorkflowProvider, CompetitionWorkflowProvider>();
        }
    }
}
