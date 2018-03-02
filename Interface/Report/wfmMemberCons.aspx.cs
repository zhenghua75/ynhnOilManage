#region ����
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
#endregion

namespace ynhnOilManage.Interface.Report
{
	/// <summary>
	/// wfmRetailOilListReport ��ժҪ˵����
	/// </summary>
	public class wfmMemberCons : wfmBase
	{
		#region �ֶ�
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.TextBox txtBeginDate;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.TextBox txtCompanyName;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtDeptName;
		protected ynhnOilManage.Interface.Report.ucPageView UcPageView1;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			//this.btnExcel.Attributes.Add("onclick","javascript:window.open('DataGridToExcel.aspx', 'Sample', 'toolbar=no,location=no,directories=no,status=yes,menubar=yes,scrollbars=no,resizable=yes,copyhistory=yes,width=790,height=520,left=0,top=0')");
			if (!IsPostBack)
			{
				BindDeptAll(ddlDept);
				//BindState(ddlState);
				UcPageView1.DebindGrid();
//				if ( null != Session[ConstValue.LOGIN_DEPT_SESSION])
//				{
//					Dept dept = (Dept)Session[ConstValue.LOGIN_DEPT_SESSION];
//					if (dept.cnvcDeptID != "00")
//					{
//						ListItem li = ddlDept.Items.FindByText(dept.cnvcDeptName);
//						ddlDept.SelectedIndex = ddlDept.Items.IndexOf(li);						
//						ddlDept.Enabled = false;
//					}
//				}
			}
		}

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

		private void BindState(DropDownList ddl)
		{
			DataTable dtState = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign='MemState'");
			ddl.DataSource = dtState;
			ddl.DataTextField = "cnvcCommName";
			ddl.DataValueField = "cnvcCommCode";
			ddl.DataBind();
			ListItem li = new ListItem("����","%");
			ddl.Items.Insert(0,li);
		}
		private DataTable GetData(string strCompanyName,string strDeptID,string strBeginDate,string strEndDate)
		{
			string strSql = "select a.cnvcCompanyName,a.cnvcDeptName,a.cnnFillFee,b.cnnPrepayFee,a.cnvcOperName,a.cndOperDate from tbFillFee a left outer join tbMebCompanyPrepay b on a.cnvcAcctID=b.cnvcAcctID where 1=1";			

			if (strDeptID != "")
			{
				strSql += " and a.cnvcDeptID like '"+strDeptID+"%'" ;
			}
//			if ( null != Session[ConstValue.LOGIN_DEPT_SESSION])
//			{
//				Dept dept = (Dept)Session[ConstValue.LOGIN_DEPT_SESSION];
//				if (dept.cnvcDeptID != "00")
//				{
//					strSql += " and a.cnvcDeptID ='"+dept.cnvcDeptID+"'";
//				}
//			}
			if (strCompanyName != "")
			{
				strSql += " and a.cnvcCompanyName like '%"+strCompanyName+"%'";
			}
			if (strBeginDate != "")
			{
				strSql += " and convert(char(10),a.cndOperDate,120)>='"+strBeginDate+"'" ;
			}
			if (strEndDate != "")
			{
				strSql += " and convert(char(10),a.cndOperDate,120)<='"+strEndDate+"'";
			}	
			strSql += " order by a.cndOperDate desc";
			DataTable dtMember = ReportQueryFacade.CommonQuery(strSql);
			
			double dFillFee = 0.00;
			double dPrepayFee = 0.00;
			foreach(DataRow dr in dtMember.Rows)
			{
				dFillFee += Convert.ToDouble(dr["cnnFillFee"]);
				dPrepayFee += Convert.ToDouble(dr["cnnPrepayFee"]);
			}
			DataRow drNew = dtMember.NewRow();
			drNew["cnvcDeptName"] = "�ϼƣ�";
			drNew["cnnFillFee"] = dFillFee;
			drNew["cnnPrepayFee"] = dPrepayFee;
			dtMember.Rows.Add(drNew);

			dtMember.Columns["cnvcCompanyName"].ColumnName = "��λ����";
			dtMember.Columns["cnvcDeptName"].ColumnName = "ָ������վ";
			dtMember.Columns["cnnFillFee"].ColumnName = "��ֵ���";
			dtMember.Columns["cnnPrepayFee"].ColumnName = "��λ���";
			dtMember.Columns["cnvcOperName"].ColumnName = "����Ա";
			dtMember.Columns["cndOperDate"].ColumnName = "��ֵ����";
			return dtMember;
		}
		
		private void BindGrid(string strCompanyName,string strDeptID,string strBeginDate,string strEndDate)
		{
			

			DataTable dtMember = GetData(strCompanyName,strDeptID,strBeginDate,strEndDate);
			this.UcPageView1.MyDataSource = dtMember.DefaultView;
			this.UcPageView1.BindGrid();
			
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
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{

			BindGrid(txtCompanyName.Text,ddlDept.SelectedValue,this.txtBeginDate.Text,this.txtEndDate.Text);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.txtBeginDate.Text = "";
			this.txtEndDate.Text = "";
			//this.txtCardID.Text = "";
			this.txtCompanyName.Text = "";
			//this.txtDeptName.Text = "";
			//this.txtLicenseTag.Text = "";
			UcPageView1.DebindGrid();
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			//����EXCEL
			//��
			DataTable dtMember = GetData(txtCompanyName.Text,ddlDept.SelectedValue,this.txtBeginDate.Text,this.txtEndDate.Text);
			//Session["QUERY"] = dtMember;
			string strMember = this.ExportTable(dtMember);
			//ͷ
			string strCaption = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strCaption += "<tr><td align=center colspan=6>"+CommonStatic.EnterpriseFullName()+"</td></tr>";
			strCaption += "<tr><td align=center colspan=6>��Ա��ֵ����</td></tr>";
			strCaption += "<tr><td align=center colspan=6>"+DateTime.Now.ToString("yyyy��MM��dd��")+"</td></tr>";
			strCaption += "</table>";
			//Session["ExcelCaption"] = strCaption;
			//��
			string strBottom = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strBottom += "<tr>";
			strBottom += "<td align=center colspan=2>�������ܣ�</td>";
			strBottom += "<td align=center colspan=2>��ˣ�</td>";
			strBottom += "<td align=center colspan=2>�Ʊ�</td></tr>";
			strBottom += "</table>";
			//Session["ExcelBottom"] = strBottom;
			this.ExportToXls(this,"��Ա��ֵ����",strCaption+strMember+strBottom);
		}
	}
}
