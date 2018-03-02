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
	public class wfmOilValidateListReport : wfmBase
	{
		#region 字段
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlProvideCompany;
		protected System.Web.UI.WebControls.DropDownList ddlDeliveryCompany;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtProvideBeginDate;
		protected System.Web.UI.WebControls.TextBox txtDeliveryBeginDate;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtProvideEndDate;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtDeliveryEndDate;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList ddlGoodsName;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.DropDownList ddlGoodsType;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtBillNo;
		protected ynhnOilManage.Interface.Report.ucPageView UcPageView1;
		#endregion

		#region page_load
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			//this.btnExcel.Attributes.Add("onclick","javascript:window.open('DataGridToExcel.aspx', 'Sample', 'toolbar=no,location=no,directories=no,status=yes,menubar=yes,scrollbars=no,resizable=yes,copyhistory=yes,width=790,height=520,left=0,top=0')");
			if (!IsPostBack)
			{
				//BindDeptAll(ddlProvideCompany);
				BindDept(ddlProvideCompany,"所有","%");
				BindDeptAll(ddlDeliveryCompany);
				UcPageView1.DebindGrid();

				DataTable dtGoodsName = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign='GoodsName'");
				

				ddlGoodsName.DataSource = dtGoodsName;
				ddlGoodsName.DataTextField = "cnvcCommName";
				ddlGoodsName.DataValueField = "cnvcCommCode";
				ddlGoodsName.DataBind();

				ListItem liAll = new ListItem("所有","%");
				ddlGoodsName.Items.Insert(0,liAll);

				if (ddlGoodsName.SelectedItem.Text != "所有")
				{
				
					DataTable dtGoodsType = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign='GoodsType"+ddlGoodsName.SelectedValue+"'");
					ddlGoodsType.DataSource = dtGoodsType;
					ddlGoodsType.DataTextField = "cnvcCommName";
					ddlGoodsType.DataValueField = "cnvcCommCode";
					ddlGoodsType.DataBind();
				}
				else
				{
					DataTable dtGoodsType = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign='GoodsTypeCY' or cnvcCommSign='GoodsTypeQY'");
					ddlGoodsType.DataSource = dtGoodsType;
					ddlGoodsType.DataTextField = "cnvcCommName";
					ddlGoodsType.DataValueField = "cnvcCommCode";
					ddlGoodsType.DataBind();
				}

				//ListItem li = new ListItem("所有","%");
				ddlGoodsType.Items.Insert(0,liAll);

//				if ( null != Session[ConstValue.LOGIN_DEPT_SESSION])
//				{
//					Dept dept = (Dept)Session[ConstValue.LOGIN_DEPT_SESSION];
//					if (dept.cnvcDeptID != "00")
//					{
//						ListItem li = ddlDeliveryCompany.Items.FindByText(dept.cnvcDeptName);
//						ddlDeliveryCompany.SelectedIndex = ddlDeliveryCompany.Items.IndexOf(li);						
//						ddlDeliveryCompany.Enabled = false;
//
////						ListItem li2 = ddlProvideCompany.Items.FindByText(dept.cnvcDeptName);
////						ddlProvideCompany.SelectedIndex = ddlProvideCompany.Items.IndexOf(li2);						
////						ddlProvideCompany.Enabled = false;
//					}
//				}
			}
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

		private DataTable GetData(string strDeliveryCompany,string strProvideCompany,string strDeliveryBeginDate,
			string strDeliveryEndDate,string strProvideBeginDate,string strProvideEndDate,string strGoodsType,
			string strGoodsName,ref string strDeliveryCompanyFact,ref string strProvideCompanyFact,string strBillNo)
		{
			string strSql = " select '' as cnnID,convert(char(10),cndProvideDate,121) as cndProvideDate,convert(char(10),cndDeliveryDate,121) as cndDeliveryDate,cnvcGoodsName+cnvcGoodsType as cnvcNameType,cnvcTransportLicenseTags,cnvcTransportMan, "
				+ " cnnOriginalCount,cnnValidateCount,cnvcBillNo,cnnDistance,cnnTransportLose,cnnLose,cnnQuotaLose, "
				+ " cnnOuterLose,cnvcProvideAddress,cnvcDeliveryCompany,cnvcProvideCompany, "
				+ " '{0}FuncName={1}&BillNo='+cnvcBillNo+'&DeptID='+cnvcDeptID+'{2}' as cnvcMod "
				+"from tbBillOfValidate where 1=1";
						
			if (strDeliveryCompany != "")
			{				
				strSql += " and cnvcDeptID like '"+strDeliveryCompany+"%'";			
			}
			if (strProvideCompany != "")
			{
				strSql += " and cnvcProvideDeptID like '"+strProvideCompany+"%'";			
			}
			if (strDeliveryBeginDate != "")
			{
				strSql += " and cndDeliveryDate >='"+strDeliveryBeginDate+"'";
			}
			if (strDeliveryEndDate != "")
			{
				strSql += " and cndDeliveryDate <='"+strDeliveryEndDate+"'";
			}
			if (strProvideBeginDate != "")
			{
				strSql += " and cndProvideDate >='"+strProvideBeginDate+"'";
			}
			if (strProvideEndDate != "")
			{
				strSql += " and cndProvideDate <='"+strProvideEndDate+"'";
			}
			if (strGoodsName != "")
			{
				strSql += " and cnvcGoodsName like '"+strGoodsName+"'";
			}
			if (strGoodsType != "")
			{
				strSql += " and cnvcGoodsType like '"+strGoodsType+"'";
			}
			if(strBillNo != "")
			{
				strSql += " and cnvcBillNo like '%"+strBillNo+"%'";
			}
			strSql += " order by cndDeliveryDate desc";
			DataTable dtBillOfValidate = ReportQueryFacade.CommonQuery(strSql);
			//算合计
			double dOriginalCount = 0.00;
			double dValidateCount = 0.00;
			double dLose = 0.00;
			double dQuotaLose = 0.00;
			double dOuterLose = 0.00;
			strDeliveryCompanyFact = "";
			strProvideCompanyFact = "";
			int i = 0;
			foreach (DataRow drBillOfValidate in dtBillOfValidate.Rows)
			{
				dOriginalCount += double.Parse(drBillOfValidate["cnnOriginalCount"].ToString());
				dValidateCount += double.Parse(drBillOfValidate["cnnValidateCount"].ToString());
				dLose += double.Parse(drBillOfValidate["cnnLose"].ToString());	
				dQuotaLose += double.Parse(drBillOfValidate["cnnQuotaLose"].ToString());	
				dOuterLose += double.Parse(drBillOfValidate["cnnOuterLose"].ToString());	
				strDeliveryCompanyFact = drBillOfValidate["cnvcDeliveryCompany"].ToString();				
				strProvideCompanyFact = drBillOfValidate["cnvcProvideCompany"].ToString();	
				i++;
				drBillOfValidate["cnnID"] = i;
			}
			DataRow drNew = dtBillOfValidate.NewRow();
			drNew["cnvcTransportMan"] = "合计";
			drNew["cnnOriginalCount"] = dOriginalCount;
			drNew["cnnValidateCount"] = dValidateCount;
			drNew["cnnLose"] = dLose;
			drNew["cnnQuotaLose"] = dQuotaLose;
			drNew["cnnOuterLose"] = dOuterLose;
			dtBillOfValidate.Rows.Add(drNew);
			dtBillOfValidate.Columns["cnnID"].ColumnName = "序号";
			dtBillOfValidate.Columns["cndProvideDate"].ColumnName = "发油日期";
			dtBillOfValidate.Columns["cndDeliveryDate"].ColumnName = "收油日期";
			dtBillOfValidate.Columns["cnvcTransportLicenseTags"].ColumnName = "运输车号";			
			dtBillOfValidate.Columns["cnvcNameType"].ColumnName = "型号规格";
			dtBillOfValidate.Columns["cnvcTransportMan"].ColumnName = "承运人";
			dtBillOfValidate.Columns["cnnOriginalCount"].ColumnName = "原发数";
			dtBillOfValidate.Columns["cnnValidateCount"].ColumnName = "验收数";
			dtBillOfValidate.Columns["cnvcBillNo"].ColumnName = "收油核对单号";
			dtBillOfValidate.Columns["cnnDistance"].ColumnName = "运输公里数";
			dtBillOfValidate.Columns["cnnTransportLose"].ColumnName = "运输损耗定额";
			dtBillOfValidate.Columns["cnnLose"].ColumnName = "实际损耗";
			dtBillOfValidate.Columns["cnnQuotaLose"].ColumnName = "定额内运输损耗";
			dtBillOfValidate.Columns["cnnOuterLose"].ColumnName = "超定额运输损耗";
			dtBillOfValidate.Columns["cnvcProvideAddress"].ColumnName = "发油地点";
			dtBillOfValidate.Columns["cnvcMod"].ColumnName = "修改";
			dtBillOfValidate.Columns.Remove("cnvcDeliveryCompany");
			dtBillOfValidate.Columns.Remove("cnvcProvideCompany");
			return dtBillOfValidate;
		}
		private void BindGrid(string strDeliveryCompany,string strProvideCompany,string strDeliveryBeginDate,string strDeliveryEndDate,
			string strProvideBeginDate,string strProvideEndDate,string strGoodsType,string strGoodsName,string strBillNo)
		{			
			string strDeliveryCompanyFact = "";
			string strProvideCompanyFact = "";
			DataTable dtBillOfValidate = GetData(strDeliveryCompany,strProvideCompany,strDeliveryBeginDate,strDeliveryEndDate,
				strProvideBeginDate,strProvideEndDate,strGoodsType,strGoodsName,
				ref strDeliveryCompanyFact,ref strProvideCompanyFact,strBillNo);
			foreach(DataRow dr in dtBillOfValidate.Rows)
			{
				string strmod = dr["修改"].ToString();
				dr["修改"] = string.Format(strmod,"<a href='wfmOilValidateListMod.aspx?",this.Server.UrlEncode("修改油料验收单"),"' target='_self'>修改</a>");
			}
			this.UcPageView1.MyDataSource = dtBillOfValidate.DefaultView;
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
			this.ddlProvideCompany.SelectedIndexChanged += new System.EventHandler(this.ddlProvideCompany_SelectedIndexChanged);
			this.ddlGoodsName.SelectedIndexChanged += new System.EventHandler(this.ddlGoodsName_SelectedIndexChanged);
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{

			string strGoodsName = ddlGoodsName.SelectedItem.Text;
			if (strGoodsName == "所有")
			{
				strGoodsName = "%";
			}
			BindGrid(this.ddlDeliveryCompany.SelectedValue,this.ddlProvideCompany.SelectedValue,
	this.txtDeliveryBeginDate.Text,this.txtDeliveryEndDate.Text,this.txtProvideBeginDate.Text,
	this.txtProvideEndDate.Text,ddlGoodsType.SelectedValue,strGoodsName,txtBillNo.Text);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.txtDeliveryBeginDate.Text = "";
			this.txtDeliveryEndDate.Text = "";
			this.txtProvideBeginDate.Text = "";
			this.txtProvideEndDate.Text = "";
			UcPageView1.DebindGrid();
		}

		private void ddlProvideCompany_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ddlGoodsName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//ddlGoodsName_SelectedIndexChanged
//			DataTable dtGoodsType = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign='GoodsType"+ddlGoodsName.SelectedValue+"'");
//			ddlGoodsType.DataSource = dtGoodsType;
//			ddlGoodsType.DataTextField = "cnvcCommName";
//			ddlGoodsType.DataValueField = "cnvcCommCode";
//			ddlGoodsType.DataBind();
			ListItem liAll = new ListItem("所有","%");
			//ddlGoodsName.Items.Insert(0,liAll);

			if (ddlGoodsName.SelectedItem.Text != "所有")
			{
				
				DataTable dtGoodsType = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign='GoodsType"+ddlGoodsName.SelectedValue+"'");
				ddlGoodsType.DataSource = dtGoodsType;
				ddlGoodsType.DataTextField = "cnvcCommName";
				ddlGoodsType.DataValueField = "cnvcCommCode";
				ddlGoodsType.DataBind();
			}
			else
			{
				DataTable dtGoodsType = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign='GoodsTypeCY' or cnvcCommSign='GoodsTypeQY'");
				ddlGoodsType.DataSource = dtGoodsType;
				ddlGoodsType.DataTextField = "cnvcCommName";
				ddlGoodsType.DataValueField = "cnvcCommCode";
				ddlGoodsType.DataBind();
			}

			//ListItem li = new ListItem("所有","%");
			ddlGoodsType.Items.Insert(0,liAll);

		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			//导出EXCEL
			//体
			string strGoodsName = ddlGoodsName.SelectedItem.Text;
			if (strGoodsName == "所有")
			{
				strGoodsName = "%";
			}
			string strDeliveryCompanyFact = "";
			string strProvideCompanyFact = "";
			DataTable dtBillOfValidate = GetData(this.ddlDeliveryCompany.SelectedValue,this.ddlProvideCompany.SelectedValue,
				this.txtDeliveryBeginDate.Text,this.txtDeliveryEndDate.Text,this.txtProvideBeginDate.Text,this.txtProvideEndDate.Text,
				ddlGoodsType.SelectedValue,strGoodsName,ref strDeliveryCompanyFact,ref strProvideCompanyFact,txtBillNo.Text);	
			dtBillOfValidate.Columns.Remove("修改");
			//Session["QUERY"] = dtBillOfValidate;
			string strBillOfValidate = this.ExportTable(dtBillOfValidate);
			//头
			string strCaption = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strCaption += "<tr><td align=center colspan=15>"+CommonStatic.EnterpriseFullName()+"</td></tr>";
			strCaption += "<tr><td align=center colspan=15>油料验收明细</td></tr>";			
			strCaption += "<tr><td align=left colspan=5>"+"供油单位："+strProvideCompanyFact+"</td><td></td><td colspan=5>收油单位："
				+strDeliveryCompanyFact+"</td><td></td><td colspan=2></td><td align=center>单位：kg</td></tr>";
			strCaption += "</table>";
			//Session["ExcelCaption"] = strCaption;
			//脚
			string strBottom = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strBottom += "<tr><td colspan=15 rospan=4>公里运输损耗的计算：公路运输定额损耗按《中石化成品油计量管理标准》规定执行，即GB11085-89之规定：50公里以下损耗为0.01％；运距每增加50公里，损耗增加0.01；不足50公里按50公里计算。甲方按乙方起运油库至糯扎渡中心油库运距，承担定额运输损耗；超出定额损耗部分由乙方承运人与甲方收货人双方签字确认，按思茅市翠云区中石化加油站挂牌零售价由甲方从乙方结算运费中扣抵。</td></tr></table>";
			//			strBottom += "<td align=center>部门主管：</td>";
			//			strBottom += "<td></td><td></td>";
			//			strBottom += "<td align=center>审核：</td>";
			//			strBottom += "<td></td><td>制表：</td><td></td></tr>";
			//			strBottom += "<tr><td colspan=8>本表一式四份，物资公司财务一份（附领料单），物资公司业务一份，一份与供货发票一并转领用单位（附领料单），各电站业务留存一份（附领料单）。</td></tr></table>";
			//Session["ExcelBottom"] = strBottom;
			this.ExportToXls(this,"油料验收明细",strCaption+strBillOfValidate+strBottom);
		}
	}
}
