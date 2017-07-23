using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace CryptinsureCore.Communication
{
    public class CommunicationHelper
    {

        public HttpClient UpdateClientHeaders(HttpClient client, Dictionary<string, string> headers)
        {
            foreach (KeyValuePair<string, string> header in headers)
            {
                var key = header.Key.Split(':');

                if (key[0] == "Header")
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation(key[1], header.Value);
                }
            }

            return client;
        }

        public HttpClientHandler SetHeader(IDictionary<string, string> request, Dictionary<string, string> credentials)
        {
            var domain = request.ContainsKey("Domain") ? request["Domain"] : "";
            var useProxy = Convert.ToBoolean(request["useProxy"]);

            var _header = new HttpClientHandler
            {
                Credentials = new NetworkCredential(credentials["Username"], credentials["Password"], domain),
                UseProxy = useProxy
            };

            if (useProxy)
            {
                _header.Proxy = new WebProxy(request["proxyUrl"]);
                _header.UseDefaultCredentials = true;
                _header.Proxy.Credentials = new NetworkCredential(credentials["proxyUsername"], credentials["proxyPassword"]);
            }

            return _header;
        }

        public T FormatResponse<T>(string input)
        {
            T response = default(T);

            if (typeof(T) == typeof(JObject))
            {
                response = JsonConvert.DeserializeObject<T>(input);
            }
            else if (typeof(T) == typeof(string))
            {
                response = (T)Convert.ChangeType(input, typeof(T));
            }

            return response;
        }
    }
}
