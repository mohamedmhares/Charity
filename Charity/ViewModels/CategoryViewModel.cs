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
    public partial class CategoryViewModel : BaseViewModel
    {
        private readonly FirebaseClient _firebaseClient;

        public CategoryViewModel(FirebaseClient firebaseClient)
        {
            _firebaseClient = firebaseClient ?? throw new ArgumentNullException(nameof(firebaseClient));
            Categories = new ObservableCollection<Category>();
            _ = InitializeAsync(); // Asynchronously initialize the ViewModel
        }

        [ObservableProperty]
        private string categoryName;

        [ObservableProperty]
        private string categoryDescription;

        [ObservableProperty]
        private ObservableCollection<Category> categories;

        private async Task InitializeAsync()
        {
            try
            {
                await LoadCategoriesAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Failed to load categories: {ex.Message}", "OK");
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
                await Application.Current.MainPage.DisplayAlert("Error", $"Error loading categories: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        public async Task AddCategoryAsync()
        {
            if (string.IsNullOrWhiteSpace(CategoryName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Category name is required.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(CategoryDescription))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Category description is required.", "OK");
                return;
            }

            try
            {
                var newCategory = new Category
                {
                    Name = CategoryName,
                    Description = CategoryDescription
                };

                await _firebaseClient.Child("Category").PostAsync(newCategory);

                ResetProperties();

                await Application.Current.MainPage.DisplayAlert("Success", "Category added successfully.", "OK");
                await LoadCategoriesAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Failed to add category: {ex.Message}", "OK");
            }
        }

        private void ResetProperties()
        {
            CategoryName = string.Empty;
            CategoryDescription = string.Empty;
        }
    }
}
