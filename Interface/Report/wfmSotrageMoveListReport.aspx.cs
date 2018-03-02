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
	public class wfmSotrageMoveListReport : wfmBase
	{
		#region �ֶ�
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.TextBox txtBeginDate;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.DropDownList ddlProvideCompany;
		protected System.Web.UI.WebControls.DropDownList ddlDeliveryCompany;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.Label Label3;
		protected ynhnOilManage.Interface.Report.ucPageView UcPageView1;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			//this.btnExcel.Attributes.Add("onclick","javascript:window.open('DataGridToExcel.aspx', 'Sample', 'toolbar=no,location=no,directories=no,status=yes,menubar=yes,scrollbars=no,resizable=yes,copyhistory=yes,width=790,height=520,left=0,top=0')");
			if (!IsPostBack)
			{
				//BindDeptAll(ddlDeliveryCompany);
				//BindDeptAll(ddlProvideCompany);
				BindDept(ddlDeliveryCompany,"����","%");
				BindDept(ddlProvideCompany,"����","%");
				UcPageView1.DebindGrid();

//				if ( null != Session[ConstValue.LOGIN_DEPT_SESSION])
//				{
//					Dept dept = (Dept)Session[ConstValue.LOGIN_DEPT_SESSION];
//					if (dept.cnvcDeptID != "00")
//					{
////						ListItem li = ddlDeliveryCompany.Items.FindByText(dept.cnvcDeptName);
////						ddlDeliveryCompany.SelectedIndex = ddlDeliveryCompany.Items.IndexOf(li);						
////						ddlDeliveryCompany.Enabled = false;
//
//						ListItem li2 = ddlProvideCompany.Items.FindByText(dept.cnvcDeptName);
//						ddlProvideCompany.SelectedIndex = ddlProvideCompany.Items.IndexOf(li2);						
//						ddlProvideCompany.Enabled = false;
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
		private DataTable GetData(string strDeliveryCompany,string strProvideCompany,string strBeginDate,string strEndDate)
		{
			//string strSql = "select '' as cnnID,cnvcDeliveryCompany,cnvcContractNo,cnvcGoodsName,cnvcGoodsType,cnvcUnit,sum(cnnCount) as cnnCount,cnnSpecialUnitPrice,sum(cnnSpecialFee) as cnnSpecialFee,'' as cnvcComments  from tbBillOfMaterials  where cnvcProvideCompany = '"+strDeptName+"'";
			string strSql = " select '' as cnnID,'����' as cnvcProvideType,a.cnvcProvideStroage,a.cnvcDeliveryCompany,a.cnvcUnit,a.cnvcGoodsName+a.cnvcGoodsType as cnvcNameType,a.cnnReceivableCount,a.cnnCount,a.cnvcTransportLiscenseTags,a.cnvcMoveNo,a.cnvcOperName,a.cndOperDate,a.cnvcComments,  "
				+ " '{0}FuncName={1}&BillNo='+a.cnvcBillNo+'&DeptID='+a.cnvcDeptID+'{2}' as cnvcMod "
				+ " from tbBillOfOutStorage a "
				//+ " join  tbBillOfValidate b on a.cnvcBillNo=b.cnvcOutNo "
				+ " where a.cnvcOutType='��������'";// and b.cnvcInType = '�������' ";



			if (strDeliveryCompany != "" )
			{
				strSql += " and a.cnvcDeliveryDeptID like '"+strDeliveryCompany+"%'" ;
			}
			if (strProvideCompany != "" )
			{
				strSql += " and a.cnvcDeptID like '"+strProvideCompany+"%'" ;
			}
			if (strBeginDate != "")
			{
				strSql += " and a.cndOutStorageDate>='"+strBeginDate+"'" ;
			}
			if (strEndDate != "")
			{
				strSql += " and a.cndOutStorageDate<='"+strEndDate+"'";
			}
			strSql += " order by cndOperDate desc";
			DataTable dtBillOfMove = ReportQueryFacade.CommonQuery(strSql);
			//��ϼ�
			double dReceivableCount = 0.00;
			double dCount = 0.00; 
			int i = 0;
			foreach (DataRow drBillOfMove in dtBillOfMove.Rows)
			{
				dReceivableCount += double.Parse(drBillOfMove["cnnReceivableCount"].ToString());
				dCount += double.Parse(drBillOfMove["cnnCount"].ToString());		
				i++;
				drBillOfMove["cnnID"] = i;
			}
			DataRow drNew = dtBillOfMove.NewRow();
			drNew["cnvcProvideStroage"] = "����";
			drNew["cnnReceivableCount"] = dReceivableCount;
			drNew["cnnCount"] = dCount;
			dtBillOfMove.Rows.Add(drNew);
			dtBillOfMove.Columns["cnnID"].ColumnName = "���";
			dtBillOfMove.Columns["cnvcProvideType"].ColumnName = "��Ӧ��ʽ";
			dtBillOfMove.Columns["cnvcProvideStroage"].ColumnName = "�����Ϳ�";
			dtBillOfMove.Columns["cnvcDeliveryCompany"].ColumnName = "�����Ϳ�";
			dtBillOfMove.Columns["cnvcUnit"].ColumnName = "��λ";			
			dtBillOfMove.Columns["cnnReceivableCount"].ColumnName = "֪ͨ��������";
			dtBillOfMove.Columns["cnnCount"].ColumnName = "ʵ�ʵ�������";
			dtBillOfMove.Columns["cnvcTransportLiscenseTags"].ColumnName = "���䳵�����ƺ�";
			dtBillOfMove.Columns["cnvcMoveNo"].ColumnName = "�����͵���֪ͨ������";
			dtBillOfMove.Columns["cnvcOperName"].ColumnName = "����Ա";
			dtBillOfMove.Columns["cndOperDate"].ColumnName = "����ʱ��";
			dtBillOfMove.Columns["cnvcComments"].ColumnName = "��ע";
			dtBillOfMove.Columns["cnvcNameType"].ColumnName = "�ͺŹ��";
			dtBillOfMove.Columns["cnvcMod"].ColumnName = "�޸�";
			return dtBillOfMove;
		}
		private void BindGrid(string strDeliveryCompany,string strProvideCompany,string strBeginDate,string strEndDate)
		{
			
			DataTable dtBillOfMove = GetData(strDeliveryCompany,strProvideCompany,strBeginDate,strEndDate);
			foreach(DataRow dr in dtBillOfMove.Rows)
			{
				string strmod = dr["�޸�"].ToString();
				dr["�޸�"] = string.Format(strmod,"<a href='wfmSotrageMoveListMod.aspx?",this.Server.UrlEncode("�޸ĵ�����"),"' target='_self'>�޸�</a>");
			}

			this.UcPageView1.MyDataSource = dtBillOfMove.DefaultView;
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

			BindGrid(this.ddlDeliveryCompany.SelectedValue,this.ddlProvideCompany.SelectedValue,this.txtBeginDate.Text,this.txtEndDate.Text);
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
			//��
			DataTable dtBillOfMove = this.GetData(this.ddlDeliveryCompany.SelectedValue,this.ddlProvideCompany.SelectedValue,this.txtBeginDate.Text,this.txtEndDate.Text);
			dtBillOfMove.Columns.Remove("�޸�");
			string strBillOfMove = this.ExportTable(dtBillOfMove);
			//Session["QUERY"] = dtBillOfMove;

			//ͷ
			string strCaption = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strCaption += "<tr><td align=center colspan=13>"+CommonStatic.EnterpriseFullName()+"</td></tr>";
			strCaption += "<tr><td align=center colspan=13>��������͵�����ϸ����</td></tr>";
			strCaption += "<tr><td align=left colspan=13>���λ��</td></tr>";			
			strCaption += "</table>";
			//Session["ExcelCaption"] = strCaption;
			//��
			string strBottom = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strBottom += "<tr>";
			strBottom += "<td align=center colspan=3>��λ���ܣ�</td>";
			strBottom += "<td></td>";
			strBottom += "<td colspan=3>ҵ�����ܣ�</td>";
			strBottom += "<td align=center colspan=3>��ˣ�</td>";
			strBottom += "<td colspan=3>�Ʊ�</td></tr>";
			
			strBottom += "<tr><td colspan=13 align=right>�������ڣ�"+DateTime.Now.ToString("yyyy��MM��dd��")+"</td></tr></table>";
			//Session["ExcelBottom"] = strBottom;
			this.ExportToXls(this,"��������͵�����ϸ����",strCaption+strBillOfMove+strBottom);
		}
	}
}
