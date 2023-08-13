using System.Text.Json;

namespace ReadersCorner.Core.Tests.Services.Utils
{
    public static class TestDataLoader
    {
        private class TestData<T>
        {
            public T Single { get; set; }
            public List<T> List { get; set; }
        }

        private static T LoadTestData<T>(string jsonFileName)
        {
            var json = File.ReadAllText($"../../../Tests/Data/{jsonFileName}");
            return JsonSerializer.Deserialize<T>(json);
        }

        public static T GetSingle<T>() => GetTestData<T>().Single;

        public static List<T> GetList<T>() => GetTestData<T>().List;

        private static TestData<T> GetTestData<T>() => LoadTestData<TestData<T>>($"{typeof(T).Name}.json");
    }
}