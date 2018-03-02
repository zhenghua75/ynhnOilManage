
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	OilPriceAccess.cs
* 作者:	     郑华
* 创建日期:    2008-6-30
* 功能描述:    油价表

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/
#region ImportNameSpace
using System;
using System.Data;
using System.Data.SqlClient;

using ynhnOilManage.Common;
using ynhnOilManage.EntityObject.EntityBase;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.DataAccess.QueryArgs;
using ynhnOilManage.DataAccess.Common;
#endregion

namespace ynhnOilManage.DataAccess.AccessClass
{
	/// <summary>
	/// **功能名称：油价表数据访问类
	/// </summary>
	public class OilPriceAccess
	{
		// 这里写你的代码

		public static long AddOilPrice(SqlTransaction trans,OilPrice price)
		{
			return EntityMapping.Create(price,trans);
		}


		#region 生成器生成代码



		/// <summary>
		/// 取当前查询参数实例


		/// </summary>
		/// <returns>查询参数</returns>
		private static OilPriceArgs GetCurrentArgs()
		{
			return new OilPriceArgs();
		}
		
		#endregion
	}
}

