
using Plugin.Settings.Abstractions;
using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings.Abstractions.Extensions;
using Xamarin.Essentials;

namespace App2.Helper
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }


        public static string token
        {
            get
            {
                return AppSettings.GetValueOrDefault("token", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("token", value);
            }
        }


        //BorrowCOde
        public static string BorrowCode
        {
            get
            {
                return AppSettings.GetValueOrDefault("BorrowCode", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("BorrowCode",value);
            }
        }

        //Category of user's choice
        public static int categoId
        {

            get => Preferences.Get(nameof(categoId), 0);
            set => Preferences.Set(nameof(categoId), value);
        }

        //Counts number of notifications sent to user
        public static int NumNotifications
        {
            get => Preferences.Get(nameof(NumNotifications), 0);
            set => Preferences.Set(nameof(NumNotifications), value);
        }

        //Counts number of books added to Bag
        public static int NumBagBooks
        {
            get => Preferences.Get(nameof(NumBagBooks), 0);
            set => Preferences.Set(nameof(NumBagBooks), value);
        }

        //Counts number of books reserved
        public static int NumReservedBooks
        {
            get => Preferences.Get(nameof(NumReservedBooks), 0);
            set => Preferences.Set(nameof(NumReservedBooks), value);
        }

        //Counts number of books reserved
        public static int NumBorrowedBooks
        {
            get => Preferences.Get(nameof(NumBorrowedBooks), 0);
            set => Preferences.Set(nameof(NumBorrowedBooks), value);
        }
    }
}
