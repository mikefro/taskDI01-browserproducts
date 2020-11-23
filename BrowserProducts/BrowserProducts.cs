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
        List<Product> products = new List<Product>();
        string language = "en";

        int productsPerPage;
        int numberOfPages;
        int currentPage = 0;


        public browserProducts()
        {
            InitializeComponent();  
        }

        private void browserProducts_Load(object sender, EventArgs e)
        {
            SetListViewScrollVertically(productsListView);
            productsForPageCombobox.SelectedIndex = 0;
            productsPerPage = int.Parse(productsForPageCombobox.SelectedItem.ToString());
            numberOfPages = db.CountProducts("en") / productsPerPage;
            engRadioButton.Checked = true;
            db.GetProducts(productsListView, language, productsPerPage, currentPage);
            UpdateListView();
            db.GetCategories(catComboBox);
        }

        private void SetListViewScrollVertically(ListView lv)
        {
            lv.Scrollable = true;
            lv.View = View.Details;
            ColumnHeader header = new ColumnHeader();
            header.Text = "";
            header.Name = "col1";
            lv.Columns.Add(header);
            lv.HeaderStyle = ColumnHeaderStyle.None;
            header.Width = lv.Width - 50;
        }

        //set from radiobutton the choosen language for queries
        public void setLanguage()
        {
           language = engRadioButton.Checked != true ? "fr" : "en";
        }

        public void UpdateListView()
        {
            numberOfPages = db.CountProducts(language) / productsPerPage;
            currentPageTotalPagesLabel.Text = $"{currentPage + 1}  of {numberOfPages}";
        }



        private void fraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            setLanguage();
            db.GetProducts(productsListView,language,productsPerPage,currentPage);
            
        }

        private void catComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.GetProductsbyCategory(productsListView,catComboBox.SelectedItem.ToString(),language);
            subCatComboBox.Items.Clear();
            db.GetSubCategories(subCatComboBox, catComboBox.SelectedItem.ToString());
        }


        private void engRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            setLanguage();
            db.GetProducts(productsListView,language,productsPerPage,currentPage);
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

        private void productsForPageCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            productsPerPage = int.Parse(productsForPageCombobox.Text);
            numberOfPages = db.CountProducts(language) / productsPerPage + 1;
            int lastSelectIndex = catComboBox.SelectedIndex;
            catComboBox.SelectedIndex = -1;
            catComboBox.SelectedIndex = lastSelectIndex;
        }

        private void previousPageButton_Click(object sender, EventArgs e)
        {
            currentPage--;
            if (currentPage == 0)
            {
                previousPageButton.Enabled = false;
            }
            nextPageButton.Enabled = true;
            db.GetProducts(productsListView, language, productsPerPage, currentPage);
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            currentPage++;
            if (currentPage == numberOfPages - 1)
            {
                nextPageButton.Enabled = false;
            }
            previousPageButton.Enabled = true;
            db.GetProducts(productsListView, language, productsPerPage, currentPage);
        }
    }
}
