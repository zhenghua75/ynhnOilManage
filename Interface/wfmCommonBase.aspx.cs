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

namespace ynhnOilManage.Interface
{
	/// <summary>
	/// Summary description for wfmCommonBase.
	/// 无权限控制页面基类
	/// 郑华　2007-3-21
	/// </summary>
	public class wfmCommonBase : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (Session[ConstValue.LOGIN_USER_SESSION] == null || Session[ConstValue.LOGIN_USER_PURVIEW_SESSION] == null)
			{
				this.Response.Redirect("Default.aspx");
			}
		}
		//弹出窗口
		public void Popup(string strComments)
		{
			this.Response.Write("<script>alert('"+strComments+"');</script>");
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
