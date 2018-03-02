using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;

namespace ynhnOilManage.Interface
{
	/// <summary>
	/// ynhnOilManageWebSetup 的摘要说明。
	/// </summary>
	[RunInstaller(true)]
	public class ynhnOilManageWebSetup : System.Configuration.Install.Installer
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ynhnOilManageWebSetup()
		{
			// 该调用是设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化
		}

		/// <summary> 
		/// 清理所有正在使用的资源。
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
					throw new InstallException("没有找到配置文件");
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
					throw new InstallException("web.Config 文件没有包含连接字符串设置");
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



		#region 组件设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
