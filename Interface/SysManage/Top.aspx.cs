
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

#endregion

namespace ynhnOilManage.Interface.SysManage
{
	#region ģ��ע��
	///<summary>
	///��    �ã���̨�������˵���CI��Ϣ
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
	
	public class Top : System.Web.UI.Page
	{

		#region �¼�����
		private void Page_Load(object sender, System.EventArgs e)
		{
			
		}
		#endregion

		protected System.Web.UI.WebControls.ImageButton btnDocManage;
		protected System.Web.UI.WebControls.ImageButton btnDocSearch;
		protected System.Web.UI.WebControls.ImageButton btnSysManage;
		protected System.Web.UI.WebControls.ImageButton btnExit;
		protected System.Web.UI.WebControls.ImageButton btnTotalReport;



		#region ����������Ա����

		protected System.Web.UI.WebControls.ImageButton btnTCGL;
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
