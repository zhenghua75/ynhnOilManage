
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	FillFeeAccess.cs
* ����:	     ֣��
* ��������:    2008-7-18
* ��������:    ��ֵ��

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
	/// **�������ƣ���ֵ�����ݷ�����
	/// </summary>
	public class FillFeeAccess
	{
		// ����д��Ĵ���


		//��ֵ
		public static void AddFee(SqlTransaction trans,FillFee fee)
		{
			EntityMapping.Create(fee,trans);
		}


		#region ���������ɴ���



		/// <summary>
		/// ȡ��ǰ��ѯ����ʵ��


		/// </summary>
		/// <returns>��ѯ����</returns>
		private static FillFeeArgs GetCurrentArgs()
		{
			return new FillFeeArgs();
		}
		
		#endregion
	}
}

