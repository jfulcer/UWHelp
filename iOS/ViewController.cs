using System;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace UWHelp.iOS
{
	public partial class ViewController : UIViewController
	{
		partial void CallSecurity(UIButton sender)
		{
			//tests button pushed
			Console.WriteLine("Button pushed");
			//sends sms back up with location
            //LaunchUriAsync(new Uri("sms:971-319-1337"));
			//calls UWT campus security emergency number
            LaunchUriAsync(new Uri("tel:971-319-1337"));
		}
		//making changes to test push
		//second change to test sync
	public Task<bool> LaunchUriAsync(Uri uri)
	{
		var completion = new TaskCompletionSource<bool>();
		var sharedApp = UIApplication.SharedApplication;
		sharedApp.BeginInvokeOnMainThread(() =>
			{
				try
				{
					var url = NSUrl.FromString(uri.ToString()) ?? new NSUrl(uri.Scheme, uri.Host, uri.LocalPath);
					var result = sharedApp.CanOpenUrl(url) && sharedApp.OpenUrl(url);
					completion.SetResult(result);
				}
				catch (Exception exception)
				{
					completion.SetException(exception);
				}
			});
		  return completion.Task;
}

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Code to start the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start ();
#endif

			// Perform any additional setup after loading the view, typically from a nib.
			/*Button.AccessibilityIdentifier = "myButton";
			Button.TouchUpInside += delegate
			{
				var title = string.Format("{0} clicks!", count++);
				Button.SetTitle(title, UIControlState.Normal);
			};*/
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
