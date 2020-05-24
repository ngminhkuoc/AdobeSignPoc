using Newtonsoft.Json;

namespace AdobeSign.Models
{
    public class WebhookConditionalParams
    {
        [JsonProperty("webhookAgreementEvents")]
        public WebhookAgreementEvents WebhookAgreementEvents { get; set; }
    }
}