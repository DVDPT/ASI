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
    public partial class ListSuppliers : Page
    {
        public ListSuppliers()
        {
            InitializeComponent();
        }

        private async void bObtainList_Click(object sender, RoutedEventArgs e)
        {
            SuppliersServiceClient supplierServiceClient = new SuppliersServiceClient();

            IEnumerable<SupplierModel> suppliers = await supplierServiceClient.AllSuppliersAsync();

            (DataContext as SupplierListViewModel).DataSource = suppliers.Select(c => new SupplierViewModel
            { 
                Number = c.Id,
                Name = c.Name,
                Address = c.Address
            });
        }
    }
}
