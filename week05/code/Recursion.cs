using System.Collections;
using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + ... + n^2.
    /// Base case: if n <= 0, return 0.
    /// Recursive case: n^2 + SumSquaresRecursive(n-1).
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0; // base case
        return n * n + SumSquaresRecursive(n - 1); // recursive case
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length 'size'
    /// from a list of 'letters' into the results list.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: when word length == size, add to results
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive case: choose each letter, remove it from pool, recurse
        for (int i = 0; i < letters.Length; i++)
        {
            char chosen = letters[i];
            string remaining = letters.Substring(0, i) + letters.Substring(i + 1);
            PermutationsChoose(results, remaining, size, word + chosen);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count ways to climb s stairs taking 1, 2, or 3 steps at a time.
    /// Use memoization to avoid recomputation.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null) remember = new Dictionary<int, decimal>();

        // Base cases
        if (s < 0) return 0;
        if (s == 0) return 1;

        if (remember.ContainsKey(s)) return remember[s];

        decimal ways = CountWaysToClimb(s - 1, remember) +
                       CountWaysToClimb(s - 2, remember) +
                       CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Wildcard Binary Patterns
    /// Replace '*' with '0' and '1' recursively until no '*' remains.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Replace * with 0
        WildcardBinary(pattern.Substring(0, index) + "0" + pattern.Substring(index + 1), results);

        // Replace * with 1
        WildcardBinary(pattern.Substring(0, index) + "1" + pattern.Substring(index + 1), results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Maze Solver: Use recursion and backtracking to find all paths
    /// from (0,0) to the end square.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null) currPath = new List<ValueTuple<int, int>>();

        // If move is invalid, stop
        if (!maze.IsValidMove(currPath, x, y)) return;

        // Add current position
        currPath.Add((x, y));

        // If at end, record path
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1); // backtrack
            return;
        }

        // Explore neighbors (down, up, right, left)
        SolveMaze(results, maze, x + 1, y, currPath);
        SolveMaze(results, maze, x - 1, y, currPath);
        SolveMaze(results, maze, x, y + 1, currPath);
        SolveMaze(results, maze, x, y - 1, currPath);

        // Backtrack
        currPath.RemoveAt(currPath.Count - 1);
    }
}