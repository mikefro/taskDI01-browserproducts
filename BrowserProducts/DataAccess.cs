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


namespace BrowserProducts
{
    public class DataAccess
    {

        //return all the categories of the products
        public List<string> GetCategories()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string procedure = $"Select ProductCategory.Name from AdventureWorks2016.Production.ProductCategory;";
                List<string> categories;

                categories = connection.Query<string>(procedure).ToList();
                return categories;
            }
        }

        //returns the subcategories with a given category passed by parameter
        public List<string> GetSubCategories(string category)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string sql = $"select productsubcategory.Name from Production.ProductSubcategory " +
                             $"inner join Production.ProductCategory on ProductCategory.ProductCategoryID = ProductSubcategory.ProductCategoryID " +
                             $"where '{category}' = Productcategory.Name";
                List<string> subCategories;

                subCategories = connection.Query<string>(sql).ToList();
                return subCategories;
            }
        }
        //Get the total of avaliables products
        public int CountAvaliableProducts(string language)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string sql = $"select count(*) from (select distinct ProductModel.Name as Name, production.ProductDescription.Description as Description " +
                                   $"from Production.Product inner join Production.ProductSubcategory on Product.ProductSubcategoryID = ProductSubcategory.ProductSubcategoryID " +
                                   $"inner join Production.ProductCategory on ProductSubcategory.ProductCategoryID = ProductCategory.ProductCategoryID " +
                                   $"inner join Production.ProductModel on Product.ProductModelID = ProductModel.ProductModelID " +
                                   $"inner join Production.ProductModelProductDescriptionCulture ON ProductModel.ProductModelID = ProductModelProductDescriptionCulture.ProductModelID " +
                                   $"inner join production.ProductDescription on ProductModelProductDescriptionCulture.ProductDescriptionID = ProductDescription.ProductDescriptionID " +
                                   $"where ProductModelProductDescriptionCulture.CultureID = '{language}' AND Product.ProductModelID is not null AND product.SellEndDate is null) as counter;";

               int total = connection.Query<int>(sql).FirstOrDefault();
                return total;
            }
        }
        // returns only the avaliable products
        public List<Product> GetAvaliableProducts(string language, int productsPerPage, int currentPage)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string sql = $"select distinct ProductModel.Name as Name, production.ProductDescription.Description as Description " +
                                   $"from Production.Product inner join Production.ProductSubcategory on Product.ProductSubcategoryID = ProductSubcategory.ProductSubcategoryID " +
                                   $"inner join Production.ProductCategory on ProductSubcategory.ProductCategoryID = ProductCategory.ProductCategoryID " +
                                   $"inner join Production.ProductModel on Product.ProductModelID = ProductModel.ProductModelID " +
                                   $"inner join Production.ProductModelProductDescriptionCulture ON ProductModel.ProductModelID = ProductModelProductDescriptionCulture.ProductModelID " +
                                   $"inner join production.ProductDescription on ProductModelProductDescriptionCulture.ProductDescriptionID = ProductDescription.ProductDescriptionID " +
                                   $"where ProductModelProductDescriptionCulture.CultureID = '{language}' AND Product.ProductModelID is not null AND product.SellEndDate is null " +
                                   $"order by ProductModel.Name " +
                                   $"Offset {productsPerPage * currentPage} rows " +
                                   $"fetch next {productsPerPage} rows only";

                List<Product> products = new List<Product>();
                products = connection.Query<Product>(sql).ToList();
                return products;
            }
        }
        // get the total of products
        public int CountProductsWithSellerDates(string language)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string sql = $"select count(*) from (select distinct ProductModel.Name as Name, production.ProductDescription.Description as Description, " +
                             $"Product.SellStartDate AS 'SellStartDate', Product.SellEndDate AS 'SellEndDate' " +
                                   $"from Production.Product inner join Production.ProductSubcategory on Product.ProductSubcategoryID = ProductSubcategory.ProductSubcategoryID " +
                                   $"inner join Production.ProductCategory on ProductSubcategory.ProductCategoryID = ProductCategory.ProductCategoryID " +
                                   $"inner join Production.ProductModel on Product.ProductModelID = ProductModel.ProductModelID " +
                                   $"inner join Production.ProductModelProductDescriptionCulture ON ProductModel.ProductModelID = ProductModelProductDescriptionCulture.ProductModelID " +
                                   $"inner join production.ProductDescription on ProductModelProductDescriptionCulture.ProductDescriptionID = ProductDescription.ProductDescriptionID " +
                                   $"where ProductModelProductDescriptionCulture.CultureID = '{language}' AND Product.ProductModelID is not null) as counter "; 

                int total = connection.Query<int>(sql).FirstOrDefault();
                return total;
            }
        }
        // returns All products with their sell dates
        public List<Product> GetProductsWithSellerDates(string language, int productsPerPage, int currentPage)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string sql = $"select distinct ProductModel.Name as Name, production.ProductDescription.Description as Description, " + 
                             $"Product.SellStartDate AS 'SellStartDate', Product.SellEndDate AS 'SellEndDate' " +
                                   $"from Production.Product inner join Production.ProductSubcategory on Product.ProductSubcategoryID = ProductSubcategory.ProductSubcategoryID " +
                                   $"inner join Production.ProductCategory on ProductSubcategory.ProductCategoryID = ProductCategory.ProductCategoryID " +
                                   $"inner join Production.ProductModel on Product.ProductModelID = ProductModel.ProductModelID " +
                                   $"inner join Production.ProductModelProductDescriptionCulture ON ProductModel.ProductModelID = ProductModelProductDescriptionCulture.ProductModelID " +
                                   $"inner join production.ProductDescription on ProductModelProductDescriptionCulture.ProductDescriptionID = ProductDescription.ProductDescriptionID " +
                                   $"where ProductModelProductDescriptionCulture.CultureID = '{language}' AND Product.ProductModelID is not null " +
                                   $"order by ProductModel.Name " +
                                   $"Offset {productsPerPage * currentPage} rows " +
                                   $"fetch next {productsPerPage} rows only";

                List<Product> products = new List<Product>();
                products = connection.Query<Product>(sql).ToList();
                return products;
            }
        }
        //returns the list of colors of the products
        public List<string> GetColors()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string sql = $"select distinct Product.Color from production.Product";
                List<string> colors = connection.Query<string>(sql).ToList();
                return colors;
            }
        }
        //returns the list of styles of the products
        public List<string> GetStyles()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string sql = $"select distinct Product.Style from production.Product";
                List<string> styles = connection.Query<string>(sql).ToList();
                return styles;
            }
        }
        //returns the list of lines of the products
        public List<string> GetProductLine()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string sql = $"select distinct Product.ProductLine from production.Product";
                List<string> productLine = connection.Query<string>(sql).ToList();
                return productLine;
            }
        }
        //returns a list of products that contains the string parameter in somewhere into the name
        public List<Product> GetProductsByProductName(string text)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string sql = $"select distinct ProductModel.Name as Name, production.ProductDescription.Description as Description " +
                         $"from Production.Product " +
                         $"inner join Production.ProductSubcategory on Product.ProductSubcategoryID = ProductSubcategory.ProductSubcategoryID " +
                         $"inner join Production.ProductCategory on ProductSubcategory.ProductCategoryID = ProductCategory.ProductCategoryID " +
                         $"inner join Production.ProductModel on Product.ProductModelID = ProductModel.ProductModelID " +
                         $"inner join Production.ProductModelProductDescriptionCulture ON ProductModel.ProductModelID = ProductModelProductDescriptionCulture.ProductModelID " +
                         $"inner join production.ProductDescription on ProductModelProductDescriptionCulture.ProductDescriptionID = ProductDescription.ProductDescriptionID " +
                         $"where ProductModelProductDescriptionCulture.CultureID = 'en' AND Product.Name like '%{text}%'";

                List<Product> products = connection.Query<Product>(sql).ToList();
                return products;
            }
        }

        //returns a list of products that contains the string parameter in somewhere into the name
        public List<Product> GetProductsByModelName(string text)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string sql = $"select distinct ProductModel.Name as Name, production.ProductDescription.Description as Description " +
                         $"from Production.Product " +
                         $"inner join Production.ProductSubcategory on Product.ProductSubcategoryID = ProductSubcategory.ProductSubcategoryID " +
                         $"inner join Production.ProductCategory on ProductSubcategory.ProductCategoryID = ProductCategory.ProductCategoryID " +
                         $"inner join Production.ProductModel on Product.ProductModelID = ProductModel.ProductModelID " +
                         $"inner join Production.ProductModelProductDescriptionCulture ON ProductModel.ProductModelID = ProductModelProductDescriptionCulture.ProductModelID " +
                         $"inner join production.ProductDescription on ProductModelProductDescriptionCulture.ProductDescriptionID = ProductDescription.ProductDescriptionID " +
                         $"where ProductModelProductDescriptionCulture.CultureID = 'en' AND ProductModel.Name like '%{text}%'";

                List<Product> products = connection.Query<Product>(sql).ToList();
                return products;
            }
        }

    }
}

