using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

using UIKit;
using Foundation;
using CoreAnimation;
using CoreGraphics;

namespace XamarinStore.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		public static AppDelegate Shared;

		UIWindow window;
		UINavigationController navigation;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Shared = this;
			FileCache.SaveLocation = System.IO.Directory.GetParent (Environment.GetFolderPath (Environment.SpecialFolder.Personal)).ToString () + "/tmp";

			UIApplication.SharedApplication.SetStatusBarStyle (UIStatusBarStyle.LightContent, false);

			window = new UIWindow (UIScreen.MainScreen.Bounds);
			UINavigationBar.Appearance.SetTitleTextAttributes (new UITextAttributes {
				TextColor = UIColor.White
			});

			var productVc = new ProductListViewController ();
			productVc.ProductTapped += ShowProductDetail;
			navigation = new UINavigationController (productVc);

			navigation.NavigationBar.TintColor = UIColor.White;
			navigation.NavigationBar.BarTintColor = Color.Blue;

			window.RootViewController = navigation;
			window.MakeKeyAndVisible ();
			return true;
		}

		public void ShowProductDetail (Product product)
		{
			var productDetails = new ProductDetailViewController (product);
			productDetails.AddToBasket += p => {
				WebService.Shared.CurrentOrder.Add (p);
				UpdateProductsCount();
			};
			navigation.PushViewController (productDetails, true);
		}
		public void ShowBasket ()
		{
			var basketVc = new BasketViewController (WebService.Shared.CurrentOrder);
			basketVc.Checkout += (object sender, EventArgs e) => ShowLogin ();
			navigation.PushViewController (basketVc, true);
		}

		public void ShowLogin ()
		{
			var loginVc = new LoginViewController ();
			loginVc.LoginSucceeded += () => ShowAddress ();
			navigation.PushViewController (loginVc, true);
		}

		public void ShowAddress ()
		{
			var addreesVc = new ShippingAddressViewController (WebService.Shared.CurrentUser);
			addreesVc.ShippingComplete += (object sender, EventArgs e) => ProccessOrder ();
			navigation.PushViewController (addreesVc, true);
		}

		public void ProccessOrder()
		{
			var processing = new ProcessingViewController (WebService.Shared.CurrentUser);
			processing.OrderPlaced += (object sender, EventArgs e) => {
				OrderCompleted ();
			};
			navigation.PresentViewController (new UINavigationController(processing), true, null);
		}

		public void OrderCompleted ()
		{
			navigation.PopToRootViewController (true);
		}
		BasketButton button;
		public UIBarButtonItem CreateBasketButton ()
		{
			if (button == null) {
				button = new BasketButton () {
					Frame = new RectangleF (0, 0, 44, 44),
				};
				button.TouchUpInside += (sender, args) => ShowBasket ();
			}
			button.ItemsCount = WebService.Shared.CurrentOrder.Products.Count;
			return new UIBarButtonItem (button);
		}
		public void UpdateProductsCount()
		{
			button.UpdateItemsCount(WebService.Shared.CurrentOrder.Products.Count);
		}
	}
}
