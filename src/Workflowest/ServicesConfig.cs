using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workflowest.Domain;
using Workflowest.Infrastructure;
using Workflowest.Infrastructure.Impl;
using Workflowest.Services;
using Workflowest.Services.Impl;
using Workflowest.Workflows;
using Workflowest.Workflows.Abstractions;
using Workflowest.Workflows.Impl;
using Workflowest.Workflows.Stateless;

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

            services.AddScoped<Func<ECompetitionState, IStateMachineConfigurator <Competition, ECompetitionState, ECompetitionEvent>>> (serviceProvider => state =>
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

            services
                .Scan(opt => opt.FromAssemblies(typeof(ServicesConfig).Assembly)
                    .AddClasses(classes => classes.AssignableTo(typeof(IStateMachineConfigurator<,,>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .As(c => c.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IStateMachineConfigurator<,,>)))
                    .WithScopedLifetime());
            services
                .Scan(opt => opt.FromAssemblies(typeof(ServicesConfig).Assembly)
                    .AddClasses(classes => classes.AssignableTo(typeof(IStateMachineFactory<,,>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .As(c => c.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IStateMachineFactory<,,>)))
                    .WithScopedLifetime());
            services
                .Scan(opt => opt.FromAssemblies(typeof(ServicesConfig).Assembly)
                    .AddClasses(classes => classes.AssignableTo(typeof(IWorkflowProvider<,,,,>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            //services.AddScoped<ICompetitionWorkflowProvider, CompetitionWorkflowProvider>();

            //services.AddScoped<Func<ECompetitionState, ICompetitionStateMachineConfigurator>>(serviceProvider => state =>
            //{
            //    switch (state)
            //    {
            //        case ECompetitionState.OnEdit:
            //            return serviceProvider.GetService<CompetitionOnEditStateMachineConfigurator>();
            //        case ECompetitionState.OnModeration:
            //            return serviceProvider.GetService<CompetitionOnModerationStateMachineConfigurator>();
            //        case ECompetitionState.Opened:
            //            return serviceProvider.GetService<CompetitionOpenedStateMachineConfigurator>();
            //        default:
            //            throw new InvalidOperationException($"Configurator for state {state.ToString()} not found"); 
            //    }
            //});

            //services.AddScoped<ICompetitionStateMachineFactory, CompetitionStateMachineFactory>();
            //services.AddScoped<ICompetitionStateMachineConfigurator, CompetitionStateMachineConfigurator>();
            //services.AddScoped<ICompetitionWorkflowProvider, CompetitionWorkflowProvider>();
        }
    }
}
