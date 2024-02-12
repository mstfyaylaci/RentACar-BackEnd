using Core.Utilities.Helpers.GuidHelper;
using Microsoft.AspNetCore.Http;
using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    //IFormFile projede httpReguest ile dosya yüklememizi sağlar.
    //Projeye yüklenecek olan dosyalar ile ilgili ekleme,silme ,güncelleme gibi işlemleri yapan sınıftır.

    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath)) //Verilen dosya yolunda bir dosya var mı diye kontrol eder. Eğer dosya mevcutsa, silme işlemine devam edilir.
            {
                File.Delete(filePath);// Dosyayı belirtilen dosya yolundan siler.
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))//Verilen dosya yolunda bir dosya var mı diye kontrol eder. Eğer dosya mevcutsa, silme işlemine devam edilir.
            {
                File.Delete(filePath);// Dosyayı belirtilen dosya yolundan siler.
            }
            return Upload(file, root);// daha sonra yeni dosya ekler
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)// dosya uzunluğu byte olarak alınır.Ve konrtol edilir dosya gönderilmiş mi diye
            {
                if (!Directory.Exists(root))
                // CarImageManagerdan roo gelmekte olup  
                //CarImageManager içerisine girdiğinizde buraya parametre olarak *PathConstants.ImagesPath* bize yüklenen dosyanın kaydedileceği dizinini verir
                //PathConstants clası içerisine girdiğinizde string bir ifadeyle bir dizin adresi var
                //O adres bizim Yükleyeceğimiz dosyaların kayıt edileceği adres burada *Check if a directory Exists* ifadesi şunu belirtiyor dosyanın kaydedileceği adres dizini var mı?
                //varsa if yapısının kod bloğundan ayrılır eğer yoksa içinde ki kodda dosyaların kayıt edilecek dizini oluşturur
                {
                    Directory.CreateDirectory(root);
                }

                string extension = Path.GetExtension(file.FileName);// yüklenen dosyanın uzantısını veriri
                string guid = GuidHelper.GuidHelper.CreateGuid();// benzersiz bir isim oluşuruldu
                string filePath = guid + extension;// dosyanın ismi ile uzantısını yanyana getiriyoruz resim.jpeg gibi

                using (FileStream fileStream = File.Create(root + filePath))//  File.Create(root + newPath)=>Belirtilen yolda bir dosya oluşturur veya üzerine yazar. (root + newPath)=>Oluşturulacak dosyanın yolu ve adı.

                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();// Dosya akışını temizler ve içindeki verileri fiziksel depolama cihazına yazar. Bu, dosyanın tam olarak kaydedilmesini sağlar.
                    return filePath;// sql le eklenecek ismi dönderiyoruz
                }
            }
            return null;
        }
    }
}
