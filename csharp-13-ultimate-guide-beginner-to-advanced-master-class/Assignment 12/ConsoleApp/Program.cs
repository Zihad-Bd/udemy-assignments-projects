

using Library;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee.OrganizationName = "Harsha Inc.";
            string continueNext = null;
            do
            {
                Employee employee = new Employee();
                System.Console.Write("EmpID: ");
                employee.EmpID = System.Convert.ToInt32(System.Console.ReadLine());
                System.Console.Write("EmpName: ");
                employee.EmpName = System.Console.ReadLine();
                System.Console.Write("SalaryPerHour: ");
                employee.SalaryPerHour = System.Convert.ToInt32(System.Console.ReadLine());
                System.Console.Write("NoOfWorkingHours: ");
                employee.NoOfWorkingHours = System.Convert.ToInt32(System.Console.ReadLine());
                employee.NetSalary = employee.SalaryPerHour * employee.NoOfWorkingHours;
                System.Console.WriteLine("EmpID: " + employee.EmpID + ", EmpName: " + employee.EmpName + ",  SalaryPerHour: " + employee.SalaryPerHour + ", NoOfWorkingHours: " + employee.NoOfWorkingHours + ", NetSalary: " + employee.NetSalary + ", OrganizationName: " + Employee.OrganizationName + ", TypeOfEmployee: " + Employee.TypeOfEmployee + ", DepartmentName: " + employee.DepartmentName);
                System.Console.WriteLine("Do you want to continue to next employee?");
                System.Console.WriteLine("Write Yes/No");
                continueNext = System.Console.ReadLine();

            } while (continueNext == "Yes");
        }
    }
}
