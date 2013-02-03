using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.ViewModel
{
    public class PlaceOrderViewModel : INotifyPropertyChanged
    {
        private IEnumerable<Tuple<int, string>> _products;
        public IEnumerable<Tuple<int, string>> Products
        {
            get { return _products; }
            set { _products = value; NotifyPropertyChanged("Products"); }
        }

        private IEnumerable<Tuple<int, string>> _suppliers;
        public IEnumerable<Tuple<int, string>> Suppliers
        {
            get { return _suppliers; }
            set { _suppliers = value; NotifyPropertyChanged("Suppliers"); }
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
}
