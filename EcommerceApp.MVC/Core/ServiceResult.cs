using System;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EcommerceApp.MVC.Core
{
    public class ServiceResult<T>
    {
        public T Response { get; set; }
        public int Status { get; set; }
        public Dictionary<string, string> Errors { get; set; }
        public string Description { get; set; }


        public static ServiceResult<T> ERROR(string key, string value, int status = 400)
        {
            return new ServiceResult<T>
            {
                Response = default,
                Status = status,
                Description = "Error occured.Please take a look to status code",
                Errors = new Dictionary<string, string>()
                {
                    { key, value }
                }
            };
        }


        public static ServiceResult<T> OK(T response)
        {
            return new ServiceResult<T>
            {
                Response = response,
                Status = 200,
                Description = "Success",
                Errors = null
            };
        }
    }
}

