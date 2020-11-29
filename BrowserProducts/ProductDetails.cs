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
            sellStartDateTextBox.Text = product.SellStartDate.ToShortDateString();
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
            //if (editOkButton.Text == "Save")
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

                productDetailed.ProductSubcategory = subCategoryComboBox.FindString(db.FromSubCatIdToSubCatName(productDetailed.ProductSubcategory));
                //productDetailed.Color = colorComboBox.SelectedItem.ToString();
                productDetailed.DaysToManufacture = (int)daysToManufactureNumericUpDown.Value;
                productDetailed.ProductLine = productLineComboBox.SelectedItem.ToString();
                try
                {
                    productDetailed.Class = classComboBox.SelectedItem.ToString();
                }
                catch (NullReferenceException nre)
                {
                    productDetailed.Class = "";
                }
                productDetailed.Style = styleComboBox.SelectedItem.ToString();
                productDetailed.StandardCost = float.Parse(standarCostTextBox.Text);
                productDetailed.ListPrice = float.Parse(listPriceTextBox.Text);
                productDetailed.SafetyStockLevel = (int)safetyStockLevelNumericUpDown.Value;
                productDetailed.ReorderPoint = (int)reorderPointNumericUpDown.Value;
                productDetailed.Size = sizeComboBox.SelectedItem.ToString();
                productDetailed.SizeUnitMeasure = sizeUnitMeasureComboBox.SelectedItem.ToString();
                productDetailed.Weight = float.Parse(weightTextBox.Text);
                productDetailed.SellStartDate = DateTime.Parse(sellStartDateTextBox.Text);
                productDetailed.SellEndDate = DateTime.Parse(sellEndDateTextBox.Text);
                productDetailed.ModifiedDate = DateTime.Parse(modifiedDateTextBox.Text);
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

        private void standarCostTextBox_Validating(object sender, CancelEventArgs e)
        {


        }
    }
}
