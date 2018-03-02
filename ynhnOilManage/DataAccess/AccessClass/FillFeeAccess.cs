
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	FillFeeAccess.cs
* 作者:	     郑华
* 创建日期:    2008-7-18
* 功能描述:    充值表

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
	/// **功能名称：充值表数据访问类
	/// </summary>
	public class FillFeeAccess
	{
		// 这里写你的代码


		//充值
		public static void AddFee(SqlTransaction trans,FillFee fee)
		{
			EntityMapping.Create(fee,trans);
		}


		#region 生成器生成代码



		/// <summary>
		/// 取当前查询参数实例


		/// </summary>
		/// <returns>查询参数</returns>
		private static FillFeeArgs GetCurrentArgs()
		{
			return new FillFeeArgs();
		}
		
		#endregion
	}
}

