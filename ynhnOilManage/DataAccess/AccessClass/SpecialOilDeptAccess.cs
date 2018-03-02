
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	SpecialOilDeptAccess.cs
* 作者:	     郑华
* 创建日期:    2008-8-27
* 功能描述:    专供油领用单位

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
	/// **功能名称：专供油领用单位数据访问类
	/// </summary>
	public class SpecialOilDeptAccess
	{
		// 这里写你的代码

		//添加
		public static long AddSpecialOilDept(SqlTransaction trans,SpecialOilDept specialOilDept)
		{
			return EntityMapping.Create(specialOilDept,trans);
		}
		public static int UpdateSpecialOilDept(SqlTransaction trans,string strContractNo,SpecialOilDept specialOilDept)
		{
			return SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbSpecialOilDept set cnvcContractNo='"+specialOilDept.cnvcContractNo+"',cnvcDeliveryCompany='"+specialOilDept.cnvcDeliveryCompany+"' where cnvcContractNo='"+strContractNo+"'");
		}
		public static int DeleteSpecialOilDept(SqlTransaction trans,SpecialOilDept specialOilDept)
		{
			return EntityMapping.Delete(specialOilDept,trans);
		}


		#region 生成器生成代码



		/// <summary>
		/// 取当前查询参数实例


		/// </summary>
		/// <returns>查询参数</returns>
		private static SpecialOilDeptArgs GetCurrentArgs()
		{
			return new SpecialOilDeptArgs();
		}
		
		#endregion
	}
}

