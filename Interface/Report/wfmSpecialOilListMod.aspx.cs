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
using ynhnOilManage.BusinessFacade;
using ynhnOilManage.Common;
using ynhnOilManage.EntityObject;
using ynhnOilManage.EntityObject.EntityClass;

using ynhnOilManage.BusinessFacade.Report;
using ynhnOilManage.BusinessFacade.SysManage;
using ynhnOilManage.EntityObject.EntityBase;

namespace ynhnOilManage.Interface.Report
{
	/// <summary>
	/// wfmSpecialOilListMod 的摘要说明。
	/// </summary>
	public class wfmSpecialOilListMod : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlGoodsName;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlGoodsType;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.TextBox txtBillNo;
		protected System.Web.UI.WebControls.DropDownList ddlDeliveryCompany;
		protected System.Web.UI.WebControls.TextBox txtProvideCompany;
		protected System.Web.UI.WebControls.DropDownList ddlContractNo;
		protected System.Web.UI.WebControls.TextBox txtReceiveCount;
		protected System.Web.UI.WebControls.TextBox txtCount;
		protected System.Web.UI.WebControls.TextBox txtSpecialUnitPrice;
		protected System.Web.UI.WebControls.TextBox txtSpecialFee;
		protected System.Web.UI.WebControls.TextBox txtDeliveryDate;
		protected System.Web.UI.WebControls.TextBox txtDeliveryMan;
		protected System.Web.UI.WebControls.TextBox txtProvideBeginDate;
		protected System.Web.UI.WebControls.TextBox txtProvideEndDate;
		protected System.Web.UI.WebControls.TextBox txtProvideMan;
		protected System.Web.UI.WebControls.TextBox txtTimeOfValidity;
		protected System.Web.UI.WebControls.TextBox txtSignerCompany;
		protected System.Web.UI.WebControls.TextBox txtSigner;
		protected System.Web.UI.WebControls.TextBox txtDeptID;
		protected System.Web.UI.WebControls.TextBox txtDeptName;
		protected System.Web.UI.WebControls.Button btnCancel;
		//protected ynhnOilManage.Interface.Report.ucPageView UcPageView1;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if (!IsPostBack)
			{
				BindComponent();
				ShowComponent();
			}
		}

		
		private void BindComponent()
		{
			BindGoodsName(ddlGoodsName);
			BindGoodsType(ddlGoodsType,ddlGoodsName.SelectedValue);
				
			//				string strBillNo = this.Request["BillNo"].ToString();
			//				string strDeptID = this.Request["DeptID"].ToString();
			BindLocalDept(this.txtDeptID,this.txtDeptName);				
			BindSDept(ddlDeliveryCompany,this.txtDeptName.Text);
				
			BillOfMaterials bom = LoadObj("BOM") as BillOfMaterials;
			SetBOM(bom);
		}
		private void ShowComponent()
		{
			this.ddlGoodsName.Enabled = false;
			this.ddlGoodsType.Enabled = false;
			this.txtBillNo.Enabled = false;
			txtProvideCompany.Enabled = false;
			txtSpecialUnitPrice.Enabled = false;
			txtSpecialFee.Enabled = false;
			txtSignerCompany.Enabled = false;
		}
		private bool BOMValidate()
		{			
			if(txtReceiveCount.Text.Trim()=="")
			{
				this.Popup("领用数量不能为空！");
				return false;
			}
			if(!this.IsNumeric(txtReceiveCount.Text))
			{
				this.Popup("领用数量必须是数字！");
				return false;
			}
			if(Convert.ToDecimal(txtReceiveCount.Text)<0)
			{
				this.Popup("领用数量必须是正数！");
				return false;
			}
			
			if(txtCount.Text.Trim()=="")
			{
				this.Popup("实发数量不能为空！");
				return false;
			}
			if(!this.IsNumeric(txtCount.Text))
			{
				this.Popup("实发数量必须是数字！");
				return false;
			}
			if(Convert.ToDecimal(txtCount.Text)<0)
			{
				this.Popup("实发数量必须是正数！");
				return false;
			}
			return true;
		}

		private void SetBOM(BillOfMaterials _bom)
		{
			txtSpecialUnitPrice.Text = _bom.cnnSpecialUnitPrice.ToString();
			txtBillNo.Text = _bom.cnvcBillNo;			
			this.SetDDL(ddlDeliveryCompany,_bom.cnvcDeliveryCompany);
			BindContractNo(this.ddlContractNo,this.txtDeptName.Text,_bom.cnvcDeliveryCompany);
			this.SetDDL(ddlContractNo,_bom.cnvcContractNo);			
			txtProvideCompany.Text = _bom.cnvcProvideCompany;
			//this.SetDDL(ddlGoodsName,_bom.cnvcGoodsName);
			this.SetDDLTxt(this.ddlGoodsName,_bom.cnvcGoodsName);
			this.SetDDL(ddlGoodsType,_bom.cnvcGoodsType);
			txtReceiveCount.Text = _bom.cnnReceiveCount.ToString();
			txtCount.Text = _bom.cnnCount.ToString();
			txtDeliveryMan.Text = _bom.cnvcDeliveryMan;
			txtDeliveryDate.Text = _bom.cndDeliveryDate.ToString("yyyy-MM-dd");
			txtProvideBeginDate.Text = _bom.cndProvideBeginDate.ToString("yyyy-MM-dd");
			txtProvideEndDate.Text = _bom.cndProvideEndDate.ToString("yyyy-MM-dd");
			txtProvideMan.Text = _bom.cndProvideMan;
			txtSignerCompany.Text = _bom.cnvcSignerCompany;
			txtSigner.Text = _bom.cnvcSigner;
			txtTimeOfValidity.Text = _bom.cndTimeOfValidity.ToString("yyyy-MM-dd");
			txtSpecialFee.Text = _bom.cnnSpecialFee.ToString();
		}
		private BillOfMaterials GetBOM()
		{			
			Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 
			BillOfMaterials _bom = new BillOfMaterials();
			_bom.SetOriginalValue();
			_bom.cnvcBillNo=txtBillNo.Text.Trim();
			_bom.cnvcContractNo=ddlContractNo.SelectedValue;
			_bom.cnvcDeliveryCompany=ddlDeliveryCompany.SelectedValue;
			_bom.cnvcProvideCompany=txtProvideCompany.Text.Trim();
			_bom.cnvcGoodsName=ddlGoodsName.SelectedItem.Text;
			_bom.cnvcGoodsType=ddlGoodsType.SelectedValue;
			_bom.cnvcUnit="KG";
			_bom.cnnReceiveCount=Convert.ToDecimal(txtReceiveCount.Text.Trim());
			_bom.cnnCount=Convert.ToDecimal(txtCount.Text.Trim());
			_bom.cnvcDeliveryMan=txtDeliveryMan.Text.Trim();
			_bom.cndDeliveryDate=Convert.ToDateTime(txtDeliveryDate.Text);
			_bom.cndProvideBeginDate=Convert.ToDateTime(txtProvideBeginDate.Text);
			_bom.cndProvideEndDate=Convert.ToDateTime(txtProvideEndDate.Text);
			_bom.cndProvideMan=txtProvideMan.Text.Trim();
			_bom.cnvcSignerCompany=txtSignerCompany.Text.Trim();
			_bom.cnvcSigner=txtSigner.Text.Trim();
			_bom.cndTimeOfValidity=Convert.ToDateTime(txtProvideEndDate.Text);
			_bom.cnvcOperName= curOper.cnvcOperName;			
			_bom.cnnSpecialUnitPrice=Convert.ToDecimal(txtSpecialUnitPrice.Text.Trim());
			_bom.cnnSpecialFee=Convert.ToDecimal(txtSpecialFee.Text.Trim());
			_bom.cnvcDeptID= this.txtDeptID.Text;//SysInitial.LocalDeptID;
			return _bom;
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
			this.ddlGoodsName.SelectedIndexChanged += new System.EventHandler(this.ddlGoodsName_SelectedIndexChanged);
			this.ddlDeliveryCompany.SelectedIndexChanged += new System.EventHandler(this.ddlDeliveryCompany_SelectedIndexChanged);
			this.txtCount.TextChanged += new System.EventHandler(this.txtCount_TextChanged);
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(!this.BOMValidate()) return;
				BillOfMaterials bom = GetBOM();
			
				Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
				Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 

				BusiLog busiLog = new BusiLog();
				busiLog.cnvcOperName = curOper.cnvcOperName;
				busiLog.cnvcDeptID = curDept.cnvcDeptID;
				busiLog.cnvcDeptName = curDept.cnvcDeptName;


				ReportQueryFacade.UpdateBOM(bom,busiLog);
				this.Popup("专供油领料单修改成功");
			}
			catch(Exception ex)
			{
				this.Popup(ex.Message);
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmSpecialOilListReport.aspx?FuncName="+this.Server.UrlEncode("专供油供应明细表"));
		}

		private void ddlGoodsName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindGoodsType(ddlGoodsType,ddlGoodsName.SelectedValue);
		}

		private void ddlDeliveryCompany_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindContractNo(this.ddlContractNo,this.txtDeptName.Text,this.ddlDeliveryCompany.SelectedValue);
		}

		private void txtCount_TextChanged(object sender, System.EventArgs e)
		{
			if(BOMValidate())
			{
				this.txtSpecialFee.Text=((Double.Parse(this.txtCount.Text))*(Double.Parse(this.txtSpecialUnitPrice.Text))).ToString();
				
			}
		}
	}
}
