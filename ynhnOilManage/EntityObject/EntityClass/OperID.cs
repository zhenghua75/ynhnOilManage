
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	OperID.cs
* ����:	     ֣��
* ��������:    2008-7-12
* ��������:    ����ԱID���ɱ�

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
	/// **�������ƣ�����ԱID���ɱ�ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbOperID")]
	public class OperID: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private int _cnnID;
		private string _cnvcFill = String.Empty;
		
		#endregion
		
		#region ���캯��




		public OperID():base()
		{
		}
		
		public OperID(DataRow row):base(row)
		{
		}
		
		public OperID(DataTable table):base(table)
		{
		}
		
		public OperID(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������




				
		/// <summary>
		/// ����ԱID
		/// </summary>
		[ColumnMapping("cnnID",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public int cnnID
		{
			get {return _cnnID;}
			set {_cnnID = value;}
		}

		/// <summary>
		/// ���ֵ
		/// </summary>
		[ColumnMapping("cnvcFill",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFill
		{
			get {return _cnvcFill;}
			set {_cnvcFill = value;}
		}
		#endregion
	}	
}
