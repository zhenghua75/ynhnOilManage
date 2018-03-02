<%@ Page language="c#" Codebehind="wfmRetailOilListReport.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.Report.wfmRetailOilListReport" %>
<%@ Register TagPrefix="uc1" TagName="ucPageView" Src="ucPageView.ascx" %>
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
					<td align="center" colSpan="2"><font style="FONT-WEIGHT: bold; FONT-SIZE: 10pt">零售油供应明细表</font>
						<hr style="WIDTH: 479px; HEIGHT: 2px" SIZE="2">
					</td>
				</tr>
				<tr>
					<td><asp:label id="Label1" runat="server">部门：</asp:label></td>
					<td><asp:dropdownlist id="ddlDept" runat="server" Width="136px"></asp:dropdownlist>
						<asp:Label id="Label4" runat="server">领料单位：</asp:Label>
						<asp:TextBox id="txtCompanyName" runat="server" Width="198px"></asp:TextBox></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label5" runat="server">会员卡号：</asp:Label></td>
					<td>
						<asp:TextBox id="txtCardID" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td><asp:label id="Label2" runat="server">开始日期：</asp:label></td>
					<td><FONT face="宋体"><asp:textbox id="txtBeginDate" onfocus="calendar()" runat="server" Width="136px" Height="24px"></asp:textbox>
							<asp:label id="Label3" runat="server" Width="63px">结束日期：</asp:label>
							<asp:textbox id="txtEndDate" onfocus="calendar()" runat="server" Width="136px"></asp:textbox></FONT></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td align="center" colSpan="2">
						<hr>
						<asp:button id="btnQuery" runat="server" Text="查询" Width="100px"></asp:button>
						<asp:button id="btnCancel" runat="server" Text="取消" Width="100px"></asp:button>
						<asp:button id="btnExcel" runat="server" Text="导出EXCEL" Width="100px"></asp:button>
						<asp:button id="Button1" runat="server" Width="100px" Text="重算"></asp:button></td>
				</tr>
			</table>
			<uc1:ucPageView id="UcPageView1" runat="server"></uc1:ucPageView></form>
	</body>
</HTML>
