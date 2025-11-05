class Employee
{
    public string Name;
    public double Salary;

    public Employee(string name) : this(name, 0) { }

    public Employee(string name, double salary)
    {
        Name = name;
        Salary = salary;
    }

    public void Display()
    {
        Console.WriteLine($"Name: {Name}, Salary: {Salary}");
    }
}
