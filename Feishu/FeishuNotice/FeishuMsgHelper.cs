using FeishuNotice.Common;
using FeishuNotice.model;
using Microsoft.VisualBasic;
using model;

/**
 * 官方文档：https://open.feishu.cn/document/ukTMukTMukTM/ucTM5YjL3ETO24yNxkjN
 * 官方文档（富文本）： https://open.feishu.cn/document/ukTMukTMukTM/ucTM5YjL3ETO24yNxkjN#f62e72d5
 */

namespace FeishuNotice
{
    public class FeishuMsgHelper
    {
        /// <summary>
        /// 推送 文本格式 的信息
        /// </summary>
        /// <param name="webhook">自定义机器人的 webhook 地址</param>
        /// <param name="text">发送的内容</param>
        /// <returns></returns>
        public static async Task<ReponseResult?> Notice(string webhook, string text)
        {
            try
            {
                var msg = new TextMessage()
                {
                    MsgType = EnumDescriptionAttribute.GetEnumDescription(EMsgType.TEXT),
                    TextContent = new()
                    {
                        Text = text
                    }
                };
                return await FeishuClient.SendMessageAsync(webhook, msg);
            }
            catch (Exception ex)
            {
                LogFile.Log("Exception", "FeishuText", LogFile.LogFileType.Day, ex.ToString());
                return null;
            }
        }

        /// <summary>
        ///  推送 富文本格式 的信息
        /// </summary>
        /// <param name="webhook">自定义机器人的 webhook 地址</param>
        /// <param name="title">标题</param>
        /// <param name="contents">内容</param>
        /// <returns></returns>
        public static async Task<ReponseResult?> Notice(string webhook, string title, List<List<IPostContent>> contents)
        {
            try
            {
                var msg = new PostMessage()
                {
                    MsgType = EnumDescriptionAttribute.GetEnumDescription(EMsgType.POST),
                    PostContent = new()
                    {
                        Post = new()
                        {
                            ZHCN = new()
                            {
                                PostContents = contents,
                                Title = title
                            }
                        }
                    }
                };
                return await FeishuClient.SendMessageAsync(webhook, msg);
            }
            catch (Exception ex)
            {
                LogFile.Log("Exception", "FeishuText", LogFile.LogFileType.Day, ex.ToString());
                return null;
            }
        }
    }
}