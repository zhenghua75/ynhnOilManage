
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	OperFunc.cs
* 作者:	     郑华
* 创建日期:    2008-6-28
* 功能描述:    操作员权限表

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
	/// **功能名称：操作员权限表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbOperFunc")]
	public class OperFunc: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private int _cnnOperID;
		private string _cnvcFuncName = String.Empty;
		private string _cnvcFuncAddress = String.Empty;
		
		#endregion
		
		#region 构造函数




		public OperFunc():base()
		{
		}
		
		public OperFunc(DataRow row):base(row)
		{
		}
		
		public OperFunc(DataTable table):base(table)
		{
		}
		
		public OperFunc(string  strXML):base(strXML)
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
		/// 功能名称
		/// </summary>
		[ColumnMapping("cnvcFuncName",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFuncName
		{
			get {return _cnvcFuncName;}
			set {_cnvcFuncName = value;}
		}

		/// <summary>
		/// 功能地址
		/// </summary>
		[ColumnMapping("cnvcFuncAddress",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFuncAddress
		{
			get {return _cnvcFuncAddress;}
			set {_cnvcFuncAddress = value;}
		}
		#endregion
	}	
}
