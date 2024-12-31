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
        public WaveControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            BindAnimation();
        }


        private void BindAnimation()
        {
            // 创建一个 DoubleAnimation
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0, // 起始位置
                To = -300, // 结束位置
                Duration = TimeSpan.FromSeconds(1), // 动画持续时间
                RepeatBehavior = RepeatBehavior.Forever, // 循环
            };
            MyTranslateTransform.BeginAnimation(TranslateTransform.XProperty, animation);
            
        }

    }
}
