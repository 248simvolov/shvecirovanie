using shveci.DB_;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для DobRedProd.xaml
    /// </summary>
    public partial class DobRedProd : Page
    {
        bool red = false;
        Product productG;
        public DobRedProd(Product product)
        {
            using (var context = new ProductoviiEntities())
            {
                InitializeComponent();
                productG = product;
                red = true;
                var type = context.ProductType.ToList();
                cbtype.ItemsSource = type;
                tbname.Text = product.Title;
                cbtype.Text = context.ProductType.Find(product.ProductTypeID).Title;
                tbart.Text = product.Image;
                tbdesc.Text = product.Description;
                tbppc.Text = product.ProductionPersonCount.ToString();
                tbpwn.Text = product.ProductionWorkshopNumber.ToString();
                tbmcfa.Text = product.MinCostForAgent.ToString();
            }
        }
        public DobRedProd()
        {
            using (var context = new ProductoviiEntities())
            {
                InitializeComponent();
                var type = context.ProductType.ToList();
                cbtype.ItemsSource = type;
            }
        }

        private void bprim_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new ProductoviiEntities())
                {
                        productG.Title = tbname.Text;
                        productG.ProductType.Title = cbtype.Text;
                        productG.Image= tbart.Text;
                        productG.Description = tbdesc.Text;
                        productG.ProductionPersonCount= Int32.Parse(tbppc.Text);
                        productG.ProductionWorkshopNumber=Int32.Parse(tbpwn.Text);
                        productG.MinCostForAgent=Int32.Parse(tbmcfa.Text);
                        context.Product.AddOrUpdate(productG);
                    context.SaveChanges();
                    if (red)
                        MessageBox.Show("Изменения приняты");
                    else
                        MessageBox.Show("Данные добавлены");
                    this.NavigationService.Content = new ProductSmotr();

                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
