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
using ynhnOilManage.BusinessFacade.Report;
using ynhnOilManage.BusinessFacade.SysManage;
using ynhnOilManage.EntityObject.EntityBase;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.Common;
namespace ynhnOilManage.Interface.SysManage
{
	/// <summary>
	/// wfmOperList 的摘要说明。
	/// </summary>
	public class wfmOperList : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtOperName;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.DropDownList ddlValidate;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected ynhnOilManage.Interface.Report.ucPageView UcPageView1;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if (!IsPostBack)
			{
				BindDeptAll(ddlDept);
				UcPageView1.DebindGrid();

//				if ( null != Session[ConstValue.LOGIN_DEPT_SESSION])
//				{
//					Dept dept = (Dept)Session[ConstValue.LOGIN_DEPT_SESSION];
//					if (dept.cnvcDeptID != "00")
//					{
//						ListItem li = ddlDept.Items.FindByText(dept.cnvcDeptName);
//						ddlDept.SelectedIndex = ddlDept.Items.IndexOf(li);						
//						ddlDept.Enabled = false;
//					}
//				}
			}
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{			

			BindGrid(this.ddlDept.SelectedValue,this.txtOperName.Text,this.ddlValidate.SelectedValue);

		}
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
		private DataTable GetData(string strDeptID,string strOperName,string strValidate)
		{
			string strsql = "select a.cnnOperID,a.cnvcOperName,a.cnvcDeptID,b.cnvcDeptName,case when a.cnbValidate=1 then '有效' when a.cnbValidate=0 then '无效' end as cnbValidate from tbOper a "
+" left join tbDept b on a.cnvcDeptID=b.cnvcDeptID "
+" where a.cnvcOperName like '%"+strOperName+"%' "
+" and a.cnvcDeptID like '%"+strDeptID+"%'"; 
			if(strValidate != "所有")
				strsql += " and a.cnbValidate="+strValidate;
			DataTable dt = ReportQueryFacade.CommonQuery(strsql);
			dt.Columns["cnnOperID"].ColumnName = "操作员ID";
			dt.Columns["cnvcOperName"].ColumnName = "操作员姓名";
			dt.Columns["cnvcDeptID"].ColumnName = "部门ID";
			dt.Columns["cnvcDeptName"].ColumnName = "部门名称";
			dt.Columns["cnbValidate"].ColumnName = "是否有效";
			return dt;
		}

		private void BindGrid(string strDeptID,string strOperName,string strValidate)
		{
			DataTable dt = this.GetData(strDeptID,strOperName,strValidate);
			this.UcPageView1.MyDataSource = dt.DefaultView;
			this.UcPageView1.BindGrid();			
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			//体
			string str = this.ExportTable(GetData(this.ddlDept.SelectedValue,this.txtOperName.Text,this.ddlValidate.SelectedValue));
			this.ExportToXls(this,"操作员列表",str);
		}
	}
}
