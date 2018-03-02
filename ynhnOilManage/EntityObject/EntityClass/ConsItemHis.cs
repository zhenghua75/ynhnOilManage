
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	ConsItemHis.cs
* 作者:	     郑华
* 创建日期:    2010/11/27
* 功能描述:    消费记录历史记录

*                                                           Copyright(C) 2010 zhenghua
*************************************************************************************/
#region Import NameSpace
using System;
using System.Data;
using ynhnOilManage.EntityObject.EntityBase;
#endregion

namespace ynhnOilManage.EntityObject.EntityClass
{
	/// <summary>
	/// **功能名称：消费记录历史记录实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbConsItemHis")]
	public class ConsItemHis: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private Guid _cnnSerial = Guid.Empty;
		private string _cnvcCardID = String.Empty;
		private string _cnvcLicenseTags = String.Empty;
		private string _cnvcGoodsName = String.Empty;
		private string _cnvcGoodsType = String.Empty;
		private string _cnvcUnit = String.Empty;
		private decimal _cnnDensity;
		private decimal _cnnKGCount;
		private decimal _cnnCount;
		private decimal _cnnPrice;
		private decimal _cnnFee;
		private string _cnvcComments = String.Empty;
		private string _cnvcConsType = String.Empty;
		private DateTime _cndConsDate;
		private Guid _cnvcCompanyID = Guid.Empty;
		private string _cnvcCompanyName = String.Empty;
		private Guid _cnvcAcctID = Guid.Empty;
		private string _cnvcDeptID = String.Empty;
		private string _cnvcDeptName = String.Empty;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		
		#endregion
		
		#region 构造函数




		public ConsItemHis():base()
		{
		}
		
		public ConsItemHis(DataRow row):base(row)
		{
		}
		
		public ConsItemHis(DataTable table):base(table)
		{
		}
		
		public ConsItemHis(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性




				
		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnSerial",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public Guid cnnSerial
		{
			get {return _cnnSerial;}
			set {_cnnSerial = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcCardID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCardID
		{
			get {return _cnvcCardID;}
			set {_cnvcCardID = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcLicenseTags",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcLicenseTags
		{
			get {return _cnvcLicenseTags;}
			set {_cnvcLicenseTags = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcGoodsName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcGoodsName
		{
			get {return _cnvcGoodsName;}
			set {_cnvcGoodsName = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcGoodsType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcGoodsType
		{
			get {return _cnvcGoodsType;}
			set {_cnvcGoodsType = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcUnit",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcUnit
		{
			get {return _cnvcUnit;}
			set {_cnvcUnit = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnDensity",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnDensity
		{
			get {return _cnnDensity;}
			set {_cnnDensity = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnKGCount",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnKGCount
		{
			get {return _cnnKGCount;}
			set {_cnnKGCount = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnCount",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnCount
		{
			get {return _cnnCount;}
			set {_cnnCount = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnPrice",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnPrice
		{
			get {return _cnnPrice;}
			set {_cnnPrice = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnFee",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnFee
		{
			get {return _cnnFee;}
			set {_cnnFee = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcComments",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcComments
		{
			get {return _cnvcComments;}
			set {_cnvcComments = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcConsType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcConsType
		{
			get {return _cnvcConsType;}
			set {_cnvcConsType = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cndConsDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndConsDate
		{
			get {return _cndConsDate;}
			set {_cndConsDate = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcCompanyID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public Guid cnvcCompanyID
		{
			get {return _cnvcCompanyID;}
			set {_cnvcCompanyID = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcCompanyName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCompanyName
		{
			get {return _cnvcCompanyName;}
			set {_cnvcCompanyName = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcAcctID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public Guid cnvcAcctID
		{
			get {return _cnvcAcctID;}
			set {_cnvcAcctID = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcDeptID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptID
		{
			get {return _cnvcDeptID;}
			set {_cnvcDeptID = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcDeptName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptName
		{
			get {return _cnvcDeptName;}
			set {_cnvcDeptName = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcOperName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperName
		{
			get {return _cnvcOperName;}
			set {_cnvcOperName = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cndOperDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndOperDate
		{
			get {return _cndOperDate;}
			set {_cndOperDate = value;}
		}
		#endregion
	}	
}
