<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.SysManage.Login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>登录<%=WebSiteTitle%></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<script src="../Scripts/AC_RunActiveContent.js" type="text/javascript"></script>
	</HEAD>
	<body scroll="no">
		<form method="post" runat="server">
			<TABLE id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0">
				<TR>
					<TD colSpan="3" align="center" valign="middle">
						<table border="0" cellspacing="0" cellpadding="0" id="tblInput" runat="server">
							<tr>
								<td width="28" align="right" valign="bottom"></td>
								<td width="440" height="28"></td>
								<td width="28" align="left" valign="bottom"></td>
							</tr>
							<tr>
								<td width="28"></td>
								<td width="440" align="center" valign="bottom">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="440" bgColor="#eaeaea" border="0">
										<TR>
											<TD colSpan="3"><IMG alt="" src="../Images/banner.gif" style="WIDTH: 439px; HEIGHT: 50px" height="50"
													width="445"></TD>
										</TR>
										<TR>
											<TD width="85" height="35" align="right" vAlign="bottom">操作员：</TD>
											<TD width="255" height="35" vAlign="bottom">&nbsp;
												<asp:textbox id="tbxAdminUser" tabIndex="1" runat="server" ToolTip="输入操作员名称" MaxLength="15" Width="192px">tbxAdminUser</asp:textbox>&nbsp;
												<asp:requiredfieldvalidator id="rfvAdminUser" runat="server" ToolTip="操作员名称不能为空！" ErrorMessage="*" ControlToValidate="tbxAdminUser"
													EnableClientScript="False"></asp:requiredfieldvalidator>
												<asp:regularexpressionvalidator id="revAdminUser" runat="server" ToolTip="操作员名称只能由字母、数字、下划线和中文组成！" ErrorMessage="*"
													ControlToValidate="tbxAdminUser" EnableClientScript="False" ValidationExpression="\w+"></asp:regularexpressionvalidator>
											</TD>
											<TD width="125" rowSpan="3" align="center"><img src="../Images/Login.gif" width="74" height="90"></TD>
										</TR>
										<TR>
											<TD width="85" height="35" align="right" vAlign="bottom">密&nbsp;&nbsp;码：</TD>
											<TD width="255" height="35" vAlign="bottom">&nbsp;
												<asp:textbox id="tbxAdminPass" tabIndex="2" runat="server" ToolTip="输入密码" MaxLength="15" TextMode="Password"
													Width="192px">tbxAdminPass</asp:textbox>&nbsp;
												<asp:requiredfieldvalidator id="rfvAdminPass" runat="server" ToolTip="密码不能为空！" ErrorMessage="*" ControlToValidate="tbxAdminPass"
													EnableClientScript="False"></asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD width="85" height="55" align="right"></TD>
											<TD width="255" height="55" align="right">&nbsp;
												<asp:imagebutton id="btnLogin" tabIndex="3" runat="server" ToolTip="单击完成登录" ImageUrl="../Images/btnLogin.gif"></asp:imagebutton>
												<FONT face="宋体">&nbsp; </FONT>
												<asp:imagebutton id="btnExit" tabIndex="4" runat="server" ToolTip="单击退出系统" ImageUrl="../Images/btnExit.gif"></asp:imagebutton>
												&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
										</TR>
									</TABLE>
								</td>
								<td width="28"></td>
							</tr>
							<tr>
								<td width="28" align="right" valign="top"></td>
								<td height="28"></td>
								<td width="28" align="left" valign="top"></td>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
