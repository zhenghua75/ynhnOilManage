<%@ Page language="c#" Codebehind="wfmSpecialOilListMod.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.Report.wfmSpecialOilListMod" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmSpecialOilListMod</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../style.css">
		<script language="javascript" src="../Scripts/calendar.js"></script>
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table width="600" align="center" height="50">
				<tr height="30">
					<td colSpan="4" align="center"><font style="FONT-SIZE: 10pt; FONT-WEIGHT: bold">ר������ϸ�޸�</font>
						<asp:textbox id="txtDeptID" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtDeptName" runat="server" Visible="False"></asp:textbox>
						<hr>
					</td>
				</tr>
				<tr>
					<td><asp:label id="Label1" runat="server">�������ƣ�</asp:label></td>
					<td><asp:dropdownlist id="ddlGoodsName" runat="server" AutoPostBack="True" Width="136px"></asp:dropdownlist></td>
					<td><asp:label id="Label4" runat="server">�����ͺţ�</asp:label></td>
					<td><asp:dropdownlist id="ddlGoodsType" runat="server" Width="128px"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td><asp:label id="Label2" runat="server">���ϵ��֣�</asp:label></td>
					<td><asp:textbox id="txtBillNo" runat="server"></asp:textbox></td>
					<td><asp:label id="Label8" runat="server">�����λ��</asp:label></td>
					<td><asp:dropdownlist id="ddlDeliveryCompany" runat="server" AutoPostBack="True" Width="128px"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td><asp:label id="Label3" runat="server">������λ��</asp:label></td>
					<td><asp:textbox id="txtProvideCompany" runat="server"></asp:textbox></td>
					<td><asp:label id="Label9" runat="server">��ͬ��ţ�</asp:label></td>
					<td><asp:dropdownlist id="ddlContractNo" runat="server" Width="128px"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td><asp:label id="Label5" runat="server">����������</asp:label></td>
					<td><asp:textbox id="txtReceiveCount" runat="server"></asp:textbox></td>
					<td><asp:label id="Label10" runat="server">ʵ��������</asp:label></td>
					<td><asp:textbox id="txtCount" runat="server" AutoPostBack="True"></asp:textbox></td>
				</tr>
				<tr>
					<td style="HEIGHT: 14px"><asp:label id="Label6" runat="server">ר�����ۣ�</asp:label></td>
					<td style="HEIGHT: 14px"><asp:textbox id="txtSpecialUnitPrice" runat="server"></asp:textbox></td>
					<td style="HEIGHT: 14px"><asp:label id="Label11" runat="server">ר����</asp:label></td>
					<td style="HEIGHT: 14px"><asp:textbox id="txtSpecialFee" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label7" runat="server">����ˣ�</asp:label></td>
					<td><asp:textbox id="txtDeliveryMan" runat="server"></asp:textbox></td>
					<td><asp:label id="Label12" runat="server">������ڣ�</asp:label></td>
					<td><asp:textbox id="txtDeliveryDate" onfocus="calendar()" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label13" runat="server">������ʼ���ڣ�</asp:label></td>
					<td><asp:textbox id="txtProvideBeginDate" onfocus="calendar()" runat="server"></asp:textbox></td>
					<td><asp:label id="Label14" runat="server">������ֹ���ڣ�</asp:label></td>
					<td><asp:textbox id="txtProvideEndDate" onfocus="calendar()" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label15" runat="server">����ҵ��Ա��</asp:label></td>
					<td><asp:textbox id="txtProvideMan" runat="server"></asp:textbox></td>
					<td><asp:label id="Label16" runat="server">��Ч�ڣ�</asp:label></td>
					<td><asp:textbox id="txtTimeOfValidity" onfocus="calendar()" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label17" runat="server">ǩ����λ��</asp:label></td>
					<td><asp:textbox id="txtSignerCompany" runat="server"></asp:textbox></td>
					<td><asp:label id="Label18" runat="server">ǩ���ˣ�</asp:label></td>
					<td><asp:textbox id="txtSigner" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td colSpan="4" align="center">
						<hr>
						<asp:button id="btnOK" runat="server" Text="ȷ��" Width="100px"></asp:button><asp:button id="btnCancel" runat="server" Text="ȡ��" Width="100px"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
