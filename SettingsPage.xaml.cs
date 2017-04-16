using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleTipCalc
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            BindingContext = Application.Current;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Application.Current.SavePropertiesAsync();
        }

        private void IconURL_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri ("https://icons8.com"));
        }
    }
}
