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
using ynhnOilManage.BusinessFacade.SysManage;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.BusinessFacade.Report;
namespace ynhnOilManage.Interface.SysManage
{
	/// <summary>
	/// Summary description for UserProperties.
	/// </summary>
	public class UserProperties : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.TextBox txtOperName;
		
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidMethod;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidDept;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPwd;
		protected System.Web.UI.HtmlControls.HtmlInputText txtConfirmPwd;
		protected AlertControl alertControl;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidInputDate;
		protected System.Web.UI.WebControls.Label lbPwd;
		protected System.Web.UI.WebControls.Label lbConfirmPwd;
		protected System.Web.UI.WebControls.Label lbProperties;
		protected System.Web.UI.WebControls.TextBox txtOperID;
		protected System.Web.UI.WebControls.Button btnMoveOper;
		protected System.Web.UI.WebControls.Button btnAddOper;
		protected System.Web.UI.WebControls.CheckBox chkValidate;
		protected System.Web.UI.WebControls.Button btnOperPasswd;

	
	
		private void ShowComponents(string method)
		{
			hidMethod.Value=method;
			switch(method)
			{
				case "Add":
					lbPwd.Visible=true;
					lbConfirmPwd.Visible=true;
					txtConfirmPwd.Visible=true;
					txtConfirmPwd.Disabled=false;
					txtPwd.Visible=true;
					txtPwd.Disabled=false;
					txtOperName.Enabled=true;
					btnCancel.Visible=true;
					btnAddOper.Visible = false;
					btnOperPasswd.Visible = false;
					btnMoveOper.Visible = false;

					chkValidate.Visible = true;
					chkValidate.Enabled = true;
					lbProperties.Text="��Ӳ���Ա";
					btnSubmit.Text="�� ��";
					break;
				case "Update":
					lbPwd.Visible=false;
					lbConfirmPwd.Visible=false;
					txtConfirmPwd.Visible=false;
					txtPwd.Visible=false;
					txtOperName.Enabled=true;
					btnCancel.Visible=true;

					btnAddOper.Visible = false;
					btnOperPasswd.Visible = false;
					btnMoveOper.Visible = false;
					
					chkValidate.Visible = true;
					chkValidate.Enabled = true;
					lbProperties.Text="���²���Ա����";
					btnSubmit.Text="�� ��";
					break;
				case "Pwd":
					lbPwd.Visible=true;
					lbConfirmPwd.Visible=true;
					txtConfirmPwd.Visible=true;
					txtPwd.Visible=true;
					txtOperName.Enabled=false;
					btnCancel.Visible=true;

					btnAddOper.Visible = false;
					btnOperPasswd.Visible = false;
					btnMoveOper.Visible = false;

					chkValidate.Visible = false;
					lbProperties.Text="���²���Ա����";
					btnSubmit.Text="�� ��";
					break;
				default:
					lbPwd.Visible=false;
					lbConfirmPwd.Visible=false;
					txtConfirmPwd.Visible=false;
					txtPwd.Visible=false;
					txtOperName.Enabled=false;
					btnCancel.Visible=false;

					btnAddOper.Visible = true;
					btnOperPasswd.Visible = true;
					btnMoveOper.Visible = true;

					chkValidate.Visible = true;
					chkValidate.Enabled = false;
					lbProperties.Text="�û�����";
					btnSubmit.Text="�� ��";
					break;
			}
		}


		void LoadOper()
		{			
			Oper getOper = new Oper();
			getOper.cnnOperID = int.Parse(txtOperID.Text);
			OperFacade.GetOper(getOper);
            Oper oper = OperFacade.GetOper(getOper);
			if(oper!=null)
			{
                hidDept.Value = oper.cnvcDeptID;
                txtOperName.Text = oper.cnvcOperName;
                chkValidate.Checked = oper.cnbValidate;               
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			//oper = GetOperInfo();
			if(!this.IsPostBack)
			{
				string strMethod = Request["Method"];
				if(strMethod!=null) 
				{
					string strID = Request["OperID"];
					if(strID != null)
					{
						string[] ss = strID.Split('_');
						txtOperID.Text = ss[1];
					}
					strID = Request["DeptID"];
					if(strID!=null)
					{
						string[] ss=strID.Split('_');
						hidDept.Value=ss[1];
					}
				
					ShowComponents(strMethod);
				}

				if(hidMethod.Value.Equals("Update")||hidMethod.Value.Equals("Show")||hidMethod.Value.Equals("Pwd"))
					LoadOper();
			}

		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			base.OnInit(e);
			InitializeComponent();
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnAddOper.Click += new System.EventHandler(this.btnAddUser_Click);
			this.btnMoveOper.Click += new System.EventHandler(this.btnMoveOper_Click);
			this.btnOperPasswd.Click += new System.EventHandler(this.btnChangePwd_Click);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		bool  AddOper()
		{
			
			int iRet = 0;
			if(txtOperName.Text.Length==0)
			{
				alertControl.Enable=true;
				alertControl.Msg="���������Ա����";				
				return false;
			}
			
			if(txtPwd.Value.Length==0)
			{
				alertControl.Enable=true;
				alertControl.Msg="���������Ա��ʼ������";				
				return false;
			}

			if(!txtPwd.Value.Equals(txtConfirmPwd.Value))
			{
				alertControl.Enable=true;
				alertControl.Msg="�����ȷ�����벻ͬ������������";				
				return false;
			}
			
			try
			{
				DataTable dtCount = ReportQueryFacade.CommonQuery("select * from tbOper where cnvcOperName = '"+this.txtOperName.Text+"'");
				if (dtCount.Rows.Count > 0)
				{
					throw new Exception("ͬ������Ա�Ѵ��ڣ�������²���Ա��");
				}
                Oper oper = new Oper();
                oper.cnvcDeptID = this.hidDept.Value;
                oper.cnvcOperName = this.txtOperName.Text;
                oper.cnvcPwd = this.txtPwd.Value;
				oper.cnbValidate = this.chkValidate.Checked;

				Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
				Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 
				BusiLog busiLog = new BusiLog();
				busiLog.cndOperDate = DateTime.Now;
				busiLog.cnnSerial = Guid.NewGuid();
				busiLog.cnvcOperName = curOper.cnvcOperName;
				busiLog.cnvcComments = "��Ӳ���Ա��"+ this.txtOperName.Text;
				busiLog.cnvcDeptID = curDept.cnvcDeptID;
				busiLog.cnvcDeptName = curDept.cnvcDeptName;
				busiLog.cnvcOperType = "BS005";
				busiLog.cnvcSource = "��վ";

				iRet = OperFacade.AddOper(oper,busiLog);
			}
			catch(Exception ex)
			{
				alertControl.Enable=true;
				alertControl.Msg=ex.Message;
				return false;
			}
			alertControl.Action=AlertControl.ACTION.Script;
			alertControl.Enable=true;
			alertControl.Msg="�ɹ���Ӳ���Ա";
			alertControl.Script=string.Format("window.parent.OnAddNodeResult('{0}','{1}','{2}');",
				"dept_"+hidDept.Value,"oper_"+iRet.ToString(),txtOperName.Text);
			return true;
		}

		bool  delOper()
		{
			try
			{
                Oper oper = new Oper();
                oper.cnvcDeptID = this.hidDept.Value;
                oper.cnnOperID = int.Parse(this.txtOperID.Text);
                oper.cnvcOperName = this.txtOperName.Text;
                oper.cnvcPwd = this.txtPwd.Value;
                oper.cnbValidate = this.chkValidate.Checked;

			}
			catch(Exception ex)
			{
				alertControl.Enable=true;
				alertControl.Msg=ex.Message;
				return false;
			}
			alertControl.Action=AlertControl.ACTION.Script;
			alertControl.Enable=true;
			alertControl.Msg="�ɹ�ɾ������Ա";
			alertControl.Script=string.Format("window.parent.OnAddNodeResult('{0}','{1}','{2}');",
				"dept_"+hidDept.Value,"oper_"+txtOperID.Text,txtOperName.Text);
			return true;
		}

		bool UpdateOper()
		{
			if(txtOperName.Text.Length==0)
			{
				alertControl.Enable=true;
				alertControl.Msg="���������Ա����";				
				return false;
			}
			
			try
			{				
				DataTable dtCount = ReportQueryFacade.CommonQuery("select * from tbOper where cnvcOperName = '"+this.txtOperName.Text+"'");
				if (dtCount.Rows.Count > 1)
				{
					throw new Exception("ͬ������Ա�Ѵ��ڣ����޸Ĳ���Ա���ƣ�");
				}
				dtCount = ReportQueryFacade.CommonQuery("select * from tbOper where cnnOperID = "+this.txtOperID.Text);
				if(dtCount.Rows.Count == 0 ) throw new Exception("����Ա��Ϣ��ȡ����");
                Oper oper = new Oper(dtCount);
                //oper.cnnOperID = int.Parse(this.txtOperID.Text);
                oper.cnvcOperName = this.txtOperName.Text;
				oper.cnbValidate = this.chkValidate.Checked;

				Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
				Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 
				BusiLog busiLog = new BusiLog();
				busiLog.cndOperDate = DateTime.Now;
				busiLog.cnnSerial = Guid.NewGuid();
				busiLog.cnvcOperName = curOper.cnvcOperName;
				busiLog.cnvcComments = "�޸Ĳ���Ա���ƣ�"+this.txtOperName.Text;
				busiLog.cnvcDeptID = curDept.cnvcDeptID;
				busiLog.cnvcDeptName = curDept.cnvcDeptName;
				busiLog.cnvcOperType = "BS006";
				busiLog.cnvcSource = "��վ";

				OperFacade.UpdatePwd(oper,busiLog);
			}
			catch(Exception ex)
			{				
				alertControl.Enable=true;
				alertControl.Msg=ex.Message;
				return false;
			}
			alertControl.Enable=true;
			alertControl.Action=AlertControl.ACTION.Script;
			alertControl.Msg="�ɹ����²���Ա����";
			alertControl.Script=string.Format("window.parent.OnChangeNodeResult('{0}','{1}');",
				"oper_"+txtOperID.Text,txtOperName.Text);
			return true;
		}

		bool UpdatePwd()
		{
			if(txtPwd.Value.Length==0)
			{
				alertControl.Enable=true;
				alertControl.Msg="���������Ա��ʼ������";				
				return false;
			}

			if(!txtPwd.Value.Equals(txtConfirmPwd.Value))
			{
				alertControl.Enable=true;
				alertControl.Msg="�����ȷ�����벻ͬ������������";				
				return false;
			}
			
			try
			{				
//				dtCount = ReportQueryFacade.CommonQuery("select * from tbOper where cnnOperID = "+this.txtOperID.Text);
//				if(dtCount.Rows.Count == 0 ) throw new Exception("����Ա��Ϣ��ȡ����");
//				Oper oper = new Oper(dtCount);
				Oper oper = new Oper();
				oper.cnnOperID = int.Parse(this.txtOperID.Text);
				oper.cnvcPwd = DataSecurity.Encrypt(this.txtPwd.Value);

				Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
				Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 
				BusiLog busiLog = new BusiLog();
				busiLog.cndOperDate = DateTime.Now;
				busiLog.cnnSerial = Guid.NewGuid();
				busiLog.cnvcOperName = curOper.cnvcOperName;
				busiLog.cnvcComments = "�޸����룺"+this.txtOperName.Text;
				busiLog.cnvcDeptID = curDept.cnvcDeptID;
				busiLog.cnvcDeptName = curDept.cnvcDeptName;
				busiLog.cnvcOperType = "BS006";
				busiLog.cnvcSource = "��վ";

				OperFacade.UpdatePwd(oper,busiLog);
			}
			catch(Exception ex)
			{				
				alertControl.Enable=true;
				alertControl.Msg=ex.Message;
				return false;
			}
			alertControl.Enable=true;
			alertControl.Action=AlertControl.ACTION.Script;
			alertControl.Msg="�ɹ����²���Ա����";
			alertControl.Script=string.Format("window.parent.OnChangeNodeResult('{0}','{1}');",
				"oper_"+txtOperID.Text,txtOperName.Text);
			return true;
		}

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			switch(hidMethod.Value)
			{
				case "Add": 
					AddOper();
					break;
				case "Update":
					if(UpdateOper())
						ShowComponents("Show");
					break;
				case "Show":
					ShowComponents("Update");
					break;
				case "Pwd":
					if(UpdatePwd())
						ShowComponents("Show");
					break;
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			switch(hidMethod.Value)
			{
				case "Add":
					txtOperName.Text = "";
					txtPwd.Value = "";
					txtConfirmPwd.Value = "";
					break;
				case "Pwd":				
					LoadOper();
					ShowComponents("Show");
					break;
				case "Update":
					LoadOper();
					ShowComponents("Show");
					break;
			}
		}

		private void btnDelOper_Click(object sender, System.EventArgs e)
		{
			Response.Output.WriteLine("<script language=javascript>");
			Response.Output.WriteLine("var strWin = \"dialogWidth:450px;dialogHeight:450px;center:1;resizable:no;scroll:0;help:0;status:0\";");
			Response.Output.WriteLine("var strUrl=\"ChangePassword.aspx?OperID=" + txtOperID.Text + "\";");
			Response.Output.WriteLine("window.parent.showModalDialog(strUrl,null,strWin);");
			Response.Output.WriteLine("window.parent.SelectNodeByID(\"oper_" + txtOperID.Text + "\");");
			Response.Output.WriteLine("</script>");
			Response.End();
		}

		private void btnChangePwd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect( "UserProperties.aspx?Method=Pwd&OperID=oper_" + txtOperID.Text );
		}

		private void btnAddUser_Click(object sender, System.EventArgs e)
		{
			Response.Redirect( "UserProperties.aspx?Method=Add&DeptID=dept_" + hidDept.Value + "&OperID=oper_"+txtOperID.Text );
		}

		private void btnMoveOper_Click(object sender, System.EventArgs e)
		{
			Response.Output.WriteLine("<script language=javascript>");
			Response.Output.WriteLine("var node = window.parent.GetSelectedNode(window.parent.tv);");
			Response.Output.WriteLine("var strID = node.getAttribute(\"ID\");");
			Response.Output.WriteLine("window.parent.MoveObj(strID);");
			Response.Output.WriteLine("</script>");
			Response.End();
		}
	}
}
