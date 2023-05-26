using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Performance
{
   public class PerformanceScopeAspect:MethodInterception
   {
       private int _interval;
       private Stopwatch _stopwatch;

       public PerformanceScopeAspect(int interval, Stopwatch stopwatch)
       {
           _interval = interval;
           _stopwatch = stopwatch;
       }

       protected override void OnBefore(IInvocation invocation)
       {
           _stopwatch.Start();
       }

       protected override void OnAfter(IInvocation invocation)
       {
           if (_stopwatch.Elapsed.TotalSeconds > _interval)
           {
               throw new System.Exception($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
           }
           _stopwatch.Reset();
        }
   }
}
