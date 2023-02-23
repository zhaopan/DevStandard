using System;

namespace Example.WebAPI
{
    /// <summary>
    /// 基础异常对象
    /// </summary>
    public abstract class BaseException : Exception
    {
        private EErrorCode _errorCode;
        private EResultCode _resultCode;

        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrorCode
        {
            get { return _errorCode.ToString(); }
        }

        /// <summary>
        /// 返回代码
        /// </summary>
        public string ResultCode
        {
            get { return _resultCode.ToString(); }
        }

        /// <summary>
        /// 错误代码对应的错误信息
        /// </summary>
        public string ErrorMessage
        {
            get { return GetEnumDesc<EErrorCode>(_errorCode); }
        }

        /// <summary>
        /// 返回代码对应的错误信息
        /// </summary>
        public string ResultMessage
        {
            get { return GetEnumDesc<EResultCode>(_resultCode); }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errorCode"></param>
        public BaseException(EErrorCode errorCode)
        {
            _errorCode = errorCode;
            _resultCode = EResultCode.s005;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="resultCode"></param>
        public BaseException(EErrorCode errorCode, EResultCode resultCode)
        {
            _errorCode = errorCode;
            _resultCode = resultCode;
        }

        /// <summary>
        /// 获取枚举值的描述信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumObject"></param>
        /// <returns></returns>
        public virtual string GetEnumDesc<T>(T enumObject)
        {
            //TODO..
            return string.Empty;
        }
    }

    /// <summary>
    /// 内部异常-通用内部异常对象
    /// </summary>
    public class InnerException : BaseException
    {
        public InnerException(EErrorCode errorCode)
            : base(errorCode) { }

        public InnerException(EErrorCode errorCode, EResultCode resultCode)
            : base(errorCode, resultCode) { }
    }

    /// <summary>
    /// 内部异常-参数为空异常对象
    /// </summary>
    public class ArgsNullException : BaseException
    {
        public ArgsNullException(EErrorCode errorCode)
            : base(errorCode) { }

        public ArgsNullException(EErrorCode errorCode, EResultCode resultCode)
            : base(errorCode, resultCode) { }
    }

}
