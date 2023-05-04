using FeishuNotice.model;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace FeishuNotice
{
    //TEST:​https://open.feishu.cn/open-apis/bot/v2/hook/8de757ec-1cd4-48bc-98c2-bf9298b7ad31
    public class FeishuClient
    {
        public static async Task<ReponseResult?> SendMessageAsync(string webHookUrl, IFeishuMessage message)
        {
            if (message == null || string.IsNullOrEmpty(webHookUrl))
            {
                return new ReponseResult
                {
                    Msg = "参数不正确",
                    Code = -1
                };
            }

            string data = JsonConvert.SerializeObject(message);
            return await SendAsync(webHookUrl, data);
        }

        private static async Task<ReponseResult?> SendAsync(string webHookUrl, string data)
        {
            try
            {
                string result = string.Empty;
                WebRequest WReq = WebRequest.Create(webHookUrl);
                WReq.Method = "POST";
                byte[] byteArray = Encoding.UTF8.GetBytes(data);
                WReq.ContentType = "application/json; charset=utf-8";
                using (Stream newStream = await WReq.GetRequestStreamAsync())
                {
                    await newStream.WriteAsync(byteArray, 0, byteArray.Length);
                }

                using (Stream stream = (await WReq.GetResponseAsync()).GetResponseStream())
                {
                    if (stream != null)
                    {
                        using StreamReader reader = new(stream);
                        result = await reader.ReadToEndAsync();
                    }
                }

                if (!string.IsNullOrEmpty(result))
                {
                    return JsonConvert.DeserializeObject<ReponseResult>(result);
                }

                return new ReponseResult
                {
                    Msg = "",
                    Code = -1
                };
            }
            catch (Exception ex)
            {
                return new ReponseResult
                {
                    Msg = ex.Message,
                    Code = -1
                };
            }
        }
    }
}