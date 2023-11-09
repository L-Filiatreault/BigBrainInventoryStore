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
using Final_Project_LF_EO.Models;

namespace Final_Project_LF_EO
{
    /*Final Project: Inventory Tracker
     * December 20, 2021
     * For: Aref Mourtada
     * By: Emma Oleszczuk (1678852)
     * Lauren Filiatreault (0474461)
     */

    /// <summary>
    /// Interaction logic for Update_Window.xaml
    /// </summary>
    public partial class Update_Window : Window
    {
        private Item itemToUpdate;
        public Update_Window()
        {
            InitializeComponent();
        }
        public Update_Window(Inventory currentInv, Item item)
        {
            InitializeComponent();

            itemToUpdate = item;
            this.DataContext = itemToUpdate;
            //make a list only with the name
            cmbItems.ItemsSource = currentInv.GenerateInventory();
            cmbItems.DisplayMemberPath = nameof(Item.ItemName);
            cmbCategories.ItemsSource = currentInv.GetListCategories();
        }
        private void cmbItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            itemToUpdate = cmbItems.SelectedItem as Item;
            if (itemToUpdate != null)
                this.DataContext = itemToUpdate;
        }


        //Call the setter for the enum
        private void cmbCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            itemToUpdate.SetCategoryChangeByIndex(cmbCategories.SelectedIndex);
        }

        private void btnUpdate_ConfirmUpdate(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
