using BYB.WebAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BYB.Test
{
    [TestClass]
    public class WebAPIUnitTest
    {
        /// <summary>
        /// HTTP Get 请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private APIJsonResult HttpGet(string url, params object[] args)
        {
            object result;
            //TODO...
            //result = http get url download data

            return null;
        }

        /// <summary>
        /// 以内部项目方式调试
        /// </summary>
        [TestMethod]
        public void TestLogin()
        {
            //s001 123456 成功用户
            //s001 123456X 密码错误
            //s002 123456 未知道用户
            //s003 123456 已禁用用户

            var api = new WebAPIServices();

            UserInfo userInfo;
            try
            {
                userInfo = api.Login("s001", "");
            }
            catch (ArgsNullException e)
            {
                //密码为空
                Assert.Equals(e.ErrorCode, EErrorCode.s003);
            }

            try
            {
                userInfo = api.Login("", "123456");
            }
            catch (ArgsNullException e)
            {
                //用户名为空
                Assert.Equals(e.ErrorCode, EErrorCode.s002);
            }

            try
            {
                userInfo = api.Login("s002", "123456");
            }
            catch (InnerException e)
            {
                //未找到用户
                Assert.Equals(e.ErrorCode, EErrorCode.s004);
            }

            try
            {
                userInfo = api.Login("s001", "123456X");
            }
            catch (InnerException e)
            {
                //密码错误
                Assert.Equals(e.ErrorCode, EErrorCode.s006);
            }

            try
            {
                userInfo = api.Login("s003", "123456");
            }
            catch (InnerException e)
            {
                //用户被限制登陆
                Assert.Equals(e.ErrorCode, EErrorCode.s005);
            }

            //成功登录
            userInfo = api.Login("s001", "123456");
            Assert.AreEqual(userInfo.UserID, "s001");
        }

        /// <summary>
        /// 以WepAPI方式调试
        /// </summary>
        [TestMethod]
        public void WebTestLogin()
        {
            //s001 123456 成功用户
            //s001 123456X 密码错误
            //s002 123456 未知道用户
            //s003 123456 已禁用用户

            string url = "http://192.168.1.254:1080/wepapi/login";

            //密码为空
            var postdata = new
            {
                userId = "s001",
                userPwd = "",
            };
            var result = HttpGet(url, postdata);
            Assert.Equals(result.code, EResultCode.s002.ToString());

            //用户名为空
            postdata = new
            {
                userId = "",
                userPwd = "123456",
            };
            result = HttpGet(url, postdata);
            Assert.Equals(result.code, EResultCode.s002.ToString());

            //未找到用户
            postdata = new
            {
                userId = "s002",
                userPwd = "123456",
            };
            result = HttpGet(url, postdata);
            Assert.Equals(result.code, EResultCode.s005.ToString());
            var errorCode = (EErrorCode)Enum.Parse(typeof(EErrorCode), result.data);
            Assert.Equals(errorCode, EErrorCode.s004);

            //密码错误
            postdata = new
            {
                userId = "s001",
                userPwd = "123456X",
            };
            result = HttpGet(url, postdata);
            Assert.Equals(result.code, EResultCode.s005.ToString());
            errorCode = (EErrorCode)Enum.Parse(typeof(EErrorCode), result.data);
            Assert.Equals(errorCode, EErrorCode.s006);

            //用户处于禁用
            postdata = new
            {
                userId = "s003",
                userPwd = "123456",
            };
            result = HttpGet(url, postdata);
            Assert.Equals(result.code, EResultCode.s005.ToString());
            errorCode = (EErrorCode)Enum.Parse(typeof(EErrorCode), result.data);
            Assert.Equals(errorCode, EErrorCode.s005);

            //成功登录
            postdata = new
            {
                userId = "s001",
                userPwd = "123456",
            };
            result = HttpGet(url, postdata);
            Assert.Equals(result.code, EResultCode.s001.ToString());
            var userInfo = JsonHelper.ToObject<UserInfo>(result.data);
            Assert.AreEqual(userInfo.UserID, postdata.userId);
        }
    }
}