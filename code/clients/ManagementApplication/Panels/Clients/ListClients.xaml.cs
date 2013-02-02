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
    public partial class ListClients : Page
    {
        public ListClients()
        {
            InitializeComponent();
        }

        private async void bObtainList_Click(object sender, RoutedEventArgs e)
        {
            CustomerServiceClient customerServiceClient = new CustomerServiceClient();

            IEnumerable<CustomerModel> customers = await customerServiceClient.AllCustomersAsync();

            (DataContext as CustomerListViewModel).DataSource = customers.Select(c => new CustomerViewModel
            { 
                Number = c.Number, 
                Address = c.Address, 
                Email = c.EmailAddress 
            });
        }
    }
}
