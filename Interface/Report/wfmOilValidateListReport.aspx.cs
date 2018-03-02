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
	public class wfmOilValidateListReport : wfmBase
	{
		#region �ֶ�
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlProvideCompany;
		protected System.Web.UI.WebControls.DropDownList ddlDeliveryCompany;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtProvideBeginDate;
		protected System.Web.UI.WebControls.TextBox txtDeliveryBeginDate;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtProvideEndDate;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtDeliveryEndDate;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList ddlGoodsName;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.DropDownList ddlGoodsType;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtBillNo;
		protected ynhnOilManage.Interface.Report.ucPageView UcPageView1;
		#endregion

		#region page_load
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			//this.btnExcel.Attributes.Add("onclick","javascript:window.open('DataGridToExcel.aspx', 'Sample', 'toolbar=no,location=no,directories=no,status=yes,menubar=yes,scrollbars=no,resizable=yes,copyhistory=yes,width=790,height=520,left=0,top=0')");
			if (!IsPostBack)
			{
				//BindDeptAll(ddlProvideCompany);
				BindDept(ddlProvideCompany,"����","%");
				BindDeptAll(ddlDeliveryCompany);
				UcPageView1.DebindGrid();

				DataTable dtGoodsName = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign='GoodsName'");
				

				ddlGoodsName.DataSource = dtGoodsName;
				ddlGoodsName.DataTextField = "cnvcCommName";
				ddlGoodsName.DataValueField = "cnvcCommCode";
				ddlGoodsName.DataBind();

				ListItem liAll = new ListItem("����","%");
				ddlGoodsName.Items.Insert(0,liAll);

				if (ddlGoodsName.SelectedItem.Text != "����")
				{
				
					DataTable dtGoodsType = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign='GoodsType"+ddlGoodsName.SelectedValue+"'");
					ddlGoodsType.DataSource = dtGoodsType;
					ddlGoodsType.DataTextField = "cnvcCommName";
					ddlGoodsType.DataValueField = "cnvcCommCode";
					ddlGoodsType.DataBind();
				}
				else
				{
					DataTable dtGoodsType = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign='GoodsTypeCY' or cnvcCommSign='GoodsTypeQY'");
					ddlGoodsType.DataSource = dtGoodsType;
					ddlGoodsType.DataTextField = "cnvcCommName";
					ddlGoodsType.DataValueField = "cnvcCommCode";
					ddlGoodsType.DataBind();
				}

				//ListItem li = new ListItem("����","%");
				ddlGoodsType.Items.Insert(0,liAll);

//				if ( null != Session[ConstValue.LOGIN_DEPT_SESSION])
//				{
//					Dept dept = (Dept)Session[ConstValue.LOGIN_DEPT_SESSION];
//					if (dept.cnvcDeptID != "00")
//					{
//						ListItem li = ddlDeliveryCompany.Items.FindByText(dept.cnvcDeptName);
//						ddlDeliveryCompany.SelectedIndex = ddlDeliveryCompany.Items.IndexOf(li);						
//						ddlDeliveryCompany.Enabled = false;
//
////						ListItem li2 = ddlProvideCompany.Items.FindByText(dept.cnvcDeptName);
////						ddlProvideCompany.SelectedIndex = ddlProvideCompany.Items.IndexOf(li2);						
////						ddlProvideCompany.Enabled = false;
//					}
//				}
			}
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

		private DataTable GetData(string strDeliveryCompany,string strProvideCompany,string strDeliveryBeginDate,
			string strDeliveryEndDate,string strProvideBeginDate,string strProvideEndDate,string strGoodsType,
			string strGoodsName,ref string strDeliveryCompanyFact,ref string strProvideCompanyFact,string strBillNo)
		{
			string strSql = " select '' as cnnID,convert(char(10),cndProvideDate,121) as cndProvideDate,convert(char(10),cndDeliveryDate,121) as cndDeliveryDate,cnvcGoodsName+cnvcGoodsType as cnvcNameType,cnvcTransportLicenseTags,cnvcTransportMan, "
				+ " cnnOriginalCount,cnnValidateCount,cnvcBillNo,cnnDistance,cnnTransportLose,cnnLose,cnnQuotaLose, "
				+ " cnnOuterLose,cnvcProvideAddress,cnvcDeliveryCompany,cnvcProvideCompany, "
				+ " '{0}FuncName={1}&BillNo='+cnvcBillNo+'&DeptID='+cnvcDeptID+'{2}' as cnvcMod "
				+"from tbBillOfValidate where 1=1";
						
			if (strDeliveryCompany != "")
			{				
				strSql += " and cnvcDeptID like '"+strDeliveryCompany+"%'";			
			}
			if (strProvideCompany != "")
			{
				strSql += " and cnvcProvideDeptID like '"+strProvideCompany+"%'";			
			}
			if (strDeliveryBeginDate != "")
			{
				strSql += " and cndDeliveryDate >='"+strDeliveryBeginDate+"'";
			}
			if (strDeliveryEndDate != "")
			{
				strSql += " and cndDeliveryDate <='"+strDeliveryEndDate+"'";
			}
			if (strProvideBeginDate != "")
			{
				strSql += " and cndProvideDate >='"+strProvideBeginDate+"'";
			}
			if (strProvideEndDate != "")
			{
				strSql += " and cndProvideDate <='"+strProvideEndDate+"'";
			}
			if (strGoodsName != "")
			{
				strSql += " and cnvcGoodsName like '"+strGoodsName+"'";
			}
			if (strGoodsType != "")
			{
				strSql += " and cnvcGoodsType like '"+strGoodsType+"'";
			}
			if(strBillNo != "")
			{
				strSql += " and cnvcBillNo like '%"+strBillNo+"%'";
			}
			strSql += " order by cndDeliveryDate desc";
			DataTable dtBillOfValidate = ReportQueryFacade.CommonQuery(strSql);
			//��ϼ�
			double dOriginalCount = 0.00;
			double dValidateCount = 0.00;
			double dLose = 0.00;
			double dQuotaLose = 0.00;
			double dOuterLose = 0.00;
			strDeliveryCompanyFact = "";
			strProvideCompanyFact = "";
			int i = 0;
			foreach (DataRow drBillOfValidate in dtBillOfValidate.Rows)
			{
				dOriginalCount += double.Parse(drBillOfValidate["cnnOriginalCount"].ToString());
				dValidateCount += double.Parse(drBillOfValidate["cnnValidateCount"].ToString());
				dLose += double.Parse(drBillOfValidate["cnnLose"].ToString());	
				dQuotaLose += double.Parse(drBillOfValidate["cnnQuotaLose"].ToString());	
				dOuterLose += double.Parse(drBillOfValidate["cnnOuterLose"].ToString());	
				strDeliveryCompanyFact = drBillOfValidate["cnvcDeliveryCompany"].ToString();				
				strProvideCompanyFact = drBillOfValidate["cnvcProvideCompany"].ToString();	
				i++;
				drBillOfValidate["cnnID"] = i;
			}
			DataRow drNew = dtBillOfValidate.NewRow();
			drNew["cnvcTransportMan"] = "�ϼ�";
			drNew["cnnOriginalCount"] = dOriginalCount;
			drNew["cnnValidateCount"] = dValidateCount;
			drNew["cnnLose"] = dLose;
			drNew["cnnQuotaLose"] = dQuotaLose;
			drNew["cnnOuterLose"] = dOuterLose;
			dtBillOfValidate.Rows.Add(drNew);
			dtBillOfValidate.Columns["cnnID"].ColumnName = "���";
			dtBillOfValidate.Columns["cndProvideDate"].ColumnName = "��������";
			dtBillOfValidate.Columns["cndDeliveryDate"].ColumnName = "��������";
			dtBillOfValidate.Columns["cnvcTransportLicenseTags"].ColumnName = "���䳵��";			
			dtBillOfValidate.Columns["cnvcNameType"].ColumnName = "�ͺŹ��";
			dtBillOfValidate.Columns["cnvcTransportMan"].ColumnName = "������";
			dtBillOfValidate.Columns["cnnOriginalCount"].ColumnName = "ԭ����";
			dtBillOfValidate.Columns["cnnValidateCount"].ColumnName = "������";
			dtBillOfValidate.Columns["cnvcBillNo"].ColumnName = "���ͺ˶Ե���";
			dtBillOfValidate.Columns["cnnDistance"].ColumnName = "���乫����";
			dtBillOfValidate.Columns["cnnTransportLose"].ColumnName = "������Ķ���";
			dtBillOfValidate.Columns["cnnLose"].ColumnName = "ʵ�����";
			dtBillOfValidate.Columns["cnnQuotaLose"].ColumnName = "�������������";
			dtBillOfValidate.Columns["cnnOuterLose"].ColumnName = "�������������";
			dtBillOfValidate.Columns["cnvcProvideAddress"].ColumnName = "���͵ص�";
			dtBillOfValidate.Columns["cnvcMod"].ColumnName = "�޸�";
			dtBillOfValidate.Columns.Remove("cnvcDeliveryCompany");
			dtBillOfValidate.Columns.Remove("cnvcProvideCompany");
			return dtBillOfValidate;
		}
		private void BindGrid(string strDeliveryCompany,string strProvideCompany,string strDeliveryBeginDate,string strDeliveryEndDate,
			string strProvideBeginDate,string strProvideEndDate,string strGoodsType,string strGoodsName,string strBillNo)
		{			
			string strDeliveryCompanyFact = "";
			string strProvideCompanyFact = "";
			DataTable dtBillOfValidate = GetData(strDeliveryCompany,strProvideCompany,strDeliveryBeginDate,strDeliveryEndDate,
				strProvideBeginDate,strProvideEndDate,strGoodsType,strGoodsName,
				ref strDeliveryCompanyFact,ref strProvideCompanyFact,strBillNo);
			foreach(DataRow dr in dtBillOfValidate.Rows)
			{
				string strmod = dr["�޸�"].ToString();
				dr["�޸�"] = string.Format(strmod,"<a href='wfmOilValidateListMod.aspx?",this.Server.UrlEncode("�޸��������յ�"),"' target='_self'>�޸�</a>");
			}
			this.UcPageView1.MyDataSource = dtBillOfValidate.DefaultView;
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
			this.ddlProvideCompany.SelectedIndexChanged += new System.EventHandler(this.ddlProvideCompany_SelectedIndexChanged);
			this.ddlGoodsName.SelectedIndexChanged += new System.EventHandler(this.ddlGoodsName_SelectedIndexChanged);
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{

			string strGoodsName = ddlGoodsName.SelectedItem.Text;
			if (strGoodsName == "����")
			{
				strGoodsName = "%";
			}
			BindGrid(this.ddlDeliveryCompany.SelectedValue,this.ddlProvideCompany.SelectedValue,
	this.txtDeliveryBeginDate.Text,this.txtDeliveryEndDate.Text,this.txtProvideBeginDate.Text,
	this.txtProvideEndDate.Text,ddlGoodsType.SelectedValue,strGoodsName,txtBillNo.Text);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.txtDeliveryBeginDate.Text = "";
			this.txtDeliveryEndDate.Text = "";
			this.txtProvideBeginDate.Text = "";
			this.txtProvideEndDate.Text = "";
			UcPageView1.DebindGrid();
		}

		private void ddlProvideCompany_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ddlGoodsName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//ddlGoodsName_SelectedIndexChanged
//			DataTable dtGoodsType = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign='GoodsType"+ddlGoodsName.SelectedValue+"'");
//			ddlGoodsType.DataSource = dtGoodsType;
//			ddlGoodsType.DataTextField = "cnvcCommName";
//			ddlGoodsType.DataValueField = "cnvcCommCode";
//			ddlGoodsType.DataBind();
			ListItem liAll = new ListItem("����","%");
			//ddlGoodsName.Items.Insert(0,liAll);

			if (ddlGoodsName.SelectedItem.Text != "����")
			{
				
				DataTable dtGoodsType = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign='GoodsType"+ddlGoodsName.SelectedValue+"'");
				ddlGoodsType.DataSource = dtGoodsType;
				ddlGoodsType.DataTextField = "cnvcCommName";
				ddlGoodsType.DataValueField = "cnvcCommCode";
				ddlGoodsType.DataBind();
			}
			else
			{
				DataTable dtGoodsType = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign='GoodsTypeCY' or cnvcCommSign='GoodsTypeQY'");
				ddlGoodsType.DataSource = dtGoodsType;
				ddlGoodsType.DataTextField = "cnvcCommName";
				ddlGoodsType.DataValueField = "cnvcCommCode";
				ddlGoodsType.DataBind();
			}

			//ListItem li = new ListItem("����","%");
			ddlGoodsType.Items.Insert(0,liAll);

		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			//����EXCEL
			//��
			string strGoodsName = ddlGoodsName.SelectedItem.Text;
			if (strGoodsName == "����")
			{
				strGoodsName = "%";
			}
			string strDeliveryCompanyFact = "";
			string strProvideCompanyFact = "";
			DataTable dtBillOfValidate = GetData(this.ddlDeliveryCompany.SelectedValue,this.ddlProvideCompany.SelectedValue,
				this.txtDeliveryBeginDate.Text,this.txtDeliveryEndDate.Text,this.txtProvideBeginDate.Text,this.txtProvideEndDate.Text,
				ddlGoodsType.SelectedValue,strGoodsName,ref strDeliveryCompanyFact,ref strProvideCompanyFact,txtBillNo.Text);	
			dtBillOfValidate.Columns.Remove("�޸�");
			//Session["QUERY"] = dtBillOfValidate;
			string strBillOfValidate = this.ExportTable(dtBillOfValidate);
			//ͷ
			string strCaption = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strCaption += "<tr><td align=center colspan=15>"+CommonStatic.EnterpriseFullName()+"</td></tr>";
			strCaption += "<tr><td align=center colspan=15>����������ϸ</td></tr>";			
			strCaption += "<tr><td align=left colspan=5>"+"���͵�λ��"+strProvideCompanyFact+"</td><td></td><td colspan=5>���͵�λ��"
				+strDeliveryCompanyFact+"</td><td></td><td colspan=2></td><td align=center>��λ��kg</td></tr>";
			strCaption += "</table>";
			//Session["ExcelCaption"] = strCaption;
			//��
			string strBottom = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strBottom += "<tr><td colspan=15 rospan=4>����������ĵļ��㣺��·���䶨����İ�����ʯ����Ʒ�ͼ��������׼���涨ִ�У���GB11085-89֮�涨��50�����������Ϊ0.01�����˾�ÿ����50����������0.01������50���ﰴ50������㡣�׷����ҷ������Ϳ���Ŵ���������Ϳ��˾࣬�е�����������ģ�����������Ĳ������ҷ���������׷��ջ���˫��ǩ��ȷ�ϣ���˼é�д�������ʯ������վ�������ۼ��ɼ׷����ҷ������˷��п۵֡�</td></tr></table>";
			//			strBottom += "<td align=center>�������ܣ�</td>";
			//			strBottom += "<td></td><td></td>";
			//			strBottom += "<td align=center>��ˣ�</td>";
			//			strBottom += "<td></td><td>�Ʊ�</td><td></td></tr>";
			//			strBottom += "<tr><td colspan=8>����һʽ�ķݣ����ʹ�˾����һ�ݣ������ϵ��������ʹ�˾ҵ��һ�ݣ�һ���빩����Ʊһ��ת���õ�λ�������ϵ���������վҵ������һ�ݣ������ϵ�����</td></tr></table>";
			//Session["ExcelBottom"] = strBottom;
			this.ExportToXls(this,"����������ϸ",strCaption+strBillOfValidate+strBottom);
		}
	}
}
