#region ���ֿռ�����

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
	/// ������Ա�����.
	/// </summary>
	public class OperFacade
	{
		public static Oper OperLogin(string strOperName,string strPassword,string strLoginIP,string strBrowser,out ArrayList lstPurview,out ArrayList lstPage)
		{
			try
			{
				ynhnOilManage.BusinessRules.SysManage.OperLogin rule = 
					                     new ynhnOilManage.BusinessRules.SysManage.OperLogin(strOperName,strPassword,strLoginIP,strBrowser);

				return rule.Login(out lstPurview,out lstPage);
			}
			catch(BusinessException be)
			{
				throw be;
			}
			catch(SqlException se)
			{
				LogAdapter.WriteDatabaseException(se);
				throw new Exception("���ݿ�����쳣��");
			}
			catch(Exception e)
			{
				LogAdapter.WriteFeaturesException(e);
				throw new Exception("ҵ�������쳣��");
			}
		}


		//��ȡ����Ա�б�
		public static DataTable GetAllOper()
		{
			DataTable dtRet = null;
			try
			{
				BusinessRules.SysManage.Authorization auth = new BusinessRules.SysManage.Authorization();
				dtRet = auth.GetAllOper();
			}
			catch(SqlException sex)
			{
				LogAdapter.WriteDatabaseException(sex);	
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
			}

			return dtRet;
			
		}
		//��ȡ�����б�
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
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
			}

			return dtRet;
			
		}
		public static DataTable GetAllOperNoAdmin()
		{
			DataTable dtRet = null;
			try
			{
				BusinessRules.SysManage.Authorization auth = new BusinessRules.SysManage.Authorization();
				dtRet = auth.GetAllOperNoAdmin();
			}
			catch(SqlException sex)
			{
				LogAdapter.WriteDatabaseException(sex);	
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
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
			catch(SqlException sex)
			{
				LogAdapter.WriteDatabaseException(sex);	
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
			}
			return dtRet;
			
		}

		public static DataTable GetOneOperFuncList(string strOperID)
		{
			DataTable dtRet = null;
			try
			{			
				BusinessRules.SysManage.Authorization auth = new BusinessRules.SysManage.Authorization();
				dtRet = auth.GetOneOperFuncList(strOperID);
			}
			catch(SqlException sex)
			{
				LogAdapter.WriteDatabaseException(sex);	
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
			}
			return dtRet;
			
		}
		public static int DeleteOperFunc(OperFunc operFunc,BusiLog busiLog)
		{
			int ret = 0;
			try
			{
				BusinessRules.SysManage.Authorization auth = new BusinessRules.SysManage.Authorization();
				ret = auth.DeleteOperFunc(operFunc,busiLog);
			}
			catch(SqlException sex)
			{
				LogAdapter.WriteDatabaseException(sex);	
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
			}
			return ret;
			
		}
		public static int AddOperFunc(OperFunc operFunc,BusiLog busiLog)
		{
			int ret = 0;
			try
			{		
				BusinessRules.SysManage.Authorization auth = new BusinessRules.SysManage.Authorization();
				ret = auth.AddOperFunc(operFunc,busiLog);
			}
			catch(SqlException sex)
			{
				LogAdapter.WriteDatabaseException(sex);	
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
			}
			return ret;
			
		}
		public static int UpdatePwd(Oper oper,BusiLog busiLog)
		{
			int ret = 0;
			try
			{		
				BusinessRules.SysManage.Authorization auth = new BusinessRules.SysManage.Authorization();
				ret = auth.UpdatePwd(oper,busiLog);
			}
			catch(SqlException sex)
			{
				LogAdapter.WriteDatabaseException(sex);	
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
			}
			return ret;
			
		}
		public static int AddOper(Oper oper,BusiLog busiLog)
		{
			int ret = 0;
			try
			{		
				BusinessRules.SysManage.Authorization auth = new BusinessRules.SysManage.Authorization();
				ret = auth.AddOper(oper,busiLog);
			}
			catch(SqlException sex)
			{
				LogAdapter.WriteDatabaseException(sex);	
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
			}
			return ret;
		}
		public static Oper GetOper(Oper oper)
		{
			Oper OldOper = null;
			try
			{		
				BusinessRules.SysManage.Authorization auth = new BusinessRules.SysManage.Authorization();
				OldOper = auth.GetOper(oper);
			}
			catch(SqlException sex)
			{
				LogAdapter.WriteDatabaseException(sex);	
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
			}
			return OldOper;
		}
	}
}
