using Microsoft.Extensions.Logging;
using ProyectoFinal.Pages;

namespace ProyectoFinal
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
            builder.Services.AddLogging(configure =>
            {
                // Configuración de registro (logging)
                configure.AddDebug(); // Agrega la salida de logs a la consola en modo DEBUG
            });
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
