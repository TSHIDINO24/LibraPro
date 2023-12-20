using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Template
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckoutTemplate : ContentView
    {
        public CheckoutTemplate()
        {
            InitializeComponent();
        }

        public enum CheckOutStepEnum
        {
            Bag,
            Receipt
        }

        public static readonly BindableProperty CheckoutStepProperty = BindableProperty.Create(nameof(CheckOutStepEnum),
            typeof(CheckOutStepEnum), typeof(CheckoutTemplate), CheckOutStepEnum.Bag);

        public CheckOutStepEnum CheckOutStep
        {
            get => (CheckOutStepEnum)GetValue(CheckoutStepProperty);
            set => SetValue(CheckoutStepProperty, value);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(CheckOutStepEnum))
            {
                if (CheckOutStep == CheckOutStepEnum.Receipt)
                {
                    //lblBagCircle.Text Models.
                }
            }
        }
    }
}