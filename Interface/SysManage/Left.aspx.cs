
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

using ynhnOilManage.Common;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.BusinessFacade.SysManage;
#endregion

namespace ynhnOilManage.Interface.SysManage
{
	#region 模块注释
	///<summary>
	///作    用：显示菜单及系统信息
	///作    者：Fightop Lin
	///编写日期：2007-03-07
	///</summary>
	
	///<summary>
	///Log编 号：1
	///修改描述：
	///作    者：
	///修改日期：
	///</summary>
	#endregion
	public class Left : System.Web.UI.Page
	{
		#region 页面加载事件处理
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			#region 设置所有菜单为隐藏

			tblUserInfo.Visible             = false;			
			tblOilReports.Visible           = false;
			tblOilTotalReports.Visible      = false;
			tblOilListReports.Visible       = false;
			tblMemberReports.Visible        = false;
			tblSysManage.Visible            = false;

			#endregion

			#region 显示当前登录用户信息

			//Session.RemoveAll();
			if (Session[ConstValue.LOGIN_USER_SESSION] != null)
			{
				Oper operCurrent =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 
				//this.lblUserId.Text     = operCurrent.cnvcOperName;
				this.lblUserName.Text   = operCurrent.cnvcOperName;

				Hashtable lstDept = new Hashtable();
				DataTable tblDept = DeptFacade.GetAllDept();

				foreach(DataRow row in tblDept.Rows)
				{
					Dept objDept = new Dept(row);
					if(null == lstDept[objDept.cnvcDeptID])
					{
						lstDept.Add(objDept.cnvcDeptID,objDept);
					}
				}
				Dept topDept = new Dept();
				topDept.cnvcDeptName = CommonStatic.EnterpriseShortName();
				topDept.cnvcDeptID = "00";
				lstDept.Add(topDept.cnvcDeptID,topDept);

				
				//Hashtable lstDept = Application[ConstValue.DEPT_DICTI_NAME] as Hashtable;
				Dept deptCurrent = lstDept[operCurrent.cnvcDeptID] as Dept;

				this.lblDeptName.Text = deptCurrent.cnvcDeptName;
				Session[ConstValue.LOGIN_DEPT_SESSION] = deptCurrent;
				
			}
			else
			{
				this.lblDeptName.Text = "";
				this.lblUserName.Text = "";
				//this.lblAddDate.Text = "";
				//this.lblLoginTime.Text = "";
				//this.lblLoginCount.Text = "";

				return;
			}

			#endregion

			

			#region 控制当前显示菜单

			string strShowMenuID = String.Empty;
			if(null != Request[ConstValue.SHOW_MENU_ARGS])
			{
				strShowMenuID = Request[ConstValue.SHOW_MENU_ARGS].ToString();
			}
			switch(strShowMenuID)
			{
				case "tblOilReports":
				case "tblOilTotalReports":
				case "tblOilListReports":
				case "tblMemberReports":
				case "tblSysManage":
					System.Web.UI.HtmlControls.HtmlTable tblCurrent= this.FindControl(strShowMenuID) as HtmlTable;
					tblCurrent.Visible = true;
					SetMenuShowByUserPurview(tblCurrent,tblCurrent,Session[ConstValue.LOGIN_USER_PURVIEW_SESSION] as ArrayList);
					break;
					
			}
			tblUserInfo.Visible = true;

			#endregion
		}


		#endregion

		#region 根据用户权限设置菜单显示

		protected void SetMenuShowByUserPurview(HtmlTable tblMenu,System.Web.UI.Control ctlParent,ArrayList lstUserPurview)
		{
			foreach(System.Web.UI.Control ctl in ctlParent.Controls)
			{
				if(ctl is HyperLink)
				{
					HyperLink linkCurrent = ctl as HyperLink;
					HtmlTableRow trCurrent = tblMenu.FindControl("tr" + linkCurrent.ID.Replace("link",String.Empty)) as HtmlTableRow;
					if(lstUserPurview.BinarySearch(linkCurrent.Text) > -1)
					{
						trCurrent.Visible = true;
					}
					else
					{
						trCurrent.Visible = false;
					}
				}

				SetMenuShowByUserPurview(tblMenu,ctl,lstUserPurview);
			}
		}

		#endregion


		#region 设计器必须的成员变量

		protected System.Web.UI.WebControls.Label lblAddDate;
		protected System.Web.UI.WebControls.Label lblLoginTime;
		protected System.Web.UI.WebControls.Label lblLoginCount;
		protected System.Web.UI.WebControls.Label lblUserName;
		protected System.Web.UI.WebControls.Label lblDeptName;
		protected System.Web.UI.WebControls.HyperLink linkFAQDocModify;
		protected System.Web.UI.WebControls.HyperLink linkMyReturn;
		protected System.Web.UI.WebControls.HyperLink linkFAQDocDel;
		protected System.Web.UI.WebControls.HyperLink linkPurviewManage;
		
		protected System.Web.UI.HtmlControls.HtmlTable tblUserInfo;
		protected System.Web.UI.HtmlControls.HtmlTableRow trFAQDocModify;
		protected System.Web.UI.HtmlControls.HtmlTableRow trFAQDocDel;
		protected System.Web.UI.HtmlControls.HtmlTableRow trPurviewManage;
		protected System.Web.UI.WebControls.HyperLink linkNeed;
		protected System.Web.UI.HtmlControls.HtmlTable tblOilReports;
		protected System.Web.UI.HtmlControls.HtmlTable tblMemberReports;
		protected System.Web.UI.HtmlControls.HtmlTable tblOilListReports;
		protected System.Web.UI.HtmlControls.HtmlTable tblOilTotalReports;
		protected System.Web.UI.HtmlControls.HtmlTableRow trOilDayReport;
		protected System.Web.UI.HtmlControls.HtmlTableRow trOilMonthReport;
		protected System.Web.UI.WebControls.HyperLink linkOilDayReport;
		protected System.Web.UI.WebControls.HyperLink linkOilMonthReport;
		protected System.Web.UI.WebControls.HyperLink linkSpecialOilSumReport;
		protected System.Web.UI.WebControls.HyperLink linkRetailOilSumReport;
		protected System.Web.UI.WebControls.HyperLink linkSpecialOilListReport;
		protected System.Web.UI.WebControls.HyperLink linkRetailOilListReport;
		protected System.Web.UI.WebControls.HyperLink linkSotrageMoveListReport;
		protected System.Web.UI.WebControls.HyperLink linkOilValidateListReport;
		protected System.Web.UI.HtmlControls.HtmlTableRow trSpecialOilSumReport;
		protected System.Web.UI.HtmlControls.HtmlTableRow trRetailOilSumReport;
		protected System.Web.UI.HtmlControls.HtmlTableRow trSpecialOilListReport;
		protected System.Web.UI.HtmlControls.HtmlTableRow trRetailOilListReport;
		protected System.Web.UI.HtmlControls.HtmlTableRow trSotrageMoveListReport;
		protected System.Web.UI.HtmlControls.HtmlTableRow trOilValidateListReport;
		protected System.Web.UI.WebControls.HyperLink linkMemberList;
		protected System.Web.UI.HtmlControls.HtmlTableRow trMemberList;
		protected System.Web.UI.WebControls.HyperLink linkDeptUserManage;
		protected System.Web.UI.HtmlControls.HtmlTableRow trDeptUserManage;
		protected System.Web.UI.WebControls.HyperLink linkOilPrice;
		protected System.Web.UI.HtmlControls.HtmlTableRow trOilPrice;
		protected System.Web.UI.WebControls.HyperLink linkMemberCons;
		protected System.Web.UI.HtmlControls.HtmlTableRow trMemberCons;
		protected System.Web.UI.WebControls.HyperLink linkBusiLogReport;
		protected System.Web.UI.HtmlControls.HtmlTableRow trBusiLogReport;
		protected System.Web.UI.WebControls.HyperLink linkRegister;
		protected System.Web.UI.HtmlControls.HtmlTableRow trRegister;
		protected System.Web.UI.WebControls.HyperLink linkCompanyPrepay;
		protected System.Web.UI.HtmlControls.HtmlTableRow trCompanyPrepay;
		protected System.Web.UI.WebControls.HyperLink linkStorageOilList;
		protected System.Web.UI.HtmlControls.HtmlTableRow trStorageOilList;
		protected System.Web.UI.WebControls.HyperLink linkSpecialOilDept;
		protected System.Web.UI.HtmlControls.HtmlTableRow trSpecialOilDept;
		protected System.Web.UI.WebControls.HyperLink linkOperList;
		protected System.Web.UI.HtmlControls.HtmlTableRow trOperList;
		protected System.Web.UI.HtmlControls.HtmlTableRow trListMod;
		protected System.Web.UI.WebControls.HyperLink linkListMod;
		protected System.Web.UI.WebControls.HyperLink linkOilStorageLog;
		protected System.Web.UI.HtmlControls.HtmlTableRow trOilStorageLog;		
		protected System.Web.UI.HtmlControls.HtmlTable tblSysManage;

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
