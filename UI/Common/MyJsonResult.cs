using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace UI.Common
{
    public class MyJsonResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("JsonRequest_GetNotAllowed");
            }
            HttpResponseBase response = context.HttpContext.Response;
            if (!string.IsNullOrEmpty(this.ContentType))
            {
                response.ContentType = this.ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }
            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }
            if (this.Data != null)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();

                //设置序列化时key为驼峰样式,开头字母小写输出  controller调用Josn(对象)
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                //原样输出
                //options.SerializerSettings.ContractResolver = new DefaultContractResolver();

                //时间格式
                settings.DateFormatString = "yyyy-MM-dd HH:mm:ss";

                response.Write(JsonConvert.SerializeObject(this.Data, settings));
            }
        }
    }
}