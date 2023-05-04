using model;

namespace FeishuNotice.model
{
    public enum EMsgType
    {
        /// <summary>
        /// 文本
        /// </summary>
        [EnumDescription("text")]
        TEXT,

        /// <summary>
        /// 富文本
        /// </summary>
        [EnumDescription("post")]
        POST,

        /// <summary>
        /// 图片
        /// </summary>
        [EnumDescription("image")]
        IMAGE,

        /// <summary>
        /// 分享群名片
        /// </summary>
        [EnumDescription("share_chat")]
        SHARE_CHAT,

        /// <summary>
        /// 消息卡片
        /// </summary>
        [EnumDescription("interactive")]
        INTERACTIVE,
    }
}