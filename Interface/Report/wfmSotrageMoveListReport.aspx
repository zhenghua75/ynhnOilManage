<%@ Register TagPrefix="uc1" TagName="ucPageView" Src="ucPageView.ascx" %>
<%@ Page language="c#" Codebehind="wfmSotrageMoveListReport.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.Report.wfmSotrageMoveListReport" %>
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
					<td align="center" colSpan="2"><font style="FONT-SIZE: 10pt; FONT-WEIGHT: bold">储备库调拨明细报表</font>
						<hr style="WIDTH: 689px; HEIGHT: 2px" SIZE="2">
					</td>
				</tr>
				<tr>
					<td><asp:label id="Label1" runat="server" Width="97px">供油单位：</asp:label></td>
					<td>
						<asp:DropDownList id="ddlProvideCompany" runat="server" Width="184px" Height="22px"></asp:DropDownList>
						<asp:Label style="Z-INDEX: 0" id="Label4" runat="server" Width="77px" Height="16px">收油单位：</asp:Label>
						<asp:DropDownList style="Z-INDEX: 0" id="ddlDeliveryCompany" runat="server" Width="200px" Height="22px"></asp:DropDownList></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td><asp:label id="Label2" runat="server">开始日期：</asp:label></td>
					<td><FONT face="宋体"><asp:textbox id="txtBeginDate" onfocus="calendar()" runat="server" Width="187px" Height="24px"></asp:textbox>
							<asp:label style="Z-INDEX: 0" id="Label3" runat="server" Width="79px">结束日期：</asp:label>
							<asp:textbox style="Z-INDEX: 0" id="txtEndDate" onfocus="calendar()" runat="server" Width="187px"
								Height="24px"></asp:textbox></FONT></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td align="center" colSpan="2">
						<hr style="WIDTH: 704px; HEIGHT: 2px" SIZE="2">
						<asp:button id="btnQuery" runat="server" Text="查询" Width="100px"></asp:button>
						<asp:button id="btnCancel" runat="server" Text="取消" Width="100px"></asp:button>
						<asp:button id="btnExcel" runat="server" Text="导出EXCEL" Width="100px"></asp:button></td>
				</tr>
			</table>
			<uc1:ucPageView id="UcPageView1" runat="server"></uc1:ucPageView></form>
	</body>
</HTML>
