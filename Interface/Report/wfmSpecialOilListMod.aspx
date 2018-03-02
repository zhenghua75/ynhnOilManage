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
					<td colSpan="4" align="center"><font style="FONT-SIZE: 10pt; FONT-WEIGHT: bold">专供油明细修改</font>
						<asp:textbox id="txtDeptID" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtDeptName" runat="server" Visible="False"></asp:textbox>
						<hr>
					</td>
				</tr>
				<tr>
					<td><asp:label id="Label1" runat="server">物料名称：</asp:label></td>
					<td><asp:dropdownlist id="ddlGoodsName" runat="server" AutoPostBack="True" Width="136px"></asp:dropdownlist></td>
					<td><asp:label id="Label4" runat="server">物料型号：</asp:label></td>
					<td><asp:dropdownlist id="ddlGoodsType" runat="server" Width="128px"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td><asp:label id="Label2" runat="server">领料单字：</asp:label></td>
					<td><asp:textbox id="txtBillNo" runat="server"></asp:textbox></td>
					<td><asp:label id="Label8" runat="server">提货单位：</asp:label></td>
					<td><asp:dropdownlist id="ddlDeliveryCompany" runat="server" AutoPostBack="True" Width="128px"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td><asp:label id="Label3" runat="server">供货单位：</asp:label></td>
					<td><asp:textbox id="txtProvideCompany" runat="server"></asp:textbox></td>
					<td><asp:label id="Label9" runat="server">合同编号：</asp:label></td>
					<td><asp:dropdownlist id="ddlContractNo" runat="server" Width="128px"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td><asp:label id="Label5" runat="server">领用数量：</asp:label></td>
					<td><asp:textbox id="txtReceiveCount" runat="server"></asp:textbox></td>
					<td><asp:label id="Label10" runat="server">实发数量：</asp:label></td>
					<td><asp:textbox id="txtCount" runat="server" AutoPostBack="True"></asp:textbox></td>
				</tr>
				<tr>
					<td style="HEIGHT: 14px"><asp:label id="Label6" runat="server">专供单价：</asp:label></td>
					<td style="HEIGHT: 14px"><asp:textbox id="txtSpecialUnitPrice" runat="server"></asp:textbox></td>
					<td style="HEIGHT: 14px"><asp:label id="Label11" runat="server">专供金额：</asp:label></td>
					<td style="HEIGHT: 14px"><asp:textbox id="txtSpecialFee" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label7" runat="server">提货人：</asp:label></td>
					<td><asp:textbox id="txtDeliveryMan" runat="server"></asp:textbox></td>
					<td><asp:label id="Label12" runat="server">提货日期：</asp:label></td>
					<td><asp:textbox id="txtDeliveryDate" onfocus="calendar()" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label13" runat="server">发货起始日期：</asp:label></td>
					<td><asp:textbox id="txtProvideBeginDate" onfocus="calendar()" runat="server"></asp:textbox></td>
					<td><asp:label id="Label14" runat="server">发货终止日期：</asp:label></td>
					<td><asp:textbox id="txtProvideEndDate" onfocus="calendar()" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label15" runat="server">发货业务员：</asp:label></td>
					<td><asp:textbox id="txtProvideMan" runat="server"></asp:textbox></td>
					<td><asp:label id="Label16" runat="server">有效期：</asp:label></td>
					<td><asp:textbox id="txtTimeOfValidity" onfocus="calendar()" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label17" runat="server">签发单位：</asp:label></td>
					<td><asp:textbox id="txtSignerCompany" runat="server"></asp:textbox></td>
					<td><asp:label id="Label18" runat="server">签发人：</asp:label></td>
					<td><asp:textbox id="txtSigner" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td colSpan="4" align="center">
						<hr>
						<asp:button id="btnOK" runat="server" Text="确定" Width="100px"></asp:button><asp:button id="btnCancel" runat="server" Text="取消" Width="100px"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
