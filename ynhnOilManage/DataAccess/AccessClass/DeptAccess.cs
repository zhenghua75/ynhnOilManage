
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	DeptAccess.cs
* 作者:	     郑华
* 创建日期:    2008-6-28
* 功能描述:    部门表

*                                                           Copyright(C) 2008 fightop
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
	/// **功能名称：部门表数据访问类
	/// </summary>
	public class DeptAccess
	{
		// 这里写你的代码

		/// <summary>
		/// 查询所有部门信息
		/// </summary>
		/// <param name="conn"></param>
		/// <returns></returns>
		public static DataTable GetAllDept(SqlConnection conn)
		{
			//return SingleTableQuery.ExcuteQuery("tbDept",conn);
			string strsql = "select * from tbdept where cnbvalidate=1";
			return SqlHelper.ExecuteDataTable(conn,CommandType.Text,strsql);
		}

		public static Dept GetDept(SqlConnection conn,Dept dept)
		{
			return EntityMapping.Get(dept,conn) as Dept;
		}
		public static void AddDept(SqlTransaction trans,Dept dept)
		{
			EntityMapping.Create(dept,trans);
		}

		public static int UpdateDept(SqlTransaction trans,Dept dept)
		{
			return EntityMapping.Update(dept,trans);
		}

		#region 生成器生成代码



		/// <summary>
		/// 取当前查询参数实例


		/// </summary>
		/// <returns>查询参数</returns>
		private static DeptArgs GetCurrentArgs()
		{
			return new DeptArgs();
		}
		
		#endregion
	}
}

