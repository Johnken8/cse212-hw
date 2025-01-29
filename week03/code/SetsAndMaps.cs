using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var pairs = new List<string>();
        var wordSet = new HashSet<string>(words);
        
        foreach (var word in words)
        {
            if (word[0] == word[1]) continue; // Skip same-letter words
            
            string reversed = new string(new[] { word[1], word[0] });
            if (wordSet.Contains(reversed) && string.Compare(word, reversed) < 0)
            {
                pairs.Add($"{word} & {reversed}");
            }
        }
        
        return pairs.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            string degree = fields[3].Trim();
            
            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2))
            return false;

        // Remove spaces and convert to lowercase
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        var charCount = new Dictionary<char, int>();

        // Count characters in first word
        foreach (char c in word1)
        {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }

        // Subtract counts for second word
        foreach (char c in word2)
        {
            if (!charCount.ContainsKey(c))
                return false;
                
            charCount[c]--;
            if (charCount[c] == 0)
                charCount.Remove(c);
        }

        return charCount.Count == 0;
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
        
        return featureCollection.Features
            .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag}")
            .ToArray();
    }
}