using Beise.Services;
using Beise.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Beise
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<IArticleService, ArticleService>();
            MainPage = new AppShell();
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
