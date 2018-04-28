
namespace BYB.WebAPI
{
    //标准接口返回对象
    public class APIJsonResult
    {
        //返回代码
        public string code { get; set; }
        //提示信息（若调用服务在服务器端抛出异常,则可以通过msg获取友好提示,如果执行成功则改字段为空字符串）。
        public string msg { get; set; }
        ///返回数据对象json字符串（若该API接口为void,则该字段为空字符串）。
        public string data { get; set; }
    }
}
