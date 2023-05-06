// Nuget 发布
// 发布包 dotnet nuget push pkg --api-key key --source https://api.nuget.org/v3/index.json
// 发布完成去邮箱认证

//自定义机器人的 webhook
using FeishuNotice;
using FeishuNotice.Common;
using FeishuNotice.model;
using FeishuNotice.Signature;
using System.Web;

string webhook = "https://open.feishu.cn/open-apis/bot/v2/hook/c11105a8-4de5-4f2b-b948-1fe36e66d374";

//文本推送官方文档地址
//https://open.feishu.cn/document/uAjLw4CM/ukTMukTMukTM/im-v1/message/create_json#c9e08671

#region 签名校验


//自定义机器人秘钥
var key = "hLk2ofRG8yfpJjO9x2zaGh";
//获取当前时间戳
var timestamp = Signature.GetTimeStamp();
//自定义机器人签名校验
var sign = Signature.SignatureCheck(timestamp.ToString(), key);
//自定义机器人全局签名配置
RobotSignature.Configure(sign, timestamp.ToString(), status: true);


#endregion


#region 文本推送

#region 简单文本

//var result = await Feishu.RobotNotice(webhook, "hello");

#endregion 简单文本

#region 换行符

//var result = await Feishu.RobotNotice(webhook, "firstline \n second line");

#endregion 换行符

#region @ 用户

//var dic = new Dictionary<string, string>
//{
//    { "all", "所有人" },
//    { "ou_xxx", "名字" }
//};
//var result = await Feishu.RobotNotice(webhook, "hello", dic);

#endregion @ 用户

//样式标签 【暂不支持 Webhook 机器人】
//var result = await Feishu.RobotNotice(webhook, "<b>加粗</b> \n <i>斜体</i> \n <u>下划线</u>  \n <s>删除线</s>");

#endregion 文本推送

#region 富文本推送

//var data = new List<List<IPostContent>>
//{
//    new List<IPostContent>() {
//        new PostTextContent() //简单文本
//        {
//            Text = "hello \n"
//        },
//        new PostAContent() //超链接内容
//        {
//            Text = "百度链接  \n",
//            Href = "https://www.baidu.com"
//        },
//        new PostAtContent() //[自定义机器人 可以推送 openid格式 ， 暂不支持 email,user_id https://open.feishu.cn/document/ukTMukTMukTM/ucTM5YjL3ETO24yNxkjN#f62e72d5]
//        {
//            UserId = "all", //取值使用"all"来at所有人
//            UserName="所有人"
//        }
//    }
//};

//var result = await Feishu.RobotNotice(webhook, "标题", data);

#endregion 富文本推送

#region 图片推送

//var result = await Feishu.RobotImgNotice(webhook, "img_ecffc3b9-8f14-400f-a014-05eca1a4310g");

#endregion 图片推送

#region 信息卡片推送 标题、多行文本、多个按钮跳转事件

//var actions = new Dictionary<string, string>()
//{
//    { "baidu","wwww.baidu.com"},
//    { "bing","https://cn.bing.com/"}
//};

//var result = await Feishu.RobotNotice(webhook, "card title", "card content", actions);

#endregion 信息卡片推送 标题、多行文本、多个按钮跳转事件
//Console.WriteLine("result: 【Code:{0}】 【Data:{1}】 【Msg:{2}】", result?.Code, result?.Data, result?.Msg);
Console.ReadLine();