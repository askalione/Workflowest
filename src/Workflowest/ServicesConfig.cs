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

            services.AddScoped<CompetitionWorkflowOnEditStateConfigurator>();
            services.AddScoped<CompetitionWorkflowOnModerationStateConfigurator>();
            services.AddScoped<CompetitionWorkflowOpenedStateConfigurator>();
            services.AddScoped<Func<ECompetitionState, ICompetitionWorkflowConfigurator>>(serviceProvider => state =>
            {
                switch (state)
                {
                    case ECompetitionState.OnEdit:
                        return serviceProvider.GetService<CompetitionWorkflowOnEditStateConfigurator>();
                    case ECompetitionState.OnModeration:
                        return serviceProvider.GetService<CompetitionWorkflowOnModerationStateConfigurator>();
                    case ECompetitionState.Opened:
                        return serviceProvider.GetService<CompetitionWorkflowOpenedStateConfigurator>();
                    default:
                        throw new InvalidOperationException($"Configurator for state {state.ToString()} not found"); 
                }
            });

            services.AddScoped<ICompetitionWorkflowConfigurator, CompetitionWorkflowConfigurator>();
            services.AddScoped<ICompetitionWorkflowFactory, CompetitionWorkflowFactory>();
        }
    }
}
