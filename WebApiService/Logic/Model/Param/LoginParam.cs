using System.ComponentModel.DataAnnotations;
using WebApiService.Common.Const;
using WebApiService.Resource;

namespace WebApiService.Logic
{
    /// <summary>
    /// ログインパラメータモデル
    /// </summary>
    public class LoginParam
    {
        /// <summary>
        /// ユーザーコード
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(MessageResource), Name = nameof(MessageResource.KeyIdUserId))]
        [StringLength(maximumLength: AuthConst.MaximumUserCodeLength, ErrorMessageResourceType = typeof(ApplicationErrorResource), ErrorMessageResourceName = nameof(ApplicationErrorResource.EnterWithInMaxLengthError))]
        public string UserCode { get; set; } = string.Empty;

        /// <summary>
        /// パスワード
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(MessageResource), Name = nameof(MessageResource.KeyIdPassword))]
        [StringLength(maximumLength: AuthConst.MaximumPasswordLength, ErrorMessageResourceType = typeof(ApplicationErrorResource), ErrorMessageResourceName = nameof(ApplicationErrorResource.EnterWithInMaxLengthError))]
        public string Password { get; set; } = string.Empty;
    }
}
