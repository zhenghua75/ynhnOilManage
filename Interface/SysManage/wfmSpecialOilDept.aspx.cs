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
namespace ynhnOilManage.Interface.SysManage
{
	/// <summary>
	/// wfmSpecialOilDept ��ժҪ˵����
	/// </summary>
	public class wfmSpecialOilDept : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtContactNo;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.DataGrid dgCompany;
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
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.dgCompany.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgCompany_PageIndexChanged);
			this.dgCompany.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgCompany_CancelCommand);
			this.dgCompany.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgCompany_EditCommand);
			this.dgCompany.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgCompany_UpdateCommand);
			this.dgCompany.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgCompany_DeleteCommand);
			this.dgCompany.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgCompany_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			string strFuncName = this.Server.UrlEncode("������õ�λ");
			this.Response.Redirect("wfmSpecialOilDeptAdd.aspx?FuncName="+strFuncName);
		}

		private void dgCompany_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//
			this.dgCompany.EditItemIndex=-1;

			this.BindCompany();
		}

		private void dgCompany_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//
			try
			{
				string strOldContractNo = e.Item.Cells[0].Text;
				string strOldDeliveryCompany = e.Item.Cells[1].Text;

				string strContractNo = ((TextBox)e.Item.Cells[2].Controls[0]).Text;
				string strDeliveryCompany = ((TextBox)e.Item.Cells[3].Controls[0]).Text;
				if (strContractNo.Trim().Length == 0)
				{
					Popup("�������ͬ��ţ�");
					return;
				}
				if (strDeliveryCompany.Trim().Length == 0)
				{
					Popup("�����뵥λ���ƣ�");
					return;
				}
				string strContractSql = "select * from tbSpecialOilDept where cnvcContractNo='"+strContractNo+"' ";
				string strDeliveryCompanySql = "select * from tbSpecialOilDept where cnvcDeliveryCompany = '"+strDeliveryCompany+"'";
				DataTable dtContract = ReportQueryFacade.CommonQuery(strContractSql);
				DataTable dtDeliveryCompany = ReportQueryFacade.CommonQuery(strDeliveryCompanySql);
				if (dtContract.Rows.Count > 0 && strOldContractNo != strContractNo)
				{
					Popup("��ͬ�ĺ�ͬ����Ѵ��ڣ�");
					return;
				}
				if (dtDeliveryCompany.Rows.Count > 0 && strOldDeliveryCompany != strDeliveryCompany)
				{
					Popup("��ͬ�ĵ�λ�����Ѵ��ڣ�");
					return;
				}

				Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
				Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 

				BusiLog busiLog = new BusiLog();
				busiLog.cndOperDate = DateTime.Now;
				busiLog.cnnSerial = Guid.NewGuid();
				busiLog.cnvcOperName = curOper.cnvcOperName;
				busiLog.cnvcComments = "�޸����õ�λ��"+strContractNo+"|"+strDeliveryCompany;
				busiLog.cnvcDeptID = curDept.cnvcDeptID;
				busiLog.cnvcDeptName = curDept.cnvcDeptName;
				busiLog.cnvcOperType = "BS014";
				busiLog.cnvcSource = "��վ";

				SpecialOilDept specialOilDept = new SpecialOilDept();
				specialOilDept.cnvcContractNo = strContractNo;
				specialOilDept.cnvcDeliveryCompany = strDeliveryCompany;
				SpecialOilFacade.UpdateSpecialOilDept(strOldContractNo,specialOilDept,busiLog);
				this.dgCompany.EditItemIndex=-1;

				this.BindCompany();
				Popup("���õ�λ�޸ĳɹ�");
			}
			catch (System.Exception ex)
			{
				Popup(ex.Message);
			}
			
		}

		private void dgCompany_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//
			this.dgCompany.EditItemIndex=(int)e.Item.ItemIndex;

			this.BindCompany();
		}

		private void dgCompany_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			//
			dgCompany.CurrentPageIndex = e.NewPageIndex;
			BindCompany();
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//
			BindCompany();
		}
		private void BindCompany()
		{
			string strSql = "select *,cnvcContractNo as cnvcID,cnvcDeliveryCompany as cnvcName from tbSpecialOilDept where 1=1";
			strSql += " and cnvcContractNo like '%"+txtContactNo.Text+"%'";
			strSql += " and cnvcDeliveryCompany like '%"+txtDeliveryCompany.Text+"%'";
			strSql += " order by cnvcContractNo,cnvcDeliveryCompany";
			DataTable dtCompany = ReportQueryFacade.CommonQuery(strSql);
			this.dgCompany.DataSource = dtCompany;
			this.dgCompany.DataBind();
		}

		private void dgCompany_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//
			if(e.Item.ItemType == ListItemType.Item|| e.Item.ItemType == ListItemType.AlternatingItem)
			{ 
				((LinkButton)(e.Item.Cells[5].Controls[0])).Attributes.Add("onclick","javascript:return confirm('ɾ���󲻿ɻָ�,��ȷ����?');");
			}
		}

		private void dgCompany_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//
			try
			{
				string strContractNo = e.Item.Cells[0].Text;
				string strDeliveryCompany = e.Item.Cells[1].Text;
				

				Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
				Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 

				BusiLog busiLog = new BusiLog();
				busiLog.cndOperDate = DateTime.Now;
				busiLog.cnnSerial = Guid.NewGuid();
				busiLog.cnvcOperName = curOper.cnvcOperName;
				busiLog.cnvcComments = "ɾ�����õ�λ��"+strContractNo+"|"+strDeliveryCompany;
				busiLog.cnvcDeptID = curDept.cnvcDeptID;
				busiLog.cnvcDeptName = curDept.cnvcDeptName;
				busiLog.cnvcOperType = "BS015";
				busiLog.cnvcSource = "��վ";

				SpecialOilDept specialOilDept = new SpecialOilDept();
				specialOilDept.cnvcContractNo = strContractNo;
				specialOilDept.cnvcDeliveryCompany = strDeliveryCompany;
				SpecialOilFacade.DeleteSpecialOilDept(specialOilDept,busiLog);
				this.dgCompany.EditItemIndex=-1;

				this.BindCompany();
				Popup("���õ�λɾ���ɹ�");
			}
			catch (System.Exception ex)
			{
				Popup(ex.Message);
			}
		}
	}
}
