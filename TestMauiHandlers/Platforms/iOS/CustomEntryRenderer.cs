using System;
using CoreGraphics;
using Foundation;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Controls.Platform;
using UIKit;
 

//[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace TestMauiHandlers.IOS
{
    [Preserve(AllMembers = true)]
    public class CustomEntryRenderer : EntryRenderer
    {
        #region Parent override

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
                return;
            Control.BorderStyle = UITextBorderStyle.None;
            UpdateBorderWidth();
            UpdateBorderColor();
            UpdateBorderRadius();
            UpdateLeftPadding();
            UpdateRightPadding();
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (this.Element == null)
                return;
            if (e.PropertyName == CustomEntry.BorderWidthProperty.PropertyName)
            {
                UpdateBorderWidth();
            }
            else if (e.PropertyName == CustomEntry.BorderColorProperty.PropertyName)
            {
                UpdateBorderColor();
            }
            else if (e.PropertyName == CustomEntry.BorderRadiusProperty.PropertyName)
            {
                UpdateBorderRadius();
            }
            else if (e.PropertyName == CustomEntry.LeftPaddingProperty.PropertyName)
            {
                UpdateLeftPadding();
            }
            else if (e.PropertyName == CustomEntry.RightPaddingProperty.PropertyName)
            {
                UpdateRightPadding();
            }
        }

        #endregion

        #region Utility methods

        private void UpdateBorderWidth()
        {
            var CustomEntry = this.Element as CustomEntry;
            this.Layer.BorderWidth = CustomEntry.BorderWidth;
        }

        private void UpdateBorderColor()
        {
            var CustomEntry = this.Element as CustomEntry;
            this.Layer.BorderColor = CustomEntry.BorderColor.ToUIColor().CGColor;
        }

        private void UpdateBorderRadius()
        {
            var CustomEntry = this.Element as CustomEntry;
            this.Layer.CornerRadius = (nfloat)CustomEntry.BorderRadius;
        }

        private void UpdateLeftPadding()
        {
            var CustomEntry = this.Element as CustomEntry;
            var leftPaddingView = new UIView(new CGRect(0, 0, CustomEntry.LeftPadding, 0));
            Control.LeftView = leftPaddingView;
            Control.LeftViewMode = UITextFieldViewMode.Always;
        }

        private void UpdateRightPadding()
        {
            var CustomEntry = this.Element as CustomEntry;
            var rightPaddingView = new UIView(new CGRect(0, 0, CustomEntry.RightPadding, 0));
            Control.RightView = rightPaddingView;
            Control.RightViewMode = UITextFieldViewMode.Always;
        }

        #endregion
    }
}