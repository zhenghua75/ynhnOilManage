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
	/// wfmRegister ��ժҪ˵����
	/// </summary>
	public class wfmRegister : wfmBase
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
				Popup("������ע����");
				return;
			}
			try
			{
				ReportQueryFacade.CommonQuery("update tbRegister set cnvcRegister='"+strRegister+"' where cnvcHddSerialNo='"+strHddSerial+"'");
				Popup("ע��ɹ���");
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
				TextBox   textBox   =   (TextBox)e.Item.Cells[3].Controls[0];//nΪ�е�ֵ  
				textBox.Width   =  System.Web.UI.WebControls.Unit.Pixel(350);//Ҫ���õĿ��  
			}
		}
	}
}
