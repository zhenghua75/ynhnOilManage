
#region 名称空间引用

using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Configuration;
using System.Web.Security;

#endregion

namespace ynhnOilManage.Interface
{
	#region 模块注释

	///<summary>
	///作    用：定义公共成员,并完成初始化工作
	///作    者：Fightop Lin
	///编写日期：2003-11-11
	///</summary>
	
	///<summary>
	///Log编 号：1
	///修改描述：加入数据库连接字符串静态变量，并在Application_Start事件中初始化
	///作    者：Fightop Lin
	///修改日期：2003-11-12
	///</summary>
	
	#endregion

	public class Global : System.Web.HttpApplication
	{

		#region 构造器

		public Global()
		{
			InitializeComponent();
		}	
		
		#endregion


		#region 事件处理

		protected void Application_Start(Object sender, EventArgs e)
		{
			CommonStatic.LoadOperDictionary();
			CommonStatic.LoadDeptDictionary();
		}
 


		protected void Session_Start(Object sender, EventArgs e)
		{
		}



		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			
		}



		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}



		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}



		protected void Application_Error(Object sender, EventArgs e)
		{

		}



		protected void Session_End(Object sender, EventArgs e)
		{
		}



		protected void Application_End(Object sender, EventArgs e)
		{

		}

		#endregion


		#region WEB窗体设计器维护变量

		/// <summary>
		/// 系统运行必须变量
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#endregion

			
		#region Web 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

