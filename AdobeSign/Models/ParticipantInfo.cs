using Newtonsoft.Json;

namespace AdobeSign.Models
{
    class ParticipantInfo
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
