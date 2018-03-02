
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	MebCompanyPrepay.cs
* 作者:	     郑华
* 创建日期:    2008-7-18
* 功能描述:    单位预存

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
	/// **功能名称：单位预存实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbMebCompanyPrepay")]
	public class MebCompanyPrepay: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private Guid _cnvcCompanyID = Guid.Empty;
		private string _cnvcCompanyName = String.Empty;
		private Guid _cnvcAcctID = Guid.Empty;
		private decimal _cnnPrepayFee;
		private string _cnvcDeptName = String.Empty;
		private string _cnvcDeptID = String.Empty;
		private bool _cnbValidate;
		#endregion
		
		#region 构造函数




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
		
		#region 系统生成属性




				
		/// <summary>
		/// 单位ID
		/// </summary>
		[ColumnMapping("cnvcCompanyID",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public Guid cnvcCompanyID
		{
			get {return _cnvcCompanyID;}
			set {_cnvcCompanyID = value;}
		}

		/// <summary>
		/// 单位名称
		/// </summary>
		[ColumnMapping("cnvcCompanyName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcCompanyName
		{
			get {return _cnvcCompanyName;}
			set {_cnvcCompanyName = value;}
		}

		/// <summary>
		/// 帐号
		/// </summary>
		[ColumnMapping("cnvcAcctID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public Guid cnvcAcctID
		{
			get {return _cnvcAcctID;}
			set {_cnvcAcctID = value;}
		}

		/// <summary>
		/// 单位余额
		/// </summary>
		[ColumnMapping("cnnPrepayFee",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnPrepayFee
		{
			get {return _cnnPrepayFee;}
			set {_cnnPrepayFee = value;}
		}

		/// <summary>
		/// 指定加油站
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
		/// <summary>
		/// 是否有效
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
