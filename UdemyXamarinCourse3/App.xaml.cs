using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UdemyXamarinCourse3
{
    public partial class App : Application
    {
        private const string TitleKey = "Name";
        private const string NotificationsEnabledKey = "NotificationsEnabled";

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public string Title
        {
            get
            {
                if (Properties.ContainsKey(TitleKey))
                    return Properties[TitleKey].ToString();
                return "";
            }

            set
            {
                Properties[TitleKey] = value;
            }
        }

        public bool NotificationEnabled
        {
            get
            {
                if (Properties.ContainsKey(NotificationsEnabledKey))
                    return (bool)Properties[NotificationsEnabledKey];

                return false;

            }

            set
            {
                Properties[NotificationsEnabledKey] = value;
            }
        }
    }
}
