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
					<td colSpan="6" align="center"><font style="FONT-SIZE: 10pt; FONT-WEIGHT: bold">验收单明细修改</font>
						<asp:textbox id="txtDeptID" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtDeptName" runat="server" Visible="False"></asp:textbox>
						<hr>
					</td>
				</tr>
				<tr>
					<td><asp:label id="Label1" runat="server">物料名称：</asp:label></td>
					<td><asp:dropdownlist id="ddlGoodsName" runat="server" Width="136px"></asp:dropdownlist></td>
					<td><asp:label id="Label4" runat="server">物料型号：</asp:label></td>
					<td><asp:dropdownlist id="ddlGoodsType" runat="server" Width="128px"></asp:dropdownlist></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td><asp:label id="Label2" runat="server">收油核对单号：</asp:label></td>
					<td><asp:textbox id="txtBillNo" runat="server"></asp:textbox></td>
					<td><asp:label id="Label8" runat="server">出库单号：</asp:label></td>
					<td><asp:textbox id="txtOutNo" runat="server"></asp:textbox></td>
					<td><asp:label id="Label3" runat="server">入库方式：</asp:label></td>
					<td><asp:dropdownlist id="ddlInType" runat="server" Width="96px">
							<asp:ListItem Value="调拨入库">调拨入库</asp:ListItem>
							<asp:ListItem Value="购入">购入</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<tr>
					<td><asp:label id="Label5" runat="server">供油单位：</asp:label></td>
					<td><asp:dropdownlist id="ddlProvideCompany" runat="server"></asp:dropdownlist>
						<asp:TextBox id="txtProvideCompany" runat="server"></asp:TextBox></td>
					<td><asp:label id="Label12" runat="server">收油单位：</asp:label></td>
					<td><asp:textbox id="txtDeliveryComp" runat="server"></asp:textbox></td>
					<td><asp:label id="Label18" runat="server">发油日期</asp:label></td>
					<td><asp:textbox id="txtProvideDate" onfocus="calendar()" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label6" runat="server">运输车号：</asp:label></td>
					<td><asp:textbox id="txtTrLicenseTags" runat="server"></asp:textbox></td>
					<td><asp:label id="Label13" runat="server">承运人：</asp:label></td>
					<td><asp:textbox id="txtTransportMan" runat="server"></asp:textbox></td>
					<td><asp:label id="Label19" runat="server">收油日期：</asp:label></td>
					<td><asp:textbox id="txtDeliveryDate" onfocus="calendar()" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label7" runat="server">原发数：</asp:label></td>
					<td><asp:textbox id="txtOriginalCount" runat="server" AutoPostBack="True"></asp:textbox></td>
					<td><asp:label id="Label14" runat="server">验收数：</asp:label></td>
					<td><asp:textbox id="txtValidateCount" runat="server" AutoPostBack="True"></asp:textbox></td>
					<td><asp:label id="Label20" runat="server">运输公里数：</asp:label></td>
					<td><asp:textbox id="txtDistance" runat="server" AutoPostBack="True"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label9" runat="server">运输损耗定额：</asp:label></td>
					<td><asp:textbox id="txtTransportLose" runat="server" AutoPostBack="True"></asp:textbox>%</td>
					<td><asp:label id="Label15" runat="server">实际损耗：</asp:label></td>
					<td><asp:textbox id="txtLose" runat="server" AutoPostBack="True"></asp:textbox></td>
					<td rowSpan="2" colSpan="2"><asp:label id="Label17" runat="server" Width="197px" Height="64px" Font-Bold="True" ForeColor="Red">如果实际损耗小于定额内运输损耗，超定额运输损耗则等于0，请仔细核对单据！（提油计量偏差0.3%）</asp:label></td>
				</tr>
				<tr>
					<td><asp:label id="Label10" runat="server">定额内运输损耗：</asp:label></td>
					<td><asp:textbox id="txtQuotaLose" runat="server" AutoPostBack="True"></asp:textbox></td>
					<td><asp:label id="Label16" runat="server">超定额运输损耗：</asp:label></td>
					<td><asp:textbox id="txtQuterLose" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label11" runat="server">发油地点：</asp:label></td>
					<td colSpan="5"><asp:textbox id="txtProvideAddress" runat="server" Width="640px" Height="24px"></asp:textbox></td>
				</tr>
				<tr>
					<td colSpan="6" align="center">
						<hr>
						<asp:button id="btnOK" runat="server" Width="100px" Text="确定"></asp:button><asp:button id="btnCancel" runat="server" Width="100px" Text="取消"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
