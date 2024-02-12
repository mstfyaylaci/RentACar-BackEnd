using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    // Şifreleme olan sistemlerin hepsinde bunu byte array cinsinde verilmesi gerek
    //JWT anlayacağı formata çevirmek lazım
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));// simetrik bir anahtar oluşturuldu
        }
    }
}
