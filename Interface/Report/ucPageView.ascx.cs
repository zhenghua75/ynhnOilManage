using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;
using ynhnOilManage.Common;

namespace ynhnOilManage.Interface.Report
	{
	/// <summary>
	///		Summary description for wbcPageView.
	///		author yinkai 2003-07-12
	/// </summary>
	public abstract class ucPageView : System.Web.UI.UserControl
	{
		#region ����
		public System.Web.UI.WebControls.DataGrid MyDataGrid;
		public System.Web.UI.WebControls.Label lbPageLabel;
		protected System.Web.UI.WebControls.LinkButton btnGo;
		protected System.Web.UI.WebControls.LinkButton btnLast;
		protected System.Web.UI.WebControls.LinkButton btnNext;
		protected System.Web.UI.WebControls.LinkButton btnPrev;
		protected System.Web.UI.WebControls.LinkButton btnFirst;		
		private System.Data.DataView iCollection;
		public int iRecordCount = 0;
		public System.Web.UI.HtmlControls.HtmlTableRow FootBar;
		#endregion
		public System.Data.DataView MyDataSource
		{
			set{
				this.iCollection = value;
				Session[ConstValue.COMMON_PAGE_VIEW] = value;
			}
			get{
				return this.iCollection;
			}
		}
		
			
		protected void PagerButtonClick(Object sender, EventArgs e) 
		{
			//used by external paging UI
			String arg = ((LinkButton)sender).CommandArgument;
			SetDataGridCurrentPageIndex(MyDataGrid,arg);
			BindGrid();
		}

		protected void MyDataGrid_Page(Object sender, DataGridPageChangedEventArgs e) 
		{
			//used by built-in pager.  CurrentPageIndex already set
			MyDataGrid.CurrentPageIndex = e.NewPageIndex;			
			BindGrid();
		}				

		//��ҳ����
		protected void SetDataGridCurrentPageIndex(DataGrid myDataGrid,string strArg)
		{
			switch(strArg)
			{
				case ("next"):
					if (myDataGrid.CurrentPageIndex < (myDataGrid.PageCount - 1))
						myDataGrid.CurrentPageIndex ++;
					break;
				case ("prev"):
					if (myDataGrid.CurrentPageIndex > 0)
						myDataGrid.CurrentPageIndex --;
					break;
				case ("last"):
					myDataGrid.CurrentPageIndex = (myDataGrid.PageCount - 1);
					break;
				case ("jump"):
					int iTempIndex = Convert.ToInt16(Request["page_number"])-1;//PageNumber.Value)-1;
					if(iTempIndex > myDataGrid.PageCount-1)
						iTempIndex = myDataGrid.PageCount-1;
					if(iTempIndex < 0)
						iTempIndex = 0;
					myDataGrid.CurrentPageIndex = iTempIndex;
					break;
				default:
					//page number
					myDataGrid.CurrentPageIndex = Convert.ToInt32(strArg);
					break;
			}			
		}	
		   
		//����Դ��
		public void BindGrid() 
		{
			if(this.iCollection!=null)
			{
				MyDataGrid.DataSource = this.iCollection;		
				MyDataGrid.CurrentPageIndex = 0;
				this.iRecordCount = this.iCollection.Count;
			}
			else
			{
				MyDataGrid.DataSource = (DataView)Session[ConstValue.COMMON_PAGE_VIEW];				
				this.iRecordCount = ((DataView)Session[ConstValue.COMMON_PAGE_VIEW]).Count;
			}
			if(this.iRecordCount>0)
			{
				this.FootBar.Visible = true;
			}
			else
			{
				this.FootBar.Visible = false;
			}			
			MyDataGrid.DataBind();			
			ShowPageLabel(lbPageLabel);			
		}

		//jjz 2005-12-30 ����ҳ�������
		public void BindGridPage(int iPageIndex) 
		{
			if(this.iCollection!=null)
			{
				MyDataGrid.DataSource = this.iCollection;		
				MyDataGrid.CurrentPageIndex = iPageIndex;
				this.iRecordCount = this.iCollection.Count;
			}
			else
			{
				MyDataGrid.DataSource = (DataView)Session[ConstValue.COMMON_PAGE_VIEW];				
				this.iRecordCount = ((DataView)Session[ConstValue.COMMON_PAGE_VIEW]).Count;
			}
			if(this.iRecordCount>0)
			{
				this.FootBar.Visible = true;
			}
			else
			{
				this.FootBar.Visible = false;
			}			
			MyDataGrid.DataBind();			
			ShowPageLabel(lbPageLabel);			
		}

		public void DebindGrid()
		{
			MyDataGrid.DataSource = null;
			if (null != Session[ConstValue.COMMON_PAGE_VIEW])
			{
				Session.Remove(ConstValue.COMMON_PAGE_VIEW);
			}
			
			this.FootBar.Visible = false;
			MyDataGrid.DataBind();
		}

		//��ȡ
		public void ShowPageLabel(Label myLable) 
		{
				myLable.Text = "�� " + (MyDataGrid.CurrentPageIndex+1) +" ҳ/�� " + MyDataGrid.PageCount+" ҳ����"+this.iRecordCount+"����¼";
		}

		private void MyDataGrid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
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
		
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{			
			this.FootBar.Visible = false;
			if(Session[ConstValue.COMMON_PAGE_VIEW]!=null)
			{
				if(((DataView)Session[ConstValue.COMMON_PAGE_VIEW]).Count>0)
				{
					this.FootBar.Visible = true;
				}

			}
			if(MyDataGrid.DataSource!=null)
			{
				if(((DataView)MyDataGrid.DataSource).Count>0)
				{
					this.FootBar.Visible = true;
				}
			}		
			
		}
	
	}
}
