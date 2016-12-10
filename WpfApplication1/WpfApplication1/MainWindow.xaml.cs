using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using TEC.Core.Collections;

namespace WpfApplication1
{

    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty TwoNumberInfoProperty =
            DependencyProperty.Register("TwoNumberInfo", typeof(TwoNumberInfo), typeof(MainWindow), new PropertyMetadata(new TwoNumberInfo() { X = 0, Y = 0 }));
        public static readonly DependencyProperty TwoNumberInfoListProperty =
           DependencyProperty.Register("TwoNumberInfoList", typeof(ThreadSafeObservableCollection<TwoNumberInfo>), typeof(MainWindow));

        public MainWindow()
        {
            InitializeComponent();
            //this.Txt_Num1.DataContext = this.TwoNumberInfo;
            //this.Txt_Num2.DataContext = this.TwoNumberInfo;

        }
        private void Window_MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //this.TwoNumberInfo = new TwoNumberInfo();
            this.TwoNumberInfoList = new ThreadSafeObservableCollection<TwoNumberInfo>();

            new Thread(new ParameterizedThreadStart(obj =>
            {
                System.Threading.Thread.Sleep(3000);
                //模擬讀取時間
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    this.TwoNumberInfoList.Add(new TwoNumberInfo()
                    {
                        Operation = Operation.Divide,
                        X = 6,
                        Y = 10
                    });
                }));
                System.Threading.Thread.Sleep(3000);
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    this.TwoNumberInfoList.Add(new TwoNumberInfo()
                    {
                        Operation = Operation.Multiple,
                        X = 1,
                        Y = 2
                    });
                    this.TwoNumberInfo.X = 5;
                    this.TwoNumberInfo.Y = 10;
                    this.TwoNumberInfo.Operation = Operation.Add;
                }));
            })).Start();
        }

        private void Btn_Hear_Click(object sender, RoutedEventArgs e)
        {
            this.TwoNumberInfo.X++;
            this.TwoNumberInfo.Y++;
        }
        private void Btn_Hear2_Click(object sender, RoutedEventArgs e)
        {
            this.TwoNumberInfoList.Add(new TwoNumberInfo()
            {

            });
        }
        public TwoNumberInfo TwoNumberInfo
        {
            set
            {
                this.SetValue(MainWindow.TwoNumberInfoProperty, value);
            }
            get
            {
                return this.GetValue(MainWindow.TwoNumberInfoProperty) as TwoNumberInfo;
            }
        }
        public ThreadSafeObservableCollection<TwoNumberInfo> TwoNumberInfoList
        {
            set
            {
                this.SetValue(MainWindow.TwoNumberInfoListProperty, value);
            }
            get
            {
                return this.GetValue(MainWindow.TwoNumberInfoListProperty) as ThreadSafeObservableCollection<TwoNumberInfo>;
            }
        }


    }
}
