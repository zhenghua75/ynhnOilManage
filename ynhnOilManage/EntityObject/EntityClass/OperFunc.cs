
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	OperFunc.cs
* ����:	     ֣��
* ��������:    2008-6-28
* ��������:    ����ԱȨ�ޱ�

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
	/// **�������ƣ�����ԱȨ�ޱ�ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbOperFunc")]
	public class OperFunc: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private int _cnnOperID;
		private string _cnvcFuncName = String.Empty;
		private string _cnvcFuncAddress = String.Empty;
		
		#endregion
		
		#region ���캯��




		public OperFunc():base()
		{
		}
		
		public OperFunc(DataRow row):base(row)
		{
		}
		
		public OperFunc(DataTable table):base(table)
		{
		}
		
		public OperFunc(string  strXML):base(strXML)
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
		/// ��������
		/// </summary>
		[ColumnMapping("cnvcFuncName",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFuncName
		{
			get {return _cnvcFuncName;}
			set {_cnvcFuncName = value;}
		}

		/// <summary>
		/// ���ܵ�ַ
		/// </summary>
		[ColumnMapping("cnvcFuncAddress",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFuncAddress
		{
			get {return _cnvcFuncAddress;}
			set {_cnvcFuncAddress = value;}
		}
		#endregion
	}	
}
