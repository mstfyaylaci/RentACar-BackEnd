using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    // her yere try catch yazılmaması için yazılmış bir yapı
    // tüm metotlar bu kurallardan geçerse çalışacak, yani bütün metotların çatısı konumunda
    // invocation = burada metot konumunda
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation); // metottan önce çalıştır
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);// hata aldığında çalıtır
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);// her şey başarılı olduğunda çalış
                }
            }
            OnAfter(invocation); // metot bittinğinde çalış
        }

       
    }
}
