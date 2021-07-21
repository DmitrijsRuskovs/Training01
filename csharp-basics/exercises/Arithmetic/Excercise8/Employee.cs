using System;
public class Employee
{   
    public string name;
    private double salaryPerHour;
    private double hoursWorked;
    private double salary;
    private string salaryMessage;
    public Employee (string name, double salaryPerHour, double hoursWorked)
    {
        this.name = name;
        this.salaryPerHour = salaryPerHour;
        this.hoursWorked = hoursWorked;
        this.salaryMessage = "To be paid in standard order";
        if (this.hoursWorked > 60)
        {
            this.salaryMessage = "Error! More than 60 hours worked!";
        }
        if (this.salaryPerHour < 8)
        {
            this.salaryMessage = "Error! Not less than 8.00 USD/h are allowed according to US legislation!";
        }

        if (this.hoursWorked <= 40)
        {
            this.salary = this.hoursWorked * this.salaryPerHour;
        }
        else
        {
            this.salary = (1.5 * this.hoursWorked - 20) * this.salaryPerHour;
        }
    }

    public void Report()
    {
        Console.WriteLine($"| {this.name} | { this.salaryPerHour.ToString("0.00")} | { this.hoursWorked.ToString("0.00")} " +
            $"| {this.salary.ToString("0.00")} | { this.salaryMessage} |");
    }
}
