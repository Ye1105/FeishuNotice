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
    }
}