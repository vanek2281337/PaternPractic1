using System;
using System.Collections.Generic;


abstract class Employee
{
    public abstract double GetSalary();
}


class SingleEmployee : Employee
{
    private string Name { get; set; }
    private double Salary { get; set; }

    public SingleEmployee(string name, double salary)
    {
        Name = name;
        Salary = salary;
    }

    public override double GetSalary()
    {
        return Salary;
    }
}


class GroupEmployee : Employee
{
    private List<Employee> Employees { get; set; }

    public GroupEmployee()
    {
        Employees = new List<Employee>();
    }

    public void AddEmployee(Employee employee)
    {
        Employees.Add(employee);
    }

    public override double GetSalary()
    {
        double totalSalary = 0;
        foreach (var employee in Employees)
        {
            totalSalary += employee.GetSalary();
        }
        return totalSalary;
    }
}

class Program
{
    static void Main()
    {
        
        var organization = new GroupEmployee();

        
        var employee1 = new SingleEmployee("John", 1000);
        var employee2 = new SingleEmployee("Jack", 1200);
        organization.AddEmployee(employee1);
        organization.AddEmployee(employee2);

     
        var group = new GroupEmployee();
        var employee3 = new SingleEmployee("Bob", 800);
        var employee4 = new SingleEmployee("Carol", 900);
        group.AddEmployee(employee3);
        group.AddEmployee(employee4);

        
        organization.AddEmployee(group);

 
        double totalSalary = organization.GetSalary();
        Console.WriteLine($"Общая зарпалата: {totalSalary}");
    }
}


abstract class Coffee
{
    public abstract double GetCost();
    public abstract string GetDescription();
}


class SimpleCoffee : Coffee
{
    public override double GetCost()
    {
        return 1.0; 
    }

    public override string GetDescription()
    {
        return "Простой кофе";
    }
}


class MilkDecorator : Coffee
{
    private Coffee _coffee;

    public MilkDecorator(Coffee coffee)
    {
        _coffee = coffee;
    }

    public override double GetCost()
    {
        return _coffee.GetCost() + 0.5; 
    }

    public override string GetDescription()
    {
        return _coffee.GetDescription() + ", milk";
    }
}


class ChocolateDecorator : Coffee
{
    private Coffee _coffee;

    public ChocolateDecorator(Coffee coffee)
    {
        _coffee = coffee;
    }

    public override double GetCost()
    {
        return _coffee.GetCost() + 0.7; 
    }

    public override string GetDescription()
    {
        return _coffee.GetDescription() + ", chocolate";
    }
}


class SyrupDecorator : Coffee
{
    private Coffee _coffee;

    public SyrupDecorator(Coffee coffee)
    {
        _coffee = coffee;
    }

    public override double GetCost()
    {
        return _coffee.GetCost() + 0.3; 
    }

    public override string GetDescription()
    {
        return _coffee.GetDescription() + ", syrup";
    }
}

class Program
{
    static void Main()
    {
      
        Coffee coffee = new SimpleCoffee();
        Console.WriteLine($"Cost: {coffee.GetCost()}, Description: {coffee.GetDescription()}");

        
        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"Cost: {coffee.GetCost()}, Description: {coffee.GetDescription()}");

        
        coffee = new ChocolateDecorator(coffee);
        Console.WriteLine($"Cost: {coffee.GetCost()}, Description: {coffee.GetDescription()}");

       
        coffee = new SyrupDecorator(coffee);
        Console.WriteLine($"Cost: {coffee.GetCost()}, Description: {coffee.GetDescription()}");
    }
}
