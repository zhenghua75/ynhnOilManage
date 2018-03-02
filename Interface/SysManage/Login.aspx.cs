
#region 名字空间引用

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

using System.Data.SqlClient;

using ynhnOilManage.Common;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.BusinessFacade.SysManage;

#endregion


namespace ynhnOilManage.Interface.SysManage
{
	#region 模块注释
	///<summary>
	///作    用：进行用户身份验证，并初始化用户操作权限
	///作    者：Fightop Lin
	///编写日期：2003-03-07
	///</summary>
	
	///<summary>
	///Log编 号：1
	///修改描述：
	///作    者：
	///修改日期：
	///</summary>
	#endregion
	
	public class Login : System.Web.UI.Page
	{
		#region 页面加载事件处理
		public string WebSiteTitle;
		private void Page_Load(object sender, System.EventArgs e)
		{  // 页面加载事件处理
			this.WebSiteTitle = CommonStatic.WebSiteTitle();
			if ( !Page.IsPostBack)
			{  // 如果条一次加载页面
				//this.tblAvi.Visible = false;  // 置登录成功进入管理动画为不可见

				//用户信息置空
				this.tbxAdminUser.Text = "";
				this.tbxAdminPass.Text = "";
			}

		}

		#endregion

		#region 退出登录处理

		private void btnExit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{  // 退出按钮单击事件管理
			string strJavaScript = "<script language='JavaScript'>" +
				                   "window.close();" +
				                   "</script>";
			Page.RegisterClientScriptBlock("ExitApp",strJavaScript);  // 向客户端发送关闭浏览器脚本
		}

		#endregion

		#region 用户登录处理
		private void btnLogin_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				//调用业务规则
				ArrayList lstPurview = null;
				ArrayList lstPage    = null;
				Oper operLogin = OperFacade.OperLogin(tbxAdminUser.Text.Trim(),tbxAdminPass.Text,Request.UserHostAddress,Request.Browser.Browser,out lstPurview,out lstPage);

				//将用户信息保存到Session变量
				Session[ConstValue.LOGIN_USER_SESSION] = operLogin;

				//将用户菜单权限保存到Session变量
				Session[ConstValue.LOGIN_USER_PURVIEW_SESSION] = lstPurview;
				//将用户页面权限保存到Session变量
				Session[ConstValue.LOGIN_USER_PAGE_SESSION] = lstPage;
				

				tblInput.Visible = false;  // 置用户信息输入框为不可见
				//tblAvi.Visible = true;     // 置登录成功动画为可见,在登录成功动画的最后一帧将页面导航至Main.aspx
				this.Response.Redirect("main.aspx");
			}
			catch(BusinessException be)
			{
				string strScript = "<script language='javascript'>";
				strScript       += "alert('" + be.Message + "');";
				strScript       += "</script>";

				Response.Write(strScript);
			}
		}

		#endregion


		#region 设计器必须成员变量
		protected System.Web.UI.WebControls.TextBox tbxAdminUser;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvAdminUser;
		protected System.Web.UI.WebControls.RegularExpressionValidator revAdminUser;
		protected System.Web.UI.WebControls.TextBox tbxAdminPass;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvAdminPass;
		protected System.Web.UI.WebControls.ImageButton btnLogin;
		protected System.Web.UI.WebControls.ImageButton btnExit;
		protected System.Web.UI.HtmlControls.HtmlTable tblInput;
		protected System.Web.UI.HtmlControls.HtmlTable tblAvi;
		/// <summary>
		/// 设计器维护变量。
		/// </summary>
		#endregion

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnLogin.Click += new System.Web.UI.ImageClickEventHandler(this.btnLogin_Click);
			this.btnExit.Click += new System.Web.UI.ImageClickEventHandler(this.btnExit_Click);
			this.ID = "frmLogin";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
