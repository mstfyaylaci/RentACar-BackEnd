using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        // sana gelen bir password ün hashini oluştur , yani dışarıya passwordHash ve passwordSalt çıkacak
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())// algoritmayı seçiyoruz
            {
                passwordSalt = hmac.Key;// her  kullanıcı için bir key değeri oluşur
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));// gelen passwordü byte çevirip onu metoda gönderip hashini gönderdi
            }
        }

        // password hashini doğrulama 
        // Gelen hash değeri ile veri tabanımızdaki hash değeri uyuarsa true dönecek
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++) 
                {
                    if (computedHash[i] != passwordHash[i])// hesaplanan hash ile veri tabanındaki tüm hashleri karşılaştır
                    {
                        return false;
                    }
                }
                return true;
            }

            
        }
    }
}
