using PopupStore.ViewModels;
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
    /// Interaction logic for CreateSell.xaml
    /// </summary>
    public partial class CreateSell : Page
    {
        CreateSellViewModel createSellViewModel;
        public CreateSell()
        {
            InitializeComponent();
            InitDataContext();
        }
        private void InitDataContext()
        {
            createSellViewModel = new CreateSellViewModel
            {
                //PaymentMode = Enums.PaymentMode.Card
            };
            DataContext = createSellViewModel;
        }
    }
}
