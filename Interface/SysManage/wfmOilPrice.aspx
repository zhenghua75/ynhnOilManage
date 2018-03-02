<%@ Page language="c#" Codebehind="wfmOilPrice.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.SysManage.wfmOilPrice" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmOilPrice</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../Scripts/calendar.js"></script>
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table align="center" width="450">
				<tr height="30">
					<td align="center" colspan="3"><font style="FONT-WEIGHT: bold; FONT-SIZE: 10pt">�ͼ��޸�</font></td>
				</tr>
				<tr>
					<td width="150">
						<asp:Label id="Label1" runat="server">���ţ�</asp:Label></td>
					<td width="150">
						<asp:DropDownList id="ddlDept" runat="server" AutoPostBack="True"></asp:DropDownList></td>
					<td width="150" style="FONT-WEIGHT: bold">�����ͼ�</td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label2" runat="server">�������ƣ�</asp:Label></td>
					<td>
						<asp:DropDownList id="ddlGoodsName" runat="server" AutoPostBack="True"></asp:DropDownList></td>
					<td>
						<asp:TextBox id="txtGoodsName1" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label3" runat="server">���Ϲ��</asp:Label></td>
					<td>
						<asp:DropDownList id="ddlGoodsType" runat="server" AutoPostBack="True"></asp:DropDownList></td>
					<td>
						<asp:TextBox id="txtGoodsType1" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label4" runat="server">��λ��</asp:Label></td>
					<td>
						<asp:DropDownList id="ddlUnit" runat="server">
							<asp:ListItem Value="KG">KG</asp:ListItem>
						</asp:DropDownList></td>
					<td>
						<asp:TextBox id="txtUnit1" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label5" runat="server">�۸�ʱ�䣺</asp:Label></td>
					<td>
						<asp:TextBox id="txtPriceDate" runat="server" onfocus="calendar()"></asp:TextBox></td>
					<td>
						<asp:TextBox id="txtPriceDate1" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label6" runat="server">���ۣ�</asp:Label></td>
					<td>
						<asp:TextBox id="txtOilPrice" runat="server"></asp:TextBox></td>
					<td>
						<asp:TextBox id="txtOilPrice1" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="3" align="center">
						<asp:Button id="btnAdd" runat="server" Text="���" Width="80px"></asp:Button>
						<asp:Button id="btnCancel" runat="server" Text="ȡ��" Width="80px"></asp:Button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
