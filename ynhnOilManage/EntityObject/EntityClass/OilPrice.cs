
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	OilPrice.cs
* 作者:	     郑华
* 创建日期:    2008-7-13
* 功能描述:    油价表

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
	/// **功能名称：油价表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbOilPrice")]
	public class OilPrice: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private Guid _cnnSerialNo = Guid.Empty;
		private DateTime _cndPriceDate;
		private string _cnvcGoodsName = String.Empty;
		private string _cnvcGoodsType = String.Empty;
		private string _cnvcUnit = String.Empty;
		private decimal _cnnOilPrice;
		private string _cnvcDeptName = String.Empty;
		private string _cnvcDeptID = String.Empty;
		
		#endregion
		
		#region 构造函数




		public OilPrice():base()
		{
		}
		
		public OilPrice(DataRow row):base(row)
		{
		}
		
		public OilPrice(DataTable table):base(table)
		{
		}
		
		public OilPrice(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性




				
		/// <summary>
		/// 流水号
		/// </summary>
		[ColumnMapping("cnnSerialNo",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public Guid cnnSerialNo
		{
			get {return _cnnSerialNo;}
			set {_cnnSerialNo = value;}
		}

		/// <summary>
		/// 时间
		/// </summary>
		[ColumnMapping("cndPriceDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndPriceDate
		{
			get {return _cndPriceDate;}
			set {_cndPriceDate = value;}
		}

		/// <summary>
		/// 商品名称
		/// </summary>
		[ColumnMapping("cnvcGoodsName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcGoodsName
		{
			get {return _cnvcGoodsName;}
			set {_cnvcGoodsName = value;}
		}

		/// <summary>
		/// 商品型号
		/// </summary>
		[ColumnMapping("cnvcGoodsType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcGoodsType
		{
			get {return _cnvcGoodsType;}
			set {_cnvcGoodsType = value;}
		}

		/// <summary>
		/// 单位
		/// </summary>
		[ColumnMapping("cnvcUnit",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcUnit
		{
			get {return _cnvcUnit;}
			set {_cnvcUnit = value;}
		}

		/// <summary>
		/// 油价
		/// </summary>
		[ColumnMapping("cnnOilPrice",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnOilPrice
		{
			get {return _cnnOilPrice;}
			set {_cnnOilPrice = value;}
		}

		/// <summary>
		/// 部门
		/// </summary>
		[ColumnMapping("cnvcDeptName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptName
		{
			get {return _cnvcDeptName;}
			set {_cnvcDeptName = value;}
		}

		/// <summary>
		/// 部门ID
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
