using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using Microsoft.Win32;
using System.Windows;

namespace Final_Project_LF_EO.Models
{
    /*Final Project: Inventory Tracker
     * December 20, 2021
     * For: Aref Mourtada
     * By: Emma Oleszczuk (1678852)
     * Lauren Filiatreault (0474461)
     */

    /// <summary>
    /// The Item class is used for creating the Item objects that be used in the Inventory Tracker Project. It constructs Item objects, stores and modifies information about the Item object.
    /// </summary>
    public class Item
    {
        public enum Category //Category is an enum that stores information of each Item object's Category type
        {
            Fruits,
            Vegetables,
            Meats,
            Dairy,
            Gluten_Free,
            Cereal,
            Drinks,
            Frozen,
            Snacks,
            Chocolate,
            Bread,
            Desserts,
            Cleaning_Supplies,
            Extra
        }

        private const int ZERO = 0; //A const int to avoid magic Numbers        
        private string itemName; //A string variable used to store the Name of the Item
        private Category categoryItem; //A Category variable that is used to retrieve the value of th Category of the Item
        private int minimumQuantity; //An int variable used for applying minimum value for the current Item object
        private int availableQuantity; //An int variable used for applying available amount value for the current Item object
        private int aisleNumber; //An int variable used for the aisle number of the current Item object
        private string supplier; //A string variable used to store the Supplier of the Item

        #region CONSTRUCTOR
        /// <summary>
        /// A default constructor for the Item class, it initializes the Item object with dummy data
        /// </summary>
        public Item()
        {
            ItemName = "";
            CategoryItem = Category.Extra;
            MinimumQuantity = 1;
            AvailableQuantity = 0;
            AisleNumber = 1;
            Supplier = "";
        }

        /// <summary>
        /// The full constructor where the fields can be filled by the user if it's needed
        /// </summary>
        /// <param name="item"></param>
        /// <param name="category"></param>
        /// <param name="minNum"></param>
        /// <param name="availableNum"></param>
        /// <param name="aisleNum"></param>
        /// <param name="supplierName"></param>
        public Item(string item, Category category, int minNum, int availableNum, int aisleNum, string supplierName)
        {
            ItemName = item;
            CategoryItem = category;
            MinimumQuantity = minNum;
            AvailableQuantity = availableNum;
            AisleNumber = aisleNum;
            Supplier = supplierName;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// ItemName Property is an int type that gets and sets the value to the backing field of itemName
        /// </summary>
        public string ItemName
        {
            get
            {
                return itemName;
            }
            set
            {
                itemName = value;
            }
        }

        /// <summary>
        /// CategoryItem Property is a Category type that gets and sets the value to the backing field of categoryItem
        /// </summary>
        public Category CategoryItem
        {
            get
            {
                return categoryItem;
            }
            set
            {
                categoryItem = value;
            }
        }

        /// <summary>
        /// MinimumQuantity Property is a int type that gets and sets the value to the backing field of minimumQuantity, and has a Try-Catch to prevent the app from crashes 
        /// </summary>
        public int MinimumQuantity
        {
            get
            {
                return minimumQuantity;
            }
            set
            {
                try
                {
                    if (value < ZERO)
                        throw new Exception("Minimum quantity can't be less than 1");
                    else
                        minimumQuantity = value;
                }
                catch (Exception err)
                {

                    MessageBox.Show("Error! " + err.Message, "Minimum Quantity Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        /// <summary>
        /// AvailableQuantity Property is a int type that gets and sets the value to the backing field ofavailableQuantity, and has a Try-Catch to prevent the app from crashes 
        /// </summary>
        public int AvailableQuantity
        {
            get
            {
                return availableQuantity;
            }
            set
            {
                try
                {
                    if (value < ZERO)
                        throw new ArgumentException("Available quantity can't be negative", "availableQuantity");
                    else
                        availableQuantity = value;
                }
                catch (Exception err)
                {

                    MessageBox.Show("Error! " + err.Message, "Available Quantity Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// AisleNumber Property is a int type that gets and sets the value to the backing field of aisleNumber, and has a Try-Catch to prevent the app from crashes 
        /// </summary>
        public int AisleNumber
        {
            get
            {
                return aisleNumber;
            }
            set
            {
                try
                {
                    if (value <= ZERO)
                        throw new ArgumentException("Aisle number can't be less than or equal to 0", "aisleNumber");
                    else
                        aisleNumber = value;
                }
                catch (Exception err)
                {

                    MessageBox.Show("Error! " + err.Message, "Aisle Numebr Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Supplier Property is a string type that gets and sets the value to the backing field of supplier
        /// </summary>
        public string Supplier
        {
            get
            {
                return supplier;
            }
            set
            {
                supplier = value;
            }
        }

        /// <summary>
        /// WriteTOCSVFile method returns a comma-separated string that is used to write to CSV files like Excel.
        /// </summary>
        public string WriteTOCSVFile
        {
            get
            {
                return string.Format($"{ItemName}, {CategoryItem}, {MinimumQuantity}, {AvailableQuantity}, {AisleNumber}, {Supplier}");
            }

        }

        #endregion

        #region METHODS

        /// <summary>
        /// Creates an overridden format of ToString(_
        /// </summary>
        /// <returns>A formatted string </returns>
        public override string ToString()
        {
            return string.Format($"{ItemName}, {CategoryItem}, {MinimumQuantity}, {AvailableQuantity}, {AisleNumber}, {Supplier}");
        }

       

        /// <summary>
        /// SetCategoryChangeByIndex method takes in an int number which represents the index of the enum Category value it needs
        /// and searches in the foreach loop for a match with the 'name' variable. If a match is made then it calls the property of CategoryItem
        /// and sets it to that value to update the category of the current  Item object. It's used in the Add Window and Update Window of the app.
        /// </summary>
        /// <param name="number"></param>
        public void SetCategoryChangeByIndex(int number)
        {
            foreach (Item.Category name in Enum.GetValues(typeof(Item.Category)))
            {
                if ((int)name == number)
                {
                    this.CategoryItem = name;
                    break;
                }
            }
        }

        /// <summary>
        /// SetCategoryChangeWithString method takes in a string parameter which respresents the word it's looking for a match with the list of enum Category values, 
        /// and once a match is made it updates the current Item object's CategoryItem property. It's used in the ReadingItem() method in the Inventory class.
        /// </summary>
        /// <param name="word"></param>
        public void SetCategoryChangeWithString(string word)
        {
            word = word.Trim();
            foreach (Item.Category name in Enum.GetValues(typeof(Item.Category)))
            {
                if (name.ToString().ToLower() == word.ToLower())
                {
                    this.CategoryItem = name;
                    break;
                }
            }
        }
        #endregion
    }
}
