
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	MebCompanyPrepayAccess.cs
* ����:	     ֣��
* ��������:    2008-7-18
* ��������:    ��λԤ��

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
	/// **�������ƣ���λԤ�����ݷ�����
	/// </summary>
	public class MebCompanyPrepayAccess
	{
		// ����д��Ĵ���


		//��ӵ�λ
		public static void AddCompany(SqlTransaction trans,MebCompanyPrepay company)
		{
			EntityMapping.Create(company,trans);
		}
		public static void UpdateCompany(SqlTransaction trans,MebCompanyPrepay company)
		{
			string strvalidate = company.cnbValidate?"1":"0";
			string strsql = "update tbmebcompanyprepay set cnvcCompanyName='"+company.cnvcCompanyName+"',cnbValidate="+strvalidate+" where cnvcCompanyID='"+company.cnvcCompanyID.ToString()+"'";
			SqlHelper.ExecuteNonQuery(trans,CommandType.Text,strsql);
		}

		#region ���������ɴ���



		/// <summary>
		/// ȡ��ǰ��ѯ����ʵ��


		/// </summary>
		/// <returns>��ѯ����</returns>
		private static MebCompanyPrepayArgs GetCurrentArgs()
		{
			return new MebCompanyPrepayArgs();
		}
		
		#endregion
	}
}

