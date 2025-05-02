# 🚗 Rent A Car Web API (.NET 6)

Bu proje, bir araç kiralama sisteminin (Rent A Car) uçtan uca tüm ihtiyaçlarını karşılamayı hedefleyen bir **.NET 6 Web API** Backend uygulamasıdır. 
## Frontend Projesi

Frontend kısmı için geliştirilmiş olan proje, [RentACar Frontend](https://github.com/mstfyaylaci/RentACar-FrontEnd)
## Backend Projesi;

- Marka, araç, renk ve araç görsellerinin yönetimi,
- Kullanıcı ve müşteri işlemleri,
- Kredi kartı ekleme ve doğrulama,
- Ödeme işlemleri,
- Findex skoru kontrolleri,
- Araç kiralama ve kiralama geçmişi yönetimi

gibi temel işlevler sunulmaktadır.

Katmanlı mimariye göre yapılandırılan sistemde, `Entities`, `DataAccess`, `Business`, `Core` ve `WebAPI` olmak üzere ayrıştırılmış bir yapı kullanılmıştır. Proje, **SOLID ilkeleri** doğrultusunda geliştirilmiş olup kurumsal mimari standartlarına uygundur.

### 🔐 Güvenlik

JWT tabanlı kimlik doğrulama sistemi ile kullanıcı kayıt, giriş, yetkilendirme ve şifre değiştirme işlemleri güvenli bir şekilde gerçekleştirilir.

### 🎯 Temel Özellikler

- Araç listeleme ve filtreleme (marka/renk bazlı)
- Uygunluk kontrolü ile araç kiralama
- Kredi kartı ile ödeme ve kart saklama
- Findex skoru kontrolü (müşteri & araç)
- Kullanıcı ve rol yönetimi
- Katmanlı ve temiz kod mimarisi

---

## 🚀 Kurulum ve Çalıştırma

Bu adımları takip ederek projeyi kendi bilgisayarınızda **MSSQL ile local olarak** çalıştırabilirsiniz.

### 🧰 Gereksinimler

- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Microsoft SQL Server (LocalDB dahil)
- Visual Studio 2022+ veya VS Code
- Git

---


### Kurulum

📥 1. Projeyi Klonlayın

   ```sh
   git clone https://github.com/mstfyaylaci/RentACar-BackEnd.git
   ```
2.  `RentACarProject.sln` dosyasını  `Visual Studio`da açın
3. `DataAccess.Concrete.EntityFramework` dizesindeki  `RentACarContext.cs` dosyasında MSSQL bağlantısı varsayılan olarak yorum satırı halindedir.
4. Eğer projeyi MSSQL LocalDB ile çalıştırmak istiyorsanız  yorumun satırını kaldırın Railway kısmını yorum satırına alın:
5.  `Package Manager Console` açın ve şu komutları girin

   ```sh
   cd DataAccess
   dotnet ef database update
   ```
   `NOTE:` dotnet ef kullanımı için `dotnet ef` aracının kurulması gerekmektedir. Kurulum komutu:
   ```sh
   dotnet tool install --global dotnet-ef
   ```
   
6. `Solution Explorer` da `WebAPI` katmanında sağ tıklayın `Set as Startup Project` diyerek projeyi `IIS Express` e hazır hala getirin. Web API'niz hazır ve çalışıyor!


### 3. Kullanım

Web API'yi çalıştırdıktan sonra şu şekilde HTTP istekleri yapabilirsiniz: 

   
   ```sh
   https://localhost:44372/api/`CONTROLLER_NAME`/`METHOD_NAME`
   ```
 
   `CONTROLLER_NAME` => Each .cs file located in the `WebAPI.Controllers` folder (For example CONTROLLER_NAME for `CarsController`: cars )
   <br><br>
   `METHOD_NAME` => All of the methods in each .cs file in the `WebAPI.Controllers` folder
 
#### Sample HTTP GET requests:

1. List all vehicles:
   ```sh
   https://localhost:44372/api/cars/getall
   ```
2. List a brand by id:
   ```sh
   https://localhost:44372/api/brands/getbyid?id=3
   ```
3. List all vehicle colors:
   ```sh
   https://localhost:44372/api/colors/getall
   ```
## 🛠️ Kullanılan Teknolojiler ve Mimariler

Bu projede modern ve ölçeklenebilir bir mimari oluşturmak adına aşağıdaki teknoloji ve yazılım geliştirme yaklaşımları kullanılmıştır:

### ✅ Entity Framework Core

- Veritabanı işlemleri için ORM aracı olarak **Entity Framework Core** kullanılmıştır.
- `Code First` yaklaşımı benimsenmiş ve veritabanı tabloları doğrudan C# sınıfları üzerinden oluşturulmuştur.

### ✅ Generic Repository Deseni

- **Tekrar kullanılabilirlik** ve **modülerlik** amacıyla `IEntityRepository<T>` arayüzü ile generic repository altyapısı kurulmuştur.
- Bu yapı sayesinde her entity için ayrı ayrı CRUD işlemleri yazmak yerine, ortak bir yapı üzerinden işlemler yapılabilmektedir.

### ✅ LINQ ve Expression Kullanımı
-Repository metotlarında LINQ tabanlı sorgular yapılabilmesi için Expression<Func<T, bool>> parametreleri kullanılmıştır.
-Bu sayede esnek ve okunabilir sorgular elde edilmiştir.
### ✅ DTO (Data Transfer Object)
-Katmanlar arası veri taşırken yalnızca ihtiyaç duyulan alanların transfer edilmesi için DTO yapısı tercih edilmiştir.
-Bu sayede veri güvenliği sağlanmış ve performans artışı elde edilmiştir.
### ✅ IResult ve IDataResult Yapıları
Projede işlem sonuçlarını standartlaştırmak amacıyla `IResult`, `IDataResult`, `SuccessResult`, `ErrorResult`, `SuccessDataResult`, `ErrorDataResult` gibi özel yapılar kullanılmıştır. Bu sayede servis katmanında hem işlem sonucu (başarı/başarısızlık) hem de kullanıcıya gösterilecek mesajlar ve veriler sistematik şekilde yönetilmiştir.
### ✅ Aspect Oriented Programming (AOP)
Projede **Autofac** altyapısı kullanılarak Aspect Oriented Programming uygulanmıştır. Böylece iş mantığından bağımsız olarak çalışan bazı işlemler katmanlar arası ayrıştırılmıştır.
Kullanılan Aspect'ler:
- **Caching**: Sık kullanılan verilerin bellekte saklanması ile performans artışı sağlanmıştır.
- **Performance**: Yavaş çalışan metotların izlenebilmesi amacıyla performans ölçümleri yapılmıştır.
- **Transaction**: Veritabanı işlemlerinde bütünlük sağlamak için işlemler bir bütün olarak ele alınmıştır.
- **Validation**: FluentValidation kütüphanesi ile gelen veriler kontrol altına alınmıştır.
### ✅ Cross Cutting Concerns
Loglama, doğrulama, cache’leme, hata yönetimi gibi uygulamanın genelini ilgilendiren işlemler Cross Cutting Concern olarak ayrılmış ve aspect yapısı ile yönetilmiştir. Bu sayede ana iş mantığı sade ve sürdürülebilir kalmıştır.
### 🔒 Güvenlik ve Kimlik Doğrulama
Projede kullanıcı doğrulama ve yetkilendirme işlemleri için aşağıdaki güvenlik yöntemleri uygulanmıştır:
- **JWT (JSON Web Token)**: Kullanıcı girişlerinde kimlik doğrulama amacıyla JWT token yapısı kullanılmıştır. Giriş yapan kullanıcıya token üretilir ve yetkili işlemler bu token ile gerçekleştirilir.
- **Hashing ve Salting**: Şifreler veri tabanına doğrudan kaydedilmez. Bunun yerine hashing + salting yöntemi ile güvenli bir şekilde şifrelenir.
- **Encryption**: Kredi kartı gibi hassas bilgiler sistem içerisinde şifrelenerek saklanır ve güvenli bir aktarım sağlanır.
- **Role-Based Authorization (RBAC)**: Kullanıcıların sistemdeki rolleri (admin, user vb.) dikkate alınarak belirli işlemlere erişim izinleri kontrol edilmiştir.
### ✅ Yardımcı Sınıflar (Helpers)
Projede sık kullanılan bazı işlemler için yardımcı sınıflar (helper) oluşturulmuştur. Böylece tekrar eden kodlar minimize edilip yeniden kullanılabilir hale getirilmiştir.
- **FileHelper**: Dosya yükleme, güncelleme ve silme işlemlerini yönetir. Özellikle araç görselleri gibi dosya işlemlerinde aktif olarak kullanılır.
- **GuidHelper**: Benzersiz dosya adları veya veriler üretmek için `GUID` temelli yardımcı metotlar içerir.
### ⚠️ Hata Yönetimi (Error Handling)
Projede uygulama hatalarını yönetmek için özel bir **Exception Middleware** yapısı kullanılmıştır. Bu sayede merkezi bir hata yönetimi sağlanmış ve kullanıcı dostu hata mesajları sunulmuştur.
- **ErrorDetails**: Hata mesajlarını ve detaylarını düzgün bir formatta tutmak için kullanılan sınıftır. Herhangi bir hata oluştuğunda bu sınıf ile hata detayları kullanıcıya iletilir.  
- **ExceptionMiddleware**: Tüm uygulama hatalarını yakalamak ve yönetmek için kullanılan middleware yapısıdır. Uygulama seviyesindeki tüm hatalar burada merkezi olarak işlenir ve uygun hata mesajı döndürülür.
- **ExceptionMiddlewareExtensions**: `ExceptionMiddleware`'i uygulama pipeline'ına dahil etmek için kullanılan extension metodudur. Bu yapı, uygulamanın her katmanında hata yönetiminin tutarlı olmasını sağlar.
### 🏢 İş Kuralları (Business Rules)
Projede iş kurallarını yönetmek için **Business Rules** yapısı kullanılmıştır. Bu yapı, belirli iş mantığı kurallarının kontrol edilmesi ve uygulanmasını sağlar. İşlem sırasında birden fazla kural çalıştırılabilir ve sonuçlar merkezi bir şekilde yönetilebilir. 
Bu sayede, uygulamanın iş mantığı merkezi bir noktada yönetilir ve kuralların kontrolü daha düzenli bir şekilde yapılır.


## Contributions

Thanks to dear [Engin Demiroğ](https://github.com/engindemirog) for his contributions.
## Tech Stack
| Technology / Library | Version |
| ------------- | ------------- |
| .NET | 6.0 |
| Autofac | 6.2.0 |
| Autofac.Extensions.DependencyInjection | 7.1.0 |
| Autofac.Extras.DynamicProxy | 6.0.0 |
| FluentValidation | 10.3.0 |
| Microsoft.AspNetCore.Authentication.JwtBearer | 5.0.9 |
| Microsoft.AspNetCore.Http | 2.2.2 |
| Microsoft.AspNetCore.Http.Abstractions | 2.2.0 |
| Microsoft.AspNetCore.Features | 5.0.9 |
| Microsoft.EntityFrameworkCore.Design | 5.0.8 |
| Microsoft.EntityFrameworkCore.SqlServer | 5.0.8 |
| Microsoft.EntityFrameworkCore.Configuration | 5.0.0 |
| Microsoft.EntityFrameworkCore.Configuration.Binder | 5.0.0 |
| Microsoft.IdentityModel.Tokens | 6.12.2 |
| Mime-Detective | 22.7.16 |
| Newtonsoft.Json | 10.0.1 |


