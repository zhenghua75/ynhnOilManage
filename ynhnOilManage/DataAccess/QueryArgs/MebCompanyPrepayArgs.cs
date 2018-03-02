
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	MebCompanyPrepayArgs.cs
* ����:	     ֣��
* ��������:    2008-7-18
* ��������:    ��λԤ��

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **�������ƣ���λԤ���ѯ������
	/// </summary>
	public class MebCompanyPrepayArgs
	{
		/// <summary>
		/// ����
		/// </summary>
		public string TableName = "tbMebCompanyPrepay";
				
		/// <summary>
		/// ��λID
		/// </summary>
		public QueryConditionField cnvcCompanyID = new QueryConditionField("cnvcCompanyID");

		/// <summary>
		/// ��λ����
		/// </summary>
		public QueryConditionField cnvcCompanyName = new QueryConditionField("cnvcCompanyName");

		/// <summary>
		/// �ʺ�
		/// </summary>
		public QueryConditionField cnvcAcctID = new QueryConditionField("cnvcAcctID");

		/// <summary>
		/// ��λ���
		/// </summary>
		public QueryConditionField cnnPrepayFee = new QueryConditionField("cnnPrepayFee");

		/// <summary>
		/// ָ������վ
		/// </summary>
		public QueryConditionField cnvcDeptName = new QueryConditionField("cnvcDeptName");

		/// <summary>
		/// ����ID
		/// </summary>
		public QueryConditionField cnvcDeptID = new QueryConditionField("cnvcDeptID");
	}	
}
