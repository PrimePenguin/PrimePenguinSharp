using Newtonsoft.Json;

namespace PrimePenguinSharp
{
    public class PrimePenguinResponse<T>
    {
        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
        public T Result { get; set; }

        [JsonProperty("success", NullValueHandling = NullValueHandling.Ignore)]
        public bool Success { get; set; }

        [JsonProperty("unAuthorizedRequest", NullValueHandling = NullValueHandling.Ignore)]
        public bool UnAuthorizedRequest { get; set; }

        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public PrimePenguinError Error { get; set; }
    }

    public class PrimePenguinError
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public bool Code { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty("details", NullValueHandling = NullValueHandling.Ignore)]
        public string Details { get; set; }

        [JsonProperty("validationErrors", NullValueHandling = NullValueHandling.Ignore)]
        public PrimePenguinValidationErrors ValidationErrors { get; set; }
    }

    public class PrimePenguinValidationErrors
    {
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty("members", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Members { get; set; }
    }
}
