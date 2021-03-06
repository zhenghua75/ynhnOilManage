/*****************************************************************************
函数名：chkemail
功能介绍：检查是否为Email Address
参数说明：要检查的字符串
返回值：true：是  false：不是
日期	：2003/07/21
作者    ：尹凯
****************************************************************************/
function chkemail(strEmail)
{
　　　　　　var email = strEmail; 
　　　　　　//var pattern = /^([a-z]|[A-Z]|[0-9]|_)+@([a-zA-Z0-9_-])+(\.[a-zA-Z0-9_-])+/;
            var pattern = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
	    flag = pattern.test(email);
　　　　　　if(flag)
　　　　　　{　　　　　　　
　　　　　　　return true;
　　　　　　}
　　　　　　else
　　　　　　{
　　　　　　　return false;
　　　　　　}
}

/*****************************************************************************
函数名称：checkID
处理机能：身份证校验
日期	：2003/07/08
作者    ：尹凯
******************************************************************************/
function checkID(a)
{
	var i,j,strTemp;
	strTemp="0123456789";
	if ( a.length!= 15 && a.length!=18 )
	{
               	return 0;
	}
	for (i=0;i<a.length-1;i++)
	{
		j=strTemp.indexOf(a.charAt(i));
		if (j==-1)
		{
			return 0;
		}
	}
	j=strTemp.indexOf(a.charAt(a.length-1));
	strTemp=a.charAt(a.length-1);
	if(a.length==15){
		if(j==-1) return 0;
	}
	else{
		if((j==-1)&&(a.charAt(a.length-1)!='x')&&(a.charAt(a.length-1)!='X'))	return 0;
	}
	var strYear;
	var strMonth;
	var strDay;
	if(a.length==15)
	{
		strYear = '19'+a.substring(6,8);//六位日期
		strMonth = a.substring(8,10);
		strDay = a.substring(10,12);			
	}
	else
	{
		strYear = a.substring(6,10);//八位日期
		strMonth = a.substring(10,12);
		strDay = a.substring(12,14);		
	}	
	if(!isDate(strYear,strMonth,strDay))
	{
		return 0;
	}	
	return 1;
}

//检查邮政编码：checkPostalcode()
function checkPostalcode(a)
{
	var i,j,strTemp;
	strTemp="0123456789";
	if ( a.length!= 6 )
	{
		//alert("你填写的邮政编码不是6位的！")
		return 0
	}
	for (i=0;i<a.length;i++)
	{
		j=strTemp.indexOf(a.charAt(i));
		if (j==-1)
		{
		//说明有字符不是数字
			//alert("你填写的邮政编码不正确！有字符")
			return 0;
		}
	}
	//说明是数字
	return 1;
}

//函数名：fucCheckNUM
//功能介绍：检查是否为数字
//参数说明：要检查的数字
//返回值：1为是数字，0为不是数字
function fucCheckNUM(NUM)
{
	var i,j,strTemp;
	strTemp="0123456789";
	if ( NUM.length== 0)
		return 0
	for (i=0;i<NUM.length;i++)
	{
		j=strTemp.indexOf(NUM.charAt(i));
		if (j==-1)
		{
		//说明有字符不是数字
			return 0;
		}
	}
	//说明是数字
	return 1;
}

//函数名：fucCheckLength
//功能介绍：获得字符串的长度
//参数说明：要检查的字符串strTemp
//返回值：长度值
function fucCheckLength(strTemp)
{
	var i,sum;
	sum=0;
	for(i=0;i<strTemp.length;i++)
	{
		if ((strTemp.charCodeAt(i)>=0) && (strTemp.charCodeAt(i)<=255))
			sum=sum+1;
		else
			sum=sum+2;
	}
	return sum;
}

//检查是否为float
function checkfloat(acode,aname)
{
        if (acode.value.length <= 0) {
             alert("请输入"+aname+"!");
             return 0;
        }

        if (isNaN(acode.value) == true) {
             alert(aname+"只能为数字!");
             return 0;
        }
        if (acode.value < 0) {
             alert(aname+"必须大于等于零!");
             return 0;
        }
	return 1;
}


function verifyIP (IPvalue) {
errorString = "";
theName = "IPaddress";

var ipPattern = /^(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})$/;
var ipArray = IPvalue.match(ipPattern);

if (IPvalue == "0.0.0.0")
errorString = errorString + theName + ': '+IPvalue+' is a special IP address and cannot be used here.';
else if (IPvalue == "255.255.255.255")
errorString = errorString + theName + ': '+IPvalue+' is a special IP address and cannot be used here.';
if (ipArray == null)
errorString = errorString + theName + ': '+IPvalue+' is not a valid IP address.';
else {
for (i = 0; i < 4; i++) {
thisSegment = ipArray[i];
if (thisSegment > 255) {
errorString = errorString + theName + ': '+IPvalue+' is not a valid IP address.';
i = 4;
}
if ((i == 0) && (thisSegment > 255)) {
errorString = errorString + theName + ': '+IPvalue+' is a special IP address and cannot be used here.';
i = 4;
      }
   }
}
extensionLength = 3;
if (errorString == "")
return 0;
else
return 1;
}

//检查输入的数字,小数部分不能超过两位
//返回1表示合法
//返回0表示小数过长了
function checkdecimal(num)
{
	if(num.indexOf('.')>0){
		num=num.substr(num.indexOf('.')+1,num.length-1);

		if ((num.length)<3){
			return 1;
		}
		else{
			return 0;
		}
	}
			return 1;
}

/*****************************************************************************
函数名称：CheckHex
处理机能：检查是否是长度为8的16进制数字
参数	：sCheck 字符串
日期	：2003/02/28
作者    ：尹凯
修改人-------修改日--------概要--------------------------
******************************************************************************/
function  CheckHex(sCheck){
    var  sSource = "0123456789ABCDEabcde";
    var ch ;
    var i,i_return;
    i_return = -1;
    if (trim(sCheck).length==0)
        return 0;
    if (sCheck.length!=8)
        return 0;
    for  ( i = 0 ; i< sCheck.length ;i++) {
        ch = sCheck.charAt(i);
        r_return = sSource.indexOf(ch);
        if( r_return == -1)
            return 0;
        else
            continue;
    }
    return 1;
}

/*****************************************************************************
函数名称：DoMultiCheck
处理机能：所有字段综合校验
日期	：2003/03/04
作者    ：尹凯
修改人-------修改日--------概要--------------------------
参数：sCheck： 校验字符串  check_type:校验类型 null_or_not:能否为空  不能（1）能（0）
返回值：成功：true  失败：false
补充：有待扩展
******************************************************************************/
function DoMultiCheck(sCheck,check_type,null_or_not){
    //alert("check start....");
    var is_null = 0;
    is_null = null_or_not;
    if (is_null == 0){
        if(trim(sCheck).length==0) return false;
    }
    else if(is_null==1){
        if(trim(sCheck).length==0) return true;
    }
    else{
        return false;
    }
    if(check_type =="text"){
        return true;
    }
    else if(check_type == "email"){    	
        return chkemail(sCheck);
    }
    else if(check_type =="post"){
        if (checkPostalcode(sCheck)==0) return false;
    }
    else if(check_type =="date"){
        //待扩展
    }
    else if(check_type =="datetime"){
        //待扩展
    }
    else if(check_type =="id"){// 身份证
        if (checkID(sCheck)==0) return false;
    }
    else if(check_type =="digit"){// 数字
        if(fucCheckNUM(sCheck)==0) return false;
    }
    else if(check_type =="password"){// 密码    	
        if(sCheck.length<6)  	return false;
        if(fucCheckNUM(sCheck)==0 ) return false;
    }   
    else if(check_type == "decimal"){//小数点最大为两位的正浮点数判断
	if(!(isFloat(sCheck)&&sCheck>=0&&(checkdecimal(sCheck)==1))){
			return false;
	}
    }
    else{
        return false;
    }   
    return true;
}

/*****************************************************************************
函数名称：AllDeviceNumberCheck
处理机能：所有字段综合校验
日期	：2003/03/04
作者    ：尹凯
修改人-------修改日--------概要--------------------------
参数：sCheck： 校验字符串  tele_type:电信类型
返回值：成功：true  失败：false
补充：有待扩展
******************************************************************************/
function AllDeviceNumberCheck(strSvcNbr,strSvcType){
    var sCheck = trim(strSvcNbr);
    var sSvcType = trim(strSvcType);
    if (isNull(sCheck)||isNull(sSvcType)){
        return false;
    }   
    if(sSvcType=="LOCAL"){
    	if(sCheck.length>64) return false;
        if(fucCheckNUM(sCheck)==0 ) return false;
    }
    else if(sSvcType=='INTER'||sSvcType=='I169'||sSvcType=='MAIL')
    {
    	if(sCheck.length>64) return false;
    	var strTemp = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
    	if(strTemp.indexOf(sCheck.charAt(0))==-1) return false;
    	var strTempSvcNbr = sCheck.substring(1,sCheck.length);
    	//alert(strTempSvcNbr);
    	if(!checkname(strTempSvcNbr)) return false;
    }    
    return true;
}

/*****************************************************************************
函数名称：isDate
处理机能：日期校验
日期	：2003/03/04
作者    ：尹凯
******************************************************************************/
function isDate(sYear,sMonth,sDay)
{
	if( isNull(sYear ) ) return false;
	if( isNull(sMonth) ) return false;
	if( isNull(sDay  ) ) return false;

	if( sMonth.charAt(0) == '0' ) { sMonth = sMonth.substring(1,2); }
	if( sDay.charAt(0)   == '0' ) { sDay   = sDay.substring(1,2);   }

	var nYear  = parseInt(sYear );
	var nMonth = parseInt(sMonth);
	var nDay   = parseInt(sDay  );
	var arrMon = new Array(12);

	if ( isNaN(nYear ) )	return false;
	if ( isNaN(nMonth) )	return false;
	if ( isNaN(nDay  ) )	return false;

	arrMon[ 0] = 31;
	arrMon[ 1] = nYear % 4 == 0 ? 29:28;
	arrMon[ 2] = 31;
	arrMon[ 3] = 30;
	arrMon[ 4] = 31;
	arrMon[ 5] = 30;
	arrMon[ 6] = 31;
	arrMon[ 7] = 31;
	arrMon[ 8] = 30;
	arrMon[ 9] = 31;
	arrMon[10] = 30;
	arrMon[11] = 31;

	if ( nYear  < 1900 || nYear > 2100 )		return false;
	if ( nMonth < 1 || nMonth > 12 )		return false;
	if ( nDay < 1 || nDay > arrMon[nMonth - 1] )	return false;

	return true;
}

/*****************************************************************************
函数名称：checkname
处理机能：名称校验
日期	：2003/07/08
作者    ：尹凯
******************************************************************************/
function checkname(str)
{
	if(isNull(str)) return false;
 	var strPattern ="0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_";
  	var ch;
  	var i;
  	var temp;
  	for (i=0;i<str.length;i++)
  	{
    		ch = str.charAt(i);
    		temp = strPattern.indexOf(ch);
    		if (temp==-1)
    		{
    			return false;
    		}
  	}
  	if(str.charAt(0)=='_'||str.charAt(str.length-1)=='_')
  		return false;
	return true;
} 

/*****************************************************************************
函数名称：CheckAcctID
处理机能：身份卡号码校验
日期	：2003/09/18
作者    ：尹凯
******************************************************************************/
function CheckAcctID(strAcctID)
{
	if(trim(strAcctID).length==0) return false;
	if(fucCheckNUM(strAcctID)==0) return false;
	if(strAcctID.length!=9) return false;
	if(strAcctID.charAt(0)!='2'&&strAcctID.charAt(0)!='3') return false;	
	return true;
}
