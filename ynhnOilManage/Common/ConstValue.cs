#region ���ֿռ�����

using System;

#endregion

namespace ynhnOilManage.Common
{
	#region ģ��ע��
	///<summary>
	///��    �ã�ϵͳ��������
	///��    �ߣ�zhh
	///��д���ڣ�2008-06-27
	///</summary>
	
	///<summary>
	///Log�� �ţ�1
	///�޸�������
	///��    �ߣ�
	///�޸����ڣ�
	///</summary>
	#endregion
	public class ConstValue
	{
		#region ��ǰ��¼�û����

		/// <summary>
		/// ��¼�û�ʵ��SESSION����
		/// </summary>
		public const string LOGIN_USER_SESSION = "LoginUser";
		/// <summary>
		/// ��¼�û�����ʵ��SESSION����
		/// </summary>
		public const string LOGIN_DEPT_SESSION = "LoginUserDept";
		/// <summary>
		/// ��¼�û��˵�Ȩ��SESSION����
		/// </summary>
		public const string LOGIN_USER_PURVIEW_SESSION = "UserPurview";
		/// <summary>
		/// ��¼�û�ҳ��Ȩ��SESSION����
		/// </summary>
		public const string LOGIN_USER_PAGE_SESSION = "UserPage";
		/// <summary>
		/// ��ʾ�˵���������
		/// </summary>
		public const string SHOW_MENU_ARGS = "ShowMenuID";

		#endregion

		/// <summary>
		/// ������Ա�ֵ�����
		/// </summary>
		public const string OPER_DICTI_NAME = "OperDictionary";
		/// <summary>
		/// �����ֵ�����
		/// </summary>
		public const string DEPT_DICTI_NAME = "DeptDictionary";

		public const string COMMON_PAGE_VIEW = "CommonPageView";

		/// <summary>
		/// ��ҵȫ��
		/// </summary>
		public const string ENTERPRISEFULLNAME = "EnterpriseFullName";

		/// <summary>
		/// ��ҵ����
		/// </summary>
		public const string ENTERPRISESHORTNAME = "EnterpriseShortName";

		/// <summary>
		/// վ�����
		/// </summary>
		public const string WEBSITETITLE = "WebSiteTitle";
	}
	public sealed class OutType
	{
		/// <summary>
		/// ��������
		/// </summary>
		public const string TransferOut = "��������";	
		/// <summary>
		/// ���ⵥ�޸ĳ���
		/// </summary>
		public const string BOSOut = "���ⵥ�޸ĳ���";
		/// <summary>
		/// ���ⵥ�޸����
		/// </summary>
		public const string BOSIn = "���ⵥ�޸����";
	}
	/// <summary>
	/// ���������
	/// </summary>
	public sealed class InType
	{	
		/// <summary>
		/// �������
		/// </summary>
		public const string TransferIn = "�������";
		/// <summary>
		/// ����
		/// </summary>
		public const string ByIn = "����";
		/// <summary>
		/// ���յ��޸ĳ���
		/// </summary>
		public const string BOVModOut = "���յ��޸ĳ���";
		/// <summary>
		/// ���յ��޸����
		/// </summary>
		public const string BOVModIn = "���յ��޸����";
		/// <summary>
		/// ���ϵ��޸ĳ���
		/// </summary>
		public const string BOMModOut = "���ϵ��޸ĳ���";
		/// <summary>
		/// ���ϵ��޸����
		/// </summary>
		public const string BOMModIn = "���ϵ��޸����";
	}
	/// <summary>
	/// ��־��Դ
	/// </summary>
	public sealed class InSource
	{
		/// <summary>
		/// �ͻ���
		/// </summary>
		public const string cs = "�ͻ���";
		public const string bs = "��վ";
	}
	/// <summary>
	/// ҵ���쳣
	/// </summary>
	public enum bexType
	{
		/// <summary>
		/// ���Ĳ�����ȫ
		/// </summary>
		centerNoPara,
		/// <summary>
		/// δ����
		/// </summary>
		noconnect,
		/// <summary>
		/// ����ʧ��
		/// </summary>
		nodown,
		/// <summary>
		/// ���ݿⲢ��
		/// </summary>
		CONCURRENT,
		/// <summary>
		/// �ն���
		/// </summary>
		noobject
	}
	/// <summary>
	/// ��������
	/// </summary>
	public sealed class OperType
	{
		/// <summary>
		/// ���յ�¼��
		/// </summary>
		public const string OP010 = "OP010";
		/// <summary>
		/// �������ⵥ¼��
		/// </summary>
		public const string OP011 = "OP011";
		/// <summary>
		/// ר�������ϵ�¼��
		/// </summary>
		public const string OP012 = "OP012";
		/// <summary>
		/// ���յ��޸�
		/// </summary>
		public const string OP201 = "OP201";
		/// <summary>
		/// �������ⵥ�޸�
		/// </summary>
		public const string OP202 = "OP202";
		/// <summary>
		/// ר�������ϵ��޸�
		/// </summary>
		public const string OP203 = "OP203";
		/// <summary>
		/// ר���ͺ�ͬ���
		/// </summary>
		public const string OP204 = "OP204";
		/// <summary>
		/// ר���ͺ�ͬ�޸�
		/// </summary>
		public const string OP205 = "OP205";
		/// <summary>
		/// ����
		/// </summary>
		public const string OP206 = "OP206";
	}
}
