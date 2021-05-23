using PopupStore.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PopupStore
{
    /// <summary>
    /// Interaction logic for PricePage.xaml
    /// </summary>
    public partial class PricePage : Page
    {
        PriceViewModel priceViewModel;

        public PricePage()
        {
            InitializeComponent();
            InitDataContext();
        }

        private void InitDataContext()
        {
            priceViewModel = new PriceViewModel
            {
                Prices = BU.PriceService.GetPrices()
            };
            DataContext = priceViewModel;
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            try
            {
                int correctPriceValue;
                if (!int.TryParse(priceValue.Text, out correctPriceValue))
                    throw new Exception($"{priceValue.Text} n'est pas un nombre valide !");
                if (BU.PriceService.GetPriceByValue(correctPriceValue) != null)
                    throw new Exception("Un prix avec cette valeur existe déjà !");
                if (BU.PriceService.GetPriceByColor(priceColor.Background.ToString()) != null)
                    throw new Exception("Un prix avec cette couleur existe déjà !");
                DAL.DB.Price price = new DAL.DB.Price();
                price.Value = correctPriceValue;
                price.Color = priceColor.Background.ToString();
                BU.PriceService.CreatePrice(price);
                InitDataContext();
            }
            catch(Exception exception)
            {
                System.Windows.MessageBox.Show(exception.Message);
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = ((DAL.DB.Price)priceDataGrid.SelectedItem).Id;
                DAL.DB.Price price = BU.PriceService.GetPrice(id);
                if (price.Products.Count > 0)
                    throw new Exception("Le prix est associé à au moins un produit !");
                BU.PriceService.DeletePrice(price);
                InitDataContext();
            }
            catch(Exception exception)
            {
                System.Windows.MessageBox.Show(exception.Message);
            }
        }
        private void Edit(object sender, RoutedEventArgs e)
        {
            if (priceDataGrid.SelectedItem != null)
            {
                EditPrice editPrice = new EditPrice(((DAL.DB.Price)priceDataGrid.SelectedItem).Id);
                editPrice.Show();
            }
        }
        private void PickColor(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var color = colorDialog.Color;
                priceColor.Background = new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
            }
        }
    }
}
