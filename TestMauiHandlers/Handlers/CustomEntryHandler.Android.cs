#if IOS || MACCATALYST
using PlatformView = Microsoft.Maui.Platform.MauiTextField;
#elif ANDROID
using PlatformView = AndroidX.AppCompat.Widget.AppCompatEditText;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Controls.TextBox;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID)
using PlatformView = System.Object;
#endif

using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Android.Text;
using Android.Text.Method;

namespace TestMauiHandlers.Handlers;

public partial class CustomEntryHandler : EntryHandler
{

    private const GravityFlags DefaultGravity = GravityFlags.CenterVertical;

    protected override void ConnectHandler(AppCompatEditText platformView)
    {

        // Perform any control setup here
        platformView.Gravity = DefaultGravity;

        //  this.Control.KeyListener = Android.Text.Method.DigitsKeyListener.GetInstance(Resources.Configuration.Locale, true, true);
        platformView.KeyListener = DigitsKeyListener.GetInstance(string.Format("1234567890{0}", ","));
        platformView.InputType = InputTypes.ClassNumber | InputTypes.NumberFlagDecimal;
        base.ConnectHandler(platformView);
    }

    protected override void DisconnectHandler(AppCompatEditText platformView)
    {
        // Perform any native view cleanup here

        platformView.Dispose();
        base.DisconnectHandler(platformView);
    }


    #region Utility methods


    public static void UpdatePadding(CustomEntryHandler handler, CustomEntry CustomEntry)
    {
        handler.PlatformView?.SetPadding((int)Platform.CurrentActivity.ToPixels(CustomEntry.LeftPadding), 0, (int)Platform.CurrentActivity.ToPixels(CustomEntry.RightPadding), 0);
    }

    public static void UpdateTextAlignment(CustomEntryHandler handler, CustomEntry customEntry)
    {
        var gravity = DefaultGravity;
        gravity |= customEntry.HorizontalTextAlignment switch
        {
            Microsoft.Maui.TextAlignment.Start => GravityFlags.Start,
            Microsoft.Maui.TextAlignment.Center => GravityFlags.CenterHorizontal,
            Microsoft.Maui.TextAlignment.End => GravityFlags.End,
            _ => throw new ArgumentOutOfRangeException()
        };
        handler.PlatformView.Gravity = gravity;
    }

    #endregion
}