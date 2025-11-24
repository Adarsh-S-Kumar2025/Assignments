using System;

// Base class
public class Vehicle
{
    public void ShowType()
    {
        Console.WriteLine("This is a vehicle");
    }
}

// Derived class with method hiding
public class Car : Vehicle
{
    public new void ShowType()   // 'new' hides the base method
    {
        Console.WriteLine("This is a car");
    }
}

class Program
{
    static void Main()
    {
        Vehicle myVehicle = new Vehicle();
        myVehicle.ShowType();   // Output: This is a vehicle

        Car myCar = new Car();
        myCar.ShowType();       // Output: This is a car

        Vehicle vehicleRefToCar = new Car();
        vehicleRefToCar.ShowType();  // Output: This is a vehicle
    }
}
