using ManagementApplication.ManagementService;
using ManagementApplication.ViewModel;
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

namespace ManagementApplication.Panels
{
    /// <summary>
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class PlaceOrder : Page
    {
        public PlaceOrder()
        {
            InitializeComponent();

            cSupplier.SelectionChanged += cSupplier_SelectionChanged;
            RefreshSuppliers();
        }

        void cSupplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cSupplier.SelectedIndex == -1) return;

            cSupplier.IsEnabled = false;
            bCreate.IsEnabled = false;
            cProduct.IsEnabled = false;

            int supplierId = (cSupplier.SelectedItem as Tuple<int, string>).Item1;
            RefreshProducts(supplierId);

            cSupplier.IsEnabled = true;
            bCreate.IsEnabled = true;
            cProduct.IsEnabled = true;
        }

        private async void bCreate_Click(object sender, RoutedEventArgs e)
        {
            int productId = (cProduct.SelectedItem as Tuple<int, string>).Item1;
            int supplierId = (cSupplier.SelectedItem as Tuple<int, string>).Item1;

            bCreate.IsEnabled = false;
            txtQuantity.IsEnabled = false;
            cSupplier.IsEnabled = false;
            cProduct.IsEnabled = false;

            ISuppliersService supplierService = new SuppliersServiceClient();
            await supplierService.OrderProductAsync(new OrderProductModel
            {
                ProductCode = productId,
                Supplier = supplierId,
                Quantity = int.Parse(txtQuantity.Text)
            });

            bCreate.IsEnabled = true;
            txtQuantity.IsEnabled = true;
            cSupplier.IsEnabled = true;
            cProduct.IsEnabled = true;

            cSupplier.SelectedIndex = -1;
            txtQuantity.Text = string.Empty;
            (DataContext as PlaceOrderViewModel).Products = new List<Tuple<int, string>>();
        }

        private void bRefresh_Click(object sender, RoutedEventArgs e)
        {
            bRefresh.IsEnabled = false;

            RefreshSuppliers();

            bRefresh.IsEnabled = true;
        }

        private async void RefreshSuppliers()
        {
            SuppliersServiceClient supplierServiceClient = new SuppliersServiceClient();

            IEnumerable<SupplierModel> suppliers = await supplierServiceClient.AllSuppliersAsync();

            (DataContext as PlaceOrderViewModel).Suppliers = suppliers.Select(s => Tuple.Create(s.Id, s.Name));
        }

        private async void RefreshProducts(int supplierId)
        {
            ProductServiceClient productServiceClient = new ProductServiceClient();

            IEnumerable<ProductModel> products = await productServiceClient.ProductsFromAsync(supplierId);

            (DataContext as PlaceOrderViewModel).Products = products.Select(p => Tuple.Create(p.Code, p.Name));
        }
    }
}
