using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Messaging;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QuickResponse.Views;
using QuickResponse.Table;
using System.IO;
using Plugin.Toast;


namespace QuickResponse.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [assembly: UsesPermission(Manifest.Permission.SEND_SMS)]
    [assembly: UsesPermission(Manifest.Permission.ACCESS_COARSE_LOCAION)]
    [assembly: UsesPermission(Manifest.Permission.ACCESS_FINE_LOCATION)]
    public partial class FinalPage : ContentPage
    {
        //text file path
        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt");
        //LandingPage landingPage = new LandingPage(string a, string b, string c, string d, string e);
        string test;
        string test2;
        string test3;
        string test4;
        string test5;

        public string firstLocationLatitude;
        public string firstLocationLongitude;
        public string secondLocationLongitude;
        public string secondLocationLatitude;

        public FinalPage(string myValue, string value2, string value3, string value4, string value5)
        {
           InitializeComponent();

            test = myValue;
            test2 = value2;
            test3 = value3;
            test4 = value4;
            test5 = value5;
        }

        //Button to edit registered Trustee number
        public async void PencilButton(object sender, EventArgs e)
        {
            File.Delete(fileName);
            await Navigation.PushModalAsync(new LandingPage(test, test2, test3, test4, test5));
        }

        //Button to allow user to type their own emergency text
        public async void buttonTypeMessage(object sender, EventArgs e) 
        {
            await Navigation.PushModalAsync(new TextPage(test,test2,test3,test4,test5));
        }

        //Police button
        public async void PoliceButton(object sender, EventArgs e)
        {            
                try
                {
                await Task.Delay(200);
                await PoliceDeptButton.FadeTo(0, 300);
                await Task.Delay(200);
                await PoliceDeptButton.FadeTo(1, 300);
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

                firstLocationLatitude = loc1;
                firstLocationLongitude = loc;

                string allPhoneNumbers = test + "," + test2 + "," + test3 + "," + test4 + "," + test5;

                    StreamReader streamReader = new StreamReader(fileName);
                    string content = streamReader.ReadToEnd();
                    var manager = Android.Telephony.SmsManager.Default;
                    manager.SendTextMessage(content, null, "EMERGENCY!!" + "\n" + "In need of Police" + "\n" + "Here is my location : " + " http://www.google.com/maps/place/" + locationsss, null, null);
                    CrossToastPopUp.Current.ShowToastSuccess("Message Sent");
                }

                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Check Trustee numbers", "OK");
                }

                //Timer
                Device.StartTimer(TimeSpan.FromMinutes(10), () =>
                {
                    CheckRadius();
                    bool status = true;
                    string loc = Longitude.Text;
                    string loc1 = Latitude.Text;
                    string locationsss = loc1.Replace(",", ".") + "," + loc.Replace(",", ".");

                    try
                    {
                        if (firstLocationLatitude.Substring(0, 4).Equals(secondLocationLatitude.Substring(0, 4)) &&
                        firstLocationLongitude.Substring(0, 4).Equals(secondLocationLongitude.Substring(0, 4)))
                        {

                            return status = false;
                        }
                        else
                        {
                            StreamReader streamReader = new StreamReader(fileName);

                            string content = streamReader.ReadToEnd();
                            var manager = Android.Telephony.SmsManager.Default;
                            manager.SendTextMessage(content, null, "Updated Location" + "\n" + "Here is my location : " + " http://www.google.com/maps/place/" + locationsss, null, null);
                            return true;// True = Repeat again, False = Stop the timer
                        }
                    }
                    catch (Exception ex)
                    {
                        App.Current.MainPage.DisplayAlert("Error", "The error occured: " + ex.Message, "OK");
                    }

                    return status; // True = Repeat again, False = Stop the timer
                });          
        }

        //check Radius Method
        public async void CheckRadius()
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

            string locUp = Longitude.Text;
            string loc1Up = Latitude.Text;
            string locationUpdated = loc1Up.Replace(",", ".") + "," + locUp.Replace(",", ".");

            secondLocationLatitude = loc1Up;
            secondLocationLongitude = locUp;  
        }

        //Ambulance Button
        public async void AmbulanceButton(object sender, EventArgs e)
        {
            try
            {
                await Task.Delay(200);
                await AmbuButton.FadeTo(0, 300);
                await Task.Delay(200);
                await AmbuButton.FadeTo(1, 300);

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
                var manager = Android.Telephony.SmsManager.Default;
                manager.SendTextMessage(content, null, "EMERGENCY!!" + "\n" + "In need of Ambulance" + "\n" + "Here is my location : " + " http://www.google.com/maps/place/" + locationsss, null, null);

                CrossToastPopUp.Current.ShowToastSuccess("Message Sent");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error","Check Trustee numbers ", "OK");
            }         
        }
        
        //Fire department Button
        public async void FireButton(object sender, EventArgs e)
        { 
            try
            {
                await Task.Delay(200);
                await FireDeptButton.FadeTo(0, 300);
                await Task.Delay(200);
                await FireDeptButton.FadeTo(1, 300);


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
                var manager = Android.Telephony.SmsManager.Default;
                manager.SendTextMessage(content,null, "EMERGENCY!!" + "\n" + "In need of Fire Department" + "\n" + "Here is my location : " + " http://www.google.com/maps/place/" + locationsss, null, null);
                CrossToastPopUp.Current.ShowToastSuccess("Message Sent");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error","Check Trustee numbers", "OK");
            }            
        }
    }
}





