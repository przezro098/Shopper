
using Shopper.Data;
using Shopper.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Shopper
{
    public partial class App : Application
    {
        static ProductDatabase productDatabase;
        static UserDatabase userDatabase;

        public App()
        {
            InitializeComponent();

            var nav = new NavigationPage(new LoginPageCS());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }

        public static ProductDatabase ProductDataBase
        {
            get
            {
                if (productDatabase == null)
                {
                    productDatabase = new ProductDatabase();
                }
                return productDatabase;
            }
        }

        public static UserDatabase UserDatabase
        {
            get
            {
                if (userDatabase == null)
                {
                    userDatabase = new UserDatabase();
                }
                return userDatabase;
            }
        }


        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}

