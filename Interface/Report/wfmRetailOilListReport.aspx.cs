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
	public class wfmRetailOilListReport : wfmBase
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
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtCompanyName;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtCardID;
		protected System.Web.UI.WebControls.Button Button1;
		protected ynhnOilManage.Interface.Report.ucPageView UcPageView1;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			//this.btnExcel.Attributes.Add("onclick","javascript:window.open('DataGridToExcel.aspx', 'Sample', 'toolbar=no,location=no,directories=no,status=yes,menubar=yes,scrollbars=no,resizable=yes,copyhistory=yes,width=790,height=520,left=0,top=0')");
			this.Button1.Attributes["OnClick"] = "return confirm('是否重算?')";
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

				//权限设置
				this.Button1.Visible=false;
				ArrayList lstUserPurview = Session[ConstValue.LOGIN_USER_PURVIEW_SESSION] as ArrayList;				
				//string strFuncAddress = "wfmRetailOilListReport_Button1";
				string strFuncName="零售油_重算";
				foreach(string fn in lstUserPurview)
				{
					if(fn == strFuncName)
					{
						this.Button1.Visible=true;
					}
				}
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

		private DataTable GetData(string strDeptID,string strBeginDate,string strEndDate,string strCompanyName,string strCardID,ref string strCompanyNameFact)
		{
			string strSql = "select '' as cnnSerialNo,cnvcCardID,cnvcLicenseTags,cnvcGoodsName+cnvcGoodsType as cnvcNameType,'KG' as cnvcUnit,cnnKGCount,cnnPrice,cnnFee,cnvcComments,cnvcCompanyName,cndConsDate from tbConsItem where cnvcDeptID like '"+strDeptID+"%'";
			if (strBeginDate != "")
			{
				strSql += " and convert(char(10),cndConsDate,120)>='"+strBeginDate+"'" ;
			}
			if (strEndDate != "")
			{
				strSql += " and convert(char(10),cndConsDate,120)<='"+strEndDate+"'";
			}
			if (strCardID != "")
			{
				strSql += " and cnvcCardID = '"+strCardID+"'";
			}
			if (strCompanyName != "")
			{
				strSql += " and cnvcCompanyName='"+strCompanyName+"' ";
			}
			strSql += " order by cnvcGoodsName+cnvcGoodsType,cndOperDate desc";
			DataTable dtConsItem = ReportQueryFacade.CommonQuery(strSql);

			string strSum = "select "
				+ " cnvcGoodsName+cnvcGoodsType as cnvcNameType, "
				+ " sum(cnnKGCount) as cnnCount,sum(cnnFee) as cnnFee "
				+ " from tbConsItem "
				+ " where cnvcDeptID like '" + strDeptID + "%'";
			if (strBeginDate != "")
			{
				strSum += " and convert(char(10),cndConsDate,120)>='"+strBeginDate+"'" ;
			}
			if (strEndDate != "")
			{
				strSum += " and convert(char(10),cndConsDate,120)<='"+strEndDate+"'";
			}
			if (strCardID != "")
			{
				strSum += " and cnvcCardID = '"+strCardID+"'";
			}
			if (strCompanyName != "")
			{
				strSum += " and cnvcCompanyName='" + strCompanyName + "' ";
			}
			strSum += " group by cnvcGoodsName+cnvcGoodsType  ";
			strSum += " order by cnvcGoodsName+cnvcGoodsType ";
			DataTable dtConsSum = ReportQueryFacade.CommonQuery(strSum);
			//算合计
			double dCount = 0.00;
			double dFee = 0.00; 
			strCompanyNameFact = "";
			int i = 0;
			foreach (DataRow drConsItem in dtConsItem.Rows)
			{
				dCount += double.Parse(drConsItem["cnnKGCount"].ToString());
				dFee += double.Parse(drConsItem["cnnFee"].ToString());
				strCompanyNameFact = drConsItem["cnvcCompanyName"].ToString();
				i++;
				drConsItem["cnnSerialNo"] = i;
				
			}
			DataRow drNew = null;
			foreach(DataRow dr in dtConsSum.Rows)
			{
				drNew = dtConsItem.NewRow();
				drNew["cnvcLicenseTags"] = dr["cnvcNameType"].ToString() + "合计：";
				drNew["cnnKGCount"] =  dr["cnnCount"];
				drNew["cnnFee"] =  dr["cnnFee"];
				//drNew["cnvcComments"] = "因油料密度影响，油料金额存在尾数差异";
				dtConsItem.Rows.Add(drNew);
			}
			drNew = dtConsItem.NewRow();
			drNew["cnvcLicenseTags"] = "合计";
			drNew["cnnKGCount"] = Math.Round(dCount,2);
			drNew["cnnFee"] = Math.Round(dFee,2);
			//drNew["cnvcComments"] = "因油料密度影响，油料金额存在尾数差异";
			dtConsItem.Rows.Add(drNew);
			dtConsItem.Columns["cnnSerialNo"].ColumnName = "序号";
			dtConsItem.Columns["cnvcLicenseTags"].ColumnName = "车牌号";
			dtConsItem.Columns["cnvcCardID"].ColumnName = "会员卡号";
			dtConsItem.Columns["cnvcNameType"].ColumnName = "型号规格";
			dtConsItem.Columns["cnvcUnit"].ColumnName = "单位";
			dtConsItem.Columns["cnnKGCount"].ColumnName = "数量";
			dtConsItem.Columns["cnnPrice"].ColumnName = "销售单价（元）";
			dtConsItem.Columns["cnnFee"].ColumnName = "销售金额（元）";
			dtConsItem.Columns["cndConsDate"].ColumnName = "消费时间";
			dtConsItem.Columns["cnvcComments"].ColumnName = "备注";//
			
			dtConsItem.Columns.Remove("cnvcCompanyName");
			return dtConsItem;
		}
		private void BindGrid(string strDeptID,string strBeginDate,string strEndDate,string strCompanyName,string strCardID)
		{
			string strCompanyNameFact = "";
			DataTable dtConsItem = GetData(strDeptID,strBeginDate,strEndDate,strCompanyName,strCardID,ref strCompanyNameFact);
			this.UcPageView1.MyDataSource = dtConsItem.DefaultView;
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{

			BindGrid(this.ddlDept.SelectedValue,this.txtBeginDate.Text,this.txtEndDate.Text,this.txtCompanyName.Text,txtCardID.Text);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.txtBeginDate.Text = "";
			this.txtEndDate.Text = "";
			this.txtCompanyName.Text = "";
			UcPageView1.DebindGrid();
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			//导出EXCEL
			//体
			string strCompanyNameFact = "";
			DataTable dtConsItem = GetData(this.ddlDept.SelectedValue,this.txtBeginDate.Text,this.txtEndDate.Text,this.txtCompanyName.Text,txtCardID.Text,ref strCompanyNameFact);
			string strConsItem = this.ExportTable(dtConsItem);
			//Session["QUERY"] = dtConsItem;
			//头
			string strCaption = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strCaption += "<tr><td align=center colspan=10>"+CommonStatic.EnterpriseFullName()+"</td></tr>";
			strCaption += "<tr><td align=center colspan=10>"+ddlDept.SelectedItem.Text+"零售油销售明细表</td></tr>";
			strCaption += "<tr><td align=center colspan=10>"+DateTime.Now.ToString("yyyy年MM月dd日")+"</td></tr>";
			strCaption += "<tr><td align=left colspan=5>"+"领用单位："+strCompanyNameFact+"</td><td colspan=3></td><td align=center>金额单位：元</td><td></td></tr>";
			strCaption += "</table>";
			//Session["ExcelCaption"] = strCaption;
			//脚
			string strBottom = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strBottom += "<tr><td></td>";
			strBottom += "<td align=center colspan=3>部门主管：</td>";
			strBottom += "<td></td><td></td>";
			strBottom += "<td align=center>审核：</td>";
			strBottom += "<td></td><td>制表：</td><td></td></tr>";
			//因油料密度影响，油料金额存在尾数差异
			strBottom += "<tr><td colspan=10>因油料密度影响，油料金额存在尾数差异。本表一式四份，物资公司财务一份，物资公司业务一份，一份与供货发票一并转使用单位，各电站业务留存一份。</td></tr></table>";
			//Session["ExcelBottom"] = strBottom;
			this.ExportToXls(this,ddlDept.SelectedItem.Text+"零售油销售明细表",strCaption+strConsItem+strBottom);
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				//根据新油价重算
				if(this.txtBeginDate.Text.Trim().Length==0)
				{
					this.Popup("请输入开始日期！");
					return;
				}
				if(this.txtEndDate.Text.Trim().Length==0)
				{
					this.Popup("请输入结束日期！");
					return;
				}
			
				DataTable dtPrice = ReportQueryFacade.CommonQuery("select count(*) from tbOilPrice where convert(varchar(10),cndpricedate,121) between '"+this.txtBeginDate.Text+"' and '"+this.txtEndDate.Text+"'");
				int icount = Convert.ToInt32(dtPrice.Rows[0][0].ToString());
				if(icount==0)
				{
					this.Popup("选定的时间段油价未变动！");
					return;
				}
			

				Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
				Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 

				BusiLog busiLog = new BusiLog();
				busiLog.cnvcOperName = curOper.cnvcOperName;
				busiLog.cnvcComments = "重算："+this.txtBeginDate.Text+"-"+this.txtEndDate.Text;
				busiLog.cnvcDeptID = curDept.cnvcDeptID;
				busiLog.cnvcDeptName = curDept.cnvcDeptName;
				busiLog.cnvcOperType = "BS016";
				busiLog.cnvcSource = "网站";

			
				

				ReportQueryFacade.AgainComp(this.txtBeginDate.Text,this.txtEndDate.Text,busiLog);
				this.Popup("重算成功");
			}
			catch(Exception ex)
			{
				this.Popup(ex.Message);
			}
		}
	}
}
