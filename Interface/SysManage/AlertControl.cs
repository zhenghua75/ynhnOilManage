using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Text;
using System.IO;

namespace ynhnOilManage.Interface.SysManage
{
	/// <summary>
	/// Summary description for AlertControl.
	/// </summary>
	[DefaultProperty("Text"), 
		ToolboxData("<{0}:AlertControl runat=server></{0}:AlertControl>")]
	public class AlertControl : System.Web.UI.WebControls.WebControl
	{
		public enum ACTION
		{
			Alert,
			Redirct,
			CloseWindow,
			Script			
		}
		private string strMsg,redirectUrl;
		private bool bEnable;
		private ACTION action;
		private string script;

		[Bindable(true), 
			Category("Behavior"), 
			DefaultValue("")] 
		public string Msg 
		{
			get
			{
				return strMsg;
			}

			set
			{
				strMsg = value;
			}
		}

		[Bindable(true), 
			Category("Behavior"), 
			DefaultValue("")] 
		public string RedirectUrl 
		{
			get
			{
				return redirectUrl;
			}

			set
			{
				redirectUrl = value;
			}
		}

		[Bindable(true), 
			Category("Behavior"), 
			DefaultValue(false)] 
		public bool Enable
		{
			get
			{
				return bEnable;
			}
			set
			{
				bEnable=true;
			}
		}
		
		[Bindable(true), 
			Category("Behavior"), 
			DefaultValue(ACTION.Alert)] 
		public ACTION Action
		{
			get
			{
				return action;
			}
			set
			{
				action =value;
			}
		}

		[Bindable(true), 
			Category("Behavior"), 
			DefaultValue("")] 
		public string Script
		{
			get
			{
				return script;
			}
			set
			{
				script=value;
			}
		}
		/// <summary> 
		/// Render this control to the output parameter specified.
		/// </summary>
		/// <param name="output"> The HTML writer to write out to </param>
		protected override void Render(HtmlTextWriter output)
		{
			if(bEnable)
			{
				output.WriteLine("<script language=javascript>");
				if(strMsg!=null && strMsg.Length!=0)
				{
					output.WriteLine("var _str_alert_msg='';\r\n");
					StringReader reader = new StringReader(strMsg);
					string strLine;
					while((strLine = reader.ReadLine())!=null)
					{
						strLine=strLine.Replace("\"","\\\"");
						output.WriteLine("_str_alert_msg+=\""+strLine+"\\r\\n\";\r\n");
					}
					output.WriteLine("alert(_str_alert_msg);\r\n");
				}
				switch(action)
				{
					case ACTION.Redirct:
						if(redirectUrl!=null && redirectUrl.Length!=0)
							output.WriteLine("document.location=\""+redirectUrl+"\";\r\n");
						break;
					case ACTION.CloseWindow:
						output.WriteLine("window.opener=null;");
						output.WriteLine("window.close();");
						break;
					case ACTION.Script:
						output.WriteLine(script);
						break;					
				}
				output.WriteLine("</script>");
			}
		}
	}
}
