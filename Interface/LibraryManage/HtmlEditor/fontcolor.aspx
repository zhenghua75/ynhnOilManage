<%@ Page language="c#" codePage="936" CodeBehind="fontcolor.aspx.cs" AutoEventWireup="false" Inherits="KxdInfo.KM.Interface.QueryInfoManage.HtmlEditor.fontcolor" %>
<html>
<head>
<title>设置字体颜色</title>
<meta http-equiv="Pragma" content="no-cache">
<meta http-equiv="Window-target" content="_top">
<meta http-equiv="Content-Language" content="zh-cn">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<style type="text/css">
body{margin:0px;scrollbar-face-color: #B8B8B8; scrollbar-highlight-color: #F5F9FF; scrollbar-shadow-color: #828282; scrollbar-3dlight-color: #828282; scrollbar-arrow-color: #797979; scrollbar-track-color: #ECECEC; scrollbar-darkshadow-color: #ffffff}
body,a,table,div,span,td,th,input,select{font:9pt;font-family: "宋体", Verdana, Arial, Helvetica, sans-serif;}
.text{border:1 solid #AAAAAA;}
</style>
<body bgcolor=menu topmargin="0" leftmargin="0">
<script>
var SelRGB = '#000000';
var DrRGB = '#000000';
var SelGRAY = '120';

var hexch = new Array('0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F');

function ToHex(n){
  var h, l;
  n = Math.round(n);
  l = n % 16;
  h = Math.floor((n / 16)) % 16;
  return (hexch[h] + hexch[l]);
}

function DoColor(c, l){
  var r, g, b;
  r = '0x' + c.substring(1, 3);
  g = '0x' + c.substring(3, 5);
  b = '0x' + c.substring(5, 7);

  if(l > 120) {
    l = l - 120;
    r = (r * (120 - l) + 255 * l) / 120;
    g = (g * (120 - l) + 255 * l) / 120;
    b = (b * (120 - l) + 255 * l) / 120;
  } else {
    r = (r * l) / 120;
    g = (g * l) / 120;
    b = (b * l) / 120;
  }
  return '#' + ToHex(r) + ToHex(g) + ToHex(b);
}

function EndColor(){
  var i;
  if(DrRGB != SelRGB) {
    DrRGB = SelRGB;
    for(i = 0; i <= 30; i ++)
      GrayTable.rows(i).bgColor = DoColor(SelRGB, 240 - i * 8);
  }
  SelColor.value = DoColor(RGB.innerText, GRAY.innerText);
  ShowColor.bgColor = SelColor.value;
}
</script>
</head>
<table border="1" cellspacing="0" cellpadding="0" width="260" align="center">
  <tr><td>
  <table id=ColorTable border="0" cellspacing="0" cellpadding="0" style='cursor:hand'
onclick		='SelRGB = event.srcElement.bgColor;		EndColor();'
onmouseover	='RGB.innerText = event.srcElement.bgColor;	EndColor();'
onmouseout	='RGB.innerText = SelRGB;			EndColor();'
>
<script>
function wc(r, g, b, n) {
  r = ((r * 16 + r) * 3 * (15 - n) + 0x80 * n) / 15;
  g = ((g * 16 + g) * 3 * (15 - n) + 0x80 * n) / 15;
  b = ((b * 16 + b) * 3 * (15 - n) + 0x80 * n) / 15;
  document.write('<td bgcolor=#' + ToHex(r) + ToHex(g) + ToHex(b) + ' height=8 width=8></td>');
}

var cnum = new Array(1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0);

for(i = 0; i < 16; i ++) {
  document.write('<tr>');
  for(j = 0; j < 30; j ++) {
    n1 = j % 5;
    n2 = Math.floor(j / 5) * 3;
    n3 = n2 + 3;
    wc((cnum[n3] * n1 + cnum[n2] * (5 - n1)),
    (cnum[n3 + 1] * n1 + cnum[n2 + 1] * (5 - n1)),
    (cnum[n3 + 2] * n1 + cnum[n2 + 2] * (5 - n1)), i);
  }
  document.writeln('</tr>');
}
</script>
  </table>
</td><td valign=bottom>
  <table ID=GrayTable border="0" cellspacing="0" cellpadding="0" height=100% style='cursor:hand'
onclick		='SelGRAY = event.srcElement.title;		EndColor();'
onmouseover	='GRAY.innerText = event.srcElement.title;	EndColor();'
onmouseout	='GRAY.innerText = SelGRAY;			EndColor();'
>
<script>
  for(i = 255; i >= 0; i -= 8.5)
     document.write('<tr bgcolor=#' + ToHex(i) + ToHex(i) + ToHex(i) + '><td title=' + Math.floor(i * 16 / 17) + ' height=4 width=20></td></tr>');
</script>
  </table>
</td></tr>
</table>
<table border="1" cellspacing="10" cellpadding="0" width="260" align="center">
  <tr><td rowspan="2" align="center">
  <table ID=ShowColor border="0" cellspacing="0" cellpadding="0" width="80" height="30">
     <tr><td></td></tr>
  </table>
<input class=text type=text size=7 ID=SelColor>
  </td><td rowspan="2" width="80" style="line-height:16pt">
基色: <span ID=RGB></span><br>
亮度: <span ID=GRAY>120</span>
  </td><td>
<input class=button type=submit onclick='window.returnValue = SelColor.value;window.close();' value="确　定">
  </td></tr>
  <tr><td>
<input class=button type=button onclick='window.close();' value="取　消">
  </td></tr>
</table>

</body>
</html>