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
    /// Interaction logic for SellPage.xaml
    /// </summary>
    public partial class SellPage : Page
    {
        SellViewModel sellViewModel;
        public SellPage()
        {
            InitializeComponent();
            InitDataContext();
        }

        private void InitDataContext()
        {
            sellViewModel = new SellViewModel
            {
                Sells = BU.SellService.GetSellsWithDetail()
            };
            this.DataContext = sellViewModel;
        }
    }
}
