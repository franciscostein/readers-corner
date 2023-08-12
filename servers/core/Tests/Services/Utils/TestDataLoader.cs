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
            var json = File.ReadAllText(jsonFileName);
            return JsonSerializer.Deserialize<T>(json);
        }

        public static T GetSingle<T>()
        {
            var testData = LoadTestData<TestData<T>>($"{typeof(T).Name}.json");
            return testData.Single;
        }

        public static List<T> GetList<T>()
        {
            var testData = LoadTestData<TestData<T>>($"{typeof(T).Name}.json");
            return testData.List;
        }
    }
}