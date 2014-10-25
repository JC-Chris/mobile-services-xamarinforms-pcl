using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Forms;
using xamarinpclshared;

namespace xamarinpcl
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		public override UIWindow Window {get; set;}

        public override bool FinishedLaunching(UIApplication application, NSDictionary options)
        {
            Forms.Init();
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            ShowToDoPage();
            return true;
        }

        private void ShowToDoPage()
        {
            Window.RootViewController = App.GetToDoPage().CreateViewController();
            Window.MakeKeyAndVisible();
        }
	}
}

