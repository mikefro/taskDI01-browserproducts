using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
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
        int currentPage;

        private string finalQuery;
        private string queryProductsWithSellDates;
        private string queryOnlyAvaliableProducts;
        private int minPrice;
        private int maxPrice;
        private string priceClause;
        private string orderBy;

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
            LoadColorComboBox(colorComboBox);
            LoadStyleComboBox(styleComboBox);
            LoadProductLineComboBox(productLineComboBox);
            SetLanguage();
            ResetPaging();

            queryProductsWithSellDates = $"select distinct ProductModel.Name as Name, production.ProductDescription.Description as Description,Product.ListPrice, " +
                 $"Product.SellStartDate AS 'SellStartDate', Product.SellEndDate AS 'SellEndDate' " +
                       $"from Production.Product inner join Production.ProductSubcategory on Product.ProductSubcategoryID = ProductSubcategory.ProductSubcategoryID " +
                       $"inner join Production.ProductCategory on ProductSubcategory.ProductCategoryID = ProductCategory.ProductCategoryID " +
                       $"inner join Production.ProductModel on Product.ProductModelID = ProductModel.ProductModelID " +
                       $"inner join Production.ProductModelProductDescriptionCulture ON ProductModel.ProductModelID = ProductModelProductDescriptionCulture.ProductModelID " +
                       $"inner join production.ProductDescription on ProductModelProductDescriptionCulture.ProductDescriptionID = ProductDescription.ProductDescriptionID " +
                       $"where ProductModelProductDescriptionCulture.CultureID = '{language}' AND Product.ProductModelID is not null ";

            queryOnlyAvaliableProducts = $"select distinct ProductModel.Name as Name, production.ProductDescription.Description as Description,Product.ListPrice,Product.SellEndDate AS 'SellEndDate' " +
                     $"from Production.Product inner join Production.ProductSubcategory on Product.ProductSubcategoryID = ProductSubcategory.ProductSubcategoryID " +
                     $"inner join Production.ProductCategory on ProductSubcategory.ProductCategoryID = ProductCategory.ProductCategoryID " +
                     $"inner join Production.ProductModel on Product.ProductModelID = ProductModel.ProductModelID " +
                     $"inner join Production.ProductModelProductDescriptionCulture ON ProductModel.ProductModelID = ProductModelProductDescriptionCulture.ProductModelID " +
                     $"inner join production.ProductDescription on ProductModelProductDescriptionCulture.ProductDescriptionID = ProductDescription.ProductDescriptionID " +
                     $"where ProductModelProductDescriptionCulture.CultureID = '{language}' AND Product.ProductModelID is not null AND product.SellEndDate is null ";
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
            foreach (string cat in categories)
            {
                catComboBox.Items.Add(cat);
            }
        }

        //Load the styleComboBox with all avaliable styles
        public void LoadColorComboBox(ComboBox cb)
        {
            List<string> colors = db.GetColors();
            foreach (string color in colors)
            {
                if (color != null)
                    cb.Items.Add(color);
                else
                    cb.Items.Add("null");

            }
        }

        //Load the styleComboBox with all avaliable styles
        public void LoadStyleComboBox(ComboBox cb)
        {
            List<string> styles = db.GetStyles();
            foreach (string style in styles)
            {
                if (style != null)
                    cb.Items.Add(style);
                else
                    cb.Items.Add("null");
            }
        }

        //Load the productLineComboBox with all avaliable productLines 
        public void LoadProductLineComboBox(ComboBox cb)
        {
            List<string> ambits = db.GetProductLine();
            foreach (string ambit in ambits)
            {
                if (ambit != null)
                    cb.Items.Add(ambit);
                else
                    cb.Items.Add("null");
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

            //If the SelectIndexChanged doesn´t come from reset button or a recent search
            if (resetFilterButtonClicked == false)
            {
                subCatComboBox.Items.Clear();
                List<string> subCategories = db.GetSubCategories(catComboBox.SelectedItem.ToString()).ToList();

                foreach (string subCat in subCategories)
                {
                    subCatComboBox.Items.Add(subCat);
                }
            }
            //If the SelectIndexChanged comes from reset,
            //it will  clear Combobox (ResetFilter method switchs the variable boolean resetFilterButtonClicked)
            else 
            {
                subCatComboBox.SelectedIndex = -1;
                subCatComboBox.Items.Clear();
                resetFilterButtonClicked = false;
            }
        }

        private void productsForPageCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            productsPerPage = int.Parse(productsForPageCombobox.Text);
            numberOfPages = totalProducts / productsPerPage + 1;
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
            UpdateListView();
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            currentPage++;
            if (currentPage == numberOfPages - 1)
            {
                nextPageButton.Enabled = false;
            }
            previousPageButton.Enabled = true;
            UpdateListView();

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


        //apply the query with the values in categoryGroupBox and filterGroupBox; checking their values
        private void applyFilterButton_Click(object sender, EventArgs e)
        {
            
            if (avaliableCheckBox.Checked)
                finalQuery = queryOnlyAvaliableProducts;
            else
                finalQuery = queryProductsWithSellDates;
            MountingQuery();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string countquery = $"select count(*) from({finalQuery}) as counter";
                totalProducts = connection.Query<int>(countquery).FirstOrDefault();
            }

            totalProductsFoundLabel.Text = $" {totalProducts} products found";

            numberOfPages = totalProducts / int.Parse(productsForPageCombobox.Text) + 1;
            currentPage = 0;
            previousPageButton.Enabled = false;
            if (numberOfPages > 1)
                nextPageButton.Enabled = true;

            UpdateListView();
            ResetFilters();

        }

        private void MountingQuery()
        {
            //If categoryComboBox has selected some category property
            if (catComboBox.SelectedIndex != -1)
            {
                finalQuery += $"AND Production.ProductCategory.Name = '{catComboBox.SelectedItem.ToString()}'";
            }
            //If subCategoryComboBox has selected some subcategory property
            if (subCatComboBox.SelectedIndex != -1)
            {
                finalQuery += $"AND ProductSubcategory.Name = '{subCatComboBox.SelectedItem.ToString()}' ";
            }
            //If colorComboBox has selected some Color property set a color SQL clause
            if (colorComboBox.SelectedIndex != -1)
            {
                finalQuery += $" AND Product.Color = '{colorComboBox.SelectedItem.ToString()}' ";
            }
            //If productLineComboBox has selected some style property set a style SQL clause
            if (styleComboBox.SelectedIndex != -1)
            {
                finalQuery += $" AND Product.Style = '{styleComboBox.SelectedItem.ToString()}' ";
            }
            //If productLineComboBox has selected some productLine property set a productLine SQL clause
            if (productLineComboBox.SelectedIndex != -1)
            {
                finalQuery += $" AND Product.productLine = '{productLineComboBox.SelectedItem.ToString()}' ";
            }

            finalQuery += priceClause;

        }

        public void UpdateListView()
        {
            if (orderByNameRadioButton.Checked)
            {
                orderBy = "NAME ASC";
            }
            else if (lowPriceRadioButton.Checked)
            {
                orderBy = "LISTPRICE ASC";
            }
            else if (sellEndDateRadioButton.Checked)
            {
                orderBy = "SellEndDate ASC ";
            }

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                currentPageTotalPagesLabel.Text = $"{currentPage + 1} of {numberOfPages} pages";

                List<Product> products = new List<Product>();
                string pagingQuery = finalQuery + $"order by {orderBy} " +
                           $"Offset {productsPerPage * currentPage} rows " +
                           $"fetch next {productsPerPage} rows only";
                products = connection.Query<Product>(pagingQuery).ToList();

                productsListView.Items.Clear();
                foreach (Product p in products)
                {
                    if (avaliableCheckBox.Checked)
                        productsListView.Items.Add(p.Name, $"{p.Name} ----- {p.Description}", 0);
                    else
                    {
                        string dates = $"Selled from {p.SellStartDate.ToShortDateString()} to {p.VerifySellEndDate()}";

                        productsListView.Items.Add(p.Name,
                                $"{p.Name} --- {p.Description} {dates}", 0);
                    }
                }
            }
        }

        //Empty all select Index of the filter comboboxes and textbox prices
        private void ResetFilters()
        {
            resetFilterButtonClicked = true;
            catComboBox.SelectedIndex = -1;
            colorComboBox.SelectedIndex = -1;
            styleComboBox.SelectedIndex = -1;
            productLineComboBox.SelectedIndex = -1;
            minPriceTextBox.Text = "";
            maxPriceTextBox.Text = "";
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

        private void productsListView_DoubleClick(object sender, EventArgs e)
        {
            string selectedProduct = productsListView.SelectedItems[0].Name;
            ProductDetails detailsForm = new ProductDetails(selectedProduct, language);
            detailsForm.ShowDialog();

            if (detailsForm.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("The product has been updated");
            }
            else if (detailsForm.DialogResult == DialogResult.Abort)
            {
                MessageBox.Show("The changes have  not been saved");
            }

        }

        private void minPriceTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {            
            try
            {
                minPrice = int.Parse(minPriceTextBox.Text);

                if (minPrice < 0)
                {
                    throw new ArgumentException();          
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("It must be a NUMBER");
                minPriceTextBox.Text = "";
                minPriceTextBox.Focus();
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Only Positive Numbers please");
                minPriceTextBox.Text = "";
                minPriceTextBox.Focus();
            }

        }
        //Validating maxPrice with the 3 possible scenarios
        private void maxPriceTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
         
            try
            {
                maxPrice = int.Parse(maxPriceTextBox.Text);

                if (maxPrice < minPrice)
                {
                    throw new Exception();
                }
                if (maxPrice < 0) 
                {
                    throw new ArgumentException();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("It must be a NUMBER");
                maxPriceTextBox.Text = "";
                maxPriceTextBox.Focus();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Only Positive Numbers please");
                minPriceTextBox.Text = "";
                minPriceTextBox.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("The maxium price must be greater than minium price");
                maxPriceTextBox.Text = "";
                maxPriceTextBox.Focus();
            }
            finally
            {
                priceClause = $"AND product.ListPrice BETWEEN {minPrice} AND {maxPrice} ";
            }

        }
        //Simulates that user get the focus on searchGroupBox , NOT REALLY GOOD
        private void searchGroupBox_Enter(object sender, EventArgs e)
        {
            categoriesGroupBox.Enabled = false;
            filterGroupBox.Enabled = false;
            orderByGroupBox.Enabled = false;
        }
        //Simulates that the user leaves the focus on searchGroupBox, NOT REALLY GOOD
        private void searchGroupBox_Leave(object sender, EventArgs e)
        {
            categoriesGroupBox.Enabled = true;
            filterGroupBox.Enabled = true;
            orderByGroupBox.Enabled = true;
        }
    }
}




