
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	MebCompanyPrepay.cs
* ����:	     ֣��
* ��������:    2008-7-18
* ��������:    ��λԤ��

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
	/// **�������ƣ���λԤ��ʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbMebCompanyPrepay")]
	public class MebCompanyPrepay: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private Guid _cnvcCompanyID = Guid.Empty;
		private string _cnvcCompanyName = String.Empty;
		private Guid _cnvcAcctID = Guid.Empty;
		private decimal _cnnPrepayFee;
		private string _cnvcDeptName = String.Empty;
		private string _cnvcDeptID = String.Empty;
		private bool _cnbValidate;
		#endregion
		
		#region ���캯��




		public MebCompanyPrepay():base()
		{
		}
		
		public MebCompanyPrepay(DataRow row):base(row)
		{
		}
		
		public MebCompanyPrepay(DataTable table):base(table)
		{
		}
		
		public MebCompanyPrepay(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region ϵͳ��������




				
		/// <summary>
		/// ��λID
		/// </summary>
		[ColumnMapping("cnvcCompanyID",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
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
		/// ��λ���
		/// </summary>
		[ColumnMapping("cnnPrepayFee",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnPrepayFee
		{
			get {return _cnnPrepayFee;}
			set {_cnnPrepayFee = value;}
		}

		/// <summary>
		/// ָ������վ
		/// </summary>
		[ColumnMapping("cnvcDeptName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptName
		{
			get {return _cnvcDeptName;}
			set {_cnvcDeptName = value;}
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
