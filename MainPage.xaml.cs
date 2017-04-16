using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace SimpleTipCalc
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var app = Application.Current as App;
            TipPercent.Text = app.DefaultTip;
        }

        async private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            //Settings Page
            await Navigation.PushAsync(new SettingsPage());
        }

        private void BillEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Calculate the tip if entry for Tip Amount and Bill subtotal are NOT null
            if (!String.IsNullOrWhiteSpace(BillSubTotal.Text) && !String.IsNullOrWhiteSpace(TipPercent.Text))
            {
                CalculateTip();
            }
            else
            {
                AmountToTip.Text = "";
                TotalBillAmount.Text = "";
            }
        }

        private void TipPercent_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(BillSubTotal.Text) && !String.IsNullOrWhiteSpace(TipPercent.Text))
            {
                CalculateTip();
            }
            else
            {
                AmountToTip.Text = "";
                TotalBillAmount.Text = "";
            }
        }

        private void CalculateTip()
        {
            Decimal _billSubTotal = 0;
            Decimal _tipPercent = 0;
            Decimal.TryParse(BillSubTotal.Text, out _billSubTotal);
            Decimal.TryParse(TipPercent.Text, out _tipPercent);

            if (_billSubTotal > 0 && _tipPercent > 0)
            {
                var _amountToTip = ((Decimal)_billSubTotal / 100) * _tipPercent;
                _amountToTip = Math.Round(_amountToTip, 2);

                var _totalBillAmount = _amountToTip + _billSubTotal;
                _totalBillAmount = Math.Round(_totalBillAmount, 2);

                var app = Application.Current as App;
                if (app.RoundTotal)
                {
                    //Math to round the total
                    var difference = Math.Ceiling(_totalBillAmount) - _totalBillAmount;
                    _amountToTip = _amountToTip + difference;
                    _totalBillAmount = _amountToTip + _billSubTotal;
                }

                AmountToTip.Text = "$" + _amountToTip.ToString();
                TotalBillAmount.Text = "$" + _totalBillAmount.ToString();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var app = Application.Current as App;
            TipPercent.Text = app.DefaultTip;

            if (!String.IsNullOrWhiteSpace(BillSubTotal.Text) && !String.IsNullOrWhiteSpace(TipPercent.Text))
            {
                CalculateTip();
            }

        }
    }
}
