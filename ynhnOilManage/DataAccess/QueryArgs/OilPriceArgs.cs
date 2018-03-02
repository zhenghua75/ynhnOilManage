
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	OilPriceArgs.cs
* ����:	     ֣��
* ��������:    2008-7-13
* ��������:    �ͼ۱�

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **�������ƣ��ͼ۱��ѯ������
	/// </summary>
	public class OilPriceArgs
	{
		/// <summary>
		/// ����
		/// </summary>
		public string TableName = "tbOilPrice";
				
		/// <summary>
		/// ��ˮ��
		/// </summary>
		public QueryConditionField cnnSerialNo = new QueryConditionField("cnnSerialNo");

		/// <summary>
		/// ʱ��
		/// </summary>
		public QueryConditionField cndPriceDate = new QueryConditionField("cndPriceDate");

		/// <summary>
		/// ��Ʒ����
		/// </summary>
		public QueryConditionField cnvcGoodsName = new QueryConditionField("cnvcGoodsName");

		/// <summary>
		/// ��Ʒ�ͺ�
		/// </summary>
		public QueryConditionField cnvcGoodsType = new QueryConditionField("cnvcGoodsType");

		/// <summary>
		/// ��λ
		/// </summary>
		public QueryConditionField cnvcUnit = new QueryConditionField("cnvcUnit");

		/// <summary>
		/// �ͼ�
		/// </summary>
		public QueryConditionField cnnOilPrice = new QueryConditionField("cnnOilPrice");

		/// <summary>
		/// ����
		/// </summary>
		public QueryConditionField cnvcDeptName = new QueryConditionField("cnvcDeptName");

		/// <summary>
		/// ����ID
		/// </summary>
		public QueryConditionField cnvcDeptID = new QueryConditionField("cnvcDeptID");
	}	
}
