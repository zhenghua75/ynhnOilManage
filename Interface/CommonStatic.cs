#region 名字空间引用

using System;
using System.Web;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

using ynhnOilManage.Common;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.BusinessFacade.SysManage;

#endregion

namespace ynhnOilManage.Interface
{
	#region 模块注释
	///<summary>
	///作    用：公用静态成员方法
	///作    者：Fightop Lin
	///编写日期：2007-03-15
	///</summary>
	
	///<summary>
	///Log编 号：1
	///修改描述：
	///作    者：
	///修改日期：
	///</summary>
	#endregion
	public class CommonStatic
	{
		/// <summary>
		/// 加载操作人员字典
		/// </summary>
		public static void LoadOperDictionary()
		{
			Hashtable lstOper = new Hashtable();
			DataTable tblOper = OperFacade.GetAllOper();

			foreach(DataRow row in tblOper.Rows)
			{
				Oper objOper = new Oper(row);
				if(null == lstOper[objOper.cnnOperID])
				{
					lstOper.Add(objOper.cnnOperID,objOper);
				}
			}

			HttpContext.Current.Application[ConstValue.OPER_DICTI_NAME] = lstOper;
		}

		/// <summary>
		/// 加载部门字典
		/// </summary>
		public static void LoadDeptDictionary()
		{
			Hashtable lstDept = new Hashtable();
			DataTable tblDept = DeptFacade.GetAllDept();

			foreach(DataRow row in tblDept.Rows)
			{
				Dept objDept = new Dept(row);
				if(null == lstDept[objDept.cnvcDeptID])
				{
					lstDept.Add(objDept.cnvcDeptID,objDept);
				}
			}
			Dept topDept = new Dept();
			topDept.cnvcDeptName = EnterpriseShortName();
			topDept.cnvcDeptID = "00";
			lstDept.Add(topDept.cnvcDeptID,topDept);

			HttpContext.Current.Application[ConstValue.DEPT_DICTI_NAME] = lstDept;
		}

		public static string EnterpriseFullName()
		{
			string strEnterpriseFullName = "云南华能澜沧江水电物资有限公司";
			if(Array.IndexOf(System.Configuration.ConfigurationSettings.AppSettings.AllKeys,ynhnOilManage.Common.ConstValue.ENTERPRISEFULLNAME)>0)
			{
				strEnterpriseFullName = System.Configuration.ConfigurationSettings.AppSettings[ynhnOilManage.Common.ConstValue.ENTERPRISEFULLNAME];
			}
			return strEnterpriseFullName;
		}

		public static string EnterpriseShortName()
		{
			string strEnterpriseShortName = "云南华能澜沧江";
			if(Array.IndexOf(System.Configuration.ConfigurationSettings.AppSettings.AllKeys,ynhnOilManage.Common.ConstValue.ENTERPRISESHORTNAME)>0)
			{
				strEnterpriseShortName = System.Configuration.ConfigurationSettings.AppSettings[ynhnOilManage.Common.ConstValue.ENTERPRISESHORTNAME];
			}
			return strEnterpriseShortName;
		}

		public static string WebSiteTitle()
		{
			string strWebSiteTitle = "云南华能澜沧江加油卡管理系统";
			if(Array.IndexOf(System.Configuration.ConfigurationSettings.AppSettings.AllKeys,ynhnOilManage.Common.ConstValue.WEBSITETITLE)>0)
			{
				strWebSiteTitle = System.Configuration.ConfigurationSettings.AppSettings[ynhnOilManage.Common.ConstValue.WEBSITETITLE];
			}
			return strWebSiteTitle;
		}
	}
}
