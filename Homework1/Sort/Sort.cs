namespace QuickSort;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Class that contains QuickSort function implementation and tests for it. 
static class Sort
{
    // Function that sorts an array using QuickSort.
    public static void QuickSort(int[] array)
    {
        QuickSortRecursion(array, 0, array.Length - 1);
    }
    
    static void QuickSortRecursion(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(array, low, high);
            QuickSortRecursion(array, low, pivotIndex - 1);
            QuickSortRecursion(array, pivotIndex + 1, high);
        } 
    }
    
    static int Partition(int[] array, int low, int high)
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
    
    // Function that tests QuickSort function.
    public static bool Tests()
    {
        int[] testArray0 = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
        Sort.QuickSort(testArray0);
        if (!IsSorted(testArray0))
        {
            Console.WriteLine("Tests failed on a reversed array");
            return false;
        }

        int[] testArray2 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        Sort.QuickSort(testArray2);
        if (!IsSorted(testArray2))
        {
            Console.WriteLine("Tests failed on a sorted array");
            return false;
        }

        int[] testArray3 = { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
        Sort.QuickSort(testArray3);
        if (!IsSorted(testArray3))
        {
            Console.WriteLine("Tests failed on an array of the same element");
            return false;
        }
            
        return true;
    }
}
