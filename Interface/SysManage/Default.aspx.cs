
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

using System.Configuration;

#endregion

namespace ynhnOilManage.Interface.SysManage
{
	#region 模块注释

	///<summary>
	///作    用：启动后台管理时显示欢迎界面并导航至登录模块
	///作    者：Fightop Lin
	///编写日期：2003-11-11
	///</summary>
	
	///<summary>
	///Log编 号：
	///修改描述：
	///作    者：
	///修改日期：
	///</summary>
	
	#endregion

	public class _Default : System.Web.UI.Page
	{
		#region 页面加载事件处理
		public string WebSiteTitle;
		private void Page_Load(object sender, System.EventArgs e)
		{  // 页面加载事件处理

			this.WebSiteTitle = CommonStatic.WebSiteTitle();

			string strJavaScript =	"<script language='javascript'>"               +
				"window.resizeTo(640,480);"                                        +
				"window.moveTo(screen.availWidth/2-320,screen.availHeight/2-240);" +	
   
				"function FullScreen()"                                            +
				"{"                                                                +
				"window.moveTo(0,0);"                                              +
				"window.resizeTo(screen.availWidth,screen.availHeight);"           +
				"var thewindow = window.open('Login.aspx', '_top');"               +
				"thewindow.focus(); "                                              +
				"}"                                                                +
         
				"setTimeout('FullScreen()',5000);"                                 +
				"</script>";  //  客户端代码声明，该代码完成开起全屏登录窗口

			Page.RegisterClientScriptBlock("FullScreen",strJavaScript);  // 注入代码

		}

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
