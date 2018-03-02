
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	OperIDArgs.cs
* ����:	     ֣��
* ��������:    2008-7-12
* ��������:    ����ԱID���ɱ�

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **�������ƣ�����ԱID���ɱ��ѯ������
	/// </summary>
	public class OperIDArgs
	{
		/// <summary>
		/// ����
		/// </summary>
		public string TableName = "tbOperID";
				
		/// <summary>
		/// ����ԱID
		/// </summary>
		public QueryConditionField cnnID = new QueryConditionField("cnnID");

		/// <summary>
		/// ���ֵ
		/// </summary>
		public QueryConditionField cnvcFill = new QueryConditionField("cnvcFill");
	}	
}
