using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebAPI2AuthenticationExample.iOS.Model;

namespace WebAPI2AuthenticationExample.iOS.Services
{
    class RegisterService
    {
        public async Task<bool> Register(string username, string password, string confirmPassword)
        {
            RegisterModel model = new RegisterModel
            {
                ConfirmPassword = confirmPassword,
                Password = password,
                UserName = username
            };

            HttpWebRequest request = new HttpWebRequest(new Uri(String.Format("{0}api/Account/Register", Constants.BaseAddress)));
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            string json = JsonConvert.SerializeObject(model);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            using(Stream stream = await request.GetRequestStreamAsync())
            {
                stream.Write(bytes, 0, bytes.Length);
            }

            try
            {
                await request.GetResponseAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}