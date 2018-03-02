
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	Oper.cs
* ����:	     ֣��
* ��������:    2008-7-12
* ��������:    ����Ա��

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
	/// **�������ƣ�����Ա��ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbOper")]
	public class Oper: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private int _cnnOperID;
		private string _cnvcOperName = String.Empty;
		private string _cnvcPwd = String.Empty;
		private string _cnvcDeptID = String.Empty;
		private bool _cnbValidate;
		#endregion
		
		#region ���캯��




		public Oper():base()
		{
		}
		
		public Oper(DataRow row):base(row)
		{
		}
		
		public Oper(DataTable table):base(table)
		{
		}
		
		public Oper(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������




				
		/// <summary>
		/// ����ԱID
		/// </summary>
		[ColumnMapping("cnnOperID",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public int cnnOperID
		{
			get {return _cnnOperID;}
			set {_cnnOperID = value;}
		}

		/// <summary>
		/// ����Ա����
		/// </summary>
		[ColumnMapping("cnvcOperName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperName
		{
			get {return _cnvcOperName;}
			set {_cnvcOperName = value;}
		}

		/// <summary>
		/// ����
		/// </summary>
		[ColumnMapping("cnvcPwd",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcPwd
		{
			get {return _cnvcPwd;}
			set {_cnvcPwd = value;}
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
		/// �Ƿ���Ч
		/// </summary>
		[ColumnMapping("cnbValidate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public bool cnbValidate
		{
			get {return _cnbValidate;}
			set {_cnbValidate = value;}
		}
		#endregion
	}	
}
