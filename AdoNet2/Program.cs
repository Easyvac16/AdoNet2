﻿using System.Data.SqlClient;
using System.Text;

namespace AdoNet2
{
    internal class Program
    {
        public static string ConnectionString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Shop;Integrated Security=True;Connect Timeout=30;";
        static void Main()
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;

            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Відобразити всю інформацію про товар.");
                Console.WriteLine("2. Відобразити всі типи товарів.");
                Console.WriteLine("3. Відобразити всіх постачальників.");
                Console.WriteLine("4. Показати товар з максимальною кількістю.");
                Console.WriteLine("5. Показати товар з мінімальною кількістю.");
                Console.WriteLine("6. Показати товар з мінімальною собівартістю.");
                Console.WriteLine("7. Показати товар з максимальною собівартістю.");
                Console.WriteLine("9. Показати товар заданого постачальника.");

                Console.WriteLine("0. Вийти з програми");

                Console.Write("Виберіть опцію: ");
                choice = int.Parse(Console.ReadLine());


                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        connection.Open();


                        switch (choice)
                        {
                            case 1:
                                DisplayAllProductData(connection);
                                break;
                            case 2:
                                DisplayAllProductTypes(connection);
                                break;
                            case 3:
                                DisplayAllSuppliers(connection);
                                break;
                            case 4:
                                DisplayProductWithMaxQuantity(connection);
                                break;
                            case 5:
                                DisplayProductWithMinQuantity(connection);
                                break;
                            case 6:
                                DisplayProductWithMinCost(connection);
                                break;
                            case 7:
                                DisplayProductWithMaxCost(connection);
                                break;
                            case 8:
                                
                                break;
                            case 9:
                                DisplayProductsBySupplier(connection);
                                break;
                            case 10:
                                
                                break;
                            case 11:
                                
                                break;
                            case 0:
                                Console.WriteLine("Poka!");
                                break;
                            default:
                                Console.WriteLine("Неправильний вибір.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Помилка: {ex.Message}");
                    }
                }
                Thread.Sleep(5000);
            } while (choice != 0);

        }
        static void DisplayAllProductData(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Products", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Product ID: {reader["ProductID"]}, Product Name: {reader["ProductName"]}, Product Type: {reader["ProductType"]}, Supplier ID: {reader["SupplierID"]}, Quantity: {reader["Quantity"]}, Cost: {reader["Cost"]}, Supply Date: {reader["SupplyDate"]}");
                }
            }
        }

        static void DisplayAllProductTypes(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT DISTINCT ProductType FROM Products", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Product Type: {reader["ProductType"]}");
                }
            }
        }

        static void DisplayAllSuppliers(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Suppliers", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Supplier ID: {reader["SupplierID"]}, Supplier Name: {reader["SupplierName"]}, Supplier Location: {reader["SupplierLocation"]}");
                }
            }
        }

        static void DisplayProductWithMaxQuantity(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Products ORDER BY Quantity DESC", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Product ID: {reader["ProductID"]}, Product Name: {reader["ProductName"]}, Quantity: {reader["Quantity"]}");
                }
            }
        }

        static void DisplayProductWithMinQuantity(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Products ORDER BY Quantity ASC", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Product ID: {reader["ProductID"]}, Product Name: {reader["ProductName"]}, Quantity: {reader["Quantity"]}");
                }
            }
        }

        static void DisplayProductWithMinCost(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Products ORDER BY Cost ASC", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Product ID: {reader["ProductID"]}, Product Name: {reader["ProductName"]}, Cost: {reader["Cost"]}");
                }
            }
        }

        static void DisplayProductWithMaxCost(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Products ORDER BY Cost DESC", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Product ID: {reader["ProductID"]}, Product Name: {reader["ProductName"]}, Cost: {reader["Cost"]}");
                }
            }
        }

        static void DisplayProductsBySupplier(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT p.ProductName FROM Products p JOIN Suppliers s ON p.SupplierID = s.SupplierID WHERE s.SupplierID = 3;", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ProductName"]}");
                }
            }
            
        }
        
        static void DisplayProductsByType(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT p.ProductName FROM Products p JOIN Suppliers s ON p.SupplierID = s.SupplierID WHERE s.SupplierID = 3;", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ProductName"]}");
                }
            }
            
        }

    }
}