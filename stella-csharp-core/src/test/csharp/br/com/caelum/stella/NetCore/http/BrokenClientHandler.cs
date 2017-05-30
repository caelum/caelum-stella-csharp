using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CaelumStellaCSharp.Test.http
{
    internal class BrokenClientHandler : HttpClientHandler
    {
        private readonly HttpStatusCode brokenHttpStatusCode;
        public BrokenClientHandler(HttpStatusCode brokenHttpStatusCode)
        {
            this.brokenHttpStatusCode = brokenHttpStatusCode;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Get)
            {
                if (request.RequestUri.PathAndQuery.Contains("/json/"))
                {
                    var response = new HttpResponseMessage(brokenHttpStatusCode);
                    return Task.FromResult(response);
                }
            }
            return (Task<HttpResponseMessage>)null;
        }
    }
}
