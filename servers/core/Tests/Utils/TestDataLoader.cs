using System.Text.Json;

namespace ReadersCorner.Core.Tests.Services.Utils
{
    public static class TestDataLoader
    {
        public static T GetSingle<T>() => GetTestData<T>(typeof(T).Name);

        public static List<T> GetList<T>(bool dev = false) => GetTestData<List<T>>($"{typeof(T).Name}s", dev);

        private static T GetTestData<T>(string className, bool dev = false) => LoadTestData<T>($"{className}.json", dev);

        private static T LoadTestData<T>(string jsonFileName, bool dev = false)
        {
            var json = string.Empty;
            if (dev)
                json = File.ReadAllText($"../core/Tests/Data/{jsonFileName}");
            else
                json = File.ReadAllText($"../../../Tests/Data/{jsonFileName}");

            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}