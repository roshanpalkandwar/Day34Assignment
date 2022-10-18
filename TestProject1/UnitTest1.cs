using Day34Assignment;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenSalaryDetailsAbleToUpdate()
        {
            Salary salary = new Salary();
            SalaryUpdateModel salaryUpdateModel = new SalaryUpdateModel()
            {
                SalaryID = 3,
                Month = "June",
                EmployeeSalary = 3000,
                EmployeeID = 3
            };

            
            int EMpSalary = salary.UpdateEmployeeSalary(salaryUpdateModel);

            
            //Assert.AreEqual( salaryUpdateModel.EmployeeSalary, EMpSalary);

        }
    }
}