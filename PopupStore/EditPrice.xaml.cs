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
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PopupStore
{
    /// <summary>
    /// Interaction logic for EditPrice.xaml
    /// </summary>
    public partial class EditPrice : Window
    {
        EditPriceViewModel editPriceViewModel;
        public EditPrice(int priceId)
        {
            InitializeComponent();
            InitDataContext(priceId);
        }
        private void InitDataContext(int priceId)
        {
            editPriceViewModel = new EditPriceViewModel
            {
                Price = BU.PriceService.GetPrice(priceId)
            };
            DataContext = editPriceViewModel;
        }
        private void PickColor(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var color = colorDialog.Color;
                priceColor.Background = new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
            }
        }
        private void Validate(object sender, RoutedEventArgs e)
        {
            try
            {
                int correctPriceValue;
                if (!int.TryParse(priceValue.Text, out correctPriceValue))
                    throw new Exception($"{priceValue.Text} n'est pas un nombre valide !");
                editPriceViewModel.Price.Value = correctPriceValue;
                editPriceViewModel.Price.Color = priceColor.Background.ToString();
                DAL.DB.Price price = BU.PriceService.GetPriceByValue(correctPriceValue);
                if ( price != null && price.Id != editPriceViewModel.Price.Id)
                    throw new Exception("Un prix avec cette valeur existe déjà !");
                price = BU.PriceService.GetPriceByColor(priceColor.Background.ToString());
                if (price != null && price.Id != editPriceViewModel.Price.Id)
                    throw new Exception("Un prix avec cette couleur existe déjà !");
                BU.PriceService.UpdatePrice(editPriceViewModel.Price.Id, editPriceViewModel.Price.Value, editPriceViewModel.Price.Color);
                this.Close();
            }
            catch (Exception exception)
            {
                System.Windows.MessageBox.Show(exception.Message);
            }
        }
    }
}
