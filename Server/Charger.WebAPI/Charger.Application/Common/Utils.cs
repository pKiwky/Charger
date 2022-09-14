using System.Security.Cryptography;
using System.Text;

namespace Charger.Application.Common {

    public static class Utils {
        public static string CreateSHA512(string data) {
            var message = Encoding.UTF8.GetBytes(data);
            using (var alg = SHA512.Create()) {
                string hex = "";

                var hashValue = alg.ComputeHash(message);
                foreach (byte x in hashValue) {
                    hex += String.Format("{0:x2}", x);
                }

                return hex;
            }
        }
    }

}