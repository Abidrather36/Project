using Domain.CreativeWebApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace CreativeWeb.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        static string connectionString = "server=.;integrated security=true;database=CreativeTest";


        [HttpGet]
        public IEnumerable<Product> Get()
        {

            List<Product> products = new List<Product>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetProductData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    Console.WriteLine("ProductId\tProductName\tProductDescription\tCategoryname\tUserName");


                    while (rdr.Read())
                    {
                        Product product = new Product()
                        {
                            ProductId = Convert.ToInt32(rdr["ProductId"]),
                            ProductName = rdr["ProductName"].ToString(),
                            ProductDescription = rdr["ProductDescription"].ToString(),
                            CategoryName = rdr["Categoryname"].ToString(),
                            UserName = rdr["UserName"].ToString()


                        };
                        products.Add(product);
                        /* Console.WriteLine($"{rdr["ProductId"]}\t {rdr["ProductName"]}\t {rdr["ProductDescription"]}\t {rdr["ProductDescription"]}\t {rdr["Categoryname"]}\t{rdr["UserName"]}");
                     *//*Console.WriteLine($"{rdr["ProductName"]}")
                     Console.WriteLine($"{rdr["ProductDescription"]}");*//*
                     Console.WriteLine($"{rdr["Categoryname"]}");
                     Console.WriteLine($"{rdr["UserName"]}");
                     */

                    }
                }
            }
            return products;
        }

        [HttpPut]

        public Product Update(int ProductId, string ProductName, string ProductDescription)
        {
            string connectionString = "server=.;integrated security=true;database=CreativeTest";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateProducts", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@productId", ProductId);
                cmd.Parameters.AddWithValue("@productname", ProductName);
                cmd.Parameters.AddWithValue("@productDescription", ProductDescription); // Corrected parameter name

                int retVal = cmd.ExecuteNonQuery();

                if (retVal > 0)
                {
                    // Create a new Product instance and return it if the update was successful
                    Product updatedProduct = new Product
                    {
                        ProductId = ProductId,
                        ProductName = ProductName,
                        ProductDescription = ProductDescription
                    };

                    return updatedProduct;
                }
                else
                {
                    // Return null or handle the case where the update was not successful
                    return null;
                }
            }
        }


        [HttpDelete]

        public string Delete(int ProductId)
        {
            string connectionString = "server=.; integrated security =true;database=CreativeTest";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteProduct", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductId", ProductId);
                int retVal = cmd.ExecuteNonQuery();

                if (retVal > 0)
                    return "Product Deleted Successfully ";

                return "Something went Wrong ";
            }
        }

        [HttpGet("UserName CategoryName")]

            public List<Product> SearchProducts(string userName, string categoryName)

             {
            List<Product> products = new List<Product>();

            string connectionString = "server=.;integrated security=true;database=CreativeTest";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SearchProducts", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the stored procedure
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Product product = new Product
                            {
                                ProductId = Convert.ToInt32(rdr["ProductId"]),
                                ProductName = rdr["ProductName"].ToString(),
                                ProductDescription = rdr["ProductDescription"].ToString(),
                                CategoryName = rdr["CategoryName"].ToString(),
                                UserName = rdr["UserName"].ToString()
                            };

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }

        [HttpPost]
        public Product Add(string ProductName ,string ProductDescription, int CategoryID,int UserID)
        {
            string connectionString = "server=.;integrated security=true;database=CreativeTest";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("InsertProduct", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductName", ProductName);
                    cmd.Parameters.AddWithValue("@ProductDescription", ProductDescription);
                    cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                    cmd.Parameters.AddWithValue("@UserID", UserID);

                    int retVal=cmd.ExecuteNonQuery();
                    if (retVal>0)
                    {
                        Product prod = new Product()
                        {
                            ProductName = ProductName,
                            ProductDescription = ProductDescription,
                            ProductId = CategoryID,
                            UserName = UserID.ToString(),
                        };

                        return prod;
                    }
                    return null;
                }

            }
        }

    }


}




