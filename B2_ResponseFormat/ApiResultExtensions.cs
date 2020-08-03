using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace B2_ResponseFormat
{
    public static class ApiResultExtensions
    {
        //public static IActionResult ErrorResult(this Controller controller, ErrorCode errorCode, HttpStatusCode statusCode)
        //{
        //    return JsonResult(new Response<object>(
        //        (int)errorCode,
        //        errorResources.ResourceManager.GetString(errorCode.ToString())),
        //       statusCode);
        //}

        //public static IActionResult ErrorResult(this Controller controller, errorCode errorCode)
        //{
        //    return JsonResult(new Response<object>(
        //        (int)errorCode,
        //        errorResources.ResourceManager.GetString(errorCode.ToString())),
        //        HttpStatusCode.BadRequest);
        //}

        public static IActionResult ErrorResult(this Controller controller, int errorCode, string errorMessage, HttpStatusCode statusCode)
        {
            return JsonResult(new Response<object>(errorCode, errorMessage), statusCode);
        }


        public static IActionResult ErrorResult(this Controller controller, int errorCode, string errorMessage)
        {
            return JsonResult(new Response<object>(errorCode, errorMessage), HttpStatusCode.BadRequest);
        }

        public static IActionResult OkResult<T>(this Controller controller, T result)
        {
            return JsonResult(new Response<T>(result));
        }

        public static IActionResult OkResult(this Controller controller)
        {
            return JsonResult(new Response<object>(true));
        }

        public static IActionResult OkResult(this Controller controller, object result)
        {
            return JsonResult(new Response<object>(result));
        }

        //hàm cơ bản trả về result bất kỳ
        private static IActionResult JsonResult(object result, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ApiResult(result, statusCode);//trả về result vừa tạo
        }
    }
}
