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
using Microsoft.Win32;


namespace Final_Project_LF_EO
{
    /*Final Project: Inventory Tracker
     * December 20, 2021
     * For: Aref Mourtada
     * By: Emma Oleszczuk (1678852)
     * Lauren Filiatreault (0474461)
     */

    /// <summary>
    /// Interaction logic for Item_Window.xaml
    /// This Window allows the user to add values which will help create an Item object for the Inventory Tracker
    /// </summary>
    /// 
    public partial class Item_Window : Window
    {
        //Creating an instance of Item to be used throughout the Item_Window class
        private Item addingItem;


        /// <summary>
        /// This runs when the Item_Window is launched
        /// </summary>
        /// <param name="c"></param>
        /// <param name="item"></param>
        public Item_Window(Inventory c, Item item)
        {
            InitializeComponent();

            cmbCategories.ItemsSource = c.GetListCategories(); //This sets a string List of the categories to be used in the Category combobox
            addingItem = item;
            this.DataContext = addingItem; //Using the current Item object to bind it's data to the display

        }

        /// <summary>
        /// When the user clicks on the Add button after inputting their data, the ValidateAddItemInput() is run to make sure all fields are filled 
        /// with the correct data, before closing the window fully
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateAddItemInput())
            {
                this.Close();
            }

        }


        #region Validation 

        /// <summary>
        /// ValidateAddItemInput() inspects each user-filled data fields for any improper data, and sends a warning when the data isn't
        /// correctly inserted
        /// </summary>
        /// <returns></returns>
        private bool ValidateAddItemInput()
        {
            StringBuilder errorMessage = new StringBuilder();

            if (string.IsNullOrEmpty(txtItem.Text))
            {
                errorMessage.AppendLine("Name of the item is a required field");
            }
            if (cmbCategories.SelectedIndex == -1)
            {
                errorMessage.AppendLine("Category is a required field");
            }
            if (!CheckingNumbers(txtAvaQty.Text))
            {
                errorMessage.AppendLine("Available Quantity is a required field");
            }
            if (!CheckingNumbers(txtMinQty.Text))
            {
                errorMessage.AppendLine("Minimum Quantity is a required field");
            }
            if (!CheckingNumbers(txtAisle.Text))
            {
                errorMessage.AppendLine("Aisle Number is a required field");
            }
            if (string.IsNullOrEmpty(txtSupplier.Text))
            {
                errorMessage.AppendLine("Supplier is a required field");
            }

            if (string.IsNullOrEmpty(errorMessage.ToString()))
                return true;

            MessageBox.Show(errorMessage.ToString(), "Required item information", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }


        /// <summary>
        /// CheckingNumbers() inspects that the given input is a number proper, and gives a false when it's anything but an int number
        /// </summary>
        /// <param name="checkIfInt"></param>
        /// <returns></returns>
        public static bool CheckingNumbers(string checkIfInt)
        {
            bool isNumber = false;
            int number = 0;

            if (Int32.TryParse(checkIfInt, out number))
            {
                isNumber = true;
            }

            return isNumber;
        }

        #endregion

        #region CATEGORY CHANGE UPDATE   

        /// <summary>
        /// cmbCategories_SelectionChanged is used when the user presses on the Combobox for Categories and selects a different value. It will send the value of selected
        /// index of the combobox to the method in the Item class to set the Item object's Category to the proper value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            addingItem.SetCategoryChangeByIndex(cmbCategories.SelectedIndex);
        }
        #endregion  
    }
}
