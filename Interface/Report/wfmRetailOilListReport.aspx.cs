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
	public class wfmRetailOilListReport : wfmBase
	{
		#region �ֶ�
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.TextBox txtBeginDate;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.Button btnExcel;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtCompanyName;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtCardID;
		protected System.Web.UI.WebControls.Button Button1;
		protected ynhnOilManage.Interface.Report.ucPageView UcPageView1;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			//this.btnExcel.Attributes.Add("onclick","javascript:window.open('DataGridToExcel.aspx', 'Sample', 'toolbar=no,location=no,directories=no,status=yes,menubar=yes,scrollbars=no,resizable=yes,copyhistory=yes,width=790,height=520,left=0,top=0')");
			this.Button1.Attributes["OnClick"] = "return confirm('�Ƿ�����?')";
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

				//Ȩ������
				this.Button1.Visible=false;
				ArrayList lstUserPurview = Session[ConstValue.LOGIN_USER_PURVIEW_SESSION] as ArrayList;				
				//string strFuncAddress = "wfmRetailOilListReport_Button1";
				string strFuncName="������_����";
				foreach(string fn in lstUserPurview)
				{
					if(fn == strFuncName)
					{
						this.Button1.Visible=true;
					}
				}
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

		private DataTable GetData(string strDeptID,string strBeginDate,string strEndDate,string strCompanyName,string strCardID,ref string strCompanyNameFact)
		{
			string strSql = "select '' as cnnSerialNo,cnvcCardID,cnvcLicenseTags,cnvcGoodsName+cnvcGoodsType as cnvcNameType,'KG' as cnvcUnit,cnnKGCount,cnnPrice,cnnFee,cnvcComments,cnvcCompanyName,cndConsDate from tbConsItem where cnvcDeptID like '"+strDeptID+"%'";
			if (strBeginDate != "")
			{
				strSql += " and convert(char(10),cndConsDate,120)>='"+strBeginDate+"'" ;
			}
			if (strEndDate != "")
			{
				strSql += " and convert(char(10),cndConsDate,120)<='"+strEndDate+"'";
			}
			if (strCardID != "")
			{
				strSql += " and cnvcCardID = '"+strCardID+"'";
			}
			if (strCompanyName != "")
			{
				strSql += " and cnvcCompanyName='"+strCompanyName+"' ";
			}
			strSql += " order by cnvcGoodsName+cnvcGoodsType,cndOperDate desc";
			DataTable dtConsItem = ReportQueryFacade.CommonQuery(strSql);

			string strSum = "select "
				+ " cnvcGoodsName+cnvcGoodsType as cnvcNameType, "
				+ " sum(cnnKGCount) as cnnCount,sum(cnnFee) as cnnFee "
				+ " from tbConsItem "
				+ " where cnvcDeptID like '" + strDeptID + "%'";
			if (strBeginDate != "")
			{
				strSum += " and convert(char(10),cndConsDate,120)>='"+strBeginDate+"'" ;
			}
			if (strEndDate != "")
			{
				strSum += " and convert(char(10),cndConsDate,120)<='"+strEndDate+"'";
			}
			if (strCardID != "")
			{
				strSum += " and cnvcCardID = '"+strCardID+"'";
			}
			if (strCompanyName != "")
			{
				strSum += " and cnvcCompanyName='" + strCompanyName + "' ";
			}
			strSum += " group by cnvcGoodsName+cnvcGoodsType  ";
			strSum += " order by cnvcGoodsName+cnvcGoodsType ";
			DataTable dtConsSum = ReportQueryFacade.CommonQuery(strSum);
			//��ϼ�
			double dCount = 0.00;
			double dFee = 0.00; 
			strCompanyNameFact = "";
			int i = 0;
			foreach (DataRow drConsItem in dtConsItem.Rows)
			{
				dCount += double.Parse(drConsItem["cnnKGCount"].ToString());
				dFee += double.Parse(drConsItem["cnnFee"].ToString());
				strCompanyNameFact = drConsItem["cnvcCompanyName"].ToString();
				i++;
				drConsItem["cnnSerialNo"] = i;
				
			}
			DataRow drNew = null;
			foreach(DataRow dr in dtConsSum.Rows)
			{
				drNew = dtConsItem.NewRow();
				drNew["cnvcLicenseTags"] = dr["cnvcNameType"].ToString() + "�ϼƣ�";
				drNew["cnnKGCount"] =  dr["cnnCount"];
				drNew["cnnFee"] =  dr["cnnFee"];
				//drNew["cnvcComments"] = "�������ܶ�Ӱ�죬���Ͻ�����β������";
				dtConsItem.Rows.Add(drNew);
			}
			drNew = dtConsItem.NewRow();
			drNew["cnvcLicenseTags"] = "�ϼ�";
			drNew["cnnKGCount"] = Math.Round(dCount,2);
			drNew["cnnFee"] = Math.Round(dFee,2);
			//drNew["cnvcComments"] = "�������ܶ�Ӱ�죬���Ͻ�����β������";
			dtConsItem.Rows.Add(drNew);
			dtConsItem.Columns["cnnSerialNo"].ColumnName = "���";
			dtConsItem.Columns["cnvcLicenseTags"].ColumnName = "���ƺ�";
			dtConsItem.Columns["cnvcCardID"].ColumnName = "��Ա����";
			dtConsItem.Columns["cnvcNameType"].ColumnName = "�ͺŹ��";
			dtConsItem.Columns["cnvcUnit"].ColumnName = "��λ";
			dtConsItem.Columns["cnnKGCount"].ColumnName = "����";
			dtConsItem.Columns["cnnPrice"].ColumnName = "���۵��ۣ�Ԫ��";
			dtConsItem.Columns["cnnFee"].ColumnName = "���۽�Ԫ��";
			dtConsItem.Columns["cndConsDate"].ColumnName = "����ʱ��";
			dtConsItem.Columns["cnvcComments"].ColumnName = "��ע";//
			
			dtConsItem.Columns.Remove("cnvcCompanyName");
			return dtConsItem;
		}
		private void BindGrid(string strDeptID,string strBeginDate,string strEndDate,string strCompanyName,string strCardID)
		{
			string strCompanyNameFact = "";
			DataTable dtConsItem = GetData(strDeptID,strBeginDate,strEndDate,strCompanyName,strCardID,ref strCompanyNameFact);
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{

			BindGrid(this.ddlDept.SelectedValue,this.txtBeginDate.Text,this.txtEndDate.Text,this.txtCompanyName.Text,txtCardID.Text);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.txtBeginDate.Text = "";
			this.txtEndDate.Text = "";
			this.txtCompanyName.Text = "";
			UcPageView1.DebindGrid();
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			//����EXCEL
			//��
			string strCompanyNameFact = "";
			DataTable dtConsItem = GetData(this.ddlDept.SelectedValue,this.txtBeginDate.Text,this.txtEndDate.Text,this.txtCompanyName.Text,txtCardID.Text,ref strCompanyNameFact);
			string strConsItem = this.ExportTable(dtConsItem);
			//Session["QUERY"] = dtConsItem;
			//ͷ
			string strCaption = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strCaption += "<tr><td align=center colspan=10>"+CommonStatic.EnterpriseFullName()+"</td></tr>";
			strCaption += "<tr><td align=center colspan=10>"+ddlDept.SelectedItem.Text+"������������ϸ��</td></tr>";
			strCaption += "<tr><td align=center colspan=10>"+DateTime.Now.ToString("yyyy��MM��dd��")+"</td></tr>";
			strCaption += "<tr><td align=left colspan=5>"+"���õ�λ��"+strCompanyNameFact+"</td><td colspan=3></td><td align=center>��λ��Ԫ</td><td></td></tr>";
			strCaption += "</table>";
			//Session["ExcelCaption"] = strCaption;
			//��
			string strBottom = "<table style='font-size:X-Small' border=1 bordercolor=gray>";
			strBottom += "<tr><td></td>";
			strBottom += "<td align=center colspan=3>�������ܣ�</td>";
			strBottom += "<td></td><td></td>";
			strBottom += "<td align=center>��ˣ�</td>";
			strBottom += "<td></td><td>�Ʊ�</td><td></td></tr>";
			//�������ܶ�Ӱ�죬���Ͻ�����β������
			strBottom += "<tr><td colspan=10>�������ܶ�Ӱ�죬���Ͻ�����β�����졣����һʽ�ķݣ����ʹ�˾����һ�ݣ����ʹ�˾ҵ��һ�ݣ�һ���빩����Ʊһ��תʹ�õ�λ������վҵ������һ�ݡ�</td></tr></table>";
			//Session["ExcelBottom"] = strBottom;
			this.ExportToXls(this,ddlDept.SelectedItem.Text+"������������ϸ��",strCaption+strConsItem+strBottom);
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				//�������ͼ�����
				if(this.txtBeginDate.Text.Trim().Length==0)
				{
					this.Popup("�����뿪ʼ���ڣ�");
					return;
				}
				if(this.txtEndDate.Text.Trim().Length==0)
				{
					this.Popup("������������ڣ�");
					return;
				}
			
				DataTable dtPrice = ReportQueryFacade.CommonQuery("select count(*) from tbOilPrice where convert(varchar(10),cndpricedate,121) between '"+this.txtBeginDate.Text+"' and '"+this.txtEndDate.Text+"'");
				int icount = Convert.ToInt32(dtPrice.Rows[0][0].ToString());
				if(icount==0)
				{
					this.Popup("ѡ����ʱ����ͼ�δ�䶯��");
					return;
				}
			

				Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
				Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 

				BusiLog busiLog = new BusiLog();
				busiLog.cnvcOperName = curOper.cnvcOperName;
				busiLog.cnvcComments = "���㣺"+this.txtBeginDate.Text+"-"+this.txtEndDate.Text;
				busiLog.cnvcDeptID = curDept.cnvcDeptID;
				busiLog.cnvcDeptName = curDept.cnvcDeptName;
				busiLog.cnvcOperType = "BS016";
				busiLog.cnvcSource = "��վ";

			
				

				ReportQueryFacade.AgainComp(this.txtBeginDate.Text,this.txtEndDate.Text,busiLog);
				this.Popup("����ɹ�");
			}
			catch(Exception ex)
			{
				this.Popup(ex.Message);
			}
		}
	}
}
