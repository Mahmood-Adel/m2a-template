using Microsoft.AspNetCore.Localization;
using Server.Constants;

namespace Server.CultureProviders;

public class HeaderRequestCultureProvider: IRequestCultureProvider
{
    public Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
    {
        var headers = httpContext.Request.Headers;
        if (headers.ContainsKey("lang") && SupportedCultures.All.Any(x => x.Name.Equals(headers["lang"].ToString())))
        {
            return Task.FromResult(new ProviderCultureResult(headers["lang"].ToString()));
        }

        return Task.FromResult(new ProviderCultureResult(SupportedCultures.Default.Name));
    }
}