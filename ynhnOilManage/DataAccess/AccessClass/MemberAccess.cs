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
	/// MemberAccess 的摘要说明。
	/// </summary>
	public class MemberAccess
	{
		public MemberAccess()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static void UpdateMemberCompany(SqlTransaction trans,MebCompanyPrepay company)
		{
			string strsql = "update tbMember set cnvcCompanyName='"+company.cnvcCompanyName+"' where cnvcCompanyID='"+company.cnvcCompanyID+"'";
			SqlHelper.ExecuteNonQuery(trans,CommandType.Text,strsql);
		}
	}
}
