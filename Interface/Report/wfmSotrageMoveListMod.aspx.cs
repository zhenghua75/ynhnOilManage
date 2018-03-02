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
	/// wfmSotrageMoveListMod 的摘要说明。
	/// </summary>
	public class wfmSotrageMoveListMod : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlGoodsName;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlGoodsType;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtBillNo;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtMoveNo;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.TextBox txtProvideStroage;
		protected System.Web.UI.WebControls.DropDownList ddlDeliveryCompany;
		protected System.Web.UI.WebControls.TextBox txtTransportCompany;
		protected System.Web.UI.WebControls.TextBox txtTransportLiscenseTags;
		protected System.Web.UI.WebControls.TextBox txtOutStorageDate;
		protected System.Web.UI.WebControls.TextBox txtReceivableCount;
		protected System.Web.UI.WebControls.TextBox txtCount;
		protected System.Web.UI.WebControls.TextBox txtStorageIncharge;
		protected System.Web.UI.WebControls.TextBox txtDeliveryMan;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.TextBox txtLister;
		protected System.Web.UI.WebControls.TextBox txtComments;
		protected System.Web.UI.WebControls.TextBox txtDeptID;
		protected System.Web.UI.WebControls.TextBox txtDeptName;
		protected System.Web.UI.WebControls.TextBox txtBillOfMaterialsNo;
	
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
			BindLocalDept(this.txtDeptID,this.txtDeptName);				
			BindPDept(ddlDeliveryCompany,this.txtDeptID.Text);				
			BillOfOutStorage bov = LoadObj("BOS") as BillOfOutStorage;
			SetBOS(bov);
		}
		private void ShowComponent()
		{
			this.ddlGoodsName.Enabled = false;
			this.ddlGoodsType.Enabled = false;
			this.txtBillNo.Enabled = false;
			txtProvideStroage.Enabled = false;
		}

		private void SetBOS(BillOfOutStorage _bos)
		{
			txtBillNo.Text = _bos.cnvcBillNo;
			txtProvideStroage.Text = _bos.cnvcProvideStroage;
			//cmbDeliveryCompany.Text = _bos.cnvcDeliveryCompany;
			this.SetDDLTxt(this.ddlDeliveryCompany,_bos.cnvcDeliveryCompany);
			txtMoveNo.Text = _bos.cnvcMoveNo;
			txtBillOfMaterialsNo.Text = _bos.cnvcBillOfMaterialsNo;
			txtTransportCompany.Text = _bos.cnvcTransportCompany;
			txtTransportLiscenseTags.Text = _bos.cnvcTransportLiscenseTags;
			txtOutStorageDate.Text = _bos.cndOutStorageDate.ToString("yyyy-MM-dd");
			//cmbGoodsName.Text = _bos.cnvcGoodsName;
			this.SetDDLTxt(ddlGoodsName,_bos.cnvcGoodsName);
			//cmbGoodsType.Text = _bos.cnvcGoodsType;
			this.SetDDL(ddlGoodsType,_bos.cnvcGoodsType);
			txtReceivableCount.Text = _bos.cnnReceivableCount.ToString();
			txtCount.Text = _bos.cnnCount.ToString();
			txtComments.Text = _bos.cnvcComments;
			txtStorageIncharge.Text = _bos.cnvcStorageIncharge;
			txtDeliveryMan.Text = _bos.cnvcDeliveryMan;
			txtLister.Text = _bos.cnvcLister;
		}
		private BillOfOutStorage GetBOS()
		{
			Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 
			BillOfOutStorage _bos = new BillOfOutStorage();
			_bos.SetOriginalValue();
			_bos.cnvcBillNo=txtBillNo.Text.Trim();
			_bos.cnvcProvideStroage=txtProvideStroage.Text.Trim();
			_bos.cnvcDeliveryCompany=ddlDeliveryCompany.SelectedItem.Text;
			_bos.cnvcMoveNo=txtMoveNo.Text.Trim();
			_bos.cnvcBillOfMaterialsNo=txtBillOfMaterialsNo.Text.Trim();
			_bos.cnvcTransportCompany=txtTransportCompany.Text.Trim();
			_bos.cnvcTransportLiscenseTags=txtTransportLiscenseTags.Text.Trim();
			_bos.cndOutStorageDate=Convert.ToDateTime(txtOutStorageDate.Text);
			_bos.cnvcGoodsName=ddlGoodsName.SelectedItem.Text;
			_bos.cnvcGoodsType=ddlGoodsType.SelectedValue;
			_bos.cnvcUnit="KG";
			_bos.cnnReceivableCount=Convert.ToDecimal(txtReceivableCount.Text.Trim());
			_bos.cnnCount=Convert.ToDecimal(txtCount.Text.Trim());
			_bos.cnvcComments=txtComments.Text.Trim();
			_bos.cnvcStorageIncharge=txtStorageIncharge.Text.Trim();
			_bos.cnvcDeliveryMan=txtDeliveryMan.Text.Trim();
			_bos.cnvcLister=txtLister.Text.Trim();
			_bos.cnvcOperName=curOper.cnvcOperName;
			_bos.cnvcDeptID=this.txtDeptID.Text;
			_bos.cnvcDeliveryDeptID=ddlDeliveryCompany.SelectedValue;
			return _bos;
		}
		private bool BOSValidate()
		{
//			if(cmbGoodsName.Text.Trim()==""||cmbGoodsType.Text.Trim()=="")
//			{
//				MessageBox.Show("物料参数不全，请检查参数！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				return false;
//			}
//
//			if(txtBillNo.Text.Trim()=="")
//			{
//				MessageBox.Show("出库单号不可为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				return false;
//			}
//			else
//			{
//				if(this._flag == OperFlag.ADD)
//				{
//					err=null;
//					if(cs.IsDupBillOfOutStorage(txtBillNo.Text.Trim(),out err))
//					{
//						MessageBox.Show("出库单号已经存在，请重新输入！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//						return false;
//					}
//				}
//			}
			if(txtMoveNo.Text.Trim()=="")
			{
				this.Popup("调拨单号不可为空！");
				return false;
			}
			if(txtBillOfMaterialsNo.Text.Trim()=="")
			{
				this.Popup("领料单号不可为空！");
				return false;
			}
			if(txtReceivableCount.Text.Trim()=="")
			{
				this.Popup("应发数不可为空！");
				return false;
			}
			if(txtCount.Text.Trim()=="")
			{
				this.Popup("实发数不可为空！");
				return false;
			}

			if(!this.IsNumeric(txtReceivableCount.Text))
			{
				this.Popup("应发数应为数字！");
				return false;
			}
			if(!this.IsNumeric(txtCount.Text))
			{
				this.Popup("实发数应为数字！");
				return false;
			}

			if(Convert.ToDecimal(txtReceivableCount.Text)<0)
			{
				this.Popup("应发数应正数！");
				return false;
			}
			if(Convert.ToDecimal(txtCount.Text)<0)
			{
				this.Popup("实发数应为正数！");
				return false;
			}

//			if(cmbDeliveryCompany.Text.Trim()=="")
//			{
//				MessageBox.Show("提货单位不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				return false;
//			}
			return true;
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmSotrageMoveListReport.aspx?FuncName="+this.Server.UrlEncode("储备库调拨明细报表"));
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(!this.BOSValidate()) return;
				BillOfOutStorage bos = GetBOS();
			
				Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
				Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 

				BusiLog busiLog = new BusiLog();
				busiLog.cnvcOperName = curOper.cnvcOperName;
				busiLog.cnvcDeptID = curDept.cnvcDeptID;
				busiLog.cnvcDeptName = curDept.cnvcDeptName;

				ReportQueryFacade.UpdateBOS(bos,busiLog);
				this.Popup("调拨单修改成功");
			}
			catch(Exception ex)
			{
				this.Popup(ex.Message);
			}
		}
	}
}
