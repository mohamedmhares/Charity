using Charity.Services;
using Charity.ViewModels;

namespace Charity.Views;

public partial class LoginView : ContentPage
{

	public LoginView(FirebaseAuthService authService)
	{
		InitializeComponent();
        BindingContext = new LoginViewModel(authService);

    }
    private async void OnSignupTaped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignupView());
    }
}