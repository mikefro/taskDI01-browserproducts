﻿using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserProducts
{
    public partial class browserProducts : Form
    {
        DataAccess db = new DataAccess();

        private string language;
        int totalProducts;
        int productsPerPage;
        int numberOfPages;
        int currentPage = 0;

        private string mainquery;
        private int minPrice;
        private int maxPrice;
        private string priceClause;
        private string colorClause;
        private string productLineClause;
        private string styleClause;

        // get if the filters has been reset
        private bool resetFilterButtonClicked = false;


        public browserProducts()
        {
            InitializeComponent();  

              
        }

        private void browserProducts_Load(object sender, EventArgs e)
        {
            
            productsForPageCombobox.SelectedIndex = 0;
            productsPerPage = int.Parse(productsForPageCombobox.SelectedItem.ToString());
            previousPageButton.Enabled = false;
            nextPageButton.Enabled = false;

            SetListViewScrollVertically();
            LoadCatComboBox();
            LoadColorComboBox();
            LoadStyleComboBox();
            LoadProductLineComboBox();
            SetLanguage();
            ResetPaging();
        }

        //Set the ListView for a vertical scroll
        private void SetListViewScrollVertically()
        {
            productsListView.Scrollable = true;
            productsListView.View = View.Details;
            ColumnHeader header = new ColumnHeader();
            header.Text = "";
            header.Name = "col1";
            productsListView.Columns.Add(header);
            productsListView.HeaderStyle = ColumnHeaderStyle.None;
            header.Width = productsListView.Width - 50;
        }

        //Load the catComboBox with all avaliables categories
        private void LoadCatComboBox()
        {
            List<string> categories = db.GetCategories();
            foreach( string cat in categories)
            {
                catComboBox.Items.Add(cat);
            }
        }

        //Load the styleComboBox with all avaliable styles
        private void LoadColorComboBox()
        {
            List<string> colors = db.GetColors();
            foreach (string color in colors)
            {
                if (color != null)
                    colorComboBox.Items.Add(color);
                else
                    colorComboBox.Items.Add("null");
                    
            }
        }

        //Load the styleComboBox with all avaliable styles
        private void LoadStyleComboBox()
        {
            List<string> styles = db.GetStyles();
            foreach (string style in styles)
            {
                if (style != null)
                    styleComboBox.Items.Add(style);
                else
                    styleComboBox.Items.Add("null");
            }
        }

        //Load the productLineComboBox with all avaliable productLines 
        private void LoadProductLineComboBox()
        {
            List<string> ambits = db.GetProductLine();
            foreach (string ambit in ambits)
            {
                if (ambit != null)
                    productLineComboBox.Items.Add(ambit);
                else
                    productLineComboBox.Items.Add("null");
            }
        }

        //set from radiobutton the choosen language for queries
        public void SetLanguage()
        {
           language = engRadioButton.Checked != true ? "fr" : "en";
        }

        private void ResetPaging()
        {
            numberOfPages = 0;
            currentPage = 0;
            currentPageTotalPagesLabel.Text = "";
        }

        public void UpdateListView(int total)
        {
            int totalProducts = total;
            numberOfPages = totalProducts / productsPerPage + 1;
            totalProductsFoundLabel.Text = $"{totalProducts} products found";
            currentPageTotalPagesLabel.Text = $"{currentPage + 1}  of {numberOfPages}";
            if (numberOfPages > 0)
            {
                previousPageButton.Enabled = false;
                nextPageButton.Enabled = true;
            }
        }

        private void fraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetLanguage();            
        }

        private void engRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetLanguage();
        }

        //When select a category product, load their subcategories con subCatComboBox
        private void catComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If the SelectIndexChanged comes from reset or not,it will load or clear Combobox in ResetFilter method
            if (resetFilterButtonClicked == false)
            {
                subCatComboBox.Items.Clear();
                List<string> subCategories = db.GetSubCategories(catComboBox.SelectedItem.ToString()).ToList();

                foreach (string subCat in subCategories)
                {
                    subCatComboBox.Items.Add(subCat);
                }
            }
        }
       
        private void productsForPageCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            productsPerPage = int.Parse(productsForPageCombobox.Text);
            numberOfPages = totalProducts / productsPerPage + 1;
            int lastSelectIndex = catComboBox.SelectedIndex;
            catComboBox.SelectedIndex = -1;
            catComboBox.SelectedIndex = lastSelectIndex;
            currentPageTotalPagesLabel.Text = $"{currentPage + 1}  of {numberOfPages}";
        }

        private void previousPageButton_Click(object sender, EventArgs e)
        {
            currentPage--;
            if (currentPage == 0)
            {
                previousPageButton.Enabled = false;
            }
            nextPageButton.Enabled = true;
            productsListView.Items.Clear();
            List<Product> products = new List<Product>();
            if (avaliableCheckBox.Checked == true)
            {
                products = db.GetAvaliableProducts(language, productsPerPage, currentPage);
                totalProducts = db.CountAvaliableProducts(language);
            }
            else
            {
                products = db.GetProductsWithSellerDates(language, productsPerPage, currentPage);
                totalProducts = db.CountProductsWithSellerDates(language);
            }
            foreach (Product p in products)
            {
                productsListView.Items.Add(p.ToStringWithDate());
            }
            currentPageTotalPagesLabel.Text = $"{currentPage + 1}  of {numberOfPages}";
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            currentPage++;
            if (currentPage == numberOfPages - 1)
            {
                nextPageButton.Enabled = false;
            }
            previousPageButton.Enabled = true;
            productsListView.Items.Clear();
            List<Product> products = new List<Product>();
            if (avaliableCheckBox.Checked == true)
            {
                products = db.GetAvaliableProducts(language, productsPerPage, currentPage);
                totalProducts = db.CountAvaliableProducts(language);
            }
            else
            {
                products = db.GetProductsWithSellerDates(language, productsPerPage, currentPage);
                totalProducts = db.CountProductsWithSellerDates(language);
            }
            foreach (Product p in products)
            {
                productsListView.Items.Add(p.ToStringWithDate());
            }
            currentPageTotalPagesLabel.Text = $"{currentPage + 1}  of {numberOfPages}";
        }

        
        private void searchProductButton_Click(object sender, EventArgs e)
        {
            if (searchProductTextBox.TextLength < 3)
            {
                // I want put a fast dialog or pop up
            }
            else
            {
                List<Product> products = new List<Product>();
                products = productNameRadioButton.Checked != true ? db.GetProductsByModelName(searchProductTextBox.Text) : db.GetProductsByProductName(searchProductTextBox.Text);
                productsListView.Items.Clear();
                if (products.Count == 0)
                {
                    MessageBox.Show("No products found");
                    searchProductTextBox.Text = "";
                }
                else
                {
                    foreach (Product p in products)
                    {
                        productsListView.Items.Add(p.ToString());
                    }
                }
                categoriesGroupBox.Enabled = true;
                filterGroupBox.Enabled = true;
                orderByGroupBox.Enabled = true;
            }
        }

        private void searchProductTextBox_TextChanged(object sender, EventArgs e)
        {
            if (searchProductTextBox.TextLength > 0)
            {
                categoriesGroupBox.Enabled = false;
                filterGroupBox.Enabled = false;
                orderByGroupBox.Enabled = false;
            }
        }
        //Simulates a Focus Event wrapping with categoriesGroupBox_Leave Event
        private void categoriesGroupBox_Enter(object sender, EventArgs e)
        {
            searchGroupBox.Enabled = false;
        }
        //Simulates a Focus Event wrapping with categoriesGroupBox_Enter Event
        private void categoriesGroupBox_Leave(object sender, EventArgs e)
        {
            searchGroupBox.Enabled = true;
        }

        private void avaliableCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {
            List<Product> products = new List<Product>();
            productsListView.Items.Clear();
            if (avaliableCheckBox.Checked == true)
            {
                products = db.GetAvaliableProducts(language, productsPerPage, currentPage);
                totalProducts = db.CountAvaliableProducts(language);
            }
            else
            {
                products = db.GetProductsWithSellerDates(language, productsPerPage, currentPage);
                totalProducts = db.CountProductsWithSellerDates(language);
            }
            UpdateListView(totalProducts);
            foreach (Product p in products)
            {
                productsListView.Items.Add(p.ToStringWithDate());
            }
        }
        //apply the query with the values in categoryGroupBox and filterGroupBox; checking their values
        private void applyFilterButton_Click(object sender, EventArgs e)
        {
            mainquery = $" select distinct production.ProductModel.Name as Name, " +
                $"production.ProductDescription.Description as Description " +
                $"from Production.Product inner join Production.ProductSubcategory on Product.ProductSubcategoryID = ProductSubcategory.ProductSubcategoryID " +
                $"inner join Production.ProductCategory on ProductSubcategory.ProductCategoryID = ProductCategory.ProductCategoryID " +
                $"inner join Production.ProductModel on Product.ProductModelID = ProductModel.ProductModelID " +   
                $"inner join Production.ProductModelProductDescriptionCulture ON ProductModel.ProductModelID = ProductModelProductDescriptionCulture.ProductModelID " +
                $"inner join production.ProductDescription on ProductModelProductDescriptionCulture.ProductDescriptionID = ProductDescription.ProductDescriptionID " +
                $"where Production.ProductModelProductDescriptionCulture.CultureID = '{language}' ";

            //If categoryComboBox has selected some category property
            if (catComboBox.SelectedIndex != -1)
            {
                mainquery += $"AND Production.ProductCategory.Name = '{catComboBox.SelectedItem.ToString()}'"; string categoryClause = $"AND Production.ProductCategory.Name = '{catComboBox.SelectedItem.ToString()}' ";
            }

            //If subCategoryComboBox has selected some subcategory property
            if (subCatComboBox.SelectedIndex != -1)
            {
                mainquery += $"AND ProductSubcategory.Name = '{subCatComboBox.SelectedItem.ToString()}' ";
            }


            //If colorComboBox has selected some Color property set a color SQL clause
            if (colorComboBox.SelectedIndex != -1)
            {
                colorClause = $" AND Product.Color = '{colorComboBox.SelectedItem.ToString()}'";
            }
            //If productLineComboBox has selected some style property set a style SQL clause
            if (styleComboBox.SelectedIndex != -1)
            {
                styleClause = $" AND Product.Style = '{styleComboBox.SelectedItem.ToString()}'";
            }
            //If productLineComboBox has selected some productLine property set a productLine SQL clause
            if (productLineComboBox.SelectedIndex != -1)
            {
                productLineClause = $" AND Product.productLine = '{productLineComboBox.SelectedItem.ToString()}'";
            }

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                List<Product> products = new List<Product>();
                products = connection.Query<Product>(mainquery).ToList();

                productsListView.Items.Clear();
                foreach (Product p in products)
                {
                    productsListView.Items.Add(p.ToString());
                }
            }
            ResetFilters();

        }

        //Empty all select Index of the filter comboboxes and textbox prices
        private void ResetFilters()
        {
            catComboBox.SelectedIndex = -1;
            subCatComboBox.SelectedIndex = -1;
            subCatComboBox.Items.Clear();
            colorComboBox.SelectedIndex = -1;
            styleComboBox.SelectedIndex = -1;
            productLineComboBox.SelectedIndex = -1;
            minPriceTextBox.Text = "";
            maxPriceTextBox.Text = "";
        }

        private void minPriceTextBox_Leave(object sender, EventArgs e)
        {
            int temp;
            //if minPriceTextBox is a number
            if (int.TryParse(minPriceTextBox.Text,out temp) )
            {   
                //If minPriceTextBox is lower than zero
                if (temp < 0)
                {
                    MessageBox.Show("Please, the minium price must be " +
                                     "equal to or greater than zero");
                    minPriceTextBox.Text = "";

                }
                else // It´s a number and it´s greater than zero
                {
                    minPrice = int.Parse(minPriceTextBox.Text);
                }
             }
            else //if minPriceTextBox is not a number
            {
                MessageBox.Show("Please type a number");
                minPriceTextBox.Text = "";
            }
        }

        private void MaxTextBox_Leave(object sender, EventArgs e)
        {
            int temp;
            //if maxPriceTextBox is a number
            if (int.TryParse(minPriceTextBox.Text, out temp))
            {
                // if minPrice is greater than maxPriceTextBox
                if (temp < minPrice)
                {
                    MessageBox.Show("The maxium price must be greater than minium price");
                }
                else //It´s a number and it´s greater than minprice
                {
                    maxPrice = int.Parse(maxPriceTextBox.Text);
                    priceClause = $"AND product.ListPrice BETWEEN {minPrice} AND {maxPrice} ";
                }
            }
            else  //if maxPriceTextBox is not a number
            { 
                MessageBox.Show("Please type a number");
                maxPriceTextBox.Text = "";
            }
        }
        //Simulates a onFocus Event
        private void filterGroupBox_Enter(object sender, EventArgs e)
        {
            searchGroupBox.Enabled = false;
        }
        //Simulates a LeaveOnFocus Event 
        private void filterGroupBox_Leave(object sender, EventArgs e)
        {
            searchGroupBox.Enabled = true;
        }
        // Throws the resetfilter method
        private void resetFilterButton_Click(object sender, EventArgs e)
        {
            resetFilterButtonClicked = true;
            ResetFilters();
        }
    }
}


