﻿using System;
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
    /// Interaction logic for Shopping_Win.xaml
    /// This Window allows the user to know the status of which Items are in low quantity than the minimum quantity, and have to re-order for the store.
    /// As well states the different data fields of the Item class, such as item name, aisle number, minimum quantity, available
    /// quantity, category type, and the supplier
    /// </summary>
    public partial class Shopping_Win : Window
    {
        public Shopping_Win(Inventory d)
        {
            InitializeComponent();

            // Binding the data to display on the grid-list when item quantity is lower than minimum amount           
            lbShopping.ItemsSource = d.ShoppingList();
        }

    }
}
