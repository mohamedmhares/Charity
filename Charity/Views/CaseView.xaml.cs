using Charity.ViewModels;

namespace Charity.Views;

public partial class CaseView : ContentPage
{
    private readonly CasesViewModel caseViewModel;

    public CaseView(CasesViewModel caseViewModel)
    {
        InitializeComponent();
        BindingContext = caseViewModel;
        //Task.Run(async () => await caseViewModel.InitializeAsync());
        this.caseViewModel = caseViewModel;
    }
}