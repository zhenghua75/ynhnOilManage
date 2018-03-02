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
namespace ynhnOilManage.Interface.SysManage
{
	/// <summary>
	/// wfmRegister 的摘要说明。
	/// </summary>
	public class wfmRegister : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if (!IsPostBack)
			{
				BindRegister();
			}
		}

		private void BindRegister()
		{
			DataTable dtRegister = ReportQueryFacade.CommonQuery("select * from tbRegister order by cndOperDate");
			this.DataGrid1.DataSource = dtRegister;
			this.DataGrid1.DataBind();
		}

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
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_CancelCommand);
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_EditCommand);
			this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGrid1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.DataGrid1.EditItemIndex=(int)e.Item.ItemIndex;
			
			this.BindRegister();
		}

		private void DataGrid1_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.DataGrid1.EditItemIndex=-1;
			
			this.BindRegister();
		}

		private void DataGrid1_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//(TextBox)(e.Item.Cells[2].Controls[0])).Text
			//Popup(e.Item.Cells[2].Text);
			//Popup(((TextBox)e.Item.Cells[3].Controls[0]).Text);
			string strHddSerial = e.Item.Cells[2].Text;
			string strRegister = ((TextBox)e.Item.Cells[3].Controls[0]).Text;
			if (strRegister.Trim() == "")
			{
				Popup("请输入注册码");
				return;
			}
			try
			{
				ReportQueryFacade.CommonQuery("update tbRegister set cnvcRegister='"+strRegister+"' where cnvcHddSerialNo='"+strHddSerial+"'");
				Popup("注册成功！");
			}
			catch (System.Exception ex)
			{
				Popup(ex.Message);
			}
			this.DataGrid1.EditItemIndex=-1;

			this.BindRegister();
			
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			this.BindRegister();
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//
			if(e.Item.ItemType==ListItemType.EditItem)  
			{   
				TextBox   textBox   =   (TextBox)e.Item.Cells[3].Controls[0];//n为列的值  
				textBox.Width   =  System.Web.UI.WebControls.Unit.Pixel(350);//要设置的宽度  
			}
		}
	}
}
