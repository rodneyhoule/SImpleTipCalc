using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SimpleTipCalc
{
    public partial class App : Application
    {
        private const string DefaultTipKey = "DefaultTip";
        private const string RoundSwitchKey = "RoundTotal";

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public string DefaultTip
        {
            get
            {
                if (Properties.ContainsKey(DefaultTipKey))
                    return Properties[DefaultTipKey].ToString();

                return "";
            }
            set
            {
                Properties[DefaultTipKey] = value;
            }
        }

        public bool RoundTotal
        {
            get
            {
                if (Properties.ContainsKey(RoundSwitchKey))
                    return (bool)Properties[RoundSwitchKey];

                return false;
            }
            set
            {
                Properties[RoundSwitchKey] = value;
            }
        }
    }
}
