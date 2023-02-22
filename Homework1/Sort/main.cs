namespace QuickSort;

using System;

class Program
{
    static void Main(string[] args)
    {
        if (Sort.Tests())
        {
            Console.Write("Eneter a length of the array: ");
            int length = Convert.ToInt32(Console.ReadLine());
            var array = new int[length];
            for (int i = 0; i < length; i++) 
            {
                Console.Write($"Enter the element number {i}: ");
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Array before sort: ");
            DisplayArray(array);
            Sort.QuickSort(array);
            Console.Write("Array after sort: ");
            DisplayArray(array);
        }
        else
        {
            Console.WriteLine("Tests weren't passed");
        }
    }
    static void DisplayArray(int[] array)
    {
        foreach (int item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
 }



