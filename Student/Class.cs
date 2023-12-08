using System;

namespace ClassLibrary
{
    public interface IPlugin
    {
        void Execute();
    }

    public class Class
    {
        public string GetName()
        {
            return "John";
        }

        public int GetAge()
        {
            return 25;
        }
    }
}
