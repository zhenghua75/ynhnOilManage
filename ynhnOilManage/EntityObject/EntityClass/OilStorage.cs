
/******************************************************************** FR 1.20E *******
* 项目名称：   CMSM
* 文件名:  	OilStorage.cs
* 作者:		     郑华
* 创建日期:     2010-4-18
* 功能描述:    库存

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
	/// **功能名称：库存实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbOilStorage")]
	public class OilStorage: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private string _cnvcGoodsName = String.Empty;
		private string _cnvcGoodsType = String.Empty;
		private decimal _cnnStorageCount;
		private string _cnvcDeptName = String.Empty;
		private string _cnvcDeptID = String.Empty;
		
		#endregion
		
		#region 构造函数




		public OilStorage():base()
		{
		}
		
		public OilStorage(DataRow row):base(row)
		{
		}
		
		public OilStorage(DataTable table):base(table)
		{
		}
		
		public OilStorage(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性




				
		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcGoodsName",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcGoodsName
		{
			get {return _cnvcGoodsName;}
			set {_cnvcGoodsName = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnvcGoodsType",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcGoodsType
		{
			get {return _cnvcGoodsType;}
			set {_cnvcGoodsType = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		[ColumnMapping("cnnStorageCount",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnStorageCount
		{
			get {return _cnnStorageCount;}
			set {_cnnStorageCount = value;}
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
		[ColumnMapping("cnvcDeptID",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptID
		{
			get {return _cnvcDeptID;}
			set {_cnvcDeptID = value;}
		}
		#endregion
	}	
}
