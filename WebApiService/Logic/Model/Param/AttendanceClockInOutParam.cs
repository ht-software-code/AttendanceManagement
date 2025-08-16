using System.ComponentModel.DataAnnotations;

namespace WebApiService.Logic.Model
{
    /// <summary>
    /// 出退勤登録パラメータモデル
    /// </summary>
    public class AttendanceClockInOutParam
    {
        /// <summary>
        /// 出退勤日時（UTC）のUNIX時間（秒）
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string ClockInOutDateTimeUserUnixTimeSec { get; set; } = string.Empty;
    }
}
