using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Week2.Services;
using Week2.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Week2
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        public static string AzureBackendUrl = "http://localhost:5000";
        public static bool UseMockDataStore = true;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            // Load The Mock Datastore by default
            Week2.Services.MasterDataStore.ToggleDataStore(Models.DataStoreEnum.Mock);
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


        //static SQLiteAsyncConnection _database;

        //public static SQLiteAsyncConnection Database
        //{
        //    get
        //    {
        //        if (_database == null)
        //        {
        //            _database = new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>().GetLocalFilePath("CrawlDatabaseKoenig1.db3"));
        //        }
        //        return _database;
        //    }
        //}
    }
}
