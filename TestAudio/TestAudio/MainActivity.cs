using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;

namespace TestAudio
{
    [Activity(Label = "TestAudio", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button playButton = FindViewById<Button>(Resource.Id.MyPlay);
            Button stopButton = FindViewById<Button>(Resource.Id.MyStop);
            MediaPlayer _mediaPlayer;
            _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.test);
            stopButton.Enabled = false;
            playButton.Click += delegate
            {
                stopButton.Enabled = true;
                playButton.Enabled = false;
                if (!_mediaPlayer.IsPlaying)
                    _mediaPlayer.Start();
                
              //  button.Text = string.Format("{0} clicks!", count++); 
            
            };
            stopButton.Click += delegate
            {
                stopButton.Enabled = false;
                playButton.Enabled = true;
                if (_mediaPlayer.IsPlaying)
                      _mediaPlayer.Pause();

                //  button.Text = string.Format("{0} clicks!", count++); 

            };
        }
    }
}

