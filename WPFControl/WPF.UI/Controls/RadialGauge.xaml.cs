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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF.UI.Controls
{
    /// <summary>
    /// RadialGauge.xaml 的交互逻辑
    /// </summary>
    public partial class RadialGauge : UserControl
    {
        public RadialGauge()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 圆弧半径
        /// </summary>
        private double radius = 13;

        private double padding = 2;

        /// <summary>
        /// 圆弧角度
        /// </summary>
        private double totalAngle = 270;

        public double ArcStartPoint=> 0;

        public double ArcEndPoint => 360;


        private void DrawTicks()
        {
            double centerX = 200;
            double centerY = 200;
            double radius = 100;
            int tickCount = 10;
            double angleStep = 180.0 / tickCount;  // 每次刻度的角度

            for (int i = 0; i <= tickCount; i++)
            {
                double angle = i * angleStep;

                // 计算刻度线的起始和结束位置
                double startX = centerX + radius * Math.Cos(angle * Math.PI / 180);
                double startY = centerY + radius * Math.Sin(angle * Math.PI / 180);
                double endX = centerX + (radius + 10) * Math.Cos(angle * Math.PI / 180); // 刻度线长度为10
                double endY = centerY + (radius + 10) * Math.Sin(angle * Math.PI / 180);

                // 创建刻度线
                Line tick = new Line
                {
                    X1 = startX,
                    Y1 = startY,
                    X2 = endX,
                    Y2 = endY,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

            }
        }
    }
}
