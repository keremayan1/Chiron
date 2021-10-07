using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
  public  class SecuredOperation:MethodInterception
  {
      private string[] _roles;
      private IHttpContextAccessor _contextAccessor;

      public SecuredOperation(string roles)
      {
          _roles = roles.Split(',');
          _contextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
      }

      protected override void OnBefore(IInvocation invocation)
      {
          var roleClaims = _contextAccessor.HttpContext.User.ClaimRoles();
          foreach (var role in _roles)
          {
              if (roleClaims.Contains(role))
              {
                  return;
              }
          }

          throw new AuthenticationException("Yetkiniz Yok!");
      }
  }
}
