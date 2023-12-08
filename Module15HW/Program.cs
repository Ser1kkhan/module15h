using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Module15HW
{
    public interface IPlugin
    {
        void Execute();
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }

    class Program
    {
        static void Main()
        {
            // Task 1: Reflecting on Console class
            Type consoleType = typeof(Console);
            MethodInfo[] consoleMethods = consoleType.GetMethods();
            Console.WriteLine("Methods in Console class:");
            foreach (MethodInfo method in consoleMethods)
            {
                Console.WriteLine(method.Name);
            }

            // Task 2: Reflecting on Student class
            Student student = new Student { Name = "John", Age = 25 };
            Type studentType = student.GetType();
            PropertyInfo[] studentProperties = studentType.GetProperties();
            Console.WriteLine("\nProperties in Student class:");
            foreach (PropertyInfo property in studentProperties)
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(student)}");
            }

            // Task 3: Reflecting on String.Substring method
            Type stringType = typeof(string);
            MethodInfo substringMethod = stringType.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });
            string originalString = "Hello, Reflection!";
            string result = (string)substringMethod.Invoke(originalString, new object[] { 7, 5 });
            Console.WriteLine($"\nResult of String.Substring: {result}");

            // Task 4: Loading and executing plugins
            List<IPlugin> plugins = new List<IPlugin>();

            string[] dllFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll");
            foreach (string dllFile in dllFiles)
            {
                Assembly assembly = Assembly.LoadFrom(dllFile);
                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    if (typeof(IPlugin).IsAssignableFrom(type))
                    {
                        IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                        plugins.Add(plugin);
                    }
                }
            }

            Console.WriteLine("\nExecuting loaded plugins:");
            foreach (var plugin in plugins)
            {
                plugin.Execute();
            }

            Console.ReadKey();
        }
    }
}
