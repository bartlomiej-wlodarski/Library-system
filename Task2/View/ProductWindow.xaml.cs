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
using Model;
using System.ComponentModel;

namespace View
{
    /// <summary>
    /// Logika interakcji dla klasy ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window, IWindow
    {
        public ProductWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            ProductViewModel productViewModel = (ProductViewModel)DataContext;
            productViewModel.MessageBoxShowDelegate = text => MessageBox.Show(text, "Hey", MessageBoxButton.OK, MessageBoxImage.Information);
        
        }
        protected override void OnClosing(CancelEventArgs e)    //makes window be reusable
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
