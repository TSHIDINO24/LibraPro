using App2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Template
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BagListTemplate : ContentView
    {
        public BagListTemplate()
        {
            InitializeComponent();
            BindingContext = new BookVewModel();
        }
    }
}