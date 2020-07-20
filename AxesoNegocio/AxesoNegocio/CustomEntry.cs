using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AxesoNegocio
{
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(nameof(CornerRadius),
            typeof(double), typeof(CustomEntry), GetDoubleCorner());
        public double CornerRadius
        {
            get => (double)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        private static double GetDoubleCorner()
        {
            //Device.OnPlatform<double>(6, 7, 7)
            double cornereturn;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    cornereturn = 6;
                    break;

                default:
                    cornereturn = 7;
                    break;
            }
            return cornereturn;
        }

        public static BindableProperty BorderThicknessProperty =
            BindableProperty.Create(nameof(BorderThickness), typeof(int), typeof(CustomEntry), 1);
        public int BorderThickness
        {
            get => (int)GetValue(BorderThicknessProperty);
            set => SetValue(BorderThicknessProperty, value);
        }

        public static BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(CustomEntry), new Thickness(5));
        public Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }

        public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CustomEntry), Color.Transparent);
        // Gets or sets BorderColor value
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        

        public static readonly BindableProperty BorderWidthProperty =
        BindableProperty.Create(nameof(BorderWidth), typeof(int),
            typeof(CustomEntry), GetIntBorder());

        private static int GetIntBorder()
        {
            //Device.OnPlatform<int>(1, 2, 2)
            int bordereturn;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    bordereturn = 1;
                    break;

                default:
                    bordereturn = 2;
                    break;
            }
            return bordereturn;
        }

        // Gets or sets BorderWidth value
        public int BorderWidth
        {
            get => (int)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }
        

        // Gets or sets CornerRadius value
        
        public static readonly BindableProperty IsCurvedCornersEnabledProperty =
        BindableProperty.Create(nameof(IsCurvedCornersEnabled),
            typeof(bool), typeof(CustomEntry), true);
        // Gets or sets IsCurvedCornersEnabled value
        public bool IsCurvedCornersEnabled
        {
            get => (bool)GetValue(IsCurvedCornersEnabledProperty);
            set => SetValue(IsCurvedCornersEnabledProperty, value);
        }
    }
}
