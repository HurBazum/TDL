using System.Windows;
using System.Windows.Controls;

namespace TDL.Views.Icons
{
    /// <summary>
    /// Логика взаимодействия для EditIcon.xaml
    /// </summary>
    public partial class EditIcon : UserControl
    {
        public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(int), typeof(EditIcon), new PropertyMetadata(100));

        public int Size
        {
            get => (int)GetValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }


        public EditIcon()
        {
            InitializeComponent();
        }
    }
}
