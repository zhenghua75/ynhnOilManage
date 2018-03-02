
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	OperAccess.cs
* ����:	     ֣��
* ��������:    2007-3-6
* ��������:    ����Ա��

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
	/// **�������ƣ�����Ա�����ݷ�����

	/// </summary>
	public class OperAccess
	{
		// ����д��Ĵ���

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

		//�����û�����
		public static int UpdatePwd(SqlTransaction trans,Oper oper)
		{
			return EntityMapping.Update(oper,trans);
		}
		//����û�
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

		#region ���������ɴ���


		/// <summary>
		/// ȡ��ǰ��ѯ����ʵ��

		/// </summary>
		/// <returns>��ѯ����</returns>
		private static OperArgs GetCurrentArgs()
		{
			return new OperArgs();
		}
		
		#endregion
	}
}

