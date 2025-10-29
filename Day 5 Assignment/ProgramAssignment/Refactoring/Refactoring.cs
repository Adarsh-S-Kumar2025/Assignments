public class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Salary { get; set; }

    public void CalculateBonus()
    {
        double bonus = Salary * 0.1;
        double totalCompensation = Salary + bonus;

        Console.WriteLine($"Bonus: {bonus}, Total Compensation: {totalCompensation}");
    }
}
