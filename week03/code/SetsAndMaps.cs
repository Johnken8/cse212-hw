using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public static class SetsAndMaps
{
    // Problem 1: FindPairs - O(n) solution using HashSet
    public static string[] FindPairs(string[] words)
    {
        var result = new List<string>();
        var seen = new HashSet<string>();

        foreach (var word in words)
        {
            // Skip words with same letters (e.g., "aa")
            if (word[0] == word[1]) continue;
            
            string reversed = new string(word.Reverse().ToArray());
            if (seen.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return result.ToArray();
    }

    // Problem 2: SummarizeDegrees - Dictionary to count degrees
    public static Dictionary<string, int> SummarizeDegrees(string filePath)
    {
        var degreeSummary = new Dictionary<string, int>();
        
        try
        {
            // Skip header row and process each line
            foreach (var line in File.ReadLines(filePath).Skip(1))
            {
                var columns = line.Split(',');
                if (columns.Length >= 4)
                {
                    string degree = columns[3].Trim();
                    degreeSummary[degree] = degreeSummary.GetValueOrDefault(degree, 0) + 1;
                }
            }
        }
        catch (Exception)
        {
            // Return empty dictionary if file can't be read
            return new Dictionary<string, int>();
        }

        return degreeSummary;
    }

    // Problem 3: IsAnagram - Using Dictionary for character counting
    public static bool IsAnagram(string word1, string word2)
    {
        // Remove spaces and convert to lowercase
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // If lengths are different, they can't be anagrams
        if (word1.Length != word2.Length) return false;

        var charCount = new Dictionary<char, int>();

        // Count characters in first word
        foreach (char c in word1)
        {
            charCount[c] = charCount.GetValueOrDefault(c, 0) + 1;
        }

        // Decrement counts for second word
        foreach (char c in word2)
        {
            if (!charCount.ContainsKey(c)) return false;
            charCount[c]--;
            if (charCount[c] == 0) charCount.Remove(c);
        }

        // If dictionary is empty, all characters matched
        return charCount.Count == 0;
    }

    // Problem 5: Earthquake JSON Data
    public static string[] EarthquakeDailySummary()
    {
        try
        {
            string jsonData = File.ReadAllText("../../../earthquakes.json");
            var featureCollection = JsonConvert.DeserializeObject<FeatureCollection>(jsonData);
            return featureCollection?.Features?
                .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag:F2}")
                .ToArray() ?? Array.Empty<string>();
        }
        catch (Exception)
        {
            return Array.Empty<string>();
        }
    }
}