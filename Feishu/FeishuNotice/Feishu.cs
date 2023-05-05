using FeishuNotice.Common;
using FeishuNotice.model;
using FeishuNotice.model.ImgModel;
using FeishuNotice.Signature;

/**
 * 官方文档：https://open.feishu.cn/document/ukTMukTMukTM/ucTM5YjL3ETO24yNxkjN
 * 官方文档（富文本）： https://open.feishu.cn/document/ukTMukTMukTM/ucTM5YjL3ETO24yNxkjN#f62e72d5
 */

namespace FeishuNotice
{
    public class Feishu
    {
        /// <summary>
        /// 推送 文本格式 的信息
        /// </summary>
        /// <param name="webhook">自定义机器人的 webhook 地址</param>
        /// <param name="text">发送的内容</param>
        /// <param name="at"> Map: all 或者 用户的Open ID
        ///     网址请参考
        ///     <see cref="https://open.feishu.cn/document/uAjLw4CM/ugTN1YjL4UTN24CO1UjN/trouble-shooting/how-to-obtain-openid"/>
        /// </param>
        /// <returns>ReponseResult</returns>
        public static async Task<ReponseResult?> RobotNotice(string webhook, string text, Dictionary<string, string>? at = null)
        {
            try
            {
                if (at != null && at?.Count > 0)
                {
                    var atUser = "";
                    foreach (var item in at)
                    {
                        if (item.Key == "all" || item.Key.StartsWith("ou_"))
                        {
                            atUser += $"<at user_id=\"{item.Key}\">{item.Value}</at>";
                        }
                        else
                        {
                            return new ReponseResult
                            {
                                Data = "Open ID 格式不正确",
                                Msg = "Open ID 格式不正确",
                                Code = 9499
                            };
                        }
                    }

                    text = $"{text}{atUser}";
                }


                var msg = new TextMessage()
                {
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
        ///  推送 图片格式 的信息
        /// </summary>
        /// <param name="webhook">自定义机器人的 webhook 地址</param>
        /// <param name="imageKey">imageKey</param>
        /// <returns></returns>
        public static async Task<ReponseResult?> RobotImgNotice(string webhook, string imageKey)
        {
            try
            {
                var msg = new ImgMessage()
                {
                    ImgContent = new()
                    {
                        ImageKey = imageKey
                    }
                };
                return await FeishuClient.SendMessageAsync(webhook, msg);
            }
            catch (Exception ex)
            {
                LogFile.Log("Exception", "FeishuImage", LogFile.LogFileType.Day, ex.ToString());
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
        public static async Task<ReponseResult?> RobotNotice(string webhook, string title, List<List<IPostContent>> contents)
        {
            try
            {
                var msg = new PostMessage()
                {
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
                LogFile.Log("Exception", "FeishuPost", LogFile.LogFileType.Day, ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 推送 消息卡片
        /// </summary>
        /// <param name="webhook">自定义机器人的 webhook 地址</param>
        /// <param name="title">标题</param>
        /// <param name="divContent">文本</param>
        /// / <param name="actions">按钮事件 key:按钮名称  value:url</param>
        /// <returns></returns>
        public static async Task<ReponseResult?> RobotNotice(string webhook, string title, string divContent, Dictionary<string, string>? actions = null)
        {
            try
            {
                List<object>? acts = null;
                if (actions != null && actions.Count > 0)
                {
                    acts = new List<object>();
                    foreach (var item in actions)
                    {
                        acts?.Add(new
                        {
                            Tag = "button",
                            Text = new
                            {
                                Content = item.Key,
                                Tag = "lark_md"
                            },
                            Url = item.Value,
                            Type = "default",
                            Value = new { }
                        });
                    }
                }

                var msg = new InteractiveMessage()
                {
                    Card = new
                    {
                        Header = new
                        {
                            Title = new
                            {
                                Content = title,
                                Tag = "plain_text"
                            }
                        },
                        Elements = new object[]
                        {
                            //文本展示
                            new
                            {
                                Tag="div",
                                Text = new
                                {
                                    Content=divContent,
                                    Tag="lark_md"
                                }
                            },
                            //按钮事件
                            new
                            {
                                Tag="action",
                                Actions=acts
                            }
                        }
                    }
                };

                return await FeishuClient.SendMessageAsync(webhook, msg);
            }
            catch (Exception ex)
            {
                LogFile.Log("Exception", "FeishuInteractiveMessage", LogFile.LogFileType.Day, ex.ToString());
                return null;
            }
        }
    }
}