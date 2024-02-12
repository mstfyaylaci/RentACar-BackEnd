using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba Eklendi";
        public static string BrandAdded = "Marka Eklendi";
        public static string ColorAdded = "Renk Eklendi";
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string CustomerAdded = "Müşteri Eklendi";
        public static string RentalAdded = "Kiralama Siparişi Eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz ";
        public static string MainteneanceTime = "sistem bakımda";
        
        public static string CarsListed = "Araba listelendi";
        public static string BrandListed = "Marka listelendi";
        public static string ColorListed = "Renk listelendi";
        public static string UserListed = "Kullanıcı listelendi";
        public static string CustomerListed = "Müşteri listelendi";
        public static string RentalListed = "Kiralama Siparişi  listelendi";
        
        public static string CarByListed = "Araba getirildi";
        public static string BrandByListed = "Marka getirildi";
        public static string ColorByListed = "Renk getirildi";
        public static string UserByListed = "Kullanıcı getirildi";
        public static string CustomerByListed = "Müşteri getirildi";
        public static string RentalByListed = "Kiralama Siparişi getirildi";
        
        public static string DailyPrice = "arabanın günlük fiyatı 0 dan büyük olmalıdır";
        public static string CarLength = "Arabanın ismi 2 karakterden küçük olamaz";
       

        public static string CarsUpdated = "Araba güncelendi";
        public static string BrandUpdated = "Marka güncelendi";
        public static string ColorUpdated = "Renk güncelendi";
        public static string UserUpdated = "Kullanıcı güncelendi";
        public static string CustomerUpdated = "Müşteri güncelendi";
        public static string RentalUpdated = "Kiralama Siparişi  güncelendi";

        public static string CarsDeleted = "Araba silindi";
        public static string BrandDeleted = "Marka silindi";
        public static string ColorDeleted = "Renk silindi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string RentalDeleted = "Kiralama Siparişi  silindi";

        public static string CarNotEmty="Araç şuanda boş değil";

        public static string CarIsDelivered = "Araç teslim edildi";

        public static string IsColorNameNumber = "Renk adı sayı içeremez";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
    }
}
