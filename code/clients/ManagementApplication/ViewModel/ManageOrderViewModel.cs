using ManagementApplication.ManagementService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.ViewModel
{
    public class ManageOrderViewModel : INotifyPropertyChanged
    {
        private IEnumerable<Tuple<OrderModel, string>> _order;
        public IEnumerable<Tuple<OrderModel, string>> Orders
        {
            get { return _order; }
            set { _order = value; NotifyPropertyChanged("Orders"); }
        }

        private IEnumerable<OrderState> _orderStates;
        public IEnumerable<OrderState> OrderStates
        {
            get { return _orderStates; }
            set { _orderStates = value; NotifyPropertyChanged("OrderStates"); }
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
}
