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
	/// DeptFacade ��ժҪ˵����
	/// </summary>
	public class DeptFacade
	{
		public DeptFacade()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
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
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
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
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
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
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
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
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
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
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
			}
			return ret;
		}
	}
}
