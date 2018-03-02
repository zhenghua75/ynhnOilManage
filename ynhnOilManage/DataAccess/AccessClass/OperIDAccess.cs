
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	OperIDAccess.cs
* ����:	     ֣��
* ��������:    2008-7-12
* ��������:    ����ԱID���ɱ�

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
	/// **�������ƣ�����ԱID���ɱ����ݷ�����
	/// </summary>
	public class OperIDAccess
	{
		// ����д��Ĵ���

		public static int GetOperID(SqlTransaction trans)
		{
			OperID operid = new OperID();
			operid.cnvcFill = "1";
			return Convert.ToInt32(EntityMapping.Create(operid,trans));
		}



		#region ���������ɴ���



		/// <summary>
		/// ȡ��ǰ��ѯ����ʵ��


		/// </summary>
		/// <returns>��ѯ����</returns>
		private static OperIDArgs GetCurrentArgs()
		{
			return new OperIDArgs();
		}
		
		#endregion
	}
}

