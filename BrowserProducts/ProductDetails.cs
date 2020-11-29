using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using BrowserProducts;
using System.Data.SqlTypes;

namespace BrowserProducts
{
    public partial class ProductDetails : Form
    {
        browserProducts bp = new browserProducts();
        Product productDetailed = new Product();
        DataAccess db = new DataAccess();
        string language;
        string productModelName;
        string productName;

        float standardCost;
        float listPrice;
        float weight;

        DateTime sellStartDate;
        DateTime sellEndDate;
        DateTime discontinuedDate;


        public ProductDetails()
        {
            InitializeComponent();
        }

        public ProductDetails(string productModelName,string language)
        {
            InitializeComponent();
            this.productModelName = productModelName;
            this.language = language;

        }

        //Load the combobox with the product names with the productmodelName selected in the previous form
        private void LoadNameComboBoxAndDescription()
        {

            List<Product> products = new List<Product>();

            products = db.GetNameProductsByProductModelName(productModelName, language);

            foreach(Product p in products)
            {
                nameComboBox.Items.Add(p.Name.ToString());
 /////////////////// Try to get better
                descriptionTextBox.Text = p.Description.ToString();
            }
        }

        //Load all the others property comboboxes
        private void LoadComboBoxes()
        {

            List<string> subCategories = db.GetAllSubCategories();
            foreach(string subCat in subCategories)
            {
                subCategoryComboBox.Items.Add(subCat);
            }

            List<string> classes = db.GetAllClasses();
            foreach(string classe in classes)
            {
                if (classe != null)
                    classComboBox.Items.Add(classe);
                else
                    classComboBox.Items.Add("null");
            }

            List<string> sizes = db.GetAllSizes();
            foreach (string size in sizes)
            {
                if (size != null)
                    sizeComboBox.Items.Add(size);
                else
                    sizeComboBox.Items.Add("null");
            }

            List<string> sizeUnits = db.GetAllSizeUnits();
            foreach(string sizeUnit in sizeUnits)
            {
                if (sizeUnit != null)
                    sizeUnitMeasureComboBox.Items.Add(sizeUnit);
                else
                    sizeUnitMeasureComboBox.Items.Add("null");
            }

            //reusing the methods of Browserproducts class
            bp.LoadColorComboBox(colorComboBox);
            bp.LoadProductLineComboBox(productLineComboBox);
            bp.LoadStyleComboBox(styleComboBox);
        }

        //Fill all the form fields with the Data of the doubleclicked product in main form
        private void FillProductFields(Product product)
        {
            productNumberTextBox.Text = product.ProductNumber;
            productModelIdTextBox.Text = product.ProductModelId.ToString();
            makeFlagCheckBox.Checked = product.MakeFlag != 0 ? true : false;
            finishedGoodsFlagCheckBox.Checked = product.FinishedGoodsFlag != 0 ? true : false;
            subCategoryComboBox.SelectedIndex = subCategoryComboBox.FindString(db.FromSubCatIdToSubCatName(product.ProductSubcategory));
            colorComboBox.SelectedIndex = colorComboBox.FindString(product.Color);
            daysToManufactureNumericUpDown.Value = product.DaysToManufacture;
            productLineComboBox.SelectedIndex = productLineComboBox.FindString(product.ProductLine);
            classComboBox.SelectedIndex = classComboBox.FindString(product.Class);
            styleComboBox.SelectedIndex = styleComboBox.FindString(product.Style);
            standarCostTextBox.Text = product.StandardCost.ToString();
            listPriceTextBox.Text = product.ListPrice.ToString();
            safetyStockLevelNumericUpDown.Value = product.SafetyStockLevel;
            reorderPointNumericUpDown.Value = product.ReorderPoint;
            sizeComboBox.SelectedIndex = sizeComboBox.FindString(product.Size);
            sizeUnitMeasureComboBox.SelectedIndex = sizeUnitMeasureComboBox.FindString(product.SizeUnitMeasure);
            weightTextBox.Text = product.Weight.ToString();
            weightUnitMeasureComboBox.SelectedIndex = weightUnitMeasureComboBox.FindString(product.WeightUnitMeasure);
            sellStartDateTextBox.Text = product.SellStartDate.ToString();
            sellEndDateTextBox.Text = product.SellEndDate.ToShortDateString();
            modifiedDateTextBox.Text = product.ModifiedDate.ToShortDateString();
            discontinuedDateTextBox.Text = product.DiscontinuedDate.ToShortDateString();       
        }

        //Enable or disable the edition of product´s properties
        private void EnabledOrDisableEdition(bool condition)
        {
            if (condition == false)
            {
                editOkButton.Text = "Edit";
                returnCancelButton.Text = "Return";
            }
            else
            { 
                editOkButton.Text = "Save ";
                returnCancelButton.Text = "Discard Changes";
            }

            editOkButton.Enabled = condition;


            foreach (Control x in productGroupBox.Controls)
            {
                if (x is TextBox || x is CheckBox)
                {
                    if (x.Name != "productNumberTextBox")
                    x.Enabled = condition;
                }
            }

            foreach (Control x in ambitGroupBox.Controls)
            {
                if (x is TextBox || x is CheckBox || x is ComboBox || x is NumericUpDown)
                {
                    x.Enabled = condition;
                }
            }

            foreach (Control x in productDatesGroupBox.Controls)
            {
                if (x is TextBox)
                {
                    x.Enabled = condition;
                }
            }

            foreach (Control x in productPriceSizeGroupBox.Controls)
            {
                if (x is TextBox || x is CheckBox || x is ComboBox || x is NumericUpDown)
                {
                    if (x.Text != "modifiedDateTextBox")  // modifiedDateTextBox will be automatically modified if there is an update
                          x.Enabled = condition;
                }
            }
        }

        private void ProductDetails_Load(object sender, EventArgs e)
        {
            EnabledOrDisableEdition(false);
            LoadNameComboBoxAndDescription();
            LoadComboBoxes();
        }

        private void nameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            productName = nameComboBox.SelectedItem.ToString();

            Product product = db.GetProduct(productName, language)[0];
            FillProductFields(product);
            editOkButton.Enabled = true;
        }

       
        private void editOkButton_Click(object sender, EventArgs e)
        {
            if (editOkButton.Text == "Edit")
            {
                EnabledOrDisableEdition(true);
            }
            // All the fields are correct and they assign to the object to do the update about it
            else
            {
                
                productDetailed.Name = nameComboBox.SelectedItem.ToString();
                productDetailed.Description = descriptionTextBox.Text;
                productDetailed.ProductNumber = productNumberTextBox.Text;
                productDetailed.ProductModelId = int.Parse(productModelIdTextBox.Text);

                if (makeFlagCheckBox.Checked)
                    productDetailed.MakeFlag = 1;
                else
                    productDetailed.MakeFlag = 0;

                if (finishedGoodsFlagCheckBox.Checked)
                    productDetailed.FinishedGoodsFlag = 1;
                else
                    productDetailed.FinishedGoodsFlag = 0;
//////////////TRYING 
               // productDetailed.ProductSubcategory = db.FromSubCatNameToSubCatId(subCategoryComboBox.SelectedItem.ToString());
                //productDetailed.Color = colorComboBox.SelectedItem.ToString();
                productDetailed.DaysToManufacture = (int)daysToManufactureNumericUpDown.Value;
                //productDetailed.ProductLine = productLineComboBox.SelectedItem.ToString();
                //productDetailed.Class = classComboBox.SelectedItem.ToString();
                //productDetailed.Style = styleComboBox.SelectedItem.ToString();
                productDetailed.StandardCost = standardCost;
                productDetailed.ListPrice = listPrice;
                productDetailed.SafetyStockLevel = (int)safetyStockLevelNumericUpDown.Value;
                productDetailed.ReorderPoint = (int)reorderPointNumericUpDown.Value;
                //productDetailed.Size = sizeComboBox.SelectedItem.ToString();
                //productDetailed.SizeUnitMeasure = sizeUnitMeasureComboBox.SelectedItem.ToString();
                productDetailed.Weight = weight;
                productDetailed.SellStartDate = sellStartDate = DateTime.ParseExact(sellStartDateTextBox.Text, "dd/MM/yyyy hh:mm:ss", null);
                productDetailed.SellEndDate =  DateTime.ParseExact("20/11/2019 00:00:00", "dd/MM/yyyy hh:mm:ss", null);
                productDetailed.DiscontinuedDate = DateTime.ParseExact("21/11/2019 00:00:00", "dd/MM/yyyy hh:mm:ss", null);
                productDetailed.ModifiedDate = DateTime.Now;

                //do the update from DataAccess Class
                db.UpdateProduct(productDetailed);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void returnCancelButton_Click(object sender, EventArgs e)
        {
            if (returnCancelButton.Text == "Return")
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            if (returnCancelButton.Text == "Discard Changes")
            {
                Product product = db.GetProduct(productName, language)[0];
                FillProductFields(product);
                EnabledOrDisableEdition(false);
                editOkButton.Enabled = true;
            }
            
        }
        //validating standardCost
        private void standarCostTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                standardCost = float.Parse(standarCostTextBox.Text);

                if (standardCost < 0) throw new ArgumentException();

            }
            catch(ArgumentException)
            {
                MessageBox.Show("The value must be positive");
                standarCostTextBox.Text = "";
                standarCostTextBox.Focus();

            }
            catch(FormatException)
            {
                MessageBox.Show("It must be a NUMBER");
                standarCostTextBox.Text = "";
                standarCostTextBox.Focus();
            }

        }
        //Validating listPrice
        private void listPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                listPrice = float.Parse(listPriceTextBox.Text);

                if (standardCost > listPrice)
                {
                    throw new Exception();
                }
                if (listPrice < 0)
                {
                    throw new ArgumentException();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("It must be a NUMBER");
                listPriceTextBox.Text = "";
                listPriceTextBox.Focus();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Only Positive Numbers please");
                listPriceTextBox.Text = "";
                listPriceTextBox.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("ATTENTION, IT MAY CAUSE LOST OF MONEY");
                listPriceTextBox.Focus();
            }
        }

        //Validating the weight
        private void weightTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                weight = float.Parse(weightTextBox.Text);

                if (weight < 0) throw new ArgumentException();

            }
            catch (ArgumentException)
            {
                MessageBox.Show("The value must be positive");
                weightTextBox.Text = "";
                weightTextBox.Focus();

            }
            catch (FormatException)
            {
                MessageBox.Show("It must be a NUMBER");
                weightTextBox.Text = "";
                weightTextBox.Focus();
            }
        }
        //Validating sellStartDate NOT WORKING 
        private void sellStartDateTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                sellStartDate = DateTime.ParseExact(sellStartDateTextBox.Text, "dd/MM/yyyy hh:mm:ss", null);
            }
            //not working....
            //catch (NullReferenceException)
            //{
            //    MessageBox.Show("Are you sure to leave the product without sell start date?");
            //}
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
                MessageBox.Show("Please use the format 'dd/MM/YYYY'");
                sellStartDateTextBox.Text = "";
                sellStartDateTextBox.Focus();
            }
        }
        //Validating sellEndDate NOT WORKING 
        private void sellEndDateTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                sellEndDate = DateTime.Parse(sellEndDateTextBox.Text);
                sellEndDate.ToShortDateString();

                if (sellEndDate < sellStartDate) throw new ArgumentException();
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
                MessageBox.Show("Please use the format 'dd/MM/YYYY'");
                sellStartDateTextBox.Text = "";
                sellStartDateTextBox.Focus();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("The sell end date must be greater than the sell start date");
            }
            
        }
        //Validating the product color 
        private void colorComboBox_Validated(object sender, EventArgs e)
        {
            try
            {
                productDetailed.Color = colorComboBox.SelectedItem.ToString();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("ArgumentNullException");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("NullReferenceException");
            }
        }
        //Validating the product Line 
        private void productLineComboBox_Validated(object sender, EventArgs e)
        {
            try
            {
                productDetailed.Class = classComboBox.SelectedItem.ToString();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("ArgumentNullException");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("NullReferenceException");
            }
        }
        //Validating the product style
        private void styleComboBox_Validated(object sender, EventArgs e)
        {
            try
            {
                productDetailed.Style = styleComboBox.SelectedItem.ToString();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("ArgumentNullException");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("NullReferenceException");
            }
        }
        //Validating the product size 
        private void sizeComboBox_Validated(object sender, EventArgs e)
        {
            try
            {
                productDetailed.Size = sizeComboBox.SelectedItem.ToString();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("ArgumentNullException");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("NullReferenceException");
            }
        }
        //Validating the product sizeUnitMeasure
        private void sizeUnitMeasureComboBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                productDetailed.SizeUnitMeasure = sizeUnitMeasureComboBox.SelectedItem.ToString();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("ArgumentNullException");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("NullReferenceException");
            }
        }
        //Validating the product weightUnitMeasure NOT WORKING( NOT GET TO RELATION BETWEEN sizeUnitMeasure and weightUnitMeasure
        private void weightUnitMeasureComboBox_Validated(object sender, EventArgs e)
        {
            try
            {
                productDetailed.WeightUnitMeasure = weightUnitMeasureComboBox.SelectedItem.ToString();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("ArgumentNullException");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("NullReferenceException");
            }
        }

        private void discontinuedDateTextBox_Validated(object sender, EventArgs e)
        {
            try
            {
                discontinuedDate = DateTime.Parse(discontinuedDateTextBox.Text);
                discontinuedDate.ToShortDateString();
            }
            catch (FormatException)
            {
                discontinuedDate = DateTime.Parse("1/1/1753");
            }
        }

        private void sellStartDateTextBox_Validated(object sender, EventArgs e)
        {
            try
            {
                sellEndDate = DateTime.Parse(sellEndDateTextBox.Text);
                sellEndDate.ToShortDateString();

                if (sellEndDate < sellStartDate) throw new ArgumentException();
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
                MessageBox.Show("Please use the format 'dd/MM/YYYY'");
                sellStartDateTextBox.Text = "";
                sellStartDateTextBox.Focus();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("The sell end date must be greater than the sell start date");
            }
        }

        private void subCategoryComboBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                productDetailed.ProductSubcategory = db.FromSubCatNameToSubCatId(subCategoryComboBox.SelectedItem.ToString());
            }
            catch(ArgumentNullException)
            {
                MessageBox.Show("A subcategory must be selected");
            }
        }
    }
}
