

<h1 align="center" >👾 FeishuNotice </h1>  



<div align="center"> 
<p>  FeishuNotice 是一个将自定义消息推送到飞书自定义机器人的 Nuget 包 😼</p>
</div>



### :package:安装Nuget

+ **FeishuNotice**
+ **Nuget 包请使用 2.0.7 及以上版本，建议使用最新版本**

### 🧷安全设置

> 可以选择一种或者多种安全设置

  + **关键词校验**
     
     + 最多设置 10 个关键词。设定后，只有包含至少一个关键词的消息才会被发送。
     
  + **IP校验**
    
    + 最多 10 个IP，多个IP用Enter键分隔。
    
  + **签名校验**
    
    + 全局签名配置，只需要在项目入口中配置一次
    ```C#
     //自定义机器人秘钥
    var key = "**************";
    
    //获取当前时间戳
    var timestamp = Signature.GetTimeStamp();
    
    //自定义机器人签名校验
   var sign = Signature.SignatureCheck(timestamp.ToString(), key);
       
    /// <summary>
    /// 全局配置自定义机器人安全设置签名校验
    /// </summary>
    /// <param name="sign">签名</param>
    /// <param name="timestamp">时间戳</param>
    /// <param name="status">true 开启签名认证，false 关闭签名认证，配置完成后默认开启</param>
    /// <returns></returns>
    RobotSignature.Configure(sign, timestamp.ToString(), status: true);
    ```

### :beers:WebHook

+ 添加自定义机器人之后自动生成的 webhook 地址

### :zap:文本推送

+ **简单文本**
    
    ``` C#
    await Feishu.RobotNotice(webhook, "hello");
    ```
+ **换行符** 
    
    ``` C#
    await Feishu.RobotNotice(webhook, "firstline \n second line")
    ```
+ **@ 用户** 
    
    ``` C#
    var dic = new Dictionary<string, string>
    {
        { "all", "所有人" },
        { "ou_xxx", "名字" }
    };
    var result = await Feishu.RobotNotice(webhook, "hello", dic);
    ```
### :fire:富文本推送

+ 可以选择包含**简单文本**、**超链接内容**、**@用户** 其中的一种或者多种进行拼接参数 
    ``` C#
    var data = new List<List<IPostContent>>
    {
        new List<IPostContent>() {
            new PostTextContent() //简单文本
            {
                Text = "hello \n"
            },
            new PostAContent() //超链接内容
            {
                Text = "百度链接  \n",
                Href = "https://www.baidu.com"
            },
            new PostAtContent() //[自定义机器人 可以推送 openid格式 ， 暂不支持 email,user_id https://open.feishu.cn/document/ukTMukTMukTM/ucTM5YjL3ETO24yNxkjN#f62e72d5]
            {
                UserId = "all", //取值使用"all"来at所有人
                UserName="所有人"
            }
    }
    await Feishu.RobotNotice(webhook, "标题", data);
    ```

### :camera_flash:图片推送

+ 上传图片之后，填入对应的 **image_key**
    ``` C#
    await Feishu.RobotImgNotice(webhook, "img_ecffc3b9-8f14-400f-a014-05eca1a4310g");
    ```

### :label:信息卡片推送

+  信息卡片推送，包含**标题、多行文本**，也可以包含多个**按钮跳转事件**
    ``` C#
    var actions = new Dictionary<string, string>()
    {
        { "baidu","wwww.baidu.com"},
        { "bing","https://cn.bing.com/"}
    };

    var result = await Feishu.RobotNotice(webhook, "card title", "card content", actions);
    ```

### :mag:返回信息

+  **打印返回信息**：[官网通用错误码参照](https://open.feishu.cn/document/ukTMukTMukTM/ugjM14COyUjL4ITN)
    
    ``` C#
    Console.WriteLine("result: 【Code:{0}】 【Data:{1}】 【Msg:{2}】", result?.Code, result?.Data, result?.Msg);
    ```

### :bug:错误日志

+  **日志文件位置：** 
    
    ```
    项目生成目录\Log\Exception\Feishu****.log
    ```

### 💕联系作者

> 有想法的小伙伴可以联系作者一起开发项目哦，很期待有大佬带带我！😼😼😼

+ [Wechat](./README_CONTACT.md)

