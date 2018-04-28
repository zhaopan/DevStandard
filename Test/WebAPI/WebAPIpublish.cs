
namespace BYB.WebAPI
{
    /// <summary>
    /// WebAPI发布对象
    /// </summary>
    public class WebAPIpublish
    {
        private WebAPIServices _webAPI;

        public WebAPIpublish()
        {
            _webAPI = new WebAPIServices();
        }

        /// <summary>
        /// 用户登录(若登录成功，并返回该用户的数据)
        /// </summary>
        /// <param name="userId">用户登录Id</param>
        /// <param name="userPwd">用户登录密码</param>
        /// <returns></returns>
        public string Login(string userId, string userPwd)
        {
            var result = _webAPI.Login(userId, userPwd);
            return result.ToJson();
        }
    }
}
