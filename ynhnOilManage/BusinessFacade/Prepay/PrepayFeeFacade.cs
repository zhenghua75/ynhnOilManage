#region ���ֿռ�����

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
	/// PrepayFeeFacade ��ժҪ˵����
	/// </summary>
	public class PrepayFeeFacade
	{
		public PrepayFeeFacade()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
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
				throw new Exception("���ݿ�����쳣��");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("ҵ�������쳣��");
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
