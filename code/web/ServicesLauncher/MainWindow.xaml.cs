using System.ServiceModel.Description;
using Management.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
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
using Ninject;
using Ninject.Extensions.Wcf;
using Notifications.Service;
using Orders.Service;

namespace ServicesLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private volatile bool _ordersServiceStatus = false;
        private volatile bool _managementServiceStatus = false;
        private volatile bool _notificationsServiceStatus = false;

        private ServiceHost _ordersHost = null;
        private ServiceHost _managementHost = null;
        private ServiceHost _notificationsHost = null;

        public MainWindow()
        {
            InitializeComponent();
            BrowseOrdersLink.RequestNavigate += HandleRequest;
            BrowseManagementLink.RequestNavigate += HandleRequest;
            BrowseNotificationsLink.RequestNavigate += HandleRequest;
        }

        private void HandleRequest(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void StartOrdersService_Click(object sender, RoutedEventArgs e)
        {
            _ordersServiceStatus = !_ordersServiceStatus;

            if (_ordersServiceStatus)
            {
                StartOrdersService.Content = "Stop";
                OrdersServiceStatus.Fill = new SolidColorBrush { Color = Color.FromRgb(0, 255, 0) };
                BrowseOrders.Visibility = Visibility.Visible;
                _ordersHost = new ServiceHost(typeof(OrdersService));
                _ordersHost.Open();

                BrowseOrdersLink.NavigateUri = _ordersHost.BaseAddresses.First();
                BrowseOrders.Text += _ordersHost.BaseAddresses.First().AbsoluteUri;

            }
            else
            {
                StartOrdersService.Content = "Start";
                OrdersServiceStatus.Fill = new SolidColorBrush { Color = Color.FromRgb(255, 0, 0) };
                BrowseOrders.Visibility = Visibility.Collapsed;

                _ordersHost.Close();
            }
        }

        private void StartManagementService_Click(object sender, RoutedEventArgs e)
        {
            _managementServiceStatus = !_managementServiceStatus;

            if (_managementServiceStatus)
            {
                StartManagementService.Content = "Stop";
                ManagementServiceStatus.Fill = new SolidColorBrush { Color = Color.FromRgb(0, 255, 0) };
                BrowseManagement.Visibility = Visibility.Visible;

                _managementHost = new ServiceHost(typeof(CustomerOrderReceiverService));
                _managementHost.Open();

                BrowseManagementLink.NavigateUri = _managementHost.BaseAddresses.First();
                BrowseManagement.Text += _managementHost.BaseAddresses.First().AbsoluteUri;
            }
            else
            {
                StartManagementService.Content = "Start";
                ManagementServiceStatus.Fill = new SolidColorBrush { Color = Color.FromRgb(255, 0, 0) };
                BrowseManagement.Visibility = Visibility.Collapsed;

                _managementHost.Close();
            }
        }

        private void StartNotificationsService_Click(object sender, RoutedEventArgs e)
        {
            _notificationsServiceStatus = !_notificationsServiceStatus;

            if (_notificationsServiceStatus)
            {
                StartNotificationsService.Content = "Stop";
                NotificationsServiceStatus.Fill = new SolidColorBrush { Color = Color.FromRgb(0, 255, 0) };
                BrowseManagement.Visibility = Visibility.Visible;

                _notificationsHost = new ServiceHost(typeof(NotificationService));
                _notificationsHost.Open();

                BrowseManagementLink.NavigateUri = _notificationsHost.BaseAddresses.First();
                BrowseManagement.Text += _notificationsHost.BaseAddresses.First().AbsoluteUri;
            }
            else
            {
                StartManagementService.Content = "Start";
                ManagementServiceStatus.Fill = new SolidColorBrush { Color = Color.FromRgb(255, 0, 0) };
                BrowseManagement.Visibility = Visibility.Collapsed;

                _notificationsHost.Close();
            }
        }


        protected override void OnClosed(EventArgs e)
        {
            if (_ordersHost != null)
            {
                using (_ordersHost)
                {
                    if (_ordersServiceStatus)
                    {
                        _ordersHost.Close();
                    }
                }
            }

            if (_managementHost != null)
            {
                using (_managementHost)
                {
                    if (_managementServiceStatus)
                    {
                        _managementHost.Close();
                    }
                }
            }

            if (_notificationsHost != null)
            {
                using (_notificationsHost)
                {
                    if (_notificationsServiceStatus)
                    {
                        _notificationsHost.Close();
                    }
                }
            }

            base.OnClosed(e);
        }
    }


}
