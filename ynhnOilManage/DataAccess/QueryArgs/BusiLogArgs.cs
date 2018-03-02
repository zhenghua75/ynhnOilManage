
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	BusiLogArgs.cs
* 作者:	     郑华
* 创建日期:    2008-7-13
* 功能描述:    营业日志

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **功能名称：营业日志查询参数类
	/// </summary>
	public class BusiLogArgs
	{
		/// <summary>
		/// 表名
		/// </summary>
		public string TableName = "tbBusiLog";
				
		/// <summary>
		/// 流水号
		/// </summary>
		public QueryConditionField cnnSerial = new QueryConditionField("cnnSerial");

		/// <summary>
		/// 操作类型
		/// </summary>
		public QueryConditionField cnvcOperType = new QueryConditionField("cnvcOperType");

		/// <summary>
		/// 操作员
		/// </summary>
		public QueryConditionField cnvcOperName = new QueryConditionField("cnvcOperName");

		/// <summary>
		/// 操作日期
		/// </summary>
		public QueryConditionField cndOperDate = new QueryConditionField("cndOperDate");

		/// <summary>
		/// 备注
		/// </summary>
		public QueryConditionField cnvcComments = new QueryConditionField("cnvcComments");

		/// <summary>
		/// 部门名称
		/// </summary>
		public QueryConditionField cnvcDeptName = new QueryConditionField("cnvcDeptName");

		/// <summary>
		/// 部门
		/// </summary>
		public QueryConditionField cnvcDeptID = new QueryConditionField("cnvcDeptID");

		/// <summary>
		/// 来源
		/// </summary>
		public QueryConditionField cnvcSource = new QueryConditionField("cnvcSource");
	}	
}
