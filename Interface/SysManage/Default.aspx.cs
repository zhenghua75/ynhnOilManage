
#region ���ֿռ�����

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Configuration;

#endregion

namespace ynhnOilManage.Interface.SysManage
{
	#region ģ��ע��

	///<summary>
	///��    �ã�������̨����ʱ��ʾ��ӭ���沢��������¼ģ��
	///��    �ߣ�Fightop Lin
	///��д���ڣ�2003-11-11
	///</summary>
	
	///<summary>
	///Log�� �ţ�
	///�޸�������
	///��    �ߣ�
	///�޸����ڣ�
	///</summary>
	
	#endregion

	public class _Default : System.Web.UI.Page
	{
		#region ҳ������¼�����
		public string WebSiteTitle;
		private void Page_Load(object sender, System.EventArgs e)
		{  // ҳ������¼�����

			this.WebSiteTitle = CommonStatic.WebSiteTitle();

			string strJavaScript =	"<script language='javascript'>"               +
				"window.resizeTo(640,480);"                                        +
				"window.moveTo(screen.availWidth/2-320,screen.availHeight/2-240);" +	
   
				"function FullScreen()"                                            +
				"{"                                                                +
				"window.moveTo(0,0);"                                              +
				"window.resizeTo(screen.availWidth,screen.availHeight);"           +
				"var thewindow = window.open('Login.aspx', '_top');"               +
				"thewindow.focus(); "                                              +
				"}"                                                                +
         
				"setTimeout('FullScreen()',5000);"                                 +
				"</script>";  //  �ͻ��˴����������ô�����ɿ���ȫ����¼����

			Page.RegisterClientScriptBlock("FullScreen",strJavaScript);  // ע�����

		}

		#endregion


		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
