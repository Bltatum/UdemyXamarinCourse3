using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UdemyXamarinCourse3
{   //Application Properties save. First Implemetation/
//    public partial class MainPage : ContentPage
//    {
//        public MainPage()
//        {
//            InitializeComponent();
//            //Loads settings when page is rendered.
//            if (Application.Current.Properties.ContainsKey("Name"))
//                title.Text = Application.Current.Properties["Name"].ToString();

//            if (Application.Current.Properties.ContainsKey("NotificationsEnabled"))
//                notificationsEnabled.On = (bool)Application.Current.Properties["NotificationsEnabled"];
//        }   

//        void OnChanged(System.Object sender, System.EventArgs e)
//        {   //Saves when appliction goes to sleep
//            Application.Current.Properties["Name"] = title.Text;
//            Application.Current.Properties["NotificationsEnabled"] = notificationsEnabled.On;

//            //This enables save ASAP instead of waiting on sleep.
//            //Application.Current.SavePropertiesAsync();

//            //Saves when user navigates away from page.
//            //protected override void OnDisappearing()
//            //{
//            //    base.OnDisappearing();
//            //}
//        }
//
  //  }

    //Application Properties save. Cleaner Implementation.
    public partial class MainPage : ContentPage
    {
        //cut and pasted private fields and put in app class. 1st
        //private const string TitleKey = "Name";
        //private const string NotificationsEnabledKey = "NotificationsEnabled";

        public MainPage()
        {
            InitializeComponent();

            BindingContext = Application.Current;

            //var app = Application.Current as App;
            //title.Text = app.Title;
            //notificationsEnabled.On = app.NotificationEnabled; 

        }

            //void OnChanged(System.Object sender, System.EventArgs e)
            //{  //1st
            //    //Application.Current.Properties[TitleKey] = title.Text;
            //    //Application.Current.Properties[NotificationsEnabledKey] = notificationsEnabled.On;

            //    //2nd
            //   var app = Application.Current as App;
            //    app.Title = title.Text;
            //    app.NotificationEnabled = notificationsEnabled.On;
            //}
        
    }

}
