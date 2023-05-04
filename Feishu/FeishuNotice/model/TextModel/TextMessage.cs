using Newtonsoft.Json;

namespace FeishuNotice.model
{
    /// <summary>
    /// 文本
    /// </summary>
    public class TextMessage : IFeishuMessage
    {
        [JsonProperty("content")]
        public TextContent? TextContent { get; set; }
    }

    public class TextContent
    {
        //[JsonIgnore]
        [JsonProperty("text")]
        public string? Text { get; set; }
    }
}