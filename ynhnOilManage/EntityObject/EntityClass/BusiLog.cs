
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	BusiLog.cs
* 作者:	     郑华
* 创建日期:    2008-7-13
* 功能描述:    营业日志

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
	/// **功能名称：营业日志实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbBusiLog")]
	public class BusiLog: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private Guid _cnnSerial = Guid.Empty;
		private string _cnvcOperType = String.Empty;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndOperDate;
		private string _cnvcComments = String.Empty;
		private string _cnvcDeptName = String.Empty;
		private string _cnvcDeptID = String.Empty;
		private string _cnvcSource = String.Empty;
		
		#endregion
		
		#region 构造函数




		public BusiLog():base()
		{
		}
		
		public BusiLog(DataRow row):base(row)
		{
		}
		
		public BusiLog(DataTable table):base(table)
		{
		}
		
		public BusiLog(string  strXML):base(strXML)
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
		/// 操作类型
		/// </summary>
		[ColumnMapping("cnvcOperType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperType
		{
			get {return _cnvcOperType;}
			set {_cnvcOperType = value;}
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
		/// 操作日期
		/// </summary>
		[ColumnMapping("cndOperDate",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndOperDate
		{
			get {return _cndOperDate;}
			set {_cndOperDate = value;}
		}

		/// <summary>
		/// 备注
		/// </summary>
		[ColumnMapping("cnvcComments",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcComments
		{
			get {return _cnvcComments;}
			set {_cnvcComments = value;}
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

		/// <summary>
		/// 部门
		/// </summary>
		[ColumnMapping("cnvcDeptID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeptID
		{
			get {return _cnvcDeptID;}
			set {_cnvcDeptID = value;}
		}

		/// <summary>
		/// 来源
		/// </summary>
		[ColumnMapping("cnvcSource",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcSource
		{
			get {return _cnvcSource;}
			set {_cnvcSource = value;}
		}
		#endregion
	}	
}
