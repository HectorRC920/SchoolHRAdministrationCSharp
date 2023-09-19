
using HRAdministrationAPI;
using SchoolHRAdministration;
using System;
namespace SchoolHRAdministration
{
     public enum EmployeeType
    {
      Teacher,
      HeadOfDepartment,
      DeputyHeadMaster,
      HeadMaster
    };
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
      IEmployee teacher1 = Employeefactory.GetEmployeeInstance(EmployeeType.Teacher,1,"Pepito","Perez",40000);
      employees.Add(teacher1);

      IEmployee teacher2 = Employeefactory.GetEmployeeInstance(EmployeeType.Teacher,2,"Juanito","Popochas",40000);
      employees.Add(teacher2);

      IEmployee headOfDepartment = Employeefactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment,3,"El boss","Quintero",60000);
      employees.Add(headOfDepartment);

      IEmployee deputyHeadMaster = Employeefactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster,4,"El sub","Quintero",50000);
      employees.Add(deputyHeadMaster);
      
      IEmployee headMaster = Employeefactory.GetEmployeeInstance(EmployeeType.HeadMaster,5,"El jefe","Quintero",70000);
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

public static class Employeefactory
{
  public static IEmployee GetEmployeeInstance(EmployeeType employeeType,int id,string firstName, string lastName,decimal salary )
  {
    IEmployee employee = null;
    switch (employeeType)
    {
      case EmployeeType.Teacher:
        employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
        break;
      case EmployeeType.HeadOfDepartment:
        employee = FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance();
        break;
      case EmployeeType.DeputyHeadMaster:
        employee = FactoryPattern<IEmployee, DeputyHeadMaster>.GetInstance();
        break;
      case EmployeeType.HeadMaster:
        employee = FactoryPattern<IEmployee, HeadMaster>.GetInstance();
        break;
      default:
        break;
    }
    employee.Id = id;
    employee.FirstName = firstName;
    employee.LastName = lastName;
    employee.Salary = salary;
    return employee;


  }
}