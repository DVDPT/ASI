using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ManagementApplication
{
    public class NavigatePanelCommand : ICommand
    {
        private MainWindow _window;

        public NavigatePanelCommand(MainWindow window)
        {
            _window = window;
        }

        public bool CanExecute(object parameter)
        {
            return parameter is string;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Uri panel = new Uri(parameter as string, UriKind.Relative);

            _window.Panels.Navigate(panel);
        }
    }
}
