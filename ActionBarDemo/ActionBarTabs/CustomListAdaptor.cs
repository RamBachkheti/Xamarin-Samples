using System;
using Android.Views;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android.Text;

namespace com.xamarin.example.actionbar.tabs
{
	public class CusotmListAdapter : BaseAdapter<User>
	{
		Activity context;
		List<User> list;

		public CusotmListAdapter (Activity _context, List<User> _list):base()
		{
			this.context = _context;
			this.list = _list;
		}

		public override int Count {
			get { return list.Count; }
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override User this[int index] {
			get { return list [index]; }
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			View view = convertView; 

			// re-use an existing view, if one is available
			// otherwise create a new one
			if (view == null)
				view = context.LayoutInflater.Inflate (Resource.Layout.ListItemRow, parent, false);

			TextView txtName = view.FindViewById<TextView> (Resource.Id.Name);
			txtName.Text = this [position].Name;

			TextView txtEmail = view.FindViewById<TextView> (Resource.Id.Email);
			txtEmail.Text = this [position].Email;

			TextView txtAddressLine1 = view.FindViewById<TextView> (Resource.Id.AddressLine1);
			txtAddressLine1.Text = this [position].AddressLine1;

			TextView txtAddressLine2 = view.FindViewById<TextView> (Resource.Id.AddressLine2);
			txtAddressLine2.Text = this [position].AddressLine2;

			TextView txtAddressLine3 = view.FindViewById<TextView> (Resource.Id.AddressLine3);
			txtAddressLine3.Text = this [position].AddressLine3;

			TextView txtDescription = view.FindViewById<TextView> (Resource.Id.Description);
			txtDescription.TextFormatted = Html.FromHtml (this [position].description);

			return view;
		}
	}
}