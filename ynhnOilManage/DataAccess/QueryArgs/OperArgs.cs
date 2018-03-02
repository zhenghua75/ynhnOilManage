
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	OperArgs.cs
* 作者:	     郑华
* 创建日期:    2008-7-12
* 功能描述:    操作员表

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **功能名称：操作员表查询参数类
	/// </summary>
	public class OperArgs
	{
		/// <summary>
		/// 表名
		/// </summary>
		public string TableName = "tbOper";
				
		/// <summary>
		/// 操作员ID
		/// </summary>
		public QueryConditionField cnnOperID = new QueryConditionField("cnnOperID");

		/// <summary>
		/// 操作员名称
		/// </summary>
		public QueryConditionField cnvcOperName = new QueryConditionField("cnvcOperName");

		/// <summary>
		/// 密码
		/// </summary>
		public QueryConditionField cnvcPwd = new QueryConditionField("cnvcPwd");

		/// <summary>
		/// 部门
		/// </summary>
		public QueryConditionField cnvcDeptID = new QueryConditionField("cnvcDeptID");
	}	
}
