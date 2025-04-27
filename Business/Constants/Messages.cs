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
        public static string CarsListed = "Araba listelendi";
        public static string CarByListed = "Araba getirildi";
        public static string CarsUpdated = "Araba güncelendi";
        public static string CarsDeleted = "Araba silindi";

        public static string BrandAdded = "Marka Eklendi";
        public static string BrandListed = "Marka listelendi";
        public static string BrandByListed = "Marka getirildi";
        public static string BrandUpdated = "Marka güncelendi";
        public static string BrandDeleted = "Marka silindi";

        public static string ColorAdded = "Renk Eklendi";
        public static string ColorListed = "Renk listelendi";
        public static string ColorByListed = "Renk getirildi";
        public static string ColorUpdated = "Renk güncelendi";
        public static string ColorDeleted = "Renk silindi";

        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserListed = "Kullanıcı listelendi";
        public static string UserByListed = "Kullanıcı getirildi";
        public static string UserUpdated = "Kullanıcı güncelendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerListed = "Müşteri listelendi";
        public static string CustomerByListed = "Müşteri getirildi";
        public static string CustomerUpdated = "Müşteri güncelendi";
        public static string CustomerDeleted = "Müşteri silindi";


        public static string RentalAdded = "Kiralama Siparişi Eklendi";
        public static string RentalListed = "Kiralama Siparişi  listelendi";
        public static string RentalByListed = "Kiralama Siparişi getirildi";
        public static string RentalUpdated = "Kiralama Siparişi  güncelendi";
        public static string RentalDeleted = "Kiralama Siparişi  silindi";
        public static string CarNotEmty = "Kiralanmak istenen Araç şuanda boş değil";
        public static string CarIsDelivered = "Araç teslim edildi";
        public static string ReservationBetweenSelectedDatesExist = "Secilen tarihler arasinda zaten bir rezervasyon mevcut";
        public static string CarCanBeRentedBetweenSelectedDates = "Araba, secilen tarihler arasinda kiralanabilir";
        public static string DeliveryStatusMustFalse = "Araç teslim durumu false olmalı";
        public static string DeliveryStatusMustNull = "Araç teslim durumu null olmalı";
        public static string DeliveryStatusMustNotBeNull = "Araç teslim durmu null olamaz";


        public static string ProductNameInvalid = "Ürün ismi geçersiz ";
        public static string MainteneanceTime = "sistem bakımda";

        public static string DailyPrice = "arabanın günlük fiyatı 0 dan büyük olmalıdır";
        public static string CarLength = "Arabanın ismi 2 karakterden küçük olamaz";
        public static string IsColorNameNumber = "Renk adı sayı içeremez";

        public static string CreditCardNotFound = "Kredi kartı bulunamadı";

        public static string CreditCardListed = "Kredi kartı listelendi";

        public static string CreditCardNotValid = "Kredi kartı geçersiz";

        public static string StringMustConsistOfNumbersOnly = "Kredi kartı numarası sadece rakamlardan oluşmalıdır";

        public static string CustomersCreditCardsListed = "Müsterinin kredi kartlari listelendi";

        public static string CustomerCreditCardAlreadySaved = "Kredi karti zaten kaydedilmis";

        public static string CustomerCreditCardSaved = "Müsteri kredi karti basariyla kaydedildi";
        public static string CustomerCreditCardFailedToSave = "Müsteri kredi karti kaydedilemedi";

        public static string CustomerCreditCardNotFound = "Müsteri kredi karti bulunamadi";

        public static string CustomerCreditCardDeleted = "Müsteri kredi karti silindi";

        public static string CustomerCreditCardNotDeleted = "Müsteri kredi karti silinemedi";

        public static string PasswordChanged = "Parola Değiştirildi";

        public static string CreditCardAdded = "Kredi kartı başarıyla eklendi";

        public static string CreditCardDeleted = "Kredi kartı başarıyla silindi";

        public static string InsufficientCardBalance = "Kredi kartı bakiyesi yetersiz";

        public static string PaymentSuccessful = "Ödeme başarılı";

        public static string LeastOneCustomerIdDoesNotMatch = "En az bir müşteri kimliği eşleşmiyor";

        public static string CarAlreadyRentedByTheReservationDate = "Araç, rezervasyon tarihine göre zaten kiralanmış durumda";

        public static string InsufficientFindexScore = "Findex puanı yetersiz";

        public static string TotalAmountNotMatch = "Toplam tutar eşleşmiyor";

        public static string RentalSuccessful = "Kiralama işlemi başarılı";

        public static string CustomerNotExist = "Müşteri mevcut değil";

        public static string UserEmailExist = "kullanıcı maili mevcut";

        public static string UserEmailNotAvailable = "kullanıcı maili yok";
    }
}
