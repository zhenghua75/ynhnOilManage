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
	/// SpecialOilFacade ��ժҪ˵����
	/// </summary>
	public class SpecialOilFacade
	{
		public SpecialOilFacade()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
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
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
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
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
			}
		}
	}
}
