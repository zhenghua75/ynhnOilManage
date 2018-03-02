
#region 名字空间引用

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

using ynhnOilManage.Common;
using ynhnOilManage.DataAccess.Common;
using ynhnOilManage.EntityObject.EntityClass;
using ynhnOilManage.DataAccess.AccessClass;

#endregion

namespace ynhnOilManage.BusinessRules.SysManage
{
	#region 模块注释
	///<summary>
	///作    用：操作人员登录业务规则处理
	///作    者：Fightop Lin
	///编写日期：2007-03-07
	///</summary>
	
	///<summary>
	///Log编 号：1
	///修改描述：
	///作    者：
	///修改日期：
	///</summary>
	#endregion
	public class OperLogin
	{
		private string strOperName   = String.Empty;
		private string strPassword   = String.Empty;
		private string strLoginIP    = String.Empty;
		private string strBrowser    = String.Empty;

		/// <summary>
		/// 构造器
		/// </summary>
		/// <param name="strUserID">操作员名称</param>
		/// <param name="strPassword">操作员密码</param>
		/// <param name="strLoginIP">登录IP</param>
		/// <param name="strBrowser">使用的浏览器</param>
		public OperLogin(string strOperName,string strPassword,string strLoginIP,string strBrowser)
		{
			this.strOperName   = strOperName;
			this.strPassword   = strPassword;
			this.strLoginIP    = strLoginIP;
			this.strBrowser    = strBrowser;
		}

		/// <summary>
		/// 执行登录
		/// </summary>
		/// <returns></returns>
		public Oper Login(out ArrayList lstPurview,out ArrayList lstPage)
		{
			SqlConnection conn = ConnectionPool.BorrowConnection();
			try
			{
				
				#region 取操作员实体

				DataTable dtOper = OperAccess.GetOperByName(conn,strOperName);
				if (dtOper.Rows.Count > 1)
				{
					throw new BusinessException("操作员登录","有同名操作员存在，登录失败！");
				}				
				// 取操作员实体
				Oper operLogin     = new Oper(dtOper);

				if(null == operLogin)
				{
					throw new BusinessException("操作员登录","操作员不存在，登录失败！");
				}
				if(!operLogin.cnbValidate) throw new BusinessException("操作员登录","账号已失效，登录失败！");
				if(operLogin.cnvcPwd != DataSecurity.Encrypt(strPassword))
				{
					throw new BusinessException("操作员登录","操作员密码不正确，登录失败！");
				}

				#endregion


				#region 处理操作人员权限

				// 处理操作人员权限
				lstPurview = new ArrayList();
				lstPage    = new ArrayList();
				DataTable dtOperFunc =  OperFuncAccess.GetOneOperFuncList(conn,operLogin.cnnOperID.ToString());
				foreach(DataRow row in dtOperFunc.Rows)
				{
					OperFunc operFunc = new OperFunc(row);					
					lstPurview.Add(operFunc.cnvcFuncName);
					lstPage.Add(operFunc.cnvcFuncAddress);
				}

				#endregion

				#region 写登录日志

				// 写登录日志
				LoginLog loginLog      = new LoginLog();
				loginLog.cnvcOperName    = strOperName; 
				loginLog.cnvcIPAddress = strLoginIP;
				loginLog.cnvcBrowser   = strBrowser;
				loginLog.cndLoginTime  = DateTime.Now;
				EntityMapping.Create(loginLog,conn);

				#endregion

				return operLogin;

			}
			finally
			{
				ConnectionPool.ReturnConnection(conn);
			}
		}
	}
}
