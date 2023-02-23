
namespace Example.WebAPI
{
    /// <summary>
    /// WebAPI Service 对象
    /// </summary>
    public class WebAPIServices
    {
        /// <summary>
        /// 用户登录(若登录成功，并返回该用户的数据)
        /// </summary>
        /// <param name="userId">用户登录Id</param>
        /// <param name="userPwd">用户登录密码</param>
        /// <returns></returns>
        public UserInfo Login(string userId, string userPwd)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgsNullException(EErrorCode.s002);

            if (string.IsNullOrEmpty(userPwd))
                throw new ArgsNullException(EErrorCode.s003);

            var result = new UserInfo();
            //TODO...
            //result = db.GetUserInfoByUserId(userId);//获取用户信息
            //TODO
            if (result == null)
                throw new InnerException(EErrorCode.s004);

            if (result.DisEnable)
                throw new InnerException(EErrorCode.s005);

            if (result.UserPwd.Equals(userPwd))
                throw new InnerException(EErrorCode.s006);

            return result;
        }
    }
}
