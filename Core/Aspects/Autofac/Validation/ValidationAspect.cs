using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
  public  class ValidationAspect:MethodInterception
  {
      private Type _validator;

      public ValidationAspect(Type validator)
      {
          if (!typeof(IValidator).IsAssignableFrom(validator))
          {
              throw new Exception("Doğrulama Hatası");
          }

          _validator = validator;
      }

      public override void OnBefore(IInvocation invocation)
      {
          var validator = (IValidator)Activator.CreateInstance(_validator);
          var entityType = _validator.GetGenericArguments()[0];
          var entities = invocation.Arguments.Where(x => x.GetType() == entityType);
          foreach (var entity in entities)
          {
              ValidationTool.Validate(validator,entity);
          }
      }
    }
}
