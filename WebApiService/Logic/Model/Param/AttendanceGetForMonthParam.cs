using System.ComponentModel.DataAnnotations;

namespace WebApiService.Logic.Model
{
    /// <summary>
    /// 月間勤怠取得パラメータモデル
    /// </summary>
    public class AttendanceGetForMonthParam
    {
        /// <summary>
        /// 対象月（UTC）のUNIX時間（秒）
        /// </summary>
        [Required]
        [DataType(DataType.Text)]
        public string TargetDateUtcUnixTimeSec { get; set; } = string.Empty;
    }
}
