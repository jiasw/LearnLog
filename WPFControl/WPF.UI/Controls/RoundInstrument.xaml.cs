using Microsoft.Expression.Shapes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
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
using System.Windows.Shapes;

namespace WPF.UI.Controls
{
    /// <summary>
    /// PathControl.xaml 的交互逻辑
    /// </summary>
    public partial class RoundInstrument : UserControl
    {

        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(double), typeof(RoundInstrument), new PropertyMetadata(0.0, OnMinimumChanged));
        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }
        private static void OnMinimumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RoundInstrument control = d as RoundInstrument;
            control.drawTick();
        }

        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(double), typeof(RoundInstrument), new PropertyMetadata(180.0, OnMaximumChanged));
        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }
        private static void OnMaximumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RoundInstrument control = d as RoundInstrument;
            control.drawTick();
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(RoundInstrument), new PropertyMetadata(0.0, OnValueChanged));
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RoundInstrument control = d as RoundInstrument;
           control.setValue(control.Value);
        }

        public double StepValue
        {
            get { return (double)GetValue(StepValueProperty); }
            set { SetValue(StepValueProperty, value); }
        }
        public static readonly DependencyProperty StepValueProperty = DependencyProperty.Register("StepValue", typeof(double), typeof(RoundInstrument), new PropertyMetadata(10.0, OnStepValueChanged));
        private static void OnStepValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RoundInstrument control = d as RoundInstrument;
            control.drawTick();
        }



        /// <summary>
        /// 圆弧的总角度
        /// </summary>
        private double Totalangle = 270;

        private double startAngle = -135;


        public RoundInstrument()
        {
            InitializeComponent();
            drawTick();
            setValue(60);
            this.guideline.RenderTransform = new RotateTransform() { Angle = 45 };
        }


        private void drawTick()
        {

            if (this.tickcanvas == null) return;
            this.tickcanvas.Children.Clear();

            for (double i = 0; i <= (this.Maximum - this.Minimum); i++)
            {
                //添加刻度线
                Line lineScale = new Line();

                if (i % StepValue == 0)
                {
                    //注意Math.Cos和Math.Sin的参数是弧度，记得将角度转为弧度制
                    lineScale.X1 = 200 - 170 * Math.Cos(i * (Totalangle / (this.Maximum - this.Minimum)) * Math.PI / 180);
                    lineScale.Y1 = 200 - 170 * Math.Sin(i * (Totalangle / (this.Maximum - this.Minimum)) * Math.PI / 180);
                    lineScale.Stroke = new SolidColorBrush(Colors.White);
                    lineScale.StrokeThickness = 2;

                    //添加刻度值
                    TextBlock txtScale = new TextBlock();
                    txtScale.Text = (i + this.Minimum).ToString();
                    txtScale.Width = 34;
                    txtScale.TextAlignment = TextAlignment.Center;
                    txtScale.Foreground = new SolidColorBrush(Colors.White);
                    txtScale.RenderTransform = new RotateTransform() { Angle = 45, CenterX = 17, CenterY = 8 };
                    txtScale.FontSize = 18;

                    Canvas.SetLeft(txtScale, 200 - 155 * Math.Cos(i * (Totalangle / (this.Maximum - this.Minimum)) * Math.PI / 180) - 17);
                    Canvas.SetTop(txtScale, 200 - 155 * Math.Sin(i * (Totalangle / (this.Maximum - this.Minimum)) * Math.PI / 180) - 10);
                    this.tickcanvas.Children.Add(txtScale);
                }
                else
                {
                    lineScale.X1 = 200 - 180 * Math.Cos(i * (Totalangle / (this.Maximum - this.Minimum)) * Math.PI / 180);
                    lineScale.Y1 = 200 - 180 * Math.Sin(i * (Totalangle / (this.Maximum - this.Minimum)) * Math.PI / 180);
                    lineScale.Stroke = new SolidColorBrush(Colors.White);
                    lineScale.StrokeThickness = 1;
                    lineScale.Opacity = 0.5;
                }

                lineScale.X2 = 200 - 190 * Math.Cos(i * (Totalangle / (this.Maximum - this.Minimum)) * Math.PI / 180);
                lineScale.Y2 = 200 - 190 * Math.Sin(i * (Totalangle / (this.Maximum - this.Minimum)) * Math.PI / 180);
                this.tickcanvas.Children.Add(lineScale);
            }


        }


        private void setValue(double value)
        {
            
            if (guideline == null)
                return;
            double angle = (value - this.Minimum) * (Totalangle / (this.Maximum - this.Minimum));
            setProcess(angle + startAngle);
            
            DoubleAnimation animation = new DoubleAnimation();
            animation.To = angle+ startAngle;
            animation.Duration = new Duration(new System.TimeSpan(0, 0, 1));
            var ease = new CubicEase();
            ease.EasingMode = EasingMode.EaseInOut;
            animation.EasingFunction = ease;
            
            this.guideline.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, animation);
            
        }


        private void setProcess(double value)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.To = value;
            animation.Duration = new Duration(new System.TimeSpan(0, 0, 1));
            var ease = new CubicEase();
            ease.EasingMode = EasingMode.EaseOut;
            animation.EasingFunction = ease;
            txtValue.Text = value.ToString();
            arckd.BeginAnimation(Arc.StartAngleProperty, animation);
            this.guideline.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, animation);
        }


    }
}
