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
		    var isDel = confirm("确认是否删除人员？");
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
									<TD width="50%" align="right" style="HEIGHT: 34px"><FONT face="宋体">&nbsp;</FONT> 操作员姓名&nbsp;&nbsp;&nbsp;</TD>
									<TD width="50%" align="left" style="HEIGHT: 34px">
										<asp:textbox id="txtOperName" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD width="50%" align="right" style="HEIGHT: 34px"><FONT face="宋体">&nbsp;</FONT>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD width="50%" align="left" style="HEIGHT: 34px">
										<asp:CheckBox id="chkValidate" runat="server" Text="是否有效" Checked="True"></asp:CheckBox>
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 17px" align="right" width="50%"><FONT face="宋体">
											<asp:Label id="lbPwd" runat="server" Width="83px">密 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码</asp:Label></FONT></TD>
									<TD style="HEIGHT: 17px" align="left" width="50%"><FONT face="宋体"><INPUT id="txtPwd" type="password" name="txtPwd" runat="server"></FONT></TD>
								</TR>
								<tr>
									<TD width="50%" align="right" style="HEIGHT: 34px"><FONT face="宋体">
											<asp:Label id="lbConfirmPwd" runat="server">确&nbsp;认&nbsp;密&nbsp;码</asp:Label></FONT></TD>
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
											<asp:Button id="btnAddOper" runat="server" Text="增加人员"></asp:Button>
											<asp:Button id="btnMoveOper" runat="server" Text="移动至..."></asp:Button>
											<asp:Button id="btnOperPasswd" runat="server" Text="更改口令"></asp:Button></td>
										<td width="50%" align="left">
											<asp:button id="btnSubmit" runat="server" Text="提 交"></asp:button>
											<asp:button id="btnCancel" runat="server" Text="取 消"></asp:button></td>
									</tr>
								</TBODY>
							</table>
						</td>
					</tr>
				</TBODY>
			</TABLE>
		</form>
		<expo:alertcontrol id="alertControl" runat="server" Enable="false"></expo:alertcontrol><IE:CALENDAR id="cal" style="Z-INDEX: 101;POSITION: absolute;WIDTH: 300px;HEIGHT: 27px;VISIBILITY: hidden;TOP: 310px;LEFT: 675px"
			onpropertychange="onCalPropertyChange();"></IE:CALENDAR><FONT face="宋体"></FONT>
	</body>
</HTML>
