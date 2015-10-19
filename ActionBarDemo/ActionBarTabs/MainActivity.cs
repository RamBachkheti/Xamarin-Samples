using Android.App;
using Android.OS;
using Android.Util;

namespace com.xamarin.example.actionbar.tabs
{
    [Activity(Label = "ITech Sample App", MainLauncher = true, Icon = "@drawable/ic_appLauncher")]
    public class MainActivity : Activity
    {
        static readonly string Tag = "";

        Fragment[] _fragments;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            SetContentView(Resource.Layout.Main);

            _fragments = new Fragment[]
                         {  				
						     new DealFragment(),
							 new CertificatesFragment(),
							 new GiftCardFragment(),
							 new CartFragment(),
							 new AccountFragment()
                         };

            AddTabToActionBar(Resource.String.deals_tab_label, Resource.Drawable.ic_dollarBlue);
			AddTabToActionBar(Resource.String.certificates_tab_label, Resource.Drawable.ic_certificateBlue);
			AddTabToActionBar(Resource.String.giftCard_tab_label, Resource.Drawable.ic_giftCard);
			AddTabToActionBar(Resource.String.card_tab_label, Resource.Drawable.ic_cartBlue);
			AddTabToActionBar(Resource.String.account_tab_label, Resource.Drawable.ic_userInfo1);
        }

        void AddTabToActionBar(int labelResourceId, int iconResourceId)
        {
            ActionBar.Tab tab = ActionBar.NewTab()
                                         .SetText(labelResourceId)
                                         .SetIcon(iconResourceId);
            tab.TabSelected += TabOnTabSelected;
            ActionBar.AddTab(tab);
        }

        void TabOnTabSelected(object sender, ActionBar.TabEventArgs tabEventArgs)
        {
            ActionBar.Tab tab = (ActionBar.Tab)sender;
            Log.Debug(Tag, "The tab {0} has been selected.", tab.Text);
            Fragment frag = _fragments[tab.Position];
            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
        }
    }
}
