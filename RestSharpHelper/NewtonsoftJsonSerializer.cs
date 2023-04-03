using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;

namespace RestSharpHelper
{
    public class NewtonsoftJsonSerializer : IRestSerializer, ISerializer, IDeserializer
    {
        public string[] SupportedContentTypes { get; } = {
            "application/json", "text/json", "text/x-json", "text/javascript", "*+json"
        };

        public string ContentType { get; set; } = "application/json";

        public DataFormat DataFormat { get; } = DataFormat.Json;

        public string[] AcceptedContentTypes => SupportedContentTypes;

        public SupportsContentType SupportsContentType => s => s.Value == RestSharp.ContentType.Json;

        public static NewtonsoftJsonSerializer Default => new NewtonsoftJsonSerializer();

        public ISerializer Serializer => Default;

        public IDeserializer Deserializer => Default;

        ContentType ISerializer.ContentType { get; set; } = RestSharp.ContentType.Json;

        public T Deserialize<T>(RestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public string Serialize(Parameter parameter)
        {
            return Serialize(parameter.Value);
        }
    }
}
