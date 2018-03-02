
/******************************************************************** FR 1.20E *******
* ��Ŀ���ƣ�   ynhnOilManage
* �ļ���:   	SpecialOilDept.cs
* ����:	     ֣��
* ��������:    2008-8-27
* ��������:    ר�������õ�λ

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
	/// **�������ƣ�ר�������õ�λʵ����
	/// </summary>
	[Serializable]
	[TableMapping("tbSpecialOilDept")]
	public class SpecialOilDept: EntityObjectBase
	{
		#region ���ݱ����ɱ���



		
		
		private string _cnvcContractNo = String.Empty;
		private string _cnvcDeliveryCompany = String.Empty;
		
		#endregion
		
		#region ���캯��




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
		
		#region ϵͳ��������




				
		/// <summary>
		/// ��ͬ���
		/// </summary>
		[ColumnMapping("cnvcContractNo",IsPrimaryKey=true,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcContractNo
		{
			get {return _cnvcContractNo;}
			set {_cnvcContractNo = value;}
		}

		/// <summary>
		/// ���õ�λ����
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
