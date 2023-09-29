using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using System.Xml;
using QuickResponse.Android;
using Android.App;
 
namespace QuickResponse.Android
{
    [Activity(Label = "QuickResponse", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

           Xamarin.FormsMaps.ReferenceEquals(this, savedInstanceState);
            global::Xamarin.Essentials.Platform.Init(this, savedInstanceState);
           Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    
    
        //public void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Content.PM.Permission[] grantResults)
        //{
        //   Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //   base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
    }
}