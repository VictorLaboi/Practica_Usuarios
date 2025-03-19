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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kanban.Views
{
    /// <summary>
    /// Lógica de interacción para Contro.xaml
    /// </summary>
    public partial class Contro : UserControl
    {


        public string TitleProperty
        {
            get { return (string)GetValue(TitlePropertys); }
            set { SetValue(TitlePropertys, value); }
        }

        // Using a DependencyProperty as the backing store for TitleProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitlePropertys =
            DependencyProperty.Register("TitleProperty", typeof(string), typeof(Contro), new PropertyMetadata(string.Empty));


        public Contro()
        {
            InitializeComponent();
        }

    }
}
