
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	Oper.cs
* 作者:	     郑华
* 创建日期:    2008-7-12
* 功能描述:    操作员表

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
	/// **功能名称：操作员表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbOper")]
	public class Oper: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private int _cnnOperID;
		private string _cnvcOperName = String.Empty;
		private string _cnvcPwd = String.Empty;
		private string _cnvcDeptID = String.Empty;
		private bool _cnbValidate;
		#endregion
		
		#region 构造函数




		public Oper():base()
		{
		}
		
		public Oper(DataRow row):base(row)
		{
		}
		
		public Oper(DataTable table):base(table)
		{
		}
		
		public Oper(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性




				
		/// <summary>
		/// 操作员ID
		/// </summary>
		[ColumnMapping("cnnOperID",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public int cnnOperID
		{
			get {return _cnnOperID;}
			set {_cnnOperID = value;}
		}

		/// <summary>
		/// 操作员名称
		/// </summary>
		[ColumnMapping("cnvcOperName",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcOperName
		{
			get {return _cnvcOperName;}
			set {_cnvcOperName = value;}
		}

		/// <summary>
		/// 密码
		/// </summary>
		[ColumnMapping("cnvcPwd",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcPwd
		{
			get {return _cnvcPwd;}
			set {_cnvcPwd = value;}
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
