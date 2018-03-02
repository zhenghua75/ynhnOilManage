#region ���ֿռ�����

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
	#region ģ��ע��
	///<summary>
	///��    �ã����þ�̬��Ա����
	///��    �ߣ�Fightop Lin
	///��д���ڣ�2007-03-15
	///</summary>
	
	///<summary>
	///Log�� �ţ�1
	///�޸�������
	///��    �ߣ�
	///�޸����ڣ�
	///</summary>
	#endregion
	public class CommonStatic
	{
		/// <summary>
		/// ���ز�����Ա�ֵ�
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
		/// ���ز����ֵ�
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
			string strEnterpriseFullName = "���ϻ������׽�ˮ���������޹�˾";
			if(Array.IndexOf(System.Configuration.ConfigurationSettings.AppSettings.AllKeys,ynhnOilManage.Common.ConstValue.ENTERPRISEFULLNAME)>0)
			{
				strEnterpriseFullName = System.Configuration.ConfigurationSettings.AppSettings[ynhnOilManage.Common.ConstValue.ENTERPRISEFULLNAME];
			}
			return strEnterpriseFullName;
		}

		public static string EnterpriseShortName()
		{
			string strEnterpriseShortName = "���ϻ������׽�";
			if(Array.IndexOf(System.Configuration.ConfigurationSettings.AppSettings.AllKeys,ynhnOilManage.Common.ConstValue.ENTERPRISESHORTNAME)>0)
			{
				strEnterpriseShortName = System.Configuration.ConfigurationSettings.AppSettings[ynhnOilManage.Common.ConstValue.ENTERPRISESHORTNAME];
			}
			return strEnterpriseShortName;
		}

		public static string WebSiteTitle()
		{
			string strWebSiteTitle = "���ϻ������׽����Ϳ�����ϵͳ";
			if(Array.IndexOf(System.Configuration.ConfigurationSettings.AppSettings.AllKeys,ynhnOilManage.Common.ConstValue.WEBSITETITLE)>0)
			{
				strWebSiteTitle = System.Configuration.ConfigurationSettings.AppSettings[ynhnOilManage.Common.ConstValue.WEBSITETITLE];
			}
			return strWebSiteTitle;
		}
	}
}
