using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ynhnOilManage.Common;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.EntityObject.EntityBase;
using System.Text;
using ynhnOilManage.BusinessFacade;
using ynhnOilManage.BusinessFacade.SysManage;
using ynhnOilManage.BusinessFacade.Report;
namespace ynhnOilManage.Interface
{
	/// <summary>
	/// Summary description for wfmBase.
	/// 页面基类，权限控制
	/// 郑华　2007-3-6
	/// </summary>
	public class wfmBase : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				//更新会话

//				Oper _oper = (Oper)Session[ConstValue.LOGIN_USER_SESSION];
//				ArrayList lstPurview = (ArrayList)Session[ConstValue.LOGIN_USER_PURVIEW_SESSION];
//				Session.RemoveAll();
//				//将用户信息保存到Session变量
//				Session[ConstValue.LOGIN_USER_SESSION] = _oper;
//				//将用户权限保存到Session变量
//				Session[ConstValue.LOGIN_USER_PURVIEW_SESSION] = lstPurview;
				//清除
				Session.Remove("QUERY");
				Session.Remove("ExcelCaption");
				Session.Remove("ExcelBottom");
				

			}
			try
			{
				if (Session[ConstValue.LOGIN_USER_SESSION] == null || Session[ConstValue.LOGIN_USER_PURVIEW_SESSION] == null
					||Session[ConstValue.LOGIN_DEPT_SESSION]==null)
				{
					this.Response.Redirect(@"..\Sysmanage\Default.aspx");
				}
				//登录操作员功能地址列表
				bool isAuthorization = true;

				ArrayList alFuncName = (ArrayList) Session[ConstValue.LOGIN_USER_PURVIEW_SESSION];
				//请求的路径
				string strFileName = System.IO.Path.GetFileName(this.Request.Path);
				//请求的功能名称
				
				string strFuncName = System.Web.HttpUtility.UrlDecode(this.Request["FuncName"].ToString(),Encoding.GetEncoding("GB2312"));//this.Server.UrlDecode(this.Request["FuncName"].ToString());
				
				//进行比对是否具有此权限
				if (alFuncName.BinarySearch(strFuncName) < 0)
				{
					isAuthorization = false;
				}				
			
				if (!isAuthorization)//如果无此功能地址
				{
//					Exception ex = new Exception(strFuncName);
//					LogAdapter.WriteInterfaceException(ex);	
					this.Response.Redirect(@"..\Sysmanage\wfmNoAuthorization.aspx");
				}
			}
			catch (BusinessException  bex)
			{
				Popup(bex.Message);
				return;
			}
			
			
			
			
		}

		#region fightop@add 2003-3-15 页面出错事件处理

		protected void wfmBase_Error(object sender, EventArgs e)
		{
			// 记录错误日志 
			Exception errorLast = Server.GetLastError();

			if (errorLast is ConcurrentException || errorLast.InnerException is ConcurrentException)
			{
				Server.ClearError();
				Popup("其它用户修改或删除了当前信息，页面刷新获取了最新的数据！");
				Server.Transfer(Request.Url.PathAndQuery);
				return;
			}
			else if (errorLast is SqlException)
			{
				SqlException se = errorLast as SqlException;
				if (SqlErrorCode.Duplicate_Key == se.Number)
				{
					Server.ClearError();
					Popup("非常抱歉，将要创建的信息已存在！");
					Server.Transfer(Request.Url.PathAndQuery);
					return;
				}
			}

			LogAdapter.WriteInterfaceException(errorLast);

			Response.Redirect("../wfmError.aspx");

			//base.OnError(e);
		}

		#endregion

		#region fightop@add 2003-3-21 取操作人员实体

		/// <summary>
		/// 取操作人员实体
		/// </summary>
		/// <param name="strOperID">操作人员ID</param>
		/// <returns>操作人员实体</returns>
		public Oper GetOperEntity(string strOperID)
		{
			Hashtable lstOper = Application[ConstValue.OPER_DICTI_NAME] as Hashtable;

			return lstOper[strOperID] as Oper;
		}

		#endregion

		//弹出窗口
		public void Popup(string strComments)
		{
			this.Response.Write("<script>alert('"+strComments+"');</script>");
		}
		public bool IsNumeric(string str)  
		{   
			System.Text.RegularExpressions.Regex reg1  
				= new System.Text.RegularExpressions.Regex(@"^[-]?\d+[.]?\d*$");   
			return reg1.IsMatch(str);  
		}
		public void SetDDL(DropDownList ddl,string strvalue)
		{
			foreach( ListItem item in ddl.Items )
			{
				if( item.Value == strvalue )
				{
					item.Selected = true;
				}
				else
				{
					item.Selected = false;
				}
			}
		}
		public void SetDDLTxt(DropDownList ddl,string strTxt)
		{
			foreach( ListItem item in ddl.Items )
			{
				if( item.Text == strTxt )
				{
					item.Selected = true;
				}
				else
				{
					item.Selected = false;
				}
			}
		}
		public void BindDept(DropDownList ddl)
		{
			if (Session[ConstValue.LOGIN_USER_SESSION] == null || Session[ConstValue.LOGIN_USER_PURVIEW_SESSION] == null
				||Session[ConstValue.LOGIN_DEPT_SESSION]==null)
			{
				this.Response.Redirect(@"..\Sysmanage\Default.aspx");
			}
			Dept dept = (Dept)Session[ConstValue.LOGIN_DEPT_SESSION];
			if (dept.cnvcDeptID != "00")
			{
				BindDept2(ddl,dept.cnvcDeptID);
			}
			else
			{
				DataTable dtDept = DeptFacade.GetAllDept();
				ddl.DataSource = dtDept;
				ddl.DataTextField = "cnvcDeptName";
				ddl.DataValueField = "cnvcDeptID";
				ddl.DataBind();
			}
		}
		public void BindDeptAll(DropDownList ddl)
		{
			if (Session[ConstValue.LOGIN_USER_SESSION] == null || Session[ConstValue.LOGIN_USER_PURVIEW_SESSION] == null
				||Session[ConstValue.LOGIN_DEPT_SESSION]==null)
			{
				this.Response.Redirect(@"..\Sysmanage\Default.aspx");
			}
			Dept dept = (Dept)Session[ConstValue.LOGIN_DEPT_SESSION];
			if (dept.cnvcDeptID != "00")
			{
				BindDept2(ddl,dept.cnvcDeptID);
			}
			else
				BindDept(ddl,"所有","%");
		}
		public void BindDept(DropDownList ddl,string strText,string strValue)
		{
			DataTable dtDept = DeptFacade.GetAllDept();
			ddl.DataSource = dtDept;
			ddl.DataTextField = "cnvcDeptName";
			ddl.DataValueField = "cnvcDeptID";
			ddl.DataBind();
			ListItem li = new ListItem(strText,strValue);
			ddl.Items.Insert(0,li);
		}
		public void BindDept2(DropDownList ddl,string strDeptID)
		{
			DataTable dtDept = DeptFacade.GetAllDept();
			
			DataView dv = new DataView(dtDept);
			dv.RowFilter="cnvcDeptID like '"+strDeptID+"%' or cnvcParentDeptID='"+strDeptID+"'";
			ddl.DataSource = dv;
			ddl.DataTextField = "cnvcDeptName";
			ddl.DataValueField = "cnvcDeptID";
			ddl.DataBind();
		}
//		public void BindOperType(DropDownList ddl)
//		{
//			DataTable dt = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign like 'GoodsType%'");
//			ddl.DataSource = dtDept;
//			ddl.DataTextField = "cnvcDeptName";
//			ddl.DataValueField = "cnvcDeptID";
//			ddl.DataBind();
//			ListItem li = new ListItem(strText,strValue);
//			ddl.Items.Insert(0,li);
//		}
		public void BindGoodsType(DropDownList ddlGoodsType,string strGoodsName)
		{
			//DataTable dtGoodsType = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign='GoodsType"+strGoodsName+"'");
			DataTable dtGoodsType = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign like 'GoodsType%'");
			ddlGoodsType.DataSource = dtGoodsType;
			ddlGoodsType.DataTextField = "cnvcCommName";
			ddlGoodsType.DataValueField = "cnvcCommCode";
			ddlGoodsType.DataBind();
		}
		public void BindGoodsName(DropDownList ddlGoodsName)
		{
			DataTable dtGoodsName = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign='GoodsName'");
				

			ddlGoodsName.DataSource = dtGoodsName;
			ddlGoodsName.DataTextField = "cnvcCommName";
			ddlGoodsName.DataValueField = "cnvcCommCode";
			ddlGoodsName.DataBind();
		}
		public void BindSDept(DropDownList ddl,string LocalDeptNameTmp)
		{
			string strsql ="select cnvcDeliveryCompany from tbSpecialOilDept  where cnvcDeliveryComPany like '"+ LocalDeptNameTmp + "%' order by cnvcDeliveryCompany";
			DataTable dt = ReportQueryFacade.CommonQuery(strsql);
			ddl.DataSource = dt;
			ddl.DataTextField = "cnvcDeliveryCompany";
			ddl.DataValueField = "cnvcDeliveryCompany";
			ddl.DataBind();				
		}
		public void BindPDept(DropDownList ddl,string LocalDeptNameTmp)
		{
			string strsql ="select * from tbDept where isnull(cnvcLocalFlag,'')<>'"+LocalDeptNameTmp+"'";
			DataTable dt = ReportQueryFacade.CommonQuery(strsql);
			ddl.DataSource = dt;
			ddl.DataTextField = "cnvcDeptName";
			ddl.DataValueField = "cnvcDeptID";
			ddl.DataBind();				
		}
		public void BindContractNo(DropDownList ddl,string LocalDeptNameTmp,string strDeliveryCompany)
		{
			string strsql="select cnvcContractNo,cnvcDeliveryCompany from tbSpecialOilDept where cnvcDeliveryComPany like '"+ LocalDeptNameTmp + "%' and cnvcDeliveryComPany='"+strDeliveryCompany+"'  order by cnvcDeliveryCompany";
			DataTable dt = ReportQueryFacade.CommonQuery(strsql);
			ddl.DataSource = dt;
			ddl.DataTextField = "cnvcContractNo";
			ddl.DataValueField = "cnvcContractNo";
			ddl.DataBind();				
		}
		public void BindLocalDept(TextBox txtDeptID,TextBox txtDeptName)
		{
			string strDeptID = this.Request["DeptID"].ToString();

			string strsql = "select cnvcDeptID,SUBSTRING(cnvcdeptname,1,3) as cnvcDeptName,cnvcParentDeptID,cnvcLocalFlag,cnbValidate from tbdept where cnvcdeptid='"+strDeptID+"'";
			DataTable dt = ReportQueryFacade.CommonQuery(strsql);
			Dept dept = new Dept(dt);

			txtDeptID.Text = strDeptID;
			txtDeptName.Text = dept.cnvcDeptName;
		}
		public EntityObjectBase LoadObj(string strType)
		{
			string strBillNo = this.Request["BillNo"].ToString();
			string strDeptID = this.Request["DeptID"].ToString();
			EntityObjectBase eob = null;
			switch(strType)
			{
				case "BOM":
					BillOfMaterials bom = new BillOfMaterials();
					bom.cnvcBillNo = strBillNo;
					bom.cnvcDeptID = strDeptID;					
					eob = ReportQueryFacade.CommonQuery(bom);					
					break;
				case "BOV":
					BillOfValidate bov = new BillOfValidate();
					bov.cnvcBillNo = strBillNo;
					bov.cnvcDeptID = strDeptID;
					eob = ReportQueryFacade.CommonQuery(bov);
					break;
				case "BOS":
					BillOfOutStorage bos = new BillOfOutStorage();
					bos.cnvcBillNo = strBillNo;
					bos.cnvcDeptID = strDeptID;
					eob = ReportQueryFacade.CommonQuery(bos);												 
					break;
			}
			return eob;
		}
		public double GetTranLose()
		{
			string strsql = "select * from tbCommCode where cnvcCommSign='TRANLOSE'";
			DataTable dt = ReportQueryFacade.CommonQuery(strsql);
			if(dt.Rows.Count > 0)
			{
				return double.Parse(dt.Rows[0]["cnvccommcode"].ToString());
			}
			else
			{
				return 0;
			}
		}
		public double GetOffSet()
		{
			string strsql = "select * from tbCommCode where cnvcCommSign='OFFSET'";
			DataTable dt = ReportQueryFacade.CommonQuery(strsql);
			if(dt.Rows.Count > 0)
			{
				return double.Parse(dt.Rows[0]["cnvccommcode"].ToString());
			}
			else
			{
				return 0;
			}
		}

		#region zhenghua@add 2010-04-14 导出EXCEL
		public string ExportTable(DataTable tb) 
		{ 
			StringBuilder sb = new StringBuilder(); 
			//data = ds.DataSetName + "\n"; 
			int count = 0; 

//			foreach (DataTable tb in ds.Tables) 
//			{ 
				//data += tb.TableName + "\n"; 
				
				sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\">"); 
				sb.Append("<table cellspacing=\"0\" cellpadding=\"5\" rules=\"all\" border=\"1\">"); 
				//写出列名 
				sb.Append("<tr style=\"font-weight: bold; white-space: nowrap;\">"); 
				foreach (DataColumn column in tb.Columns) 
				{ 
					if(column.ColumnName.IndexOf("0#柴油")>0||
						column.ColumnName.IndexOf("93#汽油")>0||
						column.ColumnName.IndexOf("97#汽油")>0)
					{
						string strcn = column.ColumnName;
						strcn = strcn.Replace("style='color:White;background-color:#000084;font-size:Small;font-weight:bold;'","style='font-weight: bold; white-space: nowrap;'");
						strcn = strcn.Replace("<table>","<table cellspacing='0' cellpadding='5' rules='all' border='1'>");
						sb.Append("<td colspan='3'>" + strcn + "</td>"); 
					}
					else if(column.ColumnName.IndexOf("汽油小计")>0)
					{
						string strcn = column.ColumnName;
						strcn = strcn.Replace("style='color:White;background-color:#000084;font-size:Small;font-weight:bold;'","style='font-weight: bold; white-space: nowrap;'");
						strcn = strcn.Replace("<table>","<table cellspacing='0' cellpadding='5' rules='all' border='1'>");
						sb.Append("<td>" + strcn + "</td>"); 
					}
					else
					{
						sb.Append("<td>" + column.ColumnName + "</td>"); 
					}
				} 
				sb.Append("</tr>"); 

				//写出数据 
				foreach (DataRow row in tb.Rows) 
				{ 
					sb.Append("<tr>"); 
					foreach (DataColumn column in tb.Columns) 
					{ 
						if (column.ColumnName.Equals("证件编号") || column.ColumnName.Equals("报名编号")) 
							sb.Append("<td style=\"vnd.ms-excel.numberformat:@\">" + row[column].ToString() + "</td>"); 
							////style="vnd.ms-excel.numberformat:@" 可以去除自动科学计数法的困扰 
						else 
							sb.Append("<td>" + row[column].ToString() + "</td>"); 
					} 
					sb.Append("</tr>"); 
					count++; 
				} 
				sb.Append("</table>"); 
			//} 

			return sb.ToString(); 
		} 

//		public void ExportDsToXls(Page page, string sql)
//		{
//			ExportDsToXls(page, "FileName", sql);
//		}
//		public void ExportDsToXls(Page page, string fileName, string sql)
//		{
//			DataSet ds = DBUtil.GetDataSet(sql);
//			if (ds != null) ExportDsToXls(page, fileName, ds);
//		}
		public void ExportToXls(Page page, string strfile)
		{
			ExportToXls(page, "FileName", strfile);
		}
		public void ExportToXls(Page page, string fileName, string strfile)
		{
			page.Response.Clear();
			page.Response.Buffer = true;
			page.Response.Charset = "GB2312";
			//page.Response.Charset = "UTF-8";
			page.Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + System.DateTime.Now.ToString("_yyyyMMdd_hhmm") + ".xls");
			page.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");//设置输出流为简体中文
			page.Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。 
			page.EnableViewState = false;
			page.Response.Write(strfile);
			page.Response.End();
		}
		#endregion
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
			this.Load += new System.EventHandler(this.Page_Load);
			this.Error +=new EventHandler(wfmBase_Error);
		}
		#endregion
	}
}
