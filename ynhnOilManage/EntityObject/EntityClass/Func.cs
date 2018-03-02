
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	Func.cs
* 作者:	     郑华
* 创建日期:    2008-6-28
* 功能描述:    功能列表

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
	/// **功能名称：功能列表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbFunc")]
	public class Func: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private string _cnvcFuncName = String.Empty;
		private string _cnvcFuncAddress = String.Empty;
		private string _cnvcFuncType = String.Empty;
		
		#endregion
		
		#region 构造函数




		public Func():base()
		{
		}
		
		public Func(DataRow row):base(row)
		{
		}
		
		public Func(DataTable table):base(table)
		{
		}
		
		public Func(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性




				
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

		/// <summary>
		/// 功能类型
		/// </summary>
		[ColumnMapping("cnvcFuncType",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFuncType
		{
			get {return _cnvcFuncType;}
			set {_cnvcFuncType = value;}
		}
		#endregion
	}	
}
