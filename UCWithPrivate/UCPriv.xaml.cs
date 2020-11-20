using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UCWithPrivate
{
    public partial class UCPriv : UserControl
    {


        public int Val
        {
            get { return (int)GetValue(ValProperty); }
            set { SetValue(ValProperty, value); }
        }
        public static readonly DependencyProperty ValProperty =
            DependencyProperty.Register("Val", typeof(int), typeof(UCPriv),new FrameworkPropertyMetadata(12, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,OnValChanged));

        private static void OnValChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is UCPriv ucPriv))
                return;
            ucPriv.onValChangedValChanged((int)e.OldValue , (int)e.NewValue);
        }

        private void onValChangedValChanged(int oldValue, int newValue)
        {
        }

        private int TwiceVal
        {
            get { return (int)GetValue(TwiceValProperty); }
            set { SetValue(TwiceValProperty, value); }
        }
        public static readonly DependencyProperty TwiceValProperty =
            DependencyProperty.Register("TwiceVal", typeof(int), typeof(UCPriv), new PropertyMetadata(4, OnTwiceValChanged));

        private static void OnTwiceValChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is UCPriv ucPriv))
                return;
            ucPriv.onTwiceValChangedValChanged((int)e.OldValue, (int)e.NewValue);
        }

        private void onTwiceValChangedValChanged(int oldValue, int newValue)
        {
            Val = newValue / 2;
        }

        public UCPriv()
        {
            InitializeComponent();
        }

        private void ucpr_Loaded(object sender, RoutedEventArgs e)
        {
            TwiceVal = Val * 2;
        }
    }
}
