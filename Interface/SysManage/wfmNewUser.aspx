<%@ Page language="c#" Codebehind="wfmNewUser.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.SysManage.wfmNewUser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmNewUser</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table height="100%" width="100%">
				<tr>
					<td vAlign="middle" align="center">
						<table>
							<tr>
								<td style="FONT-WEIGHT: bold; FONT-SIZE: 12pt" align="center" colSpan="2">新建用户</td>
							</tr>
							<tr>
								<td><asp:label id="lblOperID" runat="server">操作员ID：</asp:label></td>
								<td><asp:textbox id="txtOperID" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td><asp:label id="lblOperName" runat="server">操作员姓名：</asp:label></td>
								<td><asp:textbox id="txtOperName" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td align="center" colSpan="2"><asp:imagebutton id="btnOK" runat="server" ImageUrl="../Images/btnOk.gif"></asp:imagebutton><asp:imagebutton id="btnCancel" runat="server" ImageUrl="../Images/btnCancel.gif"></asp:imagebutton></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
