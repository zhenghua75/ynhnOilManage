using System;

namespace ynhnOilManage.Interface.SysManage
{
	/// <summary>
	/// Summary description for DeptOper.
	/// </summary>
	public class DeptOper
	{
		public DeptOper()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public static string GetActualID(string strID)
		{
			string[] ss = strID.Split('_');
			if(ss == null ||ss.Length<2) return null;
			return ss[1];
		}

		public static string MakeWebID(string strType,string strID)
		{
			return strType+"_"+strID;
		}

	}
}
