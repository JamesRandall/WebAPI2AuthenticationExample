using System;
using System.Collections.Generic;
using System.Text;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using WebAPI2AuthenticationExample.iOS.Services;

namespace WebAPI2AuthenticationExample.iOS
{
	public partial class ServiceViewController : UIViewController
	{
		private string _accessToken = "";

		public ServiceViewController () : base ("ServiceViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			_username.BecomeFirstResponder ();
		}

		private void SetButtonEnabled(bool enabled)
		{
			_loginButton.Enabled = enabled;
			_registerButton.Enabled = enabled;
			_getValuesButton.Enabled = enabled;
		}

		async partial void LoginTapped (NSObject sender)
		{
			try
			{
				SetButtonEnabled(false);
				LoginService service = new LoginService();
				_accessToken = await service.Login(_username.Text, _password.Text);
				UIAlertView alert = new UIAlertView("Success", "Login complete", null, "OK", null);
				alert.Show();
			}
			catch
			{
				_accessToken = "";
				UIAlertView alert = new UIAlertView("Error", "Login failed", null, "OK", null);
				alert.Show();
			}
			finally
			{
				SetButtonEnabled(true);
			}
		}

		async partial void RegisterTapped (NSObject sender)
		{
			try
			{
				SetButtonEnabled(false);
				RegisterService service = new RegisterService();
				bool result = await service.Register(_username.Text, _password.Text, _confirmPassword.Text);
				if (!result) throw new InvalidOperationException("Something went wrong");
				UIAlertView alert = new UIAlertView("Success", "Register complete", null, "OK", null);
				alert.Show();
			}
			catch
			{
				UIAlertView alert = new UIAlertView("Error", "Register failed", null, "OK", null);
				alert.Show();
			}
			finally
			{
				SetButtonEnabled(true);
			}
		}

		async partial void GetValuesTapped (NSObject sender)
		{
			try
			{
				SetButtonEnabled(false);
				ValuesService service = new ValuesService();
				IEnumerable<string> values = await service.GetValues(_accessToken);
				StringBuilder sb = new StringBuilder();
				bool first = true;
				foreach(string value in values)
				{
					if (first)
					{
						first = false;
					}
					else
					{
						sb.Append(", ");
					}
					sb.Append(value);
				}

				UIAlertView alert = new UIAlertView("Success",String.Format("Get values complete: {0}", sb), null, "OK", null);
				alert.Show();
			}
			catch
			{
				UIAlertView alert = new UIAlertView("Error", "Get values failed", null, "OK", null);
				alert.Show();
			}
			finally
			{
				SetButtonEnabled(true);
			}
		}
	}
}

