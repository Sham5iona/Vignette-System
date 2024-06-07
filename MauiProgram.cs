using Microsoft.Extensions.Logging;
using VignetteSystem.Model.Interfaces;
using VignetteSystem.Model.Services;
using VignetteSystem.ViewModel;
using VignetteSystem.Views;

namespace VignetteSystem
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddTransient<ICheckVignette, BulgarianVignetteChecking>();
            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddTransient<BulgarianVignetteSystemViewModel>();
            builder.Services.AddTransient<BulgarianVignetteSystemPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
