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
    /// Interaction logic for EditStore.xaml
    /// </summary>
    public partial class EditStore : Window
    {
        EditStoreViewModel editStoreViewModel;
        public EditStore()
        {
            InitializeComponent();
            InitDataContext();
        }
        private void InitDataContext()
        {
            editStoreViewModel = new EditStoreViewModel
            {
                Store = BU.StoreService.GetStore()
            };
            DataContext = editStoreViewModel;
        }
        private void Validate(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text.Length == 0)
                    throw new Exception("La boutique doit avoir un nom !");
                if (dateFrom.SelectedDate > dateTo.SelectedDate)
                    throw new Exception("La date de début ne peut être supérieure à la date de fin");
                editStoreViewModel.Store.Name = name.Text;
                editStoreViewModel.Store.PeriodFrom = (DateTime)dateFrom.SelectedDate;
                editStoreViewModel.Store.PeriodTo = (DateTime)dateTo.SelectedDate;
                BU.StoreService.UpdateStore(editStoreViewModel.Store.Id,
                                            editStoreViewModel.Store.Name,
                                            editStoreViewModel.Store.PeriodFrom,
                                            editStoreViewModel.Store.PeriodTo);
                this.Close();
            }
            catch (Exception exception)
            {
                System.Windows.MessageBox.Show(exception.Message);
            }
        }
    }
}
