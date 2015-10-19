using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using System;
using Android.Text;

namespace com.xamarin.example.actionbar.tabs
{   
	public class DealFragment : Fragment
	{
		public DealFragment ()
		{			
		}
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			RetainInstance = true;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.empty_fragment, null);
			view.FindViewById<TextView>(Resource.Id.textView1).SetText(Resource.String.deals_tab_label);
			return view;
		}
	}

	public class CertificatesFragment : Fragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.empty_fragment, null);
			view.FindViewById<TextView>(Resource.Id.textView1).SetText(Resource.String.certificates_tab_label);
			return view;
		}
	}

	public class GiftCardFragment : Fragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.empty_fragment, null);
			view.FindViewById<TextView>(Resource.Id.textView1).SetText(Resource.String.giftCard_tab_label);
			return view;
		}
	}

	public class CartFragment : Fragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.empty_fragment, null);
			view.FindViewById<TextView>(Resource.Id.textView1).SetText(Resource.String.card_tab_label);
			return view;
		}
	}

	public class AccountFragment : Fragment
	{
		public ListView _listView;
		public TextView _tvSignOut;
		public List<User> _dataList=new List<User>();

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate (Resource.Layout.simple_fragment, null);
			view.FindViewById<TextView>(Resource.Id.textView1).SetText(Resource.String.account_tab_label);
			_tvSignOut=view.FindViewById<TextView>(Resource.Id.SignOut);
			_listView = view.FindViewById<ListView> (Resource.Id.ListView);

			if(_dataList.Count ==0)
			_dataList.Add (new User (){Name="Matt Smith", 
									   Email = "test@email.com", 
									   AddressLine1="1234 Easy St",
									   AddressLine2="Suit 51 NW",
				 					   AddressLine3="Chicago IL 60600",
					description ="To update your user profile please visit <font color='#0081c6'>www.yahoo.com</font> and go to MyProfile."
				});
			
			  CusotmListAdapter objAdaptor = new CusotmListAdapter(this.Activity, _dataList);
			_listView.Adapter = objAdaptor;

			_tvSignOut.Click += SignOutClick;
			return view;
		}

		private void SignOutClick(object sender,EventArgs e)
		{
			AlertDialog.Builder alert = new AlertDialog.Builder(this.Activity);
			alert.SetTitle ("Are you sure you want to Sign Out?");

			alert.SetPositiveButton ("Cancel", (senderAlert, args) => {
			} );
			alert.SetNegativeButton ("Sign Out", (senderAlert, args) => {

			} );
			alert.Show();
		}
	}
}