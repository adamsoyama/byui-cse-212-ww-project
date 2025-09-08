using System;
using System.Collections.Generic;
using System.Diagnostics;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) -> {7, 14, 21, 28, 35}. Assume that length > 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        // 1) Allocate an array with 'length' slots.
        // 2) For each index i from 0 to length-1:
        //      - Compute the (i+1)-th multiple: number * (i + 1).
        //      - Store it into result[i].
        //    (We use (i + 1) because the first multiple is 1 * number.)
        // 3) Return the filled array.
        //
        // NOTE: Debug.WriteLine calls are wrapped with #if DEBUG so they only print in debug builds.
        //       When running tests with the debugger, Debug.WriteLine output appears in the Debug Console.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            // Explanation: i is a zero-based index (starts at 0). Multiples are 1*number, 2*number, ...
            // Therefore we use (i + 1) so that:
            //   i == 0 -> (i + 1) == 1 -> 1 * number  (first multiple)
            //   i == 1 -> (i + 1) == 2 -> 2 * number  (second multiple)
            // This ensures result[0] == number, result[1] == 2*number, etc.
            double multiple = number * (i + 1);
            result[i] = multiple;

            // Useful debug logging when testing — visible in Debug Console.
#if DEBUG
            Debug.WriteLine($"MultiplesOf: i={i}, (i+1)={(i+1)}, multiple={multiple}");
#endif
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by 'amount'. Modifies the list in place.
    /// Example: data = {1,2,3,4,5,6,7,8,9}, amount = 3 -> {7,8,9,1,2,3,4,5,6}.
    /// 'amount' is in [1, data.Count].
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN (slicing approach):
        // Goal: Move the last 'amount' items to the front, keeping order.
        // 1) Guard: If data is null or empty, nothing to do.
        // 2) Normalize 'amount' with modulo data.Count (handles amount == data.Count).
        //    - If amount becomes 0, rotation changes nothing; return.
        // 3) Compute splitIndex = data.Count - amount (start of the tail to move).
        // 4) Copy the tail using GetRange(splitIndex, amount).
        // 5) Remove that tail from the end using RemoveRange.
        // 6) Insert the saved tail at the front using InsertRange(0, tail).
        // This modifies 'data' in place as required.
        //
        // Debug.WriteLine logging (wrapped in #if DEBUG) shows before/after state when debugging.

        if (data == null) throw new ArgumentNullException(nameof(data));
        if (data.Count == 0) return;

        int originalAmount = amount;
        amount %= data.Count;            // handles amount == data.Count and amounts larger than Count (defensive)
#if DEBUG
        Debug.WriteLine($"RotateListRight - originalAmount={originalAmount}, normalized amount={amount}");
        Debug.WriteLine($"RotateListRight - before: [{string.Join(", ", data)}]");
#endif
        if (amount == 0) return;         // no visible change

        int splitIndex = data.Count - amount;

#if DEBUG
        Debug.WriteLine($"RotateListRight - splitIndex={splitIndex}");
#endif

        List<int> tail = data.GetRange(splitIndex, amount); // step 4

#if DEBUG
        Debug.WriteLine($"RotateListRight - tail to move: [{string.Join(", ", tail)}]");
#endif

        data.RemoveRange(splitIndex, amount);               // step 5

#if DEBUG
        Debug.WriteLine($"RotateListRight - after RemoveRange: [{string.Join(", ", data)}]");
#endif

        data.InsertRange(0, tail);                          // step 6

#if DEBUG
        Debug.WriteLine($"RotateListRight - after InsertRange (result): [{string.Join(", ", data)}]");
#endif
    }
}
