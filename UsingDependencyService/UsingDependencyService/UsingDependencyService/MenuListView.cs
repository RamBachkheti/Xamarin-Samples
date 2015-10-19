using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UsingDependencyService
{
    public class MenuListView: ListView
    {
        public MenuListView()
        {
            List<MenuItem> data = new MenuListData();

            ItemsSource = data;

            VerticalOptions = LayoutOptions.FillAndExpand;
            BackgroundColor = Color.Transparent;

            var cell = new DataTemplate(typeof(ImageCell));
            cell.SetBinding(TextCell.TextProperty, "Title");
            cell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");

            ItemTemplate = cell;
        }
    }

    public class MenuListData: List<MenuItem>
    {
        public MenuListData()
        {
            this.Add(new MenuItem()
            {
                Title="Audio Demo",
                IconSource="audio.png",
                TargetType=typeof(AudioPage)
            });

            this.Add(new MenuItem()
            {
                Title = "Video Demo",
                IconSource = "audio.png",
                TargetType = typeof(AudioPage)

            });

            this.Add(new MenuItem()
            {
                Title = "Camera Demo",
                IconSource = "audio.png",
                TargetType = typeof(AudioPage)
            });

            this.Add(new MenuItem()
            {
                Title = "Video Camera Demo",
                IconSource = "audio.png",
                TargetType = typeof(AudioPage)
            });
        }
    }

    public class MenuItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Type TargetType { get; set; }
    }

    public class AudioPage:ContentPage
    {
         HomeView _view;
         public AudioPage()
         {

         }
         public AudioPage(HomeView view)
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
