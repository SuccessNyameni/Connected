using QuickResponse.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using QuickResponse.Table;
using QuickResponse.Helpers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;



namespace QuickResponse
{
    public partial class App : Application
    {
        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt");
        public string IsFirstTime
        {
            get { return Settings.GeneralSettings; }
            set 
            {
                if (Settings.GeneralSettings == value)
                    return;
                Settings.GeneralSettings = value;
                OnPropertyChanged();
            }
        }
        public App()
        {          
            InitializeComponent();

            string a = "";
            string b = "";
            string c = "";
            string d = "";
            string e = "";
            if (IsFirstTime == "yes")
            {
                IsFirstTime = "no";
                MainPage = new LandingPage(a, b, c, d, e);
            }
            else 
            {                              
                MainPage = new FinalPage(a,b,c,d,e);
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
