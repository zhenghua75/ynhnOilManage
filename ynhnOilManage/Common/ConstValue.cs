#region 名字空间引用

using System;

#endregion

namespace ynhnOilManage.Common
{
	#region 模块注释
	///<summary>
	///作    用：系统常量定义
	///作    者：zhh
	///编写日期：2008-06-27
	///</summary>
	
	///<summary>
	///Log编 号：1
	///修改描述：
	///作    者：
	///修改日期：
	///</summary>
	#endregion
	public class ConstValue
	{
		#region 当前登录用户相关

		/// <summary>
		/// 登录用户实体SESSION名称
		/// </summary>
		public const string LOGIN_USER_SESSION = "LoginUser";
		/// <summary>
		/// 登录用户部门实体SESSION名称
		/// </summary>
		public const string LOGIN_DEPT_SESSION = "LoginUserDept";
		/// <summary>
		/// 登录用户菜单权限SESSION名称
		/// </summary>
		public const string LOGIN_USER_PURVIEW_SESSION = "UserPurview";
		/// <summary>
		/// 登录用户页面权限SESSION名称
		/// </summary>
		public const string LOGIN_USER_PAGE_SESSION = "UserPage";
		/// <summary>
		/// 显示菜单参数名称
		/// </summary>
		public const string SHOW_MENU_ARGS = "ShowMenuID";

		#endregion

		/// <summary>
		/// 操作人员字典名称
		/// </summary>
		public const string OPER_DICTI_NAME = "OperDictionary";
		/// <summary>
		/// 部门字典名称
		/// </summary>
		public const string DEPT_DICTI_NAME = "DeptDictionary";

		public const string COMMON_PAGE_VIEW = "CommonPageView";

		/// <summary>
		/// 企业全名
		/// </summary>
		public const string ENTERPRISEFULLNAME = "EnterpriseFullName";

		/// <summary>
		/// 企业简名
		/// </summary>
		public const string ENTERPRISESHORTNAME = "EnterpriseShortName";

		/// <summary>
		/// 站点标题
		/// </summary>
		public const string WEBSITETITLE = "WebSiteTitle";
	}
	public sealed class OutType
	{
		/// <summary>
		/// 调拨出库
		/// </summary>
		public const string TransferOut = "调拨出库";	
		/// <summary>
		/// 出库单修改出库
		/// </summary>
		public const string BOSOut = "出库单修改出库";
		/// <summary>
		/// 出库单修改入库
		/// </summary>
		public const string BOSIn = "出库单修改入库";
	}
	/// <summary>
	/// 出入库类型
	/// </summary>
	public sealed class InType
	{	
		/// <summary>
		/// 调拨入库
		/// </summary>
		public const string TransferIn = "调拨入库";
		/// <summary>
		/// 购入
		/// </summary>
		public const string ByIn = "购入";
		/// <summary>
		/// 验收单修改出库
		/// </summary>
		public const string BOVModOut = "验收单修改出库";
		/// <summary>
		/// 验收单修改入库
		/// </summary>
		public const string BOVModIn = "验收单修改入库";
		/// <summary>
		/// 领料单修改出库
		/// </summary>
		public const string BOMModOut = "领料单修改出库";
		/// <summary>
		/// 领料单修改入库
		/// </summary>
		public const string BOMModIn = "领料单修改入库";
	}
	/// <summary>
	/// 日志来源
	/// </summary>
	public sealed class InSource
	{
		/// <summary>
		/// 客户端
		/// </summary>
		public const string cs = "客户端";
		public const string bs = "网站";
	}
	/// <summary>
	/// 业务异常
	/// </summary>
	public enum bexType
	{
		/// <summary>
		/// 中心参数不全
		/// </summary>
		centerNoPara,
		/// <summary>
		/// 未连接
		/// </summary>
		noconnect,
		/// <summary>
		/// 下载失败
		/// </summary>
		nodown,
		/// <summary>
		/// 数据库并发
		/// </summary>
		CONCURRENT,
		/// <summary>
		/// 空对象
		/// </summary>
		noobject
	}
	/// <summary>
	/// 操作类型
	/// </summary>
	public sealed class OperType
	{
		/// <summary>
		/// 验收单录入
		/// </summary>
		public const string OP010 = "OP010";
		/// <summary>
		/// 调拨出库单录入
		/// </summary>
		public const string OP011 = "OP011";
		/// <summary>
		/// 专供油领料单录入
		/// </summary>
		public const string OP012 = "OP012";
		/// <summary>
		/// 验收单修改
		/// </summary>
		public const string OP201 = "OP201";
		/// <summary>
		/// 调拨出库单修改
		/// </summary>
		public const string OP202 = "OP202";
		/// <summary>
		/// 专供油领料单修改
		/// </summary>
		public const string OP203 = "OP203";
		/// <summary>
		/// 专供油合同添加
		/// </summary>
		public const string OP204 = "OP204";
		/// <summary>
		/// 专供油合同修改
		/// </summary>
		public const string OP205 = "OP205";
		/// <summary>
		/// 重算
		/// </summary>
		public const string OP206 = "OP206";
	}
}
