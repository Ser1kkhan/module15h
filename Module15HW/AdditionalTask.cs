//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;

//namespace ReflectionTasks
//{
//    class Program
//    {
//        static void Main()
//        {
//            // Task 1: Load the Student.dll assembly dynamically
//            Assembly studentAssembly = Assembly.LoadFrom("Student.dll");

//            // Task 2: Explore the Student class
//            Type studentType = studentAssembly.GetType("StudentLibrary.Student");
//            Console.WriteLine($"Type: {studentType.FullName}");

//            Console.WriteLine("Base Types:");
//            Type baseType = studentType.BaseType;
//            while (baseType != null)
//            {
//                Console.WriteLine($" - {baseType.FullName}");
//                baseType = baseType.BaseType;
//            }

//            Console.WriteLine("Implemented Interfaces:");
//            Type[] interfaces = studentType.GetInterfaces();
//            foreach (Type iface in interfaces)
//            {
//                Console.WriteLine($" - {iface.FullName}");
//            }

//            // Task 3: Dynamically create and use a Dictionary<string, int>
//            Type dictionaryType = typeof(Dictionary<string, int>);
//            object dictionaryInstance = Activator.CreateInstance(dictionaryType);
//            MethodInfo addMethod = dictionaryType.GetMethod("Add");
//            addMethod.Invoke(dictionaryInstance, new object[] { "Key1", 100 });
//            addMethod.Invoke(dictionaryInstance, new object[] { "Key2", 200 });

//            MethodInfo getItemMethod = dictionaryType.GetProperty("Item").GetGetMethod();
//            int value = (int)getItemMethod.Invoke(dictionaryInstance, new object[] { "Key1" });
//            Console.WriteLine($"Dictionary Value for Key1: {value}");

//            // Task 4: Auto-discover and execute plugins
//            string pluginsDirectory = ".";
//            string[] pluginFiles = System.IO.Directory.GetFiles(pluginsDirectory, "*.dll");
//            foreach (string pluginFile in pluginFiles)
//            {
//                Assembly pluginAssembly = Assembly.LoadFrom(pluginFile);
//                Type[] pluginTypes = pluginAssembly.GetExportedTypes();

//                foreach (Type pluginType in pluginTypes)
//                {
//                    Type[] interfacesImplemented = pluginType.GetInterfaces();
//                    if (interfacesImplemented.Contains(typeof(IPlugin)))
//                    {
//                        object pluginInstance = Activator.CreateInstance(pluginType);
//                        MethodInfo pluginMethod = pluginType.GetMethod("Execute");
//                        pluginMethod.Invoke(pluginInstance, null);
//                    }
//                }
//            }

//            Console.ReadKey();
//        }
//    }
//}
