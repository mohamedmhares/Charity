using Charity.Services;
using Charity.ViewModels;

namespace Charity.Views;

public partial class SignupView : ContentPage
{
    public SignupView()
    {
        InitializeComponent();
        BindingContext = new SignupViewModel(new FirebaseAuthService());
    }
    
}