using Charity.Models;
using Charity.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Database;
using System;
using System.Threading.Tasks;

namespace Charity.ViewModels
{
    public partial class LoginViewModel(FirebaseAuthService authService) : BaseViewModel
    {
        private readonly FirebaseAuthService _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        [ObservableProperty]
        private string userName;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private bool isLoading; // To indicate loading state

        [RelayCommand]
        public async Task Login()
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter both username and password.", "OK");
                return;
            }

            IsLoading = true;
            try
            {
                var userId = await _authService.LoginAsync(UserName, Password);

                // Example success logic: Navigate to another page or show a success message
                await Application.Current.MainPage.DisplayAlert("Success", $"Welcome User ID: {userId}", "OK");
                // Example Navigation: await Shell.Current.GoToAsync("//HomePage");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Login failed: {ex.Message}", "OK");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
