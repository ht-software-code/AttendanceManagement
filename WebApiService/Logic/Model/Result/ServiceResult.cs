using System.Runtime.Serialization;
using WebApiService.Common.Const;
using WebApiService.Resource;

namespace WebApiService.Logic
{
    /// <summary>
    /// 汎用結果クラス
    /// </summary>
    /// <typeparam name="T">応答データ型</typeparam>
    [Serializable]
    [DataContract]
    public class ServiceResult<T>
    {
        /// <summary>
        /// 結果
        /// </summary>
        public bool IsSuccess { get; private set; }

        /// <summary>
        /// エラーコード
        /// </summary>
        public string ErrorCode { get; private set; } = string.Empty;

        /// <summary>
        /// エラーメッセージ
        /// </summary>
        public string ErrorMessage { get; private set; } = string.Empty;

        /// <summary>
        /// 応答データ型
        /// </summary>
        public T? Value { get; set; }

        /// <summary>
        /// 成功時の応答データ作成
        /// </summary>
        /// <param name="value"></param>
        /// <returns>応答データ</returns>
        public static ServiceResult<T> CreateSuccess(T value)
        {
            return ServiceResult<T>.CreateSuccess(value, string.Empty, string.Empty);
        }

        /// <summary>
        /// 成功時にエラー付き応答データ作成
        /// </summary>
        /// <param name="value"></param>
        /// <param name="error">エラーコード定義</param>
        /// <returns>応答データ</returns>
        public static ServiceResult<T> CreateSuccessWithError(T value, ApplicationErrorCode error)
        {
            return ServiceResult<T>.CreateSuccess(value, error.Id, ApplicationErrorResource.ResourceManager.GetString(error.ResourceKey) ?? string.Empty);
        }

        /// <summary>
        /// 成功時の応答データ作成
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errorCode">エラーコード</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>応答データ</returns>
        public static ServiceResult<T> CreateSuccess(T value, string errorCode, string errorMessage)
        {
            var instance = new ServiceResult<T>();
            instance.IsSuccess = true;
            instance.Value = value;
            instance.ErrorCode = errorCode;
            instance.ErrorMessage = errorMessage;

            return instance;
        }

        /// <summary>
        /// エラー時の応答データ作成
        /// </summary>
        /// <param name="error">エラーコード定義</param>
        /// <returns>応答データ</returns>
        public static ServiceResult<T> CreateError(ApplicationErrorCode error)
        {
            return ServiceResult<T>.CreateError(error.Id, ApplicationErrorResource.ResourceManager.GetString(error.ResourceKey) ?? string.Empty);
        }

        /// <summary>
        /// エラー時の応答データ作成
        /// </summary>
        /// <param name="errorCode">エラーコード</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>応答データ</returns>
        public static ServiceResult<T> CreateError(string errorCode, string errorMessage)
        {
            var instance = new ServiceResult<T>();
            instance.ErrorCode = errorCode;
            instance.ErrorMessage = errorMessage;

            return instance;
        }
    }
}
