using Microsoft.Extensions.DependencyInjection;

namespace MBODM.AspNetCore.SimpleLocalization
{
    public static class SimpleLocalizationMiddleware
    {
        public static IServiceCollection AddSimpleLocalization<TSharedResourceClass>(
            this IServiceCollection serviceCollection, string resourcesPath)
            where TSharedResourceClass : class
        {
            return serviceCollection.
                AddScoped<ILocalizer, Localizer<TSharedResourceClass>>().
                AddLocalization(options => options.ResourcesPath = resourcesPath);
        }

        public static IServiceCollection AddSimpleLocalization<TSharedResourceClass>(
            this IServiceCollection serviceCollection)
            where TSharedResourceClass : class
        {
            return serviceCollection.AddSimpleLocalization<TSharedResourceClass>("Resources");
        }

        public static IMvcBuilder AddSimpleLocalizationForDataAnnotations<TSharedResourceClass>(
            this IMvcBuilder mvcBuilder)
            where TSharedResourceClass : class
        {
            return mvcBuilder.AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                {
                    return factory.Create(typeof(TSharedResourceClass));
                };
            });
        }
    }
}
