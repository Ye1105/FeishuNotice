using FeishuNotice.Common;
using Newtonsoft.Json;

namespace FeishuNotice
{
    /// <summary>
    /// 参照：https://www.cnblogs.com/mq0036/p/10436839.html
    /// </summary>
    public class HttpClientHelper
    {

        #region Post
        /// <summary>
        /// Post 异步请求
        /// </summary>
        /// <param name="webHookUrl"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<T?> SendAsync<T>(string webHookUrl, string data) where T : class, new()
        {
            try
            {

                string result = string.Empty;
                //设置Http的正文
                HttpContent httpContent = new StringContent(data);
                //设置Http的内容标头
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
                {
                    //设置Http的内容标头的字符
                    CharSet = "utf-8"
                };
                using HttpClient httpClient = new();
                //异步Post
                HttpResponseMessage response = await httpClient.PostAsync(webHookUrl, httpContent);

                //确保Http响应成功
                if (response.IsSuccessStatusCode)
                {
                    //异步读取json
                    result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(result);
                }
                else
                {
                    LogFile.Log("Exception", "SendAsync", LogFile.LogFileType.Day, "Http响应失败");
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogFile.Log("Exception", "SendAsync", LogFile.LogFileType.Day, ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Post 同步请求
        /// </summary>
        /// <param name="webHookUrl"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T? Send<T>(string webHookUrl, string data) where T : class, new()
        {
            try
            {

                string result = string.Empty;
                //设置Http的正文
                HttpContent httpContent = new StringContent(data);
                //设置Http的内容标头
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
                {
                    //设置Http的内容标头的字符
                    CharSet = "utf-8"
                };
                using HttpClient httpClient = new();
                //异步Post
                HttpResponseMessage response = httpClient.PostAsync(webHookUrl, httpContent).Result;

                //确保Http响应成功
                if (response.IsSuccessStatusCode)
                {
                    //异步读取json
                    result = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<T>(result);
                }
                else
                {
                    LogFile.Log("Exception", "Send", LogFile.LogFileType.Day, "Http响应失败");
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogFile.Log("Exception", "Send", LogFile.LogFileType.Day, ex.ToString());
                return null;
            }
        }

        #endregion
    }
}
