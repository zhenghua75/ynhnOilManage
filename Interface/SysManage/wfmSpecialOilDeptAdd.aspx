<%@ Page language="c#" Codebehind="wfmSpecialOilDeptAdd.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.SysManage.wfmSpecialOilDeptAdd" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmSpecialOilDeptAdd</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../Scripts/calendar.js"></script>
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table width="400" align="center">
				<tr>
					<td align="center" colSpan="2"><asp:label id="Label1" runat="server">
							<font style="FONT-WEIGHT: bold; FONT-SIZE: 10pt">���ר�������õ�λ</font></asp:label>
						<hr>
					</td>
				</tr>
				<tr>
					<td><asp:label id="Label2" runat="server">��ͬ��ţ�</asp:label></td>
					<td><asp:textbox id="txtContactNo" runat="server" Width="325px" Height="24px"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label3" runat="server">��λ���ƣ�</asp:label></td>
					<td><asp:textbox id="txtDeliveryCompany" runat="server" Width="326px" Height="24px"></asp:textbox></td>
				</tr>
				<tr>
					<td align="center" colSpan="2"><asp:button id="btnOK" runat="server" Text="ȷ��" Width="76px"></asp:button>
						<asp:Button id="btnCancel" runat="server" Text="ȡ��" Width="76px"></asp:Button>
						<asp:Button id="btnReturn" runat="server" Width="76px" Text="����"></asp:Button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
