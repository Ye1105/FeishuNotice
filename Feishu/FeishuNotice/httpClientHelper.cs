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
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<T?> PostAsync<T>(string url, string data) where T : class, new()
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
                HttpResponseMessage response = await httpClient.PostAsync(url, httpContent);

                //确保Http响应成功
                if (response.IsSuccessStatusCode)
                {
                    //异步读取json
                    result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(result);
                }
                else
                {
                    LogFile.Log("Exception", "PostAsync", LogFile.LogFileType.Day, "Http响应失败");
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogFile.Log("Exception", "PostAsync", LogFile.LogFileType.Day, ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Post 同步请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T? Post<T>(string url, string data) where T : class, new()
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
                HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

                //确保Http响应成功
                if (response.IsSuccessStatusCode)
                {
                    //异步读取json
                    result = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<T>(result);
                }
                else
                {
                    LogFile.Log("Exception", "Post", LogFile.LogFileType.Day, "Http响应失败");
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogFile.Log("Exception", "Post", LogFile.LogFileType.Day, ex.ToString());
                return null;
            }
        }

        public static string Post(string url, string postData, out string statusCode)
        {
            string result = string.Empty;
            //设置Http的正文
            HttpContent httpContent = new StringContent(postData);
            //设置Http的内容标头
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
            {
                //设置Http的内容标头的字符
                CharSet = "utf-8"
            };
            using (HttpClient httpClient = new())
            {
                //异步Post
                HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;
                //输出Http响应状态码
                statusCode = response.StatusCode.ToString();
                //确保Http响应成功
                if (response.IsSuccessStatusCode)
                {
                    //异步读取json
                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            return result;
        }

        #endregion

        #region Get

        /// <summary>
        /// Get Async 待测试完善才能使用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<T?> GetAsync<T>(string url) where T : class, new()
        {
            using HttpClient? httpClient = new();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage? response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var t = await response.Content.ReadAsStringAsync();
                return t is not null ? JsonConvert.DeserializeObject<T>(t) : null;
            }
            return null;
        }

        public static T? Get<T>(string url) where T : class, new()
        {
            using HttpClient? httpClient = new();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage? response = httpClient.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var t = response.Content.ReadAsStringAsync().Result;
                return t is not null ? JsonConvert.DeserializeObject<T>(t) : null;
            }
            return null;
        }

        public static string Get(string url, out string statusCode)
        {
            string result = string.Empty;

            using (HttpClient httpClient = new())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                statusCode = response.StatusCode.ToString();

                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            return result;
        }

        #endregion

        #region Put

        public static async Task<T?> PutAsync<T>(string url, string putData) where T : class, new()
        {

            HttpContent httpContent = new StringContent(putData);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
            {
                CharSet = "utf-8"
            };
            using HttpClient httpClient = new();
            HttpResponseMessage response = await httpClient.PutAsync(url, httpContent);

            if (response.IsSuccessStatusCode)
            {
                var t = await response.Content.ReadAsStringAsync();
                return t is not null ? JsonConvert.DeserializeObject<T>(t) : null;
            }

            return null;
        }


        public static T? Put<T>(string url, string putData) where T : class, new()
        {

            HttpContent httpContent = new StringContent(putData);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
            {
                CharSet = "utf-8"
            };
            using HttpClient httpClient = new();
            HttpResponseMessage response = httpClient.PutAsync(url, httpContent).Result;

            if (response.IsSuccessStatusCode)
            {
                var t = response.Content.ReadAsStringAsync().Result;
                return t is not null ? JsonConvert.DeserializeObject<T>(t) : null;
            }

            return null;
        }


        public static string Put(string url, string data, out string statusCode)
        {
            string result = string.Empty;
            HttpContent httpContent = new StringContent(data);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
            {
                CharSet = "utf-8"
            };
            using (HttpClient httpClient = new())
            {
                HttpResponseMessage response = httpClient.PutAsync(url, httpContent).Result;
                statusCode = response.StatusCode.ToString();
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            return result;
        }




        #endregion

    }
}
