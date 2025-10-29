using System;

// Base class
public class Animal
{
    public virtual void Speak()
    {
        Console.WriteLine("Animal makes a sound");
    }
}

// Derived class Dog
public class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Dog says: Woof!");
    }
}

// Derived class Cat
public class Cat : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Cat says: Meow!");
    }
}

// Test program
class Program
{
    static void Main()
    {
        Animal genericAnimal = new Animal();
        genericAnimal.Speak();  // Output: Animal makes a sound

        Animal dog = new Dog();
        dog.Speak();            // Output: Dog says: Woof!

        Animal cat = new Cat();
        cat.Speak();            // Output: Cat says: Meow!
    }
}
