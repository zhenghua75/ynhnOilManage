<%@ Page language="c#" Codebehind="wfmAddCompany.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.Prepay.wfmAddCompany" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmAddCompany</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../Scripts/calendar.js"></script>
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table align="center">
				<tr>
					<td colspan="2" align="center">
						<asp:Label id="Label1" runat="server">
							<font style="FONT-WEIGHT: bold; FONT-SIZE: 10pt">��ӵ�λ</font></asp:Label>
						<hr>
						<asp:TextBox id="txtCompanyID" runat="server" Visible="False"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label2" runat="server">��λ���ƣ�</asp:Label></td>
					<td>
						<asp:TextBox id="txtCompanyName" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label3" runat="server">ָ������վ��</asp:Label></td>
					<td>
						<asp:DropDownList id="ddlDept" runat="server"></asp:DropDownList></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label4" runat="server">Ԥ���</asp:Label></td>
					<td>
						<asp:TextBox id="txtPrepayFee" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td></td>
					<td>
						<asp:CheckBox id="chkValidate" runat="server" Text="�Ƿ���Ч" Checked="True"></asp:CheckBox>
					</td>
				</tr>
				<tr>
					<td colspan="2" align="center">
						<asp:Button id="btnOK" runat="server" Text="ȷ��"></asp:Button>
						<asp:Button id="btnCancel" runat="server" Text="ȡ��"></asp:Button>
						<asp:Button id="btnReturn" runat="server" Text="����"></asp:Button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
