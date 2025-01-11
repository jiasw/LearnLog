using System;
using System.Collections.Generic;
using System.IO;
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
    /// WaveControl.xaml 的交互逻辑
    /// </summary>
    public partial class WaveControl : UserControl
    {
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(WaveControl), new PropertyMetadata(0.0, OnValueChanged)
                , new ValidateValueCallback(ValidateLimitedValue));
        private static bool ValidateLimitedValue(object value)
        {
            double doubleValue = (double)value;
            // 限制值在 0 到 100 之间
            return doubleValue >= 0 && doubleValue <= 100;
        }
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WaveControl control = d as WaveControl;
            control.SetWaveValue((double)e.NewValue);
        }

        public WaveControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            BindAnimation();
        }

        private double minHeight = 0;
        private double maxHeight = 200;
        private void SetWaveValue(double value)
        {
            double process = value   /100;
            waveText.Text = value.ToString() ;
            double height = (maxHeight + minHeight)-(maxHeight - minHeight) * process ;
            BindAnimationY(height);

        }

        private void BindAnimationY(double process)
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                To = process,
                Duration = TimeSpan.FromSeconds(0.5)
            };
            MyTranslateTransform.BeginAnimation(TranslateTransform.YProperty, animation);
        }

        private void BindAnimation()
        {
            // 创建一个 DoubleAnimation
            ThicknessAnimation animation = new ThicknessAnimation
            {
                From = new Thickness(10, 10, 0, 0), 
                To = new Thickness(-500, 10, 0, 0), 
                Duration = TimeSpan.FromSeconds(1.5), 
                RepeatBehavior = RepeatBehavior.Forever, 
            };
            wavePath.BeginAnimation(MarginProperty, animation);
        }

    }
}
