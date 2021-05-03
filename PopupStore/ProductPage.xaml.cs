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
using System.Windows.Shapes;

namespace PopupStore
{
    /// <summary>
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        ProductViewModel productViewModel;
        public ProductPage()
        {
            InitializeComponent();
            InitDataContext();
        }
        private void InitDataContext()
        {
            productViewModel = new ProductViewModel
            {
                Products = BU.ProductService.GetProducts(),
                Prices = BU.PriceService.GetPrices()
            };
            DataContext = productViewModel;
        }
        private void Create(object sender, RoutedEventArgs e)
        {
            int correctQuantity;
            try
            {
                if (labelName.Text.Length != 3)
                    throw new Exception("Le label doit être composé de 3 caractères !");
                if (BU.ProductService.GetProductByLabel(labelName.Text) != null)
                    throw new Exception("Le label est déjà pris !");
                if (name.Text.Length == 0)
                    throw new Exception("Le produit doit avoir un nom !");
                if (BU.ProductService.GetProductByName(name.Text) != null)
                    throw new Exception("Le nom est déjà pris !");
                if (!int.TryParse(quantity.Text, out correctQuantity))
                    throw new Exception("La quantité entrée n'est pas un nombre !");
                if (correctQuantity < 1)
                    throw new Exception("La quantité ne peut être inférieure à 1");
                if (price.SelectedItem == null)
                    throw new Exception("Vous devez choisir un prix !");
                DAL.DB.Price idPrice = price.SelectedItem as DAL.DB.Price;
                DAL.DB.Product product = new DAL.DB.Product();
                product.Label = labelName.Text;
                product.Name = name.Text;
                product.Quantity = correctQuantity;
                product.PriceId = idPrice.Id;
                BU.ProductService.CreateProduct(product);
                InitDataContext();
            }
            catch (Exception exception)
            {
                System.Windows.MessageBox.Show(exception.Message);
            }
        }
    }
}
