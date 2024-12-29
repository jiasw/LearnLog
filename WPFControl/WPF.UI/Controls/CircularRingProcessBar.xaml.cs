using Microsoft.Expression.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF.UI.Controls
{
    /// <summary>
    /// CircularRingProcessBar.xaml 的交互逻辑
    /// </summary>
    public partial class CircularRingProcessBar : UserControl
    {

        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(double), typeof(CircularRingProcessBar), new PropertyMetadata(100.0));

        public double MinValue
        {
            get { return (double)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(double), typeof(CircularRingProcessBar), new PropertyMetadata(0.0));
 
        public double CurrentValue
        {
            get { return (double)GetValue(CurrentValueProperty); }
            set { SetValue(CurrentValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentValueProperty =
            DependencyProperty.Register("CurrentValue", typeof(double), typeof(CircularRingProcessBar), new PropertyMetadata(0.0));



        public CircularRingProcessBar()
        {
            InitializeComponent();
        }

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FontSizeProperty =
            DependencyProperty.Register("FontSize", typeof(double), typeof(CircularRingProcessBar), new PropertyMetadata(12.0));

        public double Value
        {   
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(CircularRingProcessBar), new PropertyMetadata(0.0, OnValueChanged));

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CircularRingProcessBar bar = d as CircularRingProcessBar;
            if (bar == null)
            {
                return;
            }
            double value = (double)e.NewValue;
            if (value < bar.MinValue)
            {
                value = bar.MinValue;
            }
            else if (value > bar.MaxValue)
            {
                value = bar.MaxValue;
            }
            bar.txtprocess.Text = value.ToString("P0");
            bar.setValuesAnimation(value);
        }

        private void setValuesAnimation(double value)
        {
            double angle = 360 * value/(MaxValue - MinValue);
            double currentAngle = 360 * (CurrentValue - MinValue) / (MaxValue - MinValue);
            double diffAngle = angle - currentAngle;
            double duration = 1000;
            DoubleAnimation animation = new DoubleAnimation(currentAngle, currentAngle + diffAngle, new Duration(TimeSpan.FromMilliseconds(duration)));
            animation.EasingFunction = new QuarticEase();
            animation.Completed += (s, e) =>
            {
                CurrentValue = value;
            };
            arcprocess.BeginAnimation(Arc.EndAngleProperty, animation);

        }



        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(CircularRingProcessBar), new PropertyMetadata(10.0));

        public Brush BackgroundStroke
        {
            get { return (Brush)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Stroke.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register("BackgroundStroke", typeof(Brush), typeof(CircularRingProcessBar), new PropertyMetadata(Brushes.Gray));

        public Brush ForegroundStroke
        {
            get { return (Brush)GetValue(ForegroundStrokeProperty); }
            set { SetValue(ForegroundStrokeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ForegroundStroke.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForegroundStrokeProperty =
            DependencyProperty.Register("ForegroundStroke", typeof(Brush), typeof(CircularRingProcessBar), new PropertyMetadata(Brushes.Red));

        public Brush TextBrush
        {
            get { return (Brush)GetValue(TextBrushProperty); }
            set { SetValue(TextBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextBrushProperty =
            DependencyProperty.Register("TextBrush", typeof(Brush), typeof(CircularRingProcessBar), new PropertyMetadata(Brushes.Black));

    }
}
