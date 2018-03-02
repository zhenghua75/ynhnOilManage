
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	OperFuncAccess.cs
* 作者:	     郑华
* 创建日期:    2007-3-7
* 功能描述:    操作员功能对应表

*                                                           Copyright(C) 2007 fightop
*************************************************************************************/
#region ImportNameSpace
using System;
using System.Data;
using System.Data.SqlClient;

using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;
using ynhnOilManage.DataAccess.QueryArgs;
using ynhnOilManage.EntityObject.EntityBase;
using ynhnOilManage.EntityObject.EntityClass;

#endregion

namespace ynhnOilManage.DataAccess.AccessClass
{
	/// <summary>
	/// **功能名称：操作员功能对应表数据访问类

	/// </summary>
	public class OperFuncAccess
	{
		// 这里写你的代码
		//获取某个操作员的功能列表
		public static DataTable GetOneOperFuncList(SqlConnection conn,string strOperID)
		{
			OperFuncArgs args = new OperFuncArgs();
			args.cnnOperID.Value = strOperID;
			return SingleTableQuery.ExcuteQuery("tbOperFunc",args.cnnOperID,conn);
		}
		//删除某个某个操作员的功能
		public static int DeleteOperFunc(SqlTransaction trans,OperFunc operFunc)
		{
			return EntityMapping.Delete(operFunc,trans);
		}
		//添加某个某个操作员的功能
		public static int AddOperFunc(SqlTransaction trans,OperFunc operFunc)
		{
			return (int)EntityMapping.Create(operFunc,trans);
		}

		#region 生成器生成代码


		/// <summary>
		/// 取当前查询参数实例

		/// </summary>
		/// <returns>查询参数</returns>
		private static OperFuncArgs GetCurrentArgs()
		{
			return new OperFuncArgs();
		}
		
		#endregion
	}
}

