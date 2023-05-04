// See https://aka.ms/new-console-template for more information
// 发布包 dotnet nuget push FeishuNotice.1.0.0.nupkg --api-key oy2nj66nhkefs644z4pq6rjoysxtcuhuvbbezk47eqq22i --source https://api.nuget.org/v3/index.json
//发布完成去邮箱认证

using FeishuNotice;
using FeishuNotice.model;

string url = "https://open.feishu.cn/open-apis/bot/v2/hook/c11105a8-4de5-4f2b-b948-1fe36e66d374";

//文本推送
//https://open.feishu.cn/document/uAjLw4CM/ukTMukTMukTM/im-v1/message/create_json#c9e08671
//var result = await FeishuMsgHelper.Notice(url, "firstline \n second line");

//富文本推送
var list = new List<IPostContent>();

//文本内容
var p1 = new PostTextContent()
{
    Text = "单行数据1 \n"
};

////超链接内容
//var p2 = new PostAContent()
//{
//    Text = "百度链接",
//    Href = "https://www.baidu.com"
//};

////超链接内容
//var p3 = new PostAtContent()
//{
//    UserId = "*"
//};

list.Add(p1);
//list.Add(p2);
//list.Add(p3);

var data = new List<List<IPostContent>>
{
    list
};

var result2 = await FeishuMsgHelper.Notice(url, "标题描述", data);

Console.ReadLine();