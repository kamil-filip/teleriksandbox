using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyWPFSandbox
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            InitMenuItems();
            InitUserToolbarItems();
            InitAdminToolbarItems();      
        }

        private void InitAdminToolbarItems()
        {
            AdminToolbarItems = new ObservableCollection<BaseMenuItemViewModel>()
            {
                new BaseMenuItemViewModel("Admin")
            };
        }

        private void InitUserToolbarItems()
        {
            var toolbarCommand = new DelegateCommand(x =>
            {
                Console.WriteLine(x);
            });

            UserToolbarItems = new ObservableCollection<BaseMenuItemViewModel>()
            {
                new BaseMenuItemViewModel("One",toolbarCommand),
                new BaseMenuItemViewModel("Two",toolbarCommand, false),
                new BaseMenuItemViewModel("Three",toolbarCommand)
            };
        }

        private void InitMenuItems()
        {

            Action a = () =>
            {
                MessageBox.Show("FX");
            };


            Action b = () =>
            {
                MessageBox.Show("Options");
            };

            var menuCommand = new DelegateCommand(x =>
                {
                    var vm = ((BaseMenuItemViewModel)x);

                    if(vm.Header == "FXReadonly" && vm.IsChecked)
                    {
                        a();
                    }
                    if(vm.Header == "OptionsReadOnly")
                    {
                        b();
                    }


                    Console.WriteLine(x);
                });


            MenuItems = new ObservableCollection<BaseMenuItemViewModel>()
            {
                new BaseMenuItemViewModel("File"){
                    SubItems = new ObservableCollection<BaseMenuItemViewModel>()
                    {
                        new BaseMenuItemViewModel("Exit")
                    }
                },
                new BaseMenuItemViewModel("Mode"){
                    SubItems = new ObservableCollection<BaseMenuItemViewModel>()
                    {
                        new BaseMenuItemViewModel("FXReadonly", menuCommand){IsCheckable = true, IsChecked = false },
                        new BaseMenuItemViewModel("OptionsReadOnly",menuCommand){IsCheckable = true,IsChecked = true},
                        new BaseMenuItemViewModel("IndicesReadonly",menuCommand, false){IsCheckable = true,IsChecked = true},
                    }
                },
                new BaseMenuItemViewModel("Help"){
                    SubItems = new ObservableCollection<BaseMenuItemViewModel>()
                    {
                        new BaseMenuItemViewModel("About"){}
                    }
                }
            };
        }

        public ObservableCollection<BaseMenuItemViewModel> MenuItems { get; set; }
        public ObservableCollection<BaseMenuItemViewModel> UserToolbarItems { get; set; }
        public ObservableCollection<BaseMenuItemViewModel> AdminToolbarItems { get; set; }
    }




}
