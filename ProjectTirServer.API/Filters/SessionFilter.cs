using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProjectTirServer.Core.DomainModel;
using ProjectTirServer.Core.RepositoryInterfaces;
using System.Security.Claims;

namespace ProjectTirServer.API.Filters
{

    public class SessionFilter : Attribute, IEndpointFilter
    {
        public SessionFilter(ISessionRepository sessionRepository) 
        {
            _sessionRepository = sessionRepository;
        }


        private readonly ISessionRepository _sessionRepository;


        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var user = context.HttpContext.User;
            Guid? sessionID = GetSessionId(user);

            if (sessionID is null)
                return Results.Problem(statusCode: 404, detail: "user is not authenticated");

            Session? session =  _sessionRepository.GetSessionById((Guid)sessionID);
            if(session is null)
            {
                await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Results.Problem(statusCode: 404, detail: "user's session was end");
            }
            var result = await next(context);
            return result;
        }


        private Guid? GetSessionId(ClaimsPrincipal claimsPrincipal)
        {
            ClaimsIdentity identitieWithSession = claimsPrincipal.Identities
                .Where(i => i.Claims.Where(c => c.Type == "sessionId").Count() > 0)
                .First();
            string sessionId = identitieWithSession.Claims.Where(c => c.Type == "sessionId").First().Value;
            if(Guid.TryParse(sessionId, out Guid sessionGuid))
                return sessionGuid;
            return null;
        }
    }
}
