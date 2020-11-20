using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using BrowserProducts;


namespace BrowserProducts
{
    public class DataAccess
    {

        // method to getProducts into ListView by a stored procedure 
        public void GetProducts(ListView lv,string language)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string procedure = $"Production.spAllProducts '{language}'";

                List<Product> products = new List<Product>();
                products = connection.Query<Product>(procedure).ToList();
                foreach (Product p in products)
                {
                    lv.Items.Add(p.ToString());
                }
            }
        }
        
                //put all the categories of the products in a combobox
                public void GetCategories(ComboBox cb)
                {
                    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
                    {
                        string procedure = $"Production.spProductCategories";
                        List<string> categories;

                        categories = connection.Query<string>(procedure).ToList();
                        foreach (string cat in categories)
                        {
                            cb.Items.Add(cat);
                        }
                    }
                }

                //put all the subcategories of a category in a combobox with a categoryname passed by parameter
                public void GetSubCategories(ComboBox cb,string category)
                {
                    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
                    {
                        string procedure = $"Production.spProductSubCategories '{category}'";
                        List<string> subCategories;

                        subCategories = connection.Query<string>(procedure).ToList();
                        foreach (string subCat in subCategories)
                        {
                            cb.Items.Add(subCat);
                        }
                    }
                }

        //put all the products by choosen category from a categoryname passed by parameter
        public void GetProductsbyCategory(ListView lv, string category, string language)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string procedure = $"Production.spProductsByCategories '{category}','{language}'";
                List<Product> products = new List<Product>();
                products = connection.Query<Product>(procedure).ToList();
                lv.Items.Clear();
                foreach (Product p in products)
                {
                    lv.Items.Add(p.ToString());
                }
            }
        }

        //put all the products by choosen Subcategory from a categoryname passed by parameter
        public void GetProductsbySubcategory(ListView lv, string subcategory, string language)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string procedure = $"Production.spProductsBySubcategories '{subcategory}','{language}'";
                List<Product> products = new List<Product>();
                products = connection.Query<Product>(procedure).ToList();
                lv.Items.Clear();
                foreach (Product p in products)
                {
                    lv.Items.Add(p.ToString());
                }
            }
        }

        // method to get avaliable products into ListView by a stored procedure 
        public void GetAvaliableProducts(ListView lv, string language)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string procedure = $"Production.spAvaliableProducts '{language}'";

                List<Product> products = new List<Product>();
                products = connection.Query<Product>(procedure).ToList();
                lv.Items.Clear();
                foreach (Product p in products)
                {
                    lv.Items.Add(p.ToString());
                }
            }
        }
        // method to get all products with their sell start date and sell sell date into ListView by a stored procedure 
        public void GetProductsWithSellerDates(ListView lv, string language)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string procedure = $"Production.spAllProductsWithSellerDates '{language}'";

                List<Product> products = new List<Product>();
                products = connection.Query<Product>(procedure).ToList();
                lv.Items.Clear();
                foreach (Product p in products)
                {
                    lv.Items.Add(p.ToStringWithDate());
                }
            }
        }


    }

}

