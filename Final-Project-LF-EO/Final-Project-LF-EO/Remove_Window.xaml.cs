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
    /// Interaction logic for Remove_Window.xaml
    /// This Window allows the user remove items from their current Inventory of item objects
    /// </summary>
    public partial class Remove_Window : Window
    {
        public Item removingItem; //Declaring an Item object to be used throughout the Remove class 

        /// <summary>
        /// This runs when the Remove_Window is launched
        /// </summary>
        /// <param name="c"></param>
        /// <param name="item"></param>
        public Remove_Window(Inventory currentInv, Item item)
        {
            InitializeComponent();

            removingItem = item; //Sending the pointer from one Item object to another
            this.DataContext = removingItem; //Using the current Item object to bind it's data to the display

        }

        /// <summary>
        /// When the user clicks on the Remove button after inputting the name of the Item they want to remove, the ValidateRemoveItemInput() is run to make the Item exists
        /// before closing the window fully
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateRemoveItemInput())
            {
                this.Close();
            }
        }

        /// <summary>
        /// ValidateRemoveItemInput() inspects that the textbox receiving input from the user is filled with the correct information to retrieve the item to remove
        /// </summary>
        /// <returns></returns>
        private bool ValidateRemoveItemInput()
        {
            StringBuilder errorMessage = new StringBuilder();

            if (string.IsNullOrEmpty(txtItemRemove.Text))
            {
                errorMessage.AppendLine("Name of the item is a required field");
            }

            if (string.IsNullOrEmpty(errorMessage.ToString()))
                return true;

            MessageBox.Show(errorMessage.ToString(), "Required item information", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
    }
}
