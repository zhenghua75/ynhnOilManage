
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	MebCompanyPrepayArgs.cs
* 作者:	     郑华
* 创建日期:    2008-7-18
* 功能描述:    单位预存

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **功能名称：单位预存查询参数类
	/// </summary>
	public class MebCompanyPrepayArgs
	{
		/// <summary>
		/// 表名
		/// </summary>
		public string TableName = "tbMebCompanyPrepay";
				
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
		/// 单位余额
		/// </summary>
		public QueryConditionField cnnPrepayFee = new QueryConditionField("cnnPrepayFee");

		/// <summary>
		/// 指定加油站
		/// </summary>
		public QueryConditionField cnvcDeptName = new QueryConditionField("cnvcDeptName");

		/// <summary>
		/// 部门ID
		/// </summary>
		public QueryConditionField cnvcDeptID = new QueryConditionField("cnvcDeptID");
	}	
}
