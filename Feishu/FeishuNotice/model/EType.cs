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
        /// 富文本,注只支持标题、不带格式的文本、图片、链接、at人样式。更复杂的带格式的内容建议使用消息卡片实现
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