namespace WebApiService.Logic
{
    /// <summary>
    /// 勤怠履歴データ
    /// </summary>
    public class AttendanceRecordsHistoryResult
    {
        /// <summary>
        /// 履歴時刻（UTC）のUNIX時間（秒）
        /// </summary>
        public string GenerateDateUtcUnixTimeSec { get; set; } = string.Empty;

        /// <summary>
        /// 更新理由
        /// </summary>
        public string Reason { get; set; } = string.Empty;
    }
}
