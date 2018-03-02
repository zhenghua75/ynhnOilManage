
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	DeptArgs.cs
* ����:	     ֣��
* ��������:    2008-7-12
* ��������:    ���ű�

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **�������ƣ����ű��ѯ������
	/// </summary>
	public class DeptArgs
	{
		/// <summary>
		/// ����
		/// </summary>
		public string TableName = "tbDept";
				
		/// <summary>
		/// ����ID
		/// </summary>
		public QueryConditionField cnvcDeptID = new QueryConditionField("cnvcDeptID");

		/// <summary>
		/// ��������
		/// </summary>
		public QueryConditionField cnvcDeptName = new QueryConditionField("cnvcDeptName");

		/// <summary>
		/// �ϼ�����ID
		/// </summary>
		public QueryConditionField cnvcParentDeptID = new QueryConditionField("cnvcParentDeptID");
	}	
}
