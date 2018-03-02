<%@ Page language="c#" Codebehind="wfmMemberList.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.Report.wfmMemberList" %>
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
					<td align="center" colSpan="2"><font style="FONT-SIZE: 10pt; FONT-WEIGHT: bold">��Ա�嵥</font>&nbsp;
						<hr style="WIDTH: 703px; HEIGHT: 2px" SIZE="2">
					</td>
				</tr>
				<tr>
					<td><asp:label id="Label1" runat="server">��λ���ƣ�</asp:label></td>
					<td>
						<asp:TextBox id="txtCompanyName" runat="server"></asp:TextBox>
						<asp:Label style="Z-INDEX: 0" id="Label5" runat="server" Width="76px">ָ������վ��</asp:Label>
						<asp:DropDownList style="Z-INDEX: 0" id="ddlDept" runat="server" Width="152px"></asp:DropDownList></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label4" runat="server">���ƺţ�</asp:Label></td>
					<td>
						<asp:TextBox id="txtLicenseTag" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label7" runat="server">��Ա���ţ�</asp:Label></td>
					<td>
						<asp:TextBox id="txtCardID" runat="server"></asp:TextBox>
						<asp:Label style="Z-INDEX: 0" id="Label6" runat="server" Width="80px">��Ա״̬��</asp:Label>
						<asp:DropDownList style="Z-INDEX: 0" id="ddlState" runat="server" Width="152px"></asp:DropDownList></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td><asp:label id="Label2" runat="server">��ʼ���ڣ�</asp:label></td>
					<td><FONT face="����"><asp:textbox id="txtBeginDate" onfocus="calendar()" runat="server"></asp:textbox>
							<asp:label style="Z-INDEX: 0" id="Label3" runat="server" Width="80px">�������ڣ�</asp:label>
							<asp:textbox style="Z-INDEX: 0" id="txtEndDate" onfocus="calendar()" runat="server" Width="152px"></asp:textbox></FONT></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
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
