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

using ynhnOilManage.Common;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.BusinessFacade.SysManage;

namespace ynhnOilManage.Interface.SysManage
{
	/// <summary>
	/// Summary description for ChangePassword.
	/// </summary>
	public class ChangePassword : wfmCommonBase
	{
		protected System.Web.UI.WebControls.Label lblOldPwd;
		protected System.Web.UI.WebControls.Label lblNewPwd;
		protected System.Web.UI.WebControls.Label lblConfirmPwd;
		protected System.Web.UI.WebControls.TextBox txtNewPwd;
		protected System.Web.UI.WebControls.TextBox txtConfirmPwd;
		protected System.Web.UI.WebControls.ImageButton btnOK;
		protected System.Web.UI.WebControls.ImageButton btnCancel;
		protected System.Web.UI.WebControls.Label lblOperName;
		protected System.Web.UI.WebControls.TextBox txtOperName;
		protected System.Web.UI.WebControls.ImageButton btnOperName;
		protected System.Web.UI.WebControls.TextBox txtOldPwd;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnOK.Click += new System.Web.UI.ImageClickEventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.Web.UI.ImageClickEventHandler(this.btnCancel_Click);
			this.btnOperName.Click += new System.Web.UI.ImageClickEventHandler(this.btnOperName_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnOK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//ȷ���޸�����
			try
			{
				if (txtOldPwd.Text.Length == 0 || txtNewPwd.Text.Length == 0 || txtConfirmPwd.Text.Length == 0)
				{
					throw new BusinessException("UpdatePwd","����Ϊ�գ�");
				}
				if (txtOldPwd.Text.Equals(txtNewPwd.Text))
				{
					throw new BusinessException("UpdatePwd","��������һ����");
				}
				if (!txtNewPwd.Text.Equals(txtConfirmPwd.Text))
				{
					throw new BusinessException("UpdatePwd","ȷ������������벻һ�£�");
				}
				if (Session[ConstValue.LOGIN_USER_SESSION] == null)
				{
					throw new BusinessException("UpdatePwd","���ȵ�¼��");
				}
				Oper oper = (Oper)Session[ConstValue.LOGIN_USER_SESSION];
				if (!txtOldPwd.Text.Equals(DataSecurity.Decrypt(oper.cnvcPwd)))
				{
					throw new BusinessException("UpdatePwd","����ľ��������");
				}
				oper.cnvcPwd = DataSecurity.Encrypt(txtNewPwd.Text);

				Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
				Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 
				BusiLog busiLog = new BusiLog();
				busiLog.cndOperDate = DateTime.Now;
				busiLog.cnnSerial = Guid.NewGuid();
				busiLog.cnvcOperName = curOper.cnvcOperName;
				busiLog.cnvcComments = "�޸����룺"+oper.cnvcOperName;
				busiLog.cnvcDeptID = curDept.cnvcDeptID;
				busiLog.cnvcDeptName = curDept.cnvcDeptName;
				busiLog.cnvcOperType = "BS006";
				busiLog.cnvcSource = "��վ";

				OperFacade.UpdatePwd(oper,busiLog);
				Session[ConstValue.LOGIN_USER_SESSION] = oper;
				Popup("�����޸ĳɹ���");
				
			}
			catch (Exception ex)
			{
				Popup(ex.Message);
			}			
		}

		private void btnCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//��������
			txtOldPwd.Text     = "";
			txtNewPwd.Text     = "";
			txtConfirmPwd.Text = "";
			txtOperName.Text   = "";
		}


		private void btnOperName_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//�޸��û�����
			Oper oper = (Oper)Session[ConstValue.LOGIN_USER_SESSION];
			try
			{
				oper.cnvcOperName = txtOperName.Text;
				Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
				Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 
				BusiLog busiLog = new BusiLog();
				busiLog.cndOperDate = DateTime.Now;
				busiLog.cnnSerial = Guid.NewGuid();
				busiLog.cnvcOperName = curOper.cnvcOperName;
				busiLog.cnvcComments = "�޸Ĳ���Ա���ƣ�"+oper.cnvcOperName;
				busiLog.cnvcDeptID = curDept.cnvcDeptID;
				busiLog.cnvcDeptName = curDept.cnvcDeptName;
				busiLog.cnvcOperType = "BS006";
				busiLog.cnvcSource = "��վ";

				OperFacade.UpdatePwd(oper,busiLog);
				CommonStatic.LoadOperDictionary();
				Session[ConstValue.LOGIN_USER_SESSION] = oper;
				Popup("�û��������޸ģ�");
			}
			catch (BusinessException bex)
			{
				Popup(bex.Message);
				return;
			}		
		}
	}
}
