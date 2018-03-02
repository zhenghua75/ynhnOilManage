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
	public class wfmSpecialOilSumReport : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.TextBox txtBeginDate;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.Button btnExcel;
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
		private DataTable GetData(string strDeptID,string strDeptName,string strBeginDate,string strEndDate)
		{
			string strSql = "select '' as cnnID,cnvcDeliveryCompany,cnvcContractNo,cnvcGoodsName,cnvcGoodsType,cnvcUnit,sum(cnnCount) as cnnCount,cnnSpecialUnitPrice,sum(cnnSpecialFee) as cnnSpecialFee,'' as cnvcComments  from tbBillOfMaterials  where cnvcDeptID like '"+strDeptID+"%'";
			if (strBeginDate != "")
			{
				strSql += " and cndDeliveryDate>='"+strBeginDate+"'" ;
			}
			if (strEndDate != "")
			{
				strSql += " and cndDeliveryDate<='"+strEndDate+"'";
			}
			strSql += " group by cnvcDeliveryCompany,cnvcContractNo,cnvcGoodsName,cnvcGoodsType,cnvcUnit,cnnSpecialUnitPrice order by cnvcContractNo,cnvcGoodsType";
			DataTable dtBillOfMaterials = ReportQueryFacade.CommonQuery(strSql);
			//��ϼ�
			double dCount = 0.00;
			double dFee = 0.00; 
			int i = 0;
			foreach (DataRow drBillOfMaterials in dtBillOfMaterials.Rows)
			{
				dCount += double.Parse(drBillOfMaterials["cnnCount"].ToString());
				dFee += double.Parse(drBillOfMaterials["cnnSpecialFee"].ToString());		
				i++;
				drBillOfMaterials["cnnID"] = i;
			}
			DataRow drNew = dtBillOfMaterials.NewRow();
			drNew["cnvcDeliveryCompany"] = "�ϼ�";
			drNew["cnnCount"] = dCount;
			drNew["cnnSpecialFee"] = dFee;
			dtBillOfMaterials.Rows.Add(drNew);
			dtBillOfMaterials.Columns["cnnID"].ColumnName = "���";
			dtBillOfMaterials.Columns["cnvcContractNo"].ColumnName = "��ͬ���";
			dtBillOfMaterials.Columns["cnvcDeliveryCompany"].ColumnName = "���õ�λ";
			dtBillOfMaterials.Columns["cnvcGoodsName"].ColumnName = "��������";
			dtBillOfMaterials.Columns["cnvcGoodsType"].ColumnName = "����ͺ�";
			dtBillOfMaterials.Columns["cnvcUnit"].ColumnName = "��λ";
			dtBillOfMaterials.Columns["cnnCount"].ColumnName = "��Ӧ����";
			dtBillOfMaterials.Columns["cnnSpecialUnitPrice"].ColumnName = "ר�����ۣ�Ԫ��";
			dtBillOfMaterials.Columns["cnnSpecialFee"].ColumnName = "ר����Ԫ��";
			dtBillOfMaterials.Columns["cnvcComments"].ColumnName = "��ע";
			return dtBillOfMaterials;
		}
		private void BindGrid(string strDeptID,string strDeptName,string strBeginDate,string strEndDate)
		{
			
			DataTable dtBillOfMaterials = GetData(strDeptID,strDeptName,strBeginDate,strEndDate);
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

			BindGrid(this.ddlDept.SelectedValue,this.ddlDept.SelectedItem.Text,this.txtBeginDate.Text,this.txtEndDate.Text);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.txtBeginDate.Text = "";
			this.txtEndDate.Text = "";
			UcPageView1.DebindGrid();
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			//����EXCEL
			DataTable dtBillOfMaterials = GetData(this.ddlDept.SelectedValue,this.ddlDept.SelectedItem.Text,this.txtBeginDate.Text,this.txtEndDate.Text);
			//��
			//Session["QUERY"] = dtBillOfMaterials;
			string strBillOfMaterials = this.ExportTable(dtBillOfMaterials);
			//ͷ
			string strCaption = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strCaption += "<tr><td align=center colspan=10>"+CommonStatic.EnterpriseFullName()+"</td></tr>";
			strCaption += "<tr><td align=center colspan=10>"+ddlDept.SelectedItem.Text+"ר���������ۻ��ܱ�</td></tr>";
			strCaption += "<tr><td align=center colspan=10>"+DateTime.Now.ToString("yyyy��MM��dd��")+"</td></tr>";
			strCaption += "<tr><td align=left colspan=3></td><td></td><td></td><td colspan=3></td><td align=center>��λ��Ԫ</td><td></td></tr>";
			strCaption += "</table>";
			//Session["ExcelCaption"] = strCaption;
			//��
			string strBottom = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strBottom += "<tr><td></td>";
			strBottom += "<td align=center>�������ܣ�</td>";
			strBottom += "<td></td><td></td>";
			strBottom += "<td align=center>��ˣ�</td>";
			strBottom += "<td></td><td></td><td></td><td>�Ʊ�</td><td></td></tr>";
			strBottom += "<tr><td colspan=10>����һʽ���ݣ����ʹ�˾����һ�ݣ����ʹ�˾ҵ��һ�ݣ�����վҵ������һ�ݡ�</td></tr></table>";
			//Session["ExcelBottom"] = strBottom;
			this.ExportToXls(this,ddlDept.SelectedItem.Text+"ר���������ۻ��ܱ�",strCaption+strBillOfMaterials+strBottom);
		}
	}
}
