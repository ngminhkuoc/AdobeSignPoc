using Newtonsoft.Json;

namespace AdobeSign.Models
{
    class BaseResponse
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}