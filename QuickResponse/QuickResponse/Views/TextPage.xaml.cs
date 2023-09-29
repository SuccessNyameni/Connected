using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.IO;
using Plugin.Toast;
using Xamarin.Forms.Platform;




namespace QuickResponse.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextPage : ContentPage
    {
        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt");
        string test;
        string test2;
        string test3;
        string test4;
        string test5;

        string message = "";
        Label Latitude = new Label();
        Label Longitude = new Label();

        public TextPage(string myValue, string value2, string value3, string value4, string value5)
        {
            InitializeComponent();
            test = myValue;
            test2 = value2;
            test3 = value3;
            test4 = value4;
            test5 = value5;
        }
        public async void SendMessage(object sender, EventArgs e)
        {
            string message = "";
            message = messageEditor.Text;

            try
            {
                     if (messageEditor.Text == null)
                      {
                        await DisplayAlert("Error", "Please enter message", "OK");
                      }
                else 
                {
                    Location Location = await Geolocation.GetLocationAsync();
                    if (Location == null)
                    {
                        Location = await Geolocation.GetLocationAsync(new GeolocationRequest
                        {
                            Timeout = TimeSpan.FromSeconds(30)
                        }); ;
                    }

                    Latitude.Text = Location.Latitude.ToString();
                    Longitude.Text = Location.Longitude.ToString();

                    string loc = Longitude.Text;
                    string loc1 = Latitude.Text;
                    string locationsss = loc1.Replace(",", ".") + "," + loc.Replace(",", ".");

                    string allPhoneNumbers = test + "," + test2 + "," + test3 + "," + test4 + "," + test5;                    
                    
                    StreamReader streamReader = new StreamReader(fileName);

                    string content = streamReader.ReadToEnd();
                   //var manager = Android.Telephony.SmsManager.Default;
                   //var manager.SendTextMessage(content, null, "EMERGENCY!!" + "\n" + "Message: " + message + "\n" + " http://www.google.com/maps/place/" + locationsss, null, null);

                    CrossToastPopUp.Current.ShowToastSuccess("Message Sent");
                    messageEditor.Text = string.Empty;
                    message = "";
                    await Navigation.PushModalAsync(new FinalPage(test, test2, test3, test4, test5));
                }
            }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Error", "The error: " + ex.Message, "OK");
                    }
        }
    }
 }
           
  
    
