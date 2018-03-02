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
	/// wfmAddCompany 的摘要说明。
	/// </summary>
	public class wfmAddCompany : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtCompanyName;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.TextBox txtPrepayFee;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.CheckBox chkValidate;
		protected System.Web.UI.WebControls.TextBox txtCompanyID;
		protected System.Web.UI.WebControls.Label Label4;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if (!IsPostBack)
			{
				BindDept(ddlDept);
				string strflag = this.Request["FLAG"].ToString();
				ShowComponent(strflag);
				if(strflag=="MOD")
				{
					string strcompanyid = this.Request["COMPANYID"].ToString();
					LoadComponent(strcompanyid);
				}
			}
		}
		private void LoadComponent(string strcompanyid)
		{
			string strsql = "select * from tbMebCompanyPrepay where cnvccompanyid='"+strcompanyid+"'";
			DataTable dt = ReportQueryFacade.CommonQuery(strsql);
			if(dt.Rows.Count != 1)
			{
				throw new Exception("不能获取到单位");
			}
			MebCompanyPrepay mcp = new MebCompanyPrepay(dt);
			this.txtCompanyID.Text = mcp.cnvcCompanyID.ToString();
			this.txtCompanyName.Text = mcp.cnvcCompanyName;
			this.chkValidate.Checked = mcp.cnbValidate;
		}
		private void ShowComponent(string strflag)
		{
			switch(strflag)
			{
				case "ADD":
					Label1.Text = "添加单位";
					//Label2.Visible = true;
					Label3.Visible = true;
					Label4.Visible = true;
					
					this.ddlDept.Visible = true;
					this.txtPrepayFee.Visible = true;
					break;
				case "MOD":
					Label1.Text = "修改单位";
					Label3.Visible = false;
					Label4.Visible = false;
					
					this.ddlDept.Visible = false;
					this.txtPrepayFee.Visible = false;
					break;
			}
		}
		

		private void AddCompany()
		{
			MebCompanyPrepay company = new MebCompanyPrepay();
			company.cnnPrepayFee = Decimal.Parse(txtPrepayFee.Text);
			company.cnvcAcctID = Guid.NewGuid();
			company.cnvcCompanyID = Guid.NewGuid();
			company.cnvcCompanyName = txtCompanyName.Text;
			company.cnvcDeptID = ddlDept.SelectedValue;
			company.cnvcDeptName = ddlDept.SelectedItem.Text;

			company.cnbValidate = chkValidate.Checked;

			Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
			Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 

			BusiLog busiLog = new BusiLog();
			busiLog.cndOperDate = DateTime.Now;
			busiLog.cnnSerial = Guid.NewGuid();
			busiLog.cnvcOperName = curOper.cnvcOperName;
			busiLog.cnvcComments = "添加单位："+txtCompanyName.Text;
			busiLog.cnvcDeptID = curDept.cnvcDeptID;
			busiLog.cnvcDeptName = curDept.cnvcDeptName;
			busiLog.cnvcOperType = "BS011";
			busiLog.cnvcSource = "网站";

			FillFee fee = new FillFee();
			fee.cndOperDate = busiLog.cndOperDate;
			fee.cnnFillFee = company.cnnPrepayFee;
			fee.cnvcAcctID = company.cnvcAcctID;
			fee.cnvcCompanyID = company.cnvcCompanyID;
			fee.cnvcCompanyName = company.cnvcCompanyName;
			fee.cnvcDeptID = company.cnvcDeptID;
			fee.cnvcDeptName = company.cnvcDeptName;
			fee.cnnSerial = busiLog.cnnSerial;
			fee.cnvcOperName = busiLog.cnvcOperName;
			

			PrepayFeeFacade.AddCompany(company,fee,busiLog);
		}
		private void UpdateCompany()
		{
			MebCompanyPrepay company = new MebCompanyPrepay();
			Guid cid = new Guid(this.txtCompanyID.Text);
			company.cnvcCompanyID = cid;
			company.cnvcCompanyName = txtCompanyName.Text;

			company.cnbValidate = chkValidate.Checked;

			Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
			Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 

			BusiLog busiLog = new BusiLog();
			busiLog.cndOperDate = DateTime.Now;
			busiLog.cnnSerial = Guid.NewGuid();
			busiLog.cnvcOperName = curOper.cnvcOperName;
			busiLog.cnvcComments = "修改单位："+txtCompanyName.Text;
			busiLog.cnvcDeptID = curDept.cnvcDeptID;
			busiLog.cnvcDeptName = curDept.cnvcDeptName;
			busiLog.cnvcOperType = "BS012";
			busiLog.cnvcSource = "网站";

//			FillFee fee = new FillFee();
//			fee.cndOperDate = busiLog.cndOperDate;
//			fee.cnnFillFee = company.cnnPrepayFee;
//			fee.cnvcAcctID = company.cnvcAcctID;
//			fee.cnvcCompanyID = company.cnvcCompanyID;
//			fee.cnvcCompanyName = company.cnvcCompanyName;
//			fee.cnvcDeptID = company.cnvcDeptID;
//			fee.cnvcDeptName = company.cnvcDeptName;
//			fee.cnnSerial = busiLog.cnnSerial;
//			fee.cnvcOperName = busiLog.cnvcOperName;
			

			PrepayFeeFacade.UpdateCompany(company,busiLog);
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
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			switch(this.Label1.Text)
			{
				case "添加单位":
					btnAddCompany();
					break;
				case "修改单位":
					btnUpdateCompany();
					break;
			}
		}

		private void btnAddCompany()
		{
			//添加单位
			if (txtCompanyName.Text.Trim().Length == 0)
			{
				Popup("请输入单位名称");
				return;
			}

			if (txtPrepayFee.Text.Trim().Length == 0)
			{
				txtPrepayFee.Text = "0";
			}
			if (!IsNumeric(txtPrepayFee.Text.Trim()))
			{
				Popup("请输入正确金额，如：22");
				return;
			}
			try
			{
				string strSql = "select * from tbMebCompanyPrepay where cnvcCompanyName = '"+txtCompanyName.Text+"'";
				DataTable dtCompany = ReportQueryFacade.CommonQuery(strSql);
				if (dtCompany.Rows.Count > 0)
				{
					throw new Exception("同名单位已存在，请重新输入单位名称！");
				}
				AddCompany();
				Popup("添加单位成功！");
				btnCancel_Click(null,null);
			}
			catch (System.Exception ex)
			{
				Popup(ex.Message);
			}
		}
		private void btnUpdateCompany()
		{
			//添加单位
			if (txtCompanyName.Text.Trim().Length == 0)
			{
				Popup("请输入单位名称");
				return;
			}

//			if (txtPrepayFee.Text.Trim().Length == 0)
//			{
//				txtPrepayFee.Text = "0";
//			}
//			if (!IsNumeric(txtPrepayFee.Text.Trim()))
//			{
//				Popup("请输入正确金额，如：22");
//				return;
//			}
			try
			{
				string strSql = "select * from tbMebCompanyPrepay where cnvcCompanyName = '"+txtCompanyName.Text+"'";
				DataTable dtCompany = ReportQueryFacade.CommonQuery(strSql);
				if (dtCompany.Rows.Count > 1)
				{
					throw new Exception("同名单位已存在，请重新输入单位名称！");
				}
				UpdateCompany();
				Popup("修改单位成功！");
				//btnCancel_Click(null,null);
			}
			catch (System.Exception ex)
			{
				Popup(ex.Message);
			}
		}
//		private bool IsNumeric(string str)  
//		{   
//			System.Text.RegularExpressions.Regex reg1  
//				= new System.Text.RegularExpressions.Regex(@"^[-]?\d+[.]?\d*$");   
//			return reg1.IsMatch(str);  
//		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			txtCompanyName.Text = "";
			txtPrepayFee.Text = "";
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			
			string strFuncName = this.Server.UrlEncode("单位预存及充值");
			this.Response.Redirect("wfmCompanyPrepay.aspx?FuncName="+strFuncName);
		}  

	}
}
