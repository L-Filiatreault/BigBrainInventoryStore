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
    /// Interaction logic for General_Report_Window.xaml
    /// </summary>
    public partial class General_Report_Window : Window
    {   
        /// <summary>
        /// Interaction logic for General_Report_Window.xaml
        /// This Window allows the user to know the status of how many Items are inside the Inventory class
        /// As well states the different data fields of the Item class, such as item name, aisle number, minimum quantity, available
        /// quantity, category type, and the supplier
        /// </summary>
        public General_Report_Window(Inventory c)
        {
            InitializeComponent();
            dgInventoryList.ItemsSource = c.GenerateInventory(); //GenerateInventory() is a stand-in method for General Report for the Inventory class, it returns a list of Item objects and provide updated information
        }
    }
}
