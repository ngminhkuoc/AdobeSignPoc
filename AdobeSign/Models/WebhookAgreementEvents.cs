using Newtonsoft.Json;

namespace AdobeSign.Models
{
    public class WebhookAgreementEvents
    {
        [JsonProperty("includeDetailedInfo")]
        public bool IncludeDetailedInfo { get; set; }
        [JsonProperty("includeDocumentsInfo")]
        public bool IncludeDocumentsInfo { get; set; }
        [JsonProperty("includeParticipantsInfo")]
        public bool IncludeParticipantsInfo { get; set; }
        [JsonProperty("includeSignedDocuments")]
        public bool IncludeSignedDocuments { get; set; }
    }
}