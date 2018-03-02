<%@ Page language="c#" Codebehind="Left2.aspx.cs" AutoEventWireup="false" Inherits="ynhnOilManage.Interface.SysManage.Left2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>Left2</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="style_Left.css" type="text/css" rel="stylesheet">
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<META http-equiv="Pragma" content="no-cache">
		<META http-equiv="Cache-Control" content="no-cache">
		<META http-equiv="Expires" content="0">
		<style type="text/css">.style1 { COLOR: #215dc6 }
		</style>
		<LINK href="css/accordion.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="js/jquery-1.3.2.min.js" type="text/javascript"></script>
		<script language="javascript" src="js/jquery.msAccordion.js" type="text/javascript"></script>
	</HEAD>
	<body>
		<form id="Form1" style="FONT-FAMILY:   ; COLOR:   #07519a;  FONT-SIZE:   18px;  FONT-WEIGHT:   bold"
			method="post" runat="server">
			<br>
			<div class="accordionWrapper" id="accordion" style="BACKGROUND-COLOR: transparent">
				<div class="set set2">
					<div class="title">加油卡管理系统</div>
					<div class="content" style="Z-INDEX: 0">
						<TABLE id="tblUserInfo" cellSpacing="0" cellPadding="0" width="185" align="center" border="0"
							runat="server">
							<TR>
								<TD>
									<TABLE cellSpacing="0" cellPadding="0" width="185" border="0">
										<TR>
											<TD align="center" width="67" bgColor="#d6dff7" height="25" style="BACKGROUND-COLOR: transparent"><SPAN style="BACKGROUND-COLOR: transparent">&nbsp;<FONT color="#215dc6">部门</FONT><span class="style1" style="BACKGROUND-COLOR: transparent">：</span></SPAN></TD>
											<TD style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BACKGROUND-COLOR: transparent; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
												width="118" bgColor="#d6dff7" height="25">&nbsp;
												<asp:label id="lblDeptName" runat="server" ForeColor="#215DC6">lblDeptName</asp:label></TD>
										</TR>
										<TR>
											<TD align="center" width="67" bgColor="#d6dff7" height="25" style="BACKGROUND-COLOR: transparent"><SPAN class="style1" style="BACKGROUND-COLOR: transparent">&nbsp;用户：</SPAN></TD>
											<TD style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BACKGROUND-COLOR: transparent; BORDER-TOP-STYLE: none"
												bgColor="#d6dff7" height="25">&nbsp;
												<asp:label id="lblUserName" runat="server" ForeColor="#215DC6">lblUserName</asp:label></TD>
										</TR>
										<TR>
											<TD align="center" width="67" bgColor="#d6dff7" height="25" style="BACKGROUND-COLOR: transparent"><IMG src="../Images/lock off.ico"></TD>
											<TD bgColor="#d6dff7" height="25" style="BACKGROUND-COLOR: transparent">&nbsp; <A href="../SysManage/ChangePassword.aspx" target="mainFrame" style="BACKGROUND-COLOR: transparent">
													修改个人资料</A></TD>
										</TR>
										
										<TR>
											<TD align="center" width="67" bgColor="#d6dff7" height="25" style="BACKGROUND-COLOR: transparent"></TD>
											<TD bgColor="#d6dff7" height="25" style="BACKGROUND-COLOR: transparent">&nbsp; <A href="../SysManage/exit.aspx" target="mainFrame" style="BACKGROUND-COLOR: transparent">
													退出</A></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="BACKGROUND-COLOR: transparent">&nbsp;</TD>
							</TR>
						</TABLE>
					</div>
				</div>
				<div>
					<div class="title" style="FONT-SIZE: 16px; TEXT-DECORATION: underline">油 料 报 表</div>
					<div class="content">
						<TABLE id="tblOilReports" cellSpacing="0" cellPadding="0" width="185" align="center" border="0"
							runat="server">
							<TR>
								<TD>
									<TABLE cellSpacing="0" cellPadding="0" width="185" border="0">
										<TR id="trOilDayReport" runat="server">
											<TD style="WIDTH: 35px" align="center" width="35" bgColor="#d6dff7" height="25"><IMG height="20" src="../Images/date and time-2.ico" width="17"></TD>
											<TD width="118" bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkOilDayReport" runat="server" Target="mainFrame" NavigateUrl="../Report/wfmOilDayReport.aspx?FuncName=油料供应日报表">油料供应日报表</asp:hyperlink></TD>
										</TR>
										<TR id="trOilMonthReport" runat="server">
											<TD style="WIDTH: 35px" align="center" width="35" bgColor="#d6dff7" height="25"><IMG height="20" src="../Images/date and time-2.ico" width="17"></TD>
											<TD bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkOilMonthReport" runat="server" Target="mainFrame" NavigateUrl="../Report/wfmOilMonthReport.aspx?FuncName=油料收支存月报表">油料收支存月报表</asp:hyperlink></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
						</TABLE>
					</div>
				</div>
				<div class="set set3">
					<div class="title" style="FONT-SIZE: 16px; TEXT-DECORATION: underline">汇 总 报 表</div>
					<div class="content">
						<TABLE id="tblOilTotalReports" cellSpacing="0" cellPadding="0" width="185" align="center"
							border="0" runat="server">
							<TR>
								<TD>
									<TABLE cellSpacing="0" cellPadding="0" width="185" border="0">
										<TR id="trSpecialOilSumReport" runat="server">
											<TD style="WIDTH: 35px" align="center" width="35" bgColor="#d6dff7" height="25"><IMG height="20" src="../Images/report.ico" width="20"></TD>
											<TD width="118" bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkSpecialOilSumReport" runat="server" Target="mainFrame" NavigateUrl="../Report/wfmSpecialOilSumReport.aspx?FuncName=专供油供应汇总表">专供油供应汇总表</asp:hyperlink></TD>
										</TR>
										<TR id="trRetailOilSumReport" runat="server">
											<TD style="WIDTH: 35px" align="center" width="35" bgColor="#d6dff7" height="25"><IMG height="20" src="../Images/car.ico" width="20"></TD>
											<TD bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkRetailOilSumReport" runat="server" Target="mainFrame" NavigateUrl="../Report/wfmRetailOilSumReport.aspx?FuncName=零售油供应汇总表">零售油供应汇总表</asp:hyperlink></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
						</TABLE>
					</div>
				</div>
				<div class="set set3">
					<div class="title" style="FONT-SIZE: 16px; TEXT-DECORATION: underline">明 细 报 表</div>
					<div class="content">
						<TABLE id="tblOilListReports" cellSpacing="0" cellPadding="0" width="185" align="center"
							border="0" runat="server">
							<TR>
								<TD>
									<TABLE cellSpacing="0" cellPadding="0" width="185" border="0">
										<TR id="trSpecialOilListReport" runat="server">
											<TD align="center" width="40" bgColor="#d6dff7" height="25" style="WIDTH: 40px"><IMG height="20" src="../Images/report.ico" width="20"></TD>
											<TD width="118" bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkSpecialOilListReport" runat="server" NavigateUrl="../Report/wfmSpecialOilListReport.aspx?FuncName=专供油供应明细表"
													Target="mainFrame">专供油供应明细表</asp:hyperlink></TD>
										</TR>
										<TR id="trRetailOilListReport" runat="server">
											<TD align="center" width="40" bgColor="#d6dff7" height="25" style="WIDTH: 40px"><IMG height="20" src="../Images/car.ico" width="20"></TD>
											<TD bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkRetailOilListReport" runat="server" NavigateUrl="../Report/wfmRetailOilListReport.aspx?FuncName=零售油供应明细表"
													Target="mainFrame">零售油供应明细表</asp:hyperlink></TD>
										</TR>
										<TR id="trSotrageMoveListReport" runat="server">
											<TD align="center" width="40" bgColor="#d6dff7" height="25" style="WIDTH: 40px"><IMG height="20" src="../Images/database edit.ico" width="20"></TD>
											<TD bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkSotrageMoveListReport" runat="server" NavigateUrl="../Report/wfmSotrageMoveListReport.aspx?FuncName=储备库调拨明细报表"
													Target="mainFrame">储备库调拨明细报表</asp:hyperlink></TD>
										</TR>
										<TR id="trOilValidateListReport" runat="server">
											<TD align="center" width="40" bgColor="#d6dff7" height="25" style="WIDTH: 40px"><IMG height="20" src="../Images/ok_16.ico" width="20"></TD>
											<TD bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkOilValidateListReport" runat="server" NavigateUrl="../Report/wfmOilValidateListReport.aspx?FuncName=油料验收明细报表"
													Target="mainFrame">油料验收明细报表</asp:hyperlink></TD>
										</TR>
										<TR id="trStorageOilList" runat="server">
											<TD align="center" width="40" bgColor="#d6dff7" height="25" style="WIDTH: 40px"><IMG height="20" src="../Images/report.ico" width="20"></TD>
											<TD width="118" bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkStorageOilList" runat="server" NavigateUrl="../Report/wfmStorageOilListReport.aspx?FuncName=库存盘点明细表"
													Target="mainFrame">库存盘点明细表</asp:hyperlink></TD>
										</TR>
										<TR id="trOilStorageLog" runat="server">
											<TD align="center" width="40" bgColor="#d6dff7" height="25" style="WIDTH: 40px"><IMG height="20" src="../Images/report.ico" width="20"></TD>
											<TD width="118" bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkOilStorageLog" runat="server" NavigateUrl="../Report/wfmOilStorageLogReport.aspx?FuncName=库存日志明细表"
													Target="mainFrame">库存日志明细表</asp:hyperlink></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
						</TABLE>
					</div>
				</div>
				<div class="set set4">
					<div class="title" style="FONT-SIZE: 16px; TEXT-DECORATION: underline">会 员 报 表</div>
					<div class="content">
						<TABLE id="tblMemberReports" cellSpacing="0" cellPadding="0" width="185" align="center"
							border="0" runat="server">
							<TR>
								<TD>
									<TABLE cellSpacing="0" cellPadding="0" width="185" border="0">
										<TR id="trMemberList" runat="server">
											<TD align="center" width="34" bgColor="#d6dff7" height="25" style="WIDTH: 34px"><IMG height="20" src="../Images/users.ico" width="20"></TD>
											<TD width="118" bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkMemberList" runat="server" NavigateUrl="../Report/wfmMemberList.aspx?FuncName=会员清单"
													Target="mainFrame">会员清单</asp:hyperlink></TD>
										</TR>
										<TR id="trMemberCons" runat="server">
											<TD align="center" width="34" bgColor="#d6dff7" height="25" style="WIDTH: 34px"><IMG height="20" src="../Images/users.ico" width="20"></TD>
											<TD width="118" bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkMemberCons" runat="server" NavigateUrl="../Report/wfmMemberCons.aspx?FuncName=会员充值报表"
													Target="mainFrame">会员充值报表</asp:hyperlink></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
						</TABLE>
					</div>
				</div>
				<div class="set set5">
					<div class="title" style="FONT-SIZE: 16px; TEXT-DECORATION: underline">系统管理维护</div>
					<div class="content">
						<TABLE id="tblSysManage" cellSpacing="0" cellPadding="0" width="185" align="center" border="0"
							runat="server">
							<TR>
								<TD>
									<TABLE cellSpacing="0" cellPadding="0" width="185" border="0">
										<TR id="trDeptUserManage" runat="server">
											<TD align="center" width="40" bgColor="#d6dff7" height="25" style="WIDTH: 40px"><IMG height="20" src="../Images/Manager.gif" width="16"></TD>
											<TD bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkDeptUserManage" runat="server" NavigateUrl="../SysManage/wfmDeptUserManage.aspx?FuncName=部门人员维护"
													Target="mainFrame">部门人员维护</asp:hyperlink></TD>
										</TR>
										<TR id="trOperList" runat="server">
											<TD align="center" width="40" bgColor="#d6dff7" height="25" style="WIDTH: 40px"><IMG height="20" src="../Images/Manager.gif" width="16"></TD>
											<TD bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkOperList" runat="server" NavigateUrl="../SysManage/wfmOperList.aspx?FuncName=操作员查询"
													Target="mainFrame">操作员查询</asp:hyperlink></TD>
										</TR>
										<TR id="trPurviewManage" runat="server">
											<TD align="center" width="40" bgColor="#d6dff7" height="25" style="WIDTH: 40px"><IMG height="20" src="../Images/key.ico" width="20"></TD>
											<TD bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkPurviewManage" runat="server" NavigateUrl="../SysManage/wfmAuthorization.aspx?FuncName=权限修改"
													Target="mainFrame">权限修改</asp:hyperlink></TD>
										</TR>
										<TR id="trListMod" runat="server">
											<TD align="center" width="40" bgColor="#d6dff7" height="25" style="WIDTH: 40px"><IMG height="20" src="../Images/report.ico" width="20"></TD>
											<TD bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkListMod" runat="server" NavigateUrl="../SysManage/wfmListMod.aspx?FuncName=明细修改"
													Target="mainFrame">明细修改</asp:hyperlink></TD>
										</TR>
										<TR id="trOilPrice" runat="server">
											<TD align="center" width="40" bgColor="#d6dff7" height="25" style="WIDTH: 40px"><IMG height="20" src="../Images/car.ico" width="20"></TD>
											<TD bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkOilPrice" runat="server" NavigateUrl="../SysManage/wfmOilPrice.aspx?FuncName=油价修改"
													Target="mainFrame">油价修改</asp:hyperlink></TD>
										</TR>
										<TR id="trBusiLogReport" runat="server">
											<TD align="center" width="40" bgColor="#d6dff7" height="25" style="WIDTH: 40px"><IMG height="20" src="../Images/report.ico" width="20"></TD>
											<TD bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkBusiLogReport" runat="server" NavigateUrl="../Report/wfmBusiLogReport.aspx?FuncName=操作日志明细表"
													Target="mainFrame">操作日志明细表</asp:hyperlink></TD>
										</TR>
										<TR id="trCompanyPrepay" runat="server">
											<TD align="center" width="40" bgColor="#d6dff7" height="25" style="WIDTH: 40px"><IMG height="20" src="../Images/report.ico" width="20"></TD>
											<TD bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkCompanyPrepay" runat="server" NavigateUrl="../Prepay/wfmCompanyPrepay.aspx?FuncName=单位预存及充值"
													Target="mainFrame">单位预存及充值</asp:hyperlink></TD>
										</TR>
										<TR id="trSpecialOilDept" runat="server">
											<TD align="center" width="40" bgColor="#d6dff7" height="25" style="WIDTH: 40px"><IMG height="20" src="../Images/report.ico" width="20"></TD>
											<TD bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkSpecialOilDept" runat="server" NavigateUrl="../SysManage/wfmSpecialOilDept.aspx?FuncName=专供油领用单位管理"
													Target="mainFrame">专供油领用单位管理</asp:hyperlink></TD>
										</TR>
										<TR id="trRegister" runat="server">
											<TD align="center" width="40" bgColor="#d6dff7" height="25" style="WIDTH: 40px"><IMG height="20" src="../Images/key.ico" width="20"></TD>
											<TD bgColor="#d6dff7" height="25">&nbsp;
												<asp:hyperlink id="linkRegister" runat="server" NavigateUrl="../SysManage/wfmRegister.aspx?FuncName=注册"
													Target="mainFrame">注册</asp:hyperlink></TD>
										</TR>
										<TR>
											<TD align="center" width="40" bgColor="#d6dff7" height="25" style="WIDTH: 40px"><IMG src="../Images/help.ico"></TD>
											<TD bgColor="#d6dff7" height="25">&nbsp; <A href="../SysManage/help.mht" target="mainFrame">
													帮助</A></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
						</TABLE>
					</div>
				</div>
				<script language="javascript" type="text/javascript">
$(document).ready(function() {
						   
						   $("#accordion").msAccordion({defaultid:0, vertical:true});						   
						   }
						   )
				</script>
		</form>
		</DIV>
	</body>
</HTML>
