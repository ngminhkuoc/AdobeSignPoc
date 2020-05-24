using Newtonsoft.Json;

namespace AdobeSign.Models
{
    class WebhookCreationResponse : BaseResponse
    {
        [JsonProperty("id")]
        public string ID { get; set; }
    }
}
