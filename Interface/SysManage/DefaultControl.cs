#region 名称空间
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Web.UI.WebControls;
using ynhnOilManage.Common;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.BusinessFacade.SysManage;
using ynhnOilManage.BusinessFacade.Report;
#endregion
namespace ynhnOilManage.Interface.SysManage
{
	/// <summary>
	/// Summary description for RoleControl.
	/// </summary>
	public class DefaultControl
	{

		public static TreeNode DeptNode(Dept dept)
		{
			TreeNode node = new TreeNode();
			node.ID = "dept_"+dept.cnvcDeptID;
			node.Text = dept.cnvcDeptName;
			node.Type = "dept";
			node.ImageUrl="../images/tree/img-organizationalUnit.gif";
			return node;
		}

		public static TreeNode OperNode(Oper oper)
		{
			TreeNode node = new TreeNode();
			node.ID = "oper_"+oper.cnnOperID.ToString();
			node.Text = oper.cnvcOperName;
			node.Type = "oper";
			node.ImageUrl="../images/tree/img-User.gif";
			return node;
		}

		public static TreeNode GetTreeNodeByID(TreeNode root, string id)
		{
			foreach(TreeNode node in root.Nodes)
			{
				if(node.ID.Equals(id))
					return node;
				TreeNode result = GetTreeNodeByID(node,id);
				if(result!=null) return result;
			}
			return null;
		}
		
		public static void FillTree(TreeView tv,bool haveOper)
		{
			DataTable dtOper = ReportQueryFacade.CommonQuery("select * from tbOper order by cnvcOpername");//"OperFacade.GetAllOper();
			DataTable dtDept = ReportQueryFacade.CommonQuery("select * from tbDept order by cnvcDeptName");//OperFacade.GetAllDept();
			
			//最高级部门
			TreeNode tnTop = new TreeNode();
			tnTop.ID = "dept_00";
			tnTop.Type = "dept";
			tnTop.Text = CommonStatic.EnterpriseFullName();

			if (haveOper)
			{
		
				DataRow[] drOpers = dtOper.Select("cnvcDeptID=00");
				foreach (DataRow drOper in drOpers)
				{
					Oper oper = new Oper(drOper);
					TreeNode tnOper = OperNode(oper);
					tnTop.Nodes.Add(tnOper);
				}
			}

			//一级部门
			DataRow[] drDepts = dtDept.Select("cnvcParentDeptID=00");
			foreach (DataRow drDept in drDepts)
			{
				Dept dept = new Dept(drDept);
				TreeNode tnDept = DeptNode(dept);
				FillNode(dtDept,dtOper,tnDept,dept.cnvcDeptID,haveOper);
				tnTop.Nodes.Add(tnDept);
			}
			tv.Nodes.Add(tnTop);
		}

		public static void FillNode(DataTable dtDept,DataTable dtOper,TreeNode tnParent,string strDeptID,bool haveOper)
		{
			if (haveOper)
			{
			
				DataRow[] drOpers = dtOper.Select("cnvcDeptID='"+strDeptID+"'");
				if (drOpers.Length > 0)
				{
			
					foreach (DataRow drOper in drOpers)
					{
						Oper oper = new Oper(drOper);
						TreeNode tnOper = OperNode(oper);
						tnParent.Nodes.Add(tnOper);
					}
				}
			}

			DataRow[] drDepts = dtDept.Select("cnvcParentDeptID='"+strDeptID+"'");
			if (drDepts.Length > 0)
			{
			
				foreach (DataRow drDept in drDepts)
				{
					Dept dept = new Dept(drDept);
					TreeNode tnDept = DeptNode(dept);
					FillNode(dtDept,dtOper,tnDept,dept.cnvcDeptID,haveOper);
					tnParent.Nodes.Add(tnDept);
				}
			}
		}

	}
}
