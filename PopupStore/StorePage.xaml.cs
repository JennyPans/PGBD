using PopupStore.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PopupStore
{
    /// <summary>
    /// Interaction logic for StorePage.xaml
    /// </summary>
    public partial class StorePage : Page
    {
        StoreViewModel storeViewModel;
        public StorePage()
        {
            InitializeComponent();
            storeViewModel = new StoreViewModel
            {
                Store = BU.StoreService.GetStore()
            };
            this.DataContext = storeViewModel;
        }
    }
}
