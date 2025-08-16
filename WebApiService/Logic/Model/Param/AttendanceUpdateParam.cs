using System.ComponentModel.DataAnnotations;

namespace WebApiService.Logic.Model
{
    /// <summary>
    /// 勤怠更新パラメータモデル
    /// </summary>
    public class AttendanceUpdateParam
    {
        /// <summary>
        /// 勤怠ID
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public Guid AttendanceId { get; set; }

        /// <summary>
        /// ユーザーコード
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string UserCode { get; set; } = string.Empty;

        /// <summary>
        /// 出勤時刻（UTC）のUNIX時間（秒）
        /// </summary>
        [DataType(DataType.Text)]
        public string? ClockInUtcDateUnixTimeSec { get; set; }

        /// <summary>
        /// 退勤時刻（UTC）のUNIX時間（秒）
        /// </summary>
        [DataType(DataType.Text)]
        public string? ClockOutUtcDateUnixTimeSec { get; set; }

        /// <summary>
        /// 休憩開始時刻（UTC）のUNIX時間（秒）
        /// </summary>
        [DataType(DataType.Text)]
        public string? BreakInDateUtcUnixTimeSec { get; set; }

        /// <summary>
        /// 休憩終了時刻（UTC）のUNIX時間（秒）
        /// </summary>
        [DataType(DataType.Text)]
        public string? BreakOutDateUtcUnixTimeSec { get; set; }

        /// <summary>
        /// 勤務形態
        /// </summary>
        public int? WorkingStyleState { get; set; }

        /// <summary>
        /// 更新理由
        /// </summary>
        public string Reason { get; set; } = string.Empty;
    }
}
