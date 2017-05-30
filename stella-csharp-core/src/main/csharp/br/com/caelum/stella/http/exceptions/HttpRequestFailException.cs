using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CaelumStellaCSharp.http.exceptions
{
    public class HttpRequestFailException : Exception
    {
        private readonly HttpStatusCode httpStatusCode;
        public HttpRequestFailException(HttpStatusCode httpStatusCode)
        {
            //HttpStatusCode.ServiceUnavailable
            this.httpStatusCode = httpStatusCode;
        }

        public HttpStatusCode StatusCode => httpStatusCode;
    }
}
