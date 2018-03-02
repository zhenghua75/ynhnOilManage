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

using ynhnOilManage.BusinessFacade.SysManage;
using ynhnOilManage.BusinessFacade.Report;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.Common;

namespace ynhnOilManage.Interface.SysManage
{
	/// <summary>
	/// Summary description for wfmAuthorization.
	/// 权限修改
	/// </summary>
	public class wfmAuthorization : wfmBase
	{
		protected System.Web.UI.WebControls.RadioButtonList rblOper;
		protected System.Web.UI.WebControls.ImageButton btnOK;
		protected System.Web.UI.WebControls.ImageButton btnCancel;
		protected System.Web.UI.WebControls.CheckBoxList cblCSFunctionList;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.CheckBoxList cblFunctionList;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				//初始化操作员列表
				//FillOperRbl();
				BindDeptAll(ddlDept);
				FillFunctionCbl();
				ddlDept_SelectedIndexChanged(null,null);

			}
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
			this.ddlDept.SelectedIndexChanged += new System.EventHandler(this.ddlDept_SelectedIndexChanged);
			this.rblOper.SelectedIndexChanged += new System.EventHandler(this.rblOper_SelectedIndexChanged);
			this.btnOK.Click += new System.Web.UI.ImageClickEventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.Web.UI.ImageClickEventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

//		private void BindDept(DropDownList ddl)
//		{
//			DataTable dtDept = DeptFacade.GetAllDept();
//			ddl.DataSource = dtDept;
//			ddl.DataTextField = "cnvcDeptName";
//			ddl.DataValueField = "cnvcDeptID";
//			ddl.DataBind();
//			ListItem li = new ListItem("所有","%");
//			ddl.Items.Insert(0,li);
//		}
		private void rblOper_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				//更新功能类别
				//清楚已选择的功能
				foreach (ListItem liFunctionList in this.cblFunctionList.Items)
				{
					if (liFunctionList.Selected)
					{
						liFunctionList.Selected = false;
					}
				}
				foreach (ListItem liFunctionList in this.cblCSFunctionList.Items)
				{
					if (liFunctionList.Selected)
					{
						liFunctionList.Selected = false;
					}
				}
				//选择的操作员
				string strOperID = this.rblOper.SelectedValue;
				//查询某操作员已具有的功能
				DataTable dtOperFunc = OperFacade.GetOneOperFuncList(strOperID);

				foreach (ListItem liFunctionList in this.cblFunctionList.Items)
				{					
					foreach (DataRow drOperFunc in dtOperFunc.Rows)
					{
						if (drOperFunc["cnvcFuncName"].ToString().Equals(liFunctionList.Text))
						{
							liFunctionList.Selected = true;
						}
					}
				}

				foreach (ListItem liFunctionList in this.cblCSFunctionList.Items)
				{					
					foreach (DataRow drOperFunc in dtOperFunc.Rows)
					{
						if (drOperFunc["cnvcFuncName"].ToString().Equals(liFunctionList.Text))
						{
							liFunctionList.Selected = true;
						}
					}
				}
			}
			catch (BusinessException bex)
			{
				Popup(bex.Message);
			}
			

		}

		private void FillOperRbl(string strDeptID)
		{			
			try
			{
				//DataTable dtAllOper = OperFacade.GetAllOperNoAdmin();
				DataTable dtOper = ReportQueryFacade.CommonQuery("select * from tbOper where cnvcOperName <>'admin' and cnvcDeptID like '"+strDeptID+"%' order by cnvcOperName");
				rblOper.DataSource = dtOper;
				rblOper.DataTextField = "cnvcOperName";
				rblOper.DataValueField = "cnnOperID";

				rblOper.DataBind();
			}
			catch (BusinessException bex)
			{
				Popup(bex.Message);
			}
			
		}

		private void FillFunctionCbl()
		{
			try
			{
				DataTable dtBSFunction = ReportQueryFacade.CommonQuery("select * from tbFunc where cnvcFuncType='BS' order by cnvcFuncName");
				DataTable dtCSFunction = ReportQueryFacade.CommonQuery("select * from tbFunc where cnvcFuncType='CS' order by cnvcFuncName");

				cblFunctionList.DataSource = dtBSFunction;
				cblFunctionList.DataTextField = "cnvcFuncName";
				cblFunctionList.DataValueField = "cnvcFuncAddress";		

				cblFunctionList.DataBind();

				cblCSFunctionList.DataSource = dtCSFunction;
				cblCSFunctionList.DataTextField = "cnvcFuncName";
				cblCSFunctionList.DataValueField = "cnvcFuncAddress";		

				cblCSFunctionList.DataBind();
			}
			catch (BusinessException bex)
			{
				Popup(bex.Message);
			}
			
		}

		private void btnCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//初始化操作员和功能列表
			foreach (ListItem liOper in rblOper.Items)
			{
				liOper.Selected = false;
			}
			foreach (ListItem liFunctionList in cblFunctionList.Items)
			{
				liFunctionList.Selected = false;
			}
			foreach (ListItem liFunctionList in cblCSFunctionList.Items)
			{
				liFunctionList.Selected = false;
			}
		}

		private void btnOK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				//更新功能列表
				if (rblOper.SelectedValue == "")
				{
					throw new BusinessException("tbOper","请选择操作员！");
				}
				string strOperID = rblOper.SelectedValue;
				//查询某操作员已具有的功能
				DataTable dtHaveOperFunc = OperFacade.GetOneOperFuncList(strOperID);

				Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
				Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 
				BusiLog busiLog = new BusiLog();
				busiLog.cndOperDate = DateTime.Now;
				
				busiLog.cnvcOperName = curOper.cnvcOperName;
				
				busiLog.cnvcDeptID = curDept.cnvcDeptID;
				busiLog.cnvcDeptName = curDept.cnvcDeptName;
				
				busiLog.cnvcSource = "网站";

				foreach (ListItem liOperFunc in cblFunctionList.Items)
				{
					if (liOperFunc.Selected)
					{
						OperFunc operFunc = new OperFunc();							
						operFunc.cnnOperID = int.Parse(strOperID);
						operFunc.cnvcFuncName = liOperFunc.Text;
						operFunc.cnvcFuncAddress = liOperFunc.Value;

						bool bIsAdd = true;

						if (dtHaveOperFunc.Rows.Count > 0)
						{
							foreach (DataRow drHaveOperFunc in dtHaveOperFunc.Rows)
							{
								//已有的不做操作
								if (drHaveOperFunc["cnvcFuncName"].ToString().Equals(liOperFunc.Text))
								{
									bIsAdd = false;
							
								}
							}
						}
						if(bIsAdd)
						{
							busiLog.cnnSerial = Guid.NewGuid();
							busiLog.cnvcComments = "添加权限："+operFunc.cnvcFuncName;
							busiLog.cnvcOperType = "BS009";
							OperFacade.AddOperFunc(operFunc,busiLog);
						}										
					}
					else
					{
						//已有的取消了的删除
						foreach (DataRow drHaveOperFunc in dtHaveOperFunc.Rows)
						{
							if (dtHaveOperFunc.Rows.Count > 0)
							{
								if (drHaveOperFunc["cnvcFuncName"].ToString().Equals(liOperFunc.Text))
								{
									OperFunc operFunc = new OperFunc();							
									operFunc.cnnOperID = int.Parse(strOperID);
									operFunc.cnvcFuncName = liOperFunc.Text;
									operFunc.cnvcFuncAddress = liOperFunc.Value;
							
									busiLog.cnnSerial = Guid.NewGuid();
									busiLog.cnvcComments = "删除权限权限："+operFunc.cnvcFuncName;
									busiLog.cnvcOperType = "BS010";
									OperFacade.DeleteOperFunc(operFunc,busiLog);
								}
							}
							
						}
					}
				}

				foreach (ListItem liOperFunc in cblCSFunctionList.Items)
				{
					if (liOperFunc.Selected)
					{
						OperFunc operFunc = new OperFunc();							
						operFunc.cnnOperID = int.Parse(strOperID);
						operFunc.cnvcFuncName = liOperFunc.Text;
						operFunc.cnvcFuncAddress = liOperFunc.Value;

						bool bIsAdd = true;

						if (dtHaveOperFunc.Rows.Count > 0)
						{
							foreach (DataRow drHaveOperFunc in dtHaveOperFunc.Rows)
							{
								//已有的不做操作
								if (drHaveOperFunc["cnvcFuncName"].ToString().Equals(liOperFunc.Text))
								{
									bIsAdd = false;
							
								}
							}
						}
						if(bIsAdd)
						{
							busiLog.cnnSerial = Guid.NewGuid();
							busiLog.cnvcComments = "添加权限："+operFunc.cnvcFuncName;
							busiLog.cnvcOperType = "BS009";
							OperFacade.AddOperFunc(operFunc,busiLog);
						}										
					}
					else
					{
						//已有的取消了的删除
						foreach (DataRow drHaveOperFunc in dtHaveOperFunc.Rows)
						{
							if (dtHaveOperFunc.Rows.Count > 0)
							{
								if (drHaveOperFunc["cnvcFuncName"].ToString().Equals(liOperFunc.Text))
								{
									OperFunc operFunc = new OperFunc();							
									operFunc.cnnOperID = int.Parse(strOperID);
									operFunc.cnvcFuncName = liOperFunc.Text;
									operFunc.cnvcFuncAddress = liOperFunc.Value;
							
									busiLog.cnnSerial = Guid.NewGuid();
									busiLog.cnvcComments = "删除权限权限："+operFunc.cnvcFuncName;
									busiLog.cnvcOperType = "BS010";
									OperFacade.DeleteOperFunc(operFunc,busiLog);
								}
							}
							
						}
					}
				}
				Popup("权限修改成功！");
			}
			catch (BusinessException bex)
			{
				Popup(bex.Message);
			}
			
			
		}

		private void ddlDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//刷新
			FillOperRbl(ddlDept.SelectedValue);
		}

	}
}
