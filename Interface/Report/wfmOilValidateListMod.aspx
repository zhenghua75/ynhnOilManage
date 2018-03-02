<%@ Page language="c#" Codebehind="wfmOilValidateListMod.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.Report.wfmOilValidateListMod" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmOilValidateListMod</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../style.css">
		<script language="javascript" src="../Scripts/calendar.js"></script>
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table width="800" align="center" height="50">
				<tr height="30">
					<td colSpan="6" align="center"><font style="FONT-SIZE: 10pt; FONT-WEIGHT: bold">���յ���ϸ�޸�</font>
						<asp:textbox id="txtDeptID" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtDeptName" runat="server" Visible="False"></asp:textbox>
						<hr>
					</td>
				</tr>
				<tr>
					<td><asp:label id="Label1" runat="server">�������ƣ�</asp:label></td>
					<td><asp:dropdownlist id="ddlGoodsName" runat="server" Width="136px"></asp:dropdownlist></td>
					<td><asp:label id="Label4" runat="server">�����ͺţ�</asp:label></td>
					<td><asp:dropdownlist id="ddlGoodsType" runat="server" Width="128px"></asp:dropdownlist></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td><asp:label id="Label2" runat="server">���ͺ˶Ե��ţ�</asp:label></td>
					<td><asp:textbox id="txtBillNo" runat="server"></asp:textbox></td>
					<td><asp:label id="Label8" runat="server">���ⵥ�ţ�</asp:label></td>
					<td><asp:textbox id="txtOutNo" runat="server"></asp:textbox></td>
					<td><asp:label id="Label3" runat="server">��ⷽʽ��</asp:label></td>
					<td><asp:dropdownlist id="ddlInType" runat="server" Width="96px">
							<asp:ListItem Value="�������">�������</asp:ListItem>
							<asp:ListItem Value="����">����</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<tr>
					<td><asp:label id="Label5" runat="server">���͵�λ��</asp:label></td>
					<td><asp:dropdownlist id="ddlProvideCompany" runat="server"></asp:dropdownlist>
						<asp:TextBox id="txtProvideCompany" runat="server"></asp:TextBox></td>
					<td><asp:label id="Label12" runat="server">���͵�λ��</asp:label></td>
					<td><asp:textbox id="txtDeliveryComp" runat="server"></asp:textbox></td>
					<td><asp:label id="Label18" runat="server">��������</asp:label></td>
					<td><asp:textbox id="txtProvideDate" onfocus="calendar()" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label6" runat="server">���䳵�ţ�</asp:label></td>
					<td><asp:textbox id="txtTrLicenseTags" runat="server"></asp:textbox></td>
					<td><asp:label id="Label13" runat="server">�����ˣ�</asp:label></td>
					<td><asp:textbox id="txtTransportMan" runat="server"></asp:textbox></td>
					<td><asp:label id="Label19" runat="server">�������ڣ�</asp:label></td>
					<td><asp:textbox id="txtDeliveryDate" onfocus="calendar()" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label7" runat="server">ԭ������</asp:label></td>
					<td><asp:textbox id="txtOriginalCount" runat="server" AutoPostBack="True"></asp:textbox></td>
					<td><asp:label id="Label14" runat="server">��������</asp:label></td>
					<td><asp:textbox id="txtValidateCount" runat="server" AutoPostBack="True"></asp:textbox></td>
					<td><asp:label id="Label20" runat="server">���乫������</asp:label></td>
					<td><asp:textbox id="txtDistance" runat="server" AutoPostBack="True"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label9" runat="server">������Ķ��</asp:label></td>
					<td><asp:textbox id="txtTransportLose" runat="server" AutoPostBack="True"></asp:textbox>%</td>
					<td><asp:label id="Label15" runat="server">ʵ����ģ�</asp:label></td>
					<td><asp:textbox id="txtLose" runat="server" AutoPostBack="True"></asp:textbox></td>
					<td rowSpan="2" colSpan="2"><asp:label id="Label17" runat="server" Width="197px" Height="64px" Font-Bold="True" ForeColor="Red">���ʵ�����С�ڶ�����������ģ�������������������0������ϸ�˶Ե��ݣ������ͼ���ƫ��0.3%��</asp:label></td>
				</tr>
				<tr>
					<td><asp:label id="Label10" runat="server">������������ģ�</asp:label></td>
					<td><asp:textbox id="txtQuotaLose" runat="server" AutoPostBack="True"></asp:textbox></td>
					<td><asp:label id="Label16" runat="server">������������ģ�</asp:label></td>
					<td><asp:textbox id="txtQuterLose" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label11" runat="server">���͵ص㣺</asp:label></td>
					<td colSpan="5"><asp:textbox id="txtProvideAddress" runat="server" Width="640px" Height="24px"></asp:textbox></td>
				</tr>
				<tr>
					<td colSpan="6" align="center">
						<hr>
						<asp:button id="btnOK" runat="server" Width="100px" Text="ȷ��"></asp:button><asp:button id="btnCancel" runat="server" Width="100px" Text="ȡ��"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
