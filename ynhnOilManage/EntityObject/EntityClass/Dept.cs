
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	Dept.cs
* 作者:	     郑华
* 创建日期:    2010-4-17
* 功能描述:    部门表

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
	/// **功能名称：部门表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbDept")]
	public class Dept: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private string _cnvcDeptID = String.Empty;
		private string _cnvcDeptName = String.Empty;
		private string _cnvcParentDeptID = String.Empty;
		private string _cnvcLocalFlag = String.Empty;
		private bool _cnbValidate;
		
		#endregion
		
		#region 构造函数




		public Dept():base()
		{
		}
		
		public Dept(DataRow row):base(row)
		{
		}
		
		public Dept(DataTable table):base(table)
		{
		}
		
		public Dept(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性




				
		/// <summary>
		/// 部门ID
		/// </summary>
		[ColumnMapping("cnvcDeptID",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
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

		/// <summary>
		/// 上级部门ID
		/// </summary>
		[ColumnMapping("cnvcParentDeptID",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcParentDeptID
		{
			get {return _cnvcParentDeptID;}
			set {_cnvcParentDeptID = value;}
		}

		/// <summary>
		/// 本地部门标志
		/// </summary>
		[ColumnMapping("cnvcLocalFlag",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcLocalFlag
		{
			get {return _cnvcLocalFlag;}
			set {_cnvcLocalFlag = value;}
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
