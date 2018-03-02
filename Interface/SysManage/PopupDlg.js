// 得到日期
function getPopDate(strOldDate)
{
	showx = event.screenX - event.offsetX - 4 - 210 ;
	showy = event.screenY - event.offsetY + 18;
	var retval = window.showModalDialog("/BossWebApp/Common/CalendarDlg.htm",strOldDate, "dialogWidth:222px; dialogHeight:244px; dialogLeft:"+showx+"px; dialogTop:"+showy+"px; status:no; directories:yes;scrollbars:no;Resizable=no;help:no");
 	return (retval == null)? strOldDate: retval ;
}
