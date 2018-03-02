
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	SpecialOilDept.cs
* 作者:	     郑华
* 创建日期:    2008-8-27
* 功能描述:    专供油领用单位

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
	/// **功能名称：专供油领用单位实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbSpecialOilDept")]
	public class SpecialOilDept: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private string _cnvcContractNo = String.Empty;
		private string _cnvcDeliveryCompany = String.Empty;
		
		#endregion
		
		#region 构造函数




		public SpecialOilDept():base()
		{
		}
		
		public SpecialOilDept(DataRow row):base(row)
		{
		}
		
		public SpecialOilDept(DataTable table):base(table)
		{
		}
		
		public SpecialOilDept(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性




				
		/// <summary>
		/// 合同编号
		/// </summary>
		[ColumnMapping("cnvcContractNo",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcContractNo
		{
			get {return _cnvcContractNo;}
			set {_cnvcContractNo = value;}
		}

		/// <summary>
		/// 领用单位名称
		/// </summary>
		[ColumnMapping("cnvcDeliveryCompany",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcDeliveryCompany
		{
			get {return _cnvcDeliveryCompany;}
			set {_cnvcDeliveryCompany = value;}
		}
		#endregion
	}	
}
