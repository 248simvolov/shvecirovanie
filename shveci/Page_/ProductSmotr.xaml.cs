using shveci.DB_;
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

namespace shveci.Page_
{
    /// <summary>
    /// Логика взаимодействия для ProductSmotr.xaml
    /// </summary>
    public partial class ProductSmotr : Page
    {
        public ProductSmotr()
        {
            InitializeComponent();
            using (var context = new ProductoviiEntities())
            {
                dgsmotr.ItemsSource = context.Product.ToList();
            }
        }

        private void bred_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ProductoviiEntities())
            {
                if (dgsmotr.SelectedItems.Count >= 1)
                    this.NavigationService.Content = new DobRedProd(dgsmotr.SelectedItems.Cast<Product>().ToList()[0]);
                else
                    MessageBox.Show("КАК?");
            }
        }

        private void bdob_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Content = new DobRedProd();
        }
    }
}
