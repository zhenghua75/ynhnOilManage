
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	FillFeeArgs.cs
* ����:	     ֣��
* ��������:    2008-7-18
* ��������:    ��ֵ��

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **�������ƣ���ֵ���ѯ������
	/// </summary>
	public class FillFeeArgs
	{
		/// <summary>
		/// ����
		/// </summary>
		public string TableName = "tbFillFee";
				
		/// <summary>
		/// ��ˮ��
		/// </summary>
		public QueryConditionField cnnSerial = new QueryConditionField("cnnSerial");

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
		/// ��ֵ���
		/// </summary>
		public QueryConditionField cnnFillFee = new QueryConditionField("cnnFillFee");

		/// <summary>
		/// ����Ա
		/// </summary>
		public QueryConditionField cnvcOperName = new QueryConditionField("cnvcOperName");

		/// <summary>
		/// ����ʱ��
		/// </summary>
		public QueryConditionField cndOperDate = new QueryConditionField("cndOperDate");

		/// <summary>
		/// ����ID
		/// </summary>
		public QueryConditionField cnvcDeptID = new QueryConditionField("cnvcDeptID");

		/// <summary>
		/// ��������
		/// </summary>
		public QueryConditionField cnvcDeptName = new QueryConditionField("cnvcDeptName");
	}	
}
