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
using System.Text;
using ynhnOilManage.Common;
using ynhnOilManage.BusinessFacade.SysManage;
namespace ynhnOilManage.Interface.SysManage
{
	/// <summary>
	/// Summary description for main.
	/// </summary>
	public class wfmDeptUserManage :  wfmBase
	{
		protected Microsoft.Web.UI.WebControls.TreeView tv;

		
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.Response.Expires = 0;
			if(!IsPostBack)
			{                
				//tv.Nodes.Clear();
				
				DefaultControl.FillTree(tv,true);
			}
		}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			base.OnInit(e);
			InitializeComponent();
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
