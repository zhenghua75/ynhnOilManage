
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	SpecialOilDeptArgs.cs
* 作者:	     郑华
* 创建日期:    2008-8-27
* 功能描述:    专供油领用单位

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **功能名称：专供油领用单位查询参数类
	/// </summary>
	public class SpecialOilDeptArgs
	{
		/// <summary>
		/// 表名
		/// </summary>
		public string TableName = "tbSpecialOilDept";
				
		/// <summary>
		/// 合同编号
		/// </summary>
		public QueryConditionField cnvcContractNo = new QueryConditionField("cnvcContractNo");

		/// <summary>
		/// 领用单位名称
		/// </summary>
		public QueryConditionField cnvcDeliveryCompany = new QueryConditionField("cnvcDeliveryCompany");
	}	
}
