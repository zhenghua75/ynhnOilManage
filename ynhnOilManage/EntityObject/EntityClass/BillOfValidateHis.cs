
/******************************************************************** FR 1.20E *******
* 项目名称：   CMSM
* 文件名:  	BillOfValidateHis.cs
* 作者:		     郑华
* 创建日期:     2010-4-19
* 功能描述:    验收单历史记录

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
	/// **功能名称：验收单历史记录实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbBillOfValidateHis")]
	public class BillOfValidateHis: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private string _cnvcBillNo = String.Empty;
		private string _cnvcOutNo = String.Empty;
		private string _cnvcProvideCompany = String.Empty;
		private string _cnvcDeliveryCompany = String.Empty;
		private DateTime _cndProvideDate;
		private string _cnvcGoodsName = String.Empty;
		private string _cnvcGoodsType = String.Empty;
		private string _cnvcUnit = String.Empty;
		private string _cnvcTransportLicenseTags = String.Empty;
		private string _cnvcTransportMan = String.Empty;
		private decimal _cnnOriginalCount;
		private decimal _cnnValidateCount;
		private decimal _cnnDistance;
		private decimal _cnnTransportLose;
		private decimal _cnnLose;
		private decimal _cnnQuotaLose;
		private decimal _cnnOuterLose;
		private string _cnvcProvideAddress = String.Empty;
		private string _cnvcInType = String.Empty;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		private DateTime _cndDeliveryDate;
		private string _cnvcDeptID = String.Empty;
		private string _cnvcProvideDeptID = String.Empty;
		
		#endregion
		
		#region 构造函数




		public BillOfValidateHis():base()
		{
		}
		
		public BillOfValidateHis(DataRow row):base(row)
		{
		}
		
		public BillOfValidateHis(DataTable table):base(table)
		{
		}
		
		public BillOfValidateHis(string  strXML):base(strXML)
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
		[ColumnMapping("cnvcOutNo",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOutNo
		{
			get {return _cnvcOutNo;}
			set {_cnvcOutNo = value;}
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
		[ColumnMapping("cnvcDeliveryCompany",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeliveryCompany
		{
			get {return _cnvcDeliveryCompany;}
			set {_cnvcDeliveryCompany = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cndProvideDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndProvideDate
		{
			get {return _cndProvideDate;}
			set {_cndProvideDate = value;}
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
		[ColumnMapping("cnvcTransportLicenseTags",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcTransportLicenseTags
		{
			get {return _cnvcTransportLicenseTags;}
			set {_cnvcTransportLicenseTags = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcTransportMan",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcTransportMan
		{
			get {return _cnvcTransportMan;}
			set {_cnvcTransportMan = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnOriginalCount",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnOriginalCount
		{
			get {return _cnnOriginalCount;}
			set {_cnnOriginalCount = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnValidateCount",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnValidateCount
		{
			get {return _cnnValidateCount;}
			set {_cnnValidateCount = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnDistance",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnDistance
		{
			get {return _cnnDistance;}
			set {_cnnDistance = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnTransportLose",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnTransportLose
		{
			get {return _cnnTransportLose;}
			set {_cnnTransportLose = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnLose",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnLose
		{
			get {return _cnnLose;}
			set {_cnnLose = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnQuotaLose",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnQuotaLose
		{
			get {return _cnnQuotaLose;}
			set {_cnnQuotaLose = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnOuterLose",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnOuterLose
		{
			get {return _cnnOuterLose;}
			set {_cnnOuterLose = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcProvideAddress",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcProvideAddress
		{
			get {return _cnvcProvideAddress;}
			set {_cnvcProvideAddress = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcInType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcInType
		{
			get {return _cnvcInType;}
			set {_cnvcInType = value;}
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
		[ColumnMapping("cndDeliveryDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndDeliveryDate
		{
			get {return _cndDeliveryDate;}
			set {_cndDeliveryDate = value;}
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
		[ColumnMapping("cnvcProvideDeptID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcProvideDeptID
		{
			get {return _cnvcProvideDeptID;}
			set {_cnvcProvideDeptID = value;}
		}
		#endregion
	}	
}
