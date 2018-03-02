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
	public class wfmMemberList : wfmBase
	{
		#region 字段
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.TextBox txtBeginDate;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtCompanyName;
		protected System.Web.UI.WebControls.TextBox txtLicenseTag;
		protected System.Web.UI.WebControls.TextBox txtCardID;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DropDownList ddlState;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected ynhnOilManage.Interface.Report.ucPageView UcPageView1;
		#endregion 
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			//this.btnExcel.Attributes.Add("onclick","javascript:window.open('DataGridToExcel.aspx', 'Sample', 'toolbar=no,location=no,directories=no,status=yes,menubar=yes,scrollbars=no,resizable=yes,copyhistory=yes,width=790,height=520,left=0,top=0')");
			if (!IsPostBack)
			{
				BindDeptAll(ddlDept);
				BindState(ddlState);
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

		private void BindState(DropDownList ddl)
		{
			DataTable dtState = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign='MemState'");
			ddl.DataSource = dtState;
			ddl.DataTextField = "cnvcCommName";
			ddl.DataValueField = "cnvcCommCode";
			ddl.DataBind();
			ListItem li = new ListItem("所有","%");
			ddl.Items.Insert(0,li);
		}
		private DataTable GetData(string strCompanyName,string strDeptID,string strBeginDate,string strEndDate,string strState,string strLicenseTag,string strCardID)
		{
			string strSql = "select a.cnvcCardId,a.cnvcCompanyName,a.cnvcLicenseTag,a.cnvcGoodsName,a.cnvcGoodsType,a.cnvcDeptName,c.cnvcCommName as cnvcState,b.cnnPrepayFee,a.cndCreateDate,a.cnvcComments from tbMember a left outer join tbMebCompanyPrepay b on a.cnvcCompanyID=b.cnvcCompanyID ";
			strSql += " left outer join tbCommCode c on a.cnvcState=c.cnvcCommCode";
			strSql += " where c.cnvcCommSign='MemState'";
			if (strDeptID != "")
			{
				strSql += " and a.cnvcDeptID like '"+strDeptID+"%'" ;
			}
//			if ( null != Session[ConstValue.LOGIN_DEPT_SESSION])
//			{
//				Dept dept = (Dept)Session[ConstValue.LOGIN_DEPT_SESSION];
//				if (dept.cnvcDeptID != "00")
//				{
//					strSql += " and a.cnvcDeptID ='"+dept.cnvcDeptID+"'";
//				}
//			}
			if (strCompanyName != "")
			{
				strSql += " and a.cnvcCompanyName like '%"+strCompanyName+"%'";
			}
			if (strBeginDate != "")
			{
				strSql += " and convert(char(10),a.cndCreateDate,120)>='"+strBeginDate+"'" ;
			}
			if (strLicenseTag != "")
			{
				strSql += " and a.cnvcLicenseTag ='"+strLicenseTag+"'";
			}
			if (strEndDate != "")
			{
				strSql += " and convert(char(10),a.cndCreateDate,120)<='"+strEndDate+"'";
			}	
			//			if (strState != "" &&strState != "所有")
			//			{				
			strSql += " and a.cnvcState like '"+strState+"'";
			//}
			if (strCardID !="")
			{
				strSql += " and a.cnvcCardID = '"+strCardID+"'";
			}
			strSql += " order by a.cndCreateDate desc"; 
			DataTable dtMember = ReportQueryFacade.CommonQuery(strSql);
			
			//dtMember.Columns["cnnMemberID"].ColumnName = "序号";
			dtMember.Columns["cnvcCardID"].ColumnName = "卡号";
			dtMember.Columns["cnvcCompanyName"].ColumnName = "单位名称";
			dtMember.Columns["cnvcLicenseTag"].ColumnName = "车牌号";
			dtMember.Columns["cnvcGoodsName"].ColumnName = "物料名称";
			dtMember.Columns["cnvcGoodsType"].ColumnName = "物料规格";
			dtMember.Columns["cnvcDeptName"].ColumnName = "指定加油站";
			dtMember.Columns["cnvcState"].ColumnName = "会员状态";
			dtMember.Columns["cnnPrepayFee"].ColumnName = "单位余额";
			dtMember.Columns["cndCreateDate"].ColumnName = "发卡日期";
			dtMember.Columns["cnvcComments"].ColumnName = "备注";

			//			dtMember.Columns.Remove("cnvcDeptID");
			//			dtMember.Columns.Remove("cnvcOperName");
			//			dtMember.Columns.Remove("cndOperDate");
			return dtMember;
		}
		private void BindGrid(string strCompanyName,string strDeptID,string strBeginDate,string strEndDate,string strState,string strLicenseTag,string strCardID)
		{
			
			DataTable dtMember = GetData(strCompanyName,strDeptID,strBeginDate,strEndDate,strState,strLicenseTag,strCardID);
			this.UcPageView1.MyDataSource = dtMember.DefaultView;
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

			BindGrid(txtCompanyName.Text,ddlDept.SelectedValue,this.txtBeginDate.Text,this.txtEndDate.Text,ddlState.SelectedValue,txtLicenseTag.Text,txtCardID.Text);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.txtBeginDate.Text = "";
			this.txtEndDate.Text = "";
			this.txtCompanyName.Text = "";
			this.txtLicenseTag.Text = "";
			UcPageView1.DebindGrid();
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			//导出EXCEL
			//体
			DataTable dtMember = GetData(txtCompanyName.Text,ddlDept.SelectedValue,this.txtBeginDate.Text,this.txtEndDate.Text,ddlState.SelectedValue,txtLicenseTag.Text,txtCardID.Text);
			string strMember = this.ExportTable(dtMember);
			//Session["QUERY"] = dtMember;
			//头
			string strCaption = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strCaption += "<tr><td align=center colspan=10>"+CommonStatic.EnterpriseFullName()+"</td></tr>";
			strCaption += "<tr><td align=center colspan=10>会员清单</td></tr>";
			strCaption += "<tr><td align=center colspan=10>"+DateTime.Now.ToString("yyyy年MM月dd日")+"</td></tr>";
			strCaption += "</table>";
			//Session["ExcelCaption"] = strCaption;
			//脚
			string strBottom = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strBottom += "<tr>";
			strBottom += "<td align=center colspan=3>部门主管：</td>";
			strBottom += "<td align=center colspan=3>审核：</td>";
			strBottom += "<td align=center colspan=4>制表：</td></tr>";
			strBottom += "</table>";
			//Session["ExcelBottom"] = strBottom;
			this.ExportToXls(this,"会员清单",strCaption+strMember+strBottom);
		}
	}
}
