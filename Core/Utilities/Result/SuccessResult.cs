using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message)
        {
        }

        public SuccessResult():base(true) // mesaj yollanmak istenmediğinde base deki cont çağır
                                          // ve true succes durumunu true gönder
        {
            
        }
    }
}
