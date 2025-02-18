using Core.Entities.Concrete;
using Core.Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}

// Client istek attığı zaman bu metot çalışcak
//İlgili kullanıcı için veri tabanına gidecek bu kullanıcı için ilgili Claimleri bulacak ve içerisinde
//bilgileri barındıran Bir JWT üretecek ve onu Cliente verecelk