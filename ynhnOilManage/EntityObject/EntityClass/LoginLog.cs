
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	LoginLog.cs
* ����:	     ֣��
* ��������:    2008-6-28
* ��������:    ��¼��־

*                                                           Copyright(C) 2008 fightop
*************************************************************************************/
#region Import NameSpace
using System;
using System.Data;
using ynhnOilManage.EntityObject.EntityBase;
#endregion

namespace ynhnOilManage.EntityObject.EntityClass
{
	/// <summary>
	/// **�������ƣ���¼��־ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbLoginLog")]
	public class LoginLog: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private int _cnnID;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndLoginTime;
		private string _cnvcIPAddress = String.Empty;
		private string _cnvcBrowser = String.Empty;
		
		#endregion
		
		#region ���캯��




		public LoginLog():base()
		{
		}
		
		public LoginLog(DataRow row):base(row)
		{
		}
		
		public LoginLog(DataTable table):base(table)
		{
		}
		
		public LoginLog(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������




				
		/// <summary>
		/// ���
		/// </summary>
		[ColumnMapping("cnnID",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public int cnnID
		{
			get {return _cnnID;}
			set {_cnnID = value;}
		}

		/// <summary>
		/// ����Ա
		/// </summary>
		[ColumnMapping("cnvcOperName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperName
		{
			get {return _cnvcOperName;}
			set {_cnvcOperName = value;}
		}

		/// <summary>
		/// ��¼ʱ��
		/// </summary>
		[ColumnMapping("cndLoginTime",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndLoginTime
		{
			get {return _cndLoginTime;}
			set {_cndLoginTime = value;}
		}

		/// <summary>
		/// ��ַ
		/// </summary>
		[ColumnMapping("cnvcIPAddress",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcIPAddress
		{
			get {return _cnvcIPAddress;}
			set {_cnvcIPAddress = value;}
		}

		/// <summary>
		/// �����
		/// </summary>
		[ColumnMapping("cnvcBrowser",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcBrowser
		{
			get {return _cnvcBrowser;}
			set {_cnvcBrowser = value;}
		}
		#endregion
	}	
}
