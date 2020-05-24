using Newtonsoft.Json;

namespace AdobeSign.Models
{
    class TransientDocumentResponse : BaseResponse
    {
        [JsonProperty("transientDocumentId")]
        public string TransientDocumentID { get; set; }
    }
}
