﻿using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspect.Autofac
{   //JWT için asspect
    //Autharization aspectleri genellkikle businnesa yazılır çünkü yetkilendirme algoritmaarı değieşbilir
    // yetki kontrolü yapılan classs
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles; //roller virgülle ayrılarak ayırt edilir
        private IHttpContextAccessor _httpContextAccessor;// jwt ile http isteği atıldığında her bir kişi için thread oluşur

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();//windows form gibi yerlerde İnjeciton kullanılabilmesi için ServisTool yazıldı 

        }

        protected override void OnBefore(IInvocation invocation) // yetkisi var mı bak
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();// rollleri gez
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;// eğer istenilen rol var ise yani admin ise metodu çalıştırmaya devam et
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
