
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	BusiLogArgs.cs
* ����:	     ֣��
* ��������:    2008-7-13
* ��������:    Ӫҵ��־

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **�������ƣ�Ӫҵ��־��ѯ������
	/// </summary>
	public class BusiLogArgs
	{
		/// <summary>
		/// ����
		/// </summary>
		public string TableName = "tbBusiLog";
				
		/// <summary>
		/// ��ˮ��
		/// </summary>
		public QueryConditionField cnnSerial = new QueryConditionField("cnnSerial");

		/// <summary>
		/// ��������
		/// </summary>
		public QueryConditionField cnvcOperType = new QueryConditionField("cnvcOperType");

		/// <summary>
		/// ����Ա
		/// </summary>
		public QueryConditionField cnvcOperName = new QueryConditionField("cnvcOperName");

		/// <summary>
		/// ��������
		/// </summary>
		public QueryConditionField cndOperDate = new QueryConditionField("cndOperDate");

		/// <summary>
		/// ��ע
		/// </summary>
		public QueryConditionField cnvcComments = new QueryConditionField("cnvcComments");

		/// <summary>
		/// ��������
		/// </summary>
		public QueryConditionField cnvcDeptName = new QueryConditionField("cnvcDeptName");

		/// <summary>
		/// ����
		/// </summary>
		public QueryConditionField cnvcDeptID = new QueryConditionField("cnvcDeptID");

		/// <summary>
		/// ��Դ
		/// </summary>
		public QueryConditionField cnvcSource = new QueryConditionField("cnvcSource");
	}	
}
