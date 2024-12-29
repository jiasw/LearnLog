using System.Text;
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
using WPF.UI.Controls;

namespace WPF.UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       

        /// <summary>
        /// UI变化
        /// </summary>
        /// <param name="bState"></param>
        private void StartChange(bool bState)
        {
            if (bState)
                btnStart.Content = "停止";
            else
                btnStart.Content = "开始";
        }

        private void StartAnimation()
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 1;
            animation.Duration = new Duration(new System.TimeSpan(0, 0, 8));
            //circleProgressBar.BeginAnimation(CircularProgressBar.CurrentValueProperty, animation);
        }

        /// <summary>
        /// 缓动动画
        /// </summary>
        private void StartEaseAnimation()
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 1;
            animation.Duration = new Duration(new System.TimeSpan(0, 0, 8));
            var ease = new CubicEase();
            ease.EasingMode = EasingMode.EaseOut;
            animation.EasingFunction =ease;
            
            //circleProgressBar.BeginAnimation(CircularProgressBar.CurrentValueProperty, animation);
        }

        private void keyFrameAnimation_Completed()
        {
            DoubleAnimationUsingKeyFrames animation = new DoubleAnimationUsingKeyFrames();
            animation.Duration = new Duration(new System.TimeSpan(0, 0, 8));
            animation.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.FromTimeSpan(new System.TimeSpan(0, 0, 0))));
            animation.KeyFrames.Add(new LinearDoubleKeyFrame(0.25, KeyTime.FromTimeSpan(new System.TimeSpan(0, 0, 2))));
            animation.KeyFrames.Add(new LinearDoubleKeyFrame(0.5, KeyTime.FromTimeSpan(new System.TimeSpan(0, 0, 4))));
            animation.KeyFrames.Add(new LinearDoubleKeyFrame(0.75, KeyTime.FromTimeSpan(new System.TimeSpan(0, 0, 6))));
            animation.KeyFrames.Add(new LinearDoubleKeyFrame(1, KeyTime.FromTimeSpan(new System.TimeSpan(0, 0, 8))));
            //circleProgressBar.BeginAnimation(CircularProgressBar.CurrentValueProperty, animation);
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

           Task.Factory.StartNew(() => ShowDashBoard());

           keyFrameAnimation_Completed();
            //Task.Factory.StartNew(() => StartCircleAnimation());
            //PathControl pathControl = new PathControl();
            //pathControl.ShowDialog();
           
        }

        private void ShowDashBoard()
        {
            while (true)
            {
                Thread.Sleep(2000);
                Random random = new Random();
                double value = random.Next(1, 180);
                pathControl.Dispatcher.Invoke(() =>
                {
                    pathControl.Value = value;
                });

                int i = 1;

                Random random1 = new Random();
                double dvalue = random1.Next(0, 100);
                CircularProcess.Dispatcher.Invoke(() =>
                {
                    CircularProcess.CurrentValue = dvalue / 100;
                });

            }




        }


        private void StartCircleAnimation()
        {
            int i = 1;
            while (true)
            {
                
                
                CircularProcess.Dispatcher.Invoke(() =>
                {
                    CircularProcess.CurrentValue = i / 100;
                });
                i++;
                if (i >= 100)
                {
                    i = 1;
                }
                Thread.Sleep(1000);
            }
            
        }




    }
}