using System.ComponentModel;

namespace BYB.WebAPI
{
    /// <summary>
    /// 返回错误枚举对象
    /// </summary>
    public enum EResultCode : long
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        s001,
        /// <summary>
        /// 失败-请求参数错误
        /// </summary>
        [Description("失败-请求参数错误")]
        s002,
        /// <summary>
        /// 失败-连接超时
        /// </summary>
        [Description("失败-连接超时")]
        s003,
        /// <summary>
        /// 失败-未知错误
        /// </summary>
        [Description("失败-未知错误")]
        s004,
        /// <summary>
        /// 失败-内部错误(程序内部抛出友好异常)
        /// </summary>
        [Description("失败-内部错误(程序内部抛出友好异常)")]
        s005,
    }

    /// <summary>
    /// 内部错误枚举对象
    /// </summary>
    public enum EErrorCode : long
    {
        /// <summary>
        /// 登陆成功
        /// </summary>
        [Description("登陆成功")]
        s001,
        /// <summary>
        /// 用户名为空
        /// </summary>
        [Description("用户名为空")]
        s002,
        /// <summary>
        /// 密码为空
        /// </summary>
        [Description("密码为空")]
        s003,
        /// <summary>
        /// 未找到用户
        /// </summary>
        [Description("未找到用户")]
        s004,
        /// <summary>
        /// 用户被限制登陆
        /// </summary>
        [Description("用户被限制登陆")]
        s005,
        /// <summary>
        /// 密码失败
        /// </summary>
        [Description("密码失败")]
        s006,
    }
}
