// See https://aka.ms/new-console-template for more information
using FeishuNotice;
using FeishuNotice.model;

string webhook = "https://open.feishu.cn/open-apis/bot/v2/hook/c11105a8-4de5-4f2b-b948-1fe36e66d374";

var result = await Feishu.RobotNotice(webhook, "hello");

Console.ReadLine();