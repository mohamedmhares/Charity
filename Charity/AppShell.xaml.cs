using Charity.Views;
namespace Charity
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("CategoryView", typeof(CategoryView));
            Routing.RegisterRoute("CasesView", typeof(CaseView));
            Routing.RegisterRoute("LoginView", typeof(LoginView));
            Routing.RegisterRoute("SignupView", typeof(SignupView));
        }
    }
}
