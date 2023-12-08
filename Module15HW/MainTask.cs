//using System;
//using System.Reflection;

//class Program
//{
//    static void Main()
//    {
//        // Task 1: Get and display methods of the Console class using reflection
//        Type consoleType = typeof(Console);
//        Console.WriteLine("Methods of Console class:");
//        MethodInfo[] consoleMethods = consoleType.GetMethods();
//        foreach (var method in consoleMethods)
//        {
//            Console.WriteLine(method.Name);
//        }
//        Console.WriteLine();

//        // Task 2: Create an instance of a class with properties, get properties, and their values using reflection
//        var myClassInstance = new MyClass
//        {
//            Property1 = "Value1",
//            Property2 = 42
//        };
//        Type myClassType = myClassInstance.GetType();
//        Console.WriteLine("Properties and their values of MyClass:");
//        PropertyInfo[] properties = myClassType.GetProperties();
//        foreach (var property in properties)
//        {
//            object value = property.GetValue(myClassInstance);
//            Console.WriteLine($"{property.Name}: {value}");
//        }
//        Console.WriteLine();

//        // Task 3: Use reflection to call the Substring method of the String class
//        string text = "Hello, Reflection!";
//        Type stringType = typeof(string);
//        MethodInfo substringMethod = stringType.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });
//        if (substringMethod != null)
//        {
//            object[] parameters = new object[] { 7, 10 };
//            object result = substringMethod.Invoke(text, parameters);
//            Console.WriteLine("Result of Substring method: " + result);
//        }
//        Console.WriteLine();

//        // Task 4: Get constructors of the List<T> class
//        Type listType = typeof(System.Collections.Generic.List<>);
//        Console.WriteLine("Constructors of List<T> class:");
//        ConstructorInfo[] listConstructors = listType.GetConstructors();
//        foreach (var constructor in listConstructors)
//        {
//            Console.WriteLine(constructor);
//        }
//        Console.WriteLine();

//        Console.ReadKey();
//    }
//}

//public class MyClass
//{
//    public string Property1 { get; set; }
//    public int Property2 { get; set; }
//}
