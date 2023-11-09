using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
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
    /// Interaction logic for MainWindow.xaml 
    /// </summary>
    public partial class MainWindow : Window
    {
        private Inventory currentItemInventory = new Inventory(); //Instantiating a new Inventory object to keep track of the Item objects 

        public MainWindow()
        {
            InitializeComponent();
            //binding the data to the List of the MainWindow.xaml for any changes made to the Inventory class, specifically the Item objects stored in it
            lbItems.ItemsSource = currentItemInventory.GenerateInventory(); //This sets the current Inventory collection to the ListBox of the main   

        }

        /// <summary>
        /// btnAdd_Click registers anytime a user clicks on the + button in the Main window and loads up the Item_Window.
        /// It creates a new Item object that will have its pointer passed to the Adding Window to fill the Item Object with the 
        /// values expected inside an Item object.
        /// It makes sure no default contructed Item is inserted into the Inventory class and refreshes the list when changes are made
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Item emptyItem = new Item();
            Item_Window addWindow = new Item_Window(currentItemInventory, emptyItem);
            addWindow.ShowDialog();

            if (emptyItem.ItemName != "")
            {
                currentItemInventory.AddItem(emptyItem);
            }

            lbItems.Items.Refresh();
        }


        /// <summary>
        /// btnRemove_Click registers anytime a user clicks on the X button in the Main window and loads up the Remove_Window.
        /// It creates a new Item object, and passes its pointer and the currentInventory's pointer to the Remove_Window location to update any changes made to the 
        /// objects in the classes.
        /// If the item is found it is then deleted from the current Inventory object with the RemoveItem() method inside the Inventory class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Item emptyDeletedItem = new Item();
            StringBuilder errorMessage = new StringBuilder();
            Remove_Window removeWindow = new Remove_Window(currentItemInventory, emptyDeletedItem);
            removeWindow.ShowDialog();

            if (emptyDeletedItem.ItemName != "")
            {
                if (currentItemInventory.FindItemIndex(emptyDeletedItem) != -1)
                {
                    currentItemInventory.RemoveItem(emptyDeletedItem);
                    lbItems.Items.Refresh();
                }
                else
                {
                    errorMessage.AppendLine("Item does not exist in current inventory");
                    MessageBox.Show(errorMessage.ToString(), "Item DNE", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }


        /// <summary>
        /// btnReport_Click registers anytime a user clicks on the General Report button in the Main and loads up the General_Report_Window window. It remains open 
        /// Until the user closes it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            General_Report_Window reportWindow = new General_Report_Window(currentItemInventory);
            reportWindow.Show();
        }


        /// <summary>
        /// btnShopping_Clickr registers anytime a user clicks on the shopping list button in the Main and loads up the Shopping_Win window. It remains open
        /// Until the user closes it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShopping_Click(object sender, RoutedEventArgs e)
        {
            Shopping_Win shoppingList = new Shopping_Win(currentItemInventory);
            shoppingList.ShowDialog();
        }


        /// <summary>
        /// btnLoad_Click registers anytime a user clicks on the load button in the Main, and calls up the method LoadingFile(); from the Inventory class
        /// to load the proper CSV file, get data to create Item objects to add to the Inventory class instance and display the objects on the Main Window's list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentItemInventory.LoadingFile();
            }
            catch (Exception error)
            {
                MessageBox.Show($"Error trying to load from file {error} ", "Couldn't load file ", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            lbItems.Items.Refresh();
        }

        /// <summary>
        /// btnSave_Click registers a click from the user and enables the Save() method inside the Inventory class to save the current data in the app.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            currentItemInventory.SaveFile();
        }

        /// <summary>
        /// In case the user closes the app window without saving any of the changes they made, the app checks if any changes have been made and if so
        /// displays apop-up menu asking the user if they want to save their changes or not. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_InCaseUserDidntSave(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !currentItemInventory.Checking();
        }

        /// <summary>
        /// lbItems_SelectionChanged displays Item object updates on the Listbox of the Main 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //StringBuilder errorMessage = new StringBuilder();
            Item itemToUpdate = lbItems.SelectedItem as Item;

            if (itemToUpdate != null)
            {
                Update_Window updateWindow = new Update_Window(currentItemInventory, itemToUpdate);
                updateWindow.ShowDialog();

                currentItemInventory.UpdateItem(itemToUpdate);                
                lbItems.Items.Refresh();
            }
        }
    }
}
