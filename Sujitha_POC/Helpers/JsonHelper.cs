using Newtonsoft.Json.Linq;
using Sujitha_POC.FileHandler;

namespace Sujitha_POC.Helpers
{
    public class JsonHelper
    {
        private readonly Dictionary<string, JToken> fields = new Dictionary<string, JToken>();

        public dynamic ReadingInputData(string key, string fileName)
        {
            try
            {
                var path = Path.Combine("DataRepository", "JsonFiles", fileName);
                var jsonData = File.ReadAllText(Path.Combine(FileLocations.GetProjectDirectory(), path));
                var data = JToken.Parse(jsonData);
                CheckKeyAndValue(data, key, fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return fields[key];
        }

        private void CheckKeyAndValue(JToken data, string key, string fileName)
        {
            Dictionary<string, JToken> jsonDictionary = CollectFields(data);

            if (!jsonDictionary.TryGetValue(key, out JToken value))
            {
                throw new Exception($"The specified key '{key}' is not present in {fileName}");
            }

            if (IsValueNullOrEmpty(value))
            {
                throw new Exception($"The value corresponding to the key '{key}' is Null or Empty");
            }
        }

        private Dictionary<string, JToken> CollectFields(JToken jToken)
        {
            fields.Clear();
            CollectFieldsRecursive(jToken);
            return fields;
        }

        private void CollectFieldsRecursive(JToken jToken)
        {
            switch (jToken.Type)
            {
                case JTokenType.Object:
                    foreach (var child in jToken.Children<JProperty>())
                    {
                        fields.Add(child.Path, child.Value);
                    }
                    break;
                case JTokenType.Array:
                    foreach (var child in jToken.Children())
                    {
                        CollectFieldsRecursive(child);
                    }
                    break;
                default:
                    fields.Add(jToken.Path, (JValue)jToken);
                    break;
            }
        }

        private bool IsValueNullOrEmpty(JToken token)
        {
            return token == null || !token.HasValues || (token.Type == JTokenType.String && token.ToString() == String.Empty) || token.Type == JTokenType.Null;
        }
    }
}
