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
	public class wfmRetailOilSumReport : wfmBase
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
			this.UcPageView1.MyDataGrid.ItemDataBound+=new DataGridItemEventHandler(MyDataGrid_ItemDataBound);
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

		private DataTable GetData(string strDeptID,string strBeginDate,string strEndDate)
		{
			string strSql = "select ''as cnnID,cnvcCompanyName,cnvcGoodsType+cnvcGoodsName as cnvcNameType, "
				+ " 'KG' as cnvcUnit,sum(cnnKGCount) as cnnKGCount,(CONVERT(numeric(10,2), sum(cnnPrice)/count(1))) AS cnnPrice,sum(cnnFee) as cnnFee from tbConsItem  where cnvcDeptID like '"+strDeptID+"%'";
			if (strBeginDate != "")
			{
				strSql += " and convert(char(10),cndConsDate,120)>='"+strBeginDate+"'" ;
			}
			if (strEndDate != "")
			{
				strSql += " and convert(char(10),cndConsDate,120)<='"+strEndDate+"'";
			}
			strSql += " group by cnvcCompanyName,cnvcGoodsType+cnvcGoodsName,cnvcUnit order by cnvcCompanyName,cnvcGoodsType+cnvcGoodsName";
			DataTable dtConsItem = ReportQueryFacade.CommonQuery(strSql);


			

			DataTable dt = new DataTable();
			dt.Columns.Add("cnnID");
			dt.Columns.Add("cnvcCompanyName");
			dt.Columns.Add("cnvcUnit");
			dt.Columns.Add("d01");
			dt.Columns.Add("d02");
			dt.Columns.Add("d03");
			dt.Columns.Add("g931");
			dt.Columns.Add("g932");
			dt.Columns.Add("g933");
			dt.Columns.Add("g971");
			dt.Columns.Add("g972");
			dt.Columns.Add("g973");
			dt.Columns.Add("gsum");
			dt.Columns.Add("sum");

			int i = 0;
			foreach (DataRow drConsItem in dtConsItem.Rows)
			{				
				
				//drConsItem["cnnID"] = i;
				DataRow dr = null;
				DataRow[] drs = dt.Select("cnvcCompanyName='"+drConsItem["cnvcCompanyName"].ToString()+"'");
				
				if(drs.Length == 0)
				{	
					i ++;
					dr = dt.NewRow();
					dr["cnnID"] = i;
					dr["cnvcCompanyName"] = drConsItem["cnvcCompanyName"];
					dr["cnvcUnit"] = drConsItem["cnvcUnit"];
				}
				else
					dr = drs[0];
				switch(drConsItem["cnvcNameType"].ToString())
				{
					case "0#����":
						dr["d01"] = drConsItem["cnnPrice"];
						dr["d02"] = drConsItem["cnnKGCount"];
						dr["d03"] =drConsItem["cnnFee"];
						break;
					case "93#����":
						dr["g931"] = drConsItem["cnnPrice"];
						dr["g932"] = drConsItem["cnnKGCount"];
						dr["g933"] =drConsItem["cnnFee"];
						break;
					case "97#����":
						dr["g971"] = drConsItem["cnnPrice"];
						dr["g972"] = drConsItem["cnnKGCount"];
						dr["g973"] =drConsItem["cnnFee"];
						break;
				}
				if(drs.Length == 0)
				{
					dt.Rows.Add(dr);
				}
			}

			//��ϼ�
			double ddCount = 0;
			double ddFee = 0; 
			double dg93Count = 0;
			double dg93Fee = 0;
			double dg97Fee = 0;
			double dg97Count = 0;
			//
			foreach(DataRow dr in dt.Rows)
			{
				ddCount += Convert.ToDouble(dr["d02"].ToString()==""?"0":dr["d02"].ToString());
				ddFee += Convert.ToDouble(dr["d03"].ToString()==""?"0":dr["d03"].ToString());	

				dg93Count += Convert.ToDouble(dr["g932"].ToString()==""?"0":dr["g932"].ToString());
				dg93Fee += Convert.ToDouble(dr["g933"].ToString()==""?"0":dr["g933"].ToString());	

				dg97Count += Convert.ToDouble(dr["g972"].ToString()==""?"0":dr["g972"].ToString());
				dg97Fee += Convert.ToDouble(dr["g973"].ToString()==""?"0":dr["g973"].ToString());	
				dr["gsum"] = Convert.ToDouble(dr["g933"].ToString()==""?"0":dr["g933"].ToString())+
					Convert.ToDouble(dr["g973"].ToString()==""?"0":dr["g973"].ToString());
				dr["sum"] = Convert.ToDouble(dr["d03"].ToString()==""?"0":dr["d03"].ToString())+
					Convert.ToDouble(dr["g933"].ToString()==""?"0":dr["g933"].ToString())+Convert.ToDouble(dr["g973"].ToString()==""?"0":dr["g973"].ToString());
			}


			double ddfeenofax = Math.Round(ddFee/1.17,2);
			double dg93feenofax = Math.Round(dg93Fee/1.17,2);
			double dg97feenofax = Math.Round(dg97Fee/1.17,2);
			double dgsumnofax = Math.Round((dg93Fee+dg97Fee)/1.17,2);
			double dsumnofax = Math.Round((ddFee+dg93Fee+dg97Fee)/1.17,2);
			//����˰��
			DataRow drNoFax = dt.NewRow();
			drNoFax["cnvcCompanyName"] = "����˰��";
			//drNoFax["cnvcUnit"] ="T";
			//drNoFax["d02"] = ddCount/1000;
			drNoFax["d03"] = ddfeenofax;
			//drNoFax["g932"] = dg93Count/1000;
			drNoFax["g933"] = dg93feenofax;
			//drNoFax["g972"] = dg97Count/1000;
			drNoFax["g973"] = dg97feenofax;
			drNoFax["gsum"] = dgsumnofax;
			drNoFax["sum"] = dsumnofax;
			dt.Rows.Add(drNoFax);

			//��ֵ˰
			DataRow drFax = dt.NewRow();
			drFax["cnvcCompanyName"] = "��ֵ˰��17%��";
			//drFax["cnvcUnit"] ="T";
			//drNoFax["d02"] = ddCount/1000;
			drFax["d03"] = Math.Round(ddFee-ddfeenofax,2);//Math.Round(ddFee*1.17,2);
			//drNoFax["g932"] = dg93Count/1000;
			drFax["g933"] = Math.Round(dg93Fee-dg93feenofax,2);//Math.Round(dg93Fee*1.17,2);
			//drNoFax["g972"] = dg97Count/1000;
			drFax["g973"] = Math.Round(dg97Fee-dg97feenofax,2);//Math.Round(dg97Fee*1.17,2);
			drFax["gsum"] = Math.Round(dg93Fee+dg97Fee-dgsumnofax,2);//Math.Round((dg93Fee+dg97Fee)*1.17,2);
			drFax["sum"] = Math.Round(ddFee+dg93Fee+dg97Fee-dsumnofax,2);//Math.Round((ddFee+dg93Fee+dg97Fee)*1.17,2);
			dt.Rows.Add(drFax);
			//�ϼ���
			DataRow drNew = dt.NewRow();
			drNew["cnvcCompanyName"] = "�ϼ�";
			drNew["cnvcUnit"] ="T";
			drNew["d02"] = ddCount/1000;
			drNew["d03"] = ddFee;
			drNew["g932"] = dg93Count/1000;
			drNew["g933"] = dg93Fee;
			drNew["g972"] = dg97Count/1000;
			drNew["g973"] = dg97Fee;
			drNew["gsum"] = dg93Fee+dg97Fee;
			drNew["sum"] = ddFee+dg93Fee+dg97Fee;
			dt.Rows.Add(drNew);



			dt.Columns["cnnID"].ColumnName ="���";
			dt.Columns["cnvcCompanyName"].ColumnName ="���õ�λ";
			dt.Columns["cnvcUnit"].ColumnName ="��λ";
			dt.Columns["d01"].ColumnName ="<table width='100%'><tr nowrap='nowrap' style='color:White;background-color:#000084;font-size:Small;font-weight:bold;'><td colspan='3' align='center'>0#����</td></tr>"
				+"<tr nowrap='nowrap' style='color:White;background-color:#000084;font-size:Small;font-weight:bold;'><td>����";
			dt.Columns["d02"].ColumnName ="<font id='d0c'>����</font>";
			dt.Columns["d03"].ColumnName ="<font id='d0f'>��Ԫ��</font></td></tr></table>";
			
			dt.Columns["g931"].ColumnName ="<table width='100%'><tr nowrap='nowrap' style='color:White;background-color:#000084;font-size:Small;font-weight:bold;'><td colspan='3' align='center'>93#����</td></tr>"
				+"<tr nowrap='nowrap' style='color:White;background-color:#000084;font-size:Small;font-weight:bold;'><td>����";
			dt.Columns["g932"].ColumnName ="<font id='g93c'>����</font>";
			dt.Columns["g933"].ColumnName ="<font id='g93f'>��Ԫ��</font></td></tr></table>";
			
			dt.Columns["g971"].ColumnName ="<table width='100%'><tr nowrap='nowrap' style='color:White;background-color:#000084;font-size:Small;font-weight:bold;'><td colspan='3' align='center'>97#����</td></tr>"
				+"<tr nowrap='nowrap' style='color:White;background-color:#000084;font-size:Small;font-weight:bold;'><td>����";
			dt.Columns["g972"].ColumnName ="<font id='g97c'>����</font>";
			dt.Columns["g973"].ColumnName ="<font id='g97f'>��Ԫ��</font></td></tr></table>";
			
			dt.Columns["gsum"].ColumnName ="<table width='100%'><tr nowrap='nowrap' style='color:White;background-color:#000084;font-size:Small;font-weight:bold;'><td>����С��</td></tr>"
				+"<tr nowrap='nowrap' style='color:White;background-color:#000084;font-size:Small;font-weight:bold;'><td>���</td></tr></table>";
			dt.Columns["sum"].ColumnName ="�ϼ�";

			return dt;
		}
		private void BindGrid(string strDeptID,string strBeginDate,string strEndDate)
		{
			DataTable dtConsItem = GetData(strDeptID,strBeginDate,strEndDate);
			
			this.UcPageView1.MyDataSource = dtConsItem.DefaultView;
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

			BindGrid(this.ddlDept.SelectedValue,this.txtBeginDate.Text,this.txtEndDate.Text);
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
			//Session["QUERY"] = dtConsItem;
			DataTable dtConsItem = GetData(this.ddlDept.SelectedValue,this.txtBeginDate.Text,this.txtEndDate.Text);
			string strConsItem = this.ExportTable(dtConsItem);
			//ͷ
			string strCaption = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strCaption += "<tr><td align=center colspan=14>"+CommonStatic.EnterpriseFullName()+"</td></tr>";
			strCaption += "<tr><td align=center colspan=14>"+ddlDept.SelectedItem.Text+"���������ۻ��ܱ�</td></tr>";
			strCaption += "<tr><td align=center colspan=14>"+DateTime.Now.ToString("yyyy��MM��dd��")+"</td></tr>";
			strCaption += "<tr><td align=left colspan=3></td><td colspan=3></td><td align=center>��λ��Ԫ</td></tr>";
			strCaption += "</table>";
			//Session["ExcelCaption"] = strCaption;
			//��
			string strBottom = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strBottom += "<tr><td></td>";
			strBottom += "<td align=center>�������ܣ�</td>";
			strBottom += "<td></td><td></td>";
			strBottom += "<td align=center>��ˣ�</td>";
			strBottom += "<td></td><td>�Ʊ�</td></tr>";
			strBottom += "<tr><td colspan=14>����һʽ���ݣ����ʹ�˾����һ�ݣ����ʹ�˾ҵ��һ�ݣ�����վҵ������һ�ݡ�</td></tr></table>";
			//Session["ExcelBottom"] = strBottom;
			this.ExportToXls(this,ddlDept.SelectedItem.Text+"���������ۻ��ܱ�",strCaption+strConsItem+strBottom);
		}

		private void MyDataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			//
			if(e.Item.ItemType == ListItemType.Header)
			{				
				e.Item.Cells[3].ColumnSpan=3;
				e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Right;
				e.Item.Cells[5].HorizontalAlign = HorizontalAlign.Right;
				e.Item.Cells[6].ColumnSpan=3;
				e.Item.Cells[7].HorizontalAlign = HorizontalAlign.Right;
				e.Item.Cells[8].HorizontalAlign = HorizontalAlign.Right;
				e.Item.Cells[9].ColumnSpan=3;
				e.Item.Cells[10].HorizontalAlign = HorizontalAlign.Right;
				e.Item.Cells[11].HorizontalAlign = HorizontalAlign.Right;
			}
		}

	}
}
