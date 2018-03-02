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
	/// Summary description for Authorization.
	/// 郑华　2007-3-7
	/// </summary>
	public class Authorization
	{
		public Authorization()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataTable GetAllOper()
		{
			SqlConnection conn = ConnectionPool.BorrowConnection();
			DataTable dtRet = null;
			try
			{
				dtRet = OperAccess.GetAllOper(conn);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
			return dtRet;
		}
		public DataTable GetAllDept()
		{
			SqlConnection conn = ConnectionPool.BorrowConnection();
			DataTable dtRet = null;
			try
			{
				dtRet = DeptAccess.GetAllDept(conn);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
			return dtRet;
		}

		public Dept GetDept(Dept dept)
		{
			SqlConnection conn = ConnectionPool.BorrowConnection();
			Dept retDept = null;
			try
			{
				retDept = DeptAccess.GetDept(conn,dept);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
			return retDept;
		}
		public DataTable GetAllOperNoAdmin()
		{
			SqlConnection conn = ConnectionPool.BorrowConnection();
			DataTable dtRet = null;
			try
			{
				dtRet = OperAccess.GetAllOperNoAdmin(conn);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
			return dtRet;
		}
		public DataTable GetAllFunction()
		{
			SqlConnection conn = ConnectionPool.BorrowConnection();
			DataTable dtRet = null;
			try
			{
				dtRet = FuncAccess.GetAllFunction(conn);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
			return dtRet;
		}
		public DataTable GetOneOperFuncList(string strOperID)
		{
			SqlConnection conn = ConnectionPool.BorrowConnection();
			DataTable dtRet = null;
			try
			{
				dtRet = OperFuncAccess.GetOneOperFuncList(conn,strOperID);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
			return dtRet;
		}
		public int DeleteOperFunc(OperFunc operFunc,BusiLog busiLog)
		{
			//SqlConnection conn = ConnectionPool.BorrowConnection();
			int iRet = 0;
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					iRet = OperFuncAccess.DeleteOperFunc(trans,operFunc);
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
		public int AddOperFunc(OperFunc operFunc,BusiLog busiLog)
		{
			//SqlConnection conn = ConnectionPool.BorrowConnection();
			int iRet = 0;
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					iRet = OperFuncAccess.AddOperFunc(trans,operFunc);
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
		public int UpdatePwd(Oper oper,BusiLog busiLog)
		{
			//SqlConnection conn = ConnectionPool.BorrowConnection();
			int iRet = 0;
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					iRet = OperAccess.UpdatePwd(trans,oper);
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
		public int AddOper(Oper oper,BusiLog busiLog)
		{
			int iRet = 0;
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					iRet = OperIDAccess.GetOperID(trans);
					oper.cnnOperID = iRet;
					oper.cnvcPwd = DataSecurity.Encrypt(oper.cnvcPwd);
					OperAccess.AddOper(trans,oper);

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
		public Oper GetOper(Oper oper)
		{
			SqlConnection conn = ConnectionPool.BorrowConnection();
			Oper OldOper = null;
			try
			{
				OldOper = OperAccess.GetOper(conn,oper);
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
			return OldOper;
		}
		

		public void AddDept(Dept dept,BusiLog busiLog)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					DeptAccess.AddDept(trans,dept);
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

		public int GetOperID()
		{
			int iRet = 0;
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{					
					iRet = OperIDAccess.GetOperID(trans);
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
		public string GetDeptID(string strParentDeptID)
		{
			SqlConnection conn = ConnectionPool.BorrowConnection();
			string strDeptID = "";
			try
			{
				string strLength = Convert.ToString(strParentDeptID.Length+1);
				string s = SqlHelper.ExecuteScalar(conn,CommandType.Text,"select max(cast(substring(cnvcDeptID,"+strLength+",2) as int)) from tbDept where cnvcParentDeptID='"+strParentDeptID+"'").ToString();
				if (s == "")
				{
					s = "0";
				}
				int i = int.Parse(s);				
				if ( i<9 )
				{
					strDeptID= strParentDeptID+"0"+ Convert.ToString(i+1);
				}
				else if (  i>=9  && i<99 )
				{
					strDeptID = strParentDeptID+Convert.ToString(i+1); 
				}
				else
				{
					throw new Exception("部门ID超出范围！");
				}
			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
			return strDeptID;
		}
		
		public int UpdateDept(Dept dept,BusiLog busiLog)
		{
			//SqlConnection conn = ConnectionPool.BorrowConnection();
			int iRet = 0;
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					BusiLogAccess.AddBusiLog(trans,busiLog);
					Dept olddept = new Dept();
					olddept.cnvcDeptID = dept.cnvcDeptID;
					olddept = EntityMapping.Get(olddept,trans) as Dept;

					olddept.cnbValidate = dept.cnbValidate;
					olddept.cnvcDeptName = dept.cnvcDeptName;
					olddept.cnvcParentDeptID = dept.cnvcParentDeptID;

					iRet = DeptAccess.UpdateDept(trans,olddept);
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

		public int AddOilPrice(OilPrice price,BusiLog busiLog)
		{
			//SqlConnection conn = ConnectionPool.BorrowConnection();
			int iRet = 0;
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();	
				
				SqlTransaction trans = conn.BeginTransaction();
				try
				{
					BusiLogAccess.AddBusiLog(trans,busiLog);
					iRet = (int)OilPriceAccess.AddOilPrice(trans,price);
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
