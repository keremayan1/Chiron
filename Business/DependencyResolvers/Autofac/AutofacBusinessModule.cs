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
using Core.Utilities.Security.Jwt;
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

            builder.RegisterType<EducationStatusManager>().As<IEducationManagerService>().SingleInstance();
            builder.RegisterType<EfEducationStatusDal>().As<IEducationStatusDal>().SingleInstance();

            builder.RegisterType<ChildrenManager>().As<IChildrenService>().SingleInstance();
            builder.RegisterType<EfChildrenDal>().As<IChildrenDal>().SingleInstance();

            builder.RegisterType<FamilyStatusManager>().As<IFamilyStatusService>().SingleInstance();
            builder.RegisterType<EfFamilyStatusDal>().As<IFamilyStatusDal>().SingleInstance();

            builder.RegisterType<JobManager>().As<IJobService>().SingleInstance();
            builder.RegisterType<EfJobDal>().As<IJobDal>().SingleInstance();

            builder.RegisterType<ChildrenPersonManager>().As<IChildrenPersonService>().SingleInstance();
            builder.RegisterType<EfChildrenPersonDal>().As<IChildrenPersonDal>().SingleInstance();

            builder.RegisterType<AddressManager>().As<IAddressService>().SingleInstance();
            builder.RegisterType<EfAddressDal>().As<IAddressDal>().SingleInstance();

            builder.RegisterType<TelephoneManager>().As<ITelephoneService>().SingleInstance();
            builder.RegisterType<EfTelephoneDal>().As<ITelephoneDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();

            builder.RegisterType<QuestionManager>().As<IQuestionService>().SingleInstance();
            builder.RegisterType<EfQuestionDal>().As<IQuestionDal>().SingleInstance();

            builder.RegisterType<QuestionTitleManager>().As<IQuestionService>().SingleInstance();
            builder.RegisterType<EfQuestionTitleDal>().As<IQuestionTitleDal>().SingleInstance();

            builder.RegisterType<QuestionAnswerManager>().As<IQuestionAnswerService>().SingleInstance();
            builder.RegisterType<EfQuestionAnswerDal>().As<IQuestionAnswerDal>().SingleInstance();


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
