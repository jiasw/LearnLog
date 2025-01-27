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
    /// PipeLineThree.xaml 的交互逻辑
    /// </summary>
    public partial class PipeLineThree : UserControl
    {
        // Token: 0x06000AFE RID: 2814 RVA: 0x000577F0 File Offset: 0x000559F0
        public PipeLineThree()
        {
            this.InitializeComponent();
            this.offect1DoubleAnimation = new DoubleAnimation(0.0, 10.0, TimeSpan.FromMilliseconds(1000.0));
            this.offect1DoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            base.BeginAnimation(PipeLineThree.LineOffect1Property, this.offect1DoubleAnimation);
            this.offect2DoubleAnimation = new DoubleAnimation(0.0, 10.0, TimeSpan.FromMilliseconds(1000.0));
            this.offect2DoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            base.BeginAnimation(PipeLineThree.LineOffect2Property, this.offect2DoubleAnimation);
            this.offect3DoubleAnimation = new DoubleAnimation(0.0, 10.0, TimeSpan.FromMilliseconds(1000.0));
            this.offect3DoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            base.BeginAnimation(PipeLineThree.LineOffect3Property, this.offect3DoubleAnimation);
        }

        /// <summary>
        /// 获取或设置管道控件的边缘颜色
        /// </summary>
        // Token: 0x1700035D RID: 861
        // (get) Token: 0x06000AFF RID: 2815 RVA: 0x0005791C File Offset: 0x00055B1C
        // (set) Token: 0x06000B00 RID: 2816 RVA: 0x0005793E File Offset: 0x00055B3E
        public Color EdgeColor
        {
            get
            {
                return (Color)base.GetValue(PipeLineThree.EdgeColorProperty);
            }
            set
            {
                base.SetValue(PipeLineThree.EdgeColorProperty, value);
            }
        }

        /// <summary>
        /// 管道的中心颜色
        /// </summary>
        // Token: 0x1700035E RID: 862
        // (get) Token: 0x06000B01 RID: 2817 RVA: 0x00057954 File Offset: 0x00055B54
        // (set) Token: 0x06000B02 RID: 2818 RVA: 0x00057976 File Offset: 0x00055B76
        public Color CenterColor
        {
            get
            {
                return (Color)base.GetValue(PipeLineThree.CenterColorProperty);
            }
            set
            {
                base.SetValue(PipeLineThree.CenterColorProperty, value);
            }
        }

        /// <summary>
        /// 获取或设置管道1号线是否激活液体显示
        /// </summary>
        // Token: 0x1700035F RID: 863
        // (get) Token: 0x06000B03 RID: 2819 RVA: 0x0005798C File Offset: 0x00055B8C
        // (set) Token: 0x06000B04 RID: 2820 RVA: 0x000579AE File Offset: 0x00055BAE
        public bool PipeLineActive1
        {
            get
            {
                return (bool)base.GetValue(PipeLineThree.PipeLineActive1Property);
            }
            set
            {
                base.SetValue(PipeLineThree.PipeLineActive1Property, value);
            }
        }

        /// <summary>
        /// 获取或设置管道2号线是否激活液体显示
        /// </summary>
        // Token: 0x17000360 RID: 864
        // (get) Token: 0x06000B05 RID: 2821 RVA: 0x000579C4 File Offset: 0x00055BC4
        // (set) Token: 0x06000B06 RID: 2822 RVA: 0x000579E6 File Offset: 0x00055BE6
        public bool PipeLineActive2
        {
            get
            {
                return (bool)base.GetValue(PipeLineThree.PipeLineActive2Property);
            }
            set
            {
                base.SetValue(PipeLineThree.PipeLineActive2Property, value);
            }
        }

        /// <summary>
        /// 获取或设置管道3号线是否激活液体显示
        /// </summary>
        // Token: 0x17000361 RID: 865
        // (get) Token: 0x06000B07 RID: 2823 RVA: 0x000579FC File Offset: 0x00055BFC
        // (set) Token: 0x06000B08 RID: 2824 RVA: 0x00057A1E File Offset: 0x00055C1E
        public bool PipeLineActive3
        {
            get
            {
                return (bool)base.GetValue(PipeLineThree.PipeLineActive3Property);
            }
            set
            {
                base.SetValue(PipeLineThree.PipeLineActive3Property, value);
            }
        }

        /// <summary>
        /// 获取或设置管道1号线液体流动的速度，0为静止，正数为正向流动，负数为反向流动
        /// </summary>
        // Token: 0x17000362 RID: 866
        // (get) Token: 0x06000B09 RID: 2825 RVA: 0x00057A34 File Offset: 0x00055C34
        // (set) Token: 0x06000B0A RID: 2826 RVA: 0x00057A56 File Offset: 0x00055C56
        public double MoveSpeed1
        {
            get
            {
                return (double)base.GetValue(PipeLineThree.MoveSpeed1Property);
            }
            set
            {
                base.SetValue(PipeLineThree.MoveSpeed1Property, value);
            }
        }

        // Token: 0x06000B0B RID: 2827 RVA: 0x00057A6C File Offset: 0x00055C6C
        public static void MoveSpeed1PropertyChangedCallback(DependencyObject dependency, DependencyPropertyChangedEventArgs e)
        {
            PipeLineThree pipeLine = (PipeLineThree)dependency;
            pipeLine.UpdateMoveSpeed1();
        }

        // Token: 0x06000B0C RID: 2828 RVA: 0x00057A88 File Offset: 0x00055C88
        public void UpdateMoveSpeed1()
        {
            bool flag = this.MoveSpeed1 > 0.0;
            if (flag)
            {
                this.offect1DoubleAnimation.From = new double?(0.0);
                this.offect1DoubleAnimation.To = new double?(10.0);
                this.offect1DoubleAnimation.Duration = TimeSpan.FromMilliseconds(300.0 / this.MoveSpeed1);
                base.BeginAnimation(PipeLineThree.LineOffect1Property, this.offect1DoubleAnimation);
            }
            else
            {
                bool flag2 = this.MoveSpeed1 < 0.0;
                if (flag2)
                {
                    this.offect1DoubleAnimation.From = new double?(0.0);
                    this.offect1DoubleAnimation.To = new double?(-10.0);
                    this.offect1DoubleAnimation.Duration = TimeSpan.FromMilliseconds(300.0 / Math.Abs(this.MoveSpeed1));
                    base.BeginAnimation(PipeLineThree.LineOffect1Property, this.offect1DoubleAnimation);
                }
                else
                {
                    this.offect1DoubleAnimation.From = new double?(0.0);
                    this.offect1DoubleAnimation.To = new double?(0.0);
                    base.BeginAnimation(PipeLineThree.LineOffect1Property, this.offect1DoubleAnimation);
                }
            }
        }

        /// <summary>
        /// 获取或设置管道2号线液体流动的速度，0为静止，正数为正向流动，负数为反向流动
        /// </summary>
        // Token: 0x17000363 RID: 867
        // (get) Token: 0x06000B0D RID: 2829 RVA: 0x00057BF0 File Offset: 0x00055DF0
        // (set) Token: 0x06000B0E RID: 2830 RVA: 0x00057C12 File Offset: 0x00055E12
        public double MoveSpeed2
        {
            get
            {
                return (double)base.GetValue(PipeLineThree.MoveSpeed2Property);
            }
            set
            {
                base.SetValue(PipeLineThree.MoveSpeed2Property, value);
            }
        }

        // Token: 0x06000B0F RID: 2831 RVA: 0x00057C28 File Offset: 0x00055E28
        public static void MoveSpeed2PropertyChangedCallback(DependencyObject dependency, DependencyPropertyChangedEventArgs e)
        {
            PipeLineThree pipeLine = (PipeLineThree)dependency;
            pipeLine.UpdateMoveSpeed2();
        }

        // Token: 0x06000B10 RID: 2832 RVA: 0x00057C44 File Offset: 0x00055E44
        public void UpdateMoveSpeed2()
        {
            bool flag = this.MoveSpeed2 > 0.0;
            if (flag)
            {
                this.offect2DoubleAnimation.From = new double?(0.0);
                this.offect2DoubleAnimation.To = new double?(10.0);
                this.offect2DoubleAnimation.Duration = TimeSpan.FromMilliseconds(300.0 / this.MoveSpeed2);
                base.BeginAnimation(PipeLineThree.LineOffect2Property, this.offect2DoubleAnimation);
            }
            else
            {
                bool flag2 = this.MoveSpeed2 < 0.0;
                if (flag2)
                {
                    this.offect2DoubleAnimation.From = new double?(0.0);
                    this.offect2DoubleAnimation.To = new double?(-10.0);
                    this.offect2DoubleAnimation.Duration = TimeSpan.FromMilliseconds(300.0 / Math.Abs(this.MoveSpeed2));
                    base.BeginAnimation(PipeLineThree.LineOffect2Property, this.offect2DoubleAnimation);
                }
                else
                {
                    this.offect2DoubleAnimation.From = new double?(0.0);
                    this.offect2DoubleAnimation.To = new double?(0.0);
                    base.BeginAnimation(PipeLineThree.LineOffect2Property, this.offect2DoubleAnimation);
                }
            }
        }

        /// <summary>
        /// 获取或设置管道3号线液体流动的速度，0为静止，正数为正向流动，负数为反向流动
        /// </summary>
        // Token: 0x17000364 RID: 868
        // (get) Token: 0x06000B11 RID: 2833 RVA: 0x00057DAC File Offset: 0x00055FAC
        // (set) Token: 0x06000B12 RID: 2834 RVA: 0x00057DCE File Offset: 0x00055FCE
        public double MoveSpeed3
        {
            get
            {
                return (double)base.GetValue(PipeLineThree.MoveSpeed3Property);
            }
            set
            {
                base.SetValue(PipeLineThree.MoveSpeed3Property, value);
            }
        }

        // Token: 0x06000B13 RID: 2835 RVA: 0x00057DE4 File Offset: 0x00055FE4
        public static void MoveSpeed3PropertyChangedCallback(DependencyObject dependency, DependencyPropertyChangedEventArgs e)
        {
            PipeLineThree pipeLine = (PipeLineThree)dependency;
            pipeLine.UpdateMoveSpeed3();
        }

        // Token: 0x06000B14 RID: 2836 RVA: 0x00057E00 File Offset: 0x00056000
        public void UpdateMoveSpeed3()
        {
            bool flag = this.MoveSpeed3 > 0.0;
            if (flag)
            {
                this.offect3DoubleAnimation.From = new double?(0.0);
                this.offect3DoubleAnimation.To = new double?(10.0);
                this.offect3DoubleAnimation.Duration = TimeSpan.FromMilliseconds(300.0 / this.MoveSpeed3);
                base.BeginAnimation(PipeLineThree.LineOffect3Property, this.offect3DoubleAnimation);
            }
            else
            {
                bool flag2 = this.MoveSpeed3 < 0.0;
                if (flag2)
                {
                    this.offect3DoubleAnimation.From = new double?(0.0);
                    this.offect3DoubleAnimation.To = new double?(-10.0);
                    this.offect3DoubleAnimation.Duration = TimeSpan.FromMilliseconds(300.0 / Math.Abs(this.MoveSpeed3));
                    base.BeginAnimation(PipeLineThree.LineOffect3Property, this.offect3DoubleAnimation);
                }
                else
                {
                    this.offect3DoubleAnimation.From = new double?(0.0);
                    this.offect3DoubleAnimation.To = new double?(0.0);
                    base.BeginAnimation(PipeLineThree.LineOffect3Property, this.offect3DoubleAnimation);
                }
            }
        }

        /// <summary>
        /// 管道1的偏移
        /// </summary>
        // Token: 0x17000365 RID: 869
        // (get) Token: 0x06000B15 RID: 2837 RVA: 0x00057F68 File Offset: 0x00056168
        // (set) Token: 0x06000B16 RID: 2838 RVA: 0x00057F8A File Offset: 0x0005618A
        public double LineOffect1
        {
            get
            {
                return (double)base.GetValue(PipeLineThree.LineOffect1Property);
            }
            set
            {
                base.SetValue(PipeLineThree.LineOffect1Property, value);
            }
        }

        /// <summary>
        /// 管道2的偏移
        /// </summary>
        // Token: 0x17000366 RID: 870
        // (get) Token: 0x06000B17 RID: 2839 RVA: 0x00057FA0 File Offset: 0x000561A0
        // (set) Token: 0x06000B18 RID: 2840 RVA: 0x00057FC2 File Offset: 0x000561C2
        public double LineOffect2
        {
            get
            {
                return (double)base.GetValue(PipeLineThree.LineOffect2Property);
            }
            set
            {
                base.SetValue(PipeLineThree.LineOffect2Property, value);
            }
        }

        /// <summary>
        /// 管道3的偏移
        /// </summary>
        // Token: 0x17000367 RID: 871
        // (get) Token: 0x06000B19 RID: 2841 RVA: 0x00057FD8 File Offset: 0x000561D8
        // (set) Token: 0x06000B1A RID: 2842 RVA: 0x00057FFA File Offset: 0x000561FA
        public double LineOffect3
        {
            get
            {
                return (double)base.GetValue(PipeLineThree.LineOffect3Property);
            }
            set
            {
                base.SetValue(PipeLineThree.LineOffect3Property, value);
            }
        }

        /// <summary>
        /// 获取或设置中间管道线的宽度信息，默认为3
        /// </summary>
        // Token: 0x17000368 RID: 872
        // (get) Token: 0x06000B1B RID: 2843 RVA: 0x00058010 File Offset: 0x00056210
        // (set) Token: 0x06000B1C RID: 2844 RVA: 0x00058032 File Offset: 0x00056232
        public int PipeLineWidth
        {
            get
            {
                return (int)base.GetValue(PipeLineThree.PipeLineWidthProperty);
            }
            set
            {
                base.SetValue(PipeLineThree.PipeLineWidthProperty, value);
            }
        }

        /// <summary>
        /// 获取或设置流动状态时管道控件的中心颜色
        /// </summary>
        // Token: 0x17000369 RID: 873
        // (get) Token: 0x06000B1D RID: 2845 RVA: 0x00058048 File Offset: 0x00056248
        // (set) Token: 0x06000B1E RID: 2846 RVA: 0x0005806A File Offset: 0x0005626A
        public Color ActiveLineCenterColor
        {
            get
            {
                return (Color)base.GetValue(PipeLineThree.ActiveLineCenterColorProperty);
            }
            set
            {
                base.SetValue(PipeLineThree.ActiveLineCenterColorProperty, value);
            }
        }

        /// <summary>
        /// 获取或设置管道的宽度，默认为30
        /// </summary>
        // Token: 0x1700036A RID: 874
        // (get) Token: 0x06000B1F RID: 2847 RVA: 0x00058080 File Offset: 0x00056280
        // (set) Token: 0x06000B20 RID: 2848 RVA: 0x000580A2 File Offset: 0x000562A2
        public int PipeWidth
        {
            get
            {
                return (int)base.GetValue(PipeLineThree.PipeWidthProperty);
            }
            set
            {
                base.SetValue(PipeLineThree.PipeWidthProperty, value);
            }
        }

        // Token: 0x06000B21 RID: 2849 RVA: 0x000580B8 File Offset: 0x000562B8
        public static void PipeWidthPropertyChangedCallback(DependencyObject dependency, DependencyPropertyChangedEventArgs e)
        {
            PipeLineThree pipeLine = (PipeLineThree)dependency;
            pipeLine.PipeWidthUpdate();
        }

        // Token: 0x06000B22 RID: 2850 RVA: 0x000580D4 File Offset: 0x000562D4
        public void PipeWidthUpdate()
        {
            this.UpdatePath();
        }

        // Token: 0x06000B23 RID: 2851 RVA: 0x000580DE File Offset: 0x000562DE
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            this.UpdatePath();
            base.OnRenderSizeChanged(sizeInfo);
        }

        // Token: 0x06000B24 RID: 2852 RVA: 0x000580F0 File Offset: 0x000562F0
        public void UpdatePath()
        {
            this.polygon1.Points = new PointCollection(new Point[]
            {
                new Point(base.ActualWidth / 2.0 - (double)this.PipeWidth / 2.0, (double)this.PipeWidth),
                new Point(base.ActualWidth / 2.0, (double)this.PipeWidth / 2.0),
                new Point(base.ActualWidth / 2.0 + (double)this.PipeWidth / 2.0, (double)this.PipeWidth),
                new Point(base.ActualWidth / 2.0 + (double)this.PipeWidth / 2.0, base.ActualHeight),
                new Point(base.ActualWidth / 2.0 - (double)this.PipeWidth / 2.0, base.ActualHeight),
                new Point(base.ActualWidth / 2.0 - (double)this.PipeWidth / 2.0, (double)this.PipeWidth)
            });
            StreamGeometry g = new StreamGeometry();
            using (StreamGeometryContext context = g.Open())
            {
                context.BeginFigure(new Point(0.0, (double)this.PipeWidth / 2.0), false, false);
                context.LineTo(new Point(base.ActualWidth, (double)this.PipeWidth / 2.0), true, false);
            }
            this.path1.Data = g;
            StreamGeometry g2 = new StreamGeometry();
            using (StreamGeometryContext context2 = g2.Open())
            {
                context2.BeginFigure(new Point(0.0, (double)this.PipeWidth / 2.0), false, false);
                context2.LineTo(new Point(base.ActualWidth / 2.0 - (double)this.PipeWidth / 2.0, (double)this.PipeWidth / 2.0), true, false);
                context2.ArcTo(new Point(base.ActualWidth / 2.0, (double)this.PipeWidth), new Size((double)this.PipeWidth / 2.0, (double)this.PipeWidth / 2.0), 0.0, false, SweepDirection.Clockwise, true, false);
                context2.LineTo(new Point(base.ActualWidth / 2.0, base.ActualHeight), true, false);
            }
            this.path2.Data = g2;
            StreamGeometry g3 = new StreamGeometry();
            using (StreamGeometryContext context3 = g3.Open())
            {
                context3.BeginFigure(new Point(base.ActualWidth, (double)this.PipeWidth / 2.0), false, false);
                context3.LineTo(new Point(base.ActualWidth / 2.0 + (double)this.PipeWidth / 2.0, (double)this.PipeWidth / 2.0), true, false);
                context3.ArcTo(new Point(base.ActualWidth / 2.0, (double)this.PipeWidth), new Size((double)this.PipeWidth / 2.0, (double)this.PipeWidth / 2.0), 0.0, false, SweepDirection.Counterclockwise, true, false);
                context3.LineTo(new Point(base.ActualWidth / 2.0, base.ActualHeight), true, false);
            }
            this.path3.Data = g3;
        }

        // Token: 0x0400056D RID: 1389
        public static readonly DependencyProperty EdgeColorProperty = DependencyProperty.Register("EdgeColor", typeof(Color), typeof(PipeLineThree), new PropertyMetadata(Colors.DimGray));

        // Token: 0x0400056E RID: 1390
        public static readonly DependencyProperty CenterColorProperty = DependencyProperty.Register("CenterColor", typeof(Color), typeof(PipeLineThree), new PropertyMetadata(Colors.LightGray));

        // Token: 0x0400056F RID: 1391
        public static readonly DependencyProperty PipeLineActive1Property = DependencyProperty.Register("PipeLineActive1", typeof(bool), typeof(PipeLineThree), new PropertyMetadata(false));

        // Token: 0x04000570 RID: 1392
        public static readonly DependencyProperty PipeLineActive2Property = DependencyProperty.Register("PipeLineActive2", typeof(bool), typeof(PipeLineThree), new PropertyMetadata(false));

        // Token: 0x04000571 RID: 1393
        public static readonly DependencyProperty PipeLineActive3Property = DependencyProperty.Register("PipeLineActive3", typeof(bool), typeof(PipeLineThree), new PropertyMetadata(false));

        // Token: 0x04000572 RID: 1394
        public static readonly DependencyProperty MoveSpeed1Property = DependencyProperty.Register("MoveSpeed1", typeof(double), typeof(PipeLineThree), new PropertyMetadata(0.0, new PropertyChangedCallback(PipeLineThree.MoveSpeed1PropertyChangedCallback)));

        // Token: 0x04000573 RID: 1395
        private DoubleAnimation offect1DoubleAnimation = null;

        // Token: 0x04000574 RID: 1396
        public static readonly DependencyProperty MoveSpeed2Property = DependencyProperty.Register("MoveSpeed2", typeof(double), typeof(PipeLineThree), new PropertyMetadata(0.0, new PropertyChangedCallback(PipeLineThree.MoveSpeed2PropertyChangedCallback)));

        // Token: 0x04000575 RID: 1397
        private DoubleAnimation offect2DoubleAnimation = null;

        // Token: 0x04000576 RID: 1398
        public static readonly DependencyProperty MoveSpeed3Property = DependencyProperty.Register("MoveSpeed3", typeof(double), typeof(PipeLineThree), new PropertyMetadata(0.0, new PropertyChangedCallback(PipeLineThree.MoveSpeed3PropertyChangedCallback)));

        // Token: 0x04000577 RID: 1399
        private DoubleAnimation offect3DoubleAnimation = null;

        // Token: 0x04000578 RID: 1400
        public static readonly DependencyProperty LineOffect1Property = DependencyProperty.Register("LineOffect1", typeof(double), typeof(PipeLineThree), new PropertyMetadata(0.0));

        // Token: 0x04000579 RID: 1401
        public static readonly DependencyProperty LineOffect2Property = DependencyProperty.Register("LineOffect2", typeof(double), typeof(PipeLineThree), new PropertyMetadata(0.0));

        // Token: 0x0400057A RID: 1402
        public static readonly DependencyProperty LineOffect3Property = DependencyProperty.Register("LineOffect3", typeof(double), typeof(PipeLineThree), new PropertyMetadata(0.0));

        // Token: 0x0400057B RID: 1403
        public static readonly DependencyProperty PipeLineWidthProperty = DependencyProperty.Register("PipeLineWidth", typeof(int), typeof(PipeLineThree), new PropertyMetadata(2));

        // Token: 0x0400057C RID: 1404
        public static readonly DependencyProperty ActiveLineCenterColorProperty = DependencyProperty.Register("ActiveLineCenterColor", typeof(Color), typeof(PipeLineThree), new PropertyMetadata(Colors.DodgerBlue));

        // Token: 0x0400057D RID: 1405
        public static readonly DependencyProperty PipeWidthProperty = DependencyProperty.Register("PipeWidth", typeof(int), typeof(PipeLineThree), new PropertyMetadata(30, new PropertyChangedCallback(PipeLineThree.PipeWidthPropertyChangedCallback)));
    }
}
