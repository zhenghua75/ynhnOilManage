<%@ Page language="c#" Codebehind="wfmDeptUserManage.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.SysManage.wfmDeptUserManage" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<LINK href="window.css" type="text/css" rel="stylesheet">
			<style>.Menu { BORDER-RIGHT: #cccccc 1px solid; BORDER-TOP: #cccccc 2px solid; BORDER-LEFT: #cccccc 2px solid; BORDER-BOTTOM: #cccccc 1px solid }
	.Up_Menu { BORDER-RIGHT: #ffffff 1px outset; BORDER-TOP: 2px outset; BORDER-LEFT: 2px outset; BORDER-BOTTOM: #ffffff 1px outset; BACKGROUND-COLOR: #cccccc }
	.Dn_Menu { BORDER-RIGHT: 1px inset; BORDER-TOP: 2px inset; BORDER-LEFT: 2px inset; BORDER-BOTTOM: 1px inset; BACKGROUND-COLOR: #cccccc }
	BODY { FONT-SIZE: 15px; FONT-FAMILY: tahoma,verdana,arial; TEXT-DECORATION: none }
	TABLE { FONT-SIZE: 15px; FONT-FAMILY: tahoma,verdana,arial; TEXT-DECORATION: none }
	INPUT { FONT-SIZE: 15px; FONT-FAMILY: tahoma,verdana,arial; TEXT-DECORATION: none }
	FORM { FONT-SIZE: 15px; FONT-FAMILY: tahoma,verdana,arial; TEXT-DECORATION: none }
	A { FONT-SIZE: 15px; FONT-FAMILY: tahoma,verdana,arial; TEXT-DECORATION: none }
	SELECT { FONT-SIZE: 15px; FONT-FAMILY: tahoma,verdana,arial; TEXT-DECORATION: none }
	BUTTON { FONT-SIZE: 15px; FONT-FAMILY: tahoma,verdana,arial; TEXT-DECORATION: none }
	A { CURSOR: default; COLOR: #000000; TEXT-DECORATION: none }
	.TreeSelectNode { BORDER-RIGHT: limegreen 1px solid; BORDER-TOP: limegreen 1px solid; FONT-SIZE: 15px; BACKGROUND: infobackground; BORDER-LEFT: limegreen 1px solid; BORDER-BOTTOM: limegreen 1px solid; FONT-FAMILY: 宋体 }
	.ListBody { SCROLLBAR-FACE-COLOR: #cccccc; SCROLLBAR-HIGHLIGHT-COLOR: white; SCROLLBAR-SHADOW-COLOR: #94a9d6; SCROLLBAR-3DLIGHT-COLOR: #94a9d6; SCROLLBAR-ARROW-COLOR: #94a9d6; SCROLLBAR-TRACK-COLOR: #e0e4e4; SCROLLBAR-DARKSHADOW-COLOR: #94a9d6; SCROLLBAR-BASE-COLOR: #cccccc }
	BUTTON { FONT-SIZE: 15px; BACKGROUND-IMAGE: url(images/buttonbg.gif); FONT-FAMILY: 宋体 }
	</style>
			<script language="javascript">
		//树操作
		
		function SelectNode(node)
		{
			var arr = new Array();
			collectParentNode(node);
			if(arr.length != 0)
			{
				for(var i=arr.length -1;i>=0;i--)
					arr[i].setAttribute("expanded",true);
			}
			tv.selectedNodeIndex = node.getNodeIndex();
			DisplayNode(node);
			function collectParentNode(node)
			{
				var parentNode = node.getParent()
				if(parentNode == tv ||parentNode == null) return;
				arr[arr.length] = parentNode;
				collectParentNode(parentNode);
			}
		}
		
		function SearchNode(nodes,id)
		{
			if(nodes != null)
			{
				for(var i=0;i<nodes.length;i++)
				{
					var node = nodes[i];
					if(node.getAttribute("ID") == id)
						return node;
					node = SearchNode(node.getChildren(),id);
					if(node !=null)
						return node;
				}
			}
			return null;
		}

		
		function AddNode(parentNode,type,id,name)
		{
			var node = tv.createTreeNode();
			node.setAttribute("Type",type);
			node.setAttribute("ID",MakeWebID(type,id));
			node.setAttribute("Text",name);
			switch(type)
			{
			case "oper":
				node.setAttribute("ImageUrl","../images/tree/img-User.gif");
				break;
			case "dept":
				node.setAttribute("ImageUrl","../images/tree/img-organizationalUnit.gif");
				break;
			}
			parentNode.add(node);
			return node;
		}
		
		function ChangeNodeName(node,name)
		{
			node.setAttribute("Text",name);
		}
		
		function RemoveNode(node)
		{
			node.remove();
		}
		
		function MoveNode(sonNode,parentNode)
		{
			sonNode.remove();
			parentNode.add(sonNode);
		}
		
		
		function MakeWebID(type,id)
		{
			return type+"_"+id;			
		}
		
		function GetActualID(webId)
		{
			var index = webId.indexOf("_");
			return webId.substring(index+1);
		}
		
		function GetSelectedNode(tree)
		{
			return tree.getTreeNode(tree.selectedNodeIndex);
		}
		
		//事件处理
		
		function OnAddNodeResult(parentId,id,name)
		{
			var parentNode = SearchNode(tv.getChildren(),parentId);
			var ss = id.split("_");
			if(ss ==null ||ss.length<2) return;
			var node = AddNode(parentNode,ss[0],ss[1],name);
			SelectNode(node);
		}
		
		function OnChangeNodeResult(id,name)
		{
			var node = SearchNode(tv.getChildren(),id);
			if(node !=null)
			{
				ChangeNodeName(node,name);
			}
		}
		
		function ChangeOperPassword(operId)
		{
			var strWin = "dialogWidth:450px;dialogHeight:450px;center:1;resizable:no;scroll:0;help:0;status:0";
			var strUrl="ChangePassword.aspx?OperID="+operId;
			window.showModalDialog(strUrl,null,strWin);
		}
		
		function onInit()
		{
			tv.onselectedindexchange = tv_onselectedindexchange;
			DisplayNode(GetSelectedNode(tv));
		}
		
		function HandeSubMenu()
		{
			switch(event.menuId)
			{
				case "ChangePassword":
				{
					var node = GetSelectedNode(tv);
					if( node == null || node.getAttribute("Type")!="oper") return;
					var operId = GetActualID(node.getAttribute("ID"));
					ChangeOperPassword(operId);
					break;
				}
				case "FindUser":
					subframe.location="SearchUser.aspx";
					break;
				case "FindDept":
					subframe.location="SearchDept.aspx";
					break;
				case "AddUser":
				{
					var node = GetSelectedNode(tv);
					if(node == null) return;
					subframe.location="UserProperties.aspx?Method=Add&DeptID="+ node.getAttribute("ID");
					break;
				}
				case "AddDept":
				{
					var node = GetSelectedNode(tv);
					if(node == null) return;
					subframe.location="DeptProperties.aspx?Method=Add&ParentDeptID="+ node.getAttribute("ID");
					break;
				}
				case "MoveDept":
				case "MoveUser":
				{
					var node = GetSelectedNode(tv);
					var strID = node.getAttribute("ID");
					MoveObj(strID);
					break;
				}
			}
		}
		
		function MoveObj(srcID)
		{
			var lsWin = "dialogWidth:250px;dialogHeight:350px;center:1;resizable:no;scroll:0;help:0;status:0";
			var loObj = new Object();
			window.showModalDialog("DeptDialog.aspx?SrcID="+srcID,loObj,lsWin);
			if(loObj.dest!=null)
			{
				var srcNode = SearchNode(tv.getChildren(),loObj.src);
				var destNode = SearchNode(tv.getChildren(),loObj.dest);
				if(srcNode == null || destNode ==null) return;
				MoveNode(srcNode,destNode);
				SelectNode(srcNode);
			}
		}
	
		function SelectNodeByID(id)
		{
			var node = SearchNode(tv.getChildren(),id);
			if(node != null)
			{
				SelectNode(node);
				/*
				var evt = document.createEventObject();
				evt.newTreeNodeIndex = node.getNodeIndex();
				tv.fireEvent("onselectedindexchange",evt);
				*/
			}
		}
		
		function DisplayNode(node)
		{
			if(node == null) return;
			switch(node.getAttribute("Type"))
			{
			case "oper":
/*			
				if(Menu.xmlsrc!="../../js/UserMenu.xml")
				{
					Menu.xmlsrc="../../js/UserMenu.xml";
					Menu.Reload();
				}
*/
				subframe.location="UserProperties.aspx?Method=Show&OperID="+node.getAttribute("ID");
				break;
			case "dept":
/*
				if(Menu.xmlsrc!="../../js/DeptMenu.xml")
				{
					Menu.xmlsrc="../../js/DeptMenu.xml";
					Menu.Reload();
				}
*/
				subframe.location="DeptProperties.aspx?Method=Show&DeptID="+node.getAttribute("ID");
				break;
			}
			
		}
		
		function tv_onselectedindexchange()
		{
			var node = tv.getTreeNode(event.newTreeNodeIndex);
			DisplayNode(node);
			//SelectNode(node);
			event.returnValue=true;
		}
		
			</script>
	</HEAD>
	<body class="background_group" onload="onInit();">
		<!--
		<table class="table_title_group" id="Table2" cellSpacing="0" cellPadding="3" width="100%"
			border="0">
			<tr height="10">
				<TD align="left" height="25">
					<div id="Menu" style="BEHAVIOR: url(../../js/Menu.htc)" onMenuClick="HandeSubMenu();"
						xmlsrc="../../js/DeptMenu.xml"></div>
				</TD>
			</tr>
		</table>
		-->
		<table class="table_content_grid_group" id="Table1" cellSpacing="0" cellPadding="3" width="100%"
			border="1">
			<tr>
				<td width="30%" height="100%"><iewc:treeview id="tv" style="OVERFLOW: auto" runat="server" SystemImagesPath="../webctrl_client/1_0/TreeImages/"
						Height="800px" ExpandLevel="2"></iewc:treeview></td>
				<td width="70%" height="100%"><iframe id="subframe" style="BACKGROUND-COLOR: #cccccc" border="0" name="subframe" frameBorder="0"
						width="100%" height="800"></iframe></td>
			</tr>
		</table>
	</body>
</HTML>
