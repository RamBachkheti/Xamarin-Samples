using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

using UIKit;
using CoreGraphics;

namespace XamarinStore
{
	public class StringUIPicker : UIPickerView
	{
		public event EventHandler SelectedItemChanged;

		public StringUIPicker ()
		{
		}

		string[] items;

		public IEnumerable<string> Items {
			get{ return items; }
			set { 
				items = value.ToArray ();
				Model = new PickerModel {
					Items = items,
					Parent = this,
				};
			}
		}

		int currentIndex;

		public int SelectedIndex {
			get{ return currentIndex; }
			set {
				if (currentIndex == value)
					return;
				currentIndex = value;
				this.Select (currentIndex, 0, true);
				if (SelectedItemChanged != null)
					SelectedItemChanged (this, EventArgs.Empty);
			}
		}

		public string SelectedItem {
			get { 
				return items.Length <= currentIndex ? "" : items [currentIndex];
			}
			set {
				if (!items.Contains (value))
					return;
				currentIndex = Array.IndexOf (items, value);
			}
		}

		UIView actionSheet;

		public void ShowPicker ()
		{
			actionSheet = new UIView () {
				BackgroundColor = UIColor.Clear
			};

			UIView parentView = UIApplication.SharedApplication.KeyWindow.RootViewController.View;

			// Creates a transparent grey background who catches the touch actions (and add more style). 
			UIView dimBackgroundView = new UIView (parentView.Bounds) {
				BackgroundColor = UIColor.Gray.ColorWithAlpha (0.5f)
			};

			const float titleBarHeight = 44;
			var actionSheetSize = new SizeF ((float)parentView.Frame.Width, (float)this.Frame.Height + titleBarHeight);
			var actionSheetFrameHidden = new CGRect (0, parentView.Frame.Height, actionSheetSize.Width, actionSheetSize.Height);
			var actionSheetFrameDisplayed = new CGRect (0, parentView.Frame.Height - actionSheetSize.Height, actionSheetSize.Width, actionSheetSize.Height);

			// Hide the action sheet before we animate it so it comes from the bottom.
			actionSheet.Frame = actionSheetFrameHidden;

			this.Frame = new RectangleF (0, 1, actionSheetSize.Width, actionSheetSize.Height - titleBarHeight);

			var toolbarPicker = new UIToolbar (new CGRect (0, 0, actionSheet.Frame.Width, titleBarHeight)) {
				ClipsToBounds = true,
				Items = new UIBarButtonItem[] {
					new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace), 
					new UIBarButtonItem (UIBarButtonSystemItem.Done, (sender, args) => {
						UIView.Animate (.25, 
							() => {
								actionSheet.Frame = actionSheetFrameHidden;
							},
							() => {
								dimBackgroundView.RemoveFromSuperview ();
								actionSheet.RemoveFromSuperview ();
							});
					})
				}
			};

			// Creates a blur background using the toolbar trick.
			var toolbarBg = new UIToolbar (new CGRect (0, 0, actionSheet.Frame.Width, actionSheet.Frame.Height)) {
				ClipsToBounds = true
			};

			actionSheet.AddSubviews (new UIView[] { toolbarBg, this, toolbarPicker });

			parentView.AddSubviews (new UIView[] { dimBackgroundView, actionSheet });

			parentView.BringSubviewToFront (actionSheet);

			UIView.Animate (.25, () => {
				actionSheet.Frame = actionSheetFrameDisplayed;
			});
		}

		class PickerModel : UIPickerViewModel
		{
			public StringUIPicker Parent { get; set; }

			public string[] Items = new string[0];

			public override nint GetComponentCount (UIPickerView picker)
			{
				return 1;
			}

			public override nint GetRowsInComponent (UIPickerView picker, nint component)
			{
				return Items.Length;
			}

			public override string GetTitle (UIPickerView picker, nint row, nint component)
			{
				return Items [row];
			}

			public override void Selected (UIPickerView picker, nint row, nint component)
			{
				if (Parent != null)
					Parent.SelectedIndex = (int)row;
			}

		}

	}
}

