using System;
using System.IO;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using WebAPI2AuthenticationExample.iOS.Model;

namespace WebAPI2AuthenticationExample.iOS.Services
{
    class LoginService
    {
        public async Task<string> Login(string username, string password)
        {
            HttpWebRequest request = new HttpWebRequest(new Uri(String.Format("{0}Token", Constants.BaseAddress)));
            request.Method = "POST";

            string postString = String.Format("username={0}&password={1}&grant_type=password", HttpUtility.HtmlEncode(username), HttpUtility.HtmlEncode(password));
            byte[] bytes = Encoding.UTF8.GetBytes(postString);
            using (Stream requestStream = await request.GetRequestStreamAsync())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }

            try
            {
                HttpWebResponse httpResponse =  (HttpWebResponse)(await request.GetResponseAsync());
                string json;
                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    json = new StreamReader(responseStream).ReadToEnd();
                }
                TokenResponseModel tokenResponse = JsonConvert.DeserializeObject<TokenResponseModel>(json);
                return tokenResponse.AccessToken;
            }
            catch (Exception ex)
            {
                throw new SecurityException("Bad credentials", ex);
            }
        }
    }
}