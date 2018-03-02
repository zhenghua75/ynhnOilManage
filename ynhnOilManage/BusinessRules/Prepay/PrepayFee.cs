using System;
using System.Data;
using System.Data.SqlClient;
using ynhnOilManage.DataAccess.Common;
using ynhnOilManage.DataAccess.AccessClass;
using ynhnOilManage.DataAccess.QueryArgs;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.Common;
using System.Security.Cryptography;

namespace ynhnOilManage.BusinessRules.Prepay
{
	/// <summary>
	/// PrepayFee 的摘要说明。
	/// </summary>
	public class PrepayFee
	{
		public PrepayFee()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public void AddCompany(MebCompanyPrepay company,FillFee fee,BusiLog busiLog)
		{

			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					MebCompanyPrepayAccess.AddCompany(trans,company);
					FillFeeAccess.AddFee(trans,fee);
					BusiLogAccess.AddBusiLog(trans,busiLog);
					trans.Commit();
				}
				catch(SqlException sex)
				{
					trans.Rollback();
					throw sex;
				}
				catch(Exception ex)
				{
					trans.Rollback();
					throw ex;
				}
				finally
				{
					ConnectionPool.ReturnConnection(conn);
				}
			}
		}
		public void UpdateCompany(MebCompanyPrepay company,BusiLog busiLog)
		{

			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					MebCompanyPrepayAccess.UpdateCompany(trans,company);
					//FillFeeAccess.AddFee(trans,fee);
					MemberAccess.UpdateMemberCompany(trans,company);
					BusiLogAccess.AddBusiLog(trans,busiLog);
					trans.Commit();
				}
				catch(SqlException sex)
				{
					trans.Rollback();
					throw sex;
				}
				catch(Exception ex)
				{
					trans.Rollback();
					throw ex;
				}
				finally
				{
					ConnectionPool.ReturnConnection(conn);
				}
			}
		}
		public void AddFee(FillFee fee,BusiLog busiLog)
		{

			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMebCompanyPrepay set cnnPrepayFee = cnnPrepayFee+"+fee.cnnFillFee.ToString()+" where cnvcCompanyID='"+fee.cnvcCompanyID.ToString()+"'");
					FillFeeAccess.AddFee(trans,fee);
					BusiLogAccess.AddBusiLog(trans,busiLog);
					trans.Commit();
				}
				catch(SqlException sex)
				{
					trans.Rollback();
					throw sex;
				}
				catch(Exception ex)
				{
					trans.Rollback();
					throw ex;
				}
				finally
				{
					ConnectionPool.ReturnConnection(conn);
				}
			}
		}
	}
}
