<%@ Register TagPrefix="expo" Namespace="ynhnOilManage.Interface.SysManage" Assembly="Interface" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Page language="c#" Codebehind="DeptDialog.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.SysManage.DeptDialog" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>选择部门</title>
		<style> 
	BODY { BORDER-RIGHT: #8094b9 1px solid; BORDER-TOP: #b2ccff 1px solid; BACKGROUND: #dfdfdf; OVERFLOW: hidden; BORDER-LEFT: #b2ccff 1px solid; CURSOR: default; COLOR: #000000; BORDER-BOTTOM: #8094b9 1px solid } 
	BODY { FONT-SIZE: 12px; FONT-FAMILY: tahoma,verdana,arial; TEXT-DECORATION: none } 
	TABLE { FONT-SIZE: 12px; FONT-FAMILY: tahoma,verdana,arial; TEXT-DECORATION: none } 
	INPUT { FONT-SIZE: 12px; FONT-FAMILY: tahoma,verdana,arial; TEXT-DECORATION: none } 
	FORM { FONT-SIZE: 12px; FONT-FAMILY: tahoma,verdana,arial; TEXT-DECORATION: none } 
	A { FONT-SIZE: 12px; FONT-FAMILY: tahoma,verdana,arial; TEXT-DECORATION: none } 
	SELECT { FONT-SIZE: 12px; FONT-FAMILY: tahoma,verdana,arial; TEXT-DECORATION: none } 
	BUTTON { FONT-SIZE: 12px; FONT-FAMILY: tahoma,verdana,arial; TEXT-DECORATION: none } 
	A { CURSOR: default; COLOR: #000000; TEXT-DECORATION: none } 
	.TreeSelectNode { BORDER-RIGHT: limegreen 1px solid; BORDER-TOP: limegreen 1px solid; FONT-SIZE: 12px; BACKGROUND: infobackground; BORDER-LEFT: limegreen 1px solid; BORDER-BOTTOM: limegreen 1px solid; FONT-FAMILY: 宋体 } 
	.ListBody { SCROLLBAR-FACE-COLOR: #cccccc; SCROLLBAR-HIGHLIGHT-COLOR: white; SCROLLBAR-SHADOW-COLOR: #94a9d6; SCROLLBAR-3DLIGHT-COLOR: #94a9d6; SCROLLBAR-ARROW-COLOR: #94a9d6; SCROLLBAR-TRACK-COLOR: #e0e4e4; SCROLLBAR-DARKSHADOW-COLOR: #94a9d6; SCROLLBAR-BASE-COLOR: #cccccc } 
	BUTTON { FONT-SIZE: 12px; BACKGROUND-IMAGE: url(images/buttonbg.gif); FONT-FAMILY: 宋体 } 
	</style>
	</HEAD>
	<Body onload="onInit();">
		<form id="DeptDialog" method="post" runat="server" onsubmit="return DeptDialog_onsubmit();"
			target="DeptDialog">
			<iewc:treeview id="tv" style="OVERFLOW:auto" runat="server" SystemImagesPath="../../../webctrl_client/1_0/TreeImages/"
				Width="250" Height="250" ExpandLevel="2"></iewc:treeview>
			<table cellpadding="2" width="250">
				<tr>
					<td align="left">
						<asp:button id="btnSubmit" runat="server" Text="选定部门"></asp:button>
					</td>
					<td align="right">
						<button onclick="window.opener=null;window.close();" ID="Button2" type="button">关闭窗口</button>
					</td>
				</tr>
			</table>
			<input type="hidden" id="hidSrcID" runat="server"> <input type="hidden" id="hidDestID" runat="server">
		</form>
		<expo:alertcontrol id="alertControl" runat="server" Enable="false"></expo:alertcontrol>
		<script language="javascript">
		var loDialog = dialogArguments;
	
		function GetSelectedNode(tree)
		{
			return tree.getTreeNode(tree.selectedNodeIndex);
		}
		
		function DeptDialog_onsubmit()
		{
			if(tv.selectedNodeIndex == null) return false;
			var node = GetSelectedNode(tv);
			DeptDialog.hidDestID.value=node.getAttribute("ID");
			return true;
		}
		
		function onInit()
		{
			window.name="DeptDialog";
		}
		</script>
	</Body>
</HTML>
