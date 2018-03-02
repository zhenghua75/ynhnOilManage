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

using ynhnOilManage.BusinessFacade.SysManage;
using ynhnOilManage.BusinessFacade.Report;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.Common;

namespace ynhnOilManage.Interface.SysManage
{
	/// <summary>
	/// Summary description for wfmAuthorization.
	/// Ȩ���޸�
	/// </summary>
	public class wfmAuthorization : wfmBase
	{
		protected System.Web.UI.WebControls.RadioButtonList rblOper;
		protected System.Web.UI.WebControls.ImageButton btnOK;
		protected System.Web.UI.WebControls.ImageButton btnCancel;
		protected System.Web.UI.WebControls.CheckBoxList cblCSFunctionList;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.CheckBoxList cblFunctionList;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				//��ʼ������Ա�б�
				//FillOperRbl();
				BindDeptAll(ddlDept);
				FillFunctionCbl();
				ddlDept_SelectedIndexChanged(null,null);

			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.ddlDept.SelectedIndexChanged += new System.EventHandler(this.ddlDept_SelectedIndexChanged);
			this.rblOper.SelectedIndexChanged += new System.EventHandler(this.rblOper_SelectedIndexChanged);
			this.btnOK.Click += new System.Web.UI.ImageClickEventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.Web.UI.ImageClickEventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

//		private void BindDept(DropDownList ddl)
//		{
//			DataTable dtDept = DeptFacade.GetAllDept();
//			ddl.DataSource = dtDept;
//			ddl.DataTextField = "cnvcDeptName";
//			ddl.DataValueField = "cnvcDeptID";
//			ddl.DataBind();
//			ListItem li = new ListItem("����","%");
//			ddl.Items.Insert(0,li);
//		}
		private void rblOper_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				//���¹������
				//�����ѡ��Ĺ���
				foreach (ListItem liFunctionList in this.cblFunctionList.Items)
				{
					if (liFunctionList.Selected)
					{
						liFunctionList.Selected = false;
					}
				}
				foreach (ListItem liFunctionList in this.cblCSFunctionList.Items)
				{
					if (liFunctionList.Selected)
					{
						liFunctionList.Selected = false;
					}
				}
				//ѡ��Ĳ���Ա
				string strOperID = this.rblOper.SelectedValue;
				//��ѯĳ����Ա�Ѿ��еĹ���
				DataTable dtOperFunc = OperFacade.GetOneOperFuncList(strOperID);

				foreach (ListItem liFunctionList in this.cblFunctionList.Items)
				{					
					foreach (DataRow drOperFunc in dtOperFunc.Rows)
					{
						if (drOperFunc["cnvcFuncName"].ToString().Equals(liFunctionList.Text))
						{
							liFunctionList.Selected = true;
						}
					}
				}

				foreach (ListItem liFunctionList in this.cblCSFunctionList.Items)
				{					
					foreach (DataRow drOperFunc in dtOperFunc.Rows)
					{
						if (drOperFunc["cnvcFuncName"].ToString().Equals(liFunctionList.Text))
						{
							liFunctionList.Selected = true;
						}
					}
				}
			}
			catch (BusinessException bex)
			{
				Popup(bex.Message);
			}
			

		}

		private void FillOperRbl(string strDeptID)
		{			
			try
			{
				//DataTable dtAllOper = OperFacade.GetAllOperNoAdmin();
				DataTable dtOper = ReportQueryFacade.CommonQuery("select * from tbOper where cnvcOperName <>'admin' and cnvcDeptID like '"+strDeptID+"%' order by cnvcOperName");
				rblOper.DataSource = dtOper;
				rblOper.DataTextField = "cnvcOperName";
				rblOper.DataValueField = "cnnOperID";

				rblOper.DataBind();
			}
			catch (BusinessException bex)
			{
				Popup(bex.Message);
			}
			
		}

		private void FillFunctionCbl()
		{
			try
			{
				DataTable dtBSFunction = ReportQueryFacade.CommonQuery("select * from tbFunc where cnvcFuncType='BS' order by cnvcFuncName");
				DataTable dtCSFunction = ReportQueryFacade.CommonQuery("select * from tbFunc where cnvcFuncType='CS' order by cnvcFuncName");

				cblFunctionList.DataSource = dtBSFunction;
				cblFunctionList.DataTextField = "cnvcFuncName";
				cblFunctionList.DataValueField = "cnvcFuncAddress";		

				cblFunctionList.DataBind();

				cblCSFunctionList.DataSource = dtCSFunction;
				cblCSFunctionList.DataTextField = "cnvcFuncName";
				cblCSFunctionList.DataValueField = "cnvcFuncAddress";		

				cblCSFunctionList.DataBind();
			}
			catch (BusinessException bex)
			{
				Popup(bex.Message);
			}
			
		}

		private void btnCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//��ʼ������Ա�͹����б�
			foreach (ListItem liOper in rblOper.Items)
			{
				liOper.Selected = false;
			}
			foreach (ListItem liFunctionList in cblFunctionList.Items)
			{
				liFunctionList.Selected = false;
			}
			foreach (ListItem liFunctionList in cblCSFunctionList.Items)
			{
				liFunctionList.Selected = false;
			}
		}

		private void btnOK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				//���¹����б�
				if (rblOper.SelectedValue == "")
				{
					throw new BusinessException("tbOper","��ѡ�����Ա��");
				}
				string strOperID = rblOper.SelectedValue;
				//��ѯĳ����Ա�Ѿ��еĹ���
				DataTable dtHaveOperFunc = OperFacade.GetOneOperFuncList(strOperID);

				Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
				Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 
				BusiLog busiLog = new BusiLog();
				busiLog.cndOperDate = DateTime.Now;
				
				busiLog.cnvcOperName = curOper.cnvcOperName;
				
				busiLog.cnvcDeptID = curDept.cnvcDeptID;
				busiLog.cnvcDeptName = curDept.cnvcDeptName;
				
				busiLog.cnvcSource = "��վ";

				foreach (ListItem liOperFunc in cblFunctionList.Items)
				{
					if (liOperFunc.Selected)
					{
						OperFunc operFunc = new OperFunc();							
						operFunc.cnnOperID = int.Parse(strOperID);
						operFunc.cnvcFuncName = liOperFunc.Text;
						operFunc.cnvcFuncAddress = liOperFunc.Value;

						bool bIsAdd = true;

						if (dtHaveOperFunc.Rows.Count > 0)
						{
							foreach (DataRow drHaveOperFunc in dtHaveOperFunc.Rows)
							{
								//���еĲ�������
								if (drHaveOperFunc["cnvcFuncName"].ToString().Equals(liOperFunc.Text))
								{
									bIsAdd = false;
							
								}
							}
						}
						if(bIsAdd)
						{
							busiLog.cnnSerial = Guid.NewGuid();
							busiLog.cnvcComments = "���Ȩ�ޣ�"+operFunc.cnvcFuncName;
							busiLog.cnvcOperType = "BS009";
							OperFacade.AddOperFunc(operFunc,busiLog);
						}										
					}
					else
					{
						//���е�ȡ���˵�ɾ��
						foreach (DataRow drHaveOperFunc in dtHaveOperFunc.Rows)
						{
							if (dtHaveOperFunc.Rows.Count > 0)
							{
								if (drHaveOperFunc["cnvcFuncName"].ToString().Equals(liOperFunc.Text))
								{
									OperFunc operFunc = new OperFunc();							
									operFunc.cnnOperID = int.Parse(strOperID);
									operFunc.cnvcFuncName = liOperFunc.Text;
									operFunc.cnvcFuncAddress = liOperFunc.Value;
							
									busiLog.cnnSerial = Guid.NewGuid();
									busiLog.cnvcComments = "ɾ��Ȩ��Ȩ�ޣ�"+operFunc.cnvcFuncName;
									busiLog.cnvcOperType = "BS010";
									OperFacade.DeleteOperFunc(operFunc,busiLog);
								}
							}
							
						}
					}
				}

				foreach (ListItem liOperFunc in cblCSFunctionList.Items)
				{
					if (liOperFunc.Selected)
					{
						OperFunc operFunc = new OperFunc();							
						operFunc.cnnOperID = int.Parse(strOperID);
						operFunc.cnvcFuncName = liOperFunc.Text;
						operFunc.cnvcFuncAddress = liOperFunc.Value;

						bool bIsAdd = true;

						if (dtHaveOperFunc.Rows.Count > 0)
						{
							foreach (DataRow drHaveOperFunc in dtHaveOperFunc.Rows)
							{
								//���еĲ�������
								if (drHaveOperFunc["cnvcFuncName"].ToString().Equals(liOperFunc.Text))
								{
									bIsAdd = false;
							
								}
							}
						}
						if(bIsAdd)
						{
							busiLog.cnnSerial = Guid.NewGuid();
							busiLog.cnvcComments = "���Ȩ�ޣ�"+operFunc.cnvcFuncName;
							busiLog.cnvcOperType = "BS009";
							OperFacade.AddOperFunc(operFunc,busiLog);
						}										
					}
					else
					{
						//���е�ȡ���˵�ɾ��
						foreach (DataRow drHaveOperFunc in dtHaveOperFunc.Rows)
						{
							if (dtHaveOperFunc.Rows.Count > 0)
							{
								if (drHaveOperFunc["cnvcFuncName"].ToString().Equals(liOperFunc.Text))
								{
									OperFunc operFunc = new OperFunc();							
									operFunc.cnnOperID = int.Parse(strOperID);
									operFunc.cnvcFuncName = liOperFunc.Text;
									operFunc.cnvcFuncAddress = liOperFunc.Value;
							
									busiLog.cnnSerial = Guid.NewGuid();
									busiLog.cnvcComments = "ɾ��Ȩ��Ȩ�ޣ�"+operFunc.cnvcFuncName;
									busiLog.cnvcOperType = "BS010";
									OperFacade.DeleteOperFunc(operFunc,busiLog);
								}
							}
							
						}
					}
				}
				Popup("Ȩ���޸ĳɹ���");
			}
			catch (BusinessException bex)
			{
				Popup(bex.Message);
			}
			
			
		}

		private void ddlDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//ˢ��
			FillOperRbl(ddlDept.SelectedValue);
		}

	}
}
