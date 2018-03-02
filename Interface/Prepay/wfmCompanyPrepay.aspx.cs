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
using ynhnOilManage.BusinessFacade.Prepay;
namespace ynhnOilManage.Interface.Prepay
{
	/// <summary>
	/// wfmCompanyPrepay 的摘要说明。
	/// </summary>
	public class wfmCompanyPrepay : wfmBase
	{
		#region 字段
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DataGrid dgCompany;
		protected System.Web.UI.WebControls.DataGrid dgFillFee;
		protected System.Web.UI.WebControls.Button btnCompanyQuery;
		protected System.Web.UI.WebControls.Button btnFillQuery;
		protected System.Web.UI.WebControls.Button btnAddCompany;
		protected System.Web.UI.WebControls.TextBox txtCompanyName;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtBeginDate;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtOperName;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.TextBox txtflag;
		protected System.Web.UI.WebControls.Label Label3;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			//this.btnExcel.Attributes.Add("onclick","javascript:window.open('../Report/DataGridToExcel.aspx', 'Sample', 'toolbar=no,location=no,directories=no,status=yes,menubar=yes,scrollbars=no,resizable=yes,copyhistory=yes,width=790,height=520,left=0,top=0')");
			if (!IsPostBack)
			{
				BindDeptAll(ddlDept);
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
			this.btnCompanyQuery.Click += new System.EventHandler(this.btnCompanyQuery_Click);
			this.btnFillQuery.Click += new System.EventHandler(this.btnFillQuery_Click);
			this.btnAddCompany.Click += new System.EventHandler(this.btnAddCompany_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.dgCompany.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgCompany_PageIndexChanged);
			this.dgCompany.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgCompany_CancelCommand);
			this.dgCompany.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgCompany_EditCommand);
			this.dgCompany.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgCompany_UpdateCommand);
			this.dgFillFee.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgFillFee_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAddCompany_Click(object sender, System.EventArgs e)
		{
			string strFuncName = this.Server.UrlEncode("添加单位");
			this.Response.Redirect("wfmAddCompany.aspx?FLAG=ADD&FuncName="+strFuncName);
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

		private void btnCompanyQuery_Click(object sender, System.EventArgs e)
		{
			if(this.dgCompany.CurrentPageIndex>0)
			{
				this.dgCompany.CurrentPageIndex=0;
			}
			BindCompany();
			this.txtflag.Text = "Company";
		}
		private DataTable GetCompany()
		{
			//单位查询
			string strSql = "select a.*,'' as cnnFillFee,b.cnnFillFeeSum from tbMebCompanyPrepay a left outer join ";
			strSql += "(select cnvcCompanyID,cnvcAcctID,cnvcDeptID, "
				+ " sum(cnnFillFee) cnnFillFeeSum from tbFillFee where 1=1";
			if (txtBeginDate.Text != "")
			{
				strSql += " and convert(char(10),isnull(cndOperDate,''),120)>='"+txtBeginDate.Text+"'" ;
			}
			if (txtEndDate.Text != "")
			{
				strSql += " and convert(char(10),isnull(cndOperDate,''),120)<='"+txtEndDate.Text+"'";
			}
			strSql+= " group by cnvcCompanyID,cnvcAcctID,cnvcDeptID ) b on";
			strSql += " a.cnvcCompanyID=b.cnvcCompanyID and a.cnvcAcctID=b.cnvcAcctID and a.cnvcDeptID=b.cnvcDeptID ";
			strSql += " where 1=1 ";
			if (txtCompanyName.Text != "")
			{
				strSql += " and a.cnvcCompanyName like '%"+txtCompanyName.Text+"%'";
			}
			strSql += " and a.cnvcDeptID like '"+ddlDept.SelectedValue+"%'";
			
			strSql += " order by a.cnvcCompanyName";
			DataTable dtCompany = ReportQueryFacade.CommonQuery(strSql);
			decimal dPrepayFee = 0;
			decimal dFillfeeSum = 0;
			foreach(DataRow dr in dtCompany.Rows)
			{
				if(System.DBNull.Value == dr["cnnPrepayFee"])
				{
					dPrepayFee += 0;
				}
				else
				{
					dPrepayFee += Convert.ToDecimal(dr["cnnPrepayFee"]);
				}
				if(System.DBNull.Value == dr["cnnFillFeeSum"])
				{
					dFillfeeSum += 0;
				}
				else
				{
					dFillfeeSum += Convert.ToDecimal(dr["cnnFillFeeSum"]);
				}
			}
			DataRow drNew = dtCompany.NewRow();
			drNew["cnvcCompanyName"] = "合计：";
			drNew["cnnPrepayFee"] = dPrepayFee;
			drNew["cnnFIllFeeSum"] = dFillfeeSum;
			dtCompany.Rows.Add(drNew);
			return dtCompany;
		}
		private void BindCompany()
		{
			
			DataTable dtCompany = GetCompany();
			this.dgCompany.DataSource = dtCompany;
			this.dgCompany.DataBind();

			this.dgFillFee.DataSource = null;
			this.dgFillFee.DataBind();

			
		}
		private DataTable GetFillFee()
		{
			//充值查询
			//string strSql = "select * from tbFillFee where 1=1";
			string strSql = "select a.* from tbFillFee a left join tbMebCompanyPrepay b on a.cnvcCompanyID=b.cnvcCompanyID where 1=1";
			if (txtCompanyName.Text != "")
			{
				strSql += " and b.cnvcCompanyName like '%"+txtCompanyName.Text+"%'";
			}
			if (txtOperName.Text != "")
			{
				strSql += " and a.cnvcOperName like '%"+txtOperName.Text+"%'";
			}
			if (txtBeginDate.Text != "")
			{
				strSql += " and convert(char(10),a.cndOperDate,120) >= '"+txtBeginDate.Text+"'";
			}
			if (txtEndDate.Text != "")
			{
				strSql += " and convert(char(10),a.cndOperDate,120) <= '"+txtEndDate.Text+"'";
			}
			strSql += " and a.cnvcDeptID like '"+ddlDept.SelectedValue+"%'";
			strSql += " order by a.cndOperDate";
			DataTable dtFillFee = ReportQueryFacade.CommonQuery(strSql);
			return dtFillFee;
		}
		private void BindFillFee()
		{
			
			DataTable dtFillFee = GetFillFee();
			this.dgFillFee.DataSource = dtFillFee;
			this.dgFillFee.DataBind();

			this.dgCompany.DataSource = null;
			this.dgCompany.DataBind();

			

		}
		private void btnFillQuery_Click(object sender, System.EventArgs e)
		{
			if(this.dgFillFee.CurrentPageIndex>0)
			{
				this.dgFillFee.CurrentPageIndex=0;
			}
			BindFillFee();
			this.txtflag.Text = "FillFee";
		}

		#region dgCompany
		private void dgCompany_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//
			try
			{
				if (Session[ConstValue.LOGIN_USER_SESSION] == null || Session[ConstValue.LOGIN_USER_PURVIEW_SESSION] == null)
				{
					this.Response.Redirect(@"..\Sysmanage\Default.aspx");
				}
				//登录操作员功能地址列表
				bool isAuthorization = true;

				ArrayList alFuncName = (ArrayList) Session[ConstValue.LOGIN_USER_PURVIEW_SESSION];
				//请求的路径
				string strFileName = System.IO.Path.GetFileName(this.Request.Path);
				//请求的功能名称
				string strFuncName = "充值";
				//进行比对是否具有此权限
				if (alFuncName.BinarySearch(strFuncName) < 0)
				{
					isAuthorization = false;
				}				
			
				if (!isAuthorization)//如果无此功能地址
				{
					this.Response.Redirect(@"..\Sysmanage\wfmNoAuthorization.aspx");
				}
				else
				{
					this.dgCompany.EditItemIndex=(int)e.Item.ItemIndex;

					this.BindCompany();
				}
				
			}
			catch (BusinessException  bex)
			{
				Popup(bex.Message);
				return;
			}

			
		}

		private void dgCompany_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				
				string strFillFee = ((TextBox)e.Item.Cells[7].Controls[0]).Text;
				if (strFillFee.Trim().Length == 0)
				{
					Popup("请输入正确充值金额，如：22");
					return;
				}
				if (!IsNumeric(strFillFee))
				{
					Popup("请输入正确充值金额，如：22");
					return;
				}

				Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
				Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 

				BusiLog busiLog = new BusiLog();
				busiLog.cndOperDate = DateTime.Now;
				busiLog.cnnSerial = Guid.NewGuid();
				busiLog.cnvcOperName = curOper.cnvcOperName;
				busiLog.cnvcComments = "充值："+e.Item.Cells[1].Text+"|"+strFillFee;
				busiLog.cnvcDeptID = curDept.cnvcDeptID;
				busiLog.cnvcDeptName = curDept.cnvcDeptName;
				busiLog.cnvcOperType = "BS012";
				busiLog.cnvcSource = "网站";

				FillFee fee = new FillFee();
				fee.cndOperDate = busiLog.cndOperDate;
				fee.cnnFillFee = Decimal.Parse(strFillFee);
				fee.cnnSerial = busiLog.cnnSerial;
				Guid guidAcctID = new Guid(e.Item.Cells[2].Text);
				fee.cnvcAcctID = guidAcctID;
				Guid guidCompanyID = new Guid(e.Item.Cells[0].Text);
				fee.cnvcCompanyID = guidCompanyID;
				fee.cnvcCompanyName = e.Item.Cells[1].Text;
				fee.cnvcDeptID = e.Item.Cells[5].Text;
				fee.cnvcDeptName = e.Item.Cells[6].Text;
				fee.cnvcOperName = busiLog.cnvcOperName;
				
				PrepayFeeFacade.AddFee(fee,busiLog);
				this.dgCompany.EditItemIndex=-1;

				this.BindCompany();
				Popup("充值成功！");
			}
			catch (System.Exception ex)
			{
				Popup(ex.Message);
			}
			
		}

		private void dgCompany_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//
			this.dgCompany.EditItemIndex=-1;

			this.BindCompany();
		}
		

		private void dgCompany_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgCompany.CurrentPageIndex = e.NewPageIndex;
			BindCompany();
		}

		#endregion
		private void dgFillFee_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgFillFee.CurrentPageIndex = e.NewPageIndex;
			BindFillFee();
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			if(this.txtflag.Text == "FillFee")
			{
				DataTable dtFillFee = GetFillFee();
				dtFillFee.Columns.Remove("cnnSerial");
				dtFillFee.Columns.Remove("cnvcCompanyID");
				dtFillFee.Columns["cnvcCompanyName"].ColumnName = "单位名称";
				dtFillFee.Columns.Remove("cnvcAcctID");
				dtFillFee.Columns["cnnFillFee"].ColumnName = "充值金额";
				dtFillFee.Columns["cnvcOperName"].ColumnName = "操作员";
				dtFillFee.Columns["cndOperDate"].ColumnName = "操作时间";
				dtFillFee.Columns.Remove("cnvcDeptID");
				dtFillFee.Columns["cnvcDeptName"].ColumnName = "指定加油站";
				//体
				//Session["QUERY"] = dtFillFee;
				string strFillFee = this.ExportTable(dtFillFee);
				//头
				string strCaption = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
				strCaption += "<tr><td align=center colspan=5>"+CommonStatic.EnterpriseFullName()+"</td></tr>";
				strCaption += "<tr><td align=center colspan=5>充值明细表</td></tr>";
				strCaption += "<tr><td align=center colspan=5>"+DateTime.Now.ToString("yyyy年MM月dd日")+"</td></tr>";
				strCaption += "</table>";
				//Session["ExcelCaption"] = strCaption;
				this.ExportToXls(this,"充值明细表",strCaption+strFillFee);
			}
			else
			{
				DataTable dtCompany = GetCompany();
				dtCompany.Columns.Remove("cnvcCompanyID");
				dtCompany.Columns["cnvcCompanyName"].ColumnName = "单位名称";
				dtCompany.Columns.Remove("cnvcAcctID");
				dtCompany.Columns["cnnPrepayFee"].ColumnName = "余额";
				dtCompany.Columns.Remove("cnvcDeptID");
				dtCompany.Columns["cnvcDeptName"].ColumnName = "指定加油站";
				dtCompany.Columns.Remove("cnnFillFee");
				dtCompany.Columns["cnnFillFeeSum"].ColumnName = "充值合计";
				//体
				//Session["QUERY"] = dtCompany;
				string strCompany = this.ExportTable(dtCompany);
				//头
				string strCaption = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
				strCaption += "<tr><td align=center colspan=4>"+CommonStatic.EnterpriseFullName()+"</td></tr>";
				strCaption += "<tr><td align=center colspan=4>加油卡单位余额明细表</td></tr>";
				strCaption += "<tr><td align=center colspan=4>"+DateTime.Now.ToString("yyyy年MM月dd日")+"</td></tr>";
				strCaption += "</table>";
				//Session["ExcelCaption"] = strCaption;
				this.ExportToXls(this,"加油卡单位余额明细表",strCaption+strCompany);
			}
		}

	}
}
