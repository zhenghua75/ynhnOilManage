
/******************************************************************** FR 1.20E *******
* 项目名称：   ynhnOilManage
* 文件名:   	LoginLog.cs
* 作者:	     郑华
* 创建日期:    2008-6-28
* 功能描述:    登录日志

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
	/// **功能名称：登录日志实体类
	/// </summary>
	[Serializable]
	[TableMapping("tbLoginLog")]
	public class LoginLog: EntityObjectBase
	{
		#region 数据表生成变量



		
		
		private int _cnnID;
		private string _cnvcOperName = String.Empty;
		private DateTime _cndLoginTime;
		private string _cnvcIPAddress = String.Empty;
		private string _cnvcBrowser = String.Empty;
		
		#endregion
		
		#region 构造函数




		public LoginLog():base()
		{
		}
		
		public LoginLog(DataRow row):base(row)
		{
		}
		
		public LoginLog(DataTable table):base(table)
		{
		}
		
		public LoginLog(string  strXML):base(strXML)
		{
		}
		#endregion
		
		#region 系统生成属性




				
		/// <summary>
		/// 序号
		/// </summary>
		[ColumnMapping("cnnID",IsPrimaryKey=true,IsIdentity=true,IsVersionNumber=false)]
		public int cnnID
		{
			get {return _cnnID;}
			set {_cnnID = value;}
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
		/// 登录时间
		/// </summary>
		[ColumnMapping("cndLoginTime",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public DateTime cndLoginTime
		{
			get {return _cndLoginTime;}
			set {_cndLoginTime = value;}
		}

		/// <summary>
		/// 地址
		/// </summary>
		[ColumnMapping("cnvcIPAddress",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcIPAddress
		{
			get {return _cnvcIPAddress;}
			set {_cnvcIPAddress = value;}
		}

		/// <summary>
		/// 浏览器
		/// </summary>
		[ColumnMapping("cnvcBrowser",IsPrimaryKey=false,IsIdentity=false,IsVersionNumber=false)]
		public string cnvcBrowser
		{
			get {return _cnvcBrowser;}
			set {_cnvcBrowser = value;}
		}
		#endregion
	}	
}
