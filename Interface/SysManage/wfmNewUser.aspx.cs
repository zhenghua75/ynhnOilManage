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
using ynhnOilManage.BusinessFacade.SysManage;

namespace ynhnOilManage.Interface.SysManage
{
	/// <summary>
	/// Summary description for wfmNewUser.
	/// </summary>
	public class wfmNewUser : wfmBase
	{
		protected System.Web.UI.WebControls.Label lblOperID;
		protected System.Web.UI.WebControls.TextBox txtOperID;
		protected System.Web.UI.WebControls.Label lblOperName;
		protected System.Web.UI.WebControls.TextBox txtOperName;
		protected System.Web.UI.WebControls.ImageButton btnOK;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvOperID;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvOperName;
		protected System.Web.UI.WebControls.RangeValidator rvOper;
		protected System.Web.UI.WebControls.ImageButton btnCancel;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.btnOK.Click += new System.Web.UI.ImageClickEventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.Web.UI.ImageClickEventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void btnOK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//添加用户
			try
			{
				if (txtOperID.Text.Length == 0 || txtOperName.Text.Length == 0)
				{
					throw new BusinessException("AddOper","不能为空！");
				}
				
				if (GetLength(txtOperID.Text) >8)
				{
					throw new BusinessException("","操作员ID过长！");
				}
				if (GetLength(txtOperName.Text) >20)
				{
					throw new BusinessException("","操作员姓名过长！");
				}
				Oper oper = new Oper();
				oper.cnvcOperName = txtOperID.Text;
				Oper oldOper = OperFacade.GetOper(oper);
				if (oldOper == null)
				{
					oper.cnvcOperName = txtOperName.Text;
					oper.cnvcPwd = "666666";
					//OperFacade.AddOper(oper);
					Popup("新建用户成功！");

				}
				else
				{
					Popup("用户已存在！");
				}
				
				CommonStatic.LoadOperDictionary();
				
			}
			catch (BusinessException bex)
			{
				Popup(bex.Message);
			}
			
		}

		private void btnCancel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//
			txtOperID.Text = "";
			txtOperName.Text = "";
		}

		private int GetLength(string strIn)
		{
			int lens = strIn.Length;
			char[] chars = strIn.ToCharArray();
			for(int i=0;i<chars.Length;i++)
			{         
				if(System.Convert.ToInt32( chars[i] )>255)
				{
					lens++;
				}
			} 
			return lens;
		}
	}
}
