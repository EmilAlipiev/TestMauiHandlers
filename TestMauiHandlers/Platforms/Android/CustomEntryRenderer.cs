 

using System.ComponentModel;
using Android.Content;
using Android.Text;
using Android.Text.Method;
using Android.Views;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Platform;


//[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace TestMauiHandlers.Android
{
    
    public class CustomEntryRenderer : EntryRenderer
    {
        #region Private fields and properties

        
        private const GravityFlags DefaultGravity = GravityFlags.CenterVertical;

        #endregion

        #region Parent override

        public CustomEntryRenderer(Context context)
                  : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || this.Element == null)
                return;
            Control.Gravity = DefaultGravity;
            var CustomEntry = Element as CustomEntry;
         
            UpdatePadding(CustomEntry);
            UpdateTextAlighnment(CustomEntry);
            //  this.Control.KeyListener = Android.Text.Method.DigitsKeyListener.GetInstance(Resources.Configuration.Locale, true, true);
            this.Control.KeyListener =  DigitsKeyListener.GetInstance(string.Format("1234567890{0}", ","));
            this.Control.InputType = InputTypes.ClassNumber | InputTypes.NumberFlagDecimal;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Element == null)
                return;
            var CustomEntry = Element as CustomEntry;
            if (e.PropertyName == CustomEntry.BorderWidthProperty.PropertyName ||
                e.PropertyName == CustomEntry.BorderColorProperty.PropertyName ||
                e.PropertyName == CustomEntry.BorderRadiusProperty.PropertyName ||
                e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
            {
              //  UpdateBackground(CustomEntry);
            }
            else if (e.PropertyName == CustomEntry.LeftPaddingProperty.PropertyName ||
                e.PropertyName == CustomEntry.RightPaddingProperty.PropertyName)
            {
                UpdatePadding(CustomEntry);
            }
            else if (e.PropertyName == Entry.HorizontalTextAlignmentProperty.PropertyName)
            {
                UpdateTextAlighnment(CustomEntry);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            
        }

        #endregion

        #region Utility methods

 

        private void UpdatePadding(CustomEntry CustomEntry)
        {
            Control.SetPadding((int)Context.ToPixels(CustomEntry.LeftPadding), 0,
                (int)Context.ToPixels(CustomEntry.RightPadding), 0);
        }

        private void UpdateTextAlighnment(CustomEntry CustomEntry)
        {
            var gravity = DefaultGravity;
            switch (CustomEntry.HorizontalTextAlignment)
            {
                case Microsoft.Maui.TextAlignment.Start:
                    gravity |= GravityFlags.Start;
                    break;
                case Microsoft.Maui.TextAlignment.Center:
                    gravity |= GravityFlags.CenterHorizontal;
                    break;
                case Microsoft.Maui.TextAlignment.End:
                    gravity |= GravityFlags.End;
                    break;
            }
            Control.Gravity = gravity;
        }

        #endregion
    }
}