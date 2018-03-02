<%@ Page language="c#" Codebehind="DeptProperties.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.SysManage.DeptProperties" %>
<%@ Register TagPrefix="expo" Namespace="ynhnOilManage.Interface.SysManage" Assembly="Interface" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DeptProperties</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<SCRIPT language="javascript" src="calendar.js"></SCRIPT>
		<SCRIPT language="javascript" src="PopupDlg.js"></SCRIPT>
		<SCRIPT language="javascript" src="validator.js"></SCRIPT>
		<SCRIPT language="javascript" src="TabIndex.js"></SCRIPT>
		<LINK href="window.css" type="text/css" rel="stylesheet">
		<script language="javascript">
	window.name="DeptProperties";
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" class="background_group">
		<form id="DeptProperties" method="post" runat="server" target="DeptProperties">
			<TABLE id="Table1" cellSpacing="0" cellPadding="3" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD width="100%" colSpan="2" align="center" class="titlefont">
							<asp:Label id="lbProperties" runat="server"></asp:Label>
							<input type="hidden" id="hidMethod" runat="server" NAME="hidMethod"> <input type="hidden" id="hidParentID" runat="server" NAME="hidParentID">
							<asp:TextBox id="txtDeptID" Runat="server" Visible="False"></asp:TextBox>
						</TD>
					</TR>
					<TR>
						<TD>
							<TABLE class="table_input_group" id="Table2" cellSpacing="0" cellPadding="3" width="100%"
								align="center" border="0">
								<TR>
									<TD width="50%" align="right" style="HEIGHT: 34px">部门名称&nbsp;</TD>
									<TD width="50%" align="left" style="HEIGHT: 34px"><asp:TextBox id="txtDeptName" runat="server"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD width="50%" align="right" style="HEIGHT: 34px">&nbsp;</TD>
									<TD width="50%" align="left" style="HEIGHT: 34px">
										<asp:CheckBox id="chkValidate" runat="server" Text="是否有效" Checked="True"></asp:CheckBox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<td>
							<table cellSpacing="0" cellPadding="2" width="100%" align="center">
								<TBODY>
									<tr>
										<td width="50%" align="left">
											<asp:Button id="btnAddUser" runat="server" Text="增加人员"></asp:Button>
											<asp:Button id="btnMoveDept" runat="server" Text="移动至..."></asp:Button>
											<asp:Button id="btnAddDept" runat="server" Text="增加部门"></asp:Button></td>
										<td width="50%" align="left"><asp:Button id="btnSubmit" runat="server" Text="提 交"></asp:Button>
											<asp:Button id="btnCancel" runat="server" Text="取 消"></asp:Button></td>
									</tr>
								</TBODY>
							</table>
						</td>
					</tr>
				</TBODY>
			</TABLE>
		</form>
		<expo:alertcontrol id="alertControl" runat="server" Enable="false"></expo:alertcontrol></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
