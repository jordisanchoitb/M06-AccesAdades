namespace ClassLibrary
{
    public class Class1
    {
        public static int suma(int a, int b)
        {
            return a + b;
        }

        public static void mostrarArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
