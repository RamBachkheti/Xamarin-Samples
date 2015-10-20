using System;
using UIKit;

namespace XamarinStore
{
	public class SpinnerCell : CustomViewCell
	{
		public SpinnerCell (): base(CreateView())
		{
		}
		static UIActivityIndicatorView CreateView()
		{
			var indicator = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.Gray);
			indicator.StartAnimating ();
			return indicator;
		}
	}
}

