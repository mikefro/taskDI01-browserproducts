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

        //List<Product> products = new List<Product>();

        public browserProducts()
        {
            InitializeComponent();
    

        }

        private string setLanguage()
        {


            string lng = engRadioButton.Checked != true ? "fr" : "en";
            return lng;
        }

        private void browserProducts_Load(object sender, EventArgs e)
        {
            engRadioButton.Checked = true;
            db.GetProducts(productsDataGridView,setLanguage());
        }

        private void fraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            db.GetProducts(productsDataGridView, setLanguage());
        }
    }
}
