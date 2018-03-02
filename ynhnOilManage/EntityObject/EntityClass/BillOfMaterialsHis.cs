
/******************************************************************** FR 1.20E *******
* 项目名称：   CMSM
* 文件名:  	BillOfMaterialsHis.cs
* 作者:		     郑华
* 创建日期:     2010-4-19
* 功能描述:    领料单历史表

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
	/// **功能名称：领料单历史表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbBillOfMaterialsHis")]
	public class BillOfMaterialsHis: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private string _cnvcBillNo = String.Empty;
		private string _cnvcContractNo = String.Empty;
		private string _cnvcDeliveryCompany = String.Empty;
		private string _cnvcProvideCompany = String.Empty;
		private string _cnvcGoodsName = String.Empty;
		private string _cnvcGoodsType = String.Empty;
		private string _cnvcUnit = String.Empty;
		private decimal _cnnReceiveCount;
		private decimal _cnnCount;
		private string _cnvcDeliveryMan = String.Empty;
		private DateTime _cndDeliveryDate;
		private DateTime _cndProvideBeginDate;
		private DateTime _cndProvideEndDate;
		private string _cndProvideMan = String.Empty;
		private string _cnvcSignerCompany = String.Empty;
		private string _cnvcSigner = String.Empty;
		private DateTime _cndTimeOfValidity;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		private decimal _cnnSpecialUnitPrice;
		private decimal _cnnSpecialFee;
		private string _cnvcDeptID = String.Empty;
		
		#endregion
		
		#region 构造函数




		public BillOfMaterialsHis():base()
		{
		}
		
		public BillOfMaterialsHis(DataRow row):base(row)
		{
		}
		
		public BillOfMaterialsHis(DataTable table):base(table)
		{
		}
		
		public BillOfMaterialsHis(string  strXML):base(strXML)
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
		[ColumnMapping("cnvcContractNo",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcContractNo
		{
			get {return _cnvcContractNo;}
			set {_cnvcContractNo = value;}
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
		[ColumnMapping("cnvcProvideCompany",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcProvideCompany
		{
			get {return _cnvcProvideCompany;}
			set {_cnvcProvideCompany = value;}
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
		[ColumnMapping("cnnReceiveCount",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnReceiveCount
		{
			get {return _cnnReceiveCount;}
			set {_cnnReceiveCount = value;}
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
		[ColumnMapping("cnvcDeliveryMan",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeliveryMan
		{
			get {return _cnvcDeliveryMan;}
			set {_cnvcDeliveryMan = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cndDeliveryDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndDeliveryDate
		{
			get {return _cndDeliveryDate;}
			set {_cndDeliveryDate = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cndProvideBeginDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndProvideBeginDate
		{
			get {return _cndProvideBeginDate;}
			set {_cndProvideBeginDate = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cndProvideEndDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndProvideEndDate
		{
			get {return _cndProvideEndDate;}
			set {_cndProvideEndDate = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cndProvideMan",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cndProvideMan
		{
			get {return _cndProvideMan;}
			set {_cndProvideMan = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcSignerCompany",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcSignerCompany
		{
			get {return _cnvcSignerCompany;}
			set {_cnvcSignerCompany = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcSigner",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcSigner
		{
			get {return _cnvcSigner;}
			set {_cnvcSigner = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cndTimeOfValidity",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndTimeOfValidity
		{
			get {return _cndTimeOfValidity;}
			set {_cndTimeOfValidity = value;}
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
		[ColumnMapping("cnnSpecialUnitPrice",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnSpecialUnitPrice
		{
			get {return _cnnSpecialUnitPrice;}
			set {_cnnSpecialUnitPrice = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnSpecialFee",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnSpecialFee
		{
			get {return _cnnSpecialFee;}
			set {_cnnSpecialFee = value;}
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
		#endregion
	}	
}
