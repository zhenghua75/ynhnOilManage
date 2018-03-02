<%@ Page language="c#" Codebehind="ChangePassword.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.SysManage.ChangePassword" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ChangePassword</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%" height="100%">
				<tr>
					<td valign="middle" align="center">
						<table>
							<tr>
								<td colspan="2" align="center" style="FONT-WEIGHT: bold; FONT-SIZE: 12pt">修改登录密码</td>
							</tr>
							<tr>
								<td><asp:Label id="lblOldPwd" runat="server">旧密码：</asp:Label></td>
								<td><asp:TextBox id="txtOldPwd" runat="server" TextMode="Password"></asp:TextBox></td>
							</tr>
							<tr>
								<td>
									<asp:Label id="lblNewPwd" runat="server">新密码：</asp:Label></td>
								<td>
									<asp:TextBox id="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox></td>
							</tr>
							<tr>
								<td>
									<asp:Label id="lblConfirmPwd" runat="server">确认密码：</asp:Label></td>
								<td>
									<asp:TextBox id="txtConfirmPwd" runat="server" TextMode="Password"></asp:TextBox></td>
							</tr>
							<tr>
								<td colspan="2" align="center">
									<asp:ImageButton id="btnOK" runat="server" ImageUrl="../Images/btnOk.gif"></asp:ImageButton>
									<asp:ImageButton id="btnCancel" runat="server" ImageUrl="../Images/btnCancel.gif"></asp:ImageButton></td>
							</tr>
							<tr><td colspan="2" height="20"></td></tr>
							<tr>
								<td colspan="2"><hr>
								</td>
							</tr>
							<tr><td colspan="2" height="20"></td></tr>
							<tr>
								<td colspan="2" align="center" style="FONT-WEIGHT: bold; FONT-SIZE: 12pt">修改用户名称</td>
							</tr>
							
							<tr>
								<td>
									<asp:Label id="lblOperName" runat="server">用户名称：</asp:Label></td>
								<td>
									<asp:TextBox id="txtOperName" runat="server"></asp:TextBox></td>
							</tr>
							<tr>
								<td colspan="2" align="center">
									<asp:ImageButton id="btnOperName" runat="server" ImageUrl="../Images/Change.gif"></asp:ImageButton></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
