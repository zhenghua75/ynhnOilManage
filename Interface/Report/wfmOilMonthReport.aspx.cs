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
	public class wfmOilMonthReport : wfmBase
	{
		#region 字段
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnExcel;
		//protected System.Web.UI.WebControls.TextBox txtBeginDate;
		protected System.Web.UI.WebControls.Label Label3;
		//protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.Label Label4;
		//protected System.Web.UI.WebControls.TextBox txtBeforeBeginDate;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtBeginDate;
		//protected System.Web.UI.WebControls.TextBox txtBeforeEndDate;
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
		private DataTable GetData(string strDeptID,string strDeptName,string strDate)
		{

			string strGoodsType = @"select b.cnvcCommName as cnvcGoodsType,'' as cnvcGoodsName,b.cnvcCommName+a.cnvcCommName as cnvcNameType
,'' as cnnBeforeMonthCurCount,'' as cnnCurMonthInCount,'' as cnnCurMonthOutCount, 
				 '' as cnnStorageLose, '' as cnnQuotaLose,'' as cnnOuterLose,'' as cnnLose,'' as cnnCurMonthCurCount 
 from 
(select cnvcCommName,'GoodsType'+cnvcCommCode as cnvcCommCOde from tbCommCode where cnvcCommSign='GoodsName') a
join
(select cnvcCommName,cnvcCommSign from tbcommCode where cnvcCommSign='GoodsTypeCY' or cnvcCommSign='GoodsTypeQY') b
on a.cnvcCommCOde=b.cnvcCommSign";

//			string strGoodsType = "select cnvcCommcode as cnvcGoodsType,'' as cnvcGoodsName,'' as cnvcNameType,'' as cnnBeforeMonthCurCount,'' as cnnCurMonthInCount,'' as cnnCurMonthOutCount, "
//				+ " '' as cnnStorageLose, '' as cnnQuotaLose,'' as cnnOuterLose,'' as cnnLose,'' as cnnCurMonthCurCount "
//				+ " from tbcommCode where cnvcCommSign='GoodsTypeCY' or cnvcCommSign='GoodsTypeQY' order by cnvcCommCode";
			DataTable dtGoodsType = ReportQueryFacade.CommonQuery(strGoodsType);
			//结存			
			//			DateTime dtCur = DateTime.Parse(strBeginDate);
			//			DateTime dtBefore = dtCur.AddMonths(-1);
			//			string strBefore = dtBefore.ToString("yyyy-MM-dd");
            
			//罗修改2010-07-22
			string strBeginDate="";
			string strEndDate="";
			string strBeforeBeginDate="";
			string strBeforeEndDate="";

			DateTime dtDate =  DateTime.Parse(strDate);
			if (int.Parse(dtDate.Day.ToString())>20)
			{
				strBeginDate = dtDate.ToString("yyyy-MM")+"-21";
				strEndDate = dtDate.AddMonths(+1).ToString("yyyy-MM")+"-21";
				strBeforeBeginDate = dtDate.AddMonths(-1).ToString("yyyy-MM")+"-21";;
				strBeforeEndDate = dtDate.ToString("yyyy-MM")+"-21";;
			}
			else
			{
				strBeginDate = dtDate.AddMonths(-1).ToString("yyyy-MM")+"-21";
				strEndDate = dtDate.ToString("yyyy-MM")+"-21";
				strBeforeBeginDate = dtDate.AddMonths(-2).ToString("yyyy-MM")+"-21";;
				strBeforeEndDate = dtDate.AddMonths(-1).ToString("yyyy-MM")+"-21";;
			}
//			strBeginDate = dtDate.AddMonths(-1).ToString("yyyy-MM")+"-21";
//			strEndDate = dtDate.ToString("yyyy-MM")+"-21";
//			strBeforeBeginDate = dtDate.AddMonths(-2).ToString("yyyy-MM")+"-21";;
//			strBeforeEndDate = dtDate.AddMonths(-1).ToString("yyyy-MM")+"-21";;
			foreach (DataRow drGoodsType in dtGoodsType.Rows)
			{
				//上月结存
				//string strBeforeMonth = "select top 1 cnnCurCount from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and convert(char(7),cndOperDate,121) = '"+strBefore+"' and cnvcDeptID like '"+strDeptID+"%' order by cndOperDate desc ";
				//string strBeforeMonth = "select top 1 cnnCurCount from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeforeBeginDate+"' and cndOperDate < '"+strBeforeEndDate+"'  and cnvcDeptID like '"+strDeptID+"%' order by cndOperDate desc ";
				string strBeforeMonth = "select sum(cnnCurCount) as cnnCurCount from tbOilStorageLog a where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeforeBeginDate+"' and cndOperDate < '"+strBeforeEndDate+"'  and cnvcDeptID like '"+strDeptID+"%' "
							+" and a.cndOperDate=(select max(cndOperDate) from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeforeBeginDate+"' and cndOperDate < '"+strBeforeEndDate+"'  and cnvcDeptID=a.cnvcDeptID) ";
				DataTable dtBeforeMonth =  ReportQueryFacade.CommonQuery(strBeforeMonth);
				//本月结存
				//string strCurMonth = "select top 1 cnnCurCount from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and convert(char(7),cndOperDate,121) = '"+strBeginDate.Substring(0,7)+"' and cnvcDeptID like '"+strDeptID+"%' order by cndOperDate desc ";
				//string strCurMonth = "select top 1 cnnCurCount from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeginDate+"' and cndOperDate < '"+strEndDate+"'  and cnvcDeptID like '"+strDeptID+"%' order by cndOperDate desc ";
				string strCurMonth = "select sum(cnnCurCount) as cnnCurCount from tbOilStorageLog a where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeginDate+"' and cndOperDate < '"+strEndDate+"'  and cnvcDeptID like '"+strDeptID+"%' "+
							" and a.cndOperDate=(select max(cndOperDate) from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeginDate+"' and cndOperDate < '"+strEndDate+"'  and cnvcDeptID=a.cnvcDeptID) ";
				DataTable dtCurMonth =  ReportQueryFacade.CommonQuery(strCurMonth);
				
				if (dtBeforeMonth.Rows.Count > 0)
				{
					drGoodsType["cnnBeforeMonthCurCount"] = dtBeforeMonth.Rows[0][0];
				}
				if (dtCurMonth.Rows.Count > 0)
				{
					drGoodsType["cnnCurMonthCurCount"] = dtCurMonth.Rows[0][0];
				}						
			}
			//收
			//本月收
			//			string strMonthIn = "select cnvcGoodsType,cnvcGoodsName,sum(cnnInOutCount) as cnnInCount from tbOilStorageLog "
			//				+ " where cnnInOutCount >= 0 and convert(char(7),cndOperDate,121) = '"+strDate.Substring(0,7)+"' and cnvcDeptID like '"+strDeptID+"%'  "
			//				+ " group by cnvcGoodsType,cnvcGoodsName "
			//				+ " order by cnvcGoodsType,cnvcGoodsName ";
			string strMonthIn = "select cnvcGoodsType,cnvcGoodsName,sum(cnnInOutCount) as cnnInCount from tbOilStorageLog "
				+ " where cnnInOutCount >= 0 and cndOperDate >= '"+strBeginDate+"' and cndOperDate <'"+strEndDate+"' and  cnvcDeptID like '"+strDeptID+"%'  "
				+ " group by cnvcGoodsType,cnvcGoodsName "
				+ " order by cnvcGoodsType,cnvcGoodsName ";
			DataTable dtMonthIn =  ReportQueryFacade.CommonQuery(strMonthIn);
			//支
			//本月支
			//			string strMonthOut = "select cnvcGoodsType,cnvcGoodsName,sum(cnnInOutCount) as cnnOutCount from tbOilStorageLog "
			//				+ " where cnnInOutCount < 0 and convert(char(7),cndOperDate,121) = '"+strDate.Substring(0,7)+"' and cnvcDeptID like '"+strDeptID+"%'  "
			//				+ " group by cnvcGoodsType,cnvcGoodsName "
			//				+ " order by cnvcGoodsType,cnvcGoodsName ";
			string strMonthOut = "select cnvcGoodsType,cnvcGoodsName,sum(cnnInOutCount) as cnnOutCount from tbOilStorageLog "
				+ " where cnnInOutCount < 0 and cndOperDate >= '"+strBeginDate+"' and cndOperDate <'"+strEndDate+"' and cnvcDeptID like '"+strDeptID+"%'  "
				+ " group by cnvcGoodsType,cnvcGoodsName "
				+ " order by cnvcGoodsType,cnvcGoodsName ";
			DataTable dtMonthOut =  ReportQueryFacade.CommonQuery(strMonthOut);
			//损耗
			//			string strLose = " select cnvcGoodsName,cnvcGoodsType,sum(-(cnnLose-cnnOuterLose)) as cnnQuotaLose,sum(-cnnOuterLose) as cnnOuterLose "
			//				+ " from tbBillOfValidate "
			//				+ " where convert(char(7),cndDeliveryDate,121) = '"+strDate.Substring(0,7)+"' "
			//				+ " and cnvcDeptID like '"+strDeptID+"%' "
			//				+ " group by cnvcGoodsName,cnvcGoodsType ";
			string strLose = " select cnvcGoodsName,cnvcGoodsType,sum(-(cnnLose-cnnOuterLose)) as cnnQuotaLose,sum(-cnnOuterLose) as cnnOuterLose "
				+ " from tbBillOfValidate "
//				+ " where cndDeliveryDate >= '"+strBeginDate+"' "
//				+ " and cndDeliveryDate < '"+strEndDate+"'"
				//罗修改2010-09-03
				+ " where cndProvideDate >= '"+strBeginDate+"' "
				+ " and cndProvideDate < '"+strEndDate+"'"
				+ " and cnvcDeptID like '"+strDeptID+"%' "
				+ " group by cnvcGoodsName,cnvcGoodsType ";
			DataTable dtLose = ReportQueryFacade.CommonQuery(strLose);
			//库存损耗
			//			string strStorageLose = " select cnvcGoodsName,cnvcGoodsType,sum(-cnnLoseCount) as cnnStorageLose "
			//				+ " from tbOilStorageCheck "
			//				+ " where convert(char(7),cndOperDate,121) = '"+strDate.Substring(0,7)+"' "
			//				+ " and cnvcDeptID like '"+strDeptID+"%' "
			//				+ " group by cnvcGoodsName,cnvcGoodsType ";
			string strStorageLose = " select cnvcGoodsName,cnvcGoodsType,sum(-cnnLoseCount) as cnnStorageLose "
				+ " from tbOilStorageCheck "
				+ " where cndOperDate >= '"+strBeginDate+"' "
				+ " and cndOperDate < '"+strEndDate+"'"
				+ " and cnvcDeptID like '"+strDeptID+"%' "
				+ " group by cnvcGoodsName,cnvcGoodsType ";
			DataTable dtStorageLose = ReportQueryFacade.CommonQuery(strStorageLose);
			//合并数据		
			foreach (DataRow dr in dtGoodsType.Rows)
			{
				DataRow[] drMonthIns = dtMonthIn.Select("cnvcGoodsType='"+dr["cnvcGoodsType"].ToString()+"'");
				if (drMonthIns.Length > 0)
				{
					dr["cnvcGoodsName"] = drMonthIns[0]["cnvcGoodsName"];
					dr["cnvcNameType"] = drMonthIns[0]["cnvcGoodsType"].ToString() + drMonthIns[0]["cnvcGoodsName"].ToString();
					dr["cnnCurMonthInCount"] = drMonthIns[0]["cnnInCount"];
				}				
				DataRow[] drMonthOuts = dtMonthOut.Select("cnvcGoodsType='"+dr["cnvcGoodsType"].ToString()+"'");
				if (drMonthOuts.Length > 0)
				{
					dr["cnvcGoodsName"] = drMonthOuts[0]["cnvcGoodsName"];
					dr["cnvcNameType"] = drMonthOuts[0]["cnvcGoodsType"].ToString() + drMonthOuts[0]["cnvcGoodsName"].ToString();
					dr["cnnCurMonthOutCount"] = drMonthOuts[0]["cnnOutCount"];
				}	
				DataRow[] drLoses = dtLose.Select("cnvcGoodsType='"+dr["cnvcGoodsType"].ToString()+"'");
				if (drLoses.Length > 0)
				{
					dr["cnvcGoodsName"] = drLoses[0]["cnvcGoodsName"];
					dr["cnvcNameType"] = drLoses[0]["cnvcGoodsType"].ToString() + drLoses[0]["cnvcGoodsName"].ToString();
					dr["cnnQuotaLose"] = drLoses[0]["cnnQuotaLose"];
					dr["cnnOuterLose"] = drLoses[0]["cnnOuterLose"];
				}	

				DataRow[] drStorageLoses = dtStorageLose.Select("cnvcGoodsType='"+dr["cnvcGoodsType"].ToString()+"'");
				if (drStorageLoses.Length > 0)
				{
					dr["cnvcGoodsName"] = drStorageLoses[0]["cnvcGoodsName"];
					dr["cnvcNameType"] = drStorageLoses[0]["cnvcGoodsType"].ToString() + drStorageLoses[0]["cnvcGoodsName"].ToString();
					dr["cnnStorageLose"] = drStorageLoses[0]["cnnStorageLose"];
				}	
			}
			

			
			//算合计

			//double d0 = 0.00;
			foreach (DataRow drSum in dtGoodsType.Rows)
			{
				double dQuotaLose = 0.00;
				double dOuterLose = 0.00;
				double dOutCount  = 0.00;
				double dStorageLose = 0.00;
				//double dLose = 0.00;

				if (drSum["cnnCurMonthOutCount"].ToString() == "")
				{
					dOutCount = 0.00;
				}
				else
				{
					dOutCount = double.Parse(drSum["cnnCurMonthOutCount"].ToString());
				}
				if (drSum["cnnQuotaLose"].ToString() == "")
				{
					dQuotaLose = 0.00;
				}
				else
				{
					dQuotaLose = double.Parse(drSum["cnnQuotaLose"].ToString());
				}
				if (drSum["cnnOuterLose"].ToString() == "")
				{
					dOuterLose = 0.00;
				}
				else
				{
					dOuterLose = double.Parse(drSum["cnnOuterLose"].ToString());
				}
				if (drSum["cnnStorageLose"].ToString() == "")
				{
					dStorageLose = 0.00;
				}
				else
				{
					dStorageLose = double.Parse(drSum["cnnStorageLose"].ToString());
				}

				drSum["cnnLose"] = dOutCount + dQuotaLose + dOuterLose + dStorageLose;
			}
			//dtSum.Columns["cnvcOperType"].ColumnName = "供应方式";
			dtGoodsType.Columns["cnvcNameType"].ColumnName = "油料名称";
			dtGoodsType.Columns["cnnBeforeMonthCurCount"].ColumnName = "上月结存数量（KG）";
			dtGoodsType.Columns["cnnCurMonthInCount"].ColumnName = "本月收入（KG）";
			dtGoodsType.Columns["cnnCurMonthOutCount"].ColumnName = "本月实际支出（KG）";
			dtGoodsType.Columns["cnnCurMonthCurCount"].ColumnName = "本月结存数量（KG）";
			dtGoodsType.Columns["cnnStorageLose"].ColumnName = "本月库存损耗（KG）";
			dtGoodsType.Columns["cnnQuotaLose"].ColumnName = "本月定损支出（KG）";
			dtGoodsType.Columns["cnnOuterLose"].ColumnName = "本月超损支出（KG）";
			dtGoodsType.Columns["cnnLose"].ColumnName = "本月支出合计（KG）";
			
			dtGoodsType.Columns.Remove("cnvcGoodsName");
			dtGoodsType.Columns.Remove("cnvcGoodsType");
			return dtGoodsType;
		}
		private void BindGrid(string strDeptID,string strDeptName,string strDate)//,string strBeginDate,string strEndDate,string strBeforeBeginDate,string strBeforeEndDate)
		{			
			DataTable dtGoodsType = GetData(strDeptID,strDeptName,strDate);
			this.UcPageView1.MyDataSource = dtGoodsType.DefaultView;
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
			
			string strDate = "";
			if (this.txtBeginDate.Text == "")
			{
				strDate = DateTime.Now.ToString("yyyy-MM-dd");
			}
			else
			{
				strDate = this.txtBeginDate.Text;
			}

			BindGrid(this.ddlDept.SelectedValue,this.ddlDept.SelectedItem.Text,strDate);//,txtBeginDate.Text,txtEndDate.Text,txtBeforeBeginDate.Text,txtBeforeEndDate.Text);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{			
			this.txtBeginDate.Text = "";
			UcPageView1.DebindGrid();
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			string strDate = "";
			if (this.txtBeginDate.Text == "")
			{
				strDate = DateTime.Now.ToString("yyyy-MM-dd");
			}
			else
			{
				strDate = this.txtBeginDate.Text;
			}
			//导出EXCEL
			DataTable dtGoodsType = GetData(this.ddlDept.SelectedValue,this.ddlDept.SelectedItem.Text,strDate);
			string strGoodsType = this.ExportTable(dtGoodsType);
			//体
			//Session["QUERY"] = dtGoodsType;
			//头
			string strCaption = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strCaption += "<tr><td align=center colspan=9>"+CommonStatic.EnterpriseFullName()+"</td></tr>";
			strCaption += "<tr><td align=center colspan=9>油料收、支、存动态月报表</td></tr>";
			strCaption += "<tr><td align=left colspan=4>填报单位："+this.ddlDept.SelectedItem.Text+"</td><td align=left colspan=5>填报日期："+strDate+"";
			strCaption += "</table>";
			//Session["ExcelCaption"] = strCaption;
			//脚
			string strBottom = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strBottom += "<tr ><td align=left colspan=3>单位主管：</td>";
			strBottom += "<td align=left colspan=3>审核：</td>";
			strBottom += "<td align=left colspan=3>制表：</td></tr>";
			strBottom += "</table>";
			//Session["ExcelBottom"] = strBottom;
			this.ExportToXls(this,"油料收、支、存动态月报表",strCaption+strGoodsType+strBottom);
		}
	}
}
