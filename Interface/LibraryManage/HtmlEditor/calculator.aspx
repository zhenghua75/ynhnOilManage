<%@ Page language="c#" codePage="936" CodeBehind="calculator.aspx.cs" AutoEventWireup="false" Inherits="KxdInfo.KM.Interface.QueryInfoManage.HtmlEditor.calculator" %>
<html>
<head>
<title>辅助计算器</title>
<meta http-equiv="Pragma" content="no-cache">
<meta http-equiv="Window-target" content="_top">
<meta http-equiv="Content-Language" content="zh-cn">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<script language="JavaScript">
function computetoedit(obj) 
{
return eval(obj.expr.value)
}
function compute(obj) 

   {obj.expr.value = eval(obj.expr.value)}

var one = '1'

var two = '2'

var three = '3'

var four = '4'

var five = '5'

var six = '6'

var seven = '7'

var eight = '8'

var nine = '9'

var zero = '0'

var plus = '+'

var minus = '-'

var multiply = '*'

var divide = '/'

var decimal = '.'

function enter(obj, string) 

   {obj.expr.value += string}

function clear(obj) 

   {obj.expr.value = ''}
</script>
<style type="text/css">
<!--
input {
	font-size: 9pt;
}
-->
</style>
<body bgcolor=menu topmargin="0" leftmargin="0"></head>

<form name="calc">

  <table width="152" border=1 align="center" bordercolor="#efefef">
    <td colspan=4 width="202" bgcolor="#000000"><input type="text" name="expr" size=14 action="compute(this.form)" style="background-color: #000000; font-size: 18pt; color: #FFFF00; border: 1 inset #000000"> <tr>

<td width="37" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" 7 " onClick="enter(this.form, seven)">

<td width="50" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" 8 " onClick="enter(this.form, eight)">

<td width="47" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" 9 " onClick="enter(this.form, nine)">

<td width="50" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" / " onClick="enter(this.form, divide)">

<tr><td width="37" bgcolor="#C0C0C0">
    <p align="center"><input type="button" value=" 4 " onClick="enter(this.form, four)">

<td width="50" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" 5 " onClick="enter(this.form, five)">

<td width="47" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" 6 " onClick="enter(this.form, six)">

<td width="50" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" * " onClick="enter(this.form, multiply)">

<tr><td width="37" bgcolor="#C0C0C0">
    <p align="center"><input type="button" value=" 1 " onClick="enter(this.form, one)">

<td width="50" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" 2 " onClick="enter(this.form, two)">

<td width="47" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" 3 " onClick="enter(this.form, three)">

<td width="50" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" - " onClick="enter(this.form, minus)">

<tr><td width="37" bgcolor="#C0C0C0">
    <p align="center"><input type="button" value=" . " onClick="enter(this.form, decimal)">

  <td width="50" bgcolor="#C0C0C0">
    <p align="center"><input type="button" value=" 0 " onClick="enter(this.form, zero)">

<td width="47" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" AC" size= 3 onClick="clear(this.form)"> 

<td width="50" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" + " onClick="enter(this.form, plus)">

<tr><td colspan=4 width="196" bgcolor="#C0C0C0"><input type="button" value="   =   " onClick="compute(this.form)">
        <input type="button" value="计算并插入" onClick='window.returnValue = computetoedit(this.form);window.close();' LANGUAGE=javascript>
</table>
</form>
</body>
</html>