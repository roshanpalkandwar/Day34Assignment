using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day34Assignment
{
    public class Salary
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Employee_Payroll_Service1;Integrated Security=True");

        }


        public int UpdateEmployeeSalary(SalaryUpdateModel salaryUpdateModel)
        {
            SqlConnection sqlConnection = ConnectionSetup();
            int salary = 0;
            try
            {
                using (sqlConnection)
                {
                    SalaryDetailsModel salaryDetailsModel = new SalaryDetailsModel();
                    SqlCommand command = new SqlCommand("SpUpdateEmployeeSalary", sqlConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id", salaryUpdateModel.SalaryID);
                    command.Parameters.AddWithValue("@month", salaryUpdateModel.Month);
                    command.Parameters.AddWithValue("@salary", salaryUpdateModel.EmployeeSalary);
                    command.Parameters.AddWithValue("@empid", salaryUpdateModel.EmployeeID);

                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            salaryDetailsModel.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                            salaryDetailsModel.EmployeeName = reader["EmployeeName"].ToString();
                            salaryDetailsModel.JobDescription = reader["JobDescription"].ToString();
                            salaryDetailsModel.Month = reader["Month"].ToString();
                            salaryDetailsModel.EmployeeSalary = Convert.ToInt32(reader["EmployeeSalary"]);
                            salaryDetailsModel.SalaryID = Convert.ToInt32(reader["SalaryID"]);

                            Console.WriteLine("{0}   {1}   {2}   {3}   {4}   {5}", salaryDetailsModel.SalaryID, salaryDetailsModel.EmployeeID, salaryDetailsModel.EmployeeName, salaryDetailsModel.JobDescription, salaryDetailsModel.Month, salaryDetailsModel.EmployeeSalary);
                            salary = salaryDetailsModel.EmployeeSalary;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data not found");
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return salary;
        }
    }
}
