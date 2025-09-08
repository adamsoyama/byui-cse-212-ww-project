public static class ArraySelector
{
    public static void Run()
    {
        // Original test case from instructions
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10 };
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 };

        // Call to the implemented int version of ListSelector
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
        
        
        //  NEW: Added support for char arrays to demonstrate generic behavior
        var l3 = new[] { 'A', 'A', 'A', 'A', 'A' };
        var l4 = new[] { 'B', 'B', 'B', 'B', 'B' };
        select = [1, 2, 1, 2, 1, 2, 1, 2, 1, 2];

        // Call to the newly added char version of ListSelector
        var charResult = ListSelector(l3, l4, select);
        Console.WriteLine("<char[]>{" + string.Join(", ", charResult) + "}"); // Expected output: <char[]>{A, B, A, B, A, B, A, B, A, B}
    }

// 🔹 REPLACED: Instead of using List<int>, this version uses a fixed-size array for better performance
    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        var result = new int[select.Length]; // Pre-allocated array for efficiency
        var l1Idx = 0;
        var l2Idx = 0;

        // Loop through selector array and choose from list1 or list2
        for (var i = 0; i < select.Length; i++)
        {
            if (select[i] == 1)
                result[i] = list1[l1Idx++]; // Select from list1
            else
                result[i] = list2[l2Idx++]; // Select from list2
        }

        return result;
    }

    // NEW: Added method to support char arrays using the same selector logic

    private static char[] ListSelector(char[] list1, char[] list2, int[] select)
    {
        var result = new char[select.Length]; // Pre-allocated array for efficiency
        var l1Idx = 0;
        var l2Idx = 0;

        // Ternary operator used for concise selection logic
        for (var i = 0; i < select.Length; i++)
        {
            result[i] = select[i] == 1 ? list1[l1Idx++] : list2[l2Idx++];
        }

        return result;
    }
}
