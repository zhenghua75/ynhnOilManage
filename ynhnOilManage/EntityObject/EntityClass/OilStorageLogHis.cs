
/******************************************************************** FR 1.20E *******
* 项目名称：   CMSM
* 文件名:  	OilStorageLogHis.cs
* 作者:		     郑华
* 创建日期:     2010-4-18
* 功能描述:    库存日志

*                                                           Copyright(C) 2010 zhenghua
*************************************************************************************/
#region Import NameSpace
using System;
using System.Data;
using ynhnOilManage.EntityObject.EntityBase;
#endregion

namespace  ynhnOilManage.EntityObject.EntityClass
{
	/// <summary>
	/// **功能名称：库存日志实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbOilStorageLogHis")]
	public class OilStorageLogHis: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private Guid _cnnSerial = Guid.Empty;
		private string _cnvcDeptName = String.Empty;
		private string _cnvcGoodsName = String.Empty;
		private string _cnvcGoodsType = String.Empty;
		private decimal _cnnInOutCount;
		private decimal _cnnLastCount;
		private decimal _cnnCurCount;
		private string _cnvcOperType = String.Empty;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		private string _cnvcDeptID = String.Empty;
		
		#endregion
		
		#region 构造函数




		public OilStorageLogHis():base()
		{
		}
		
		public OilStorageLogHis(DataRow row):base(row)
		{
		}
		
		public OilStorageLogHis(DataTable table):base(table)
		{
		}
		
		public OilStorageLogHis(string  strXML):base(strXML)
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
		[ColumnMapping("cnvcDeptName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptName
		{
			get {return _cnvcDeptName;}
			set {_cnvcDeptName = value;}
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
		[ColumnMapping("cnnInOutCount",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnInOutCount
		{
			get {return _cnnInOutCount;}
			set {_cnnInOutCount = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnLastCount",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnLastCount
		{
			get {return _cnnLastCount;}
			set {_cnnLastCount = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnCurCount",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnCurCount
		{
			get {return _cnnCurCount;}
			set {_cnnCurCount = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcOperType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperType
		{
			get {return _cnvcOperType;}
			set {_cnvcOperType = value;}
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
		[ColumnMapping("cnvcDeptID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptID
		{
			get {return _cnvcDeptID;}
			set {_cnvcDeptID = value;}
		}
		#endregion
	}	
}
