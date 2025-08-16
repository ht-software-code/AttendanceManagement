namespace WebApiService.Logic
{
    /// <summary>
    /// 勤怠情報結果モデル
    /// </summary>
    public class AttendanceRecordsResult
    {
        /// <summary>
        /// 勤怠ID
        /// </summary>
        public Guid AttendanceId { get; set; }

        /// <summary>
        /// ユーザーコード
        /// </summary>
        public string UserCode { get; set; } = string.Empty;

        /// <summary>
        /// 勤務日のUNIX時間（秒）
        /// </summary>
        public string WorkDateUserUnixTimeSec { get; set; } = string.Empty;

        /// <summary>
        /// 出勤時刻（UTC）のUNIX時間（秒）
        /// </summary>
        public string ClockInDateUtcUnixTimeSec { get; set; } = string.Empty;

        /// <summary>
        /// 退勤時刻（UTC）のUNIX時間（秒）
        /// </summary>
        public string? ClockOutDateUtcUnixTimeSec { get; set; }

        /// <summary>
        /// 休憩開始時刻（UTC）のUNIX時間（秒）
        /// </summary>
        public string? BreakInDateUtcUnixTimeSec { get; set; }

        /// <summary>
        /// 休憩終了時刻（UTC）のUNIX時間（秒）
        /// </summary>
        public string? BreakOutDateUtcUnixTimeSec { get; set; }

        /// <summary>
        /// 勤務形態
        /// </summary>
        public int WorkingStyleState { get; set; } = 0;

        /// <summary>
        /// 更新履歴
        /// </summary>
        public List<AttendanceRecordsHistoryResult>? History { get; set; }
    }
}
