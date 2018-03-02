<%@ Register TagPrefix="uc1" TagName="ucPageView" Src="ucPageView.ascx" %>
<%@ Page language="c#" Codebehind="wfmStorageOilListReport.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.Report.wfmStorageOilListReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmRetailOilListReport</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../Scripts/calendar.js"></script>
	</HEAD>
	<body bgColor="#0099cc" MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table height="50" width="400" align="center">
				<tr height="30">
					<td align="center" colSpan="2"><font style="FONT-SIZE: 10pt; FONT-WEIGHT: bold">库存盘点明细表</font>
						<hr>
					</td>
				</tr>
				<tr>
					<td><asp:label id="Label1" runat="server">部门：</asp:label></td>
					<td><asp:dropdownlist id="ddlDept" runat="server" Width="133px"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td><asp:label id="Label2" runat="server">开始日期：</asp:label></td>
					<td><FONT face="宋体"><asp:textbox id="txtBeginDate" onfocus="calendar()" runat="server"></asp:textbox></FONT></td>
				</tr>
				<tr>
					<td><asp:label id="Label3" runat="server">结束日期：</asp:label></td>
					<td><asp:textbox id="txtEndDate" onfocus="calendar()" runat="server"></asp:textbox></td>
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
