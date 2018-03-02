<%@ Page language="c#" Codebehind="wfmCompanyPrepay.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.Prepay.wfmCompanyPrepay" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wfmCompanyPrepay</title>
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
							<font style="FONT-WEIGHT: bold; FONT-SIZE: 10pt">单位预存及充值</font></asp:label>
						<hr>
					</td>
				</tr>
				<tr>
					<td><asp:label id="Label2" runat="server">单位名称：</asp:label></td>
					<td><asp:textbox id="txtCompanyName" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label3" runat="server">指定加油站：</asp:label></td>
					<td><asp:dropdownlist id="ddlDept" runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td><asp:label id="Label6" runat="server">操作员</asp:label></td>
					<td><asp:textbox id="txtOperName" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label4" runat="server">开始日期：</asp:label></td>
					<td><FONT face="宋体"><asp:textbox id="txtBeginDate" onfocus="calendar()" runat="server"></asp:textbox></FONT></td>
				</tr>
				<tr>
					<td><asp:label id="Label5" runat="server">结束日期：</asp:label></td>
					<td><asp:textbox id="txtEndDate" onfocus="calendar()" runat="server"></asp:textbox>
						<asp:TextBox id="txtflag" runat="server" Visible="False"></asp:TextBox></td>
				</tr>
				<tr>
					<td align="center" colSpan="2"><asp:button id="btnCompanyQuery" runat="server" Text="单位查询"></asp:button><asp:button id="btnFillQuery" runat="server" Text="充值查询"></asp:button><asp:button id="btnAddCompany" runat="server" Text="添加单位"></asp:button><asp:button id="btnExcel" runat="server" Text="导出EXCEL"></asp:button>
						<hr>
					</td>
				</tr>
			</table>
			<asp:datagrid id="dgCompany" runat="server" AutoGenerateColumns="False" AllowPaging="True" Font-Names="Verdana"
				Width="100%" AlternatingItemStyle-BackColor="#eeeeee" HeaderStyle-BackColor="SteelBlue" Font-Size="X-Small"
				Font-Name="Verdana" CellPadding="3" BorderWidth="1px" BorderColor="Black" PagerStyle-HorizontalAlign="Right"
				PagerStyle-Mode="NumericPages">
				<FooterStyle Wrap="False"></FooterStyle>
				<SelectedItemStyle Wrap="False"></SelectedItemStyle>
				<EditItemStyle Wrap="False"></EditItemStyle>
				<AlternatingItemStyle Wrap="False" ForeColor="Black" BackColor="#EEEEEE"></AlternatingItemStyle>
				<ItemStyle Wrap="False" ForeColor="Black" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#000084"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="cnvcCompanyID" ReadOnly="True" HeaderText="单位ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="cnvcCompanyName" ReadOnly="True" HeaderText="单位名称"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="cnvcAcctID" ReadOnly="True" HeaderText="帐号"></asp:BoundColumn>
					<asp:BoundColumn DataField="cnnFillFeeSum" ReadOnly="True" HeaderText="充值合计"></asp:BoundColumn>
					<asp:BoundColumn DataField="cnnPrepayFee" ReadOnly="True" HeaderText="余额"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="cnvcDeptID" ReadOnly="True" HeaderText="部门ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="cnvcDeptName" ReadOnly="True" HeaderText="指定加油站"></asp:BoundColumn>
					<asp:BoundColumn DataField="cnnFillFee" HeaderText="充值金额"></asp:BoundColumn>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="确定" CancelText="取消" EditText="充值"></asp:EditCommandColumn>
					<asp:HyperLinkColumn Text="编辑" Target="_self" DataNavigateUrlField="cnvcCompanyID" DataNavigateUrlFormatString="wfmAddCompany.aspx?FLAG=MOD&COMPANYID={0}&FuncName=修改单位"
						HeaderText="修改单位"></asp:HyperLinkColumn>
				</Columns>
				<PagerStyle Font-Size="X-Small" HorizontalAlign="Right" Wrap="False" Mode="NumericPages"></PagerStyle>
			</asp:datagrid><asp:datagrid id="dgFillFee" runat="server" AutoGenerateColumns="False" AllowPaging="True" Font-Names="Verdana"
				Width="100%" AlternatingItemStyle-BackColor="#eeeeee" HeaderStyle-BackColor="SteelBlue" Font-Size="X-Small"
				Font-Name="Verdana" CellPadding="3" BorderWidth="1px" BorderColor="Black" PagerStyle-HorizontalAlign="Right"
				PagerStyle-Mode="NumericPages">
				<FooterStyle Wrap="False"></FooterStyle>
				<SelectedItemStyle Wrap="False"></SelectedItemStyle>
				<EditItemStyle Wrap="False"></EditItemStyle>
				<AlternatingItemStyle Wrap="False" ForeColor="Black" BackColor="#EEEEEE"></AlternatingItemStyle>
				<ItemStyle Wrap="False" ForeColor="Black" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" Wrap="False" ForeColor="White" BackColor="#000084"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="cnnSerial" HeaderText="序列号"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="cnvcCompanyID" HeaderText="单位ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="cnvcCompanyName" HeaderText="单位名称"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="cnvcAcctID" HeaderText="帐号"></asp:BoundColumn>
					<asp:BoundColumn DataField="cnnFillFee" HeaderText="充值金额"></asp:BoundColumn>
					<asp:BoundColumn DataField="cnvcOperName" HeaderText="操作员"></asp:BoundColumn>
					<asp:BoundColumn DataField="cndOperDate" HeaderText="操作时间"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="cnvcDeptID" HeaderText="部门ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="cnvcDeptName" HeaderText="指定加油站"></asp:BoundColumn>
				</Columns>
				<PagerStyle Visible="true" Font-Size="X-Small" HorizontalAlign="Right" Wrap="False" Mode="NumericPages"></PagerStyle>
			</asp:datagrid></form>
	</body>
</HTML>
