
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	FunctionListAccess.cs
* 作者:	     郑华
* 创建日期:    2007-3-7
* 功能描述:    功能列表

*                                                           Copyright(C) 2007 fightop
*************************************************************************************/
#region ImportNameSpace
using System;
using System.Data;
using System.Data.SqlClient;

using ynhnOilManage.Common;
using ynhnOilManage.EntityObject.EntityBase;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.DataAccess.QueryArgs;
using ynhnOilManage.DataAccess.Common;
#endregion

namespace ynhnOilManage.DataAccess.AccessClass
{
	/// <summary>
	/// **功能名称：功能列表数据访问类

	/// </summary>
	public class FuncAccess
	{
		// 这里写你的代码
		public static DataTable GetAllFunction(SqlConnection conn)
		{
			FuncArgs args = GetCurrentArgs();
			QueryOrderCollection order = new QueryOrderCollection();
			order.Add(args.cnvcFuncName.FieldName,QueryOperationSign.OrderOperation.ASC);
			return SingleTableQuery.ExcuteQuery("tbFunc",order,conn);
		}
		
		#region 生成器生成代码


		/// <summary>
		/// 取当前查询参数实例

		/// </summary>
		/// <returns>查询参数</returns>
		private static FuncArgs GetCurrentArgs()
		{
			return new FuncArgs();
		}
		
		#endregion
	}
}

