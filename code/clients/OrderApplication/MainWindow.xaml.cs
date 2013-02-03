using ManagementApplication.ViewModel;
using OrderApplication.OrdersService;
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

namespace OrderApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void bCreate_Click(object sender, RoutedEventArgs e)
        {
            if (cProduct.SelectedIndex == -1 || string.IsNullOrEmpty(txtCustomerID.Text) || string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("There are fields missing.");
                return;
            }

            int productId = (cProduct.SelectedItem as Tuple<int, string>).Item1;

            bCreate.IsEnabled = false;
            txtQuantity.IsEnabled = false;
            cProduct.IsEnabled = false;

            OrdersServiceClient ordersServiceClient = new OrdersServiceClient();
            await ordersServiceClient.PlaceOrderAsync(new OrderModel
            {
                ProductCode = productId,
                CustomerId = int.Parse(txtCustomerID.Text),
                Quantity = int.Parse(txtQuantity.Text)
            });

            bCreate.IsEnabled = true;
            txtQuantity.IsEnabled = true;
            cProduct.IsEnabled = true;

            cProduct.SelectedIndex = -1;
            txtCustomerID.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            (DataContext as PlaceOrderViewModel).Products = new List<Tuple<int, string>>();
        }

        private void bRefresh_Click(object sender, RoutedEventArgs e)
        {
            bRefresh.IsEnabled = false;

            RefreshProducts();

            bRefresh.IsEnabled = true;
        }

        private async void RefreshProducts()
        {
            OrdersServiceClient ordersServiceClient = new OrdersServiceClient();

            IEnumerable<ProductModel> products = await ordersServiceClient.ListProductsAsync();

            (DataContext as PlaceOrderViewModel).Products = products.Select(p => Tuple.Create(p.Code, p.Name));
        }
    }
}
