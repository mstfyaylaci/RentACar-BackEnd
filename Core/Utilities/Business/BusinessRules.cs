using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //BusinnesRules.Run(iş kuralı(),işkuralı_2()) şeklinde kullanılacak
        public static IResult Run(params IResult[] logics)// gönderilen tüm parametreli yani metotları listeye atılıyor
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;// iş kuralından uymayanını  dönderir
                }
            }
            return null;
        }
    }
}
