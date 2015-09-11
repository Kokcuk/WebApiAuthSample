namespace WebApplication5.Security
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Principal;
    using System.Threading;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class TokenAuthenticationAttribute : AuthorizationFilterAttribute
    {
        private const string DefaultTokenName = "token";
        private readonly ITokenStorage _tokenStorage;

        public TokenAuthenticationAttribute()
        {
            _tokenStorage = new InMemoryTokenStorage();
        }

        public override void OnAuthorization(HttpActionContext context)
        {
            if (!IsAuthorized(context))
            {

                context.Response =
                    context.Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

        private bool IsAuthorized(HttpActionContext context)
        {
            IEnumerable<string> headers;
            context.Request.Headers.TryGetValues(DefaultTokenName, out headers);
            if (headers != null && headers.Any())
            {
                var token = headers.FirstOrDefault();
                var metadata = _tokenStorage.GetMetadata(token);
                if (metadata != null)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(metadata.Login), null);
                    return true;
                }
            }
            return false;
        }
    }
}