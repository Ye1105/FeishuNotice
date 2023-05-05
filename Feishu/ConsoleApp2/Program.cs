// See https://aka.ms/new-console-template for more information
using FeishuNotice;
using FeishuNotice.Signature;

string webhook = "https://open.feishu.cn/open-apis/bot/v2/hook/c11105a8-4de5-4f2b-b948-1fe36e66d374";

//自定义机器人秘钥
var key = "hLk2ofRG8yfpJjO9x2zaGh";
//获取当前时间戳
var timestamp = Signature.GetTimeStamp();
//自定义机器人签名校验
var sign = Signature.SignatureCheck(timestamp.ToString(), key);
//自定义机器人全局签名配置
RobotSignature.Configure(sign, timestamp.ToString(), status: true);

var result = await Feishu.RobotNotice(webhook, "hello");

Console.ReadLine();