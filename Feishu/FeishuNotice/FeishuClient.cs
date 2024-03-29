﻿using FeishuNotice.model;
using Newtonsoft.Json;

namespace FeishuNotice
{
    //TEST:​https://open.feishu.cn/open-apis/bot/v2/hook/8de757ec-1cd4-48bc-98c2-bf9298b7ad31
    public class FeishuClient
    {
        /// <summary>
        /// 异步请求
        /// </summary>
        /// <param name="webHookUrl"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task<ReponseResult?> SendMessageAsync(string webHookUrl, IFeishuMessage message)
        {
            if (message == null || string.IsNullOrEmpty(webHookUrl))
            {
                return new ReponseResult
                {
                    Data = "参数不正确",
                    Msg = "参数不正确",
                    Code = 9499
                };
            }
            //小驼峰规则
            var setting = new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };
            string data = JsonConvert.SerializeObject(message, setting);
            return await HttpClientHelper.PostAsync<ReponseResult>(webHookUrl, data);
        }

        /// <summary>
        ///同步请求
        /// </summary>
        /// <param name="webHookUrl"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ReponseResult? SendMessageSync(string webHookUrl, IFeishuMessage message)
        {
            if (message == null || string.IsNullOrEmpty(webHookUrl))
            {
                return new ReponseResult
                {
                    Data = "参数不正确",
                    Msg = "参数不正确",
                    Code = 9499
                };
            }
            //小驼峰规则
            var setting = new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };
            string data = JsonConvert.SerializeObject(message, setting);
            return HttpClientHelper.Post<ReponseResult>(webHookUrl, data);
        }
    }
}