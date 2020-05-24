using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdobeSign.Models
{
    class ParticipantSetInfo
    {
        [JsonProperty("memberInfos")]
        public IEnumerable<ParticipantInfo> MemberInfos { get; set; }
        [JsonProperty("order")]
        public int Order { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
    }
}