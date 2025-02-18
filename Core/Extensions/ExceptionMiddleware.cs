using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //Tüm operasyonlar buradn geçecek
        public async Task InvokeAsync(HttpContext httpContext)
        {
            //tüm kodları try catch e aldık
            try
            {
                await _next(httpContext);//  hata olmassa devam et
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);// hata alırsan handle et
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error";

            IEnumerable<ValidationFailure> errors;

            if (e.GetType() == typeof(ValidationException)) // alınan hata validation hatası ise ona göre bir mesaj oluştur    
            {
                message = e.Message;
                errors = ((ValidationException)e).Errors;// validation kurallarına erişim
                httpContext.Response.StatusCode = 400; // bad request olrak  verdik

                return httpContext.Response.WriteAsync(new ValidationErrorDetails // validation hatası alınırsa dönecek yer
                {
                    StatusCode = 400,
                    Message = message,
                    ValidationErrors = errors
                }.ToString());
            }

            // sistemsel hata bilgisi olarak dönecek kısm
            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
