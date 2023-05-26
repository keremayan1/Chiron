using System;
using System.Linq;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    [Serializable]
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

      protected override void OnBefore(IInvocation invocation)
      {
          var validator = (IValidator)Activator.CreateInstance(_validator);
          var entityType = _validator.BaseType.GetGenericArguments()[0];
          var entities = invocation.Arguments.Where(x => x.GetType() == entityType);
          foreach (var entity in entities)
          {
              ValidationTool.Validate(validator,entity);
          }
      }
    }
}
