using Charity.Services;
using Charity.ViewModels;
using Charity.Views;
using Firebase.Database;
using Microsoft.Extensions.Logging;

namespace Charity
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
            builder.Services.AddSingleton(new FirebaseClient("https://test-a6c53-default-rtdb.firebaseio.com/"));
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<CasesViewModel>();
            builder.Services.AddSingleton<CaseView>();
            builder.Services.AddSingleton<CategoryViewModel>();
            builder.Services.AddSingleton<CategoryView>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<LoginView>(); 
            builder.Services.AddSingleton<SignupViewModel>();
            builder.Services.AddSingleton<SignupView>();
            builder.Services.AddSingleton<FirebaseAuthService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
