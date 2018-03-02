using System;
using System.Data;
using System.Data.SqlClient;
using ynhnOilManage.DataAccess.Common;
using ynhnOilManage.DataAccess.AccessClass;
using ynhnOilManage.DataAccess.QueryArgs;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.Common;
using System.Security.Cryptography;

namespace ynhnOilManage.BusinessRules.SysManage
{
	/// <summary>
	/// SpecialOil 的摘要说明。
	/// </summary>
	public class SpecialOil
	{
		public SpecialOil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public int AddSpecialOilDept(SpecialOilDept specialOilDept,BusiLog busiLog)
		{
			//SqlConnection conn = ConnectionPool.BorrowConnection();
			int iRet = 0;
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					iRet = (int)SpecialOilDeptAccess.AddSpecialOilDept(trans,specialOilDept);
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
			return iRet;
		}

		public int UpdateSpecialOilDept(string strContractNo,SpecialOilDept specialOilDept,BusiLog busiLog)
		{
			//SqlConnection conn = ConnectionPool.BorrowConnection();
			int iRet = 0;
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					iRet = (int)SpecialOilDeptAccess.UpdateSpecialOilDept(trans,strContractNo,specialOilDept);
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
			return iRet;
		}

		public int DeleteSpecialOilDept(SpecialOilDept specialOilDept,BusiLog busiLog)
		{
			//SqlConnection conn = ConnectionPool.BorrowConnection();
			int iRet = 0;
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					iRet = SpecialOilDeptAccess.DeleteSpecialOilDept(trans,specialOilDept);
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
			return iRet;
		}
	
	}


}
