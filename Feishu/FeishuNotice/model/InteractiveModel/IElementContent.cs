using Newtonsoft.Json;

namespace FeishuNotice.model.InteractiveModel
{
    public class IElementContent
    {
        /// <summary>
        /// 标签
        /// </summary>
        [JsonProperty("tag")]
        protected string? Tag { get; set; }
    }
}