using Firebase.Database;

namespace Charity
{
    public partial class MainPage : ContentPage
    {
        private readonly FirebaseClient _firebaseClient;

        public MainPage(FirebaseClient firebaseClient)
        {
            InitializeComponent();
            BindingContext = this;

            NavigateToCategoriesCommand = new Command(() => Shell.Current.GoToAsync("CategoryView"));
            NavigateToCasesCommand = new Command(() => Shell.Current.GoToAsync("CasesView"));
            _firebaseClient = firebaseClient;
        }

        public Command NavigateToCategoriesCommand { get; }
        public Command NavigateToCasesCommand { get; }

    }

}
