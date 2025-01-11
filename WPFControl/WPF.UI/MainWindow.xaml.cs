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

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {

           
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
                circularRingProcessBar.Dispatcher.Invoke(() =>
                {
                    circularRingProcessBar.Value = dvalue ;
                    thermometerProcessBar.CurrentValue = dvalue;
                    waveControl.Value = dvalue;
                });

            }




        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() => ShowDashBoard());
        }
    }
}