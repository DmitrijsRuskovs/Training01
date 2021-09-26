using System;
public class Employee
{   
    public string Name;
    private double _salaryPerHour;
    private double _hoursWorked;
    private double _salary;
    private string _salaryMessage;
    public Employee (string name, double salaryPerHour, double hoursWorked)
    {
        this.Name = name;
        this._salaryPerHour = salaryPerHour;
        this._hoursWorked = hoursWorked;
        this._salaryMessage = "To be paid in standard order";
        if (this._hoursWorked > 60)
        {
            this._salaryMessage = "Error! More than 60 hours worked!";
        }
        if (this._salaryPerHour < 8)
        {
            this._salaryMessage = "Error! Not less than 8.00 USD/h are allowed according to US legislation!";
        }

        if (this._hoursWorked <= 40)
        {
            this._salary = this._hoursWorked * this._salaryPerHour;
        }
        else
        {
            this._salary = (1.5 * this._hoursWorked - 20) * this._salaryPerHour;
        }
    }

    public string SalaryPayingMessage()
    {
        return this._salaryMessage;
    }

    public double GetSalary()
    {
        return this._salary;
    }

    public void Report()
    {
        Console.WriteLine($"| {this.Name} | { this._salaryPerHour.ToString("0.00")} | { this._hoursWorked.ToString("0.00")} " +
            $"| {this._salary.ToString("0.00")} | { this._salaryMessage} |");
    }
}