
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	BusiLogAccess.cs
* ����:	     ֣��
* ��������:    2008-7-13
* ��������:    ������־��

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
	/// **�������ƣ�������־�����ݷ�����
	/// </summary>
	public class BusiLogAccess
	{
		// ����д��Ĵ���

		public static void AddBusiLog(SqlTransaction trans,BusiLog busiLog)
		{
			EntityMapping.Create(busiLog,trans);
		}

		#region ���������ɴ���



		/// <summary>
		/// ȡ��ǰ��ѯ����ʵ��


		/// </summary>
		/// <returns>��ѯ����</returns>
		private static BusiLogArgs GetCurrentArgs()
		{
			return new BusiLogArgs();
		}
		
		#endregion
	}
}

