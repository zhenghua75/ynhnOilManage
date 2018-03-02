<%@ Register TagPrefix="uc1" TagName="ucPageView" Src="ucPageView.ascx" %>
<%@ Page language="c#" Codebehind="wfmOilValidateListReport.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.Report.wfmOilValidateListReport" %>
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
			<table height="50" width="600" align="center">
				<tr height="30">
					<td align="center" colSpan="4"><font style="FONT-SIZE: 10pt; FONT-WEIGHT: bold">油料验收明细报表</font>
						<hr>
					</td>
				</tr>
				<tr>
					<td><asp:label id="Label1" runat="server">供油单位：</asp:label></td>
					<td>
						<asp:DropDownList id="ddlProvideCompany" runat="server" Width="128px"></asp:DropDownList></td>
					<td>
						<asp:Label id="Label4" runat="server">收油单位：</asp:Label></td>
					<td>
						<asp:DropDownList id="ddlDeliveryCompany" runat="server" Width="128px"></asp:DropDownList></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label7" runat="server">物料名称：</asp:Label></td>
					<td>
						<asp:DropDownList id="ddlGoodsName" runat="server" AutoPostBack="True" Width="128px"></asp:DropDownList></td>
					<td>
						<asp:Label id="Label8" runat="server">物料规格：</asp:Label></td>
					<td>
						<asp:DropDownList id="ddlGoodsType" runat="server" AutoPostBack="True" Width="128px"></asp:DropDownList></td>
				</tr>
				<tr>
					<td><asp:label id="Label2" runat="server">发油开始日期：</asp:label></td>
					<td><FONT face="宋体"><asp:textbox id="txtProvideBeginDate" onfocus="calendar()" runat="server"></asp:textbox></FONT></td>
					<td><asp:label id="Label5" runat="server">发油结束日期：</asp:label></td>
					<td><FONT face="宋体"><asp:textbox id="txtProvideEndDate" onfocus="calendar()" runat="server"></asp:textbox></FONT></td>
				</tr>
				<tr>
					<td><asp:label id="Label3" runat="server">收油开始日期：</asp:label></td>
					<td><asp:textbox id="txtDeliveryBeginDate" onfocus="calendar()" runat="server"></asp:textbox></td>
					<td><asp:label id="Label6" runat="server">收油结束日期：</asp:label></td>
					<td><asp:textbox id="txtDeliveryEndDate" onfocus="calendar()" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td>
						<asp:label style="Z-INDEX: 0" id="Label9" runat="server">收油核对单号：</asp:label></td>
					<td>
						<asp:TextBox id="txtBillNo" runat="server"></asp:TextBox></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td align="center" colSpan="4">
						<hr>
						<asp:button id="btnQuery" runat="server" Text="查询" Width="100px"></asp:button>
						<asp:button id="btnCancel" runat="server" Text="取消" Width="100px"></asp:button>
						<asp:button id="btnExcel" runat="server" Text="导出EXCEL" Width="100px"></asp:button></td>
				</tr>
			</table>
			<uc1:ucPageView id="UcPageView1" runat="server"></uc1:ucPageView></form>
	</body>
</HTML>
