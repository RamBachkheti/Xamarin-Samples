using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace LocalNotification
{
	[Activity (Label = "LocalNotification", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;
		Notification.Builder builder;
		Notification notification;
		NotificationManager notificationManger;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			Button button1 = FindViewById<Button> (Resource.Id.button1);

			// Instantiate the builder and set notification elements:
			builder = new Notification.Builder (this)
				.SetContentTitle ("Test")
				.SetContentText ("This is test")
				.SetSmallIcon (Resource.Drawable.Icon);

			// Build the notification:
			notification = builder.Build ();

			// Get the notification manager:
			notificationManger = GetSystemService (Context.NotificationService) as NotificationManager;

			const int notificationId = 0;

			button.Click += delegate {
				// Publish the notification:
				notificationManger.Notify (notificationId,notification);
				button.Text = string.Format ("{0} clicks!", count++);
			};

			button1.Click += delegate {
				builder = new Notification.Builder (this)
					.SetContentTitle ("Updated Test")
					.SetContentText ("This is updated test")
					.SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate)
					.SetSmallIcon (Resource.Drawable.Icon);

				// Build the notification:
				notification = builder.Build ();

				// Publish the notification:
				notificationManger.Notify (notificationId,notification);

				button.Text = string.Format ("{0} clicks!", count++);
			};
		}
	}
}