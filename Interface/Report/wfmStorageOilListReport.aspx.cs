#region 引入
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
#endregion
namespace ynhnOilManage.Interface.Report
{
	/// <summary>
	/// wfmRetailOilListReport 的摘要说明。
	/// </summary>
	public class wfmStorageOilListReport : wfmBase//System.Web.UI.Page
	{
		#region 字段
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.TextBox txtBeginDate;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected ynhnOilManage.Interface.Report.ucPageView UcPageView1;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			//this.btnExcel.Attributes.Add("onclick","javascript:window.open('DataGridToExcel.aspx', 'Sample', 'toolbar=no,location=no,directories=no,status=yes,menubar=yes,scrollbars=no,resizable=yes,copyhistory=yes,width=790,height=520,left=0,top=0')");
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
		private DataTable GetData(string strDeptID,string strBeginDate,string strEndDate)
		{
			string strSql = "select '' as cnnSerialNo,cnvcDeptName,cnvcGoodsType+cnvcGoodsName as cnvcNameType,cnnStorageCount,cnnLoseCount,cnnCount,cnvcOperName,cndOperDate from tbOilStorageCheck  where cnvcDeptID like '"+strDeptID+"%'";
			if (strBeginDate != "")
			{
				strSql += " and convert(char(10),cndOperDate,120)>='"+strBeginDate+"'" ;
			}
			if (strEndDate != "")
			{
				strSql += " and convert(char(10),cndOperDate,120)<='"+strEndDate+"'";
			}			
			strSql += " order by cndOperDate desc";
			DataTable dtStorage = ReportQueryFacade.CommonQuery(strSql);
			int i = 0;
			foreach (DataRow drStorage in dtStorage.Rows)
			{				
				i++;
				drStorage["cnnSerialNo"] = i;
			}

			dtStorage.Columns["cnnSerialNo"].ColumnName = "序号";	
			dtStorage.Columns["cnvcDeptName"].ColumnName = "部门名称";
			dtStorage.Columns["cnvcNameType"].ColumnName = "型号规格";
			dtStorage.Columns["cnnStorageCount"].ColumnName = "库存数量";
			dtStorage.Columns["cnnLoseCount"].ColumnName = "损耗数量";
			dtStorage.Columns["cnnCount"].ColumnName = "库存实际数";
			dtStorage.Columns["cnvcOperName"].ColumnName = "操作员";
			dtStorage.Columns["cndOperDate"].ColumnName = "操作时间";
			return dtStorage;
		}
		private void BindGrid(string strDeptID,string strBeginDate,string strEndDate)
		{
			DataTable dtStorage = GetData(strDeptID,strBeginDate,strEndDate);
			this.UcPageView1.MyDataSource = dtStorage.DefaultView;
			this.UcPageView1.BindGrid();
			
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
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{

			BindGrid(this.ddlDept.SelectedValue,this.txtBeginDate.Text,this.txtEndDate.Text);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.txtBeginDate.Text = "";
			this.txtEndDate.Text = "";			
			UcPageView1.DebindGrid();
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			//导出EXCEL
			//体
			DataTable dtStorage = GetData(this.ddlDept.SelectedValue,this.txtBeginDate.Text,this.txtEndDate.Text);
			string strStorage = this.ExportTable(dtStorage);
			//Session["QUERY"] = dtStorage;
			//头
			string strCaption = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strCaption += "<tr><td align=center colspan=8>"+CommonStatic.EnterpriseFullName()+"</td></tr>";
			strCaption += "<tr><td align=center colspan=8>"+ddlDept.SelectedItem.Text+"库存盘点明细表</td></tr>";
			strCaption += "<tr><td align=center colspan=8>"+DateTime.Now.ToString("yyyy年MM月dd日")+"</td></tr>";
			strCaption += "</table>";
			//Session["ExcelCaption"] = strCaption;
			this.ExportToXls(this,ddlDept.SelectedItem.Text+"库存盘点明细表",strCaption+strStorage);
		}
	}
}
