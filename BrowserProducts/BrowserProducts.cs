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
        BindingList<Product> products = new BindingList<Product>();
        string language = "en";

        public browserProducts()
        {
            InitializeComponent();  
        }

        public void setLanguage()
        {
           language = engRadioButton.Checked != true ? "fr" : "en";
        }

        private void browserProducts_Load(object sender, EventArgs e)
        {
            engRadioButton.Checked = true;
            db.GetProducts(productsListView,language);
            db.GetCategories(catComboBox);
        }

        private void fraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            setLanguage();
            db.GetProducts(productsListView,language);
        }

       

        private void catComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.GetProductsbyCategory(productsListView,catComboBox.SelectedItem.ToString(),language);
            db.GetSubCategories(subCatComboBox, catComboBox.SelectedItem.ToString());
        }

        private void avaliableCheckBox_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void engRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            setLanguage();
            db.GetProducts(productsListView, language);
        }

        private void subCatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.GetProductsbySubcategory(productsListView, subCatComboBox.SelectedItem.ToString(), language);
        }

        private void avaliableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (avaliableCheckBox.Checked)
            {
                db.GetAvaliableProducts(productsListView,language);
            }
            else
            {
                db.GetProductsWithSellerDates(productsListView, language);
            }
        }
    }
}
