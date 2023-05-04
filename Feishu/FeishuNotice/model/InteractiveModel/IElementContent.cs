using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeishuNotice.model.InteractiveModel
{
    public class IElementContent
    {
        /// <summary>
        /// 标签
        /// </summary>
        [JsonProperty("tag")]
        protected string? Tag { get; set; }
    }
}
