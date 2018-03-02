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
	public class wfmSpecialOilListReport : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.TextBox txtBeginDate;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtDeliveryCompany;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtContractNo;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected ynhnOilManage.Interface.Report.ucPageView UcPageView1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			//this.btnExcel.Attributes.Add("onclick","javascript:window.open('DataGridToExcel.aspx', 'Sample', 'toolbar=no,location=no,directories=no,status=yes,menubar=yes,scrollbars=no,resizable=yes,copyhistory=yes,width=790,height=520,left=0,top=0')");
			if (!IsPostBack)
			{
				BindDeptAll(ddlDept);
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
		private DataTable GetData(string strDeptID,string strDeptName,string strBeginDate,string strEndDate,string strDeliveryCompany,
			string strContractNo,ref string strDeliveryCompanyFact,ref string strContractNoFact)
		{
			string strSql = "select cnvcBillNo,cnvcGoodsName,cnvcGoodsType,cnvcUnit,cnnCount,cnnSpecialUnitPrice,cnnSpecialFee,'' as cnvcComments,cnvcDeliveryCompany,cnvcContractNo,cndDeliveryDate,cnvcOperName,cndOperDate,"
				+ " '{0}FuncName={1}&BillNo='+cnvcBillNo+'&DeptID='+cnvcDeptID+'{2}' as cnvcMod "
				+"  from tbBillOfMaterials where cnvcDeptID like '"+strDeptID+"%'";
			if (strBeginDate != "")
			{
				strSql += " and cndDeliveryDate>='"+strBeginDate+"'" ;
			}
			if (strEndDate != "")
			{
				strSql += " and cndDeliveryDate<='"+strEndDate+"'";
			}
			if (strDeliveryCompany != "")
			{
				strSql += " and cnvcDeliveryCompany like '%"+strDeliveryCompany+"%'";
			}
			if (strContractNo != "")
			{
				strSql += " and cnvcContractNo = '"+strContractNo+"'";
			}
			strSql += " order by cndOperDate desc";
			DataTable dtBillOfMaterials = ReportQueryFacade.CommonQuery(strSql);
			//��ϼ�
			double dCount = 0.00;
			double dFee = 0.00; 
			strDeliveryCompanyFact = "";
			strContractNoFact = "";
			foreach (DataRow drBillOfMaterials in dtBillOfMaterials.Rows)
			{
				dCount += double.Parse(drBillOfMaterials["cnnCount"].ToString());
				dFee += double.Parse(drBillOfMaterials["cnnSpecialFee"].ToString());				
				strDeliveryCompanyFact = drBillOfMaterials["cnvcDeliveryCompany"].ToString();				
				strContractNoFact = drBillOfMaterials["cnvcContractNo"].ToString();				
			}
			DataRow drNew = dtBillOfMaterials.NewRow();
			drNew["cnvcGoodsType"] = "�ϼ�";
			drNew["cnnCount"] = Math.Round(dCount,2);
			drNew["cnnSpecialFee"] = Math.Round(dFee,2);
			dtBillOfMaterials.Rows.Add(drNew);
			dtBillOfMaterials.Columns["cnvcBillNo"].ColumnName = "���ϵ���";
			dtBillOfMaterials.Columns["cnvcGoodsName"].ColumnName = "��������";
			dtBillOfMaterials.Columns["cnvcGoodsType"].ColumnName = "����ͺ�";
			dtBillOfMaterials.Columns["cnvcUnit"].ColumnName = "��λ";
			dtBillOfMaterials.Columns["cnnCount"].ColumnName = "��Ӧ����";
			dtBillOfMaterials.Columns["cnnSpecialUnitPrice"].ColumnName = "ר�����ۣ�Ԫ��";
			dtBillOfMaterials.Columns["cnnSpecialFee"].ColumnName = "ר����Ԫ��";
			dtBillOfMaterials.Columns["cnvcComments"].ColumnName = "��ע";
			dtBillOfMaterials.Columns["cndDeliveryDate"].ColumnName = "���ʱ��";
			dtBillOfMaterials.Columns["cnvcOperName"].ColumnName = "����Ա";
			dtBillOfMaterials.Columns["cndOPerDate"].ColumnName = "����ʱ��";
			dtBillOfMaterials.Columns["cnvcMod"].ColumnName = "�޸�";
			dtBillOfMaterials.Columns.Remove("cnvcDeliveryCompany");
			dtBillOfMaterials.Columns.Remove("cnvcContractNo");
			return dtBillOfMaterials;
		}
		private void BindGrid(string strDeptID,string strDeptName,string strBeginDate,string strEndDate,string strDeliveryCompany,string strContractNo)
		{
			string strDeliveryCompanyFact = "";
			string strContractNoFact = "";
			DataTable dtBillOfMaterials = GetData(strDeptID,strDeptName,strBeginDate,strEndDate,strDeliveryCompany,strContractNo,
				ref strDeliveryCompanyFact,ref strContractNoFact);
			foreach(DataRow dr in dtBillOfMaterials.Rows)
			{
				string strmod = dr["�޸�"].ToString();
				dr["�޸�"] = string.Format(strmod,"<a href='wfmSpecialOilListMod.aspx?",this.Server.UrlEncode("�޸�ר����"),"' target='_self'>�޸�</a>");
			}
			this.UcPageView1.MyDataSource = dtBillOfMaterials.DefaultView;
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

			BindGrid(this.ddlDept.SelectedValue,this.ddlDept.SelectedItem.Text,this.txtBeginDate.Text,this.txtEndDate.Text,this.txtDeliveryCompany.Text,this.txtContractNo.Text);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.txtBeginDate.Text = "";
			this.txtEndDate.Text = "";
			this.txtDeliveryCompany.Text = "";
			this.txtContractNo.Text = "";
			UcPageView1.DebindGrid();
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			//����EXCEL
			//��
			string strDeliveryCompanyFact = "";
			string strContractNoFact = "";
			DataTable dtBillOfMaterials = GetData(this.ddlDept.SelectedValue,this.ddlDept.SelectedItem.Text,
				this.txtBeginDate.Text,this.txtEndDate.Text,this.txtDeliveryCompany.Text,
				this.txtContractNo.Text,ref strDeliveryCompanyFact,ref strContractNoFact);
			dtBillOfMaterials.Columns.Remove("�޸�");
			string strBillOfMaterials = this.ExportTable(dtBillOfMaterials);
			//Session["QUERY"] = dtBillOfMaterials;
			//ͷ
			string strCaption = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strCaption += "<tr><td align=center colspan=11>"+CommonStatic.EnterpriseFullName()+"</td></tr>";
			strCaption += "<tr><td align=center colspan=11>"+ddlDept.SelectedItem.Text+"ר������������ϸ��</td></tr>";
			strCaption += "<tr><td align=center colspan=11>"+DateTime.Now.ToString("yyyy��MM��dd��")+"</td></tr>";
			strCaption += "<tr><td align=left colspan=4>"+"���õ�λ��"+strDeliveryCompanyFact+"</td><td colspan=4>��ͬ��ţ�"+strContractNoFact+"</td><td align=center colspan=2>��λ��Ԫ</td><td></td></tr>";
			strCaption += "</table>";
			//Session["ExcelCaption"] = strCaption;
			//��
			string strBottom = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strBottom += "<tr><td></td>";
			strBottom += "<td align=center colspan=2>�������ܣ�</td>";
			strBottom += "<td></td><td></td>";
			strBottom += "<td align=center colspan=2>��ˣ�</td>";
			strBottom += "<td></td><td colspan=2>�Ʊ�</td><td></td></tr>";
			strBottom += "<tr><td colspan=11>����һʽ�ķݣ����ʹ�˾����һ�ݣ������ϵ��������ʹ�˾ҵ��һ�ݣ�һ���빩����Ʊһ��ת���õ�λ�������ϵ���������վҵ������һ�ݣ������ϵ�����</td></tr></table>";
			//Session["ExcelBottom"] = strBottom;
			this.ExportToXls(this,ddlDept.SelectedItem.Text+"ר������������ϸ��",strCaption+strBillOfMaterials+strBottom);
		}
	}
}
