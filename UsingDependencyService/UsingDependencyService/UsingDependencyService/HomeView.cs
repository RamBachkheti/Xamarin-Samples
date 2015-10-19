using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace UsingDependencyService
{
    public class HomeView : MasterDetailPage
    {
        /*public HomeView()
        {
            Detail = new NavigationPage(new DetailAudioView(this));
            Master = new MainPage();
        }*/

        public HomeView()
        {
            var menuPage = new MenuPage();
            menuPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MenuItem);

            Master = menuPage;
            Detail = new NavigationPage(new AudioPage(this));
        }

        void NavigateTo(MenuItem menu)
        {
            Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);
            Detail = new NavigationPage(displayPage);

            IsPresented = false;
        }
    }
}
