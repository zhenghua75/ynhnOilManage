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
using ynhnOilManage.Common;
using ynhnOilManage.EntityObject.EntityClass;

using System.Globalization;
using System.Threading;

namespace ynhnOilManage.Interface.Report
{
	/// <summary>
	/// Summary description for DataGridToExcel.
	/// </summary>
	public class DataGridToExcel : System.Web.UI.Page
	{
		protected ucPageView UcPageView1 ;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
//			this.Response.Expires = -1;
//			this.Response.ExpiresAbsolute = DateTime.Now.AddMilliseconds(-1);
//			this.Response.CacheControl = "no-cache";
			this.Response.Clear();
			this.Response.Buffer = true;
			if(Session["QUERY"] != null)
			{
				
				UcPageView1.MyDataGrid.PageSize = 60000;
				DataTable dtOut	= (DataTable)Session["QUERY"];
				//string ExcelName = "xxx.xls";
				string ExcelName =dtOut.TableName + System.DateTime.Now.ToString("_yyyyMMdd");
				//Session.Remove("QUERY");
				if(dtOut.Rows.Count > 0)
				{
					DataView dvOut =new DataView(dtOut);
					this.UcPageView1.MyDataSource = dvOut;	
					this.UcPageView1.BindGrid();

					string Caption = "";
					int colspan = dtOut.Columns.Count;
					if(Session["ExcelCaption"] != null)
					{
						Caption = Session["ExcelCaption"].ToString();
						//Session.Remove("ExcelCaption");
						//ExcelName = Caption;
					}
					string Bottom = "";
					if(Session["ExcelBottom"] != null)
					{
						Bottom = Session["ExcelBottom"].ToString();
						//Session.Remove("ExcelBottom");
					}

					Response.AddHeader("Content-Disposition","inline; filename="+System.Web.HttpUtility.UrlEncode(ExcelName)+".xls");
					Response.ContentType = "application/vnd.ms-excel";
					Response.Charset = "UTF-8";
					Response.ContentEncoding = System.Text.Encoding.UTF8;
					EnableViewState = false;

					System.IO.StringWriter tw = new System.IO.StringWriter();
					System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
					UcPageView1.MyDataGrid.RenderControl(hw);
					
					Response.Write( Caption + tw.ToString() + Bottom);
					UcPageView1.MyDataGrid.PageSize = 20;					
					Response.End();					
				}
			}
		}
		
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

		}
		#endregion
	}
}
