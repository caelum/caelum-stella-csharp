using System.Net;
using System.Net.Http;

namespace CaelumStellaCSharp.http
{
    public class HttpResponse : IHttpResponse
    {
        private readonly HttpResponseMessage httpResponseMessage;
        internal HttpResponse(HttpResponseMessage httpResponseMessage)
        {
            this.httpResponseMessage = httpResponseMessage;
        }

        public bool Success => httpResponseMessage.IsSuccessStatusCode;
        public HttpStatusCode StatusCode => this.httpResponseMessage.StatusCode;
        public HttpContent Content => httpResponseMessage.Content;
    }
}
