
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	MebCompanyPrepayAccess.cs
* 作者:	     郑华
* 创建日期:    2008-7-18
* 功能描述:    单位预存

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
	/// **功能名称：单位预存数据访问类
	/// </summary>
	public class MebCompanyPrepayAccess
	{
		// 这里写你的代码


		//添加单位
		public static void AddCompany(SqlTransaction trans,MebCompanyPrepay company)
		{
			EntityMapping.Create(company,trans);
		}
		public static void UpdateCompany(SqlTransaction trans,MebCompanyPrepay company)
		{
			string strvalidate = company.cnbValidate?"1":"0";
			string strsql = "update tbmebcompanyprepay set cnvcCompanyName='"+company.cnvcCompanyName+"',cnbValidate="+strvalidate+" where cnvcCompanyID='"+company.cnvcCompanyID.ToString()+"'";
			SqlHelper.ExecuteNonQuery(trans,CommandType.Text,strsql);
		}

		#region 生成器生成代码



		/// <summary>
		/// 取当前查询参数实例


		/// </summary>
		/// <returns>查询参数</returns>
		private static MebCompanyPrepayArgs GetCurrentArgs()
		{
			return new MebCompanyPrepayArgs();
		}
		
		#endregion
	}
}

