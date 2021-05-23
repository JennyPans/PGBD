using PopupStore.UI.ViewModels;
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

namespace PopupStore
{
    /// <summary>
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        EditProductViewModel editProductViewModel;
        public EditProduct(int productId)
        {
            InitializeComponent();
            InitDataContext(productId);
        }
        private void InitDataContext(int productId)
        {
            editProductViewModel = new EditProductViewModel
            {
                Product = BU.ProductService.GetProduct(productId),
                Prices = BU.PriceService.GetPrices()
            };
            DataContext = editProductViewModel;
        }
        private void Validate(object sender, RoutedEventArgs e)
        {
            int correctQuantity;
            try
            {
                if (labelName.Text.Length != 3)
                    throw new Exception("Le label doit être composé de 3 caractères !");
                DAL.DB.Product product = BU.ProductService.GetProductByLabel(name.Text);
                if (product != null && product.Id != editProductViewModel.Product.Id)
                    throw new Exception("Le label est déjà pris !");
                if (name.Text.Length == 0)
                    throw new Exception("Le produit doit avoir un nom !");
                product = BU.ProductService.GetProductByName(name.Text);
                if ( product != null && product.Id != editProductViewModel.Product.Id)
                    throw new Exception("Le nom est déjà pris !");
                if (!int.TryParse(quantity.Text, out correctQuantity))
                    throw new Exception("La quantité entrée n'est pas un nombre !");
                if (correctQuantity < 0)
                    throw new Exception("La quantité ne peut être inférieure à 0");
                if (price.SelectedItem == null)
                    throw new Exception("Vous devez choisir un prix !");
                DAL.DB.Price idPrice = price.SelectedItem as DAL.DB.Price;
                editProductViewModel.Product.Label = labelName.Text;
                editProductViewModel.Product.Name = name.Text;
                editProductViewModel.Product.Quantity = correctQuantity;
                editProductViewModel.Product.PriceId = idPrice.Id;
                BU.ProductService.UpdateProduct(editProductViewModel.Product.Id, 
                                                editProductViewModel.Product.Label, 
                                                editProductViewModel.Product.Name, 
                                                editProductViewModel.Product.PriceId,
                                                editProductViewModel.Product.Quantity);
            }
            catch (Exception exception)
            {
                System.Windows.MessageBox.Show(exception.Message);
            }
        }
    }
}
