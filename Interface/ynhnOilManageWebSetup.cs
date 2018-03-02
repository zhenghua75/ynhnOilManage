using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;

namespace ynhnOilManage.Interface
{
	/// <summary>
	/// ynhnOilManageWebSetup ��ժҪ˵����
	/// </summary>
	[RunInstaller(true)]
	public class ynhnOilManageWebSetup : System.Configuration.Install.Installer
	{
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ynhnOilManageWebSetup()
		{
			// �õ����������������ġ�
			InitializeComponent();

			// TODO: �� InitializeComponent ���ú�����κγ�ʼ��
		}

		/// <summary> 
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public override void Install(IDictionary stateSaver)
		{
			base.Install (stateSaver);
			try
			{
				System.IO.FileInfo fileInfo = new System.IO.FileInfo(this.Context.Parameters["targetdir"]+@"\web.config");
				if (!fileInfo.Exists)
				{
					throw new InstallException("û���ҵ������ļ�");
				}
				
				System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();
				xmlDocument.Load(fileInfo.FullName);
				//System.Xml.XmlNode node;
				bool bFoundIt = false;
				foreach (System.Xml.XmlNode node in xmlDocument["configuration"]["appSettings"])
				{
					if (node.Name == "add")
					{
						if (node.Attributes.GetNamedItem("key").Value == "SetConnectionString")
						{
							node.Attributes.GetNamedItem("value").Value = 
								string.Format("server={0};uid ={1};pwd={2};database={3}",this.Context.Parameters["server"].ToString(),
								this.Context.Parameters["uid"].ToString(),this.Context.Parameters["pwd"].ToString(),this.Context.Parameters["database"].ToString());
							bFoundIt = true;
						}
					}
				}
				if (!bFoundIt)
				{
					throw new InstallException("web.Config �ļ�û�а��������ַ�������");
				}
				xmlDocument.Save(fileInfo.FullName);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
			}
		}



		#region �����������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
