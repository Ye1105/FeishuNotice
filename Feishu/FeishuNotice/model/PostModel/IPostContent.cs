using Newtonsoft.Json;

namespace FeishuNotice.model
{
    public abstract class IPostContent
    {
        /// <summary>
        /// 标签
        /// </summary>
        [JsonProperty("tag")]
        protected string? Tag { get; set; }
    }
}