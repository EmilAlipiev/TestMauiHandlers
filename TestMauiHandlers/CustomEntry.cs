using System;

 

namespace TestMauiHandlers
{
 
    public class CustomEntry : Entry
    {
        public bool IsNumeric { get; set; }
        public bool IsDouble { get; set; } = true;

        public int MaxDecimalDigits { get; set; }
        #region Constructors

        public CustomEntry()
            : base()
        {
            MaxDecimalDigits = 2;
            IsNumeric = true;
            IsDouble = true;
            Keyboard = Keyboard.Numeric;
            Text = "this default text";
            
        }

        #endregion

        #region Properties
        public static readonly BindableProperty FormatStringValueProperty = BindableProperty.Create("FormatString", typeof(string), typeof(CustomEntry),
             defaultValue: string.Empty, defaultBindingMode: BindingMode.TwoWay);

        public string FormatString
        {
            get => (string)GetValue(FormatStringValueProperty);
            set => SetValue(FormatStringValueProperty, value);
        }

        public static readonly BindableProperty MaxValueProperty = BindableProperty.Create("MaxValue", typeof(double?), typeof(CustomEntry), defaultValue: null, defaultBindingMode: BindingMode.TwoWay);

        public double? MaxValue
        {
            get => (double?)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }


        public static readonly BindableProperty MinValueProperty = BindableProperty.Create("MinValue", typeof(double?), typeof(CustomEntry), defaultValue: 0.0, defaultBindingMode: BindingMode.TwoWay);

        public double? MinValue
        {
            get => (double?)GetValue(MinValueProperty);
            set => SetValue(MinValueProperty, value);
        }

        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create("MaxLength", typeof(int?), typeof(CustomEntry), defaultValue: null, defaultBindingMode: BindingMode.TwoWay);

        public int? MaxLength
        {
            get => (int?)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
        }
        public static BindableProperty BorderColorProperty = BindableProperty.Create("BorderColor", typeof(Color), typeof(CustomEntry), defaultValue: Colors.Transparent);

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }


        public static BindableProperty BorderWidthProperty = BindableProperty.Create("BorderWidth", typeof(float), typeof(CustomEntry), defaultValue: 0.0f);

        public float BorderWidth
        {
            get => (float)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }

        public static BindableProperty BorderRadiusProperty = BindableProperty.Create("BorderRadius", typeof(float), typeof(CustomEntry), defaultValue: 0.0f);

        public float BorderRadius
        {
            get => (float)GetValue(BorderRadiusProperty);
            set => SetValue(BorderRadiusProperty, value);
        }

        public static BindableProperty LeftPaddingProperty = BindableProperty.Create("LeftPadding", typeof(int), typeof(CustomEntry), defaultValue: 5);

        public int LeftPadding
        {
            get => (int)GetValue(LeftPaddingProperty);
            set => SetValue(LeftPaddingProperty, value);
        }

        public static BindableProperty RightPaddingProperty = BindableProperty.Create("RightPadding", typeof(int), typeof(CustomEntry), defaultValue: 5);

        public int RightPadding
        {
            get => (int)GetValue(RightPaddingProperty);
            set => SetValue(RightPaddingProperty, value);
        }

   

        #endregion
    }

}
