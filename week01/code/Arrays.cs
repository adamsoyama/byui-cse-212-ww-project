public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
       // Step 1: Create a new array of doubles with the specified 'length'.
    double[] result = new double[length];

    // Step 2: Use a loop to fill the array.
    // The loop will run from 0 to length - 1.
    // For each index i, calculate the multiple: number * (i + 1)
    // Store that value in result[i].

    for (int i = 0; i < length; i++)
    {
        result[i] = number * (i + 1);
    }

    // Step 3: Return the filled array.
    return result;

    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Identify the portion of the list to move.
    // Since we're rotating to the right, we want to move the last 'amount' elements to the front.
    // For example, if amount = 3 and data = {1,2,3,4,5,6,7,8,9}, we want to move {7,8,9} to the front.

    // Step 2: Use GetRange to extract the last 'amount' elements.
    List<int> tail = data.GetRange(data.Count - amount, amount);

    // Step 3: Remove those elements from the end of the list.
    data.RemoveRange(data.Count - amount, amount);

    // Step 4: Insert the extracted elements at the beginning of the list.
    data.InsertRange(0, tail);

    // The list is now rotated to the right by 'amount'.

    }
}
