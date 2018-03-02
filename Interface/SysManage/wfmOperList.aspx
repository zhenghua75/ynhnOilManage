<%@ Register TagPrefix="uc1" TagName="ucPageView" Src="../Report/ucPageView.ascx" %>
<%@ Page language="c#" Codebehind="wfmOperList.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.SysManage.wfmOperList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmOperList</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../Scripts/calendar.js"></script>
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table height="50" width="400" align="center">
				<tr height="30">
					<td align="center" colSpan="2"><font style="FONT-SIZE: 10pt; FONT-WEIGHT: bold">操作员查询</font>
						<hr>
					</td>
				</tr>
				<tr>
					<td><asp:label id="Label1" runat="server">部门：</asp:label></td>
					<td><asp:dropdownlist id="ddlDept" runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td><asp:label id="Label2" runat="server">操作员姓名：</asp:label></td>
					<td><FONT face="宋体"><asp:textbox id="txtOperName" onfocus="calendar()" runat="server"></asp:textbox></FONT></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label3" runat="server">是否有效：</asp:Label></td>
					<td>
						<asp:DropDownList id="ddlValidate" runat="server">
							<asp:ListItem Value="所有" Selected="True">所有</asp:ListItem>
							<asp:ListItem Value="1">有效</asp:ListItem>
							<asp:ListItem Value="0">无效</asp:ListItem>
						</asp:DropDownList></td>
				</tr>
				<tr>
					<td align="center" colSpan="2">
						<hr>
						<asp:button id="btnQuery" runat="server" Text="查询" Width="100px"></asp:button>
						<asp:button id="btnCancel" runat="server" Text="取消" Width="100px"></asp:button>
						<asp:button id="btnExcel" runat="server" Text="导出EXCEL" Width="100px"></asp:button></td>
				</tr>
			</table>
			<uc1:ucPageView id="UcPageView1" runat="server"></uc1:ucPageView></form>
	</body>
</HTML>
