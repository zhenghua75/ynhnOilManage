<%@ Page language="c#" Codebehind="wfmAuthorization.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.SysManage.wfmAuthorization" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmAuthorization</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body scroll="yes">
		<form id="Form1" method="post" runat="server">
			<table height="100%" width="95%">
				<tr>
					<td align="center" style="FONT-WEIGHT: bold; FONT-SIZE: 12pt">权限修改</td>
				</tr>
				<tr>
					<td vAlign="middle" align="center">
						<table cellSpacing="0" cellPadding="0" width="650" align="center" border="1" bordercolor="#00ccff"
							style="WIDTH: 740px">
							<tr>
								<td style="WIDTH: 390px">
									部门：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList id="ddlDept" runat="server" AutoPostBack="True" Width="200"></asp:DropDownList>&nbsp;&nbsp;&nbsp; 
									操作员列表</td>
								<td align="center" style="WIDTH: 195px">网站功能列表</td>
								<td align="center">客户端功能列表</td>
							</tr>
							<tr>
								<td style="WIDTH: 200px" align="center" valign="middle"><asp:radiobuttonlist id="rblOper" runat="server" ToolTip="操作员列表" AutoPostBack="True" ForeColor="Crimson"
										BorderStyle="None"></asp:radiobuttonlist></td>
								<td style="WIDTH: 150px"><asp:checkboxlist id="cblFunctionList" runat="server"></asp:checkboxlist></td>
								<td><asp:checkboxlist id="cblCSFunctionList" runat="server"></asp:checkboxlist></td>
							</tr>
							<tr>
								<td align="center" colSpan="3"><asp:imagebutton id="btnOK" runat="server" ImageUrl="../Images/btnOk.gif"></asp:imagebutton><asp:imagebutton id="btnCancel" runat="server" ImageUrl="../Images/btnCancel.gif"></asp:imagebutton></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
