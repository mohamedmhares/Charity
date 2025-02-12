using Charity.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Charity.ViewModels
{
    public partial class CasesViewModel : BaseViewModel
    {
        private readonly FirebaseClient _firebaseClient;

        public CasesViewModel(FirebaseClient firebaseClient)
        {
            _firebaseClient = firebaseClient ?? throw new ArgumentNullException(nameof(firebaseClient));
            Categories = new ObservableCollection<Category>();
            Cases = new ObservableCollection<Case>();
            Task.Run(async () => await InitializeAsync());
        }

        [ObservableProperty]
        private string caseName;

        [ObservableProperty]
        private string caseNumber;

        [ObservableProperty]
        private string caseDescription;

        [ObservableProperty]
        private bool isFatherAlive;

        [ObservableProperty]
        private bool isMotherAlive;

        [ObservableProperty]
        private ObservableCollection<Category> categories;

        [ObservableProperty]
        private Category selectedCategory;

        [ObservableProperty]
        private ObservableCollection<Case> cases;

        [ObservableProperty]
        private bool isLoading; // To indicate loading state

        public async Task InitializeAsync()
        {
            IsLoading = true;
            try
            {
                await LoadCategoriesAsync();
                await LoadCasesAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Initialization failed: {ex.Message}", "OK");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                var categoriesFromDb = await _firebaseClient.Child("Category").OnceAsync<Category>();
                Categories.Clear();
                foreach (var category in categoriesFromDb)
                {
                    Categories.Add(category.Object);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Failed to load categories: {ex.Message}", "OK");
            }
        }

        private async Task LoadCasesAsync()
        {
            try
            {
                var casesFromDb = await _firebaseClient.Child("Case").OnceAsync<Case>();
                Cases.Clear();
                foreach (var caseItem in casesFromDb)
                {
                    Cases.Add(caseItem.Object);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Failed to load cases: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        public async Task AddCaseAsync()
        {
            if (string.IsNullOrWhiteSpace(CaseName) || string.IsNullOrWhiteSpace(CaseNumber) || string.IsNullOrWhiteSpace(CaseDescription) || selectedCategory == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill out all fields.", "OK");
                return;
            }

            try
            {
                var newCase = new Case
                {
                    Name = CaseName,
                    CasesNumber = CaseNumber,
                    IsFatherAlive = IsFatherAlive,
                    IsMotherAlive = IsMotherAlive,
                    Description = CaseDescription,
                    CategoryId = SelectedCategory.Id,
                    CategoryName = SelectedCategory.Name,
                };

                await _firebaseClient.Child("Case").PostAsync(newCase);

                // Add the new case to the list
                Cases.Add(newCase);

                // Reset input fields
                CaseName = string.Empty;
                CaseNumber = string.Empty;
                CaseDescription = string.Empty;
                IsFatherAlive = false;
                IsMotherAlive = false;
                SelectedCategory = null;

                await Application.Current.MainPage.DisplayAlert("Success", "Case added successfully.", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Failed to add case: {ex.Message}", "OK");
            }
        }
    }
}
