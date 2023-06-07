using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Abstract.AuthApi;
using Business.Abstract.CustomerApi;
using Business.Abstract.MeterApi;
using Business.Abstract.ModemApi;
using Business.Abstract.ReadingApi;
using Business.Concrete.AuthApi;
using Business.Concrete.CustomerApi;
using Business.Concrete.MeterApi;
using Business.Concrete.ModemApi;
using Business.Concrete.ReadingApi;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthApiManager>().As<IAuthApiService>().SingleInstance();
            builder.RegisterType<AuthUserApiManager>().As<IAuthUserApiService>().SingleInstance();
            builder.RegisterType<AuthOperationClaimApiManager>().As<IAuthOperationClaimApiService>().SingleInstance();
            builder.RegisterType<AuthUserOperationClaimsApiManager>().As<IAuthUserOperationClaimsApiService>().SingleInstance();

            builder.RegisterType<MeterApiManager>().As<IMeterApiService>().SingleInstance();
            builder.RegisterType<MeterBrandApiManager>().As<IMeterBrandApiService>().SingleInstance();
            builder.RegisterType<MeterModelApiManager>().As<IMeterModelApiService>().SingleInstance();
            builder.RegisterType<MeterReadingTimeApiManager>().As<IMeterReadingTimeApiService>().SingleInstance();

            builder.RegisterType<ReadingApiManager>().As<IReadingApiService>().SingleInstance();

            builder.RegisterType<ModemApiManager>().As<IModemApiService>().SingleInstance();
            builder.RegisterType<ModemBrandApiManager>().As<IModemBrandApiService>().SingleInstance();
            builder.RegisterType<ModemModelApiManager>().As<IModemModelApiService>().SingleInstance();

            builder.RegisterType<CustomerApiManager>().As<ICustomerApiService>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
