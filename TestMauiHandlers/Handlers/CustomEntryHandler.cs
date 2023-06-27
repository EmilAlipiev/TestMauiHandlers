#if IOS || MACCATALYST
using PlatformView = Microsoft.Maui.Platform.MauiTextField;
#elif ANDROID
using PlatformView = AndroidX.AppCompat.Widget.AppCompatEditText;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Controls.TextBox;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID)
using PlatformView = System.Object;
#endif

using Microsoft.Maui.Handlers;
 

namespace TestMauiHandlers.Handlers;

public partial class CustomEntryHandler
{
    public static PropertyMapper<CustomEntry, CustomEntryHandler> PropertyMapper = new PropertyMapper<CustomEntry, CustomEntryHandler>(EntryHandler.ViewMapper)
    {
#if __ANDROID__
      
        [nameof(CustomEntry.LeftPadding)] = UpdatePadding,
        [nameof(CustomEntry.RightPadding)] = UpdatePadding,
        [nameof(CustomEntry.HorizontalTextAlignment)] = UpdateTextAlignment,
#elif IOS || MACCATALYST
        [nameof(CustomEntry.BorderWidth)] = UpdateBorderWidth,
        [nameof(CustomEntry.BorderColor)] = UpdateBorderColor,
        [nameof(CustomEntry.BorderRadius)] = UpdateBorderRadius,
        [nameof(CustomEntry.LeftPadding)] = UpdateLeftPadding,
        [nameof(CustomEntry.RightPadding)] = UpdateRightPadding,
#endif
    };

    public CustomEntryHandler() : base(PropertyMapper)
    {
    }
}