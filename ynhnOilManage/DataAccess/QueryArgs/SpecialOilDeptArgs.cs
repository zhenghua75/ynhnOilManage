
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	SpecialOilDeptArgs.cs
* ����:	     ֣��
* ��������:    2008-8-27
* ��������:    ר�������õ�λ

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **�������ƣ�ר�������õ�λ��ѯ������
	/// </summary>
	public class SpecialOilDeptArgs
	{
		/// <summary>
		/// ����
		/// </summary>
		public string TableName = "tbSpecialOilDept";
				
		/// <summary>
		/// ��ͬ���
		/// </summary>
		public QueryConditionField cnvcContractNo = new QueryConditionField("cnvcContractNo");

		/// <summary>
		/// ���õ�λ����
		/// </summary>
		public QueryConditionField cnvcDeliveryCompany = new QueryConditionField("cnvcDeliveryCompany");
	}	
}
