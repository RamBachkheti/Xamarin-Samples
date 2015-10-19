using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace UsingDependencyService
{
    public class DetailAudioView : ContentPage
    {
        HomeView _view;
        public DetailAudioView(HomeView view)
        {
            _view = view;
            var playAudio = new Button
            {
                Text = "Play Audio",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            playAudio.Clicked += (sender, e) =>
            {
                DependencyService.Get<IPlayAudio>().PlayAudio();
            };
            Content = playAudio;
        }
    }
}
