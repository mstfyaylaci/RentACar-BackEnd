using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
   //Jwt servislerinin WebApi de kullanılabilmesi için gerekli olan anahtarı kullarak sonucunda bize imzalamasını veren yapı
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);// HAngi anahtarı kullnacağı --- HAngi algoritmayı kullanması gerektiğini söyledik
        }
    }
}
