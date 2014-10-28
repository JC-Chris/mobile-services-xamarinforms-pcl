using System;
using Android.OS;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Shared;
using Xamarin.Forms.Platform.Android;
using xamarinpclshared;


namespace xamarinpcl
{
	[Activity (MainLauncher = true, 
	           Icon="@drawable/ic_launcher", Label="@string/app_name",
	           Theme="@style/AppTheme")]
    public class ToDoActivity : AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            SetPage(App.GetToDoPage());
        }
    }
}


