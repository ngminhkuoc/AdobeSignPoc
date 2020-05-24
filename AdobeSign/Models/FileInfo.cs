using Newtonsoft.Json;

namespace AdobeSign.Models
{
    class FileInfo
    {
        [JsonProperty("transientDocumentId")]
        public string TransientDocumentID { get; set; }
    }
}
