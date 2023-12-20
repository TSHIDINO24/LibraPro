using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IDNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string UserType { get; set; }

        public string Password { get; set; }

        public string Respo { get; set; }

       // public ICommand RegisterCommand
       // {
            //get
            //{
            //    return new Command(async () =>
            //    {
            //        var isSuccess = await apiservice.RegisterAsync(FirstName, LastName, IDNumber, Email, Address, PhoneNumber, UserType, Password);
            //        if (isSuccess)
            //        {
            //            Respo = "Registered successfully";
            //        }
            //        else
            //        {
            //            Respo = "Try to sign up again!";
            //        }
            //    });
            //}

        //}
    }
}
