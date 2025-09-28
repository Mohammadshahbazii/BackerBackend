using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Utilities
{
    public enum ResponseState
    {
        Success,
        Error,
        Failed
    }

    public static class MessageProvider
    {
        public static string GetMessage(ResponseState status)
        {
            switch (status)
            {
                case ResponseState.Success:
                    return "عملیات با موفقیت انجام شد";
                case ResponseState.Error:
                    return "ثبت درخواست شما ناموفق بود . لطفا مجددا تلاش فرمائید";
                case ResponseState.Failed:
                    return "هنگام عملیات خطایی رخ داد لطفا مجددا تلاش کنید";
                default:
                    return "عملیات با موفقیت انجام شد";
            }
        }
    }

    public static class ResponseProvider
    {
        public static Respone GetRespone(ResponseState status, object data = null)
        {
            return new Respone() { State = status, Message = MessageProvider.GetMessage(status), Data = data };
        }
    }


    public class Respone
    {
        public ResponseState State { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }

    }
}
