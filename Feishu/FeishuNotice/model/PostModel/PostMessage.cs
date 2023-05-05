using FeishuNotice.Signature;
using model;
using Newtonsoft.Json;

namespace FeishuNotice.model
{
    /// <summary>
    /// 富文本
    /// </summary>
    public class PostMessage : IFeishuMessage
    {
        public PostMessage()
        {
            MsgType = EnumDescriptionAttribute.GetEnumDescription(EMsgType.POST);
            Sign = RobotSignature.Status() ? RobotSignature.Sign() : null;
            TimeStamp = RobotSignature.Status() ? RobotSignature.TimeStamp() : null;
        }

        [JsonProperty("content")]
        public PostContent? PostContent { get; set; }
    }

    public class PostContent
    {
        //[JsonIgnore]
        [JsonProperty("post")]
        public Post? Post { get; set; }
    }

    public class Post
    {
        [JsonProperty("zh_cn")]
        public ZHCN? ZHCN { get; set; }
    }

    public class ZHCN
    {
        /// <summary>
        /// 标题
        /// </summary>
        [JsonProperty("title")]
        public string? Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [JsonProperty("content")]
        public List<List<IPostContent>>? PostContents { get; set; }
    }
}