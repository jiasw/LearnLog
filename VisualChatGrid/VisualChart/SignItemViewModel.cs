using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VisualChart
{

    public enum Direction
    {
        Up=270,
        Down=90,
        Left=180,
        Right=0,

    }

    

    public class SignLineViewModel: NotifycationObject
    {

        private string signUrl = "sign.png";
        /// <summary>
        /// 市标元素的图片路径
        /// </summary>
        public string SignUrl
        {
            get { return signUrl; }
            set { signUrl = value; OnPropertyChanged("SignUrl"); }
        }

        private double lineHeight = 0;
        /// <summary>
        /// 市标元素所在行的高度
        /// </summary>
        public double LineHeight
        {
            get { return lineHeight; }
            set { lineHeight = value; OnPropertyChanged("LineHeight"); }
        }

        private double signHeight =0;
        /// <summary>
        /// 市标元素的高度
        /// </summary>
        public double SignHeight
        {
            get { return signHeight; }
            set { signHeight = value; OnPropertyChanged("SignHeight"); }
        }

        private double signWidth = 0;
        /// <summary>
        /// 市标元素的宽度
        /// </summary>
        public double SignWidth
        {
            get { return signWidth; }
            set { signWidth = value; OnPropertyChanged("SignWidth"); }
        }

        private Thickness margin = new Thickness(0, 0, 0, 0);
        /// <summary>
        /// 市标元素的边距
        /// </summary>
        public Thickness Margin
        {
            get { return margin; }
            set { margin = value; OnPropertyChanged("Margin"); }
        }


        private List<SignItemViewModel> signItems = new List<SignItemViewModel>();
        /// <summary>
        /// 市标元素的子元素集合
        /// </summary>
        public List<SignItemViewModel> SignItems
        {
            get { return signItems; }
            set { signItems = value; OnPropertyChanged("SignItems"); }
        }

        private SignText leftText = new SignText();
        /// <summary>
        /// 左侧的文字
        /// </summary>
        public SignText LeftText
        {
            get { return leftText; }
            set { leftText = value; OnPropertyChanged("LeftText"); }
        }

        private SignText rightText = new SignText();
        /// <summary>
        /// 右侧的文字
        /// </summary>
        public SignText RightText
        {
            get { return rightText; }
            set { rightText = value; OnPropertyChanged("RightText"); }
        }

        private bool isShow = true;
        /// <summary>
        /// 市标元素是否显示
        /// </summary>
        public bool IsShow
        {   
            get { return isShow; }
            set { isShow = value; OnPropertyChanged("IsShow"); }
        }

    }

    public class SignItemViewModel: NotifycationObject
    {
        

        private Direction direction = Direction.Up;
        /// <summary>
        /// 市标元素的方向
        /// </summary>
        public Direction Direction
        {
            get { return direction; }
            set { direction = value; OnPropertyChanged("Direction"); }
        }

        private bool isSelected = false;
        /// <summary>
        /// 市标元素是否被选中
        /// </summary>
        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; OnPropertyChanged("IsSelected"); }
        }

        private bool isShow = true;
        /// <summary>
        /// 市标元素是否显示
        /// </summary>
        public bool IsShow
        {
            get { return isShow; }
            set { isShow = value; OnPropertyChanged("IsShow"); }
        }
        


    }

    public class SignText 
    {
        public string Text { get; set; } = "";
        public string Level { get; set; } = "";
    }


    public class SignVisualViewModel: NotifycationObject
    {
        private List<SignLineViewModel> signLines = new List<SignLineViewModel>();

        public SignVisualViewModel()
        {
            InitSign();
        }

        /// <summary>
        /// 市标元素的集合
        /// </summary>
        public List<SignLineViewModel> SignLines
        {
            get { return signLines; }
            set { signLines = value; OnPropertyChanged("SignLines"); }
        }

        private void InitSign()
        {
            SignLines.Add(new SignLineViewModel()
            {
                LineHeight = 150,
                SignHeight = 120,
                SignWidth = 120,
                Margin = new Thickness(50, 0, 50, 0),

                SignItems = new List<SignItemViewModel>()
                {
                    new SignItemViewModel()
                    {
                        Direction = Direction.Up
                    },
                    new SignItemViewModel()
                    {
                        Direction = Direction.Down
                    }
                },
                LeftText = new SignText()
                {
                    Text = "4.0",
                    Level = "(0.1)"
                },
                RightText = new SignText()
                {
                    Text = "3.7",
                    Level = "(0.05)"
                }
            });

            SignLines.Add(new SignLineViewModel()
            {
                LineHeight = 130,
                SignHeight = 100,
                SignWidth = 100,
                Margin = new Thickness(70, 0, 70, 0),

                SignItems = new List<SignItemViewModel>()
                {
                    new SignItemViewModel()
                    {
                        Direction = Direction.Up
                    },
                    new SignItemViewModel()
                    {
                        Direction = Direction.Down
                    }
                },
                LeftText = new SignText()
                {
                    Text = "4.1",
                    Level = "(0.12)"
                },
                RightText = new SignText()
                {
                    Text = "3.8",
                    Level = "(0.06)"
                }
            });
        }
    }
}
