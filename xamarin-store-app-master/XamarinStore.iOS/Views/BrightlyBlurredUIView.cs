using System;
using UIKit;
using CoreAnimation;

namespace XamarinStore
{
	public class BrightlyBlurredUIView: UIView
	{
		CALayer blurLayer,accentLayer;
		UIView accentView;
		UIToolbar toolbar;
		public BrightlyBlurredUIView()
		{
			toolbar = new UIToolbar {
				Opaque = true,
			};
			this.Layer.AddSublayer(blurLayer = toolbar.Layer);

			accentView = new UIView {
				BackgroundColor = this.TintColor,
				Alpha = .7f,
				Opaque = false
			};

			blurLayer.InsertSublayer(accentLayer = accentView.Layer,1);
			this.Layer.MasksToBounds = true;
			this.BackgroundColor = UIColor.Clear;
		}
		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			var bounds = Bounds;
			accentLayer.Frame = blurLayer.Frame = bounds;
		}
		public float AccentColorIntensity
		{
			get{ return (float)accentView.Alpha; }
			set{ accentView.Alpha = value; }
		}
		public override UIColor TintColor {
			get {
				return base.TintColor;
			}
			set {
				base.TintColor = toolbar.BarTintColor = accentView.BackgroundColor = value;
			}
		}
	
	}
}
