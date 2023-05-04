using Newtonsoft.Json;

namespace FeishuNotice.model
{
    public class ReponseResult
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("msg")]
        public string? Msg { get; set; }

        [JsonProperty("data")]
        public object? Data { get; set; }

        [JsonProperty(nameof(Extra))]
        public string? Extra { get; set; }

        [JsonProperty(nameof(StatusCode))]
        public string? StatusCode { get; set; }

        [JsonProperty(nameof(StatusMessage))]
        public string? StatusMessage { get; set; }
    }
}