// See https://aka.ms/new-console-template for more information
using FeishuNotice;
using FeishuNotice.model;

Console.WriteLine("Hello, World!");

string url = "https://open.feishu.cn/open-apis/bot/v2/hook/c11105a8-4de5-4f2b-b948-1fe36e66d374";

var result = await FeishuMsgHelper.Notice(url, EMsgType.TEXT, "\n> ##### 所有点 :  人 ;  元 一级标题# 空格  ");