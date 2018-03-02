
#region ���ֿռ�����

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;

using ynhnOilManage.Common;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.BusinessFacade.SysManage;

#endregion


namespace ynhnOilManage.Interface.SysManage
{
	#region ģ��ע��
	///<summary>
	///��    �ã������û������֤������ʼ���û�����Ȩ��
	///��    �ߣ�Fightop Lin
	///��д���ڣ�2003-03-07
	///</summary>
	
	///<summary>
	///Log�� �ţ�1
	///�޸�������
	///��    �ߣ�
	///�޸����ڣ�
	///</summary>
	#endregion
	
	public class Login : System.Web.UI.Page
	{
		#region ҳ������¼�����
		public string WebSiteTitle;
		private void Page_Load(object sender, System.EventArgs e)
		{  // ҳ������¼�����
			this.WebSiteTitle = CommonStatic.WebSiteTitle();
			if ( !Page.IsPostBack)
			{  // �����һ�μ���ҳ��
				//this.tblAvi.Visible = false;  // �õ�¼�ɹ����������Ϊ���ɼ�

				//�û���Ϣ�ÿ�
				this.tbxAdminUser.Text = "";
				this.tbxAdminPass.Text = "";
			}

		}

		#endregion

		#region �˳���¼����

		private void btnExit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{  // �˳���ť�����¼�����
			string strJavaScript = "<script language='JavaScript'>" +
				                   "window.close();" +
				                   "</script>";
			Page.RegisterClientScriptBlock("ExitApp",strJavaScript);  // ��ͻ��˷��͹ر�������ű�
		}

		#endregion

		#region �û���¼����
		private void btnLogin_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				//����ҵ�����
				ArrayList lstPurview = null;
				ArrayList lstPage    = null;
				Oper operLogin = OperFacade.OperLogin(tbxAdminUser.Text.Trim(),tbxAdminPass.Text,Request.UserHostAddress,Request.Browser.Browser,out lstPurview,out lstPage);

				//���û���Ϣ���浽Session����
				Session[ConstValue.LOGIN_USER_SESSION] = operLogin;

				//���û��˵�Ȩ�ޱ��浽Session����
				Session[ConstValue.LOGIN_USER_PURVIEW_SESSION] = lstPurview;
				//���û�ҳ��Ȩ�ޱ��浽Session����
				Session[ConstValue.LOGIN_USER_PAGE_SESSION] = lstPage;
				

				tblInput.Visible = false;  // ���û���Ϣ�����Ϊ���ɼ�
				//tblAvi.Visible = true;     // �õ�¼�ɹ�����Ϊ�ɼ�,�ڵ�¼�ɹ����������һ֡��ҳ�浼����Main.aspx
				this.Response.Redirect("main.aspx");
			}
			catch(BusinessException be)
			{
				string strScript = "<script language='javascript'>";
				strScript       += "alert('" + be.Message + "');";
				strScript       += "</script>";

				Response.Write(strScript);
			}
		}

		#endregion


		#region ����������Ա����
		protected System.Web.UI.WebControls.TextBox tbxAdminUser;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvAdminUser;
		protected System.Web.UI.WebControls.RegularExpressionValidator revAdminUser;
		protected System.Web.UI.WebControls.TextBox tbxAdminPass;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvAdminPass;
		protected System.Web.UI.WebControls.ImageButton btnLogin;
		protected System.Web.UI.WebControls.ImageButton btnExit;
		protected System.Web.UI.HtmlControls.HtmlTable tblInput;
		protected System.Web.UI.HtmlControls.HtmlTable tblAvi;
		/// <summary>
		/// �����ά��������
		/// </summary>
		#endregion

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnLogin.Click += new System.Web.UI.ImageClickEventHandler(this.btnLogin_Click);
			this.btnExit.Click += new System.Web.UI.ImageClickEventHandler(this.btnExit_Click);
			this.ID = "frmLogin";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
