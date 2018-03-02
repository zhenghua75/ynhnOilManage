
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	DeptArgs.cs
* 作者:	     郑华
* 创建日期:    2008-7-12
* 功能描述:    部门表

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **功能名称：部门表查询参数类
	/// </summary>
	public class DeptArgs
	{
		/// <summary>
		/// 表名
		/// </summary>
		public string TableName = "tbDept";
				
		/// <summary>
		/// 部门ID
		/// </summary>
		public QueryConditionField cnvcDeptID = new QueryConditionField("cnvcDeptID");

		/// <summary>
		/// 部门名称
		/// </summary>
		public QueryConditionField cnvcDeptName = new QueryConditionField("cnvcDeptName");

		/// <summary>
		/// 上级部门ID
		/// </summary>
		public QueryConditionField cnvcParentDeptID = new QueryConditionField("cnvcParentDeptID");
	}	
}
