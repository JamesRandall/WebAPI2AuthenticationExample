using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebAPI2AuthenticationExample.iOS.Services
{
    class ValuesService
    {
        public async Task<IEnumerable<string>> GetValues(string accessToken)
        {
            HttpWebRequest request = new HttpWebRequest(new Uri(String.Format("{0}api/Values", Constants.BaseAddress)));
            request.Method = "GET";
            request.Accept = "application/json";
            request.Headers.Add("Authorization", String.Format("Bearer {0}", accessToken));

            try
            {
                HttpWebResponse httpResponse = (HttpWebResponse)(await request.GetResponseAsync());
                string json;
                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    json = new StreamReader(responseStream).ReadToEnd();
                }
                List<string> values = JsonConvert.DeserializeObject<List<string>>(json);
                return values;
            }
            catch (Exception ex)
            {
                throw new SecurityException("Bad credentials", ex);
            }
        }
    }
}