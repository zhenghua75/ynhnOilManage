
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	FuncArgs.cs
* ����:	     ֣��
* ��������:    2008-6-28
* ��������:    �����б�

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **�������ƣ������б��ѯ������
	/// </summary>
	public class FuncArgs
	{
		/// <summary>
		/// ����
		/// </summary>
		public string TableName = "tbFunc";
				
		/// <summary>
		/// ��������
		/// </summary>
		public QueryConditionField cnvcFuncName = new QueryConditionField("cnvcFuncName");

		/// <summary>
		/// ���ܵ�ַ
		/// </summary>
		public QueryConditionField cnvcFuncAddress = new QueryConditionField("cnvcFuncAddress");

		/// <summary>
		/// ��������
		/// </summary>
		public QueryConditionField cnvcFuncType = new QueryConditionField("cnvcFuncType");
	}	
}
