using Charity.ViewModels;
namespace Charity.Views;

public partial class CategoryView : ContentPage
{
    private readonly CategoryViewModel categoryViewModel;

    public CategoryView(CategoryViewModel categoryViewModel)
    {
        InitializeComponent();
        BindingContext = categoryViewModel;
        this.categoryViewModel = categoryViewModel;
    }
}