<%@ Page language="c#" codePage="936" CodeBehind="table.aspx.cs" AutoEventWireup="false" Inherits="KxdInfo.KM.Interface.QueryInfoManage.HtmlEditor.table" %>
<html>
<head>
<meta http-equiv="Pragma" content="no-cache">
<meta http-equiv="Window-target" content="_top">
<meta http-equiv="Content-Language" content="zh-cn">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<style type="text/css">
<!--
td {
	font-size: 9pt;
}
input {
	font-size: 9pt;
}
a:link {
	font-size: 9pt;
	text-decoration: none;
	color: #000000;
}
a:visited {
	font-size: 9pt;
	text-decoration: none;
	color: #000000;
}
.currentColor{
width:18px;height:18px;border:1px solid black;margin-left:0pt;margin-right:6pt;margin-top:0pt;margin-bottom:0pt
}
.colorTable{
height:75px
}
-->
</style>
</head>
<body bgcolor=menu>
<script language="JavaScript">
var tables = new Array; 
if (dialogArguments!=null)
{
tables = dialogArguments;
document.write(_CTablePopupRenderer_PrepareHTML(false,true));
}
else
document.write(_CTablePopupRenderer_PrepareHTML(true,false));

function _CTablePopupRenderer_PrepareHTMLPage(szID,bDisplay){
var sz="<TABLE height=100% "+((!bDisplay)?" style=\"display:none\"":"")+" width=100% CELLSPACING=0 CELLPADDING=0 ID="+szID+"><TR ID=tableContents><TD ID=tableOptions VALIGN=TOP NOWRAP WIDTH=150 ROWSPAN=2><A HREF=\"javascript:_CTablePopupRenderer_Select(this,'"+szID+"','prop1')\">设定行列</A><BR><BR><A HREF=\"javascript:_CTablePopupRenderer_Select(this,'"+szID+"','prop2')\">设定边框与间隔</A><BR><BR><A HREF=\"javascript:_CTablePopupRenderer_Select(this,'"+szID+"','prop3')\">设定边框</A><BR><BR><A HREF=\"javascript:_CTablePopupRenderer_Select(this,'"+szID+"','prop4')\">设定背景</A><BR></TD><TD BGCOLOR=black ID=puDivider ROWSPAN=2></TD><TD ID=tableProps VALIGN=TOP>"
if(szID=="tabNewBody"){
sz+= "<DIV align=left ID='"+szID+"prop1'><P CLASS=tablePropsTitle>设定行列</P><TABLE><TR><TD>行: </TD><TD><INPUT SIZE=2 MAXLENGTH=2 TYPE=text ID="+szID+"txtRows VALUE=2 ></TD></TR><TR><TD>列: </TD><TD><INPUT SIZE=2 MAXLENGTH=2 TYPE=text ID="+szID+"txtColumns VALUE=2 ></TD></TR></TABLE></DIV><DIV ID='"+szID+"prop2' STYLE=\"display:none\"><P CLASS=tablePropsTitle>设定边框与间隔</P>单元格边框: <INPUT SIZE=2 TYPE=text ID="+szID+"txtPadding VALUE=1><BR>单元格间隔: <INPUT SIZE=2 TYPE=text ID="+szID+"txtSpacing VALUE=1></DIV><DIV ID="+szID+"prop3 STYLE=\"display:none\"><P CLASS=tablePropsTitle>设定边框</P>边框宽度: <INPUT SIZE=2 TYPE=text ID="+szID+"txtBorder VALUE=1><BR>边框颜色: <INPUT SIZE=7 TYPE=text ID="+szID+"txtBorderColor value=#000000><BR>" +_CUtil_BuildColorTable("idBorder"+szID,"","_CTablePopupRenderer_ColorSelect(this,'"+szID+"txtBorderColor')")+"</DIV><DIV ID="+szID+"prop4 SIZE=12 STYLE=\"display:none\"><P CLASS=tablePropsTitle>设定背景</P>背景图片: <INPUT TYPE=text ID="+szID+"txtBackgroundImage SIZE=15><BR>背景颜色: <INPUT TYPE=text SIZE=7 ID="+szID+"txtBackgroundColor><BR>" +_CUtil_BuildColorTable("idBackground"+szID,"","_CTablePopupRenderer_ColorSelect(this,'"+szID+"txtBackgroundColor')")+"</DIV></TD></TR><TR><TD align=center ID=tableButtons valign=bottom>"
}
else{
sz+="<DIV align=left ID='"+szID+"prop1'><P CLASS=tablePropsTitle>修改行列</P><TABLE><TR><TD>行: </TD><TD><INPUT SIZE=2 MAXLENGTH=2 TYPE=text ID="+szID+"txtRows VALUE="+tables[0]+" ></TD></TR><TR><TD>列: </TD><TD><INPUT SIZE=2 MAXLENGTH=2 TYPE=text ID="+szID+"txtColumns VALUE="+tables[1]+" ></TD></TR></TABLE></DIV><DIV ID='"+szID+"prop2' STYLE=\"display:none\"><P CLASS=tablePropsTitle>修改边框与间隔</P>单元格边框: <INPUT SIZE=2 TYPE=text ID="+szID+"txtPadding VALUE="+tables[5]+"><BR>单元格间隔: <INPUT SIZE=2 TYPE=text ID="+szID+"txtSpacing VALUE="+tables[6]+"></DIV><DIV ID="+szID+"prop3 STYLE=\"display:none\"><P CLASS=tablePropsTitle>修改边框</P>边框宽度: <INPUT SIZE=2 TYPE=text ID="+szID+"txtBorder VALUE="+tables[3]+"><BR>边框颜色: <INPUT SIZE=7 TYPE=text ID="+szID+"txtBorderColor value="+tables[7]+"><BR>" +_CUtil_BuildColorTable("idBorder"+szID,"","_CTablePopupRenderer_ColorSelect(this,'"+szID+"txtBorderColor')")+"</DIV><DIV ID="+szID+"prop4 SIZE=12 STYLE=\"display:none\"><P CLASS=tablePropsTitle>修改背景</P>背景图片: <INPUT TYPE=text ID="+szID+"txtBackgroundImage SIZE=15 value="+tables[2]+"><BR>背景颜色: <INPUT TYPE=text SIZE=7 ID="+szID+"txtBackgroundColor VALUE="+tables[4]+"><BR>" +_CUtil_BuildColorTable("idBackground"+szID,"","_CTablePopupRenderer_ColorSelect(this,'"+szID+"txtBackgroundColor')")+"</DIV></TD></TR><TR><TD align=center ID=tableButtons valign=bottom>"
}
if(szID=="tabNewBody"){
sz+="<INPUT TYPE=submit ONCLICK=\"window.returnValue = _CTablePopupRenderer_BuildTable('"+szID+"',this.document);window.close();\" VALUE=\"创建表格\"> <INPUT TYPE=reset VALUE=\" 取 消 \" onclick='window.close();'>"
}else{
sz+="<INPUT TYPE=submit ONCLICK=\"window.returnValue = _CTablePopupRenderer_BuildTable('"+szID+"',this.document);window.close();\" VALUE=\"修改表格\"> <INPUT TYPE=reset VALUE=\" 取 消 \" onclick='window.close();'>"
}
sz+= "</TD></TR></TABLE>"
return sz
}

function _CTablePopupRenderer_BuildTable(szID,d)
{
if(szID=="tabNewBody"){
var sz="<TABLE style='WIDTH: 100%' "+(((d.all[szID+"txtBorder"].value=="")||(d.all[szID+"txtBorder"].value=="0"))?"class=\"NOBORDER\"":"")+(d.all[szID+"txtPadding"].value!=""?"cellPadding=\""+d.all[szID+"txtPadding"].value+"\" ":"")+(d.all[szID+"txtSpacing"].value!=""?"cellSpacing=\""+d.all[szID+"txtSpacing"].value+"\" ":"")+(d.all[szID+"txtBorder"].value!=""?"border=\""+d.all[szID+"txtBorder"].value+"\" ":"")+(d.all[szID+"txtBorderColor"].value!=""?"bordercolor=\""+d.all[szID+"txtBorderColor"].value+"\" ":"")+(d.all[szID+"txtBackgroundImage"].value!=""?"background=\""+d.all[szID+"txtBackgroundImage"].value+"\" ":"")+(d.all[szID+"txtBackgroundColor"].value!=""?"bgColor=\""+d.all[szID+"txtBackgroundColor"].value+"\" ":"")+">"
if(d.all[szID+"txtRows"].value>99)d.all[szID+"txtRows"].value=99
if(d.all[szID+"txtColumns"].value>99)d.all[szID+"txtColumns"].value=99
for(var r=0;r<parseInt(d.all[szID+"txtRows"].value);r++)
{
sz+="<TR>"
for(var c=0;c<parseInt(d.all[szID+"txtColumns"].value);c++)
sz+="<TD>&nbsp;</TD>"
sz+="</TR>"
}
sz+="</TABLE>"
return sz
}else
if(szID=="tabEditBody"){
var mod = new Array;
mod[0]=d.all.tabEditBodytxtPadding.value
mod[1]=d.all.tabEditBodytxtSpacing.value
mod[2]=d.all.tabEditBodytxtBorder.value
mod[3]=(tables[3]==""||tables[3]=="0")?"NOBORDER":""
mod[4]=d.all.tabEditBodytxtBorderColor.value
mod[5]=d.all.tabEditBodytxtBackgroundColor.value
mod[6]=d.all.tabEditBodytxtBackgroundImage.value
mod[7]=d.all.tabEditBodytxtRows.value
mod[8]=d.all.tabEditBodytxtColumns.value
return mod
}
}

function _CTablePopupRenderer_ColorSelect(el,id)
{
el.document.all[id].value=el.bgColor
}

function _CTablePopupRenderer_Select(el,szID,id)
{
var d=el.document
for(var i=1;i<5;i++)
d.all[szID+"prop"+i].style.display="none"
d.all[szID+id].style.display=""
}

function _CUtil_BuildColorTable(sID,fmt,szClick)
{
var sz,cPick=new Array("00","33","66","99","CC","FF"),iCnt=2
var iColors=cPick.length,szColor=""
sz="<TABLE CELLSPACING=0 CELLPADDING=0<TR><TD><DIV CLASS=currentColor ID=\""+sID+"Current\">&nbsp;</DIV></TD><TD><TABLE style=cursor:hand ONMOUSEOUT=\"document.all."+sID+"Current.style.backgroundColor=''\" ONMOUSEOVER=\"document.all."+sID+"Current.style.backgroundColor=event.srcElement.bgColor\" CLASS=colorTable CELLSPACING=0 CELLPADDING=0 ID=\""+sID+"\">"
for(var r=0;r<iColors;r++){
sz+="<TR>"
for(var g=iColors-1;g>=0;g--)
for(var b=iColors-1;b>=0;b--){
szColor=cPick[r]+cPick[g]+cPick[b]
sz+="<TD BGCOLOR=\"#"+szColor+"\"_item=\""+szColor+"\" TITLE=\"#"+szColor+"\" "+(szClick?"ONCLICK=\""+szClick+"\" ":"")+">&nbsp;</TD>"
}
sz+="</TR>"
}
sz+="</TABLE></TD></TR></TABLE>"
return sz
}

function _CTablePopupRenderer_PrepareHTML(newbody,editbody)
{
var sz="<TABLE CLASS=tabBox ID=\"tabSelect\" CELLSPACING=0 CELLPADDING=0 WIDTH=95%><TR><TD VALIGN=TOP CLASS=tabBody COLSPAN=3>"+_CTablePopupRenderer_PrepareHTMLPage("tabNewBody",newbody)+_CTablePopupRenderer_PrepareHTMLPage("tabEditBody",editbody)+"</TD></TR></TABLE>"
return sz
}
</script>
</body>
</html>
