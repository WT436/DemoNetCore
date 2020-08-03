using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2_ResponseFormat
{
    public class Response<T> //genaric <T>
    {
        public bool successFul { get; set; } //báo cho client biết có lỗi hay không
        public T result { get; set; }//kết quả trả về nếu có
        public int? errorCode { get; set; } //mã lỗi 
        public string  errorMessage { get; set; }//thông tin lỗi

        public Response(T _result)// nếu có kết quả thì cài đặt trả về 
        {
            successFul = true;
            result = _result; //lấy parameter truyền lại dữ liệu

        }
        public Response(bool _successFul)
        {
            successFul = _successFul;
        }
        public Response(int _errorCode , string _errorMessage)
        {
            errorCode = _errorCode;
            errorMessage = _errorMessage;
        }
    }
}
