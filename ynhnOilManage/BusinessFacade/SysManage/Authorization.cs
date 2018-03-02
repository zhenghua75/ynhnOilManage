using System;
using System.Data;
using System.Data.SqlClient;
using KxdInfo.KM.EntityObject.EntityClass;
using KxdInfo.KM.Common;
using KxdInfo.KM.BusinessRules;

namespace KxdInfo.KM.BusinessFacade.SysManage
{
	/// <summary>
	/// Summary description for Authorization.
	/// </summary>
	public class Authorization
	{
		public Authorization()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//获取操作员列表
		public static DataTable GetAllOper()
		{
			DataTable dtRet = null;
			try
			{
				BusinessRules.SysManage.Authorization auth = new BusinessRules.SysManage.Authorization();
				dtRet = auth.GetAllOper();
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
			}

			return dtRet;
			
		}

		public static DataTable GetAllFunction()
		{			
			DataTable dtRet = null;
			try
			{			
				BusinessRules.SysManage.Authorization auth = new BusinessRules.SysManage.Authorization();
				dtRet = auth.GetAllFunction();
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
			}
			return dtRet;
			
		}

		public static DataTable GetOneOperFunctionList(string strOperID)
		{
			DataTable dtRet = null;
			try
			{			
				BusinessRules.SysManage.Authorization auth = new BusinessRules.SysManage.Authorization();
				dtRet = auth.GetOneOperFunctionList(strOperID);
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
			}
			return dtRet;
			
		}
		public static int DeleteOperFunction(OperFunction operFunction)
		{
			int ret = 0;
			try
			{
				BusinessRules.SysManage.Authorization auth = new BusinessRules.SysManage.Authorization();
				ret = auth.DeleteOperFunction(operFunction);
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
			}
			return ret;
			
		}
		public static int AddOperFunction(OperFunction operFunction)
		{
			int ret = 0;
			try
			{		
				BusinessRules.SysManage.Authorization auth = new BusinessRules.SysManage.Authorization();
				ret = auth.AddOperFunction(operFunction);
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
			}
			return ret;
			
		}
	}
}
