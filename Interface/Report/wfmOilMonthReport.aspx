<%@ Register TagPrefix="uc1" TagName="ucPageView" Src="ucPageView.ascx" %>
<%@ Page language="c#" Codebehind="wfmOilMonthReport.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.Report.wfmOilMonthReport" %>
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
			<table height="170" width="481" align="center" style="WIDTH: 481px; HEIGHT: 170px">
				<tr height="30">
					<td align="center" colSpan="2"><font style="FONT-SIZE: 10pt; FONT-WEIGHT: bold">�����ա�֧�����±���</font>
						<hr>
					</td>
				</tr>
				<tr>
					<td style="WIDTH: 69px; HEIGHT: 24px"><asp:label id="Label1" runat="server">���λ��</asp:label></td>
					<td style="HEIGHT: 24px"><asp:dropdownlist id="ddlDept" runat="server" Width="218px" Height="22px"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td style="WIDTH: 69px"><asp:label id="Label2" runat="server">����ڣ�</asp:label></td>
					<td><FONT face="����" style="Z-INDEX: 0"><asp:textbox id="txtBeginDate" onfocus="calendar()" runat="server" Width="216px"></asp:textbox><FONT face="����"></FONT></FONT></td>
				</tr>
				<tr>
					<td align="center" colSpan="2">
						<hr>
						<asp:button id="btnQuery" runat="server" Text="��ѯ" Width="100px"></asp:button>
						<asp:button id="btnCancel" runat="server" Text="ȡ��" Width="100px"></asp:button>
						<asp:button id="btnExcel" runat="server" Text="����EXCEL" Width="100px"></asp:button></td>
				</tr>
			</table>
			<uc1:ucPageView id="UcPageView1" runat="server"></uc1:ucPageView></form>
	</body>
</HTML>
