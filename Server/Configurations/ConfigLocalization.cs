using Microsoft.AspNetCore.Localization;
using Server.Constants;
using Server.CultureProviders;
using Server.Resources.Shared;

namespace Server.Configurations;

public static partial class Config
{
    public static void ConfigureLocalization(IServiceCollection services)
    {
        services.AddLocalization(options =>   options.ResourcesPath = "Resources"); 
        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture(SupportedCultures.Default);

            options.SupportedCultures = SupportedCultures.All;
            options.SupportedUICultures = SupportedCultures.All;

            options.RequestCultureProviders = new List<IRequestCultureProvider> {new HeaderRequestCultureProvider()};
            
            //todo Add Data annotation localization
        });
    }
}