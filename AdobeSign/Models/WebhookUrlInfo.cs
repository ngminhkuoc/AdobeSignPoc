using Newtonsoft.Json;

namespace AdobeSign.Models
{
    class WebhookUrlInfo
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
