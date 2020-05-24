using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdobeSign.Models
{
    class WebhookInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("scope")]
        public string Scope { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("webhookSubscriptionEvents")]
        public IEnumerable<string> WebhookSubscriptionEvents { get; set; }
        [JsonProperty("webhookUrlInfo")]
        public WebhookUrlInfo WebhookUrlInfo { get; set; }
        [JsonProperty("applicationDisplayName")]
        public string ApplicationDisplayName { get; set; }
        [JsonProperty("applicationName")]
        public string ApplicationName { get; set; }
        [JsonProperty("webhookConditionalParams")]
        public WebhookConditionalParams WebhookConditionalParams { get; set; }
    }
}
