# 🚗 Rent A Car Web API (.NET 6)

Bu proje, bir araç kiralama sisteminin (Rent A Car) uçtan uca tüm ihtiyaçlarını karşılamayı hedefleyen bir **.NET 6 Web API** uygulamasıdır. Proje kapsamında;

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


