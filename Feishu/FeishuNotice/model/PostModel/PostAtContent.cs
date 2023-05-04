using Newtonsoft.Json;

namespace FeishuNotice.model
{
    /// <summary>
    /// @
    /// </summary>
    public class PostAtContent : IPostContent
    {
        public PostAtContent()
        {
            Tag = "at";
        }

        /// <summary>
        /// @的用户id，全部则为
        /// </summary>
        [JsonProperty("user_id")]
        public string? UserId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty("user_name")]
        public string? UserName { get; set; }

        ///// <summary>
        ///// 用于配置文本内容加粗、下划线、删除线和斜体样式，可选值分别为bold、underline、lineThrough与italic，非可选值将被忽略
        ///// </summary>
        //[JsonProperty("style")]
        //public List<string> Style { get; set; } = new List<string> { "bold", "underline" };
    }
}