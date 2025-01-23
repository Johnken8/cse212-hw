using Newtonsoft.Json;
using System.Collections.Generic;

public class FeatureCollection
{
    [JsonProperty("features")]
    public List<Feature> Features { get; set; } = new List<Feature>();
}

public class Feature
{
    [JsonProperty("properties")]
    public Properties Properties { get; set; } = new Properties();
}

public class Properties
{
    [JsonProperty("place")]
    public string Place { get; set; } = string.Empty;

    [JsonProperty("mag")]
    public double Mag { get; set; }
}