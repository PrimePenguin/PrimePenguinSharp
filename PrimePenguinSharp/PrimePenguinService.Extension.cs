using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using PrimePenguinSharp;

namespace PrimePenguinSharp
{
    public partial class Client
    {
        public string _accessToken;
        public int _tenantId;

        public Client(string baseUrl, string accessToken, int tenantId) : this(baseUrl, new HttpClient())
        {
            BaseUrl = baseUrl;
            _accessToken = accessToken;
            _tenantId = tenantId;
        }

        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, StringBuilder urlBuilder)
        {
        }

        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
        {
            request.Headers.Add("Abp.TenantId", _tenantId.ToString());
            request.Headers.Add("Authorization", $"Bearer {_accessToken}");
        }

        partial void ProcessResponse(HttpClient client, HttpResponseMessage response)
        {
        }

        partial void UpdateJsonSerializerSettings(JsonSerializerSettings settings)
        {
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;
        }

        public partial class PrimePenguinServiceException : System.Exception
        {
            public int StatusCode { get; private set; }

            public string Response { get; private set; }

            public PrimePenguinResponse<dynamic> PrimePenguinResponse { get; set; }

            public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; private set; }

            public PrimePenguinServiceException(string message, int statusCode, string response, IReadOnlyDictionary<string, IEnumerable<string>> headers, System.Exception innerException)
                : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + response.Substring(0, response.Length >= 512 ? 512 : response.Length), innerException)
            {
                StatusCode = statusCode;
                Response = response;
                Headers = headers;
                try
                {
                    PrimePenguinResponse = JsonConvert.DeserializeObject<PrimePenguinResponse<dynamic>>(response);
                }
                catch (Exception e)
                {

                }
            }

            public override string ToString()
            {
                return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
            }
        }

        public partial class PrimePenguinServiceException<TResult> : PrimePenguinServiceException
        {
            public TResult Result { get; private set; }

            public PrimePenguinServiceException(string message, int statusCode, string response, Dictionary<string, IEnumerable<string>> headers, TResult result, System.Exception innerException)
                : base(message, statusCode, response, headers, innerException)
            {
                Result = result;
            }
        }
    }
}
