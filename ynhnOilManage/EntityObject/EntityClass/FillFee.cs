
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	FillFee.cs
* 作者:	     郑华
* 创建日期:    2008-7-18
* 功能描述:    充值表

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
	/// **功能名称：充值表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbFillFee")]
	public class FillFee: EntityObjectBase
	{
		#region 数据表生成变量



		
		
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
		
		#region 构造函数




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
		
		#region 系统生成属性




				
		/// <summary>
		/// 流水号
		/// </summary>
		[ColumnMapping("cnnSerial",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public Guid cnnSerial
		{
			get {return _cnnSerial;}
			set {_cnnSerial = value;}
		}

		/// <summary>
		/// 单位ID
		/// </summary>
		[ColumnMapping("cnvcCompanyID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
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
		/// 充值金额
		/// </summary>
		[ColumnMapping("cnnFillFee",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public decimal cnnFillFee
		{
			get {return _cnnFillFee;}
			set {_cnnFillFee = value;}
		}

		/// <summary>
		/// 操作员
		/// </summary>
		[ColumnMapping("cnvcOperName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperName
		{
			get {return _cnvcOperName;}
			set {_cnvcOperName = value;}
		}

		/// <summary>
		/// 操作时间
		/// </summary>
		[ColumnMapping("cndOperDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndOperDate
		{
			get {return _cndOperDate;}
			set {_cndOperDate = value;}
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
		/// 部门名称
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
