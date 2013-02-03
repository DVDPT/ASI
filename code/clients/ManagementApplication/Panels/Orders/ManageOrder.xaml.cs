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
    /// Interaction logic for ManageOrder.xaml
    /// </summary>
    public partial class ManageOrder : Page
    {
        public ManageOrder()
        {
            InitializeComponent();

            cState.IsEnabled = false;
            cOrder.SelectionChanged += cOrder_SelectionChanged;
            RefreshOrders();

            (DataContext as ManageOrderViewModel).OrderStates = Enum.GetValues(typeof(OrderState)) as IEnumerable<OrderState>;
        }

        void cOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cOrder.SelectedIndex == -1)
            {
                cState.IsEnabled = false;
                return;
            }

            cOrder.IsEnabled = false;
            bUpdate.IsEnabled = false;
            cState.IsEnabled = false;

            OrderModel orderModel = (cOrder.SelectedItem as Tuple<OrderModel, string>).Item1;
            SetState(orderModel);

            cOrder.IsEnabled = true;
            bUpdate.IsEnabled = true;
            cState.IsEnabled = true;
        }

        private void SetState(OrderModel orderModel)
        {
            (DataContext as ManageOrderViewModel).State = (OrderState) orderModel.State;
            cState.IsEnabled = true;
        }

        private async void bUpdate_Click(object sender, RoutedEventArgs e)
        {
            OrderModel selectedOrder = (cOrder.SelectedItem as Tuple<OrderModel, string>).Item1;
            OrderState orderState = (OrderState)cState.SelectedItem;
            CustomerOrderServiceClient customerOrderClient = new CustomerOrderServiceClient();

            await customerOrderClient.ChangeOrderStateAsync(new OrderKeyModel
            {
                CustomerId = selectedOrder.CustomerId,
                ProductCode = selectedOrder.ProductCode,
                OrderDate = selectedOrder.OrderDate
            }, orderState);
        }

        private void bRefresh_Click(object sender, RoutedEventArgs e)
        {
            bRefresh.IsEnabled = false;

            RefreshOrders();

            bRefresh.IsEnabled = true;
        }

        private async void RefreshOrders()
        {
            CustomerOrderServiceClient customerOrderClient = new CustomerOrderServiceClient();

            IEnumerable<OrderModel> orders = await customerOrderClient.AllOrdersAsync();

            (DataContext as ManageOrderViewModel).Orders = orders.Select(s => Tuple.Create(s, string.Format("{0},{1} - {2}", s.ProductCode, s.CustomerId, s.OrderDate)));
        }
    }
}
