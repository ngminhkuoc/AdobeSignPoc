using Newtonsoft.Json;

namespace AdobeSign.Models
{
    class AgreementCreationResponse: BaseResponse
    {
        [JsonProperty("id")]
        public string ID { get; set; }
    }
}
