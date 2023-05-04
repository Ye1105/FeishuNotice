using model;
using Newtonsoft.Json;

namespace FeishuNotice.model
{
    /// <summary>
    /// 文本
    /// </summary>
    public class TextMessage : IFeishuMessage
    {
        public TextMessage()
        {
            MsgType = EnumDescriptionAttribute.GetEnumDescription(EMsgType.TEXT);
        }

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