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
    /// BezierDemo.xaml 的交互逻辑
    /// </summary>
    public partial class BezierDemo : UserControl
    {
        private double _waveOffset;
        public BezierDemo()
        {
            InitializeComponent();
           
        }

        private void StartWaveAnimation()
        {
            DoubleAnimation waveAnimation = new DoubleAnimation
            {
                From = 0,
                To = 2 * Math.PI,
                Duration = new Duration(TimeSpan.FromSeconds(2)),
                RepeatBehavior = RepeatBehavior.Forever,
                EasingFunction = new SineEase { EasingMode = EasingMode.EaseInOut }
            };

            waveAnimation.CurrentTimeInvalidated += (s, e) => UpdateWave();

            //BezierSegment.BeginAnimation(BezierSegment.Point1Property, waveAnimation);
        }


        private void Test()
        {
            while (true)
            {
                UpdateWave();
                System.Threading.Thread.Sleep(1000 / 60);
            }
        }

        private void UpdateWave()
        {
            _waveOffset += 0.1;

            // 根据波动情况更新贝塞尔曲线的控制点

            beizerSegment.Dispatcher.BeginInvoke(new Action(() =>
            {
                var pathFigure = WavePath.Data as PathGeometry;
                if (pathFigure != null)
                {
                    pathFigure.Figures[0].StartPoint = new Point(0, 200 + Math.Sin(_waveOffset) * 20);
                    beizerSegment.Point1 = new Point(150, 100 + Math.Sin(_waveOffset) * 20);
                    beizerSegment.Point2 = new Point(250, 300 + Math.Sin(_waveOffset) * 20);
                    beizerSegment.Point3 = new Point(400, 200 + Math.Sin(_waveOffset) * 20);
                }
            }));
            //if (beizerSegment != null)
            //{
            //    beizerSegment.Point1 = new Point(150, 100 + Math.Sin(_waveOffset) * 20);
            //    beizerSegment.Point2 = new Point(250, 300 + Math.Sin(_waveOffset) * 20);
            //    beizerSegment.Point3 = new Point(400, 200 + Math.Sin(_waveOffset) * 20);
            //}

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Run(Test);
        }
    }
}
