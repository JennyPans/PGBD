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
using System.Windows.Shapes;

namespace PopupStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Price(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PricePage();
        }
        private void Product(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ProductPage();
        }
        private void Store(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new StorePage();
        }
        private void Sell(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new SellPage();
        }
        private void CreateSell(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new CreateSell();
        }
    }
}
