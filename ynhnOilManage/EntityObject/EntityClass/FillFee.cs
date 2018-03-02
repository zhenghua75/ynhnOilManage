
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	FillFee.cs
* ����:	     ֣��
* ��������:    2008-7-18
* ��������:    ��ֵ��

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
	/// **�������ƣ���ֵ��ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbFillFee")]
	public class FillFee: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private Guid _cnnSerial = Guid.Empty;
		private Guid _cnvcCompanyID = Guid.Empty;
		private string _cnvcCompanyName = String.Empty;
		private Guid _cnvcAcctID = Guid.Empty;
		private decimal _cnnFillFee;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		private string _cnvcDeptID = String.Empty;
		private string _cnvcDeptName = String.Empty;
		
		#endregion
		
		#region ���캯��




		public FillFee():base()
		{
		}
		
		public FillFee(DataRow row):base(row)
		{
		}
		
		public FillFee(DataTable table):base(table)
		{
		}
		
		public FillFee(string  strXML):base(strXML)
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
		/// ��λID
		/// </summary>
		[ColumnMapping("cnvcCompanyID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public Guid cnvcCompanyID
		{
			get {return _cnvcCompanyID;}
			set {_cnvcCompanyID = value;}
		}

		/// <summary>
		/// ��λ����
		/// </summary>
		[ColumnMapping("cnvcCompanyName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCompanyName
		{
			get {return _cnvcCompanyName;}
			set {_cnvcCompanyName = value;}
		}

		/// <summary>
		/// �ʺ�
		/// </summary>
		[ColumnMapping("cnvcAcctID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public Guid cnvcAcctID
		{
			get {return _cnvcAcctID;}
			set {_cnvcAcctID = value;}
		}

		/// <summary>
		/// ��ֵ���
		/// </summary>
		[ColumnMapping("cnnFillFee",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnFillFee
		{
			get {return _cnnFillFee;}
			set {_cnnFillFee = value;}
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
		/// ����ʱ��
		/// </summary>
		[ColumnMapping("cndOperDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndOperDate
		{
			get {return _cndOperDate;}
			set {_cndOperDate = value;}
		}

		/// <summary>
		/// ����ID
		/// </summary>
		[ColumnMapping("cnvcDeptID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptID
		{
			get {return _cnvcDeptID;}
			set {_cnvcDeptID = value;}
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
		#endregion
	}	
}
