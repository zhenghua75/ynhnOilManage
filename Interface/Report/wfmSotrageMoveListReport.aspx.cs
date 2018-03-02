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
	public class wfmSotrageMoveListReport : wfmBase
	{
		#region 字段
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.TextBox txtBeginDate;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.DropDownList ddlProvideCompany;
		protected System.Web.UI.WebControls.DropDownList ddlDeliveryCompany;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.Label Label3;
		protected ynhnOilManage.Interface.Report.ucPageView UcPageView1;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			//this.btnExcel.Attributes.Add("onclick","javascript:window.open('DataGridToExcel.aspx', 'Sample', 'toolbar=no,location=no,directories=no,status=yes,menubar=yes,scrollbars=no,resizable=yes,copyhistory=yes,width=790,height=520,left=0,top=0')");
			if (!IsPostBack)
			{
				//BindDeptAll(ddlDeliveryCompany);
				//BindDeptAll(ddlProvideCompany);
				BindDept(ddlDeliveryCompany,"所有","%");
				BindDept(ddlProvideCompany,"所有","%");
				UcPageView1.DebindGrid();

//				if ( null != Session[ConstValue.LOGIN_DEPT_SESSION])
//				{
//					Dept dept = (Dept)Session[ConstValue.LOGIN_DEPT_SESSION];
//					if (dept.cnvcDeptID != "00")
//					{
////						ListItem li = ddlDeliveryCompany.Items.FindByText(dept.cnvcDeptName);
////						ddlDeliveryCompany.SelectedIndex = ddlDeliveryCompany.Items.IndexOf(li);						
////						ddlDeliveryCompany.Enabled = false;
//
//						ListItem li2 = ddlProvideCompany.Items.FindByText(dept.cnvcDeptName);
//						ddlProvideCompany.SelectedIndex = ddlProvideCompany.Items.IndexOf(li2);						
//						ddlProvideCompany.Enabled = false;
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
		private DataTable GetData(string strDeliveryCompany,string strProvideCompany,string strBeginDate,string strEndDate)
		{
			//string strSql = "select '' as cnnID,cnvcDeliveryCompany,cnvcContractNo,cnvcGoodsName,cnvcGoodsType,cnvcUnit,sum(cnnCount) as cnnCount,cnnSpecialUnitPrice,sum(cnnSpecialFee) as cnnSpecialFee,'' as cnvcComments  from tbBillOfMaterials  where cnvcProvideCompany = '"+strDeptName+"'";
			string strSql = " select '' as cnnID,'调拨' as cnvcProvideType,a.cnvcProvideStroage,a.cnvcDeliveryCompany,a.cnvcUnit,a.cnvcGoodsName+a.cnvcGoodsType as cnvcNameType,a.cnnReceivableCount,a.cnnCount,a.cnvcTransportLiscenseTags,a.cnvcMoveNo,a.cnvcOperName,a.cndOperDate,a.cnvcComments,  "
				+ " '{0}FuncName={1}&BillNo='+a.cnvcBillNo+'&DeptID='+a.cnvcDeptID+'{2}' as cnvcMod "
				+ " from tbBillOfOutStorage a "
				//+ " join  tbBillOfValidate b on a.cnvcBillNo=b.cnvcOutNo "
				+ " where a.cnvcOutType='调拨出库'";// and b.cnvcInType = '调拨入库' ";



			if (strDeliveryCompany != "" )
			{
				strSql += " and a.cnvcDeliveryDeptID like '"+strDeliveryCompany+"%'" ;
			}
			if (strProvideCompany != "" )
			{
				strSql += " and a.cnvcDeptID like '"+strProvideCompany+"%'" ;
			}
			if (strBeginDate != "")
			{
				strSql += " and a.cndOutStorageDate>='"+strBeginDate+"'" ;
			}
			if (strEndDate != "")
			{
				strSql += " and a.cndOutStorageDate<='"+strEndDate+"'";
			}
			strSql += " order by cndOperDate desc";
			DataTable dtBillOfMove = ReportQueryFacade.CommonQuery(strSql);
			//算合计
			double dReceivableCount = 0.00;
			double dCount = 0.00; 
			int i = 0;
			foreach (DataRow drBillOfMove in dtBillOfMove.Rows)
			{
				dReceivableCount += double.Parse(drBillOfMove["cnnReceivableCount"].ToString());
				dCount += double.Parse(drBillOfMove["cnnCount"].ToString());		
				i++;
				drBillOfMove["cnnID"] = i;
			}
			DataRow drNew = dtBillOfMove.NewRow();
			drNew["cnvcProvideStroage"] = "汇总";
			drNew["cnnReceivableCount"] = dReceivableCount;
			drNew["cnnCount"] = dCount;
			dtBillOfMove.Rows.Add(drNew);
			dtBillOfMove.Columns["cnnID"].ColumnName = "序号";
			dtBillOfMove.Columns["cnvcProvideType"].ColumnName = "供应方式";
			dtBillOfMove.Columns["cnvcProvideStroage"].ColumnName = "调出油库";
			dtBillOfMove.Columns["cnvcDeliveryCompany"].ColumnName = "调入油库";
			dtBillOfMove.Columns["cnvcUnit"].ColumnName = "单位";			
			dtBillOfMove.Columns["cnnReceivableCount"].ColumnName = "通知调拨数量";
			dtBillOfMove.Columns["cnnCount"].ColumnName = "实际调出数量";
			dtBillOfMove.Columns["cnvcTransportLiscenseTags"].ColumnName = "运输车辆车牌号";
			dtBillOfMove.Columns["cnvcMoveNo"].ColumnName = "《柴油调拨通知单》号";
			dtBillOfMove.Columns["cnvcOperName"].ColumnName = "操作员";
			dtBillOfMove.Columns["cndOperDate"].ColumnName = "操作时间";
			dtBillOfMove.Columns["cnvcComments"].ColumnName = "备注";
			dtBillOfMove.Columns["cnvcNameType"].ColumnName = "型号规格";
			dtBillOfMove.Columns["cnvcMod"].ColumnName = "修改";
			return dtBillOfMove;
		}
		private void BindGrid(string strDeliveryCompany,string strProvideCompany,string strBeginDate,string strEndDate)
		{
			
			DataTable dtBillOfMove = GetData(strDeliveryCompany,strProvideCompany,strBeginDate,strEndDate);
			foreach(DataRow dr in dtBillOfMove.Rows)
			{
				string strmod = dr["修改"].ToString();
				dr["修改"] = string.Format(strmod,"<a href='wfmSotrageMoveListMod.aspx?",this.Server.UrlEncode("修改调拨单"),"' target='_self'>修改</a>");
			}

			this.UcPageView1.MyDataSource = dtBillOfMove.DefaultView;
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

			BindGrid(this.ddlDeliveryCompany.SelectedValue,this.ddlProvideCompany.SelectedValue,this.txtBeginDate.Text,this.txtEndDate.Text);
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
			DataTable dtBillOfMove = this.GetData(this.ddlDeliveryCompany.SelectedValue,this.ddlProvideCompany.SelectedValue,this.txtBeginDate.Text,this.txtEndDate.Text);
			dtBillOfMove.Columns.Remove("修改");
			string strBillOfMove = this.ExportTable(dtBillOfMove);
			//Session["QUERY"] = dtBillOfMove;

			//头
			string strCaption = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strCaption += "<tr><td align=center colspan=13>"+CommonStatic.EnterpriseFullName()+"</td></tr>";
			strCaption += "<tr><td align=center colspan=13>储备库柴油调拨明细报表</td></tr>";
			strCaption += "<tr><td align=left colspan=13>填报单位：</td></tr>";			
			strCaption += "</table>";
			//Session["ExcelCaption"] = strCaption;
			//脚
			string strBottom = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strBottom += "<tr>";
			strBottom += "<td align=center colspan=3>单位主管：</td>";
			strBottom += "<td></td>";
			strBottom += "<td colspan=3>业务主管：</td>";
			strBottom += "<td align=center colspan=3>审核：</td>";
			strBottom += "<td colspan=3>制表：</td></tr>";
			
			strBottom += "<tr><td colspan=13 align=right>编制日期："+DateTime.Now.ToString("yyyy年MM月dd日")+"</td></tr></table>";
			//Session["ExcelBottom"] = strBottom;
			this.ExportToXls(this,"储备库柴油调拨明细报表",strCaption+strBillOfMove+strBottom);
		}
	}
}
