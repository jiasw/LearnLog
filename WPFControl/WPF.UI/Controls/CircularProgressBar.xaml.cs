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
    /// 圆环型进度条控件
    /// </summary>
    public partial class CircularProgressBar : UserControl
    {
        private Point _lastPoint=new Point(0,0); //进度条上次的位置
        public CircularProgressBar()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CurrentValueProperty 
            = DependencyProperty.Register("CurrentValue",
                typeof(double), 
                typeof(CircularProgressBar),
                new PropertyMetadata(0.0, new PropertyChangedCallback(OnCurrentValueChanged)));

        private static void OnCurrentValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CircularProgressBar cpb = d as CircularProgressBar;
            cpb.SetProcess(cpb.CurrentValue);
        }

        public double CurrentValue
        {
            get { return (double)GetValue(CurrentValueProperty); }
            set { SetValue(CurrentValueProperty, value);SetProcess(value); }
        }

        private ArcSegment arcsegment;

        /// <summary>
        /// 设置百分百，输入小数，自动乘100
        /// </summary>
        /// <param name="percentValue"></param>
        private void SetProcess(double percentValue)
        {
            /*****************************************
              方形矩阵边长为34，半长为17
              环形半径为14，所以距离边框3个像素
              环形描边3个像素
            ******************************************/
            double angel = percentValue * 360; //角度



            double radius = 14; //环形半径

            //起始点
            double leftStart = 17;
            double topStart = 3;

            //结束点
            double endLeft = 0;
            double endTop = 0;



            //数字显示
            lbValue.Content = (percentValue * 100).ToString("0") + "%";

            /***********************************************
            * 整个环形进度条使用Path来绘制，采用三角函数来计算
            * 环形根据角度来分别绘制，以90度划分，方便计算比例
            ***********************************************/

            bool isLagreCircle = false; //是否优势弧，即大于180度的弧形

            //小于90度
            if (angel <= 90)
            {
                /*****************
                          *
                          *   *
                          * * ra
                   * * * * * * * * *
                          *
                          *
                          *
                ******************/
                double ra = (90 - angel) * Math.PI / 180; //弧度
                endLeft = leftStart + Math.Cos(ra) * radius; //余弦横坐标
                endTop = topStart + radius - Math.Sin(ra) * radius; //正弦纵坐标

            }

            else if (angel <= 180)
            {
                /*****************
                          *
                          *  
                          * 
                   * * * * * * * * *
                          * * ra
                          *  *
                          *   *
                ******************/

                double ra = (angel - 90) * Math.PI / 180; //弧度
                endLeft = leftStart + Math.Cos(ra) * radius; //余弦横坐标
                endTop = topStart + radius + Math.Sin(ra) * radius;//正弦纵坐标
            }

            else if (angel <= 270)
            {
                /*****************
                          *
                          *  
                          * 
                   * * * * * * * * *
                        * *
                       *ra*
                      *   *
                ******************/
                isLagreCircle = true; //优势弧
                double ra = (angel - 180) * Math.PI / 180;
                endLeft = leftStart - Math.Sin(ra) * radius;
                endTop = topStart + radius + Math.Cos(ra) * radius;
            }

            else if (angel < 360)
            {
                /*****************
                      *   *
                       *  *  
                     ra * * 
                   * * * * * * * * *
                          *
                          *
                          *
                ******************/
                isLagreCircle = true; //优势弧
                double ra = (angel - 270) * Math.PI / 180;
                endLeft = leftStart - Math.Cos(ra) * radius;
                endTop = topStart + radius - Math.Sin(ra) * radius;
            }
            else
            {
                isLagreCircle = true; //优势弧
                endLeft = leftStart - 0.001; //不与起点在同一点，避免重叠绘制出非环形
                endTop = topStart;
            }

            Point arcEndPt = new Point(endLeft, endTop); //结束点
            //Point arcEndPt = new Point(17, 31); //结束点
            Size arcSize = new Size(radius, radius);
            SweepDirection direction = SweepDirection.Clockwise; //顺时针弧形
            //弧形
            arcsegment = new ArcSegment(arcEndPt, arcSize, 0, isLagreCircle, direction, true);

            //形状集合
            PathSegmentCollection pathsegmentCollection = new PathSegmentCollection();
            pathsegmentCollection.Add(arcsegment);

            //路径描述
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(leftStart, topStart); //起始地址
            pathFigure.Segments = pathsegmentCollection;

            //路径描述集合
            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            pathFigureCollection.Add(pathFigure);

            //复杂形状
            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pathFigureCollection;

            //Data赋值
            process.Data = pathGeometry;
            //达到100%则闭合整个
            if (angel == 360)
                process.Data = Geometry.Parse(process.Data.ToString() + " z");
        }

        private void AnimateEllipse(Point newPoint)
        {
            PointAnimation pointAnimation = new PointAnimation()
            {
                To = newPoint,
                Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                FillBehavior = FillBehavior.HoldEnd
            };

            //process.BeginAnimation(process.Data, pointAnimation);
            //// 将动画应用到控件的Canvas.Left和Canvas.Top属性
            //Storyboard.SetTarget(pointAnimation, MyEllipse);
            //Storyboard.SetTargetProperty(pointAnimation, new PropertyPath("(Canvas.Left),(Canvas.Top)"));

            //// 创建Storyboard以包含动画
            //Storyboard storyboard = new Storyboard();
            //storyboard.Children.Add(pointAnimation);

            //// 开始动画
            //storyboard.Begin();

        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        { //起始点
            double leftStart = 17;
            double topStart = 3;

            //结束点
            double endLeft = 0;
            double endTop = 0;
            double radius = 14; //环形半径
            Point arcEndPt = new Point(17, 31); //结束点
            Size arcSize = new Size(radius, radius);
            arcsegment = new ArcSegment(arcEndPt, arcSize, 0, true, SweepDirection.Clockwise, true);
        }
    }
}
