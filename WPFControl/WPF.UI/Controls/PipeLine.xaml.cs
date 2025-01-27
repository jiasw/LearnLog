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
using WPF.UI.Converter;
using WPF.UI.Enum;

namespace WPF.UI.Controls
{
    /// <summary>
    /// PipeLine.xaml 的交互逻辑
    /// </summary>
    public partial class PipeLine : UserControl
    {
        /// <summary>
        /// 实例化一个管道对象
        /// </summary>
        // Token: 0x06000AE0 RID: 2784 RVA: 0x00056BB8 File Offset: 0x00054DB8
        public PipeLine()
        {
            this.InitializeComponent();
            this.offectDoubleAnimation = new DoubleAnimation(0.0, 10.0, TimeSpan.FromMilliseconds(1000.0));
            this.offectDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            base.BeginAnimation(PipeLine.LineOffectProperty, this.offectDoubleAnimation);
        }

        /// <summary>
        /// 设置左边的方向
        /// </summary>
        // Token: 0x17000354 RID: 852
        // (get) Token: 0x06000AE1 RID: 2785 RVA: 0x00056C3C File Offset: 0x00054E3C
        // (set) Token: 0x06000AE2 RID: 2786 RVA: 0x00056C5E File Offset: 0x00054E5E
        public PipeTurnDirection LeftDirection
        {
            get
            {
                return (PipeTurnDirection)base.GetValue(PipeLine.LeftDirectionProperty);
            }
            set
            {
                base.SetValue(PipeLine.LeftDirectionProperty, value);
            }
        }

        // Token: 0x06000AE3 RID: 2787 RVA: 0x00056C74 File Offset: 0x00054E74
        public static void LeftDirectionPropertyChangedCallback(DependencyObject dependency, DependencyPropertyChangedEventArgs e)
        {
            PipeLine pipeLine = (PipeLine)dependency;
            pipeLine.UpdateLeftDirectionBinding();
        }

        // Token: 0x06000AE4 RID: 2788 RVA: 0x00056C90 File Offset: 0x00054E90
        public void UpdateLeftDirectionBinding()
        {
            BindingOperations.ClearBinding(this.ellipe1, Canvas.TopProperty);
            bool flag = this.LeftDirection == PipeTurnDirection.Left;
            if (flag)
            {
                this.canvas1.Visibility = Visibility.Visible;
                Binding binding = new Binding();
                binding.Source = this.grid1;
                binding.Path = new PropertyPath("ActualHeight", new object[0]);
                binding.Converter = new MultiplesValueConverter();
                binding.ConverterParameter = 0;
                this.ellipe1.SetBinding(Canvas.TopProperty, binding);
            }
            else
            {
                bool flag2 = this.LeftDirection == PipeTurnDirection.Right;
                if (flag2)
                {
                    this.canvas1.Visibility = Visibility.Visible;
                    Binding binding2 = new Binding();
                    binding2.Source = this.grid1;
                    binding2.Path = new PropertyPath("ActualHeight", new object[0]);
                    binding2.Converter = new MultiplesValueConverter();
                    binding2.ConverterParameter = -1;
                    this.ellipe1.SetBinding(Canvas.TopProperty, binding2);
                }
                else
                {
                    this.canvas1.Visibility = Visibility.Collapsed;
                }
            }
            this.UpdatePathData();
        }

        /// <summary>
        /// 设置右边的方向
        /// </summary>
        public PipeTurnDirection RightDirection
        {
            get
            {
                return (PipeTurnDirection)base.GetValue(PipeLine.RightDirectionProperty);
            }
            set
            {
                base.SetValue(PipeLine.RightDirectionProperty, value);
            }
        }

        // Token: 0x06000AE7 RID: 2791 RVA: 0x00056DE8 File Offset: 0x00054FE8
        public static void RightDirectionPropertyChangedCallback(DependencyObject dependency, DependencyPropertyChangedEventArgs e)
        {
            PipeLine pipeLine = (PipeLine)dependency;
            pipeLine.UpdateRightDirectionBinding();
        }

        // Token: 0x06000AE8 RID: 2792 RVA: 0x00056E04 File Offset: 0x00055004
        public void UpdateRightDirectionBinding()
        {
            BindingOperations.ClearBinding(this.ellipe2, Canvas.TopProperty);
            bool flag = this.RightDirection == PipeTurnDirection.Left;
            if (flag)
            {
                this.canvas2.Visibility = Visibility.Visible;
                Binding binding = new Binding();
                binding.Source = this.grid1;
                binding.Path = new PropertyPath("ActualHeight", new object[0]);
                binding.Converter = new MultiplesValueConverter();
                binding.ConverterParameter = 0;
                this.ellipe2.SetBinding(Canvas.TopProperty, binding);
            }
            else
            {
                bool flag2 = this.RightDirection == PipeTurnDirection.Right;
                if (flag2)
                {
                    this.canvas2.Visibility = Visibility.Visible;
                    Binding binding2 = new Binding();
                    binding2.Source = this.grid1;
                    binding2.Path = new PropertyPath("ActualHeight", new object[0]);
                    binding2.Converter = new MultiplesValueConverter();
                    binding2.ConverterParameter = -1;
                    this.ellipe2.SetBinding(Canvas.TopProperty, binding2);
                }
                else
                {
                    this.canvas2.Visibility = Visibility.Collapsed;
                }
            }
            this.UpdatePathData();
        }

        // Token: 0x17000356 RID: 854
        // (get) Token: 0x06000AE9 RID: 2793 RVA: 0x00056F24 File Offset: 0x00055124
        // (set) Token: 0x06000AEA RID: 2794 RVA: 0x00056F46 File Offset: 0x00055146
        public bool PipeLineActive
        {
            get
            {
                return (bool)base.GetValue(PipeLine.PipeLineActiveProperty);
            }
            set
            {
                base.SetValue(PipeLine.PipeLineActiveProperty, value);
            }
        }

        // Token: 0x06000AEB RID: 2795 RVA: 0x00056F5B File Offset: 0x0005515B
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            this.UpdatePathData();
            base.OnRenderSizeChanged(sizeInfo);
        }

        // Token: 0x17000357 RID: 855
        // (get) Token: 0x06000AEC RID: 2796 RVA: 0x00056F70 File Offset: 0x00055170
        // (set) Token: 0x06000AED RID: 2797 RVA: 0x00056F92 File Offset: 0x00055192
        public double LineOffect
        {
            get
            {
                return (double)base.GetValue(PipeLine.LineOffectProperty);
            }
            set
            {
                base.SetValue(PipeLine.LineOffectProperty, value);
            }
        }

        // Token: 0x06000AEE RID: 2798 RVA: 0x00056FA8 File Offset: 0x000551A8
        public void UpdatePathData()
        {
            Console.WriteLine("Size Changed");
            StreamGeometry g = new StreamGeometry();
            using (StreamGeometryContext context = g.Open())
            {
                bool flag = this.LeftDirection == PipeTurnDirection.Left;
                if (flag)
                {
                    context.BeginFigure(new Point(base.ActualHeight / 2.0, base.ActualHeight), false, false);
                    context.ArcTo(new Point(base.ActualHeight, base.ActualHeight / 2.0), new Size(base.ActualHeight / 2.0, base.ActualHeight / 2.0), 0.0, false, SweepDirection.Clockwise, true, false);
                }
                else
                {
                    bool flag2 = this.LeftDirection == PipeTurnDirection.Right;
                    if (flag2)
                    {
                        context.BeginFigure(new Point(base.ActualHeight / 2.0, 0.0), false, false);
                        context.ArcTo(new Point(base.ActualHeight, base.ActualHeight / 2.0), new Size(base.ActualHeight / 2.0, base.ActualHeight / 2.0), 0.0, false, SweepDirection.Counterclockwise, true, false);
                    }
                    else
                    {
                        context.BeginFigure(new Point(0.0, base.ActualHeight / 2.0), false, false);
                        context.LineTo(new Point(base.ActualHeight, base.ActualHeight / 2.0), true, false);
                    }
                }
                context.LineTo(new Point(base.ActualWidth - base.ActualHeight, base.ActualHeight / 2.0), true, false);
                bool flag3 = this.RightDirection == PipeTurnDirection.Left;
                if (flag3)
                {
                    context.ArcTo(new Point(base.ActualWidth - base.ActualHeight / 2.0, base.ActualHeight), new Size(base.ActualHeight / 2.0, base.ActualHeight / 2.0), 0.0, false, SweepDirection.Clockwise, true, false);
                }
                else
                {
                    bool flag4 = this.RightDirection == PipeTurnDirection.Right;
                    if (flag4)
                    {
                        context.ArcTo(new Point(base.ActualWidth - base.ActualHeight / 2.0, 0.0), new Size(base.ActualHeight / 2.0, base.ActualHeight / 2.0), 0.0, false, SweepDirection.Counterclockwise, true, false);
                    }
                    else
                    {
                        context.LineTo(new Point(base.ActualWidth, base.ActualHeight / 2.0), true, false);
                    }
                }
            }
            this.path1.Data = g;
        }

        /// <summary>
        /// 获取或设置流动的速度
        /// </summary>
        // Token: 0x17000358 RID: 856
        // (get) Token: 0x06000AEF RID: 2799 RVA: 0x000572A0 File Offset: 0x000554A0
        // (set) Token: 0x06000AF0 RID: 2800 RVA: 0x000572C2 File Offset: 0x000554C2
        public double MoveSpeed
        {
            get
            {
                return (double)base.GetValue(PipeLine.MoveSpeedProperty);
            }
            set
            {
                base.SetValue(PipeLine.MoveSpeedProperty, value);
            }
        }

        // Token: 0x06000AF1 RID: 2801 RVA: 0x000572D8 File Offset: 0x000554D8
        public static void MoveSpeedPropertyChangedCallback(DependencyObject dependency, DependencyPropertyChangedEventArgs e)
        {
            PipeLine pipeLine = (PipeLine)dependency;
            pipeLine.UpdateMoveSpeed();
        }

        // Token: 0x06000AF2 RID: 2802 RVA: 0x000572F4 File Offset: 0x000554F4
        public void UpdateMoveSpeed()
        {
            bool flag = this.MoveSpeed > 0.0;
            if (flag)
            {
                this.offectDoubleAnimation.From = new double?(0.0);
                this.offectDoubleAnimation.To = new double?(10.0);
                this.offectDoubleAnimation.Duration = TimeSpan.FromMilliseconds(300.0 / this.MoveSpeed);
                base.BeginAnimation(PipeLine.LineOffectProperty, this.offectDoubleAnimation);
            }
            else
            {
                bool flag2 = this.MoveSpeed < 0.0;
                if (flag2)
                {
                    this.offectDoubleAnimation.From = new double?(0.0);
                    this.offectDoubleAnimation.To = new double?(-10.0);
                    this.offectDoubleAnimation.Duration = TimeSpan.FromMilliseconds(300.0 / Math.Abs(this.MoveSpeed));
                    base.BeginAnimation(PipeLine.LineOffectProperty, this.offectDoubleAnimation);
                }
                else
                {
                    this.offectDoubleAnimation.From = new double?(0.0);
                    this.offectDoubleAnimation.To = new double?(0.0);
                    base.BeginAnimation(PipeLine.LineOffectProperty, this.offectDoubleAnimation);
                }
            }
        }

        /// <summary>
        /// 管道的中心颜色
        /// </summary>
        // Token: 0x17000359 RID: 857
        // (get) Token: 0x06000AF3 RID: 2803 RVA: 0x0005745C File Offset: 0x0005565C
        // (set) Token: 0x06000AF4 RID: 2804 RVA: 0x0005747E File Offset: 0x0005567E
        public Color CenterColor
        {
            get
            {
                return (Color)base.GetValue(PipeLine.CenterColorProperty);
            }
            set
            {
                base.SetValue(PipeLine.CenterColorProperty, value);
            }
        }

        /// <summary>
        /// 管道活动状态时的中心线的线条宽度
        /// </summary>
        // Token: 0x1700035A RID: 858
        // (get) Token: 0x06000AF5 RID: 2805 RVA: 0x00057494 File Offset: 0x00055694
        // (set) Token: 0x06000AF6 RID: 2806 RVA: 0x000574B6 File Offset: 0x000556B6
        public int PipeLineWidth
        {
            get
            {
                return (int)base.GetValue(PipeLine.PipeLineWidthProperty);
            }
            set
            {
                base.SetValue(PipeLine.PipeLineWidthProperty, value);
            }
        }

        /// <summary>
        /// 管道活动状态时的中心线的颜色信息
        /// </summary>
        // Token: 0x1700035B RID: 859
        // (get) Token: 0x06000AF7 RID: 2807 RVA: 0x000574CC File Offset: 0x000556CC
        // (set) Token: 0x06000AF8 RID: 2808 RVA: 0x000574EE File Offset: 0x000556EE
        public Color ActiveLineCenterColor
        {
            get
            {
                return (Color)base.GetValue(PipeLine.ActiveLineCenterColorProperty);
            }
            set
            {
                base.SetValue(PipeLine.ActiveLineCenterColorProperty, value);
            }
        }

        /// <summary>
        /// 管道控件的边缘颜色
        /// </summary>
        // Token: 0x1700035C RID: 860
        // (get) Token: 0x06000AF9 RID: 2809 RVA: 0x00057504 File Offset: 0x00055704
        // (set) Token: 0x06000AFA RID: 2810 RVA: 0x00057526 File Offset: 0x00055726
        public Color EdgeColor
        {
            get
            {
                return (Color)base.GetValue(PipeLine.EdgeColorProperty);
            }
            set
            {
                base.SetValue(PipeLine.EdgeColorProperty, value);
            }
        }

        // Token: 0x0400055B RID: 1371
        private DoubleAnimation offectDoubleAnimation = null;

        // Token: 0x0400055C RID: 1372
        public static readonly DependencyProperty LeftDirectionProperty = DependencyProperty.Register("LeftDirection", typeof(PipeTurnDirection), typeof(PipeLine), new PropertyMetadata(PipeTurnDirection.Left, new PropertyChangedCallback(PipeLine.LeftDirectionPropertyChangedCallback)));

        // Token: 0x0400055D RID: 1373
        public static readonly DependencyProperty RightDirectionProperty = DependencyProperty.Register("RightDirection", typeof(PipeTurnDirection), typeof(PipeLine), new PropertyMetadata(PipeTurnDirection.Right, new PropertyChangedCallback(PipeLine.RightDirectionPropertyChangedCallback)));

        // Token: 0x0400055E RID: 1374
        public static readonly DependencyProperty PipeLineActiveProperty = DependencyProperty.Register("PipeLineActive", typeof(bool), typeof(PipeLine), new PropertyMetadata(false));

        // Token: 0x0400055F RID: 1375
        public static readonly DependencyProperty LineOffectProperty = DependencyProperty.Register("LineOffect", typeof(double), typeof(PipeLine), new PropertyMetadata(0.0));

        // Token: 0x04000560 RID: 1376
        public static readonly DependencyProperty MoveSpeedProperty = DependencyProperty.Register("MoveSpeed", typeof(double), typeof(PipeLine), new PropertyMetadata(0.3, new PropertyChangedCallback(PipeLine.MoveSpeedPropertyChangedCallback)));

        // Token: 0x04000561 RID: 1377
        private Storyboard storyboard = new Storyboard();

        // Token: 0x04000562 RID: 1378
        public static readonly DependencyProperty CenterColorProperty = DependencyProperty.Register("CenterColor", typeof(Color), typeof(PipeLine), new PropertyMetadata(Colors.LightGray));

        // Token: 0x04000563 RID: 1379
        public static readonly DependencyProperty PipeLineWidthProperty = DependencyProperty.Register("PipeLineWidth", typeof(int), typeof(PipeLine), new PropertyMetadata(2));

        // Token: 0x04000564 RID: 1380
        public static readonly DependencyProperty ActiveLineCenterColorProperty = DependencyProperty.Register("ActiveLineCenterColor", typeof(Color), typeof(PipeLine), new PropertyMetadata(Colors.DodgerBlue));

        // Token: 0x04000565 RID: 1381
        public static readonly DependencyProperty EdgeColorProperty = DependencyProperty.Register("EdgeColor", typeof(Color), typeof(PipeLine), new PropertyMetadata(Colors.DimGray));
    }
}
