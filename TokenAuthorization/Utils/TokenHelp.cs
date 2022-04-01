using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAuthorization.Models;

namespace TokenAuthorization.Utils
{
    public class TokenHelp
    {
        public static Token GetToken(string userAccount, string userPwd)
        {
            string AccessTokenKey = ConfigHelp.GetString("AccessTokenKey");

            string userId = Guid.NewGuid().ToString();

            //2. 生成accessToken
            //过期时间
            double exp = (DateTime.UtcNow.AddMinutes(5) - new DateTime(1970, 1, 1)).TotalSeconds;
            var payload = new Dictionary<string, object>
                     {
                   { "userId", userId },
                   { "userAccount", userAccount },
                   { "exp",exp }
                };
            var accessToken = JWTHelp.JWTJiaM(payload, AccessTokenKey);

            return new Token
            {
                accessToken = accessToken
            };
        }
        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="base64UrlStr"></param>
        /// <returns></returns>

        public static string Base64UrlDecode(string base64UrlStr)
        {
            base64UrlStr = base64UrlStr.Replace('-', '+').Replace('_', '/');
            switch (base64UrlStr.Length % 4)
            {
                case 2:
                    base64UrlStr += "==";
                    break;
                case 3:
                    base64UrlStr += "=";
                    break;
            }
            var bytes = Convert.FromBase64String(base64UrlStr);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
