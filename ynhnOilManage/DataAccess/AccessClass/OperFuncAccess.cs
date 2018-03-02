
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	OperFuncAccess.cs
* ����:	     ֣��
* ��������:    2007-3-7
* ��������:    ����Ա���ܶ�Ӧ��

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
	/// **�������ƣ�����Ա���ܶ�Ӧ�����ݷ�����

	/// </summary>
	public class OperFuncAccess
	{
		// ����д��Ĵ���
		//��ȡĳ������Ա�Ĺ����б�
		public static DataTable GetOneOperFuncList(SqlConnection conn,string strOperID)
		{
			OperFuncArgs args = new OperFuncArgs();
			args.cnnOperID.Value = strOperID;
			return SingleTableQuery.ExcuteQuery("tbOperFunc",args.cnnOperID,conn);
		}
		//ɾ��ĳ��ĳ������Ա�Ĺ���
		public static int DeleteOperFunc(SqlTransaction trans,OperFunc operFunc)
		{
			return EntityMapping.Delete(operFunc,trans);
		}
		//���ĳ��ĳ������Ա�Ĺ���
		public static int AddOperFunc(SqlTransaction trans,OperFunc operFunc)
		{
			return (int)EntityMapping.Create(operFunc,trans);
		}

		#region ���������ɴ���


		/// <summary>
		/// ȡ��ǰ��ѯ����ʵ��

		/// </summary>
		/// <returns>��ѯ����</returns>
		private static OperFuncArgs GetCurrentArgs()
		{
			return new OperFuncArgs();
		}
		
		#endregion
	}
}

