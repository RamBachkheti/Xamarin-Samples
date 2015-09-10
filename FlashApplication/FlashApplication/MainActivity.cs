using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Hardware;
using Android.Util;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Graphics.Drawables.Shapes;

namespace FlashApplication
{
	[Activity (MainLauncher = true, Icon = "@drawable/iTorch")]
	public class MainActivity : Activity
	{
		View btnLight;
		private Android.Hardware.Camera camera;
		private bool isFlashOn;
		private bool hasFlash;
		Android.Hardware.Camera.Parameters params1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			btnLight = FindViewById(Resource.Id.floating_shape);

			Android.Content.PM.PackageManager pm = PackageManager;

			hasFlash = pm.HasSystemFeature(Android.Content.PM.PackageManager.FeatureCameraFlash);
			if (!hasFlash) {

				//set alert for executing the task
				AlertDialog.Builder alert = new AlertDialog.Builder (this);

				alert.SetTitle ("Error");
				alert.SetMessage ("Sorry, your device doesn't support flash light");
				alert.SetPositiveButton ("OK", (senderAlert, args) => {
					Finish ();
				} );
				//run the alert in UI thread to display in the screen
				RunOnUiThread (() => {
					alert.Show();
				} );

			}

			btnLight.Click += delegate {
				if (isFlashOn) {
					// turn off flash
					TurnOffFlash();
					int h = btnLight.Height;
					ShapeDrawable mDrawable = new ShapeDrawable(new OvalShape());
					mDrawable.Paint.SetShader(new LinearGradient(0, 0, 0, h, Color.Red, Color.Red, Shader.TileMode.Repeat));
					btnLight.SetBackgroundDrawable (mDrawable);
					//btnLight.Text="Tap to off the flash";
				} else {
					// turn on flash
					TurnOnFlash();
					int h = btnLight.Height;
					ShapeDrawable mDrawable = new ShapeDrawable(new OvalShape());
					mDrawable.Paint.SetShader(new LinearGradient(0, 0, 0, h, Color.Green, Color.Red, Shader.TileMode.Repeat));
					btnLight.SetBackgroundDrawable (mDrawable);
					//btnLight.Text="Tap to on the flash";
				}
				//btnLight.Text = string.Format ("{0} clicks!", count++);
			};		
		}

		protected override void OnStart()
		{
			base.OnStart ();
			GetCamera ();
		}

		protected override void OnStop()
		{	
			base.OnStop ();			
			if (camera != null) {
				camera.Release ();
				camera = null;
			}
		}


		protected override void OnResume()
		{
			base.OnResume ();
			if (hasFlash)
				TurnOnFlash ();
		}

		// getting camera parameters
		private void GetCamera() {
			if (camera == null) {
				try {
					camera = Android.Hardware.Camera.Open();
					params1 = camera.GetParameters();
				} catch (Exception e) {
					Log.Error("Camera Error. Failed to Open. Error: ", e.Message);
				}
			}
		}

		/*
 * Turning On flash
 */
		private void TurnOnFlash() {
			//isFlashOn = true;
			if (!isFlashOn) {
				if (camera == null) {
					return;
				}
				// play sound
				//playSound();

				params1 = camera.GetParameters ();
				params1.FlashMode= Android.Hardware.Camera.Parameters.FlashModeTorch;
				camera.SetParameters(params1);
				camera.StartPreview ();
				isFlashOn = true;

				// changing button/switch image
				//toggleButtonImage();
			}

		}



		/*
		 * Turning Off flash
 	*/
		private void TurnOffFlash() {
			if (isFlashOn) {
				if (camera == null) {
					return;
				}
				// play sound
				//playSound();

				params1 = camera.GetParameters ();
				params1.FlashMode= Android.Hardware.Camera.Parameters.FlashModeOn;
				camera.SetParameters(params1);
				camera.StopPreview();
				isFlashOn = false;

				// changing button/switch image
				//toggleButtonImage();
			}
		}
	}
}