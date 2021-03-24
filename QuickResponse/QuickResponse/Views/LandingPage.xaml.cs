using Android.Content;
using Firebase.Database;
using QuickResponse.Table;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Toast;

namespace QuickResponse.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage 
    {             
        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt");
        string number1;
        string number2;
        string number3;
        string number4;
        string number5;
        public Context Activity { get; private set; }
        public LandingPage(string myValue, string value2, string value3, string value4, string value5)
        {
            InitializeComponent();
            phoneNumber1.Text = myValue;
            phoneNumber2.Text = value2;
            phoneNumber3.Text = value3;
            phoneNumber4.Text = value4;
            phoneNumber5.Text = value5;
        }
        //Register Button
        public async void Button_Clicked_1(object sender, EventArgs e)
        {
                try
                {
                    number1 = phoneNumber1.Text;
                    number2 = phoneNumber2.Text;
                    number3 = phoneNumber3.Text;
                    number4 = phoneNumber4.Text;
                    number5 = phoneNumber5.Text;

                    if (string.IsNullOrWhiteSpace(phoneNumber1.Text) )//|| string.IsNullOrWhiteSpace(phoneNumber2.Text) || string.IsNullOrWhiteSpace(phoneNumber3.Text) || string.IsNullOrWhiteSpace(phoneNumber4.Text) || string.IsNullOrWhiteSpace(phoneNumber5.Text))
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Please Enter at least one number ", "OK");
                    }
                    else
                    {
                    if (phoneNumber1.Text.Length < 10)// || phoneNumber2.Text.Length < 10 || phoneNumber3.Text.Length < 10 || phoneNumber4.Text.Length < 10 || phoneNumber5.Text.Length < 10)
                    {
                        await DisplayAlert("Warning", "Invalid numbers entered", "OK");
                    }
                    else 
                    {
                        TrusteeNumbers obj = new TrusteeNumbers();
                        obj.phoneNumberFive = number5;
                        obj.phoneNumberFour = number4;
                        obj.phoneNumberThree = number3;
                        obj.phoneNumberTwo = number2;
                        obj.phoneNumberOne = number1;

                        using (var streamWriter = new StreamWriter(fileName, true))
                        {
                            streamWriter.WriteLine(obj.phoneNumberOne + "," + obj.phoneNumberTwo + "," + obj.phoneNumberThree + "," + obj.phoneNumberFour + "," + obj.phoneNumberFive);
                        }
                        using (var streamReader = new StreamReader(fileName))
                        {
                            string content = streamReader.ReadToEnd(); 
                            CrossToastPopUp.Current.ShowToastSuccess("Successfully Registered");
                        }
                        await Navigation.PushModalAsync(new FinalPage(obj.phoneNumberOne, obj.phoneNumberTwo, obj.phoneNumberThree, obj.phoneNumberFour, obj.phoneNumberFive));                    }
                }
                }
                catch (Exception ex)
                {
                   await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }               
        }
    }
}
