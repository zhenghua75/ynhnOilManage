<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ucPageView.ascx.cs" Inherits="ynhnOilManage.Interface.Report.ucPageView" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR vAlign="top">
		<TD colSpan="2"><ASP:DATAGRID id="MyDataGrid" AllowPaging="True" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right"
				OnPageIndexChanged="MyDataGrid_Page" BorderColor="Black" BorderWidth="1px" CellPadding="3" Font-Name="Verdana"
				Font-Size="X-Small" HeaderStyle-BackColor="SteelBlue" AlternatingItemStyle-BackColor="#eeeeee" runat="server"
				Width="100%" Font-Names="Verdana" PageSize="20">
				<FooterStyle Wrap="False"></FooterStyle>
				<SelectedItemStyle Wrap="False"></SelectedItemStyle>
				<EditItemStyle Wrap="False"></EditItemStyle>
				<AlternatingItemStyle Wrap="False" ForeColor="Black" BackColor="#EEEEEE"></AlternatingItemStyle>
				<ItemStyle Wrap="False" ForeColor="Black" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#000084"></HeaderStyle>
				<PagerStyle Visible="False" Font-Size="X-Small" HorizontalAlign="Right" Wrap="False" Mode="NumericPages"></PagerStyle>
			</ASP:DATAGRID></TD>
	</TR>
	<TR id="FootBar" runat="server" name="FootBar">
		<TD><asp:label id="lbPageLabel" runat="server"></asp:label></TD>
		<TD align="right"><asp:linkbutton id="btnFirst" onclick="PagerButtonClick" Font-Name="verdana" runat="server" Text="首页"
				CommandArgument="0" ForeColor="navy" Font-size="8pt"></asp:linkbutton>|
			<asp:linkbutton id="btnPrev" onclick="PagerButtonClick" Font-Name="verdana" runat="server" Text="上页"
				CommandArgument="prev" ForeColor="navy" Font-size="8pt"></asp:linkbutton>|
			<asp:linkbutton id="btnNext" onclick="PagerButtonClick" Font-Name="verdana" runat="server" Text="下页"
				CommandArgument="next" ForeColor="navy" Font-size="8pt"></asp:linkbutton>|
			<asp:linkbutton id="btnLast" onclick="PagerButtonClick" Font-Name="verdana" runat="server" Text="尾页"
				CommandArgument="last" ForeColor="navy" Font-size="8pt"></asp:linkbutton>| 
			跳到第 <INPUT id=page_number size=1 
      value="<%=MyDataGrid.CurrentPageIndex+1%>" name=page_number 
      >页
			<asp:linkbutton id="btnGo" onmouseover="javascript:if((!isInt(page_number.value))||page_number.value<=0){alert('跳转页码必须为正整数！');page_number.focus();return false;};"
				onclick="PagerButtonClick" Font-Name="verdana" runat="server" Text="GO" CommandArgument="jump"
				ForeColor="navy" Font-size="8pt">GO!</asp:linkbutton></TD>
	</TR>
</TABLE>
