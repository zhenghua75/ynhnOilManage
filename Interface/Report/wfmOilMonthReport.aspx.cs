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
	public class wfmOilMonthReport : wfmBase
	{
		#region �ֶ�
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnExcel;
		//protected System.Web.UI.WebControls.TextBox txtBeginDate;
		protected System.Web.UI.WebControls.Label Label3;
		//protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.Label Label4;
		//protected System.Web.UI.WebControls.TextBox txtBeforeBeginDate;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtBeginDate;
		//protected System.Web.UI.WebControls.TextBox txtBeforeEndDate;
		protected ynhnOilManage.Interface.Report.ucPageView UcPageView1;
		#endregion
	
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
		private DataTable GetData(string strDeptID,string strDeptName,string strDate)
		{

			string strGoodsType = @"select b.cnvcCommName as cnvcGoodsType,'' as cnvcGoodsName,b.cnvcCommName+a.cnvcCommName as cnvcNameType
,'' as cnnBeforeMonthCurCount,'' as cnnCurMonthInCount,'' as cnnCurMonthOutCount, 
				 '' as cnnStorageLose, '' as cnnQuotaLose,'' as cnnOuterLose,'' as cnnLose,'' as cnnCurMonthCurCount 
 from 
(select cnvcCommName,'GoodsType'+cnvcCommCode as cnvcCommCOde from tbCommCode where cnvcCommSign='GoodsName') a
join
(select cnvcCommName,cnvcCommSign from tbcommCode where cnvcCommSign='GoodsTypeCY' or cnvcCommSign='GoodsTypeQY') b
on a.cnvcCommCOde=b.cnvcCommSign";

//			string strGoodsType = "select cnvcCommcode as cnvcGoodsType,'' as cnvcGoodsName,'' as cnvcNameType,'' as cnnBeforeMonthCurCount,'' as cnnCurMonthInCount,'' as cnnCurMonthOutCount, "
//				+ " '' as cnnStorageLose, '' as cnnQuotaLose,'' as cnnOuterLose,'' as cnnLose,'' as cnnCurMonthCurCount "
//				+ " from tbcommCode where cnvcCommSign='GoodsTypeCY' or cnvcCommSign='GoodsTypeQY' order by cnvcCommCode";
			DataTable dtGoodsType = ReportQueryFacade.CommonQuery(strGoodsType);
			//���			
			//			DateTime dtCur = DateTime.Parse(strBeginDate);
			//			DateTime dtBefore = dtCur.AddMonths(-1);
			//			string strBefore = dtBefore.ToString("yyyy-MM-dd");
            
			//���޸�2010-07-22
			string strBeginDate="";
			string strEndDate="";
			string strBeforeBeginDate="";
			string strBeforeEndDate="";

			DateTime dtDate =  DateTime.Parse(strDate);
			if (int.Parse(dtDate.Day.ToString())>20)
			{
				strBeginDate = dtDate.ToString("yyyy-MM")+"-21";
				strEndDate = dtDate.AddMonths(+1).ToString("yyyy-MM")+"-21";
				strBeforeBeginDate = dtDate.AddMonths(-1).ToString("yyyy-MM")+"-21";;
				strBeforeEndDate = dtDate.ToString("yyyy-MM")+"-21";;
			}
			else
			{
				strBeginDate = dtDate.AddMonths(-1).ToString("yyyy-MM")+"-21";
				strEndDate = dtDate.ToString("yyyy-MM")+"-21";
				strBeforeBeginDate = dtDate.AddMonths(-2).ToString("yyyy-MM")+"-21";;
				strBeforeEndDate = dtDate.AddMonths(-1).ToString("yyyy-MM")+"-21";;
			}
//			strBeginDate = dtDate.AddMonths(-1).ToString("yyyy-MM")+"-21";
//			strEndDate = dtDate.ToString("yyyy-MM")+"-21";
//			strBeforeBeginDate = dtDate.AddMonths(-2).ToString("yyyy-MM")+"-21";;
//			strBeforeEndDate = dtDate.AddMonths(-1).ToString("yyyy-MM")+"-21";;
			foreach (DataRow drGoodsType in dtGoodsType.Rows)
			{
				//���½��
				//string strBeforeMonth = "select top 1 cnnCurCount from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and convert(char(7),cndOperDate,121) = '"+strBefore+"' and cnvcDeptID like '"+strDeptID+"%' order by cndOperDate desc ";
				//string strBeforeMonth = "select top 1 cnnCurCount from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeforeBeginDate+"' and cndOperDate < '"+strBeforeEndDate+"'  and cnvcDeptID like '"+strDeptID+"%' order by cndOperDate desc ";
				string strBeforeMonth = "select sum(cnnCurCount) as cnnCurCount from tbOilStorageLog a where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeforeBeginDate+"' and cndOperDate < '"+strBeforeEndDate+"'  and cnvcDeptID like '"+strDeptID+"%' "
							+" and a.cndOperDate=(select max(cndOperDate) from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeforeBeginDate+"' and cndOperDate < '"+strBeforeEndDate+"'  and cnvcDeptID=a.cnvcDeptID) ";
				DataTable dtBeforeMonth =  ReportQueryFacade.CommonQuery(strBeforeMonth);
				//���½��
				//string strCurMonth = "select top 1 cnnCurCount from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and convert(char(7),cndOperDate,121) = '"+strBeginDate.Substring(0,7)+"' and cnvcDeptID like '"+strDeptID+"%' order by cndOperDate desc ";
				//string strCurMonth = "select top 1 cnnCurCount from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeginDate+"' and cndOperDate < '"+strEndDate+"'  and cnvcDeptID like '"+strDeptID+"%' order by cndOperDate desc ";
				string strCurMonth = "select sum(cnnCurCount) as cnnCurCount from tbOilStorageLog a where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeginDate+"' and cndOperDate < '"+strEndDate+"'  and cnvcDeptID like '"+strDeptID+"%' "+
							" and a.cndOperDate=(select max(cndOperDate) from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeginDate+"' and cndOperDate < '"+strEndDate+"'  and cnvcDeptID=a.cnvcDeptID) ";
				DataTable dtCurMonth =  ReportQueryFacade.CommonQuery(strCurMonth);
				
				if (dtBeforeMonth.Rows.Count > 0)
				{
					drGoodsType["cnnBeforeMonthCurCount"] = dtBeforeMonth.Rows[0][0];
				}
				if (dtCurMonth.Rows.Count > 0)
				{
					drGoodsType["cnnCurMonthCurCount"] = dtCurMonth.Rows[0][0];
				}						
			}
			//��
			//������
			//			string strMonthIn = "select cnvcGoodsType,cnvcGoodsName,sum(cnnInOutCount) as cnnInCount from tbOilStorageLog "
			//				+ " where cnnInOutCount >= 0 and convert(char(7),cndOperDate,121) = '"+strDate.Substring(0,7)+"' and cnvcDeptID like '"+strDeptID+"%'  "
			//				+ " group by cnvcGoodsType,cnvcGoodsName "
			//				+ " order by cnvcGoodsType,cnvcGoodsName ";
			string strMonthIn = "select cnvcGoodsType,cnvcGoodsName,sum(cnnInOutCount) as cnnInCount from tbOilStorageLog "
				+ " where cnnInOutCount >= 0 and cndOperDate >= '"+strBeginDate+"' and cndOperDate <'"+strEndDate+"' and  cnvcDeptID like '"+strDeptID+"%'  "
				+ " group by cnvcGoodsType,cnvcGoodsName "
				+ " order by cnvcGoodsType,cnvcGoodsName ";
			DataTable dtMonthIn =  ReportQueryFacade.CommonQuery(strMonthIn);
			//֧
			//����֧
			//			string strMonthOut = "select cnvcGoodsType,cnvcGoodsName,sum(cnnInOutCount) as cnnOutCount from tbOilStorageLog "
			//				+ " where cnnInOutCount < 0 and convert(char(7),cndOperDate,121) = '"+strDate.Substring(0,7)+"' and cnvcDeptID like '"+strDeptID+"%'  "
			//				+ " group by cnvcGoodsType,cnvcGoodsName "
			//				+ " order by cnvcGoodsType,cnvcGoodsName ";
			string strMonthOut = "select cnvcGoodsType,cnvcGoodsName,sum(cnnInOutCount) as cnnOutCount from tbOilStorageLog "
				+ " where cnnInOutCount < 0 and cndOperDate >= '"+strBeginDate+"' and cndOperDate <'"+strEndDate+"' and cnvcDeptID like '"+strDeptID+"%'  "
				+ " group by cnvcGoodsType,cnvcGoodsName "
				+ " order by cnvcGoodsType,cnvcGoodsName ";
			DataTable dtMonthOut =  ReportQueryFacade.CommonQuery(strMonthOut);
			//���
			//			string strLose = " select cnvcGoodsName,cnvcGoodsType,sum(-(cnnLose-cnnOuterLose)) as cnnQuotaLose,sum(-cnnOuterLose) as cnnOuterLose "
			//				+ " from tbBillOfValidate "
			//				+ " where convert(char(7),cndDeliveryDate,121) = '"+strDate.Substring(0,7)+"' "
			//				+ " and cnvcDeptID like '"+strDeptID+"%' "
			//				+ " group by cnvcGoodsName,cnvcGoodsType ";
			string strLose = " select cnvcGoodsName,cnvcGoodsType,sum(-(cnnLose-cnnOuterLose)) as cnnQuotaLose,sum(-cnnOuterLose) as cnnOuterLose "
				+ " from tbBillOfValidate "
//				+ " where cndDeliveryDate >= '"+strBeginDate+"' "
//				+ " and cndDeliveryDate < '"+strEndDate+"'"
				//���޸�2010-09-03
				+ " where cndProvideDate >= '"+strBeginDate+"' "
				+ " and cndProvideDate < '"+strEndDate+"'"
				+ " and cnvcDeptID like '"+strDeptID+"%' "
				+ " group by cnvcGoodsName,cnvcGoodsType ";
			DataTable dtLose = ReportQueryFacade.CommonQuery(strLose);
			//������
			//			string strStorageLose = " select cnvcGoodsName,cnvcGoodsType,sum(-cnnLoseCount) as cnnStorageLose "
			//				+ " from tbOilStorageCheck "
			//				+ " where convert(char(7),cndOperDate,121) = '"+strDate.Substring(0,7)+"' "
			//				+ " and cnvcDeptID like '"+strDeptID+"%' "
			//				+ " group by cnvcGoodsName,cnvcGoodsType ";
			string strStorageLose = " select cnvcGoodsName,cnvcGoodsType,sum(-cnnLoseCount) as cnnStorageLose "
				+ " from tbOilStorageCheck "
				+ " where cndOperDate >= '"+strBeginDate+"' "
				+ " and cndOperDate < '"+strEndDate+"'"
				+ " and cnvcDeptID like '"+strDeptID+"%' "
				+ " group by cnvcGoodsName,cnvcGoodsType ";
			DataTable dtStorageLose = ReportQueryFacade.CommonQuery(strStorageLose);
			//�ϲ�����		
			foreach (DataRow dr in dtGoodsType.Rows)
			{
				DataRow[] drMonthIns = dtMonthIn.Select("cnvcGoodsType='"+dr["cnvcGoodsType"].ToString()+"'");
				if (drMonthIns.Length > 0)
				{
					dr["cnvcGoodsName"] = drMonthIns[0]["cnvcGoodsName"];
					dr["cnvcNameType"] = drMonthIns[0]["cnvcGoodsType"].ToString() + drMonthIns[0]["cnvcGoodsName"].ToString();
					dr["cnnCurMonthInCount"] = drMonthIns[0]["cnnInCount"];
				}				
				DataRow[] drMonthOuts = dtMonthOut.Select("cnvcGoodsType='"+dr["cnvcGoodsType"].ToString()+"'");
				if (drMonthOuts.Length > 0)
				{
					dr["cnvcGoodsName"] = drMonthOuts[0]["cnvcGoodsName"];
					dr["cnvcNameType"] = drMonthOuts[0]["cnvcGoodsType"].ToString() + drMonthOuts[0]["cnvcGoodsName"].ToString();
					dr["cnnCurMonthOutCount"] = drMonthOuts[0]["cnnOutCount"];
				}	
				DataRow[] drLoses = dtLose.Select("cnvcGoodsType='"+dr["cnvcGoodsType"].ToString()+"'");
				if (drLoses.Length > 0)
				{
					dr["cnvcGoodsName"] = drLoses[0]["cnvcGoodsName"];
					dr["cnvcNameType"] = drLoses[0]["cnvcGoodsType"].ToString() + drLoses[0]["cnvcGoodsName"].ToString();
					dr["cnnQuotaLose"] = drLoses[0]["cnnQuotaLose"];
					dr["cnnOuterLose"] = drLoses[0]["cnnOuterLose"];
				}	

				DataRow[] drStorageLoses = dtStorageLose.Select("cnvcGoodsType='"+dr["cnvcGoodsType"].ToString()+"'");
				if (drStorageLoses.Length > 0)
				{
					dr["cnvcGoodsName"] = drStorageLoses[0]["cnvcGoodsName"];
					dr["cnvcNameType"] = drStorageLoses[0]["cnvcGoodsType"].ToString() + drStorageLoses[0]["cnvcGoodsName"].ToString();
					dr["cnnStorageLose"] = drStorageLoses[0]["cnnStorageLose"];
				}	
			}
			

			
			//��ϼ�

			//double d0 = 0.00;
			foreach (DataRow drSum in dtGoodsType.Rows)
			{
				double dQuotaLose = 0.00;
				double dOuterLose = 0.00;
				double dOutCount  = 0.00;
				double dStorageLose = 0.00;
				//double dLose = 0.00;

				if (drSum["cnnCurMonthOutCount"].ToString() == "")
				{
					dOutCount = 0.00;
				}
				else
				{
					dOutCount = double.Parse(drSum["cnnCurMonthOutCount"].ToString());
				}
				if (drSum["cnnQuotaLose"].ToString() == "")
				{
					dQuotaLose = 0.00;
				}
				else
				{
					dQuotaLose = double.Parse(drSum["cnnQuotaLose"].ToString());
				}
				if (drSum["cnnOuterLose"].ToString() == "")
				{
					dOuterLose = 0.00;
				}
				else
				{
					dOuterLose = double.Parse(drSum["cnnOuterLose"].ToString());
				}
				if (drSum["cnnStorageLose"].ToString() == "")
				{
					dStorageLose = 0.00;
				}
				else
				{
					dStorageLose = double.Parse(drSum["cnnStorageLose"].ToString());
				}

				drSum["cnnLose"] = dOutCount + dQuotaLose + dOuterLose + dStorageLose;
			}
			//dtSum.Columns["cnvcOperType"].ColumnName = "��Ӧ��ʽ";
			dtGoodsType.Columns["cnvcNameType"].ColumnName = "��������";
			dtGoodsType.Columns["cnnBeforeMonthCurCount"].ColumnName = "���½��������KG��";
			dtGoodsType.Columns["cnnCurMonthInCount"].ColumnName = "�������루KG��";
			dtGoodsType.Columns["cnnCurMonthOutCount"].ColumnName = "����ʵ��֧����KG��";
			dtGoodsType.Columns["cnnCurMonthCurCount"].ColumnName = "���½��������KG��";
			dtGoodsType.Columns["cnnStorageLose"].ColumnName = "���¿����ģ�KG��";
			dtGoodsType.Columns["cnnQuotaLose"].ColumnName = "���¶���֧����KG��";
			dtGoodsType.Columns["cnnOuterLose"].ColumnName = "���³���֧����KG��";
			dtGoodsType.Columns["cnnLose"].ColumnName = "����֧���ϼƣ�KG��";
			
			dtGoodsType.Columns.Remove("cnvcGoodsName");
			dtGoodsType.Columns.Remove("cnvcGoodsType");
			return dtGoodsType;
		}
		private void BindGrid(string strDeptID,string strDeptName,string strDate)//,string strBeginDate,string strEndDate,string strBeforeBeginDate,string strBeforeEndDate)
		{			
			DataTable dtGoodsType = GetData(strDeptID,strDeptName,strDate);
			this.UcPageView1.MyDataSource = dtGoodsType.DefaultView;
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
			
			string strDate = "";
			if (this.txtBeginDate.Text == "")
			{
				strDate = DateTime.Now.ToString("yyyy-MM-dd");
			}
			else
			{
				strDate = this.txtBeginDate.Text;
			}

			BindGrid(this.ddlDept.SelectedValue,this.ddlDept.SelectedItem.Text,strDate);//,txtBeginDate.Text,txtEndDate.Text,txtBeforeBeginDate.Text,txtBeforeEndDate.Text);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{			
			this.txtBeginDate.Text = "";
			UcPageView1.DebindGrid();
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			string strDate = "";
			if (this.txtBeginDate.Text == "")
			{
				strDate = DateTime.Now.ToString("yyyy-MM-dd");
			}
			else
			{
				strDate = this.txtBeginDate.Text;
			}
			//����EXCEL
			DataTable dtGoodsType = GetData(this.ddlDept.SelectedValue,this.ddlDept.SelectedItem.Text,strDate);
			string strGoodsType = this.ExportTable(dtGoodsType);
			//��
			//Session["QUERY"] = dtGoodsType;
			//ͷ
			string strCaption = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strCaption += "<tr><td align=center colspan=9>"+CommonStatic.EnterpriseFullName()+"</td></tr>";
			strCaption += "<tr><td align=center colspan=9>�����ա�֧���涯̬�±���</td></tr>";
			strCaption += "<tr><td align=left colspan=4>���λ��"+this.ddlDept.SelectedItem.Text+"</td><td align=left colspan=5>����ڣ�"+strDate+"";
			strCaption += "</table>";
			//Session["ExcelCaption"] = strCaption;
			//��
			string strBottom = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strBottom += "<tr ><td align=left colspan=3>��λ���ܣ�</td>";
			strBottom += "<td align=left colspan=3>��ˣ�</td>";
			strBottom += "<td align=left colspan=3>�Ʊ�</td></tr>";
			strBottom += "</table>";
			//Session["ExcelBottom"] = strBottom;
			this.ExportToXls(this,"�����ա�֧���涯̬�±���",strCaption+strGoodsType+strBottom);
		}
	}
}
