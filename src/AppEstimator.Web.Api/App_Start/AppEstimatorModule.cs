using AppEstimator.Common;
using AppEstimator.Common.Logging;
using AppEstimator.Data.SqlServer.Mapping;
using AppEstimator.Web.Common;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using log4net.Config;
using NHibernate;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppEstimator.Web.Common.Security;
using AppEstimator.Common.Security;
using AppEstimator.Common.TypeMapping;
using AppEstimator.Data.QueryProcessors;
using AppEstimator.Data.SqlServer.QueryProcessors;
using AppEstimator.Web.Api.AutoMappingConfiguration;
using AppEstimator.Web.Api.MaintenanceProcessing;
using Autofac;
using Autofac.Integration.WebApi;
using AppEstimator.Web.Api.Security;
using AppEstimator.Web.Api.InquiryProcessing;
using AppEstimator.Web.Api.LinkServices;
using AppEstimator.Web.Api.Calculators;

namespace AppEstimator.Web.Api
{
    public class AppEstimatorModule : Module
    {
        protected override void Load(ContainerBuilder container)
        {
            ConfigureLog4net(container);
            ConfigureUserSession(container);
            ConfigureNHibernate(container);
            ConfigureAutoMapper(container);
            ConfigureQueryProcessors(container);
            ConfigureMaintenanceProcessors(container);
            ConfigureMiscellaneousTypes(container);
            ConfigureHttpLinkServices(container);
            ConfigureSecurityTypes(container);
        }

        private void ConfigureHttpLinkServices(ContainerBuilder container)
        {
            container.RegisterType<CommonLinkService>()
                .As<ICommonLinkService>()
                .InstancePerRequest();
            container.RegisterType<AppUserLinkService>()
                .As<IAppUserLinkService>()
                .InstancePerRequest();
            container.RegisterType<ActorLinkService>()
                .As<IActorLinkService>()
                .InstancePerRequest();
            container.RegisterType<UseCaseLinkService>()
                .As<IUseCaseLinkService>()
                .InstancePerRequest();
            container.RegisterType<EstimateLinkService>()
                .As<IEstimateLinkService>()
                .InstancePerRequest();
        }

        private void ConfigureSecurityTypes(ContainerBuilder container)
        {
            container.RegisterType<BasicSecurityService>()
                 .As<IBasicSecurityService>()
                 .SingleInstance();
        }

        private void ConfigureMiscellaneousTypes(ContainerBuilder container)
        {
            container.RegisterType<DateTimeAdapter>()
                .As<IDateTime>()
                .InstancePerLifetimeScope();
            container.RegisterType<UseCasePointCalculatorService>()
                .As<IUseCasePointCalculatorService>()
                .SingleInstance();
        }

        private void ConfigureMaintenanceProcessors(ContainerBuilder container)
        {
            container.RegisterType<AddEstimateMaintenanceProcessor>()
               .As<IAddEstimateMaintenanceProcessor>()
               .InstancePerRequest();
            container.RegisterType<EstimateUpdateMaintenanceProcessor>()
                .As<IEstimateUpdateMaintenanceProcessor>()
                .InstancePerRequest();
            container.RegisterType<AddUserMaintenanceProcessor>()
                .As<IAddUserMaintenanceProcessor>()
                .InstancePerRequest();
        }

        private void ConfigureQueryProcessors(ContainerBuilder container)
        {
            container.RegisterType<AddEstimateQueryProcessor>()
                .As<IAddEstimateQueryProcessor>()
                .InstancePerRequest();
            container.RegisterType<EstimateFetcherQueryProcessor>()
                .As<IEstimateFetcherQueryProcessor>()
                .InstancePerRequest();
            container.RegisterType<EstimateInquiryProcessor>()
                .As<IEstimateInquiryProcessor>()
                .InstancePerRequest();
            container.RegisterType<UpdateEstimateQueryProcessor>()
                .As<IUpdateEstimateQueryProcessor>()
                .InstancePerRequest();
            container.RegisterType<UserInquiryProcessor>()
                .As<IUserInquiryProcessor>()
                .InstancePerRequest();
            container.RegisterType<UserFetcherQueryProcessor>()
                .As<IUserFetcherQueryProcessor>()
                .InstancePerRequest();
            container.RegisterType<AddUserQueryProcessor>()
                .As<IAddUserQueryProcessor>()
                .InstancePerRequest();
        }

        private void ConfigureLog4net(ContainerBuilder cb)
        {
            XmlConfigurator.Configure();
            
            cb.RegisterInstance<ILogManager>(new LogManagerAdapter());
        }

        private void ConfigureNHibernate(ContainerBuilder cb)
        {
                var sessionFactory = Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("AppEstimatorDb")))
                .CurrentSessionContext("web")
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EstimateMap>())
                .BuildSessionFactory();

            cb.RegisterInstance<ISessionFactory>(sessionFactory);
            cb.Register(c => {
                var sessionFac = c.Resolve<ISessionFactory>();
                if (!CurrentSessionContext.HasBind(sessionFac))
                {
                    var session = sessionFac.OpenSession();
                    CurrentSessionContext.Bind(session);
                }
                return sessionFac.GetCurrentSession();
            });
            cb.RegisterType<ActionTransactionHelper>().As<IActionTransactionHelper>().InstancePerLifetimeScope();
        }

        private void ConfigureUserSession(ContainerBuilder cb)
        {
            var userSession = new UserSession();
            cb.RegisterInstance<IUserSession>(userSession);
            cb.RegisterInstance<IWebUserSession>(userSession);
        }

        private void ConfigureAutoMapper(ContainerBuilder cb)
        {
            cb.RegisterType<AppUserEntityViewToAppUserInfoAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<AppUserInfoToAppUserEntityViewAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<AutoMapperAdapter>()
                .As<IAutoMapper>()
                .SingleInstance();
            cb.RegisterType<AppUserEntityToAppUserAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<AppUserToAppUserEntityAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<ComplexityEntityToComplexityAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<ComplexityToComplexityEntityAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<NewEstimateToEstimateEntityAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<EstimateEntityToEstimateAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<ActorEntityToActorAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<UseCaseEntityToUseCaseAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<EnvironmentalFactorEntityToEnvironmentatlFactorAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<TechnicalFactorEntityToTechnicalFactorAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<TechnicalFactorToTechnicalFactorEntityAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<EnvironmentalFactorToEnvironmentalFactorEntityAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<ActorToActorEntityAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<UseCaseToUseCaseEntityAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<EFValueEntityToEFValueAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<TFValueEntityToTFValueAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<TFValueToTFValueEntityAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<EFValueToEFValueEntityAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<EstimateInfoEntityToEstimateInfoAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
            cb.RegisterType<NewAppUserToAppUserEntityAutoMapperTypeConfigurator>()
                .As<IAutoMapperTypeConfigurator>()
                .SingleInstance();
        }
    }
}