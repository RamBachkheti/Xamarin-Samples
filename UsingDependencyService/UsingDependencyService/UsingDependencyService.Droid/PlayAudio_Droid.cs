using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;
using Xamarin.Forms;
using UsingDependencyService.Droid;

[assembly: Dependency(typeof(PlayAudio_Droid))]

namespace UsingDependencyService.Droid
{
	public class PlayAudio_Droid : Java.Lang.Object, IPlayAudio
	{
		MediaPlayer _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.test);
	   
		 string audioPath;

		public PlayAudio_Droid ()
		{
				
		}

		public void PlayAudio()
		{
			 if (!_mediaPlayer.IsPlaying)
					_mediaPlayer.Start();
		}
	}
}