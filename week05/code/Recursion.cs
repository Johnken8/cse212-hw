using System.Collections;
using System.Diagnostics;

public static class Recursion
{
    public static int SumSquaresRecursive(int n)
    {
        // Base case: if n <= 0, return 0
        if (n <= 0)
            return 0;
            
        // Recursive case: n^2 + sum of squares from 1 to (n-1)
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: if we've built a word of the desired size, add it to results
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Try each letter as the next character
        for (int i = 0; i < letters.Length; i++)
        {
            // Skip if this letter is already used in our current word
            if (word.Contains(letters[i]))
                continue;
                
            // Add this letter and recurse
            PermutationsChoose(results, letters, size, word + letters[i]);
        }
    }

    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Initialize memoization dictionary on first call
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Base cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // Check if we've already calculated this value
        if (remember.ContainsKey(s))
            return remember[s];

        // Calculate ways recursively with memoization
        decimal ways = CountWaysToClimb(s - 1, remember) + 
                      CountWaysToClimb(s - 2, remember) + 
                      CountWaysToClimb(s - 3, remember);
                      
        // Store result in memoization dictionary
        remember[s] = ways;
        
        return ways;
    }

    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Base case: if no wildcards, add the pattern
        if (!pattern.Contains('*'))
        {
            results.Add(pattern);
            return;
        }

        // Find first wildcard
        int starIndex = pattern.IndexOf('*');
        
        // Replace first * with 0 and recurse
        string pattern0 = pattern[..starIndex] + "0" + pattern[(starIndex + 1)..];
        WildcardBinary(pattern0, results);
        
        // Replace first * with 1 and recurse
        string pattern1 = pattern[..starIndex] + "1" + pattern[(starIndex + 1)..];
        WildcardBinary(pattern1, results);
    }

    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize path on first call
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        // Add current position to path
        currPath.Add((x, y));

        // If we reached the end, add the solution
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Try all possible moves: right, down, left, up
        int[,] moves = { {1,0}, {0,1}, {-1,0}, {0,-1} };
        
        for (int i = 0; i < 4; i++)
        {
            int newX = x + moves[i,0];
            int newY = y + moves[i,1];
            
            // Check if move is valid
            if (maze.IsValidMove(currPath, newX, newY))
            {
                SolveMaze(results, maze, newX, newY, currPath);
            }
        }

        // Remove current position from path when backtracking
        currPath.RemoveAt(currPath.Count - 1);
    }
}