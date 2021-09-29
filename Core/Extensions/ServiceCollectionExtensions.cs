using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
  public  static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection collection, params ICoreModule[] modules)
        {
            foreach (var coreModule in modules)
            {
                coreModule.Load(collection);
            }

            return ServiceTool.Create(collection);
        }
    }
}
