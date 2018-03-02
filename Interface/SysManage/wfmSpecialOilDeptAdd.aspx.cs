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
	/// wfmSpecialOilDeptAdd ��ժҪ˵����
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
			// �ڴ˴������û������Գ�ʼ��ҳ��
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

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			string strFuncName = this.Server.UrlEncode("ר�������õ�λ����");
			this.Response.Redirect("wfmSpecialOilDept.aspx?FuncName="+strFuncName);
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			//���

			if (txtContactNo.Text.Trim().Length == 0)
			{
				Popup("�������ͬ��ţ�");
				return;
			}
			if (txtDeliveryCompany.Text.Trim().Length == 0)
			{
				Popup("�����뵥λ���ƣ�");
				return;
			}
			string strContractSql = "select * from tbSpecialOilDept where cnvcContractNo='"+txtContactNo.Text+"' ";
			string strDeliveryCompany = "select * from tbSpecialOilDept where cnvcDeliveryCompany = '"+txtDeliveryCompany.Text+"'";
			DataTable dtContract = ReportQueryFacade.CommonQuery(strContractSql);
			DataTable dtDeliveryCompany = ReportQueryFacade.CommonQuery(strDeliveryCompany);
			if (dtContract.Rows.Count > 0)
			{
				Popup("��ͬ�ĺ�ͬ����Ѵ��ڣ�");
				return;
			}
			if (dtDeliveryCompany.Rows.Count > 0)
			{
				Popup("��ͬ�ĵ�λ�����Ѵ��ڣ�");
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
			busiLog.cnvcComments = "������õ�λ��"+txtContactNo.Text+"|"+txtDeliveryCompany.Text;
			busiLog.cnvcDeptID = curDept.cnvcDeptID;
			busiLog.cnvcDeptName = curDept.cnvcDeptName;
			busiLog.cnvcOperType = "BS013";
			busiLog.cnvcSource = "��վ";

			SpecialOilFacade.AddSpecialOilDept(specialOilDept,busiLog);
			Popup("���õ�λ��ӳɹ�");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			//ȡ��
			this.txtContactNo.Text = "";
			this.txtDeliveryCompany.Text = "";
		}
	}
}
