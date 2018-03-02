using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
	/// Summary description for DeptProperties.
	/// </summary>
	public class DeptProperties : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbProperties;
		protected System.Web.UI.WebControls.TextBox txtDeptName;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidMethod;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidParentID;
		protected ynhnOilManage.Interface.SysManage.AlertControl alertControl;
		protected System.Web.UI.WebControls.Button btnAddDept;
		protected System.Web.UI.WebControls.Button btnAddUser;
		protected System.Web.UI.WebControls.Button btnMoveDept;
		protected string strParentDept, strDept;
		protected System.Web.UI.WebControls.TextBox txtDeptID;
		protected System.Web.UI.WebControls.CheckBox chkValidate;
		protected System.Web.UI.WebControls.Button btnAgent;
		

		void ShowComponents(string strMethod)
		{
			hidMethod.Value=strMethod;
			switch(strMethod)
			{
				case "Add":
					txtDeptID.Enabled = true;
					chkValidate.Enabled = true;
					btnCancel.Visible=true;
					btnSubmit.Text="提 交";
					lbProperties.Text="添加部门";
					txtDeptName.Text = "";
					chkValidate.Checked = false;
					txtDeptName.Enabled=true;
					btnAddDept.Visible = false;
					btnAddUser.Visible = false;
					btnMoveDept.Visible = false;
					break;
				case "Update":
					txtDeptID.Enabled = false;
					btnCancel.Visible=true;
					btnSubmit.Text="提 交";
					lbProperties.Text="更新部门";
					txtDeptName.Enabled=true;
					chkValidate.Enabled = true;

					btnAddDept.Visible = false;
					btnAddUser.Visible = false;
					btnMoveDept.Visible = false;
					break;
				case "Show":

					txtDeptID.Enabled = false;
					btnCancel.Visible=false;
					btnSubmit.Text="更 改";
					lbProperties.Text="部门属性";
					txtDeptName.Enabled=false;
					chkValidate.Enabled = false;
					btnAddDept.Visible = true;
					btnAddUser.Visible = true;
					btnMoveDept.Visible = true;
					break;
			}
		}

		void LoadDept()
		{			
			Dept getDept = new Dept();
			getDept.cnvcDeptID = this.txtDeptID.Text;
			Dept dept = DeptFacade.GetDept(getDept);
			if(dept!=null)
			{
				hidParentID.Value=dept.cnvcParentDeptID;
				txtDeptName.Text=dept.cnvcDeptName;
				chkValidate.Checked = dept.cnbValidate;
			}
			if (this.txtDeptID.Text == "0")
			{
				hidParentID.Value="0";
				txtDeptName.Text=CommonStatic.EnterpriseFullName();
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
					string strID = Request["DeptID"];
					if(strID != null)
					{
						string[] ss = strID.Split('_');
						txtDeptID.Text=ss[1];
					}
					strID = Request["ParentDeptID"];
					if(strID != null)
					{
						string[] ss = strID.Split('_');
						hidParentID.Value = ss[1];
					}
					ShowComponents(strMethod);
				}
				if(hidMethod.Value.Equals("Update")||hidMethod.Value.Equals("Show"))
					LoadDept();
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
			this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
			this.btnMoveDept.Click += new System.EventHandler(this.btnMoveDept_Click);
			this.btnAddDept.Click += new System.EventHandler(this.btnAddDept_Click);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		bool AddDept()
		{
			string strDeptID = "";
			if(txtDeptName.Text.Length==0)
			{
				alertControl.Enable=true;
				alertControl.Msg="请输入部门名称";				
				return false;
			}
			try
			{
				//Dept getDept = new Dept();
				//getDept.cnvcDeptID = this.hidParentID.Value;

                //Dept deptParent = DeptFacade.GetDept(getDept);//BaseSqlMapDao.ExecuteQueryForObject("Dept.Select",this.hidParentID.Value) as ynhnOilManage.Common.Dept;


				DataTable dtCount = ReportQueryFacade.CommonQuery("select * from tbDept where cnvcDeptName = '"+this.txtDeptName.Text+"'");
				if (dtCount.Rows.Count > 0)
				{
					throw new Exception("同名部门已存在，请添加新部门！");
				}
				strDeptID = DeptFacade.GetDeptID(this.hidParentID.Value);
                Dept dept = new Dept();
				dept.cnvcDeptID = strDeptID;
                dept.cnvcParentDeptID = this.hidParentID.Value;
				dept.cnbValidate = this.chkValidate.Checked;
                dept.cnvcDeptName = this.txtDeptName.Text;	


				Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
				Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 
				BusiLog busiLog = new BusiLog();
				busiLog.cndOperDate = DateTime.Now;
				busiLog.cnnSerial = Guid.NewGuid();
				busiLog.cnvcOperName = curOper.cnvcOperName;
				busiLog.cnvcComments = "添加部门："+this.txtDeptName.Text;
				busiLog.cnvcDeptID = curDept.cnvcDeptID;
				busiLog.cnvcDeptName = curDept.cnvcDeptName;
				busiLog.cnvcOperType = "BS001";
				busiLog.cnvcSource = "网站";
				DeptFacade.AddDept(dept,busiLog);
                
			}
			catch(Exception ex)
			{
				alertControl.Enable=true;
				alertControl.Msg=ex.Message;				
				return false;
			}
			//成功添加部门
			alertControl.Action=AlertControl.ACTION.Script;
			alertControl.Enable=true;
			alertControl.Msg="成功添加部门";
			alertControl.Script=string.Format("window.parent.OnAddNodeResult('{0}','{1}','{2}');",
				"dept_"+hidParentID.Value,"dept_"+strDeptID,txtDeptName.Text);
			return true;
		}
		
		bool UpdateDept()
		{
			if(txtDeptName.Text.Length==0)
			{
				alertControl.Enable=true;
				alertControl.Msg="请输入部门名称";				
				return false;
			}
			try
			{
				DataTable dtCount = ReportQueryFacade.CommonQuery("select * from tbDept where cnvcDeptName = '"+this.txtDeptName.Text+"'");
				if (dtCount.Rows.Count > 1)
				{
					throw new Exception("同名部门已存在，请添加新部门！");
				}
                Dept dept = new Dept();
                dept.cnvcDeptID = this.txtDeptID.Text;
                dept.cnvcDeptName = this.txtDeptName.Text;
				dept.cnvcParentDeptID = this.hidParentID.Value;
				dept.cnbValidate = this.chkValidate.Checked;
				Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
				Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 
				BusiLog busiLog = new BusiLog();
				busiLog.cndOperDate = DateTime.Now;
				busiLog.cnnSerial = Guid.NewGuid();
				busiLog.cnvcOperName = curOper.cnvcOperName;
				busiLog.cnvcComments = "修改部门名称为："+this.txtDeptName.Text;
				busiLog.cnvcDeptID = curDept.cnvcDeptID;
				busiLog.cnvcDeptName = curDept.cnvcDeptName;
				busiLog.cnvcOperType = "BS002";
				busiLog.cnvcSource = "网站";

				DeptFacade.UpdateDept(dept,busiLog);
			}
			catch(Exception ex)
			{
				alertControl.Enable=true;
				alertControl.Msg=ex.Message;				
				return false;
			}

			//成功更新部门
			alertControl.Action=AlertControl.ACTION.Script;
			alertControl.Enable=true;
			alertControl.Msg="成功更新部门信息";
			alertControl.Script=string.Format("window.parent.OnChangeNodeResult('{0}','{1}');",
				"dept_"+txtDeptID.Text,txtDeptName.Text);
			return true;
		}


		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			switch(hidMethod.Value)
			{
				case "Add": 
					AddDept();
					break;
				case "Update":
					if(UpdateDept())
						ShowComponents("Show");
					break;
				case "Show":
					ShowComponents("Update");
					break;
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			switch(hidMethod.Value)
			{
				case "Add":
//					Response.Output.WriteLine("<script language=javascript>");
//					Response.Output.WriteLine("window.parent.SelectNodeByID('{0}');","dept_"+hidParentID.Value);
//					Response.Output.WriteLine("</script>");
//					Response.End();
					LoadDept();
					ShowComponents("Show");
					break;
				case "Update":
					LoadDept();
					ShowComponents("Show");
					break;
			}
		}

		private void btnAddDept_Click(object sender, System.EventArgs e)
		{
			hidParentID.Value = txtDeptID.Text; //strParentDept;
			ShowComponents("Add");
		}

		private void btnAddUser_Click(object sender, System.EventArgs e)
		{
			Response.Redirect( "UserProperties.aspx?Method=Add&DeptID=dept_" + txtDeptID.Text );
		}

		private void btnMoveDept_Click(object sender, System.EventArgs e)
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
