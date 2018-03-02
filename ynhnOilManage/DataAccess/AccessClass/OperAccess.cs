
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	OperAccess.cs
* 作者:	     郑华
* 创建日期:    2007-3-6
* 功能描述:    操作员表

*                                                           Copyright(C) 2007 fightop
*************************************************************************************/
#region ImportNameSpace
using System;
using System.Data;
using System.Data.SqlClient;

using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;
using ynhnOilManage.EntityObject.EntityBase;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.DataAccess.QueryArgs;
using ynhnOilManage.EntityObject;
#endregion

namespace ynhnOilManage.DataAccess.AccessClass
{
	/// <summary>
	/// **功能名称：操作员表数据访问类

	/// </summary>
	public class OperAccess
	{
		// 这里写你的代码

		public static DataTable GetAllOperNoAdmin(SqlConnection conn)
		{
			return SqlHelper.ExecuteDataTable(conn,CommandType.Text,"select * from tbOper where cnvcOperName <> 'admin'");
		}
		public static DataTable GetAllOper(SqlConnection conn)
		{
			return SingleTableQuery.ExcuteQuery("tbOper",conn);
		}

		public static DataTable GetOperByName(SqlConnection conn,string strOperName)
		{
			OperArgs args = GetCurrentArgs();
			args.cnvcOperName.Value = strOperName;
			return SingleTableQuery.ExcuteQuery("tbOper",args.cnvcOperName,conn);
		}

		//更新用户密码
		public static int UpdatePwd(SqlTransaction trans,Oper oper)
		{
			return EntityMapping.Update(oper,trans);
		}
		//添加用户
		public static void AddOper(SqlTransaction trans,Oper oper)
		{
			EntityMapping.Create(oper,trans);
		}
		public static Oper GetOper(SqlConnection conn,Oper oper)
		{
			return EntityMapping.Get(oper,conn) as Oper;
		}
		public static int DeleteOper(SqlConnection conn,Oper oper)
		{
			return EntityMapping.Delete(oper,conn);
		}

		#region 生成器生成代码


		/// <summary>
		/// 取当前查询参数实例

		/// </summary>
		/// <returns>查询参数</returns>
		private static OperArgs GetCurrentArgs()
		{
			return new OperArgs();
		}
		
		#endregion
	}
}

