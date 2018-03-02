using System;
using System.Data;
using System.Data.SqlClient;
using ynhnOilManage.DataAccess.Common;
using ynhnOilManage.DataAccess.AccessClass;
using ynhnOilManage.DataAccess.QueryArgs;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.EntityObject.EntityBase;
using ynhnOilManage.Common;

namespace ynhnOilManage.BusinessRules.Report
{
	/// <summary>
	/// ReportQuery 的摘要说明。
	/// </summary>
	public class ReportQuery
	{
		public ReportQuery()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public DataTable CommonQuery(string strSql)
		{
			SqlConnection conn = ConnectionPool.BorrowConnection();
			DataTable dtRet = null;
			try
			{
				dtRet = SqlHelper.ExecuteDataTable(conn,CommandType.Text,strSql);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
			return dtRet;
		}
		public EntityObjectBase CommonQuery(EntityObjectBase eob)
		{
			SqlConnection conn = ConnectionPool.BorrowConnection();
			try
			{
				return EntityMapping.Get(eob,conn);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
			return null;
		}
	}
}
