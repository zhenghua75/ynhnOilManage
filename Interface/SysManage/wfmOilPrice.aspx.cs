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
using ynhnOilManage.BusinessFacade.SysManage;
using ynhnOilManage.EntityObject.EntityBase;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.Common;
namespace ynhnOilManage.Interface.SysManage
{
	/// <summary>
	/// wfmOilPrice 的摘要说明。
	/// </summary>
	public class wfmOilPrice : wfmBase
	{
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtPriceDate;
		protected System.Web.UI.WebControls.TextBox txtOilPrice;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.TextBox txtGoodsName1;
		protected System.Web.UI.WebControls.TextBox txtGoodsType1;
		protected System.Web.UI.WebControls.TextBox txtUnit1;
		protected System.Web.UI.WebControls.TextBox txtPriceDate1;
		protected System.Web.UI.WebControls.TextBox txtOilPrice1;
		protected System.Web.UI.WebControls.DropDownList ddlUnit;
		protected System.Web.UI.WebControls.DropDownList ddlGoodsName;
		protected System.Web.UI.WebControls.DropDownList ddlGoodsType;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if (!IsPostBack)
			{
				BindDept(ddlDept);

				BindGoodsName(ddlGoodsName);
//				DataTable dtGoodsName = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign='GoodsName'");
//				
//
//				ddlGoodsName.DataSource = dtGoodsName;
//				ddlGoodsName.DataTextField = "cnvcCommName";
//				ddlGoodsName.DataValueField = "cnvcCommCode";
//				ddlGoodsName.DataBind();

				
//				DataTable dtGoodsType = ReportQueryFacade.CommonQuery("select * from tbCommCode where cnvcCommSign='GoodsType"+ddlGoodsName.SelectedValue+"'");
//				ddlGoodsType.DataSource = dtGoodsType;
//				ddlGoodsType.DataTextField = "cnvcCommName";
//				ddlGoodsType.DataValueField = "cnvcCommCode";
//				ddlGoodsType.DataBind();

				BindGoodsType(ddlGoodsType,ddlGoodsName.SelectedValue);

				ddlDept_SelectedIndexChanged(null,null);

//				if ( null != Session[ConstValue.LOGIN_DEPT_SESSION])
//				{
//					Dept dept = (Dept)Session[ConstValue.LOGIN_DEPT_SESSION];
//					if (dept.cnvcDeptID != "00")
//					{
//						ListItem li = ddlDept.Items.FindByText(dept.cnvcDeptName);
//						ddlDept.SelectedIndex = ddlDept.Items.IndexOf(li);						
//						ddlDept.Enabled = false;
//					}
//				}
			}
		}

		
//		private void BindDept(DropDownList ddl)
//		{
//			DataTable dtDept = DeptFacade.GetAllDept();
//			ddl.DataSource = dtDept;
//			ddl.DataTextField = "cnvcDeptName";
//			ddl.DataValueField = "cnvcDeptID";
//			ddl.DataBind();
//		}

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
			this.ddlDept.SelectedIndexChanged += new System.EventHandler(this.ddlDept_SelectedIndexChanged);
			this.ddlGoodsName.SelectedIndexChanged += new System.EventHandler(this.ddlGoodsName_SelectedIndexChanged);
			this.ddlGoodsType.SelectedIndexChanged += new System.EventHandler(this.ddlGoodsType_SelectedIndexChanged);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			txtOilPrice.Text = "";	
		
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				decimal.Parse(txtOilPrice.Text);
			}
			catch (System.Exception)
			{
				this.Popup("请输入正确油价！");
			}
			if (txtOilPrice.Text == "")
			{
				this.Popup("请填写参数");
				return;
			}
			OilPrice price = new OilPrice();
			price.cnnSerialNo = Guid.NewGuid();
			price.cndPriceDate = DateTime.Now;
			price.cnnOilPrice = decimal.Parse(txtOilPrice.Text);
			price.cnvcDeptName = ddlDept.SelectedItem.Text;
			price.cnvcGoodsName = ddlGoodsName.SelectedItem.Text;
			price.cnvcGoodsType = ddlGoodsType.SelectedItem.Text;
			price.cnvcUnit = ddlUnit.SelectedItem.Text;
			price.cndPriceDate = DateTime.Parse(txtPriceDate.Text+" "+DateTime.Now.ToLongTimeString());

			Dept curDept = Session[ConstValue.LOGIN_DEPT_SESSION] as Dept;
			Oper curOper =Session[ConstValue.LOGIN_USER_SESSION] as Oper; 
			BusiLog busiLog = new BusiLog();
			busiLog.cndOperDate = DateTime.Now;
			busiLog.cnnSerial = Guid.NewGuid();
			busiLog.cnvcOperName = curOper.cnvcOperName;
			busiLog.cnvcComments = "添加油价："+price.cnvcDeptName+"|"+price.cnnOilPrice.ToString();
			busiLog.cnvcDeptID = curDept.cnvcDeptID;
			busiLog.cnvcDeptName = curDept.cnvcDeptName;
			busiLog.cnvcOperType = "BS004";
			busiLog.cnvcSource = "网站";

			DeptFacade.AddOilPrice(price,busiLog);
			Popup("油价添加成功");
			ddlDept_SelectedIndexChanged(null,null);
		}

		private void ddlDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//显示最新油价
			string strSql = "select  top 1 * from tbOilPrice where cnvcDeptName = '"+ddlDept.SelectedItem.Text+"' and cnvcGoodsName='"+ddlGoodsName.SelectedItem.Text+"' and cnvcGoodsType='"+ddlGoodsType.SelectedItem.Text+"' order by cndPriceDate desc,cnnSerialNo desc" ;
			DataTable dtOilPrice = ReportQueryFacade.CommonQuery(strSql);
			if (dtOilPrice.Rows.Count > 0)
			{
				OilPrice price = new OilPrice(dtOilPrice);
				txtOilPrice1.Text = price.cnnOilPrice.ToString();
				txtGoodsName1.Text = price.cnvcGoodsName;
				txtGoodsType1.Text = price.cnvcGoodsType;
				txtUnit1.Text = price.cnvcUnit;
				txtPriceDate1.Text = price.cndPriceDate.ToString("yyyy-MM-dd");
			}
			
			
		}

		private void ddlGoodsName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindGoodsType(ddlGoodsType,ddlGoodsName.SelectedValue);
			//
			ddlDept_SelectedIndexChanged(null,null);
			//
			
		}
		
		private void ddlGoodsType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ddlDept_SelectedIndexChanged(null,null);
		}
	}
}
