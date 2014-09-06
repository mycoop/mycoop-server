using System.Web;
using System.Web.Routing;

public class FontServiceRoute : IRouteHandler
{
    public IHttpHandler GetHttpHandler(RequestContext requestContext)
    {
        return new FontService(requestContext);
    }
}
