using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.Expression.Shapes;

namespace DashboardDemo
{
    public class Dashboard : System.Windows.Controls.Control
    {
        public const string ArcName = "arckd";
        public const string ValueTxtName = "valueTxt";
        public const string CanvasName = "canvasPlate";
        public const string ZZRotateName = "rtPointer";

        private static double StartAngle = -135.5;

        static Dashboard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Dashboard), new FrameworkPropertyMetadata(typeof(Dashboard)));
        }

        Arc arckd;
        TextBlock valueTxt;
        Canvas canvasPlate;
        RotateTransform rtPointer;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (arckd == null)
                arckd = GetTemplateChild(ArcName) as Arc;
            if (valueTxt == null)
                valueTxt = GetTemplateChild(ValueTxtName) as TextBlock;
            if (canvasPlate == null)
                canvasPlate = GetTemplateChild(CanvasName) as Canvas;
            if (rtPointer == null)
                rtPointer = GetTemplateChild(ZZRotateName) as RotateTransform;
            DrawScale();
            DrawAngle();
            arckd.EndAngle = StartAngle + (-StartAngle * 2d) * ((double)Value / Maximum);
            valueTxt.Text = Value.ToString();
        }
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set
            {
                SetValue(ValueProperty, value);
            }
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(Dashboard),
                new PropertyMetadata(default(double), new PropertyChangedCallback(OnValuePropertyChanged)));
        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(double), typeof(Dashboard),
                new PropertyMetadata(double.NaN, new PropertyChangedCallback(OnPropertyChanged)));


        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(Dashboard),
                new PropertyMetadata(double.NaN, new PropertyChangedCallback(OnPropertyChanged)));

        public Brush PlateBackground
        {
            get { return (Brush)GetValue(PlateBackgroundProperty); }
            set { SetValue(PlateBackgroundProperty, value); }
        }
        public static readonly DependencyProperty PlateBackgroundProperty =
            DependencyProperty.Register("PlateBackground", typeof(Brush), typeof(Dashboard), null);


        public Brush PlateBorderBrush
        {
            get { return (Brush)GetValue(PlateBorderBrushProperty); }
            set { SetValue(PlateBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty PlateBorderBrushProperty =
            DependencyProperty.Register("PlateBorderBrush", typeof(Brush), typeof(Dashboard), null);


        public Thickness PlateBorderThickness
        {
            get { return (Thickness)GetValue(PlateBorderThicknessProperty); }
            set { SetValue(PlateBorderThicknessProperty, value); }
        }
        public static readonly DependencyProperty PlateBorderThicknessProperty =
            DependencyProperty.Register("PlateBorderThickness", typeof(Thickness), typeof(Dashboard), null);


        public static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as Dashboard).DrawScale();
        }

        public static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Dashboard dashboard = d as Dashboard;
            dashboard.DrawAngle();
            if (dashboard.arckd == null)
                return;
            dashboard.arckd.EndAngle = StartAngle + (-StartAngle * 2d) * ((double)dashboard.Value / dashboard.Maximum);
            dashboard.valueTxt.Text = dashboard.Value.ToString();
        }

        /// <summary>
        /// 画表盘的刻度
        /// </summary>
        private void DrawScale()
        {
            if (this.canvasPlate == null) return;
            this.canvasPlate.Children.Clear();

            for (double i = 0; i <= this.Maximum - this.Minimum; i++)
            {
                //添加刻度线
                Line lineScale = new Line();

                if (i % 10 == 0)
                {
                    //注意Math.Cos和Math.Sin的参数是弧度，记得将角度转为弧度制
                    lineScale.X1 = 200 - 170 * Math.Cos(i * (270 / (this.Maximum - this.Minimum)) * Math.PI / 180);
                    lineScale.Y1 = 200 - 170 * Math.Sin(i * (270 / (this.Maximum - this.Minimum)) * Math.PI / 180);
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

                    Canvas.SetLeft(txtScale, 200 - 155 * Math.Cos(i * (270 / (this.Maximum - this.Minimum)) * Math.PI / 180) - 17);
                    Canvas.SetTop(txtScale, 200 - 155 * Math.Sin(i * (270 / (this.Maximum - this.Minimum)) * Math.PI / 180) - 10);

                    this.canvasPlate.Children.Add(txtScale);
                }
                else
                {
                    lineScale.X1 = 200 - 180 * Math.Cos(i * (270 / (this.Maximum - this.Minimum)) * Math.PI / 180);
                    lineScale.Y1 = 200 - 180 * Math.Sin(i * (270 / (this.Maximum - this.Minimum)) * Math.PI / 180);
                    lineScale.Stroke = new SolidColorBrush(Colors.White);
                    lineScale.StrokeThickness = 1;
                    lineScale.Opacity = 0.5;
                }

                lineScale.X2 = 200 - 190 * Math.Cos(i * (270 / (this.Maximum - this.Minimum)) * Math.PI / 180);
                lineScale.Y2 = 200 - 190 * Math.Sin(i * (270 / (this.Maximum - this.Minimum)) * Math.PI / 180);
                this.canvasPlate.Children.Add(lineScale);
            }
        }

        private void DrawAngle()
        {
            if (rtPointer == null)
                return;
            double step = 270.0 / (this.Maximum - this.Minimum);
            DoubleAnimation da = new DoubleAnimation(this.Value * step - 45, new Duration(TimeSpan.FromMilliseconds(200)));
            this.rtPointer.BeginAnimation(RotateTransform.AngleProperty, da);
        }
    }
}
