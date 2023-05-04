<!--
 * @Author: 15868707168@163.com 15868707168@163.com
 * @Date: 2023-05-04 09:22:22
 * @LastEditors: 15868707168@163.com 15868707168@163.com
 * @LastEditTime: 2023-05-04 16:28:00
 * @FilePath: \undefinedd:\FeishuNotice\README.md
 * @Description: 这是默认设置,请设置`customMade`, 打开koroFileHeader查看配置 进行设置: https://github.com/OBKoro1/koro1FileHeader/wiki/%E9%85%8D%E7%BD%AE
-->
## FeishuNotice

### 自定义机器人

#### 安装Nuget
+ **FeishuNotice**

#### 安全设置
+ **IP白名单**
  + 在自定义机器人的设置里面配置，多个IP用Enter键分隔


#### WebHook
+ 添加自定义机器人之后自动生成的 webhook 地址

#### 文本推送
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
#### 富文本推送
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

#### 图片推送
+ **上传图片之后，填入对应的 image_key**
    ``` C#
    await Feishu.RobotNotice(webhook, "img_ecffc3b9-8f14-400f-a014-05eca1a4310g");
    ```

#### 信息卡片推送
+  **信息卡片推送，包含标题、多行文本，也可以包含多个按钮跳转事件**
    ``` C#
    var actions = new Dictionary<string, string>()
    {
        { "baidu","wwww.baidu.com"},
        { "bing","https://cn.bing.com/"}
    };

    var result = await Feishu.RobotNotice(webhook, "card title", "card content", actions);
    ```

#### 返回信息

+  **打印返回信息**：[通用错误码参照](https://open.feishu.cn/document/ukTMukTMukTM/ugjM14COyUjL4ITN)
    ``` C#
    Console.WriteLine("result: 【Code:{0}】 【Data:{1}】 【Msg:{2}】", result?.Code, result?.Data, result?.Msg);
    ```