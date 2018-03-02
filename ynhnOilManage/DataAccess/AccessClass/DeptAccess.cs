
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	DeptAccess.cs
* ����:	     ֣��
* ��������:    2008-6-28
* ��������:    ���ű�

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
	/// **�������ƣ����ű����ݷ�����
	/// </summary>
	public class DeptAccess
	{
		// ����д��Ĵ���

		/// <summary>
		/// ��ѯ���в�����Ϣ
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

		#region ���������ɴ���



		/// <summary>
		/// ȡ��ǰ��ѯ����ʵ��


		/// </summary>
		/// <returns>��ѯ����</returns>
		private static DeptArgs GetCurrentArgs()
		{
			return new DeptArgs();
		}
		
		#endregion
	}
}

