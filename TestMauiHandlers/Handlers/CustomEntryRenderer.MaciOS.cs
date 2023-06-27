using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Controls.Platform;
using UIKit;
using CoreGraphics;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;


namespace TestMauiHandlers.Handlers;

 
public partial class CustomEntryHandler : EntryHandler
{
    #region Parent override

    // protected override MauiTextField CreatePlatformView() => new(VirtualView.Frame);

    protected override void ConnectHandler(MauiTextField platformView)
    {
        platformView.KeyboardType = UIKeyboardType.NumberPad;
        platformView.BorderStyle = UITextBorderStyle.None;
        base.ConnectHandler(platformView);
    }

    #endregion

    #region Utility methods

    public static void UpdateBorderWidth(CustomEntryHandler handler, CustomEntry customEntry)
    {
        handler.PlatformView.UpdateBorder(customEntry);
    }

    public static void UpdateBorderColor(CustomEntryHandler handler, CustomEntry customEntry)
    {
        handler.PlatformView.UpdateBorder(customEntry);
    }

    protected override void DisconnectHandler(MauiTextField platformView)
    {
        // Perform any native view cleanup here
        platformView.Dispose();
        base.DisconnectHandler(platformView);
    }

    public static void UpdateBorderRadius(CustomEntryHandler handler, CustomEntry customEntry)
    {
        //handler.PlatformView.UpdateBorder(customEntry);
    }

    public static void UpdateLeftPadding(CustomEntryHandler handler, CustomEntry customEntry)
    {
        var leftPaddingView = new UIView(new CGRect(0, 0, customEntry.LeftPadding, 0));
        handler.PlatformView.LeftView = leftPaddingView;
        handler.PlatformView.LeftViewMode = UITextFieldViewMode.Always;
    }

    public static void UpdateRightPadding(CustomEntryHandler handler, CustomEntry customEntry)
    {
        var rightPaddingView = new UIView(new CGRect(0, 0, customEntry.RightPadding, 0));
        handler.PlatformView.RightView = rightPaddingView;
        handler.PlatformView.RightViewMode = UITextFieldViewMode.Always;
    }

    #endregion
}