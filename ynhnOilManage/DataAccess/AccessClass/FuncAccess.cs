
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	FunctionListAccess.cs
* ����:	     ֣��
* ��������:    2007-3-7
* ��������:    �����б�

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
	/// **�������ƣ������б����ݷ�����

	/// </summary>
	public class FuncAccess
	{
		// ����д��Ĵ���
		public static DataTable GetAllFunction(SqlConnection conn)
		{
			FuncArgs args = GetCurrentArgs();
			QueryOrderCollection order = new QueryOrderCollection();
			order.Add(args.cnvcFuncName.FieldName,QueryOperationSign.OrderOperation.ASC);
			return SingleTableQuery.ExcuteQuery("tbFunc",order,conn);
		}
		
		#region ���������ɴ���


		/// <summary>
		/// ȡ��ǰ��ѯ����ʵ��

		/// </summary>
		/// <returns>��ѯ����</returns>
		private static FuncArgs GetCurrentArgs()
		{
			return new FuncArgs();
		}
		
		#endregion
	}
}

