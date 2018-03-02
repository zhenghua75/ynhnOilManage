
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	BusiSerialNo.cs
* ����:	     ֣��
* ��������:    2008-7-13
* ��������:    ������ˮ���ɱ�

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
	/// **�������ƣ�������ˮ���ɱ�ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbBusiSerialNo")]
	public class BusiSerialNo: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private decimal _cnnSerialNo;
		private string _cnvcFill = String.Empty;
		
		#endregion
		
		#region ���캯��




		public BusiSerialNo():base()
		{
		}
		
		public BusiSerialNo(DataRow row):base(row)
		{
		}
		
		public BusiSerialNo(DataTable table):base(table)
		{
		}
		
		public BusiSerialNo(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������




				
		/// <summary>
		/// ��ˮ��
		/// </summary>
		[ColumnMapping("cnnSerialNo",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public decimal cnnSerialNo
		{
			get {return _cnnSerialNo;}
			set {_cnnSerialNo = value;}
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
