using Newtonsoft.Json;

namespace ClassMapper.JsonMapper
{
    public static class JsonMapper
    {
        public static T1 Convert<T, T1>(T convertFrom)
        {
            return JsonConvert.DeserializeObject<T1>(JsonConvert.SerializeObject(convertFrom));
        }
    }
}