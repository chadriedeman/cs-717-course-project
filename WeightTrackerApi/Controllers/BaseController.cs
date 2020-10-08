using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace WeightTrackerApi.Controllers
{
    public abstract class BaseController : Controller
    {
        protected string GetBasePath(HttpRequest httpRequest)
        {
            if (httpRequest == null)
                return string.Empty;

            var isLocalhost = Regex.Match(httpRequest.Host.ToString(), "localhost")
                .Success;

            var dnsPrefix = "/weightrackerapi";

            var scheme = "https";

            if (isLocalhost)
            {
                dnsPrefix = string.Empty;
                scheme = "http";
            }

            return $"{scheme}://{httpRequest.Host}{dnsPrefix}{httpRequest.Path.Value.TrimEnd('/')}";
        }
    }
}
