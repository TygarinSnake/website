using System.Security.Cryptography;
using System.Text;

namespace AuthenticationService.Helpers
{
    public static class SHA512Generator
    {
        public static string ToSHA512(this string str)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(str);
                byte[] hash = sha512.ComputeHash(bytes);

                StringBuilder hashBuilder = new StringBuilder();
                foreach (byte b in hash)
                {
                    hashBuilder.Append(b.ToString("x2"));
                }

                return hashBuilder.ToString();
            }
        }
    }
}
