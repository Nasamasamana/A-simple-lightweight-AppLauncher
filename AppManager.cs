using System.Text.Json;

namespace LightLauncher
{
    public static class AppManager
    {
        private static string filePath = "apps.json";

        public static List<AppItem> LoadApps()
        {
            if (!File.Exists(filePath))
                return new List<AppItem>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<AppItem>>(json) ?? new List<AppItem>();
        }

        public static void SaveApps(List<AppItem> apps)
        {
            string json = JsonSerializer.Serialize(apps, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
