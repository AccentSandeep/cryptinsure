using System;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using CryptinsureCore.Bindings;

namespace CryptinsureCore.Communication
{

    public class HttpChannel : IClient<Dictionary<string, string>, Dictionary<string, string>, JObject>, IDisposable
    {

        private HttpClientHandler _header;
        private Dictionary<string, string> _request;
        private readonly CommunicationHelper _helper = new CommunicationHelper();

        public B SendRequest<B>(Dictionary<string, string> request, Dictionary<string, string> credentials, string Method)
        {
            B response;
            _request = request;
            _header = _helper.SetHeader(request, credentials);

            switch (Method)
            {
                case "POST":
                    var httprequest = new HttpRequestMessage { Content = new StringContent(request["request"], Encoding.UTF8, request["Header:Content-Type"].ToString()) };
                    response = PostAsync<B>(_request["uri"], httprequest.Content).Result;
                    break;
                case "GET":
                    response = GetAsync<B>(_request["uri"]).Result;
                    break;
                default:
                    return default(B);
            }
            Dispose();
            return response;
        }

        public async Task<T> PostAsync<T>(string uri, HttpContent httpcontent)
        {

            using (var httpClient = new HttpClient(_header))
            {
                _helper.UpdateClientHeaders(httpClient, _request);
                HttpResponseMessage response = await httpClient.PostAsync(new Uri(uri), httpcontent).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Connectivity issue: Cannot establish connection with server");
                }

                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return _helper.FormatResponse<T>(responseContent);

            }
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            using (var httpClient = new HttpClient(_header))
            {
                _helper.UpdateClientHeaders(httpClient, _request);
                HttpResponseMessage response = await httpClient.GetAsync(new Uri(uri)).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Connectivity issue: Cannot establish connection with server");
                }

                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return _helper.FormatResponse<T>(responseContent);
            }
        }

        public void Dispose()
        {
            ((IDisposable)_header).Dispose();
        }
    }
}
