using ManagementApplication.ManagementService;
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
    public partial class AddClient : Page
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private async void bCreate_Click(object sender, RoutedEventArgs e)
        {
            CustomerServiceClient customerServiceClient = new CustomerServiceClient();

            txtAddress.IsEnabled = false;
            txtEmail.IsEnabled = false;
            bCreate.IsEnabled = false;

            try
            {
                await customerServiceClient.CreateCustomerAsync(new CreateCustomerModel
                {
                    Address = txtAddress.Text,
                    EmailAddress = txtEmail.Text
                });
                txtAddress.Text = string.Empty;
                txtEmail.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txtAddress.IsEnabled = true;
                txtEmail.IsEnabled = true;
                bCreate.IsEnabled = true;
            }

        }
    }
}
