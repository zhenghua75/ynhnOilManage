<%@ Page language="c#" Codebehind="wfmRegister.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.SysManage.wfmRegister" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmRegister</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%">
				<tr>
					<td align="center">
						<asp:Label id="Label1" runat="server" Font-Bold="True">×¢²á</asp:Label></td>
				</tr>
				<tr>
					<td>
						<asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False" AllowPaging="True" Font-Names="Verdana"
							Width="100%" AlternatingItemStyle-BackColor="#eeeeee" HeaderStyle-BackColor="SteelBlue" Font-Size="X-Small"
							Font-Name="Verdana" CellPadding="3" BorderWidth="1px" BorderColor="Black" PagerStyle-HorizontalAlign="Right"
							PagerStyle-Mode="NumericPages">
							<SelectedItemStyle Wrap="False"></SelectedItemStyle>
							<EditItemStyle Wrap="False"></EditItemStyle>
							<AlternatingItemStyle Wrap="False" ForeColor="Black" BackColor="#EEEEEE"></AlternatingItemStyle>
							<ItemStyle Wrap="False" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="Small" Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#000084"></HeaderStyle>
							<FooterStyle Wrap="False"></FooterStyle>
							<PagerStyle Visible="true" Font-Size="X-Small" HorizontalAlign="Right" Wrap="False" Mode="NumericPages"></PagerStyle>
							<Columns>
								<asp:BoundColumn DataField="cnvcDeptName" ReadOnly="True" HeaderText="²¿ÃÅ"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcOperName" ReadOnly="True" HeaderText="²Ù×÷Ô±"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcHddSerialNo" ReadOnly="True" HeaderText="×¢²áÉêÇëÂë"></asp:BoundColumn>
								<asp:BoundColumn DataField="cnvcRegister" HeaderText="×¢²áÂë"></asp:BoundColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="¸üÐÂ" CancelText="È¡Ïû" EditText="ÊäÈë×¢²áÂë"></asp:EditCommandColumn>
							</Columns>
						</asp:DataGrid>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
