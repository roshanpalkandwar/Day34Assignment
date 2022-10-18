using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day34Assignment
{
    public class RetrieveEmployee
    {
        public static string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_Payroll_Service1;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionstring);

        public void GetEmplyee()
        {
            try
            {
                EmployeeModel model = new EmployeeModel();
                using (connection)
                {
                    string query = @"SELECT EmployeeID,EmployeeName,PhoneNumber,Address,Department,Gender,
	                BasicPay,Deduction,TaxablePay,Tax,NetPay,City,Country FROM Employee_Payroll WHERE EmployeeID BETWEEN 2 AND 4";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.EmployeeID = reader.GetInt32(0);
                            model.EmployeeName = reader.GetString(1);
                            model.PhoneNumber = Convert.ToInt64(reader["PhoneNumber"]);
                            model.Address = Convert.ToString(reader["Address"]);
                            model.Department = Convert.ToString(reader["Department"]);
                            model.Gender = Convert.ToChar(reader["Gender"]);
                            model.BasicPay = Convert.ToDouble(reader["BasicPay"]);
                            model.Deduction = Convert.ToDouble(reader["Deduction"]);
                            model.TaxablePay = Convert.ToDouble(reader["TaxablePay"]);
                            model.Tax = Convert.ToDouble(reader["Tax"]);
                            model.NetPay = Convert.ToDouble(reader["NetPay"]);
                            model.City = Convert.ToString(reader["City"]);
                            model.Country = Convert.ToString(reader["Country"]);


                            Console.WriteLine("{0}  {1}   {2}   {3}   {4}   {5}   {6}   {7}   {8}   {9}   {10}   {11}   {12}", model.EmployeeID, model.EmployeeName, model.PhoneNumber, model.Address, model.Department, model.Gender, model.BasicPay, model.Deduction, model.TaxablePay, model.Tax, model.NetPay, model.City, model.Country);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
