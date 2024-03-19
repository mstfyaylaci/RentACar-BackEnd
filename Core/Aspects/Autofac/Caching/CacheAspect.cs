using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration; // cache de bekleme süresi
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60) //60 dk
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation) // metot çalışmadan buralar çalışacak
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}"); // ReflectedType:namespacesini+manager al .metot ismi
                                                                                                                    // ReentAcar.buisness.ICarService.Getall
            var arguments = invocation.Arguments.ToList(); // metodun parametlerini listeye çebir
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"; // parametleri varsa GetAll(parametre=="1") olarak geç yoksa null dön
            if (_cacheManager.IsAdd(key)) // Bellekte böyle bir anahtar var mı?
            {
                invocation.ReturnValue = _cacheManager.Get(key); // varsa metotdı çalıştırmadan geri dön , cacheden metodu.get(key) yap
                return;
            }
            invocation.Proceed(); // Eğer yoksa metodu çalıştırmaya devam et yani veri tabanından getir
            _cacheManager.Add(key, invocation.ReturnValue, _duration);// Metotdu cache ekle
        }
    }
}
