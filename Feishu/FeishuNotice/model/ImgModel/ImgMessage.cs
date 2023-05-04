using model;
using Newtonsoft.Json;

namespace FeishuNotice.model.ImgModel
{
    /// <summary>
    /// 图片
    /// </summary>
    public class ImgMessage : IFeishuMessage
    {
        public ImgMessage()
        {
            MsgType = EnumDescriptionAttribute.GetEnumDescription(EMsgType.IMAGE);
        }

        /// <summary>
        /// 图片 
        /// </summary>
        [JsonProperty("content")]
        public ImgContent? ImgContent { get; set; }

    }

    public class ImgContent
    {
        /// <summary>
        /// image_key
        /// </summary>
        [JsonProperty("image_key")]
        public string? ImageKey { get; set; }
    }
}