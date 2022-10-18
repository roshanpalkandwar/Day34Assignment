using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day34Assignment
{
    public class DataBaseFunction
    {
        public static string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_Payroll_Service1;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionstring);

        public void SumFunction()
        {
            try
            {

                EmployeeModel model = new EmployeeModel();
                using (connection)
                {
                    string query = "SELECT Gender, SUM(BasicPay) as TotalSalary FROM Employee_Payroll GROUP BY Gender";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.Gender = Convert.ToChar(reader["Gender"]);
                            int TotalSalary = Convert.ToInt32(reader["TotalSalary"]);

                            Console.WriteLine("{0}   {1} ", model.Gender, TotalSalary);
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

        public void AvgFunction()
        {
            try
            {

                EmployeeModel model = new EmployeeModel();
                using (connection)
                {
                    string query = "SELECT Gender, AVG(BasicPay) as AvgSalary FROM Employee_Payroll GROUP BY Gender";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.Gender = Convert.ToChar(reader["Gender"]);
                            int AvgSalary = Convert.ToInt32(reader["AvgSalary"]);

                            Console.WriteLine("{0}   {1} ", model.Gender, AvgSalary);
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

        public void MinFunction()
        {
            try
            {

                EmployeeModel model = new EmployeeModel();
                using (connection)
                {
                    string query = "SELECT Gender, MIN(BasicPay) as MinSalary FROM Employee_Payroll GROUP BY Gender";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.Gender = Convert.ToChar(reader["Gender"]);
                            int minSalary = Convert.ToInt32(reader["MinSalary"]);

                            Console.WriteLine("{0}   {1} ", model.Gender, minSalary);
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

        public void MaxFunction()
        {
            try
            {

                EmployeeModel model = new EmployeeModel();
                using (connection)
                {
                    string query = "SELECT Gender, MAX(BasicPay) as MaxSalary FROM Employee_Payroll GROUP BY Gender";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.Gender = Convert.ToChar(reader["Gender"]);
                            int maxSalary = Convert.ToInt32(reader["MaxSalary"]);

                            Console.WriteLine("{0}   {1} ", model.Gender, maxSalary);
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

        public void CountFunction()
        {
            try
            {

                EmployeeModel model = new EmployeeModel();
                using (connection)
                {
                    string query = "SELECT Gender, COUNT(BasicPay) as CountSalary FROM Employee_Payroll GROUP BY Gender";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.Gender = Convert.ToChar(reader["Gender"]);
                            int countSalary = Convert.ToInt32(reader["CountSalary"]);

                            Console.WriteLine("{0}   {1} ", model.Gender, countSalary);
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
