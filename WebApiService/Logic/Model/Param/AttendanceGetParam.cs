using System.ComponentModel.DataAnnotations;

namespace WebApiService.Logic.Model
{
    /// <summary>
    /// 勤怠取得パラメータモデル
    /// </summary>
    public class AttendanceGetParam
    {
        /// <summary>
        /// 勤怠ID
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public Guid AttendanceId { get; set; }
    }
}
