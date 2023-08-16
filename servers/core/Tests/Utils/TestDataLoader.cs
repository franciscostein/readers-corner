using System.Text.Json;

namespace ReadersCorner.Core.Tests.Services.Utils
{
    public static class TestDataLoader
    {
        public static T GetSingle<T>() => GetTestData<T>(typeof(T).Name);

        public static List<T> GetList<T>() => GetTestData<List<T>>($"{typeof(T).Name}s");

        private static T GetTestData<T>(string className) => LoadTestData<T>($"{className}.json");

        private static T LoadTestData<T>(string jsonFileName)
        {
            var json = File.ReadAllText($"../../../Tests/Data/{jsonFileName}");
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}