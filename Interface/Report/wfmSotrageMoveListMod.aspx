<%@ Page language="c#" Codebehind="wfmSotrageMoveListMod.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.Report.wfmSotrageMoveListMod" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmSotrageMoveListMod</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../Scripts/calendar.js"></script>
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table width="700" align="center" height="50">
				<tr height="30">
					<td colSpan="6" align="center"><font style="FONT-SIZE: 10pt; FONT-WEIGHT: bold">��������ϸ�޸�</font>
						<asp:textbox id="txtDeptID" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtDeptName" runat="server" Visible="False"></asp:textbox>
						<hr>
					</td>
				</tr>
				<tr>
					<td><asp:label id="Label1" runat="server">�������ƣ�</asp:label></td>
					<td><asp:dropdownlist id="ddlGoodsName" runat="server" Width="136px"></asp:dropdownlist></td>
					<td><asp:label id="Label4" runat="server">�����ͺţ�</asp:label></td>
					<td><asp:dropdownlist id="ddlGoodsType" runat="server" Width="133px"></asp:dropdownlist></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td><asp:label id="Label2" runat="server">���ⵥ�ţ�</asp:label></td>
					<td><asp:textbox id="txtBillNo" runat="server"></asp:textbox></td>
					<td><asp:label id="Label8" runat="server">�������ţ�</asp:label></td>
					<td><asp:textbox id="txtMoveNo" runat="server"></asp:textbox></td>
					<td><asp:label id="Label3" runat="server">���ϵ��ţ�</asp:label></td>
					<td>
						<asp:TextBox id="txtBillOfMaterialsNo" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td><asp:label id="Label5" runat="server">���ϲֿ⣺</asp:label></td>
					<td>
						<asp:TextBox id="txtProvideStroage" runat="server"></asp:TextBox></td>
					<td><asp:label id="Label12" runat="server">�����λ��</asp:label></td>
					<td colspan="3">
						<asp:DropDownList id="ddlDeliveryCompany" runat="server" Width="136px"></asp:DropDownList></td>
				</tr>
				<tr>
					<td><asp:label id="Label6" runat="server">���˵�λ��</asp:label></td>
					<td><asp:textbox id="txtTransportCompany" runat="server"></asp:textbox></td>
					<td><asp:label id="Label13" runat="server">���˳��ţ�</asp:label></td>
					<td><asp:textbox id="txtTransportLiscenseTags" runat="server"></asp:textbox></td>
					<td><asp:label id="Label19" runat="server">�������ڣ�</asp:label></td>
					<td><asp:textbox id="txtOutStorageDate" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label7" runat="server">Ӧ������</asp:label></td>
					<td><asp:textbox id="txtReceivableCount" runat="server"></asp:textbox></td>
					<td><asp:label id="Label14" runat="server">ʵ������</asp:label></td>
					<td><asp:textbox id="txtCount" runat="server"></asp:textbox></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td><asp:label id="Label9" runat="server">�ֿ����ܣ�</asp:label></td>
					<td><asp:textbox id="txtStorageIncharge" runat="server"></asp:textbox></td>
					<td><asp:label id="Label15" runat="server">����ˣ�</asp:label></td>
					<td><asp:textbox id="txtDeliveryMan" runat="server"></asp:textbox></td>
					<td>
						<asp:Label id="Label17" runat="server">�Ƶ���</asp:Label></td>
					<td>
						<asp:TextBox id="txtLister" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td><asp:label id="Label11" runat="server">��ע��</asp:label></td>
					<td colspan="5">
						<asp:TextBox id="txtComments" runat="server" Height="104px" Width="555px" TextMode="MultiLine"></asp:TextBox></td>
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
