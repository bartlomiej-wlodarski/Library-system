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
using Model.ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            BuyersViewModel buyersViewModel = (BuyersViewModel)DataContext;
            buyersViewModel.ChildWindow = new Lazy<IWindow>(() => new ProductWindow());
            buyersViewModel.MessageBoxShowDelegate = text => MessageBox.Show(text, "Hey", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
