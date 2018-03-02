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
			//确定修改密码
			try
			{
				if (txtOldPwd.Text.Length == 0 || txtNewPwd.Text.Length == 0 || txtConfirmPwd.Text.Length == 0)
				{
					throw new BusinessException("UpdatePwd","不能为空！");
				}
				if (txtOldPwd.Text.Equals(txtNewPwd.Text))
				{
					throw new BusinessException("UpdatePwd","新老密码一样！");
				}
				if (!txtNewPwd.Text.Equals(txtConfirmPwd.Text))
				{
					throw new BusinessException("UpdatePwd","确认密码和新密码不一致！");
				}
				if (Session[ConstValue.LOGIN_USER_SESSION] == null)
				{
					throw new BusinessException("UpdatePwd","请先登录！");
				}
				Oper oper = (Oper)Session[ConstValue.LOGIN_USER_SESSION];
				if (!txtOldPwd.Text.Equals(DataSecurity.Decrypt(oper.cnvcPwd)))
				{
					throw new BusinessException("UpdatePwd","输入的旧密码错误！");
				}
				oper.cnvcPwd = DataSecurity.Encrypt(txtNewPwd.Text);

				Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
				Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 
				BusiLog busiLog = new BusiLog();
				busiLog.cndOperDate = DateTime.Now;
				busiLog.cnnSerial = Guid.NewGuid();
				busiLog.cnvcOperName = curOper.cnvcOperName;
				busiLog.cnvcComments = "修改密码："+oper.cnvcOperName;
				busiLog.cnvcDeptID = curDept.cnvcDeptID;
				busiLog.cnvcDeptName = curDept.cnvcDeptName;
				busiLog.cnvcOperType = "BS006";
				busiLog.cnvcSource = "网站";

				OperFacade.UpdatePwd(oper,busiLog);
				Session[ConstValue.LOGIN_USER_SESSION] = oper;
				Popup("密码修改成功！");
				
			}
			catch (Exception ex)
			{
				Popup(ex.Message);
			}			
		}

		private void btnCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//重置数据
			txtOldPwd.Text     = "";
			txtNewPwd.Text     = "";
			txtConfirmPwd.Text = "";
			txtOperName.Text   = "";
		}


		private void btnOperName_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//修改用户名称
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
				busiLog.cnvcComments = "修改操作员名称："+oper.cnvcOperName;
				busiLog.cnvcDeptID = curDept.cnvcDeptID;
				busiLog.cnvcDeptName = curDept.cnvcDeptName;
				busiLog.cnvcOperType = "BS006";
				busiLog.cnvcSource = "网站";

				OperFacade.UpdatePwd(oper,busiLog);
				CommonStatic.LoadOperDictionary();
				Session[ConstValue.LOGIN_USER_SESSION] = oper;
				Popup("用户名称已修改！");
			}
			catch (BusinessException bex)
			{
				Popup(bex.Message);
				return;
			}		
		}
	}
}
