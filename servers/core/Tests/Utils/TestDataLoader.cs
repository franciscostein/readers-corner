using System.Text.Json;
using ReadersCorner.Core.Exceptions;
using ReadersCorner.Core.Models.Interfaces;

namespace ReadersCorner.Core.Tests.Services.Utils
{
    public static class TestDataLoader
    {
        public static T GetSingle<T>() => GetTestData<T>(typeof(T).Name);

        public static T GetById<T>(int id) where T : IModel
        {
            var list = GetList<T>();
            var entity = list.Find(entity => entity.Id == id);

            if (entity != null)
                return entity;
            else
                throw new NotFoundException("Result not found");
        }

        public static List<T> GetList<T>(bool dev = false) => GetTestData<List<T>>($"{typeof(T).Name}s", dev);

        private static T GetTestData<T>(string className, bool dev = false) => LoadTestData<T>($"{className}.json", dev);

        private static T LoadTestData<T>(string jsonFileName, bool dev = false)
        {
            var json = dev ?
                File.ReadAllText($"../core/Tests/Data/{jsonFileName}") :
                File.ReadAllText($"../../../Tests/Data/{jsonFileName}");

            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}