
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	BusiSerialNoArgs.cs
* 作者:	     郑华
* 创建日期:    2008-7-13
* 功能描述:    操作流水生成表

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **功能名称：操作流水生成表查询参数类
	/// </summary>
	public class BusiSerialNoArgs
	{
		/// <summary>
		/// 表名
		/// </summary>
		public string TableName = "tbBusiSerialNo";
				
		/// <summary>
		/// 流水号
		/// </summary>
		public QueryConditionField cnnSerialNo = new QueryConditionField("cnnSerialNo");

		/// <summary>
		/// 填充值
		/// </summary>
		public QueryConditionField cnvcFill = new QueryConditionField("cnvcFill");
	}	
}
