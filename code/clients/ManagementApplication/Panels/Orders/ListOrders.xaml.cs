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
    /// Interaction logic for ListClients.xaml
    /// </summary>
    public partial class ListOrders : Page
    {
        public ListOrders()
        {
            InitializeComponent();
        }

        private async void bObtainList_Click(object sender, RoutedEventArgs e)
        {
            CustomerOrderServiceClient orderServiceClient = new CustomerOrderServiceClient();

            IEnumerable<OrderModel> orders = await orderServiceClient.AllOrdersAsync();

            (DataContext as OrderListViewModel).DataSource = orders.Select(o => new OrderViewModel
            {
                Customer = o.CustomerId,
                Product = o.ProductCode,
                OrderDate = o.OrderDate,
                State = (OrderState) o.State,
                Quantity = o.Quantity
            });
        }
    }
}
