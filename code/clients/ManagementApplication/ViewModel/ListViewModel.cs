using ManagementApplication.ManagementService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.ViewModel
{
    public class ListViewModel<T> : INotifyPropertyChanged
    {
        private IEnumerable<T> _dataSource;
        public IEnumerable<T> DataSource
        {
            get { return _dataSource; }
            set { _dataSource = value; NotifyPropertyChanged("DataSource"); } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class CustomerViewModel : INotifyPropertyChanged
    {
        private int _number;
        public int Number
        {
            get { return _number; }
            set { _number = value; NotifyPropertyChanged("Number"); }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; NotifyPropertyChanged("Address"); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; NotifyPropertyChanged("Email"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class CustomerListViewModel : ListViewModel<CustomerViewModel>
    {

    }

    public class SupplierViewModel : INotifyPropertyChanged
    {
        private int _number;
        public int Number
        {
            get { return _number; }
            set { _number = value; NotifyPropertyChanged("Number"); }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; NotifyPropertyChanged("Address"); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged("Name"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class SupplierListViewModel : ListViewModel<SupplierViewModel>
    {

    }

    public class OrderViewModel : INotifyPropertyChanged
    {
        private int _customer;
        public int Customer
        {
            get { return _customer; }
            set { _customer = value; NotifyPropertyChanged("Supplier"); }
        }

        private int _product;
        public int Product
        {
            get { return _product; }
            set { _product = value; NotifyPropertyChanged("Product"); }
        }

        private DateTime _orderDate;
        public DateTime OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; NotifyPropertyChanged("OrderDate"); }
        }
        
        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; NotifyPropertyChanged("Quantity"); }
        }

        private OrderState _state;
        public OrderState State
        {
            get { return _state; }
            set { _state = value; NotifyPropertyChanged("State"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class OrderListViewModel : ListViewModel<OrderViewModel>
    {

    }
}
