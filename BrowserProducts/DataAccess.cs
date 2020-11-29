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

        public List<Product> GetNameProductsByProductModelName(string productModelName, string language)
        {
            string query = $"select product.Name,production.ProductDescription.Description as Description from production.product " +
                $"inner join Production.ProductSubcategory on Product.ProductSubcategoryID = ProductSubcategory.ProductSubcategoryID " +
                $"inner join Production.ProductCategory on  ProductSubcategory.ProductCategoryID = ProductCategory.ProductCategoryID " +
                $"inner join Production.ProductModel on Product.ProductModelID = ProductModel.ProductModelID " +
                $"inner join Production.ProductModelProductDescriptionCulture ON ProductModel.ProductModelID = ProductModelProductDescriptionCulture.ProductModelID " +
                $"inner join production.ProductDescription on ProductModelProductDescriptionCulture.ProductDescriptionID = ProductDescription.ProductDescriptionID " +
                $"where ProductModelProductDescriptionCulture.CultureID = '{language}' and ProductModel.Name = '{productModelName}'";

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {

                List<Product> productList = new List<Product>();

                productList = connection.Query<Product>(query).ToList();
                return productList;
            }
        }

        public List<Product> GetProduct(string productModelName, string language)
        {
            string queryDetailProduct = $"SELECT ProductID,production.ProductDescription.Description as Description,Product.Name as Name,ProductNumber" +
                    $",MakeFlag,FinishedGoodsFlag,Color,SafetyStockLevel,ReorderPoint,StandardCost,ListPrice,Size,SizeUnitMeasureCode as SizeUnitMeasure,WeightUnitMeasureCode as WeightUnitMeasure" +
                    $",Weight,DaysToManufacture,ProductLine,Class,Style,product.ProductSubcategoryID as ProductSubcategory,Product.ProductModelID,SellStartDate,SellEndDate,DiscontinuedDate,Product.ModifiedDate " +
                    $"FROM AdventureWorks2016.Production.Product inner join Production.ProductModel on Product.ProductModelID = ProductModel.ProductModelID " +
                    $"inner join Production.ProductSubcategory on Product.ProductSubcategoryID = ProductSubcategory.ProductSubcategoryID " +
                    $"inner join Production.ProductModelProductDescriptionCulture ON ProductModel.ProductModelID = ProductModelProductDescriptionCulture.ProductModelID " +
                    $"inner join production.ProductDescription on ProductModelProductDescriptionCulture.ProductDescriptionID = ProductDescription.ProductDescriptionID " +
                    $"where ProductModelProductDescriptionCulture.CultureID = '{language}' and production.Product.Name = '{productModelName}'";

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                List<Product> detailedProduct = connection.Query<Product>(queryDetailProduct).ToList();
                return detailedProduct;
            }
        }

        public List<string> GetAllSubCategories()
        {
            string sql = "select production.ProductSubcategory.Name from production.ProductSubcategory";

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                List<string> subCategoryList = connection.Query<string>(sql).ToList();
                return subCategoryList;
            }
        }

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

        //returns a List of all the kind of product classes
        public List<string> GetAllClasses()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string sql = $"select distinct Product.Class from production.Product";
                List<string> classes = connection.Query<string>(sql).ToList();
                return classes;
            }
        }

        //return a List of all the kind of product sizes
        public List<string> GetAllSizes()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string sql = $"select distinct Product.Size from production.Product";
                List<string> sizes = connection.Query<string>(sql).ToList();
                return sizes;
            }
        }

        //return a List of all the kind of unit sizes
        public List<string> GetAllSizeUnits()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string sql = $"select UnitMeasure.Name from production.UnitMeasure";
                List<string> unitSizes = connection.Query<string>(sql).ToList();
                return unitSizes;
            }
        }

        public string FromSubCatIdToSubCatName(int subCatId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string sql = $"select productsubcategory.name from Production.ProductSubcategory where ProductSubcategoryID = {subCatId}";
                string name = connection.Query<string>(sql).FirstOrDefault();
                return name;
            }
        }
        ////return a List of all the kind of unit weigth sizes
        //public List<string> GetAllSizeUnits()
        //{
        //    using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
        //    {
        //        string sql = $"select UnitMeasure.Name from production.UnitMeasure";
        //        List<string> unitSizes = connection.Query<string>(sql).ToList();
        //        return unitSizes;
        //    }
        //}
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

        public void UpdateProduct(Product p)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AdventureWorks2016")))
            {
                string sql = $"UPDATE Production.Products " +
                             $"SET Name = @Name, ProductNumber = @ProductNumber, MakeFlag = @MakeFlag, " +
                             $"FinishedGoodsFlag = @FinishedGoodsFlag, Color = @Color, SafetyStockLevel = @SafaetyStockLevel," +
                             $"ReorderPoint = @ReorderPoint, StandardCost = @StandardCost, ListPrice = @ListPrice, Size = @Size," +
                             $"SizeUnitMeasureCode = @SizeUnitMeasure, WeightUnitMeasureCode = @WeightUnitMeasure, Weight = @Weight," +
                             $"DaysToManufacture = @DaysToManufacture, ProductLine = @ProductLine, Class = @Class, Style = @Style," +
                             $"ProductSubcategoryID = @ProductSubcategory, ProductModelID = @ProductModelId, SellStartDate = @SellStartDate," +
                             $"SellEndDate = @SellEndDate, DiscontinuedDate = @DiscontinuedDate, ModifiedDate = @ModifiedDate' " +
                             $"WHERE ProductID = @ProductID";

                int id = p.GetProductID();

                //string sql = "UPDATE Categories SET Description = @Description WHERE CategoryID = @CategoryID;";


                connection.Execute(sql, new { ProductID = id,
                    Name = p.Name, 
                    ProductNumber = p.ProductNumber,
                    MakeFlag = p.MakeFlag,
                    FinishedGoodsFlag = p.FinishedGoodsFlag,
                    Color = p.Color,
                    SafetyStockLevel = p.SafetyStockLevel,
                    ReorderPoint = p.ReorderPoint,
                    StandardCost = p.StandardCost,
                    ListPrice = p.ListPrice,
                    Size = p.Size,
                    SizeUnitMeasure = p.SizeUnitMeasure,
                    WeightUnitMeasure = p.WeightUnitMeasure,
                    Weight = p.Weight,
                    DaysToManufacture = p.DaysToManufacture,
                    ProductLine = p.ProductLine,
                    Class = p.Class,
                    Style = p.Style,
                    ProductSubcategory = p.ProductSubcategory,
                    ProductModelId = p.ProductModelId,
                    SellStartDate = p.SellStartDate,
                    SellEndDate = p.SellEndDate,
                    DiscontinuedDate = p.DiscontinuedDate,
                    ModifiedDate = p.ModifiedDate
                });
            }
        }
    }

}


