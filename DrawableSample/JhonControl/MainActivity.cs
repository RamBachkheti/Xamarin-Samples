using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Graphics.Drawables.Shapes;

namespace JhonControl
{
	[Activity (Label = "Ram's First Graphics", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			//LayoutInflater inflater;

			var topLeft = FindViewById(Resource.Id.floating_shape1);
			var topRight = FindViewById(Resource.Id.floating_shape2);
			var bottomLeft = FindViewById(Resource.Id.floating_shape3);
			var bottomRight= FindViewById(Resource.Id.floating_shape4);

	
			topLeft.Touch += delegate {
				int h = topLeft.Height;
				ShapeDrawable mDrawable = new ShapeDrawable(new OvalShape());
				mDrawable.Paint.SetShader(new LinearGradient(0, 0, 0, h, Color.Red, Color.Red, Shader.TileMode.Repeat));
				topLeft.SetBackgroundDrawable (mDrawable);
			};

			topRight.Touch += delegate {
				int h = topRight.Height;
				ShapeDrawable mDrawable = new ShapeDrawable(new OvalShape());
				mDrawable.Paint.SetShader(new LinearGradient(0, 0, 0, h, Color.Yellow, Color.Yellow, Shader.TileMode.Repeat));
				topRight.SetBackgroundDrawable (mDrawable);
			};

			bottomLeft.Touch += delegate {
				int h = bottomLeft.Height;
				ShapeDrawable mDrawable = new ShapeDrawable(new OvalShape());
				mDrawable.Paint.SetShader(new LinearGradient(0, 0, 0, h, Color.Green, Color.Green, Shader.TileMode.Repeat));
				bottomLeft.SetBackgroundDrawable (mDrawable);
			};

			bottomRight.Touch += delegate {
				int h = bottomRight.Height;
				ShapeDrawable mDrawable = new ShapeDrawable(new OvalShape());
				mDrawable.Paint.SetShader(new LinearGradient(0, 0, 0, h, Color.ParseColor("#330000FF"), Color.ParseColor ("#110000FF"), Shader.TileMode.Repeat));
				bottomRight.SetBackgroundDrawable (mDrawable);
				Toast.MakeText (this,"you have clicked on "+Resource.Id.floating_shape1,ToastLength.Long);
			};

		}
	}
}


