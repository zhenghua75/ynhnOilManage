#region 名字空间引用

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.Common;
using ynhnOilManage.BusinessRules;

#endregion

namespace ynhnOilManage.BusinessFacade.SysManage
{
	/// <summary>
	/// DeptFacade 的摘要说明。
	/// </summary>
	public class DeptFacade
	{
		public DeptFacade()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//获取部门列表
		public static DataTable GetAllDept()
		{
			DataTable dtRet = null;
			try
			{
				BusinessRules.SysManage.Authorization auth = new BusinessRules.SysManage.Authorization();
				dtRet = auth.GetAllDept();
			}
			catch(SqlException sex)
			{
				LogAdapter.WriteDatabaseException(sex);	
				throw new Exception("数据库访问异常。");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("业务规则层异常。");
			}

			return dtRet;
			
		}
		public static Dept GetDept(Dept dept)
		{
			Dept retDept = null;
			try
			{
				BusinessRules.SysManage.Authorization auth = new BusinessRules.SysManage.Authorization();
				retDept = auth.GetDept(dept);
			}
			catch(SqlException sex)
			{
				LogAdapter.WriteDatabaseException(sex);	
				throw new Exception("数据库访问异常。");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("业务规则层异常。");
			}

			return retDept;
			
		}

		public static void AddDept(Dept dept,BusiLog busiLog)
		{
			try
			{		
				BusinessRules.SysManage.Authorization auth = new BusinessRules.SysManage.Authorization();
				auth.AddDept(dept,busiLog);
			}
			catch(SqlException sex)
			{
				LogAdapter.WriteDatabaseException(sex);	
				throw new Exception("数据库访问异常。");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("业务规则层异常。");
			}
		}

		public static string GetDeptID(string strParentDeptID)
		{
			string strDeptID = "";
			try
			{		
				BusinessRules.SysManage.Authorization auth = new BusinessRules.SysManage.Authorization();
				strDeptID = auth.GetDeptID(strParentDeptID);
			}
			catch(SqlException sex)
			{
				LogAdapter.WriteDatabaseException(sex);	
				throw new Exception("数据库访问异常。");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("业务规则层异常。");
			}
			return strDeptID;
		}
		public static int UpdateDept(Dept dept,BusiLog busiLog)
		{
			int ret = 0;
			try
			{		
				BusinessRules.SysManage.Authorization auth = new BusinessRules.SysManage.Authorization();
				ret = auth.UpdateDept(dept,busiLog);
			}
			catch(SqlException sex)
			{
				LogAdapter.WriteDatabaseException(sex);	
				throw new Exception("数据库访问异常。");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("业务规则层异常。");
			}
			return ret;
		}
		public static int AddOilPrice(OilPrice price,BusiLog busiLog)
		{
			int ret = 0;
			try
			{		
				BusinessRules.SysManage.Authorization auth = new BusinessRules.SysManage.Authorization();
				ret = auth.AddOilPrice(price,busiLog);
			}
			catch(SqlException sex)
			{
				LogAdapter.WriteDatabaseException(sex);	
				throw new Exception("数据库访问异常。");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("业务规则层异常。");
			}
			return ret;
		}
	}
}
