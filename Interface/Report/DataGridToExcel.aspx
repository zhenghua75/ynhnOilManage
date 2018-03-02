<%@ Register TagPrefix="uc1" TagName="ucPageView" Src="ucPageView.ascx" %>
<%@ Page language="c#" Codebehind="DataGridToExcel.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.Report.DataGridToExcel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Excel</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="../js/Comm.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/calendar.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/PopupDlg.js"></SCRIPT>
		<LINK href="/BossWebApp/css/window.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
				<tr>
					<td align="center"><uc1:ucpageview id="UcPageView1" runat="server" Visible="False"></uc1:ucpageview></td>
				</tr>
				<tr>
				</tr>
			</table>
		</form>
	</body>
</HTML>
