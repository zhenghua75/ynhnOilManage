
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	FuncArgs.cs
* 作者:	     郑华
* 创建日期:    2008-6-28
* 功能描述:    功能列表

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **功能名称：功能列表查询参数类
	/// </summary>
	public class FuncArgs
	{
		/// <summary>
		/// 表名
		/// </summary>
		public string TableName = "tbFunc";
				
		/// <summary>
		/// 功能名称
		/// </summary>
		public QueryConditionField cnvcFuncName = new QueryConditionField("cnvcFuncName");

		/// <summary>
		/// 功能地址
		/// </summary>
		public QueryConditionField cnvcFuncAddress = new QueryConditionField("cnvcFuncAddress");

		/// <summary>
		/// 功能类型
		/// </summary>
		public QueryConditionField cnvcFuncType = new QueryConditionField("cnvcFuncType");
	}	
}
