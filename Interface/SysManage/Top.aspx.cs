
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

#endregion

namespace ynhnOilManage.Interface.SysManage
{
	#region 模块注释
	///<summary>
	///作    用：后台管理主菜单及CI信息
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
	
	public class Top : System.Web.UI.Page
	{

		#region 事件处理
		private void Page_Load(object sender, System.EventArgs e)
		{
			
		}
		#endregion

		protected System.Web.UI.WebControls.ImageButton btnDocManage;
		protected System.Web.UI.WebControls.ImageButton btnDocSearch;
		protected System.Web.UI.WebControls.ImageButton btnSysManage;
		protected System.Web.UI.WebControls.ImageButton btnExit;
		protected System.Web.UI.WebControls.ImageButton btnTotalReport;



		#region 设计器必须成员变量

		protected System.Web.UI.WebControls.ImageButton btnTCGL;
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
