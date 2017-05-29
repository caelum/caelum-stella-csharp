using System.Net;
using System.Net.Http;

namespace CaelumStellaCSharp.http
{
    public interface IHttpResponse
    {
        HttpContent Content { get; }
        HttpStatusCode StatusCode { get; }
        bool Success { get; }
    }
}