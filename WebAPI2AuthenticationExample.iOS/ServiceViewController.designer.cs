// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//

using MonoTouch.Foundation;

namespace WebAPI2AuthenticationExample.iOS
{
	[Register ("ServiceViewController")]
	partial class ServiceViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField _confirmPassword { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton _getValuesButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton _loginButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField _password { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton _registerButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField _username { get; set; }

		[Action ("GetValuesTapped:")]
		partial void GetValuesTapped (MonoTouch.Foundation.NSObject sender);

		[Action ("LoginTapped:")]
		partial void LoginTapped (MonoTouch.Foundation.NSObject sender);

		[Action ("RegisterTapped:")]
		partial void RegisterTapped (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (_confirmPassword != null) {
				_confirmPassword.Dispose ();
				_confirmPassword = null;
			}

			if (_password != null) {
				_password.Dispose ();
				_password = null;
			}

			if (_username != null) {
				_username.Dispose ();
				_username = null;
			}

			if (_registerButton != null) {
				_registerButton.Dispose ();
				_registerButton = null;
			}

			if (_loginButton != null) {
				_loginButton.Dispose ();
				_loginButton = null;
			}

			if (_getValuesButton != null) {
				_getValuesButton.Dispose ();
				_getValuesButton = null;
			}
		}
	}
}
