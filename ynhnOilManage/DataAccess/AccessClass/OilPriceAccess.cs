
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	OilPriceAccess.cs
* ����:	     ֣��
* ��������:    2008-6-30
* ��������:    �ͼ۱�

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
	/// **�������ƣ��ͼ۱����ݷ�����
	/// </summary>
	public class OilPriceAccess
	{
		// ����д��Ĵ���

		public static long AddOilPrice(SqlTransaction trans,OilPrice price)
		{
			return EntityMapping.Create(price,trans);
		}


		#region ���������ɴ���



		/// <summary>
		/// ȡ��ǰ��ѯ����ʵ��


		/// </summary>
		/// <returns>��ѯ����</returns>
		private static OilPriceArgs GetCurrentArgs()
		{
			return new OilPriceArgs();
		}
		
		#endregion
	}
}

