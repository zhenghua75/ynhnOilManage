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
	/// wfmOilValidateListMod 的摘要说明。
	/// </summary>
	public class wfmOilValidateListMod : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlGoodsName;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlGoodsType;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtBillNo;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlInType;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.DropDownList ddlProvideCompany;
		protected System.Web.UI.WebControls.TextBox txtDeliveryComp;
		protected System.Web.UI.WebControls.TextBox txtProvideDate;
		protected System.Web.UI.WebControls.TextBox txtTrLicenseTags;
		protected System.Web.UI.WebControls.TextBox txtTransportMan;
		protected System.Web.UI.WebControls.TextBox txtDeliveryDate;
		protected System.Web.UI.WebControls.TextBox txtOriginalCount;
		protected System.Web.UI.WebControls.TextBox txtValidateCount;
		protected System.Web.UI.WebControls.TextBox txtDistance;
		protected System.Web.UI.WebControls.TextBox txtTransportLose;
		protected System.Web.UI.WebControls.TextBox txtLose;
		protected System.Web.UI.WebControls.TextBox txtQuotaLose;
		protected System.Web.UI.WebControls.TextBox txtQuterLose;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.TextBox txtProvideAddress;
		protected System.Web.UI.WebControls.TextBox txtDeptID;
		protected System.Web.UI.WebControls.TextBox txtDeptName;
		protected System.Web.UI.WebControls.TextBox txtProvideCompany;
		protected System.Web.UI.WebControls.TextBox txtOutNo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if (!IsPostBack)
			{
				BindComponent();
				ShowComponent();
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
			this.txtOriginalCount.TextChanged += new System.EventHandler(this.txtOriginalCount_TextChanged);
			this.txtValidateCount.TextChanged += new System.EventHandler(this.txtValidateCount_TextChanged);
			this.txtDistance.TextChanged += new System.EventHandler(this.txtDistance_TextChanged);
			this.txtTransportLose.TextChanged += new System.EventHandler(this.txtTransportLose_TextChanged);
			this.txtLose.TextChanged += new System.EventHandler(this.txtLose_TextChanged);
			this.txtQuotaLose.TextChanged += new System.EventHandler(this.txtQuotaLose_TextChanged);
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindComponent()
		{
			BindGoodsName(ddlGoodsName);
			BindGoodsType(ddlGoodsType,ddlGoodsName.SelectedValue);
			BindLocalDept(this.txtDeptID,this.txtDeptName);				
			BindPDept(ddlProvideCompany,this.txtDeptID.Text);				
			BillOfValidate bov = LoadObj("BOV") as BillOfValidate;
			SetBOV(bov);
		}
		private void ShowComponent()
		{
			this.ddlGoodsName.Enabled = false;
			this.ddlGoodsType.Enabled = false;
			this.txtBillNo.Enabled = false;
			txtDeliveryComp.Enabled = false;
			txtTransportLose.Enabled = false;
			txtLose.Enabled = false;
			txtQuotaLose.Enabled = false;
			txtQuterLose.Enabled = false;
			ddlInType.Enabled = false;
			switch(ddlInType.SelectedValue)
			{
				case "调拨入库":
					this.ddlProvideCompany.Visible = true;
					this.txtProvideCompany.Visible = false;
					break;
				case "购入":
					this.ddlProvideCompany.Visible = false;
					this.txtProvideCompany.Visible = true;
					break;
			}
		}
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("wfmOilValidateListReport.aspx?FuncName="+this.Server.UrlEncode("油料验收明细报表"));
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(!this.BOVValidate()) return;
				BillOfValidate bov = GetBOV();
			
				Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
				Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 

				BusiLog busiLog = new BusiLog();
				busiLog.cnvcOperName = curOper.cnvcOperName;
				busiLog.cnvcDeptID = curDept.cnvcDeptID;
				busiLog.cnvcDeptName = curDept.cnvcDeptName;

				ReportQueryFacade.UpdateBOV(bov,busiLog);
				this.Popup("验收单修改成功");
			}
			catch(Exception ex)
			{
				this.Popup(ex.Message);
			}

		}


		private void SetBOV(BillOfValidate _bov)
		{
			this.SetDDLTxt(this.ddlGoodsName,_bov.cnvcGoodsName);
			this.SetDDL(this.ddlGoodsType,_bov.cnvcGoodsType);
			this.txtBillNo.Text = _bov.cnvcBillNo;
			this.txtOutNo.Text = _bov.cnvcOutNo;
			this.SetDDL(this.ddlInType,_bov.cnvcInType);
			this.SetDDLTxt(this.ddlProvideCompany,_bov.cnvcProvideCompany);
			this.txtProvideCompany.Text = _bov.cnvcProvideCompany;
			this.txtDeliveryComp.Text = _bov.cnvcDeliveryCompany;
			this.txtProvideDate.Text = _bov.cndProvideDate.ToString("yyyy-MM-dd");
			this.txtTrLicenseTags.Text = _bov.cnvcTransportLicenseTags;
			this.txtTransportMan.Text = _bov.cnvcTransportMan;
			this.txtDeliveryDate.Text = _bov.cndDeliveryDate.ToString("yyyy-MM-dd");
			this.txtOriginalCount.Text = _bov.cnnOriginalCount.ToString();
			this.txtValidateCount.Text = _bov.cnnValidateCount.ToString();
			this.txtDistance.Text = _bov.cnnDistance.ToString();
			this.txtTransportLose.Text = _bov.cnnTransportLose.ToString();
			this.txtLose.Text = _bov.cnnLose.ToString();
			this.txtQuotaLose.Text = _bov.cnnQuotaLose.ToString();
			this.txtQuterLose.Text = _bov.cnnOuterLose.ToString();
			this.txtProvideAddress.Text = _bov.cnvcProvideAddress;
		}
		private BillOfValidate GetBOV()
		{
			Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 
			BillOfValidate _bov = new BillOfValidate();
			_bov.SetOriginalValue();
			_bov.cnvcBillNo=txtBillNo.Text.Trim();
			_bov.cnvcOutNo=txtOutNo.Text.Trim();
			_bov.cnvcDeliveryCompany=txtDeliveryComp.Text.Trim();
			_bov.cndProvideDate=Convert.ToDateTime(txtProvideDate.Text);
			_bov.cndDeliveryDate=Convert.ToDateTime(txtDeliveryDate.Text);
			_bov.cnvcGoodsName=ddlGoodsName.SelectedItem.Text;
			_bov.cnvcGoodsType=ddlGoodsType.SelectedValue;
			_bov.cnvcUnit="KG";
			_bov.cnvcTransportLicenseTags=txtTrLicenseTags.Text.Trim();
			_bov.cnvcTransportMan=txtTransportMan.Text.Trim();
			_bov.cnnOriginalCount=Convert.ToDecimal(txtOriginalCount.Text.Trim());
			_bov.cnnValidateCount=Convert.ToDecimal(txtValidateCount.Text.Trim());
			_bov.cnnDistance=Convert.ToDecimal(txtDistance.Text.Trim());
			_bov.cnnTransportLose=Convert.ToDecimal(txtTransportLose.Text.Trim());
			_bov.cnnLose=Convert.ToDecimal(txtLose.Text.Trim());
			_bov.cnnQuotaLose=Convert.ToDecimal(txtQuotaLose.Text.Trim());
			_bov.cnnOuterLose=Convert.ToDecimal(txtQuterLose.Text.Trim());
			_bov.cnvcProvideAddress=txtProvideAddress.Text.Trim();
			_bov.cnvcInType=ddlInType.SelectedValue;
			_bov.cnvcOperName= curOper.cnvcOperName;
			_bov.cnvcDeptID= this.txtDeptID.Text;
			switch(_bov.cnvcInType)
			{
				case "调拨入库":
					_bov.cnvcProvideCompany=ddlProvideCompany.SelectedItem.Text;
					_bov.cnvcProvideDeptID= this.ddlProvideCompany.SelectedValue;
					break;
				case "购入":
					_bov.cnvcProvideCompany=txtProvideCompany.Text;
					_bov.cnvcProvideDeptID= "";
					break;
			}
			return _bov;
		}
		private bool BOVValidate()
		{			
//			if(cmbGoodsName.Text.Trim()==""||cmbGoodsType.Text.Trim()=="")
//			{
//				MessageBox.Show("物料参数不全，请检查参数！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				return false;
//			}
//			
//			if(cmbProvideCompany.Text.Trim()=="")
//			{
//				MessageBox.Show("供油单位不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				return false;
//			}
//			if(txtBillNo.Text.Trim()=="")
//			{
//				MessageBox.Show("收油核对单号不能为空！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//				return false;
//			}
//			else
//			{
//				if(this._flag == OperFlag.ADD)
//				{
//					err=null;
//					if(cs.IsDupBillOfValidate(txtBillNo.Text.Trim(),out err))
//					{
//						MessageBox.Show("收油核对单号已经存在，请重新输入！","系统提示",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
//						return false;
//					}
//				}
//			}

			if(txtOutNo.Text.Trim()==""&&ddlInType.SelectedValue=="调拨入库")
			{
				this.Popup("出库单号不能为空！");
				return false;
			}

			if(txtOriginalCount.Text.Trim()=="")
			{
				Popup("原发数不能为空或为0！");
				return false;
			}
			if(txtValidateCount.Text.Trim()=="")
			{
				Popup("验收数不能为空或为0！");
				return false;
			}
			if(txtDistance.Text.Trim()=="")
			{
				Popup("运输公里数不能为空！");
				return false;
			}
			if(txtTransportLose.Text.Trim()==""||txtTransportLose.Text.Trim()=="请点击此处...")
			{
				Popup("请点击运输损耗定额！");
				return false;
			}
			if(txtProvideAddress.Text.Trim()=="")
			{
				Popup("发油地点不能为空！");
				return false;
			}

			if(double.Parse(txtQuterLose.Text.Trim())<0)
			{
				Popup("超定额运输损耗不能为负！");
				return false;
			}
			return true;
		}

		private void txtOriginalCount_TextChanged(object sender, System.EventArgs e)
		{
			if(txtOriginalCount.Text.Trim()!=""&&txtValidateCount.Text.Trim()!="")
			{
				double dori=double.Parse(txtOriginalCount.Text.Trim());
				double dval=double.Parse(txtValidateCount.Text.Trim());

				double dlose=dori-dval;
				txtLose.Text=(Math.Round(dlose,2)).ToString();
			}

			if(txtOriginalCount.Text.Trim()!=""&&txtTransportLose.Text.Trim()!=""&&txtTransportLose.Text.Trim()!="请点击此处...")
			{
				double dori=double.Parse(txtOriginalCount.Text.Trim());
				double dtranl=double.Parse(txtTransportLose.Text.Trim())/100;

				double dql=dori*dtranl;
				txtQuotaLose.Text=(Math.Round(dql,0)).ToString();
			}
		}

		private void txtValidateCount_TextChanged(object sender, System.EventArgs e)
		{
			if(txtOriginalCount.Text.Trim()!=""&&txtValidateCount.Text.Trim()!="")
			{
				double dori=double.Parse(txtOriginalCount.Text.Trim());
				double dval=double.Parse(txtValidateCount.Text.Trim());

				double dlose=dori-dval;
				txtLose.Text=(Math.Round(dlose,2)).ToString();
			}
		}

		private void txtTransportLose_TextChanged(object sender, System.EventArgs e)
		{
			if(txtOriginalCount.Text.Trim()!=""&&txtTransportLose.Text.Trim()!=""&&txtTransportLose.Text.Trim()!="请点击此处...")
			{
				double dori=double.Parse(txtOriginalCount.Text.Trim());
				double dtranl=double.Parse(txtTransportLose.Text.Trim())/100;

				double dql=dori*dtranl;
				txtQuotaLose.Text=(Math.Round(dql,0)).ToString();
			}
		}

		private void txtLose_TextChanged(object sender, System.EventArgs e)
		{
			if(txtLose.Text.Trim()!=""&&txtQuotaLose.Text.Trim()!="")
			{
				double dlose=double.Parse(txtLose.Text.Trim());
				double dql=double.Parse(txtQuotaLose.Text.Trim());

				double dql2=dlose-dql;
				if(dql2<0)
				{
					txtQuterLose.Text="0";
				}
				else
				{
					txtQuterLose.Text=(Math.Round(dql2,0)).ToString();
				}
			}
		}

		private void txtQuotaLose_TextChanged(object sender, System.EventArgs e)
		{
			if(txtLose.Text.Trim()!=""&&txtQuotaLose.Text.Trim()!="")
			{
				double dlose=double.Parse(txtLose.Text.Trim());
				double dql=double.Parse(txtQuotaLose.Text.Trim());

				double dql2=dlose-dql;
				if(dql2<0)
				{
					txtQuterLose.Text="0";
				}
				else
				{
					txtQuterLose.Text=(Math.Round(dql2,0)).ToString();
				}
			}
		}

		private void txtDistance_TextChanged(object sender, System.EventArgs e)
		{
			//txtDistance.Focus();
			double dTransLoseT = this.GetTranLose();
			double dOffSetT = this.GetOffSet();
			double dTransLose = 0.01;
			double doffset = 0.3;
			if(dTransLoseT>0)
				dTransLose = dTransLoseT;
			if(dOffSetT>0)
				doffset = dOffSetT;			
			if(txtDistance.Text.Trim()!=""&&txtDistance.Text.Trim()!="0")
			{
				double ddis=double.Parse(txtDistance.Text.Trim());
				int ratedis=int.Parse(Math.Round((ddis/50),0).ToString());
				double dtranlose=0;
				if(ratedis<=1)
				{
					dtranlose=dTransLose;//0.01;
				}
				else
				{
					dtranlose=ratedis*dTransLose;//0.01;
				}

				if(ratedis*50<ddis)
				{
					dtranlose+=dTransLose;//0.01;
				}
				dtranlose += doffset;//0.3;
				txtTransportLose.Text=dtranlose.ToString("0.00");

				if(txtOriginalCount.Text.Trim()!=""&&txtValidateCount.Text.Trim()!="")
				{
					double dori=double.Parse(txtOriginalCount.Text.Trim());
					double dval=double.Parse(txtValidateCount.Text.Trim());

					double dlose=dori-dval;
					txtLose.Text=(Math.Round(dlose,2)).ToString();
				}

				if(txtOriginalCount.Text.Trim()!=""&&txtTransportLose.Text.Trim()!=""&&txtTransportLose.Text.Trim()!="请点击此处...")
				{
					double dori=double.Parse(txtOriginalCount.Text.Trim());
					double dtranl=double.Parse(txtTransportLose.Text.Trim())/100;

					double dql=dori*dtranl;
					txtQuotaLose.Text=(Math.Round(dql,0)).ToString();
				}

				if(txtLose.Text.Trim()!=""&&txtQuotaLose.Text.Trim()!="")
				{
					double dlose=double.Parse(txtLose.Text.Trim());
					double dql=double.Parse(txtQuotaLose.Text.Trim());

					double dql2=dlose-dql;
					if(dql2<0)
					{
						txtQuterLose.Text="0";
					}
					else
					{
						txtQuterLose.Text=(Math.Round(dql2,0)).ToString();
					}
				}
			}
			else
			{
				this.Popup("请检查运输公里数输入正确！");
				txtTransportLose.Text="请点击此处...";
				return;
			}
		}
	}
}
