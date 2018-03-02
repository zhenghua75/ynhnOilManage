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
	/// wfmAddCompany ��ժҪ˵����
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
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
				throw new Exception("���ܻ�ȡ����λ");
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
					Label1.Text = "��ӵ�λ";
					//Label2.Visible = true;
					Label3.Visible = true;
					Label4.Visible = true;
					
					this.ddlDept.Visible = true;
					this.txtPrepayFee.Visible = true;
					break;
				case "MOD":
					Label1.Text = "�޸ĵ�λ";
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
			busiLog.cnvcComments = "��ӵ�λ��"+txtCompanyName.Text;
			busiLog.cnvcDeptID = curDept.cnvcDeptID;
			busiLog.cnvcDeptName = curDept.cnvcDeptName;
			busiLog.cnvcOperType = "BS011";
			busiLog.cnvcSource = "��վ";

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
			busiLog.cnvcComments = "�޸ĵ�λ��"+txtCompanyName.Text;
			busiLog.cnvcDeptID = curDept.cnvcDeptID;
			busiLog.cnvcDeptName = curDept.cnvcDeptName;
			busiLog.cnvcOperType = "BS012";
			busiLog.cnvcSource = "��վ";

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

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
				case "��ӵ�λ":
					btnAddCompany();
					break;
				case "�޸ĵ�λ":
					btnUpdateCompany();
					break;
			}
		}

		private void btnAddCompany()
		{
			//��ӵ�λ
			if (txtCompanyName.Text.Trim().Length == 0)
			{
				Popup("�����뵥λ����");
				return;
			}

			if (txtPrepayFee.Text.Trim().Length == 0)
			{
				txtPrepayFee.Text = "0";
			}
			if (!IsNumeric(txtPrepayFee.Text.Trim()))
			{
				Popup("��������ȷ���磺22");
				return;
			}
			try
			{
				string strSql = "select * from tbMebCompanyPrepay where cnvcCompanyName = '"+txtCompanyName.Text+"'";
				DataTable dtCompany = ReportQueryFacade.CommonQuery(strSql);
				if (dtCompany.Rows.Count > 0)
				{
					throw new Exception("ͬ����λ�Ѵ��ڣ����������뵥λ���ƣ�");
				}
				AddCompany();
				Popup("��ӵ�λ�ɹ���");
				btnCancel_Click(null,null);
			}
			catch (System.Exception ex)
			{
				Popup(ex.Message);
			}
		}
		private void btnUpdateCompany()
		{
			//��ӵ�λ
			if (txtCompanyName.Text.Trim().Length == 0)
			{
				Popup("�����뵥λ����");
				return;
			}

//			if (txtPrepayFee.Text.Trim().Length == 0)
//			{
//				txtPrepayFee.Text = "0";
//			}
//			if (!IsNumeric(txtPrepayFee.Text.Trim()))
//			{
//				Popup("��������ȷ���磺22");
//				return;
//			}
			try
			{
				string strSql = "select * from tbMebCompanyPrepay where cnvcCompanyName = '"+txtCompanyName.Text+"'";
				DataTable dtCompany = ReportQueryFacade.CommonQuery(strSql);
				if (dtCompany.Rows.Count > 1)
				{
					throw new Exception("ͬ����λ�Ѵ��ڣ����������뵥λ���ƣ�");
				}
				UpdateCompany();
				Popup("�޸ĵ�λ�ɹ���");
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
			
			string strFuncName = this.Server.UrlEncode("��λԤ�漰��ֵ");
			this.Response.Redirect("wfmCompanyPrepay.aspx?FuncName="+strFuncName);
		}  

	}
}
