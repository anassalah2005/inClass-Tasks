abstract class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }

    public abstract void Speak();

    public void Sleep()
    {
        Console.WriteLine("Zzz...");
    }
}
class Dog : Animal
{
    public Dog(string name) : base(name)
    {
    }

    public override void Speak()
    {
        Console.WriteLine($"{Name} says Woof!");
    }
}
class Cat : Animal
{
    public Cat(string name) : base(name)
    {
    }

    public override void Speak()
    {
        Console.WriteLine($"{Name} says Meow!");
    }
}
class Bird : Animal
{
    public Bird(string name) : base(name)
    {
    }

    public override void Speak()
    {
        Console.WriteLine($"{Name} says Tweet!");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Dog dog = new Dog("Rocky");
        Cat cat = new Cat("Kitty");
        Bird bird = new Bird("Tweety");

        dog.Speak();
        dog.Sleep();

        cat.Speak();
        cat.Sleep();

        bird.Speak();
        bird.Sleep();
    }
}