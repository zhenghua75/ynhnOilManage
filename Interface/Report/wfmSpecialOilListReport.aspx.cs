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
	public class wfmSpecialOilListReport : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.TextBox txtBeginDate;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtDeliveryCompany;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtContractNo;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected ynhnOilManage.Interface.Report.ucPageView UcPageView1;
	
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
		private DataTable GetData(string strDeptID,string strDeptName,string strBeginDate,string strEndDate,string strDeliveryCompany,
			string strContractNo,ref string strDeliveryCompanyFact,ref string strContractNoFact)
		{
			string strSql = "select cnvcBillNo,cnvcGoodsName,cnvcGoodsType,cnvcUnit,cnnCount,cnnSpecialUnitPrice,cnnSpecialFee,'' as cnvcComments,cnvcDeliveryCompany,cnvcContractNo,cndDeliveryDate,cnvcOperName,cndOperDate,"
				+ " '{0}FuncName={1}&BillNo='+cnvcBillNo+'&DeptID='+cnvcDeptID+'{2}' as cnvcMod "
				+"  from tbBillOfMaterials where cnvcDeptID like '"+strDeptID+"%'";
			if (strBeginDate != "")
			{
				strSql += " and cndDeliveryDate>='"+strBeginDate+"'" ;
			}
			if (strEndDate != "")
			{
				strSql += " and cndDeliveryDate<='"+strEndDate+"'";
			}
			if (strDeliveryCompany != "")
			{
				strSql += " and cnvcDeliveryCompany like '%"+strDeliveryCompany+"%'";
			}
			if (strContractNo != "")
			{
				strSql += " and cnvcContractNo = '"+strContractNo+"'";
			}
			strSql += " order by cndOperDate desc";
			DataTable dtBillOfMaterials = ReportQueryFacade.CommonQuery(strSql);
			//算合计
			double dCount = 0.00;
			double dFee = 0.00; 
			strDeliveryCompanyFact = "";
			strContractNoFact = "";
			foreach (DataRow drBillOfMaterials in dtBillOfMaterials.Rows)
			{
				dCount += double.Parse(drBillOfMaterials["cnnCount"].ToString());
				dFee += double.Parse(drBillOfMaterials["cnnSpecialFee"].ToString());				
				strDeliveryCompanyFact = drBillOfMaterials["cnvcDeliveryCompany"].ToString();				
				strContractNoFact = drBillOfMaterials["cnvcContractNo"].ToString();				
			}
			DataRow drNew = dtBillOfMaterials.NewRow();
			drNew["cnvcGoodsType"] = "合计";
			drNew["cnnCount"] = Math.Round(dCount,2);
			drNew["cnnSpecialFee"] = Math.Round(dFee,2);
			dtBillOfMaterials.Rows.Add(drNew);
			dtBillOfMaterials.Columns["cnvcBillNo"].ColumnName = "领料单号";
			dtBillOfMaterials.Columns["cnvcGoodsName"].ColumnName = "物资名称";
			dtBillOfMaterials.Columns["cnvcGoodsType"].ColumnName = "规格型号";
			dtBillOfMaterials.Columns["cnvcUnit"].ColumnName = "单位";
			dtBillOfMaterials.Columns["cnnCount"].ColumnName = "供应数量";
			dtBillOfMaterials.Columns["cnnSpecialUnitPrice"].ColumnName = "专供单价（元）";
			dtBillOfMaterials.Columns["cnnSpecialFee"].ColumnName = "专供金额（元）";
			dtBillOfMaterials.Columns["cnvcComments"].ColumnName = "备注";
			dtBillOfMaterials.Columns["cndDeliveryDate"].ColumnName = "提货时间";
			dtBillOfMaterials.Columns["cnvcOperName"].ColumnName = "操作员";
			dtBillOfMaterials.Columns["cndOPerDate"].ColumnName = "操作时间";
			dtBillOfMaterials.Columns["cnvcMod"].ColumnName = "修改";
			dtBillOfMaterials.Columns.Remove("cnvcDeliveryCompany");
			dtBillOfMaterials.Columns.Remove("cnvcContractNo");
			return dtBillOfMaterials;
		}
		private void BindGrid(string strDeptID,string strDeptName,string strBeginDate,string strEndDate,string strDeliveryCompany,string strContractNo)
		{
			string strDeliveryCompanyFact = "";
			string strContractNoFact = "";
			DataTable dtBillOfMaterials = GetData(strDeptID,strDeptName,strBeginDate,strEndDate,strDeliveryCompany,strContractNo,
				ref strDeliveryCompanyFact,ref strContractNoFact);
			foreach(DataRow dr in dtBillOfMaterials.Rows)
			{
				string strmod = dr["修改"].ToString();
				dr["修改"] = string.Format(strmod,"<a href='wfmSpecialOilListMod.aspx?",this.Server.UrlEncode("修改专供油"),"' target='_self'>修改</a>");
			}
			this.UcPageView1.MyDataSource = dtBillOfMaterials.DefaultView;
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

			BindGrid(this.ddlDept.SelectedValue,this.ddlDept.SelectedItem.Text,this.txtBeginDate.Text,this.txtEndDate.Text,this.txtDeliveryCompany.Text,this.txtContractNo.Text);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.txtBeginDate.Text = "";
			this.txtEndDate.Text = "";
			this.txtDeliveryCompany.Text = "";
			this.txtContractNo.Text = "";
			UcPageView1.DebindGrid();
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			//导出EXCEL
			//体
			string strDeliveryCompanyFact = "";
			string strContractNoFact = "";
			DataTable dtBillOfMaterials = GetData(this.ddlDept.SelectedValue,this.ddlDept.SelectedItem.Text,
				this.txtBeginDate.Text,this.txtEndDate.Text,this.txtDeliveryCompany.Text,
				this.txtContractNo.Text,ref strDeliveryCompanyFact,ref strContractNoFact);
			dtBillOfMaterials.Columns.Remove("修改");
			string strBillOfMaterials = this.ExportTable(dtBillOfMaterials);
			//Session["QUERY"] = dtBillOfMaterials;
			//头
			string strCaption = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strCaption += "<tr><td align=center colspan=11>"+CommonStatic.EnterpriseFullName()+"</td></tr>";
			strCaption += "<tr><td align=center colspan=11>"+ddlDept.SelectedItem.Text+"专供柴油销售明细表</td></tr>";
			strCaption += "<tr><td align=center colspan=11>"+DateTime.Now.ToString("yyyy年MM月dd日")+"</td></tr>";
			strCaption += "<tr><td align=left colspan=4>"+"领用单位："+strDeliveryCompanyFact+"</td><td colspan=4>合同编号："+strContractNoFact+"</td><td align=center colspan=2>金额单位：元</td><td></td></tr>";
			strCaption += "</table>";
			//Session["ExcelCaption"] = strCaption;
			//脚
			string strBottom = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strBottom += "<tr><td></td>";
			strBottom += "<td align=center colspan=2>部门主管：</td>";
			strBottom += "<td></td><td></td>";
			strBottom += "<td align=center colspan=2>审核：</td>";
			strBottom += "<td></td><td colspan=2>制表：</td><td></td></tr>";
			strBottom += "<tr><td colspan=11>本表一式四份，物资公司财务一份（附领料单），物资公司业务一份，一份与供货发票一并转领用单位（附领料单），各电站业务留存一份（附领料单）。</td></tr></table>";
			//Session["ExcelBottom"] = strBottom;
			this.ExportToXls(this,ddlDept.SelectedItem.Text+"专供柴油销售明细表",strCaption+strBillOfMaterials+strBottom);
		}
	}
}
