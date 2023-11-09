using System;
using System.Collections.Generic;
using System.Text;
using Final_Project_LF_EO.Models;
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
    /// Inventory class to keep track of the list of Items that a store might carry.
    /// </summary>
    public class Inventory
    {
        private readonly List<Item> currentItemInventory; //List of the items 
        private bool success; // A bool that is used to determine if operation was successful or not
        public List<string> listCategory; // A string List field to be able to access the Categories of the Item class
        private string savedFilePath = string.Empty; // A sttring field to store the path of the file
        private bool savedToFile; // A bool field to keep track of changes with saved/unsaved changes

        #region CONSTRUCTOR

        /// <summary>
        /// Default constructor that initializes the inventory to a list of Items and gets the list
        /// of the categories. 
        /// </summary>
        public Inventory()
        {
            currentItemInventory = new List<Item>();
            listCategory = GetListCategories();

        }
        #endregion

        #region GENERATING DATA FOR BINDING PURPOSES

        /// <summary>
        /// Function returns the data of the inventory. Allows for a public access to the information
        /// in the inventory. This is the stand-in for the method General Report()
        /// </summary>
        /// <returns> A list of items. </returns>
        public List<Item> GenerateInventory()
        {
            return currentItemInventory;
        }

        /// <summary>
        /// Function that loops through the inventory and compares the available quantity to the minimum quantity of items.
        /// It adds the item that are under the minimmum required quantity to a shopping list.
        /// </summary>
        /// <returns> A list of items under the minimum required quantity. </returns>
        public List<Item> ShoppingList()
        {
            List<Item> shoppingList = new List<Item>();

            for (int i = 0; i < currentItemInventory.Count; i++)
            {
                if (currentItemInventory[i].AvailableQuantity <= currentItemInventory[i].MinimumQuantity)
                {
                    shoppingList.Add(currentItemInventory[i]);
                }
            }
            return shoppingList;
        }
        #endregion


        #region METHODS THAT MANIPULATE DATA

        /// <summary>
        /// The AddItem method takes in a newly-created Item object, verifies it is an Item object and is not null,
        /// and then adds it to the currentItemInventory List. Used inside the Add Item window.
        /// </summary>
        /// <param name="newItem">An Item object</param>
        /// <returns>A bool</returns>
        public bool AddItem(Item newItem)
        {

            if (newItem is Item)
            {
                Item itemToBeAdded = newItem as Item;

                if (newItem == null)
                {
                    success = false;
                }
                else
                {
                    currentItemInventory.Add(itemToBeAdded);
                    savedToFile = false;
                    success = true;

                }
            }
            else
            {
                success = false;
            }

            return success;
        }

        /// <summary>
        /// Function validates the item inputted by user is in the inventory.
        /// If the item is there, it removes the item from the list.
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns> True if exists and remove it, otherwise return false</returns>
        public bool RemoveItem(Item newItem)
        {
            StringBuilder errorMessage = new StringBuilder();
            int indexOfItem = FindItemIndex(newItem);
            if (indexOfItem == -1)
            {
                errorMessage.AppendLine("Item does not exist in current inventory");
                MessageBox.Show(errorMessage.ToString(), "Item DNE", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                currentItemInventory.RemoveAt(indexOfItem);
                savedToFile = false;
                return true;
            }
        }

        /// <summary>
        /// Function validates the item to update is in the inventory.
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns>True, if the item is found in the inventory. False, if the item is null or not found in list. </returns>
        public bool UpdateItem(Item newItem)
        {
            if (newItem == null)
                return false;

            int indexOfItem = FindItemIndex(newItem);
            if (indexOfItem == -1)
                return false;
            else
            {
                savedToFile = false;
                return true;
            }
        }
     


        /// <summary>
        /// Function loops through list of items to verify if the name of the item that is being sent in 
        /// is in the the inventory.
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns> Index of the item in the list. </returns>
        public int FindItemIndex(Item newItem)
        {
            int indexFound = 0;
            for (int i = 0; i < currentItemInventory.Count; i++)
            {
                if (currentItemInventory[i].ItemName == newItem.ItemName)
                {
                    indexFound = i;
                    return indexFound;
                }
            }
            return -1;
        }

        #endregion

        #region METHODS DEALING WITH FILES 

        /// <summary>
        /// SaveFile() method saves the inventory data into a CSV file.
        /// </summary>
        public void SaveFile()
        {
            try
            {
                if (string.IsNullOrEmpty(savedFilePath))
                {
                    SaveFileDialog savingTheFile = new SaveFileDialog();


                    savingTheFile.Filter = "CSV Files|*.csv"; //Ensuring only CSV files are being saved with this program
                    if (savingTheFile.ShowDialog() == true)
                    {
                        savedFilePath = savingTheFile.FileName;
                    }
                    else
                        return;
                }
                WriteToFile();
            }
            catch (Exception error)
            {
                MessageBox.Show("Couldn't save data for the CSV file", error.Message);
            }

        }

        /// <summary>
        /// Function writes inventory data to a CSV file.
        /// </summary>
        public void WriteToFile()
        {

            if (!savedToFile)
            {
                try
                {
                    StringBuilder dataToSave = new StringBuilder();

                    foreach (Item itemToWrite in currentItemInventory)
                    {
                        dataToSave.AppendLine(itemToWrite.WriteTOCSVFile);

                    }

                    File.WriteAllText(savedFilePath, dataToSave.ToString());
                    savedToFile = true;

                }
                catch (UnauthorizedAccessException error)
                {
                    MessageBox.Show("Error! {0}. Use a relative path to the .exe file.", error.Message);
                }
                catch (PathTooLongException path)
                {
                    MessageBox.Show("Error! Filepath is too long to retrieve document. Exception Type: {0}.", path.Message);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error! Issue with saving data to file " + error.Message, "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Function to load a new file inventory into the application.
        /// </summary>
        public void LoadingFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            openFile.Filter = "CSV Files|*.csv"; //Filtering for only CSV files to be loaded in the program

            if (openFile.ShowDialog() == true)
            {
                savedFilePath = openFile.FileName;
                savedToFile = true;
                currentItemInventory.Clear();
                ReadingItem();
            }
        }

        /// <summary>
        /// ReadingItem() reads the data given from the file, splits the data from the commas, and parses it into the 
        /// object initialization of the Item class to make a brand new Item object. It's then added into the Inventory class' currentInventoryList.
        /// This method will continue this operation until the file input is null.
        /// </summary>
        private void ReadingItem()
        {
            StreamReader streamReading = null; //streamReading reads data from 'savedFilePath', set to null until it's in use
            string inputLine = ""; //A string which takes the parsed text from streamReading and helps with splitting the commas from the text
            List<string> dataCollection = new List<string>(); //A list which takes the data from inputLine and sets it to the properties of the Employee object

            try
            {
                streamReading = new StreamReader(savedFilePath); //Instantiating the streamReader to read from the file
                while ((inputLine = streamReading.ReadLine()) != null)//While input is still being received, the input will be transformed and inserted into properties of a new Employee object 
                {
                    dataCollection = inputLine.Split(',').ToList(); //Splitting the data from the comma's in the array, and making it into a List format                
                    Item loadedItem = new Item()
                    {
                        ItemName = dataCollection[0], //Filling in the name
                        MinimumQuantity = int.Parse(dataCollection[2]), //Filling the minimum quantity with parsed int data
                        AvailableQuantity = int.Parse(dataCollection[3]), //Filling the available quantity with parsed int data
                        AisleNumber = int.Parse(dataCollection[4]), //Filling the aisle number with parsed int data
                        Supplier = dataCollection[5], //Filling in the supplier
                    };

                    loadedItem.SetCategoryChangeWithString(dataCollection[1]); //This is for setting the Category property of the Item correctly using the Item-class method SetCategoryChangeWithString()
                    currentItemInventory.Add(loadedItem);

                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Couldn't load data from the CSV file", error.Message);
            }
        }


        /// <summary>
        /// Function checks the status of the inventory to see if the data is saved before opening
        /// a new file to ensure that no data is lost.
        /// </summary>
        /// <returns> True, if the inventory is already saved, empty or if user doesn't wish to save inventory
        /// False, if the inventory is a. </returns>
        public bool Checking()
        {
            if (savedToFile)
                return true;

            if (string.IsNullOrEmpty(savedFilePath) && currentItemInventory.Count == 0)
                return true;

            MessageBoxResult result =
            MessageBox.Show("Do you want to save changes?", "Unsaved changes", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
                return true;

            if (result == MessageBoxResult.Cancel)
                return false;

            if (result == MessageBoxResult.Yes)
                SaveFile();

            return savedToFile;
        }
        #endregion

        #region METHODS THAT GET LISTS FROM ENUMS
        /// <summary>
        /// Function loops through enums Category and adds to string list.
        /// </summary>
        /// <returns> List of string that holds the name of categories. </returns>
        public List<string> GetListCategories()
        {
            List<string> listCategory = new List<string>();

            foreach (string name in Enum.GetNames(typeof(Item.Category)))
            {
                listCategory.Add(name);

            }
            return listCategory;
        }

        #endregion
    }
}
