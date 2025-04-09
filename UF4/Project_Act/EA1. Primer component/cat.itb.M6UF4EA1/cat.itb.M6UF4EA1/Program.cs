using System;
using ClassLibrary;

namespace cat.itb.M6UF4EA1
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Class1.suma(6,6));
            int[] array = {1,2,3,4,5,51,41,52,62,45,74,8,98,71,100};

            Class1.mostrarArray(array);

            Console.ReadKey();

        }
    }
}