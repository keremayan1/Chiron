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
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.MSSQL;
using DataAccess.Concrete.EntityFramework.MSSQL.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
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

            builder.RegisterType<EducationStatusManager>().As<IEducationStatusService>().SingleInstance();
            builder.RegisterType<EfEducationStatusDal>().As<IEducationStatusDal>().SingleInstance();

            builder.RegisterType<ChildrenManager>().As<IChildrenService>().SingleInstance();
            builder.RegisterType<EfChildrenDal>().As<IChildrenDal>().SingleInstance();

            builder.RegisterType<FamilyStatusManager>().As<IFamilyStatusService>().SingleInstance();
            builder.RegisterType<EfFamilyStatusDal>().As<IFamilyStatusDal>().SingleInstance();
         

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

            builder.RegisterType<QuestionTitleManager>().As<IQuestionTitleService>().SingleInstance();
            builder.RegisterType<EfQuestionTitleDal>().As<IQuestionTitleDal>().SingleInstance();

            builder.RegisterType<QuestionAnswerManager>().As<IQuestionAnswerService>().SingleInstance();
            builder.RegisterType<EfQuestionAnswerDal>().As<IQuestionAnswerDal>().SingleInstance();

            builder.RegisterType<MarriedStatusManager>().As<IMarriedStatusService>().SingleInstance();
            builder.RegisterType<EfMarriedStatusDal>().As<IMarriedStatusDal>().SingleInstance();

            builder.RegisterType<ReligionManager>().As<IReligionService>().SingleInstance();
            builder.RegisterType<EfReligionDal>().As<IReligionDal>().SingleInstance();

            builder.RegisterType<AdultManager>().As<IAdultService>().SingleInstance();
            builder.RegisterType<EfAdultDal>().As<IAdultDal>().SingleInstance();

            builder.RegisterType<AdultWifeManager>().As<IAdultWifeService>().SingleInstance();
            builder.RegisterType<EfAdultWifeDal>().As<IAdultWifeDal>().SingleInstance();

            builder.RegisterType<AdultChildrenManager>().As<IAdultChildrenService>().SingleInstance();
            builder.RegisterType<EfAdultChildrenDal>().As<IAdultChildrenDal>().SingleInstance();

            builder.RegisterType<ContactInformationManager>().As<IContactInformationService>().SingleInstance();
            builder.RegisterType<EfContactInformationDal>().As<IContactInformationDal>().SingleInstance();

            builder.RegisterType<ChildrenSiblingsManager>().As<IChildrenSiblingsService>().SingleInstance();
            builder.RegisterType<EfChildrenSiblingsDal>().As<IChildrenSiblingsDal>().SingleInstance();

            builder.RegisterType<AdultAdultChildrenManager>().As<IAdultAdultChildrenService>().SingleInstance();
            builder.RegisterType<EfAdultAdultChildren>().As<IAdultAdultChildrenDal>().SingleInstance();

          //  builder.RegisterType<SqlContext>().As<DbContext>().SingleInstance();
                
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
