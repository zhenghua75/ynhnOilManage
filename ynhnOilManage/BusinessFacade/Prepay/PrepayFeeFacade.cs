#region 名字空间引用

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.Common;
using ynhnOilManage.BusinessRules;

#endregion

namespace ynhnOilManage.BusinessFacade.Prepay
{
	/// <summary>
	/// PrepayFeeFacade 的摘要说明。
	/// </summary>
	public class PrepayFeeFacade
	{
		public PrepayFeeFacade()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public static void AddCompany(MebCompanyPrepay company,FillFee fee,BusiLog busiLog)
		{
			try
			{		
				BusinessRules.Prepay.PrepayFee prepay = new BusinessRules.Prepay.PrepayFee();
				prepay.AddCompany(company,fee,busiLog);
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
		public static void UpdateCompany(MebCompanyPrepay company,BusiLog busiLog)
		{
			try
			{		
				BusinessRules.Prepay.PrepayFee prepay = new BusinessRules.Prepay.PrepayFee();
				prepay.UpdateCompany(company,busiLog);
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

		public static void AddFee(FillFee fee,BusiLog busiLog)
		{
			try
			{		
				BusinessRules.Prepay.PrepayFee prepay = new BusinessRules.Prepay.PrepayFee();
				prepay.AddFee(fee,busiLog);
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
