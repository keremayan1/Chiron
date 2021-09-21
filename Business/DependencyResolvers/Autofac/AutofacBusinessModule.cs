using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Adapters.PersonService;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.MSSQL;
using Module = Autofac.Module;

namespace Business.DependencyResolvers.Autofac
{
   public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PersonManager>().As<IPersonService>().SingleInstance();
            builder.RegisterType<EfPersonDal>().As<IPersonDal>().SingleInstance();

            builder.RegisterType<PersonInformationManager>().As<IPersonInformationService>().SingleInstance();
            builder.RegisterType<EfPersonInformationDal>().As<IPersonInformationDal>().SingleInstance();

            builder.RegisterType<GenderManager>().As<IGenderService>().SingleInstance();
            builder.RegisterType<EfGenderDal>().As<IGenderDal>().SingleInstance();

            builder.RegisterType<PersonGenderManager>().As<IPersonGenderService>().SingleInstance();
            builder.RegisterType<EfPersonGenderDal>().As<IPersonGenderDal>().SingleInstance();

            builder.RegisterType<KpsServiceManager>().As<IKpsService>().SingleInstance();

            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(
                new ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelectors()
                });
        }
    }
}
