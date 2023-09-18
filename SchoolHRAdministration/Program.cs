
using HRAdministrationAPI;
using System;
namespace SchoolHRAdministration
{
  class Program
  {
    static void Main(string[] args)
    {
      decimal totalSalaries = 0;
      List<IEmployee> employees = new List<IEmployee>();

      SeedData(employees);

      foreach (var employee in employees)
      {
        totalSalaries += employee.Salary;
      }
      Console.WriteLine($"Total Salaries: {totalSalaries}");
    }
    public static void SeedData(List<IEmployee> employees)
    {
      IEmployee teacher1 = new Teacher
      {
        Id = 1,
        FirstName = "Pepito",
        LastName = "Perez",
        Salary = 40000
      };
      employees.Add(teacher1);
      IEmployee teacher2 = new Teacher
      {
        Id = 2,
        FirstName = "Juanito",
        LastName = "Popochas",
        Salary = 40000
      };
      employees.Add(teacher2);
      IEmployee headOfDepartment = new HeadOfDepartment
      {
        Id = 3,
        FirstName = "El boss",
        LastName = "Quintero",
        Salary = 60000
      };
      employees.Add(headOfDepartment);
      IEmployee deputyHeadMaster = new DeputyHeadMaster
      {
        Id = 4,
        FirstName = "El sub",
        LastName = "Quintero",
        Salary = 50000
      };
      employees.Add(deputyHeadMaster);
      IEmployee headMaster = new HeadMaster
      {
        Id = 5,
        FirstName = "El jefe",
        LastName = "Quintero",
        Salary = 70000
      };
      employees.Add(headMaster);
    }
  }
}

public class Teacher : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.02m); set => base.Salary = value; }
}
public class HeadOfDepartment : EmployeeBase
{
  public override decimal Salary { get => base.Salary + (base.Salary * 0.03m); set => base.Salary = value; }
}
public class DeputyHeadMaster : EmployeeBase
{
  public override decimal Salary { get => base.Salary + (base.Salary * 0.04m); set => base.Salary = value; }
}
public class HeadMaster : EmployeeBase
{
  public override decimal Salary { get => base.Salary + (base.Salary * 0.05m); set => base.Salary = value; }
}