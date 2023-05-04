using FeishuNotice.model.InteractiveModel;
using model;
using Newtonsoft.Json;
using System.Reflection.PortableExecutable;

namespace FeishuNotice.model
{
    /// <summary>
    /// 富文本
    /// </summary>
    public class InteractiveMessage : IFeishuMessage
    {
        public InteractiveMessage()
        {
            MsgType = EnumDescriptionAttribute.GetEnumDescription(EMsgType.INTERACTIVE);
        }

        /// <summary>
        /// 消息卡片
        /// </summary>
        [JsonProperty("card")]
        public object? Card { get; set; }
    }
}