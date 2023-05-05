using Newtonsoft.Json;

namespace FeishuNotice.model
{
    public abstract class IFeishuMessage
    {
        /// <summary>
        /// 消息格式,具体描述参考官网  https://open.feishu.cn/document/ukTMukTMukTM/ucTM5YjL3ETO24yNxkjN
        /// <para>EMsgType 枚举中定义了多种消息格式类型。可进行查阅</para>
        /// </summary>
        [JsonProperty("msg_type")]
        public string? MsgType { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        [JsonProperty("timestamp")]
        public string? TimeStamp { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [JsonProperty("sign")]
        public string? Sign { get; set; }
    }
}