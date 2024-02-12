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

// Cliient istek geldiği zaman bu metot çalışcak
//İlgili kullaınıcı için bu kullanıcı için ilgili Claimleri bulacak ve içerisinde bilgileri barındıran Bir JWT üretecek 