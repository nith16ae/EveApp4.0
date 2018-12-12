using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Interop;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;


/// <summary>
/// This namespace contains the entirety of the application. 
/// Add general stuff about the project here
/// </summary>
namespace EveOnlineApp
{
    /// <summary>
    /// 
    /// This is the CS-side (logic) of the MainPage (.xaml). It contains everything except the actual API call,
    /// the deserialization of the JSON objects into EveObjModel objects and the DataContract (the EveObjModel class)
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //these contain item entries that are ready to be displayed
        ObservableCollection<EveObjModel> dataList = new ObservableCollection<EveObjModel>(); //buy datalist
        ObservableCollection<EveObjModel> dataList2 = new ObservableCollection<EveObjModel>(); //sell datalist

        // instance of the APIHelper class
        APIHelper APIHelper = new APIHelper();

        // The List that contains the lists that we store the EveObjModel objects in
        List<List<EveObjModel>> importedListOfLists = new List<List<EveObjModel>>();

        // lists to contain optimised results
        List<EveObjModel> uniqueBuyList = new List<EveObjModel>();
        List<EveObjModel> uniqueSellList = new List<EveObjModel>();


        // Simply initializes the XAML components of the MainPage
        public MainPage()
        {
            this.InitializeComponent();
            searchBox.Visibility = Visibility.Collapsed;
            searchButton.Visibility = Visibility.Collapsed;
            restoreButton.Visibility = Visibility.Collapsed;
        }


        // This clickHandler is where the magic happens. Everything runs through this click.
        /// <summary>
        /// Author: Nicolai Thomsen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Btn_start_Click(object sender, RoutedEventArgs e)
        {
            btn_start.Content = "";
            searchBox.Text = "";
            searchBox.Visibility = Visibility.Collapsed;
            searchButton.Visibility = Visibility.Collapsed;
            ProgressRing.IsActive = true;
            ProgressRing.Visibility = Visibility.Visible;

            // Gets the region from the input text box on the MainPage.xaml. All regions are 8-digits, so
            // we check if the input is this is as well. If not, a ErrorDialog prompt is displayed.
            string selectedRegion = regionBox.Text;
            if (selectedRegion.TrimEnd(' ').Length == 8)
            {
                // Try to populate the importedListOfLists with the data we get through the API, via the APIHelper class.
                try
                {
                    importedListOfLists = await APIHelper.GetData(selectedRegion);
                    // If we do get data back, we populate the returnList with 2 lists, a buyList and a sellList. 
                    List<List<EveObjModel>> returnList = SplitIntoBuySellLists(importedListOfLists);
                    uniqueBuyList = CreateUniqueBuyList(returnList[0].ToList());
                    uniqueSellList = CreateUniqueSellList(returnList[1].ToList());
                    DisplayItems(uniqueBuyList, uniqueSellList);

                    ProgressRing.IsActive = false;
                    ProgressRing.Visibility = Visibility.Collapsed;
                    btn_start.Content = "Get Data";

                    searchBox.Visibility = Visibility.Visible;
                    searchButton.Visibility = Visibility.Visible;
                }

                catch (Exception ex)
                {
                    // If we don't get data back, we run an error prompt. 
                    if (importedListOfLists.Count <= 0)
                    {
                        DisplayErrorDialog("Could not load data from server", "It probably means that there is no data to show." + ex.Message);
                        btn_start.Content = "Get Data";
                    }
                }
            }

            else
                DisplayErrorDialog("No region detected", "You have to type in a region first!");
        }


        //adds EveObjects fromthe polished lists to the datalists, then displays them in the gridview elements
        /// <summary>
        /// Author: George Bushnell
        /// </summary>
        /// <param name="uniqueBuyList"></param>
        /// <param name="uniqueSellList"></param>
        private void DisplayItems(List<EveObjModel> uniqueBuyList, List<EveObjModel> uniqueSellList)
        {
            try
            {
                foreach (EveObjModel item in uniqueBuyList)
                {
                    dataList.Add(item);
                }

                foreach (EveObjModel item in uniqueSellList)
                {
                    dataList2.Add(item);
                }

                GridViewBuy.ItemsSource = dataList;
                GridViewSell.ItemsSource = dataList2;
            }

            //list is null
            catch (ArgumentNullException aNex)
            {
                DisplayErrorDialog("List is empty", "Please check if data is taken form the website:" + aNex.Message);
            }

            //general exception
            catch (Exception ex)
            {
                DisplayErrorDialog("Error", "Please check DisplayItems code:" + ex.Message);
            }
        }


        /// <summary>
        /// Author: Joseph Omengan
        /// Just a method to display a prompt. 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public async void DisplayErrorDialog(string title, string content)
        {
            ContentDialog ErrorDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await ErrorDialog.ShowAsync();
        }


        /// <summary>
        /// Author: Diana Abysheva
        /// Splits the objects into 2 lists, from the ~ 5 - 300 lists currently in importedList
        /// </summary>
        /// <param name="importedList"> contains the lists </param>
        /// <returns> List<List<EveObjModel>> returnList containing 2 lists: Buy and sell items </returns>
        public List<List<EveObjModel>> SplitIntoBuySellLists(List<List<EveObjModel>> importedList)
        {
            // The necessary instantiations of the lists needed
            List<EveObjModel> sellList = new List<EveObjModel>();
            List<EveObjModel> buyList = new List<EveObjModel>();
            List<List<EveObjModel>> returnList = new List<List<EveObjModel>>();

            try
            {
                // we run through every list...
                foreach (List<EveObjModel> item in importedList)
                {
                    // and every object in each list, in order to split into buy and sell objects
                    foreach (EveObjModel obj in item)
                    {
                        if (obj.is_buy_order)
                            buyList.Add(obj);
                        else
                            sellList.Add(obj);
                    }
                }

                // we then add the lists and return the list of lists
                returnList.Add(buyList);
                returnList.Add(sellList);
            }

            //check if the lists are not null
            catch (ArgumentNullException aNex)
            {
                DisplayErrorDialog("Could not create lists", "It probably means that there is no data to show:" + aNex.Message);
            }

            //data types do not match
            catch (ArgumentException aEx)
            {
                DisplayErrorDialog("Argument types do not match", "Please check if the arguments are a list:" + aEx.Message);
            }

            //general exception
            catch (Exception e)
            {
                DisplayErrorDialog("SplitIntoBuySellLists Error", "Please check the SplitIntoBuySellLists code:" + e.Message);
            }

            return returnList;
        }


        /// <summary>
        /// Logic author: Nicolai Thomsen
        /// Error handling author: Joseph Omengan
        /// This method create a list of unique items, i.e. the instance of each type_id that has the highest price
        /// </summary>
        /// <param name="buyList"> buyList. Contains somewhere between 1000 - 100,000 objects. </param>
        public List<EveObjModel> CreateUniqueBuyList(List<EveObjModel> buyList)
        {
            List<EveObjModel> uniqueBuyList = new List<EveObjModel>();

            try
            {
                uniqueBuyList = buyList.GroupBy(e => e.type_id).Select(g => g.Aggregate((e1, e2) => e1.price > e2.price ? e1 : e2)).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return uniqueBuyList;
        }
        //DEBUG: should the method above be try-catch'd like the method below?


        //DEBUG: line inside the try-block doesn't work in this try-catch case...it otherwise works fine without try-catch
        /// <summary>
        /// Author: Cliff Phan
        /// </summary>
        /// <param name="sellList"></param>
        /// <returns></returns>
        public List<EveObjModel> CreateUniqueSellList(List<EveObjModel> sellList)
        {
            List<EveObjModel> uniqueSellList = new List<EveObjModel>();
            try
            {
               uniqueSellList = sellList.GroupBy(e => e.type_id).Select(g => g.Aggregate((e1, e2) => e1.price < e2.price ? e1 : e2)).ToList();            
            }

            catch (MissingMethodException mme)
            {
                DisplayErrorDialog("Missing Methods to create a list", ":" + mme.Message);
            }

            catch (Exception ex)
            {
                DisplayErrorDialog("General exception", "Please check the CreateUniquBuyList code:" + ex.Message);
            }

            //DEBUG: temp fix - placing that line outside the try-catch
            return uniqueSellList;
        }


        /// <summary>
        /// Author: Nicolai Thomsen
        /// Code-behind method for the ComboBox containing all regions. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dropdown_regions_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = dropdown_regions_box.Items[dropdown_regions_box.SelectedIndex] as ComboBoxItem;
            regionBox.Text = comboBoxItem.Content.ToString();
            regionBox.Text = regionBox.Text.GetFirst(8);
        }


        //item search functionality
        /// <summary>
        /// Author: Cliff Phan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (searchBox.Text.Trim(' ').Length < 3)
                {
                    searchBox.Text = "";
                    searchBox.PlaceholderText = "Enter Item Type ID, please";
                }

                else if (dataList.Where(x => x.type_id.ToString() == searchBox.Text).ToList().Count < 1)
                {
                    searchBox.Text = "";
                    searchBox.PlaceholderText = "Items doesn't exist in current region";
                }

                else
                {
                    GridViewBuy.ItemsSource = dataList.Where(x => x.type_id.ToString() == searchBox.Text);
                    GridViewSell.ItemsSource = dataList2.Where(x => x.type_id.ToString() == searchBox.Text);
                    restoreButton.Visibility = Visibility.Visible;
                }
            }

            catch (ArgumentOutOfRangeException oOr)
            {
                DisplayErrorDialog("Input is out of range", ":" + oOr.Message);
            }

            catch (Exception ex)
            {
                DisplayErrorDialog("General exception", "Please check the searchButton_click code:" + ex.Message);
            }
        }


        //button that restores everything after an item search operation
        /// <summary>
        /// Author: Jpseph Omengan, Diana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restoreButton_Click(object sender, RoutedEventArgs e)
        {
            GridViewBuy.ItemsSource = dataList;
            GridViewSell.ItemsSource = dataList2;
            restoreButton.Visibility = Visibility.Collapsed;
        }

        private void Sell_label_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
