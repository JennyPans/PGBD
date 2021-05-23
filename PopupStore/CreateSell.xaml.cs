using PopupStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
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
                SellProductRels = new ObservableCollection<DAL.DB.SellProductRel>(),
                Sell = new DAL.DB.Sell()
            };
            DataContext = createSellViewModel;
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            int correctQuantity;
            try
            {
                if (label.Text.Length != 3)
                    throw new Exception("Le label doit être composé de 3 caractères !");
                if (!Regex.IsMatch(label.Text, "^[A-Za-z]+$"))
                    throw new Exception("Le label doit être composé exclusivement de lettres !");
                if (!int.TryParse(quantity.Text, out correctQuantity))
                    throw new Exception("La quantité entrée n'est pas un nombre !");
                if (correctQuantity < 1)
                    throw new Exception("La quantité ne peut être inférieure à 1");
                DAL.DB.Product product = BU.ProductService.GetProductByLabel(label.Text);
                if (product == null)
                    throw new Exception($"Le produit {label.Text} n'existe pas !");
                if (product.Quantity < correctQuantity)
                    throw new Exception($"La quantité demandée est supérieure au stock ! (En stock : {product.Quantity})");
                if (!createSellViewModel.canAddProductInSell(product.Id))
                    throw new Exception("Le produit est déjà dans la liste !");
                DAL.DB.SellProductRel sellProductRel = new DAL.DB.SellProductRel();
                sellProductRel.Product = product;
                sellProductRel.ProductId = product.Id;
                sellProductRel.Quantity = correctQuantity;
                createSellViewModel.SellProductRels.Add(sellProductRel);
                createSellViewModel.calculTotal();
            }
            catch (Exception exception)
            {
                System.Windows.MessageBox.Show(exception.Message);
            }
        }

        private void Sell(object sender, RoutedEventArgs e)
        {
            try
            {
                if (createSellViewModel.SellProductRels.Count == 0)
                    throw new Exception("Il n'y a pas de produits indiqués !");
                if (paymentMode.SelectedIndex == -1)
                    throw new Exception("Vous devez choisir un mode de paiement !");
                createSellViewModel.CreateSell(paymentMode.SelectedIndex);
            }
            catch (Exception exception)
            {
                System.Windows.MessageBox.Show(exception.Message);
            }
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            DAL.DB.SellProductRel sellProductRel = (DAL.DB.SellProductRel)details.SelectedItem;
            createSellViewModel.removeSellProductRel(sellProductRel);
        }
    }
}