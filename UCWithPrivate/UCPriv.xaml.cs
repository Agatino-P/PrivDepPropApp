using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace UCWithPrivate
{
    public partial class UCPriv : UserControl
    {
        private IEnumerable<int> _originalNumbers;



        private List<int> OriginalNumbers
        {
            get { return (List<int>)GetValue(OriginalNumbersProperty); }
            set { SetValue(OriginalNumbersProperty, value); }
        }
        public static readonly DependencyProperty OriginalNumbersProperty =
            DependencyProperty.Register("OriginalNumbers", typeof(List<int>), typeof(UCPriv),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public IEnumerable<int> Numbers
        {
            get { return (IEnumerable<int>)GetValue(NumbersProperty); }
            set { SetValue(NumbersProperty, value); }
        }
        public static readonly DependencyProperty NumbersProperty =
            DependencyProperty.Register("Numbers", typeof(IEnumerable<int>), typeof(UCPriv),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        private ObservableCollection<int> PrivNumbers
        {
            get { return (ObservableCollection<int>)GetValue(PrivNumbersProperty); }
            set { SetValue(PrivNumbersProperty, value); }
        }
        public static readonly DependencyProperty PrivNumbersProperty =
            DependencyProperty.Register("PrivNumbers", typeof(ObservableCollection<int>), typeof(UCPriv),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public int Val
        {
            get { return (int)GetValue(ValProperty); }
            set { SetValue(ValProperty, value); }
        }
        public static readonly DependencyProperty ValProperty =
            DependencyProperty.Register("Val", typeof(int), typeof(UCPriv), new FrameworkPropertyMetadata(12, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnValChanged));

        private static void OnValChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is UCPriv ucPriv))
            {
                return;
            }

            ucPriv.onValChangedValChanged((int)e.OldValue, (int)e.NewValue);
        }

        private void onValChangedValChanged(int oldValue, int newValue)
        {
            if (_originalNumbers != null)
            {
                Numbers = _originalNumbers.Select(n => n * Val);
                PrivNumbers = new ObservableCollection<int>(Numbers);

            }
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
            {
                return;
            }

            ucPriv.onTwiceValChangedValChanged((int)e.OldValue, (int)e.NewValue);
        }

        private void onTwiceValChangedValChanged(int oldValue, int newValue)
        {
            Val = newValue / 2;
        }

        public UCPriv()
        {
            PrivNumbers = new ObservableCollection<int>();
            InitializeComponent();
        }

        private void ucpr_Loaded(object sender, RoutedEventArgs e)
        {
            _originalNumbers = Numbers;
            OriginalNumbers = new List<int>(_originalNumbers);
            Val++;
            Val--;
        }
    }
}
