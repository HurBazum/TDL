using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TDL.Views.Icons
{
    /// <summary>
    /// Логика взаимодействия для CheckIcon.xaml
    /// </summary>
    public partial class CheckIcon : UserControl
    {
        public static readonly DependencyProperty SizeProperty = DependencyProperty
            .Register("Size", typeof(int), typeof(CheckIcon), new PropertyMetadata(100));
        
        public static readonly DependencyProperty ColorProperty = DependencyProperty
            .Register("Color", typeof(SolidColorBrush), typeof(CheckIcon), new PropertyMetadata(Brushes.Red));
        public int Size
        {
            get => (int)GetValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }

        public SolidColorBrush Color
        {
            get => (SolidColorBrush)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public CheckIcon()
        {
            InitializeComponent();
        }
    }
}