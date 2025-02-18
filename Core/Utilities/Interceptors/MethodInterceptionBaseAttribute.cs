using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    // Attribute yi classlara veya methotara ekleyebilirsin , birden fazla ekleyebilrisn , birden fazla kullanabilirsin
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }// Sıralama yapmak için önce Cache sonra loglama vs

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
