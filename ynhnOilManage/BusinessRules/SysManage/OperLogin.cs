
#region ���ֿռ�����

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.DataAccess.AccessClass;

#endregion

namespace ynhnOilManage.BusinessRules.SysManage
{
	#region ģ��ע��
	///<summary>
	///��    �ã�������Ա��¼ҵ�������
	///��    �ߣ�Fightop Lin
	///��д���ڣ�2007-03-07
	///</summary>
	
	///<summary>
	///Log�� �ţ�1
	///�޸�������
	///��    �ߣ�
	///�޸����ڣ�
	///</summary>
	#endregion
	public class OperLogin
	{
		private string strOperName   = String.Empty;
		private string strPassword   = String.Empty;
		private string strLoginIP    = String.Empty;
		private string strBrowser    = String.Empty;

		/// <summary>
		/// ������
		/// </summary>
		/// <param name="strUserID">����Ա����</param>
		/// <param name="strPassword">����Ա����</param>
		/// <param name="strLoginIP">��¼IP</param>
		/// <param name="strBrowser">ʹ�õ������</param>
		public OperLogin(string strOperName,string strPassword,string strLoginIP,string strBrowser)
		{
			this.strOperName   = strOperName;
			this.strPassword   = strPassword;
			this.strLoginIP    = strLoginIP;
			this.strBrowser    = strBrowser;
		}

		/// <summary>
		/// ִ�е�¼
		/// </summary>
		/// <returns></returns>
		public Oper Login(out ArrayList lstPurview,out ArrayList lstPage)
		{
			SqlConnection conn = ConnectionPool.BorrowConnection();
			try
			{
				
				#region ȡ����Աʵ��

				DataTable dtOper = OperAccess.GetOperByName(conn,strOperName);
				if (dtOper.Rows.Count > 1)
				{
					throw new BusinessException("����Ա��¼","��ͬ������Ա���ڣ���¼ʧ�ܣ�");
				}				
				// ȡ����Աʵ��
				Oper operLogin     = new Oper(dtOper);

				if(null == operLogin)
				{
					throw new BusinessException("����Ա��¼","����Ա�����ڣ���¼ʧ�ܣ�");
				}
				if(!operLogin.cnbValidate) throw new BusinessException("����Ա��¼","�˺���ʧЧ����¼ʧ�ܣ�");
				if(operLogin.cnvcPwd != DataSecurity.Encrypt(strPassword))
				{
					throw new BusinessException("����Ա��¼","����Ա���벻��ȷ����¼ʧ�ܣ�");
				}

				#endregion


				#region ���������ԱȨ��

				// ���������ԱȨ��
				lstPurview = new ArrayList();
				lstPage    = new ArrayList();
				DataTable dtOperFunc =  OperFuncAccess.GetOneOperFuncList(conn,operLogin.cnnOperID.ToString());
				foreach(DataRow row in dtOperFunc.Rows)
				{
					OperFunc operFunc = new OperFunc(row);					
					lstPurview.Add(operFunc.cnvcFuncName);
					lstPage.Add(operFunc.cnvcFuncAddress);
				}

				#endregion

				#region д��¼��־

				// д��¼��־
				LoginLog loginLog      = new LoginLog();
				loginLog.cnvcOperName    = strOperName; 
				loginLog.cnvcIPAddress = strLoginIP;
				loginLog.cnvcBrowser   = strBrowser;
				loginLog.cndLoginTime  = DateTime.Now;
				EntityMapping.Create(loginLog,conn);

				#endregion

				return operLogin;

			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
		}
	}
}
