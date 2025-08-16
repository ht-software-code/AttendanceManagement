using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiService.Common.Const;
using WebApiService.Logic.Logic;
using WebApiService.Logic.Model;

namespace AttendanceManagement.Server.Controllers
{
    /// <summary>
    /// メニューコントローラー（分割クラス）
    /// URL:https://localhost:XXXXX/mainmenu/【Route name】
    /// </summary>
    public partial class MainMenuController : ApiControllerBase
    {
        #region API Attendance

        /// <summary>
        /// 出勤登録状況を取得します。
        /// URL:https://localhost:XXXXX/mainmenu/attendanceclockinstate
        /// </summary>
        /// <returns>応答データ</returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(MainMenuControllerActionsRoutes.AttendanceClockInState)]
        public async Task<IActionResult> AttendanceClockInState()
        {
            return await this.ExecuteLogicWithStatus((userCode) =>
            {
                return AttendanceLogic.GetClockInState(userCode);
            });
        }

        /// <summary>
        /// 出勤データを登録します。
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <returns>応答データ</returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(MainMenuControllerActionsRoutes.AttendanceClockIn)]
        public async Task<IActionResult> AttendanceClockIn([FromBody] AttendanceClockInOutParam param)
        {
            return await this.ExecuteLogicWithStatus((userCode) =>
            {
                return AttendanceLogic.RegisterClockIn(userCode, param);
            });
        }

        /// <summary>
        /// 退勤データを登録します。
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <returns>応答データ</returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(MainMenuControllerActionsRoutes.AttendanceClockOut)]
        public async Task<IActionResult> AttendanceClockOut([FromBody] AttendanceClockInOutParam param)
        {
            return await this.ExecuteLogicWithStatus((userCode) =>
            {
                return AttendanceLogic.RegisterClockOut(userCode, param);
            });
        }

        /// <summary>
        /// 勤怠ID指定の勤怠を取得します。
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <returns>応答データ</returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(MainMenuControllerActionsRoutes.AttendanceGet)]
        public async Task<IActionResult> AttendanceGet([FromBody] AttendanceGetParam param)
        {
            return await this.ExecuteLogicWithStatus((userCode) =>
            {
                return AttendanceLogic.GetAttendance(userCode, param);
            });
        }

        /// <summary>
        /// 指定月の勤怠を取得します。
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <returns>応答データ</returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(MainMenuControllerActionsRoutes.AttendanceGetForMonth)]
        public async Task<IActionResult> AttendanceGetForMonth([FromBody] AttendanceGetForMonthParam param)
        {
            return await this.ExecuteLogicWithStatus((userCode) =>
            {
                return AttendanceLogic.GetMonthlyAttendances(userCode, param);
            });
        }

        /// <summary>
        /// 勤怠を更新します。
        /// </summary>
        /// <param name="attendance">勤怠</param>
        /// <returns>応答データ</returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(MainMenuControllerActionsRoutes.AttendanceUpdate)]
        public async Task<IActionResult> AttendanceUpdate([FromBody] AttendanceUpdateParam attendance)
        {
            return await this.ExecuteLogicWithStatus((userCode) =>
            {
                return AttendanceLogic.UpdateAttendance(userCode, attendance);
            });
        }

        /// <summary>
        /// 勤怠を削除します。
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <returns>応答データ</returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(MainMenuControllerActionsRoutes.AttendanceDelete)]
        public async Task<IActionResult> AttendanceDelete([FromBody] AttendanceDeleteParam param)
        {
            return await this.ExecuteLogicWithStatus((userCode) =>
            {
                return AttendanceLogic.DeleteAttendance(userCode, param);
            });
        }

        #endregion
    }
}
