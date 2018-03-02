
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	SpecialOilDeptAccess.cs
* ����:	     ֣��
* ��������:    2008-8-27
* ��������:    ר�������õ�λ

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
	/// **�������ƣ�ר�������õ�λ���ݷ�����
	/// </summary>
	public class SpecialOilDeptAccess
	{
		// ����д��Ĵ���

		//���
		public static long AddSpecialOilDept(SqlTransaction trans,SpecialOilDept specialOilDept)
		{
			return EntityMapping.Create(specialOilDept,trans);
		}
		public static int UpdateSpecialOilDept(SqlTransaction trans,string strContractNo,SpecialOilDept specialOilDept)
		{
			return SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbSpecialOilDept set cnvcContractNo='"+specialOilDept.cnvcContractNo+"',cnvcDeliveryCompany='"+specialOilDept.cnvcDeliveryCompany+"' where cnvcContractNo='"+strContractNo+"'");
		}
		public static int DeleteSpecialOilDept(SqlTransaction trans,SpecialOilDept specialOilDept)
		{
			return EntityMapping.Delete(specialOilDept,trans);
		}


		#region ���������ɴ���



		/// <summary>
		/// ȡ��ǰ��ѯ����ʵ��


		/// </summary>
		/// <returns>��ѯ����</returns>
		private static SpecialOilDeptArgs GetCurrentArgs()
		{
			return new SpecialOilDeptArgs();
		}
		
		#endregion
	}
}

