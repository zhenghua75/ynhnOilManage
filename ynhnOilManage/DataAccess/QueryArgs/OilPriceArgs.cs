
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	OilPriceArgs.cs
* 作者:	     郑华
* 创建日期:    2008-7-13
* 功能描述:    油价表

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/

using System;
using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;

namespace ynhnOilManage.DataAccess.QueryArgs
{
	/// <summary>
	/// **功能名称：油价表查询参数类
	/// </summary>
	public class OilPriceArgs
	{
		/// <summary>
		/// 表名
		/// </summary>
		public string TableName = "tbOilPrice";
				
		/// <summary>
		/// 流水号
		/// </summary>
		public QueryConditionField cnnSerialNo = new QueryConditionField("cnnSerialNo");

		/// <summary>
		/// 时间
		/// </summary>
		public QueryConditionField cndPriceDate = new QueryConditionField("cndPriceDate");

		/// <summary>
		/// 商品名称
		/// </summary>
		public QueryConditionField cnvcGoodsName = new QueryConditionField("cnvcGoodsName");

		/// <summary>
		/// 商品型号
		/// </summary>
		public QueryConditionField cnvcGoodsType = new QueryConditionField("cnvcGoodsType");

		/// <summary>
		/// 单位
		/// </summary>
		public QueryConditionField cnvcUnit = new QueryConditionField("cnvcUnit");

		/// <summary>
		/// 油价
		/// </summary>
		public QueryConditionField cnnOilPrice = new QueryConditionField("cnnOilPrice");

		/// <summary>
		/// 部门
		/// </summary>
		public QueryConditionField cnvcDeptName = new QueryConditionField("cnvcDeptName");

		/// <summary>
		/// 部门ID
		/// </summary>
		public QueryConditionField cnvcDeptID = new QueryConditionField("cnvcDeptID");
	}	
}
