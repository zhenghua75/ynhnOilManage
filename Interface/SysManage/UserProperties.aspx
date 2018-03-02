<%@ Register TagPrefix="expo" Namespace="ynhnOilManage.Interface.SysManage" Assembly="Interface" %>
<%@ Page language="c#" Codebehind="UserProperties.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.SysManage.UserProperties" %>
<HTML XMLNS:IE>
	<HEAD>
		<title>UserProperties</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="window.css" type="text/css" rel="stylesheet">
		<STYLE> @media All { IE\:Calendar { WIDTH: 33%; BEHAVIOR: url(../../javascript/calendar.htc) }}
		</STYLE>
	</HEAD>
	<body class="background_group" onload="onInit();" MS_POSITIONING="GridLayout">
		<script language="javascript">
		//need to update the original database
		var DEFAULT_INVALID_YEAR=2;
		window.name="UserProperties";
		function onInit()
		{
			//var dt=new Date();
			//cal.value=""+(dt.getFullYear()+DEFAULT_INVALID_YEAR)+"-"+(dt.getMonth()+1)+"-"+dt.getDate();
			//UserProperties.btnDateSwitch.onclick=SwitchCalVisible;
			//UserProperties.btnDelOper.onclick=DeleteConfirm;
		}
		function DeleteConfirm()
		{
		    var isDel = confirm("ȷ���Ƿ�ɾ����Ա��");
		    return isDel;
		}
		function SwitchCalVisible()
		{
			if(cal.style.visibility=='visible')
			{
				cal.style.visibility='hidden';
				UserProperties.btnDateSwitch.value=">>";
			}			
			else
			{
				cal.style.visibility='visible';
				UserProperties.btnDateSwitch.value="<<";
				var eventObjX = event.screenX - event.offsetX - window.screenLeft;
				var eventObjY = event.screenY - event.offsetY - window.screenTop;
				
				
				cal.style.left = eventObjX + event.srcElement.offsetWidth - 300;
				cal.style.top  = eventObjY + event.srcElement.offsetHeight;
				try{
					cal.value=UserProperties.txtDate.value;
				}catch(ex)
				{
					var dt=new Date();
					cal.value=""+(dt.getFullYear()+DEFAULT_INVALID_YEAR)+"-"+(dt.getMonth()+1)+"-"+dt.getDate();
				}
			}
		}
		function onCalPropertyChange()
		{
			if(cal.style.visibility=='visible')
				UserProperties.txtDate.value=cal.value;
		}
		</script>
		<form id="UserProperties" method="post" runat="server" target="UserProperties">
			<TABLE id="Table1" cellSpacing="0" cellPadding="3" width="100%" align="center" border="0">
				<TBODY>
					<TR>
						<TD width="100%" colSpan="2" align="center" class="titlefont">
							<asp:Label id="lbProperties" runat="server">Label</asp:Label>&nbsp; <INPUT id="hidDept" type="hidden" name="hidDept" runat="server"><INPUT id="hidInputDate" type="hidden" name="hidInputDate" runat="server"><INPUT id="hidMethod" type="hidden" name="hidMethod" runat="server">
							<asp:TextBox id="txtOperID" runat="server" Visible="False"></asp:TextBox>
						</TD>
					</TR>
					<TR>
						<TD>
							<TABLE class="table_input_group" id="Table2" cellSpacing="0" cellPadding="3" width="100%"
								align="center" border="0">
								<TR>
									<TD width="50%" align="right" style="HEIGHT: 34px"><FONT face="����">&nbsp;</FONT> ����Ա����&nbsp;&nbsp;&nbsp;</TD>
									<TD width="50%" align="left" style="HEIGHT: 34px">
										<asp:textbox id="txtOperName" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD width="50%" align="right" style="HEIGHT: 34px"><FONT face="����">&nbsp;</FONT>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD width="50%" align="left" style="HEIGHT: 34px">
										<asp:CheckBox id="chkValidate" runat="server" Text="�Ƿ���Ч" Checked="True"></asp:CheckBox>
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 17px" align="right" width="50%"><FONT face="����">
											<asp:Label id="lbPwd" runat="server" Width="83px">�� &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��</asp:Label></FONT></TD>
									<TD style="HEIGHT: 17px" align="left" width="50%"><FONT face="����"><INPUT id="txtPwd" type="password" name="txtPwd" runat="server"></FONT></TD>
								</TR>
								<tr>
									<TD width="50%" align="right" style="HEIGHT: 34px"><FONT face="����">
											<asp:Label id="lbConfirmPwd" runat="server">ȷ&nbsp;��&nbsp;��&nbsp;��</asp:Label></FONT></TD>
									<td width="50%" align="left" style="HEIGHT: 34px"><INPUT id="txtConfirmPwd" type="password" name="txtConfirmPwd" runat="server"></td>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<td>
							<table cellSpacing="0" cellPadding="2" width="100%" align="center">
								<TBODY>
									<tr>
										<td width="50%" align="left">
											<asp:Button id="btnAddOper" runat="server" Text="������Ա"></asp:Button>
											<asp:Button id="btnMoveOper" runat="server" Text="�ƶ���..."></asp:Button>
											<asp:Button id="btnOperPasswd" runat="server" Text="���Ŀ���"></asp:Button></td>
										<td width="50%" align="left">
											<asp:button id="btnSubmit" runat="server" Text="�� ��"></asp:button>
											<asp:button id="btnCancel" runat="server" Text="ȡ ��"></asp:button></td>
									</tr>
								</TBODY>
							</table>
						</td>
					</tr>
				</TBODY>
			</TABLE>
		</form>
		<expo:alertcontrol id="alertControl" runat="server" Enable="false"></expo:alertcontrol><IE:CALENDAR id="cal" style="Z-INDEX: 101;POSITION: absolute;WIDTH: 300px;HEIGHT: 27px;VISIBILITY: hidden;TOP: 310px;LEFT: 675px"
			onpropertychange="onCalPropertyChange();"></IE:CALENDAR><FONT face="����"></FONT>
	</body>
</HTML>
