var gForm=null;
var gTabArray = new Array();
//var gIndex;
var gCom;

function InitTabControl(form,com)
{
//	gIndex = 0;
	gForm = form;
	gCom=com;
	var length=form.all.length;	
	for(var i=0;i<length;i++)
	{
		var elm=form.all[i];
		var index= parseInt(elm.tabIndex);
		if(index != null && index !=0 )
		{
			gTabArray[gTabArray.length] = elm;
		}
	}
	
	length=gTabArray.length;
	for(var i=0;i<length;i++)
	{
		for(var j=i+1;j<length;j++)
		{
			if(gTabArray[j].tabIndex<gTabArray[i].tabIndex)
			{
				var elm=gTabArray[j];
				gTabArray[j] = gTabArray[i];
				gTabArray[i] = elm;
			}
		}
	}
	for(var i=0;i<length;i++)
		gTabArray[i]._innerIndex = i;
	SetTabControlFocus();
	document.onkeypress = keyPress;
}

function FindNextTabControl(elm)
{
	if(elm._innerIndex == null)
		return null;
	var index= elm._innerIndex + 1;
	if(index == gTabArray.length)
		index = 0;
	return gTabArray[index];
}

function FocusableTabControl(orgElm)
{
	var elm=orgElm;
	while(elm !=null)
	{
		try{
			if(elm.readOnly) throw "Readonly component"; 
			elm.focus();
			return elm;
		}catch(ex)
		{
			elm=FindNextTabControl(elm);
			if(elm == orgElm) return null;
		}
	}
}

function SetTabControlFocus()
{
	var index= parseInt(gCom.value);
	if(index != null && index<gTabArray.length)
		FocusableTabControl(gTabArray[index]);
}

function keyPress()
{
	if(event.keyCode==13)
	{
		if(event.srcElement.form!=gForm) return;
		//var curObj=document.activeElement;
		//var elm = FindNextTabControl(document.activeElement);
		var elm = FindNextTabControl(event.srcElement);
		if(elm != null)
		{
			elm=FocusableTabControl(elm);
			if(elm!=null)
			{
				//gIndex = elm._innerIndex;
				gCom.value=elm._innerIndex;
			}
		}
	}
}
