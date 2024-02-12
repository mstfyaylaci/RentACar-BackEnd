using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.GuidHelper
{
    public  class GuidHelper
    {
        // Yüklenecek olan dosya için benzersiz bir isim oluşturulmasına olan sağlar.
        // Yeni eklenecek olan dosyanın ismi kendi simi olmasın
        // ben ona bernzersiz bir isim oluşturacağım ki aynı isimden başka yükleme olmasın.
        
       public static string CreateGuid() 
        {
            return Guid.NewGuid().ToString(); // Eşşiz bir isim oluşturuldu.Stringe çevirildi
        }
    }
}
