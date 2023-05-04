using Newtonsoft.Json;

namespace FeishuNotice.model
{
    /// <summary>
    /// 超链接
    /// </summary>
    public class PostAContent : IPostContent
    {
        public PostAContent()
        {
            Tag = "a";
        }

        /// <summary>
        /// 文本
        /// </summary>
        [JsonProperty("text")]
        public string? Text { get; set; }

        /// <summary>
        /// 跳转网址
        /// </summary>
        [JsonProperty("href")]
        public string? Href { get; set; }
    }
}