
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	BusiSerialNo.cs
* 作者:	     郑华
* 创建日期:    2008-7-13
* 功能描述:    操作流水生成表

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
	/// **功能名称：操作流水生成表实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbBusiSerialNo")]
	public class BusiSerialNo: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private decimal _cnnSerialNo;
		private string _cnvcFill = String.Empty;
		
		#endregion
		
		#region 构造函数




		public BusiSerialNo():base()
		{
		}
		
		public BusiSerialNo(DataRow row):base(row)
		{
		}
		
		public BusiSerialNo(DataTable table):base(table)
		{
		}
		
		public BusiSerialNo(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性




				
		/// <summary>
		/// 流水号
		/// </summary>
		[ColumnMapping("cnnSerialNo",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public decimal cnnSerialNo
		{
			get {return _cnnSerialNo;}
			set {_cnnSerialNo = value;}
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
