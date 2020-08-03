using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace B2_ResponseFormat
{
    public class ApiResult : ActionResult // dùng để trả về kết quả cho api
    {
        private HttpStatusCode _httpStatusCode;
        private object _result;
        public ApiResult(object result , HttpStatusCode code)
        {
            _httpStatusCode = code;
            _result = result;
        }
        public ApiResult(HttpStatusCode code)
        {
            _httpStatusCode = code;
        }
        public override async Task ExecuteResultAsync(ActionContext context)//cài đặt lại mã , ghi đè
        {
            var httpcontext = context.HttpContext;
            var request = httpcontext.Request;
            var reponse = httpcontext.Response;

            reponse.ContentType = "application/json charset=utf-8"; //kết quả trả về sẽ là unicode
            reponse.StatusCode = (int)_httpStatusCode;

            var writerFactory = httpcontext.RequestServices.GetRequiredService<IHttpResponseStreamWriterFactory>();
            var options = httpcontext.RequestServices.GetRequiredService<IOptions<MvcNewtonsoftJsonOptions>>().Value;
            var serializerSettings = options.SerializerSettings;

            await using (var writer = writerFactory.CreateWriter(reponse.Body, Encoding.UTF8))
            {
                using (var jsonWriter = new JsonTextWriter(writer))
                {
                    jsonWriter.CloseOutput = false;
                    var jsonSerializer = JsonSerializer.Create(serializerSettings);
                    jsonSerializer.Serialize(jsonWriter, _result);
                }
            }

        }
    }
}
