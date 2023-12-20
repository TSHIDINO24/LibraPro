using App2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutHomeFlyout : ContentPage
    {
        public ListView ListView;

        public FlyoutHomeFlyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutHomeFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class FlyoutHomeFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutHomeFlyoutMenuItem> MenuItems { get; set; }

            public FlyoutHomeFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutHomeFlyoutMenuItem>(new[]
                {
                    new FlyoutHomeFlyoutMenuItem { Id = 0, Title = "Home", IconSource="home2.png", TargetType=typeof(FlyoutHome)},
                    new FlyoutHomeFlyoutMenuItem { Id = 1, Title = "Book Categories", IconSource="book3.png", TargetType=typeof(CategoryPage)},
                    new FlyoutHomeFlyoutMenuItem { Id = 2, Title = "Book History", IconSource="bookhistory.png", TargetType=typeof(BookHistoryPage) },
                    new FlyoutHomeFlyoutMenuItem { Id = 3, Title = "Book Bag",IconSource="bookbasket.png", TargetType=typeof(BookBagPage) },
                    new FlyoutHomeFlyoutMenuItem { Id = 4, Title = "About Us",IconSource="team.png", TargetType=typeof(AboutPage) },
                    new FlyoutHomeFlyoutMenuItem { Id = 5, Title = "Contact Us",IconSource="contactmail.png", TargetType=typeof(ContactPage) },
                    new FlyoutHomeFlyoutMenuItem { Id = 6, Title = "Account",IconSource="useraccount.png", TargetType=typeof(AccountPage) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}