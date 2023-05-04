using Newtonsoft.Json;

namespace FeishuNotice.model
{
    /// <summary>
    /// 文本
    /// </summary>
    public class PostTextContent : IPostContent
    {
        public PostTextContent()
        {
            Tag = "text";
        }

        public PostTextContent(bool unEscape)
        {
            Tag = "text";
            UnEscape = unEscape;
        }

        //public PostTextContent(string[] style)
        //{
        //    Tag = "text";
        //    Style = style;
        //}

        //public PostTextContent(bool unEscape, string[] style)
        //{
        //    Tag = "text";
        //    UnEscape = unEscape;
        //    Style = style;
        //}

        /// <summary>
        /// 文本内容
        /// </summary>
        [JsonProperty("text")]
        public string? Text { get; set; }

        /// <summary>
        /// 表示是不是 unescape 解码，默认为 false ，不用可以不填
        /// </summary>
        [JsonProperty("un_escape")]
        public bool UnEscape { get; set; } = false;

        ///// <summary>
        ///// 用于配置文本内容加粗、下划线、删除线和斜体样式，可选值分别为bold、underline、lineThrough与italic，非可选值将被忽略
        ///// </summary>
        //[JsonProperty("style")]
        //public List<string> Style { get; set; } = new List<string> { "bold", "underline" };
    }
}