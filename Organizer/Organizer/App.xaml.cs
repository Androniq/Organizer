using Organizer.Views;
using System;
using Organizer.Data;
using Organizer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Organizer
{
    public partial class App : Application
    {
        public new static App Current { get; private set; }

        public Storage Storage { get; }

        public MainVm MainVm { get; }

        public App()
        {
            Current = this;

            InitializeComponent();

            Storage = new Storage();

            MainPage = new MainView();

            MainVm = (MainVm)MainPage.BindingContext;

            Init();
        }

        private async void Init()
        {
            await Storage.Init();
            await MainVm.Load();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
