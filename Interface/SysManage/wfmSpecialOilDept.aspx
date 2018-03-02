<%@ Page language="c#" Codebehind="wfmSpecialOilDept.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.SysManage.wfmSpecialOilDept" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmSpecialOilDept</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../Scripts/calendar.js"></script>
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table width="400" align="center">
				<tr>
					<td align="center" colSpan="2"><asp:label id="Label1" runat="server">
							<font style="FONT-WEIGHT: bold; FONT-SIZE: 10pt">专供油领用单位管理</font></asp:label>
						<hr>
					</td>
				</tr>
				<tr>
					<td><asp:label id="Label2" runat="server">合同编号：</asp:label></td>
					<td><asp:textbox id="txtContactNo" runat="server" Width="303px"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label3" runat="server">单位名称：</asp:label></td>
					<td><asp:textbox id="txtDeliveryCompany" runat="server" Width="304px"></asp:textbox></td>
				</tr>
				<tr>
					<td align="center" colSpan="2"><asp:button id="btnQuery" runat="server" Text="查询" Width="76px"></asp:button>
						<asp:Button id="btnAdd" runat="server" Text="添加" Width="76px"></asp:Button></td>
				</tr>
			</table>
			<asp:datagrid id="dgCompany" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
				Font-Names="Verdana" AlternatingItemStyle-BackColor="#eeeeee" HeaderStyle-BackColor="SteelBlue"
				Font-Size="X-Small" Font-Name="Verdana" CellPadding="3" BorderWidth="1px" BorderColor="Black"
				PagerStyle-HorizontalAlign="Right" PagerStyle-Mode="NumericPages" PageSize="20">
				<FooterStyle Wrap="False"></FooterStyle>
				<SelectedItemStyle Wrap="False"></SelectedItemStyle>
				<EditItemStyle Wrap="False"></EditItemStyle>
				<AlternatingItemStyle Wrap="False" ForeColor="Black" BackColor="#EEEEEE"></AlternatingItemStyle>
				<ItemStyle Wrap="False" ForeColor="Black" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#000084"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="cnvcID" ReadOnly="True" HeaderText="编号"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="cnvcName" ReadOnly="True" HeaderText="名称"></asp:BoundColumn>
					<asp:BoundColumn DataField="cnvcContractNo" HeaderText="合同编号"></asp:BoundColumn>
					<asp:BoundColumn DataField="cnvcDeliveryCompany" HeaderText="单位名称"></asp:BoundColumn>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="确定" CancelText="取消" EditText="编辑"></asp:EditCommandColumn>
					<asp:ButtonColumn Text="删除" CommandName="Delete" Visible="False"></asp:ButtonColumn>
				</Columns>
				<PagerStyle Font-Size="X-Small" HorizontalAlign="Right" Wrap="False" Mode="NumericPages"></PagerStyle>
			</asp:datagrid></form>
	</body>
</HTML>
