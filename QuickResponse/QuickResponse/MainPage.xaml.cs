using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using QuickResponse.Views;
using QuickResponse.Table;
using Xamarin.Forms.Xaml;
using Firebase.Database;
using Firebase.Database.Query;

namespace QuickResponse
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static FirebaseClient Client = new FirebaseClient("https://emergency-app-4dcf7.firebaseio.com/");

        public MainPage()
        {
            InitializeComponent();
        }
    }

}
