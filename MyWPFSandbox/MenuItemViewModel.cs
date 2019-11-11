using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyWPFSandbox
{
    public class BaseMenuItemViewModel : ViewModelBase
    {

        public BaseMenuItemViewModel(string header,ICommand onSelectCommand = null, bool isEnabled = true)
        {
            Header = header;
            OnSelectCommand = onSelectCommand;
            IsEnabled = isEnabled;
            SubItems = new ObservableCollection<BaseMenuItemViewModel>();
        }

        public bool IsCheckable { get; set; }

        private bool _isChecked;
        public bool IsChecked //{ get; set; }
        {
            get { return _isChecked; }
            set {
               _isChecked = value;
                OnPropertyChanged();
            } 
        }

        public bool IsEnabled
        {
            get; set;
        } 


        public string Header { get; set; }
        public ICommand OnSelectCommand { get; set; }

        public ObservableCollection<BaseMenuItemViewModel> SubItems { get; set; }
    }
}
