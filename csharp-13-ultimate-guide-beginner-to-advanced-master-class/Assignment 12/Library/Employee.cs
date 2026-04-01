

namespace Library
{
    public class Employee
    {
        public int EmpID;
        public string EmpName;
        public int SalaryPerHour;
        public int NoOfWorkingHours;
        public int NetSalary;
        public static string OrganizationName;
        public const string TypeOfEmployee = "Contract Based";
        public readonly string DepartmentName;

        public Employee()
        {
            DepartmentName = "Finance Department";
        }
    }
}
