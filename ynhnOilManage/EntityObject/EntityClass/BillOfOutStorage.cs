
/******************************************************************** FR 1.20E *******
* 项目名称：   CMSM
* 文件名:  	BillOfOutStorage.cs
* 作者:		     郑华
* 创建日期:     2010-4-20
* 功能描述:    出库单

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
	/// **功能名称：出库单实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbBillOfOutStorage")]
	public class BillOfOutStorage: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private string _cnvcBillNo = String.Empty;
		private string _cnvcProvideStroage = String.Empty;
		private string _cnvcDeliveryCompany = String.Empty;
		private string _cnvcMoveNo = String.Empty;
		private string _cnvcBillOfMaterialsNo = String.Empty;
		private string _cnvcTransportCompany = String.Empty;
		private string _cnvcTransportLiscenseTags = String.Empty;
		private DateTime _cndOutStorageDate;
		private string _cnvcGoodsName = String.Empty;
		private string _cnvcGoodsType = String.Empty;
		private string _cnvcUnit = String.Empty;
		private decimal _cnnReceivableCount;
		private decimal _cnnCount;
		private string _cnvcComments = String.Empty;
		private string _cnvcStorageIncharge = String.Empty;
		private string _cnvcDeliveryMan = String.Empty;
		private string _cnvcLister = String.Empty;
		private string _cnvcOutType = String.Empty;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		private string _cnvcDeptID = String.Empty;
		private string _cnvcDeliveryDeptID = String.Empty;
		
		#endregion
		
		#region 构造函数




		public BillOfOutStorage():base()
		{
		}
		
		public BillOfOutStorage(DataRow row):base(row)
		{
		}
		
		public BillOfOutStorage(DataTable table):base(table)
		{
		}
		
		public BillOfOutStorage(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性




				
		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcBillNo",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcBillNo
		{
			get {return _cnvcBillNo;}
			set {_cnvcBillNo = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcProvideStroage",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcProvideStroage
		{
			get {return _cnvcProvideStroage;}
			set {_cnvcProvideStroage = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcDeliveryCompany",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeliveryCompany
		{
			get {return _cnvcDeliveryCompany;}
			set {_cnvcDeliveryCompany = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcMoveNo",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcMoveNo
		{
			get {return _cnvcMoveNo;}
			set {_cnvcMoveNo = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcBillOfMaterialsNo",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcBillOfMaterialsNo
		{
			get {return _cnvcBillOfMaterialsNo;}
			set {_cnvcBillOfMaterialsNo = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcTransportCompany",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcTransportCompany
		{
			get {return _cnvcTransportCompany;}
			set {_cnvcTransportCompany = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcTransportLiscenseTags",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcTransportLiscenseTags
		{
			get {return _cnvcTransportLiscenseTags;}
			set {_cnvcTransportLiscenseTags = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cndOutStorageDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndOutStorageDate
		{
			get {return _cndOutStorageDate;}
			set {_cndOutStorageDate = value;}
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
		[ColumnMapping("cnnReceivableCount",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnReceivableCount
		{
			get {return _cnnReceivableCount;}
			set {_cnnReceivableCount = value;}
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
		[ColumnMapping("cnvcComments",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcComments
		{
			get {return _cnvcComments;}
			set {_cnvcComments = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcStorageIncharge",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcStorageIncharge
		{
			get {return _cnvcStorageIncharge;}
			set {_cnvcStorageIncharge = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcDeliveryMan",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeliveryMan
		{
			get {return _cnvcDeliveryMan;}
			set {_cnvcDeliveryMan = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcLister",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcLister
		{
			get {return _cnvcLister;}
			set {_cnvcLister = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcOutType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOutType
		{
			get {return _cnvcOutType;}
			set {_cnvcOutType = value;}
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

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcDeptID",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptID
		{
			get {return _cnvcDeptID;}
			set {_cnvcDeptID = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcDeliveryDeptID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeliveryDeptID
		{
			get {return _cnvcDeliveryDeptID;}
			set {_cnvcDeliveryDeptID = value;}
		}
		#endregion
	}	
}
