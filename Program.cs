
using System;
using System.Reflection.Metadata;
using System.Text;
/*Lets say there are 2 concrete classes one is CheesePizza and another is PepperoniPizza i.e. two variety of pizza and we will have to create 
 * object of the class based on Customer's Order i.e. if Customer wants CheesePizza then you will have to create CheesePizza and if customer 
 * wants PepperoniPizza then we will have create PepperoniPizza then How you will do?
*/

// Product Interface
/*interface Pizza
{
    public void Prepare();
    public void Bake();
}

// Concrete Products
public class CheesePizza : Pizza
{
    public void Prepare()
    {
        Console.WriteLine("Preparing cheese pizza.");
    }
    public void Bake()
    {
        Console.WriteLine("Baking cheese pizza.");
    }
}
public class PepperoniPizza : Pizza
{
    public void Prepare()
    {
        Console.WriteLine("Preparing pepperoni pizza.");
    }
    public void Bake()
    {
        Console.WriteLine("Baking pepperoni pizza.");
    }
}
//Client Code
class Program
{
    static void Main(string[] args)
    {
        string pizzaType = "cheese";  // Get the pizza type from user input

        Pizza pizza;

        switch (pizzaType)
        {
            case "cheese":
                pizza = new CheesePizza();
                break;
            case "pepperoni":
                pizza = new PepperoniPizza();
                break;
            default:
                throw new ArgumentException("Invalid pizza type");
        }
        Console.WriteLine("Order received for a pizza.");
        pizza.Prepare();
        pizza.Bake();
    }
}*/

/*Problem With above Code:
 1. Violates Open - Closed Principle(OCP): If you want to add a new type of pizza(e.g., "margheritaPizza"), you need to modify the client code (the Main method). This violates the OCP, as We have to modify the Class Instead of Extending it.
 2. Tight Coupling: The client code is tightly coupled to the concrete pizza classes (e.g., CheesePizza and PepperoniPizza). If you add a new pizza type, you need to modify the Main method, potentially affecting other parts of the application
 3. Violation of Single Responsibility Principle: The Main method takes on the responsibility of both user interaction and pizza creation, violating the Single Responsibility Principle.*/

/*To address these problems and improve the design, you can use design patterns like the Factory Pattern, which encapsulates object creation logic and promotes extensibility without modifying existing code.*/
/*The Factory Pattern or similar creational design patterns are a better approach because they encapsulate the object creation logic in separate classes or methods. This promotes code that is open for extension (you can add new pizza types) without the need to modify existing code (closed for modification), aligning with the Open-Closed Principle and providing better maintainability and scalability.*/

/*Why Factory Design Pattern?
 Separation of Concerns: In the Factory Pattern, you have dedicated factory classes or methods responsible for creating objects of a particular type. This separation of concerns ensures that object creation logic is isolated from the client code.
*/
/*At what scenario we have to use factory design pattern?: When we have to create object of the classes based on the user input or  parameters. *///

/*Let's have a look at Factory pattern */

namespace Factory
{

    // Product Interface
    public interface IPizza
    {
        void Prepare();
        void Bake();
    }
    // Concrete Products
    class CheesePizza : IPizza
    {
        public void Prepare()
        {
            Console.WriteLine("Preparing cheese pizza.");
        }
        public void Bake()
        {
            Console.WriteLine("Baking cheese pizza.");
        }
    }
    class PepperoniPizza : IPizza
    {
        public void Prepare()
        {
            Console.WriteLine("Preparing pepperoni pizza.");
        }

        public void Bake()
        {
            Console.WriteLine("Baking pepperoni pizza.");
        }
    }
    /*    Creator Abstract Class:  This is an abstract class and declares the factory method which returns an object of type Product(i.e.IPizza).*/
    public abstract class PizzaFactory
    {
        public abstract IPizza CreatePizza(string type);

    }
    /*  Concrete Creator Class*/
    class ConcretePizzaFactory : PizzaFactory
    {
        public override IPizza CreatePizza(string type)
        {
            switch (type)
            {
                case "cheese":
                    return new CheesePizza();
                case "pepperoni":
                    return new PepperoniPizza();
                default:
                    throw new ArgumentException("Invalid pizza type");
            }
        }
    }
    /* The ConcretePizzaFactory is a Subclass of PizzaFactory and overrides the CreatePizza method to decide which concrete class to instantiate based on the input parameter.*/

    /* Another Definition of Factory Pattern is :  Define an interface (PizzaFactory) for creating an object, but let the subclasses (ConcretePizzaFactory) decide which class to instantiate.*/

    //Client Code
    class Program
    {
        static void Main(string[] args)
        {

            PizzaFactory factory = new ConcretePizzaFactory();

            IPizza cheesePizza = factory.CreatePizza("cheese");
            cheesePizza.Prepare();
            cheesePizza.Bake();

            IPizza pepperoniPizza = factory.CreatePizza("pepperoni");
            pepperoniPizza.Prepare();
            pepperoniPizza.Bake();
        }
    }
}

/*Here, the main advantage is Client is not responsible for creating objects of Concrete Classes.

But OCP (Open-Closed Principle) is still not completely satisfied as you see if we add one more pizza type then we will have to modify the factory class.*/
