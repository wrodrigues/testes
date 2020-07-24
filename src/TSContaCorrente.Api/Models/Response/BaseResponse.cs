using System.Collections;
using System.Collections.Generic;

namespace TSContaCorrente.Api.Models.Response
{
    public class BaseResponse
    {
        public List<string> Errors { get; set; }
        public bool IsValid
        {
            protected set { }

            get
            {
                return Errors != null && Errors.Count == 0;
            }
        }

        public BaseResponse()
        {
            Errors = new List<string>();
        }
    }
}
