using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdobeSign.Models
{
    class AgreementInfo
    {
        [JsonProperty("fileInfos")]
        public IEnumerable<FileInfo> FileInfos { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("participantSetsInfo")]
        public IEnumerable<ParticipantSetInfo> ParticipantSetsInfo { get; set; }
        [JsonProperty("signatureType")]
        public string SignatureType { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
