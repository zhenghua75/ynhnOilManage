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
	/// MemberAccess ��ժҪ˵����
	/// </summary>
	public class MemberAccess
	{
		public MemberAccess()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public static void UpdateMemberCompany(SqlTransaction trans,MebCompanyPrepay company)
		{
			string strsql = "update tbMember set cnvcCompanyName='"+company.cnvcCompanyName+"' where cnvcCompanyID='"+company.cnvcCompanyID+"'";
			SqlHelper.ExecuteNonQuery(trans,CommandType.Text,strsql);
		}
	}
}
