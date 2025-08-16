using System.ComponentModel.DataAnnotations;

namespace WebApiService.Logic.Model
{
    /// <summary>
    /// 勤怠削除パラメータモデル
    /// </summary>
    public class AttendanceDeleteParam
    {
        /// <summary>
        /// 勤怠ID
        /// </summary>
        /// [Required]
        [Required]
        [DataType(DataType.Text)]
        public string AttendanceId { get; set; } = string.Empty;

        /// <summary>
        /// 更新理由
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string Reason { get; set; } = string.Empty;
    }
}
