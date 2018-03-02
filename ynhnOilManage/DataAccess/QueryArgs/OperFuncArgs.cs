
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	OperFuncArgs.cs
* 作者:	     郑华
* 创建日期:    2008-6-28
* 功能描述:    操作员功能列表

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **功能名称：操作员功能列表查询参数类
	/// </summary>
	public class OperFuncArgs
	{
		/// <summary>
		/// 表名
		/// </summary>
		public string TableName = "tbOperFunc";
				
		/// <summary>
		/// 操作员ID
		/// </summary>
		public QueryConditionField cnnOperID = new QueryConditionField("cnnOperID");

		/// <summary>
		/// 功能名称
		/// </summary>
		public QueryConditionField cnvcFuncName = new QueryConditionField("cnvcFuncName");

		/// <summary>
		/// 功能地址
		/// </summary>
		public QueryConditionField cnvcFuncAddress = new QueryConditionField("cnvcFuncAddress");
	}	
}
