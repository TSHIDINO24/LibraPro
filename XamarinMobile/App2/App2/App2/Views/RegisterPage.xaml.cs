using App2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private UserServices _userservices = new UserServices();
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            //Firstly Check if User's ID Number is valid
            if (IsValidID(txtidnumber.Text))
            {
                if (txtpass.Text != txtconpass.Text)
                {
                    await DisplayAlert("Invalid", "Password do not match", "Ok");
                }
                else
                {
                    bool user = await _userservices.RegisterAsync(txtfirstname.Text, txtlastname.Text, txtidnumber.Text, txtemail.Text,txtaddress.Text, txtphone.Text, txtpass.Text);
                if(user == true)
                {

                    await Navigation.PushAsync(new LoginPage());
                   
                }
                else
                {
                    await DisplayAlert("", "User already exists", "ok");
                }

        }
    }
            else
            {
                await DisplayAlert("", "ID Number is not Valid", "ok");
}
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }


        //Function used to Validate if User ID Number is Valid or not
        public static bool IsValidID(string IDNumber)
        {
            //Check if the ID Number is in the correct format 
            if (!Regex.IsMatch(IDNumber, @"^\d{13}$"))
            {
                return false;
            }

            //Extract the date of birth from the ID number provided
            string YearOfBirth = IDNumber.Substring(0, 2);
            string MonthOfBirth = IDNumber.Substring(2, 2);
            string DayOfBirth = IDNumber.Substring(4, 2);

            int Year = int.Parse(YearOfBirth);
            int Month = int.Parse(MonthOfBirth);
            int Day = int.Parse(DayOfBirth);

            //Check if the date of birth is valid 
            if (Year < 0 || Year > 99 || Month < 1 || Month > 12 || Day < 1 || Day > 31)
            {
                return false;
            }

            //Check the checksum digit 
            //int[] IDDigits = IDNumber.ToCharArray().Select(i => int.Parse(i.ToString())).ToArray();

            //int checksum = 0;

            //for (int c = 0; c < 12; c++)
            //{
            //    checksum += (c % 2 == 0) ? IDDigits[c] : IDDigits[c] * 2;
            //    if (IDDigits[c] > 4)
            //    {
            //        checksum -= 9;
            //    }
            //}

            //int CalcCheckSum = (10 - (checksum % 10)) % 10;
            //int ActualCheckSum = IDDigits[12];

            //return CalcCheckSum == ActualCheckSum;

            //Extract the last digit (checksum digit)
            int Checksumdigit = int.Parse(IDNumber.Substring(12, 1));

            //Calculate the Luhn checksumm
            int[] idDigits = IDNumber.Substring(0, 12).ToCharArray().Select(t => int.Parse(t.ToString())).ToArray();

            int sum = 0;

            bool doubleDigit = true;

            for (int i = idDigits.Length - 1; i >= 0; i--)
            {
                int digit = idDigits[i];

                if (doubleDigit)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }

                sum += digit;
                doubleDigit = !doubleDigit;
            }

            int CalcCheckSum = (10 - (sum % 10)) % 10;

            return CalcCheckSum == Checksumdigit;
        }
    }
}