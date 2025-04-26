using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;

namespace Core.Utilities.Interceptors
{ 
    /* Metodun,classın üstüne yazıdığımız [Attrıbute] leri bir listeye öncelik srasına göre listeye koyar
     * */
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute> // git classın attributlerini oku
                (true).ToList();


            var methodAttributes = method
           .GetCustomAttributes<MethodInterceptionBaseAttribute>(true); // method zaten elimizde

            //var methodAttributes = type.GetMethod(method.Name)
            //    .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);// git metotdun attributlerini oku 
            classAttributes.AddRange(methodAttributes); // onları bir listeye koy


            return classAttributes.OrderBy(x => x.Priority).ToArray();// öncelik sıralamasına göre 
        }
    }
}
