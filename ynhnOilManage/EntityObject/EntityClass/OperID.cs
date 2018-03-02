
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	OperID.cs
* 作者:	     郑华
* 创建日期:    2008-7-12
* 功能描述:    操作员ID生成表

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
	/// **功能名称：操作员ID生成表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbOperID")]
	public class OperID: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private int _cnnID;
		private string _cnvcFill = String.Empty;
		
		#endregion
		
		#region 构造函数




		public OperID():base()
		{
		}
		
		public OperID(DataRow row):base(row)
		{
		}
		
		public OperID(DataTable table):base(table)
		{
		}
		
		public OperID(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性




				
		/// <summary>
		/// 操作员ID
		/// </summary>
		[ColumnMapping("cnnID",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public int cnnID
		{
			get {return _cnnID;}
			set {_cnnID = value;}
		}

		/// <summary>
		/// 填充值
		/// </summary>
		[ColumnMapping("cnvcFill",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcFill
		{
			get {return _cnvcFill;}
			set {_cnvcFill = value;}
		}
		#endregion
	}	
}
