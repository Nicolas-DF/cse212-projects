public class FeatureCollection
{
    public Feature[] Features { get; set; }
    public class Feature
    {
        public Properties Properties { get; set; }
    }
    public class Properties
    {
        public string Place { get; set; }
        public double Mag { get; set; }
    }


    public double AverageMagnitude()
    {
        double total = 0;
        foreach (var feature in Features)
        {
            total += feature.Properties.Mag;
        }
        return total / Features.Length;
    }
    public string StrongestEarthquakeLocation()
    {
        double maxMag = double.MinValue;
        string location = "";
        foreach (var feature in Features)
        {
            if (feature.Properties.Mag > maxMag)
            {
                maxMag = feature.Properties.Mag;
                location = feature.Properties.Place;
            }
        }
        return location;
    }
    public int CountStrongEarthquakes(double threshold)
    {
        int count = 0;
        foreach (var feature in Features)
        {
            if (feature.Properties.Mag >= threshold)
            {
                count++;
            }
        }
        return count;
    }
}