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
	/// SpecialOilFacade 的摘要说明。
	/// </summary>
	public class SpecialOilFacade
	{
		public SpecialOilFacade()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public static void AddSpecialOilDept(SpecialOilDept specialOilDept,BusiLog busiLog)
		{
			try
			{		
				BusinessRules.SysManage.SpecialOil specialOil = new BusinessRules.SysManage.SpecialOil();
				specialOil.AddSpecialOilDept(specialOilDept,busiLog);
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

		public static void UpdateSpecialOilDept(string strContractNo,SpecialOilDept specialOilDept,BusiLog busiLog)
		{
			try
			{		
				BusinessRules.SysManage.SpecialOil specialOil = new BusinessRules.SysManage.SpecialOil();
				specialOil.UpdateSpecialOilDept(strContractNo,specialOilDept,busiLog);
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

		public static void DeleteSpecialOilDept(SpecialOilDept specialOilDept,BusiLog busiLog)
		{
			try
			{		
				BusinessRules.SysManage.SpecialOil specialOil = new BusinessRules.SysManage.SpecialOil();
				specialOil.DeleteSpecialOilDept(specialOilDept,busiLog);
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
	}
}
