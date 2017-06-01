using System.Net;
using System.Net.Http;

namespace Caelum.Stella.CSharp.Http
{
    public interface IHttpResponse
    {
        HttpContent Content { get; }
        HttpStatusCode StatusCode { get; }
        bool Success { get; }
    }
}