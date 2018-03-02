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
	public class wfmOilDayReport : wfmBase//System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Label Label3;
		//protected System.Web.UI.WebControls.TextBox txtBeginDate;
		protected System.Web.UI.WebControls.Label Label4;
		//protected System.Web.UI.WebControls.TextBox txtEndDate;
		//protected System.Web.UI.WebControls.TextBox txtBeforeBeginDate;
		//protected System.Web.UI.WebControls.TextBox txtBeforeEndDate;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected ynhnOilManage.Interface.Report.ucPageView UcPageView1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			//this.btnExcel.Attributes.Add("onclick","javascript:window.open('DataGridToExcel.aspx', '_blank', 'toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,copyhistory=yes,width=10,height=10,left=0,top=0')");
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
,'' as cnnBeforeMonthCurCount,'' as cnnCurMonthInCount,'' as cnnCurMonthOutCount,'' as cnnCurMonthCurCount, 
				 '' as cnnCurDayInCount,'' as cnnCurDayOutCount,'' as cnnCurDayCurCount,'' as cnvcComments 
 from 
(select cnvcCommName,'GoodsType'+cnvcCommCode as cnvcCommCOde from tbCommCode where cnvcCommSign='GoodsName') a
join
(select cnvcCommName,cnvcCommSign from tbcommCode where cnvcCommSign='GoodsTypeCY' or cnvcCommSign='GoodsTypeQY') b
on a.cnvcCommCOde=b.cnvcCommSign";
//			string strGoodsType = "select cnvcCommcode as cnvcGoodsType,'' as cnvcGoodsName,'' as cnvcNameType,'' as cnnBeforeMonthCurCount,'' as cnnCurMonthInCount,'' as cnnCurMonthOutCount,'' as cnnCurMonthCurCount, "
//				+ " '' as cnnCurDayInCount,'' as cnnCurDayOutCount,'' as cnnCurDayCurCount,'' as cnvcComments "
//				+ " from tbcommCode where cnvcCommSign='GoodsTypeCY' or cnvcCommSign='GoodsTypeQY' order by cnvcCommCode";
			DataTable dtGoodsType = ReportQueryFacade.CommonQuery(strGoodsType);
			//���			
			//DateTime dtCur = DateTime.Parse(strDate);
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
				strBeforeBeginDate = dtDate.AddMonths(-1).ToString("yyyy-MM")+"-21";
				strBeforeEndDate = dtDate.ToString("yyyy-MM")+"-21";
			}
			else
			{
				strBeginDate = dtDate.AddMonths(-1).ToString("yyyy-MM")+"-21";
				strEndDate = dtDate.ToString("yyyy-MM")+"-21";
				strBeforeBeginDate = dtDate.AddMonths(-2).ToString("yyyy-MM")+"-21";
				strBeforeEndDate = dtDate.AddMonths(-1).ToString("yyyy-MM")+"-21";
			}
//			string strBeginDate = dtDate.AddMonths(-1).ToString("yyyy-MM")+"-21";
//			string strEndDate = dtDate.ToString("yyyy-MM")+"-21";
//			string strBeforeBeginDate = dtDate.AddMonths(-2).ToString("yyyy-MM")+"-21";;
//			string strBeforeEndDate = dtDate.AddMonths(-1).ToString("yyyy-MM")+"-21";;

			//			DateTime dtEndDate = DateTime.Parse(strEndDate);
			//			strEndDate = dtEndDate.AddDays(1).ToString("yyyy-MM-dd");

			//			DateTime dtBeforeEndDate = DateTime.Parse(strBeforeEndDate);
			//			strBeforeEndDate = dtEndDate.AddDays(1).ToString("yyyy-MM-dd");

			foreach (DataRow drGoodsType in dtGoodsType.Rows)
			{
				//���½��
				//string strBeforeMonth = "select top 1 cnnCurCount from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and convert(char(7),cndOperDate,121) = '"+strBefore+"' and cnvcDeptID like '"+strDeptID+"%' order by cndOperDate desc ";
				//string strBeforeMonth = "select top 1 cnnCurCount from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeforeBeginDate+"' and cndOperDate < '"+strBeforeEndDate+"' and cnvcDeptID like '"+strDeptID+"%' order by cndOperDate desc ";
				string strBeforeMonth = "select sum(cnnCurCount) as cnnCurCount from tbOilStorageLog a where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeforeBeginDate+"' and cndOperDate < '"+strBeforeEndDate+"' and cnvcDeptID like '"+strDeptID+"%' "+
					" and a.cndOperDate=(select max(cndOperDate) from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeforeBeginDate+"' and cndOperDate < '"+strBeforeEndDate+"' and cnvcDeptID=a.cnvcDeptID)";

//				if ( null != Session[ConstValue.LOGIN_DEPT_SESSION])
//				{
//					Dept dept = (Dept)Session[ConstValue.LOGIN_DEPT_SESSION];
//					if (dept.cnvcDeptID != "00")
//					{
//						strBeforeMonth = "select sum(cnnCurCount) as cnnCurCount from tbOilStorageLog a where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeforeBeginDate+"' and cndOperDate < '"+strBeforeEndDate+"' and cnvcDeptID = '"+strDeptID+"' "+
//							" and a.cndOperDate=(select max(cndOperDate) from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeforeBeginDate+"' and cndOperDate < '"+strBeforeEndDate+"' and cnvcDeptID=a.cnvcDeptID)";
//
//					}
//				}
				DataTable dtBeforeMonth =  ReportQueryFacade.CommonQuery(strBeforeMonth);
				//���½��
				//string strCurMonth = "select top 1 cnnCurCount from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and convert(char(7),cndOperDate,121) = '"+strDate.Substring(0,7)+"' and cnvcDeptID like '"+strDeptID+"%' order by cndOperDate desc ";
				//string strCurMonth = "select top 1 cnnCurCount from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeginDate+"' and cndOperDate < '"+strEndDate+"' and cnvcDeptID like '"+strDeptID+"%' order by cndOperDate desc ";
				string strCurMonth = "select sum(cnnCurCount) as cnnCurCount from tbOilStorageLog a where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeginDate+"' and cndOperDate < '"+strEndDate+"' and cnvcDeptID like '"+strDeptID+"%'  "+
							" and a.cndOperDate=(select max(cndOperDate) from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeginDate+"' and cndOperDate < '"+strEndDate+"' and cnvcDeptID=a.cnvcDeptID) ";
				
//				if ( null != Session[ConstValue.LOGIN_DEPT_SESSION])
//				{
//					Dept dept = (Dept)Session[ConstValue.LOGIN_DEPT_SESSION];
//					if (dept.cnvcDeptID != "00")
//					{
//						strCurMonth = "select sum(cnnCurCount) as cnnCurCount from tbOilStorageLog a where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeginDate+"' and cndOperDate < '"+strEndDate+"' and cnvcDeptID = '"+strDeptID+"'  "+
//							" and a.cndOperDate=(select max(cndOperDate) from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and cndOperDate >= '"+strBeginDate+"' and cndOperDate < '"+strEndDate+"' and cnvcDeptID=a.cnvcDeptID) ";
//				
//					}
//				}

				DataTable dtCurMonth =  ReportQueryFacade.CommonQuery(strCurMonth);
				//���ս��
				//string strCurDay = "select top 1 cnnCurCount from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and convert(char(10),cndOperDate,121) = '"+strDate+"' and cnvcDeptID like '"+strDeptID+"%' order by cndOperDate desc ";
				string strCurDay = "select sum(cnnCurCount) as cnnCurCount from tbOilStorageLog a where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and convert(char(10),cndOperDate,121) = '"+strDate+"' and cnvcDeptID like '"+strDeptID+"%' "+
					" and a.cndOperDate=(select max(cndOperDate) from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and convert(char(10),cndOperDate,121) = '"+strDate+"' and cnvcDeptID=a.cnvcDeptID) ";
				
//				if ( null != Session[ConstValue.LOGIN_DEPT_SESSION])
//				{
//					Dept dept = (Dept)Session[ConstValue.LOGIN_DEPT_SESSION];
//					if (dept.cnvcDeptID != "00")
//					{
//						strCurDay = "select sum(cnnCurCount) as cnnCurCount from tbOilStorageLog a where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and convert(char(10),cndOperDate,121) = '"+strDate+"' and cnvcDeptID = '"+strDeptID+"' "+
//							" and a.cndOperDate=(select max(cndOperDate) from tbOilStorageLog where cnvcGoodsType = '"+drGoodsType["cnvcGoodsType"].ToString()+"' and convert(char(10),cndOperDate,121) = '"+strDate+"' and cnvcDeptID=a.cnvcDeptID) ";
//				
//					}
//				}
				DataTable dtCurDay =  ReportQueryFacade.CommonQuery(strCurDay);

				if (dtBeforeMonth.Rows.Count > 0)
				{
					drGoodsType["cnnBeforeMonthCurCount"] = dtBeforeMonth.Rows[0][0];
				}
				if (dtCurMonth.Rows.Count > 0)
				{
					drGoodsType["cnnCurMonthCurCount"] = dtCurMonth.Rows[0][0];
				}
				if (dtCurDay.Rows.Count > 0)
				{
					drGoodsType["cnnCurDayCurCount"] = dtCurDay.Rows[0][0];
				}				
			}
			//��
			//������
			//			string strMonthIn = "select cnvcGoodsType,cnvcGoodsName,sum(cnnInOutCount) as cnnInCount from tbOilStorageLog "
			//							+ " where cnnInOutCount >= 0 and convert(char(7),cndOperDate,121) = '"+strDate.Substring(0,7)+"' and cnvcDeptID like '"+strDeptID+"%'  "
			//							+ " group by cnvcGoodsType,cnvcGoodsName "
			//							+ " order by cnvcGoodsType,cnvcGoodsName ";
			string strMonthIn = "select cnvcGoodsType,cnvcGoodsName,sum(cnnInOutCount) as cnnInCount from tbOilStorageLog "
				+ " where cnnInOutCount >= 0 and cndOperDate >= '"+strBeginDate+"' and cndOperDate < '"+strEndDate+"' and cnvcDeptID like '"+strDeptID+"%'  "
				+ " group by cnvcGoodsType,cnvcGoodsName "
				+ " order by cnvcGoodsType,cnvcGoodsName ";
			DataTable dtMonthIn =  ReportQueryFacade.CommonQuery(strMonthIn);
			//������
			string strDayIn = "select cnvcGoodsType,cnvcGoodsName,sum(cnnInOutCount) as cnnInCount from tbOilStorageLog "
				+ " where cnnInOutCount >= 0 and convert(char(10),cndOperDate,121) = '"+strDate+"' and cnvcDeptID like '"+strDeptID+"%'  "
				+ " group by cnvcGoodsType,cnvcGoodsName "
				+ " order by cnvcGoodsType,cnvcGoodsName ";
			DataTable dtDayIn =  ReportQueryFacade.CommonQuery(strDayIn);
			//֧
			//����֧
			//			string strMonthOut = "select cnvcGoodsType,cnvcGoodsName,sum(cnnInOutCount) as cnnOutCount from tbOilStorageLog "
			//				+ " where cnnInOutCount < 0 and convert(char(7),cndOperDate,121) = '"+strDate.Substring(0,7)+"' and cnvcDeptID like '"+strDeptID+"%'  "
			//				+ " group by cnvcGoodsType,cnvcGoodsName "
			//				+ " order by cnvcGoodsType,cnvcGoodsName ";
			string strMonthOut = "select cnvcGoodsType,cnvcGoodsName,sum(cnnInOutCount) as cnnOutCount from tbOilStorageLog "
				+ " where cnnInOutCount < 0 and cndOperDate >= '"+strBeginDate+"' and cndOperDate < '"+strEndDate+"'  and cnvcDeptID like '"+strDeptID+"%'  "
				+ " group by cnvcGoodsType,cnvcGoodsName "
				+ " order by cnvcGoodsType,cnvcGoodsName ";
			DataTable dtMonthOut =  ReportQueryFacade.CommonQuery(strMonthOut);
			//����֧
			string strDayOut = "select cnvcGoodsType,cnvcGoodsName,sum(cnnInOutCount) as cnnOutCount from tbOilStorageLog "
				+ " where cnnInOutCount < 0 and convert(char(10),cndOperDate,121) = '"+strDate+"' and cnvcDeptID like '"+strDeptID+"%'  "
				+ " group by cnvcGoodsType,cnvcGoodsName "
				+ " order by cnvcGoodsType,cnvcGoodsName ";
			DataTable dtDayOut =  ReportQueryFacade.CommonQuery(strDayOut);
			
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
				DataRow[] drDayIns = dtDayIn.Select("cnvcGoodsType='"+dr["cnvcGoodsType"].ToString()+"'");
				if (drDayIns.Length > 0)
				{
					dr["cnvcGoodsName"] = drDayIns[0]["cnvcGoodsName"];
					dr["cnvcNameType"] = drDayIns[0]["cnvcGoodsType"].ToString() + drDayIns[0]["cnvcGoodsName"].ToString();
					dr["cnnCurDayInCount"] = drDayIns[0]["cnnInCount"];
				}
				DataRow[] drMonthOuts = dtMonthOut.Select("cnvcGoodsType='"+dr["cnvcGoodsType"].ToString()+"'");
				if (drMonthOuts.Length > 0)
				{
					dr["cnvcGoodsName"] = drMonthOuts[0]["cnvcGoodsName"];
					dr["cnvcNameType"] = drMonthOuts[0]["cnvcGoodsType"].ToString() + drMonthOuts[0]["cnvcGoodsName"].ToString();
					dr["cnnCurMonthOutCount"] = drMonthOuts[0]["cnnOutCount"];
				}
				DataRow[] drDayOuts = dtDayOut.Select("cnvcGoodsType='"+dr["cnvcGoodsType"].ToString()+"'");
				if (drDayOuts.Length > 0)
				{
					dr["cnvcGoodsName"] = drDayOuts[0]["cnvcGoodsName"];
					dr["cnvcNameType"] = drDayOuts[0]["cnvcGoodsType"].ToString() + drDayOuts[0]["cnvcGoodsName"].ToString();
					dr["cnnCurDayOutCount"] = drDayOuts[0]["cnnOutCount"];
				}
			}

			//dtSum.Columns["cnvcOperType"].ColumnName = "��Ӧ��ʽ";
			dtGoodsType.Columns["cnvcNameType"].ColumnName = "��������";
			dtGoodsType.Columns["cnnBeforeMonthCurCount"].ColumnName = "���½��������KG��";
			dtGoodsType.Columns["cnnCurMonthInCount"].ColumnName = "�����ۼ�����������KG��";
			dtGoodsType.Columns["cnnCurMonthOutCount"].ColumnName = "�����ۼ�֧��������KG��";
			dtGoodsType.Columns["cnnCurMonthCurCount"].ColumnName = "�����ۼƽ��������KG��";
			dtGoodsType.Columns["cnnCurDayInCount"].ColumnName = "���������������KG��";
			dtGoodsType.Columns["cnnCurDayOutCount"].ColumnName = "�����֧��������KG��";
			dtGoodsType.Columns["cnnCurDayCurCount"].ColumnName = "��������������KG��";
			dtGoodsType.Columns["cnvcComments"].ColumnName = "��ע";

			dtGoodsType.Columns.Remove("cnvcGoodsType");
			dtGoodsType.Columns.Remove("cnvcGoodsName");
			return dtGoodsType;
		}
		private void BindGrid(string strDeptID,string strDeptName,string strDate)
		{
			DataTable dtGoodsType = this.GetData(strDeptID,strDeptName,strDate);
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
			if (this.txtDate.Text == "")
			{
				strDate = DateTime.Now.ToString("yyyy-MM-dd");
			}
			else
			{
				strDate = this.txtDate.Text;
			}
//			if (this.txtBeginDate.Text == "" || this.txtEndDate.Text == "")
//			{
//				Popup("��ѡ���¿�ʼ���ڻ��½������ڣ�");
//				return;
//			}
//			if (this.txtBeforeBeginDate.Text == "" || this.txtBeforeEndDate.Text == "")
//			{
//				Popup("��ѡ�����¿�ʼ���ڻ����½������ڣ�");
//				return;
//			}
			BindGrid(this.ddlDept.SelectedValue,this.ddlDept.SelectedItem.Text,strDate);//,txtBeginDate.Text,txtEndDate.Text,txtBeforeBeginDate.Text,txtBeforeEndDate.Text);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{			
			this.txtDate.Text = "";
			UcPageView1.DebindGrid();
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			string strDate = "";
			if (this.txtDate.Text == "")
			{
				strDate = DateTime.Now.ToString("yyyy-MM-dd");
			}
			else
			{
				strDate = this.txtDate.Text;
			}
			//��
			string strGoodsType = this.ExportTable(GetData(this.ddlDept.SelectedValue,this.ddlDept.SelectedItem.Text,strDate));
			//ͷ
			string strCaption = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strCaption += "<tr><td align=center colspan=9>"+CommonStatic.EnterpriseFullName()+"</td></tr>";
			strCaption += "<tr><td align=center colspan=9>�����ա�֧���涯̬�ձ���</td></tr>";
			strCaption += "<tr><td align=left colspan=3>���λ��"+this.ddlDept.SelectedItem.Text+"</td><td align=left colspan=6>����ڣ�"+strDate+"</td></tr>";
			strCaption += "</table>";
			//Session["ExcelCaption"] = strCaption;
			//��
			string strBottom = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strBottom += "<tr ><td align=left colspan=3>��λ���ܣ�</td>";
			strBottom += "<td align=left colspan=3>��ˣ�</td>";
			strBottom += "<td align=left colspan=3>�Ʊ�</td></tr>";
			strBottom += "</table>";
			//Session["ExcelBottom"] = strBottom;

			this.ExportToXls(this,"�����ա�֧���涯̬�ձ���",strCaption+strGoodsType+strBottom);
		}
	}
}
