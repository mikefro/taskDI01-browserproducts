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

namespace BrowserProducts
{
    public partial class ProductDetails : Form
    {

        Product productDetailed = new Product();
        DataAccess db = new DataAccess();
        string language;
        string productModelName;

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
            string description;

            products = db.GetNameProductsByProductModelName(productModelName, language);

            foreach(Product p in products)
            {
                nameComboBox.Items.Add(p.Name.ToString());
 /////////////////// Try to get better
                descriptionTextBox.Text = p.Description.ToString();
            }

            nameComboBox.SelectedIndex = 0;
           
        }

        private void ProductDetails_Load(object sender, EventArgs e)
        {



            LoadNameComboBoxAndDescription();
            //db.GetProduct(productModelName,language);
        }
    }
}
