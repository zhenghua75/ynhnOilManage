
#region ���ƿռ�����

using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Configuration;
using System.Web.Security;

#endregion

namespace ynhnOilManage.Interface
{
	#region ģ��ע��

	///<summary>
	///��    �ã����幫����Ա,����ɳ�ʼ������
	///��    �ߣ�Fightop Lin
	///��д���ڣ�2003-11-11
	///</summary>
	
	///<summary>
	///Log�� �ţ�1
	///�޸��������������ݿ������ַ�����̬����������Application_Start�¼��г�ʼ��
	///��    �ߣ�Fightop Lin
	///�޸����ڣ�2003-11-12
	///</summary>
	
	#endregion

	public class Global : System.Web.HttpApplication
	{

		#region ������

		public Global()
		{
			InitializeComponent();
		}	
		
		#endregion


		#region �¼�����

		protected void Application_Start(Object sender, EventArgs e)
		{
			CommonStatic.LoadOperDictionary();
			CommonStatic.LoadDeptDictionary();
		}
 


		protected void Session_Start(Object sender, EventArgs e)
		{
		}



		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			
		}



		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}



		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}



		protected void Application_Error(Object sender, EventArgs e)
		{

		}



		protected void Session_End(Object sender, EventArgs e)
		{
		}



		protected void Application_End(Object sender, EventArgs e)
		{

		}

		#endregion


		#region WEB���������ά������

		/// <summary>
		/// ϵͳ���б������
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#endregion

			
		#region Web ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

