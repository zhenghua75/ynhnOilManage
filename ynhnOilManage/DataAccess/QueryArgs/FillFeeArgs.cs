
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	FillFeeArgs.cs
* 作者:	     郑华
* 创建日期:    2008-7-18
* 功能描述:    充值表

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **功能名称：充值表查询参数类
	/// </summary>
	public class FillFeeArgs
	{
		/// <summary>
		/// 表名
		/// </summary>
		public string TableName = "tbFillFee";
				
		/// <summary>
		/// 流水号
		/// </summary>
		public QueryConditionField cnnSerial = new QueryConditionField("cnnSerial");

		/// <summary>
		/// 单位ID
		/// </summary>
		public QueryConditionField cnvcCompanyID = new QueryConditionField("cnvcCompanyID");

		/// <summary>
		/// 单位名称
		/// </summary>
		public QueryConditionField cnvcCompanyName = new QueryConditionField("cnvcCompanyName");

		/// <summary>
		/// 帐号
		/// </summary>
		public QueryConditionField cnvcAcctID = new QueryConditionField("cnvcAcctID");

		/// <summary>
		/// 充值金额
		/// </summary>
		public QueryConditionField cnnFillFee = new QueryConditionField("cnnFillFee");

		/// <summary>
		/// 操作员
		/// </summary>
		public QueryConditionField cnvcOperName = new QueryConditionField("cnvcOperName");

		/// <summary>
		/// 操作时间
		/// </summary>
		public QueryConditionField cndOperDate = new QueryConditionField("cndOperDate");

		/// <summary>
		/// 部门ID
		/// </summary>
		public QueryConditionField cnvcDeptID = new QueryConditionField("cnvcDeptID");

		/// <summary>
		/// 部门名称
		/// </summary>
		public QueryConditionField cnvcDeptName = new QueryConditionField("cnvcDeptName");
	}	
}
