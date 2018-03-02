
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	OperFuncArgs.cs
* ����:	     ֣��
* ��������:    2008-6-28
* ��������:    ����Ա�����б�

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **�������ƣ�����Ա�����б��ѯ������
	/// </summary>
	public class OperFuncArgs
	{
		/// <summary>
		/// ����
		/// </summary>
		public string TableName = "tbOperFunc";
				
		/// <summary>
		/// ����ԱID
		/// </summary>
		public QueryConditionField cnnOperID = new QueryConditionField("cnnOperID");

		/// <summary>
		/// ��������
		/// </summary>
		public QueryConditionField cnvcFuncName = new QueryConditionField("cnvcFuncName");

		/// <summary>
		/// ���ܵ�ַ
		/// </summary>
		public QueryConditionField cnvcFuncAddress = new QueryConditionField("cnvcFuncAddress");
	}	
}
