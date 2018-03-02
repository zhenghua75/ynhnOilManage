
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	BusiSerialNoArgs.cs
* ����:	     ֣��
* ��������:    2008-7-13
* ��������:    ������ˮ���ɱ�

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **�������ƣ�������ˮ���ɱ��ѯ������
	/// </summary>
	public class BusiSerialNoArgs
	{
		/// <summary>
		/// ����
		/// </summary>
		public string TableName = "tbBusiSerialNo";
				
		/// <summary>
		/// ��ˮ��
		/// </summary>
		public QueryConditionField cnnSerialNo = new QueryConditionField("cnnSerialNo");

		/// <summary>
		/// ���ֵ
		/// </summary>
		public QueryConditionField cnvcFill = new QueryConditionField("cnvcFill");
	}	
}
