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
using System.Text;
using ynhnOilManage.Common;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.BusinessFacade.SysManage;
namespace ynhnOilManage.Interface.SysManage
{
	/// <summary>
	/// Summary description for DeptDialog.
	/// </summary>
	public class DeptDialog : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidSrcID;
		protected Microsoft.Web.UI.WebControls.TreeView tv;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidDestID;
		protected ynhnOilManage.Interface.SysManage.AlertControl alertControl;

		protected void Close(string strAlertMsg)
		{
			Close(null,strAlertMsg);
		}
		protected void Close(string strScript,string strAlertMsg)
		{
			Response.Output.WriteLine("<script language=javascript>");
			if(strScript!=null)
				Response.Output.WriteLine(strScript);
			if(strAlertMsg != null)
				Response.Output.WriteLine("alert('{0}');",strAlertMsg);
			Response.Output.WriteLine("window.opener = null");
			Response.Output.WriteLine("window.close();");
			Response.Output.WriteLine("</script>");
			Response.End();
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				DefaultControl.FillTree(tv,false);
				if(Request["SrcID"] == null)
					Close(null);
				hidSrcID.Value=Request["SrcID"];
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
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			string[] strDests = hidDestID.Value.Split('_');
			string[] strSrcs = hidSrcID.Value.Split('_');
			if(strSrcs.Length<2||strDests.Length<2) return;
			switch(strSrcs[0])
			{
				case "oper":
				{
					bool bRet=false;
					try
					{
                        Oper oper = new Oper();
                        oper.cnnOperID = int.Parse(strSrcs[1]);
                        oper.cnvcDeptID = strDests[1];

						Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
						Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 
						BusiLog busiLog = new BusiLog();
						busiLog.cndOperDate = DateTime.Now;
						busiLog.cnnSerial = Guid.NewGuid();
						busiLog.cnvcOperName = curOper.cnvcOperName;
						busiLog.cnvcComments = "移动操作员："+oper.cnnOperID;
						busiLog.cnvcDeptID = curDept.cnvcDeptID;
						busiLog.cnvcDeptName = curDept.cnvcDeptName;
						busiLog.cnvcOperType = "BS008";
						busiLog.cnvcSource = "网站";

						OperFacade.UpdatePwd(oper,busiLog);
						bRet=true;
					}
					catch(Exception ex)
					{
						alertControl.Enable=true;
						alertControl.Msg=ex.Message;
					}
					if(bRet)
					{
						string strScript = string.Format("window.dialogArguments.src='{0}';window.dialogArguments.dest='{1}';",
							hidSrcID.Value,hidDestID.Value);
						Close(strScript,"成功移动用户");
					}
					break;
				}
				case "dept":
				{
					bool bRet=false;
					try
					{
                        Dept dept = new Dept();
                        dept.cnvcDeptID = strSrcs[1];
                        dept.cnvcParentDeptID = strDests[1];

						Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
						Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 
						BusiLog busiLog = new BusiLog();
						busiLog.cndOperDate = DateTime.Now;
						busiLog.cnnSerial = Guid.NewGuid();
						busiLog.cnvcOperName = curOper.cnvcOperName;
						busiLog.cnvcComments = "移动部门："+dept.cnvcDeptID;
						busiLog.cnvcDeptID = curDept.cnvcDeptID;
						busiLog.cnvcDeptName = curDept.cnvcDeptName;
						busiLog.cnvcOperType = "BS003";
						busiLog.cnvcSource = "网站";

						DeptFacade.UpdateDept(dept,busiLog);
						bRet=true;
					}
					catch(Exception ex)
					{
						alertControl.Enable=true;
						alertControl.Msg=ex.Message;
					}
					if(bRet)
					{
						string strScript = string.Format("window.dialogArguments.src='{0}';window.dialogArguments.dest='{1}';",
							hidSrcID.Value,hidDestID.Value);
						Close(strScript,"成功移动部门");
					}
					break;
				}
			}
		}
	}
}
