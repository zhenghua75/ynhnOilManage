
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	BusiLog.cs
* ����:	     ֣��
* ��������:    2008-7-13
* ��������:    Ӫҵ��־

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
	/// **�������ƣ�Ӫҵ��־ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbBusiLog")]
	public class BusiLog: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private Guid _cnnSerial = Guid.Empty;
		private string _cnvcOperType = String.Empty;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		private string _cnvcComments = String.Empty;
		private string _cnvcDeptName = String.Empty;
		private string _cnvcDeptID = String.Empty;
		private string _cnvcSource = String.Empty;
		
		#endregion
		
		#region ���캯��




		public BusiLog():base()
		{
		}
		
		public BusiLog(DataRow row):base(row)
		{
		}
		
		public BusiLog(DataTable table):base(table)
		{
		}
		
		public BusiLog(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������




				
		/// <summary>
		/// ��ˮ��
		/// </summary>
		[ColumnMapping("cnnSerial",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public Guid cnnSerial
		{
			get {return _cnnSerial;}
			set {_cnnSerial = value;}
		}

		/// <summary>
		/// ��������
		/// </summary>
		[ColumnMapping("cnvcOperType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperType
		{
			get {return _cnvcOperType;}
			set {_cnvcOperType = value;}
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
		/// ��������
		/// </summary>
		[ColumnMapping("cndOperDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndOperDate
		{
			get {return _cndOperDate;}
			set {_cndOperDate = value;}
		}

		/// <summary>
		/// ��ע
		/// </summary>
		[ColumnMapping("cnvcComments",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcComments
		{
			get {return _cnvcComments;}
			set {_cnvcComments = value;}
		}

		/// <summary>
		/// ��������
		/// </summary>
		[ColumnMapping("cnvcDeptName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptName
		{
			get {return _cnvcDeptName;}
			set {_cnvcDeptName = value;}
		}

		/// <summary>
		/// ����
		/// </summary>
		[ColumnMapping("cnvcDeptID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptID
		{
			get {return _cnvcDeptID;}
			set {_cnvcDeptID = value;}
		}

		/// <summary>
		/// ��Դ
		/// </summary>
		[ColumnMapping("cnvcSource",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcSource
		{
			get {return _cnvcSource;}
			set {_cnvcSource = value;}
		}
		#endregion
	}	
}
