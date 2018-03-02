
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	OperArgs.cs
* ����:	     ֣��
* ��������:    2008-7-12
* ��������:    ����Ա��

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **�������ƣ�����Ա���ѯ������
	/// </summary>
	public class OperArgs
	{
		/// <summary>
		/// ����
		/// </summary>
		public string TableName = "tbOper";
				
		/// <summary>
		/// ����ԱID
		/// </summary>
		public QueryConditionField cnnOperID = new QueryConditionField("cnnOperID");

		/// <summary>
		/// ����Ա����
		/// </summary>
		public QueryConditionField cnvcOperName = new QueryConditionField("cnvcOperName");

		/// <summary>
		/// ����
		/// </summary>
		public QueryConditionField cnvcPwd = new QueryConditionField("cnvcPwd");

		/// <summary>
		/// ����
		/// </summary>
		public QueryConditionField cnvcDeptID = new QueryConditionField("cnvcDeptID");
	}	
}
