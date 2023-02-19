using System;

namespace quickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Sort.Tests())
            {
                Console.Write("Eneter a length of the array: ");
                int length = Convert.ToInt32(Console.ReadLine());
                int[] array = new int[length];
                for (int i = 0; i < length; i++) 
                {
                    Console.Write($"Enter the element number {i}: ");
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.Write("Array before sort: ");
                DisplayArray(array);
                Sort.quickSort(array);
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
    static class Sort
    {
        static public void quickSort(int[] array)
        {
            quickSortRecursion(array, 0, array.Length - 1);
        }
        static void quickSortRecursion(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = partition(array, low, high);
                quickSortRecursion(array, low, pivotIndex - 1);
                quickSortRecursion(array, pivotIndex + 1, high);
            } 
        }
        static int partition(int[] array, int low, int high)
        {
            int pivotValue = array[high];
            int i = low;
            for (int j = low; j < high; j++) 
            {
                if (array[j] <= pivotValue) 
                {
                    Swap(ref array[j], ref array[j]);
                    i++;
                }   
            }
            Swap(ref array[i], ref array[high]);
            return i;
        }
        static void Swap(ref int oneValue, ref int anotherValue)
        {
            int temp = oneValue;
            oneValue = anotherValue;
            anotherValue = temp;
        }
        static bool IsSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
        static public bool Tests()
        {
            int[] testArray0 = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            Sort.quickSort(testArray0);
            if (!IsSorted(testArray0))
            {
                Console.WriteLine("Tests failed on a reversed array");
                return false;
            }

            int[] testArray2 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            Sort.quickSort(testArray2);
            if (!IsSorted(testArray2))
            {
                Console.WriteLine("Tests failed on a sorted array");
                return false;
            }

            int[] testArray3 = { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            Sort.quickSort(testArray3);
            if (!IsSorted(testArray3))
            {
                Console.WriteLine("Tests failed on an array of the same element");
                return false;
            }
            
            return true;
        }
    }
}