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
    /// ThermometerProcessBar.xaml 的交互逻辑
    /// </summary>
    public partial class ThermometerProcessBar : UserControl
    {

        private double leftTickStartX=46;
        private double rightTickStartX= 54;
        private double tickStartY = 68;
        private double longTickWidth = 5;
        private double normalTickWidth = 2;
        private double tickStrokeThickness = 0.4;
        private double tickEndY = 10;
        

        public ThermometerProcessBar()
        {
            InitializeComponent(); renderTick();
        }


        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(double), typeof(ThermometerProcessBar), new PropertyMetadata(100.0));


        public double CurrentValue
        {
            get { return (double)GetValue(CurrentValueProperty); }
            set { SetValue(CurrentValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentValueProperty =
            DependencyProperty.Register("CurrentValue", typeof(double), typeof(ThermometerProcessBar), new PropertyMetadata(0.0,OnCurrentValueChanged));

        private static void OnCurrentValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ThermometerProcessBar thermometerProcessBar = d as ThermometerProcessBar;
            thermometerProcessBar.renderValue((double)e.NewValue);
        }

        public double MinValue
        {
            get { return (double)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(double), typeof(ThermometerProcessBar), new PropertyMetadata(0.0));

        /// <summary>
        /// 每个刻度代表的数值
        /// </summary>
        public double TickInterval
        {
            get { return (double)GetValue(TickIntervalProperty); }
            set { SetValue(TickIntervalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TickInterval.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TickIntervalProperty =
            DependencyProperty.Register("TickInterval", typeof(double), typeof(ThermometerProcessBar), new PropertyMetadata(5.0));
        /// <summary>
        /// 每个长刻度之间的间隔
        /// </summary>
        public int LongTickStep
        {
            get { return (int)GetValue(LongTickIntervalProperty); }
            set { SetValue(LongTickIntervalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LongTickInterval.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LongTickIntervalProperty =
            DependencyProperty.Register("LongTickStep", typeof(int), typeof(ThermometerProcessBar), new PropertyMetadata(5));

        

        /// <summary>
        /// 渲染刻度
        /// </summary>
        private void renderTick()
        {
            double intervalCount = (MaxValue - MinValue) / TickInterval;
            double tickCount = intervalCount + 1;
            double normalTickHeight =(tickStartY- tickEndY) / intervalCount;
            for (double i = 0; i < tickCount; i++)
            {
                double currentwidth = normalTickWidth;
                double currentopacity = 0.5;
                if (i % LongTickStep == 0)
                {
                    currentwidth= longTickWidth;
                    currentopacity=0.8;
                    TextBlock lefttext = new TextBlock();
                    lefttext.Text = (i * TickInterval + MinValue).ToString();
                    lefttext.FontSize = 5;
                    lefttext.Foreground = Brushes.Black;
                    lefttext.HorizontalAlignment = HorizontalAlignment.Right;
                    double lefttextwidth = lefttext.Text.Length*3;
                    Canvas.SetLeft(lefttext, leftTickStartX - currentwidth- lefttextwidth-1);
                    Canvas.SetTop(lefttext, tickStartY - i * normalTickHeight-3);
                    bgCanvas.Children.Add(lefttext);
                    TextBlock righttext = new TextBlock();
                    righttext.Text = (i * TickInterval + MinValue).ToString();
                    righttext.FontSize = 5;
                    righttext.Foreground = Brushes.Black;
                    righttext.HorizontalAlignment = HorizontalAlignment.Left;
                    double righttextwidth = righttext.Text.Length * 3;
                    Canvas.SetLeft(righttext, rightTickStartX  + 6);
                    Canvas.SetTop(righttext, tickStartY - i * normalTickHeight-3);
                    bgCanvas.Children.Add(righttext);
                }
                double currenty= tickStartY - i * normalTickHeight;
                Line leftline = new Line();
                leftline.Opacity = currentopacity;
                leftline.StrokeThickness = tickStrokeThickness;
                leftline.Stroke = Brushes.Black;
                leftline.X1= leftTickStartX;
                leftline.X2 = leftTickStartX - currentwidth;
                leftline.Y1 = leftline.Y2= tickStartY - i * normalTickHeight;
                
                Line rightline = new Line();
                rightline.Opacity = currentopacity;
                rightline.StrokeThickness = tickStrokeThickness;
                rightline.Stroke = Brushes.Black;
                rightline.X1 = rightTickStartX;
                rightline.X2 = rightTickStartX + currentwidth;
                rightline.Y1 = rightline.Y2 = tickStartY - i * normalTickHeight;

                bgCanvas.Children.Add(leftline);
                bgCanvas.Children.Add(rightline);
            

            }


        }


        private void renderValue(double value)
        {
            double renderValue = tickStartY - (value - MinValue) / (MaxValue - MinValue) * (tickStartY - tickEndY);
            DoubleAnimation animation = new DoubleAnimation();
            animation.To = renderValue;
            animation.Duration = new Duration(new System.TimeSpan(0, 0, 1));
            var ease = new CubicEase();
            ease.EasingMode = EasingMode.EaseOut;
            animation.EasingFunction = ease;
            lineProcess.BeginAnimation(Line.Y1Property, animation);
        }

    }
}
