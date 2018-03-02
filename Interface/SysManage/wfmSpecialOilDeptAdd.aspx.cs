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
	/// wfmSpecialOilDeptAdd 的摘要说明。
	/// </summary>
	public class wfmSpecialOilDeptAdd : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtContactNo;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.TextBox txtDeliveryCompany;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
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

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			string strFuncName = this.Server.UrlEncode("专供油领用单位管理");
			this.Response.Redirect("wfmSpecialOilDept.aspx?FuncName="+strFuncName);
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			//添加

			if (txtContactNo.Text.Trim().Length == 0)
			{
				Popup("请输入合同编号！");
				return;
			}
			if (txtDeliveryCompany.Text.Trim().Length == 0)
			{
				Popup("请输入单位名称！");
				return;
			}
			string strContractSql = "select * from tbSpecialOilDept where cnvcContractNo='"+txtContactNo.Text+"' ";
			string strDeliveryCompany = "select * from tbSpecialOilDept where cnvcDeliveryCompany = '"+txtDeliveryCompany.Text+"'";
			DataTable dtContract = ReportQueryFacade.CommonQuery(strContractSql);
			DataTable dtDeliveryCompany = ReportQueryFacade.CommonQuery(strDeliveryCompany);
			if (dtContract.Rows.Count > 0)
			{
				Popup("相同的合同编号已存在！");
				return;
			}
			if (dtDeliveryCompany.Rows.Count > 0)
			{
				Popup("相同的单位名称已存在！");
				return;
			}
			SpecialOilDept specialOilDept = new SpecialOilDept();
			specialOilDept.cnvcContractNo = txtContactNo.Text;
			specialOilDept.cnvcDeliveryCompany = txtDeliveryCompany.Text;

			Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
			Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 
			BusiLog busiLog = new BusiLog();
			busiLog.cndOperDate = DateTime.Now;
			busiLog.cnnSerial = Guid.NewGuid();
			busiLog.cnvcOperName = curOper.cnvcOperName;
			busiLog.cnvcComments = "添加领用单位："+txtContactNo.Text+"|"+txtDeliveryCompany.Text;
			busiLog.cnvcDeptID = curDept.cnvcDeptID;
			busiLog.cnvcDeptName = curDept.cnvcDeptName;
			busiLog.cnvcOperType = "BS013";
			busiLog.cnvcSource = "网站";

			SpecialOilFacade.AddSpecialOilDept(specialOilDept,busiLog);
			Popup("领用单位添加成功");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			//取消
			this.txtContactNo.Text = "";
			this.txtDeliveryCompany.Text = "";
		}
	}
}
