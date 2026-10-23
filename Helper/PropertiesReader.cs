
namespace DigitalForm_AutomationSuite.Helper
{
    public class PropertiesReader
    {
        private readonly Dictionary<string, string> properties = new Dictionary<string, string>();

        public PropertiesReader(string filePath)
        {
            foreach (var line in File.ReadAllLines(filePath))
            {
                if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                {
                    var parts = line.Split('=', 2);
                    if (parts.Length == 2)
                    {
                        properties[parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }
        }

        public string Get(string key)
        {
            return properties.ContainsKey(key) ? properties[key] : null;
        }
    }
}

