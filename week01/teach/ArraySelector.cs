using System;
using System.Collections.Generic;

public static class ArraySelector
{
    /// <summary>
    /// Entry point for the ArraySelector class.
    /// Demonstrates selecting values from two arrays based on a selector array.
    /// </summary>
    public static void Run()
    {
        // Sample input arrays
        var l1 = new[] { 1, 2, 3, 4, 5 };           // Source list 1
        var l2 = new[] { 2, 4, 6, 8, 10 };          // Source list 2
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 }; // Selector array

        // Call the selector function
        var intResult = ListSelector(l1, l2, select);

        // Print the result
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}");
        // Expected output: <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    /// <summary>
    /// Combines two arrays into a new array based on a selector array.
    /// Each value in 'select' determines which list to pull the next value from.
    /// </summary>
    /// <param name="list1">First source array</param>
    /// <param name="list2">Second source array</param>
    /// <param name="select">Array of 1s and 2s indicating selection source</param>
    /// <returns>New array built by selecting values from list1 and list2</returns>
    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        // Step 1: Create result array with same length as 'select'
        int[] result = new int[select.Length];

        // Step 2: Initialize counters for list1 and list2
        int i1 = 0; // Tracks position in list1
        int i2 = 0; // Tracks position in list2

        // Step 3: Loop through each index of 'select'
        for (int i = 0; i < select.Length; i++)
        {
            if (select[i] == 1)
            {
                // Take next value from list1
                result[i] = list1[i1];
                i1++; // Move to next item in list1
            }
            else if (select[i] == 2)
            {
                // Take next value from list2
                result[i] = list2[i2];
                i2++; // Move to next item in list2
            }
            else
            {
                // Defensive: If select[i] is not 1 or 2, throw error
                throw new ArgumentException($"Invalid selector value at index {i}: {select[i]}");
            }
        }

        // Step 4: Return the result array
        return result;
    }
}