using FeishuNotice.Signature;
using model;
using Newtonsoft.Json;

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
            Sign = RobotSignature.Status() ? RobotSignature.Sign() : null;
            TimeStamp = RobotSignature.Status() ? RobotSignature.TimeStamp() : null;
        }

        /// <summary>
        /// 消息卡片
        /// </summary>
        [JsonProperty("card")]
        public object? Card { get; set; }
    }
}