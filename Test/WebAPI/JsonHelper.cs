
namespace Example.WebAPI
{
    public static class JsonHelper
    {
        /// <summary>
        /// 序列化为JSON字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            //TODO..
            return string.Empty;
        }

        /// <summary>
        /// 将JSON字符串反序列化为指定对象
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ToObject<T>(this string json)
        {
            //TODO...
            return default(T);
        }

    }

}
