#region 名字空间引用

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

using ynhnOilManage.BusinessRules.Report;

using ynhnOilManage.Common;
using ynhnOilManage.EntityObject.EntityBase;
using ynhnOilManage.EntityObject.EntityClass;


using ynhnOilManage.DataAccess.Common;
using ynhnOilManage.DataAccess.AccessClass;
using ynhnOilManage.DataAccess.QueryArgs;


#endregion

namespace ynhnOilManage.BusinessFacade.Report
{
	/// <summary>
	/// ReportQuery 的摘要说明。
	/// </summary>
	public class ReportQueryFacade
	{
		public ReportQueryFacade()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		//获取部门列表
		public static DataTable CommonQuery(string strSql)
		{
			DataTable dtRet = null;			
			try
			{
				ReportQuery report = new ReportQuery();
				dtRet = report.CommonQuery(strSql);
			}
			catch(SqlException sex)
			{
				LogAdapter.WriteDatabaseException(sex);	
				throw new Exception("数据库访问异常。");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("业务规则层异常。");
			}

			return dtRet;
			
		}

		public static EntityObjectBase CommonQuery(EntityObjectBase eob)
		{			
			try
			{				
				ReportQuery report = new ReportQuery();
				return report.CommonQuery(eob);
			}
			catch(SqlException sex)
			{
				LogAdapter.WriteDatabaseException(sex);	
				throw new Exception("数据库访问异常。");
			}
			catch (Exception ex)
			{
				LogAdapter.WriteFeaturesException(ex);	
				throw new Exception("业务规则层异常。");
			}

			//return null;
			
		}

		
		public static void UpdateBOM(BillOfMaterials bom,BusiLog bl)
		{
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();					
				SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
				try
				{					
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);

					Dept dept = new Dept();
					dept.cnvcDeptID = bom.cnvcDeptID;
					dept = EntityMapping.Get(dept,trans) as Dept;

					OilStorage os = new OilStorage();
					os.cnvcGoodsName = bom.cnvcGoodsName;
					os.cnvcGoodsType = bom.cnvcGoodsType;
					os.cnvcDeptID = bom.cnvcDeptID;
					os = EntityMapping.Get(os,trans) as OilStorage;
					if(null == os ) throw new BusinessException(bexType.noobject,"库存获取错误");

					Guid gd = Guid.NewGuid();

					//判断修改操作类型 改多为出库 改少为入库
					//专供油出库
					BillOfMaterials oldbom = new BillOfMaterials();
					oldbom.cnvcBillNo = bom.cnvcBillNo;
					oldbom.cnvcDeptID = bom.cnvcDeptID;
					oldbom = EntityMapping.Get(oldbom,trans) as BillOfMaterials;
					string strOperType = "";
					if(oldbom.cnnCount>bom.cnnCount)
						strOperType = InType.BOMModIn;
					else
						strOperType = InType.BOMModOut;

					//验收单
					//bom.cnvcInType = strOperType;
					

					if(bom.cnnCount != oldbom.cnnCount)
					{
						
						//库存日志
						OilStorageLog ol = new OilStorageLog(bom.ToTable());
						ol.cndOperDate=dtSysTime;
						ol.cnvcDeptName = dept.cnvcDeptName;										
						ol.cnvcOperType = strOperType;
						ol.cnnSerial = gd;
						ol.cnnLastCount = oldbom.cnnCount;//os.cnnStorageCount;
						ol.cnnInOutCount = oldbom.cnnCount-bom.cnnCount;//bom.cnnCount-oldbom.cnnCount;
						ol.cnnCurCount = bom.cnnCount;//os.cnnStorageCount + oldbom.cnnCount - bom.cnnCount;
						EntityMapping.Create(ol,trans);

						

						OilStorageLogHis olhis = new OilStorageLogHis(ol.ToTable());
						EntityMapping.Create(olhis,trans);

						oldbom.SynchronizeModifyValue(bom);
						oldbom.cnnCount=bom.cnnCount;
						oldbom.cnnReceiveCount=bom.cnnReceiveCount;
						oldbom.cnnSpecialFee = bom.cnnSpecialFee;
						EntityMapping.Update(oldbom,trans);

						//库存
						
						os.cnnStorageCount = os.cnnStorageCount+ol.cnnInOutCount;//ol.cnnCurCount;
						EntityMapping.Update(os,trans);
					}
					//日志
					bl.cnnSerial = gd;
					bl.cnvcComments = "领料单修改，出入库量："+(oldbom.cnnCount-bom.cnnCount);
					bl.cnvcOperType = OperType.OP203;
					bl.cndOperDate = dtSysTime;
					bl.cnvcSource = InSource.bs;
					EntityMapping.Create(bl,trans);

					trans.Commit();

				}
				catch(BusinessException bex)
				{
					trans.Rollback();
					LogAdapter.WriteBusinessException(bex);
					throw bex;
				}
				catch(SqlException sex)
				{
					trans.Rollback();
					LogAdapter.WriteDatabaseException(sex);
					throw sex;
				}
				catch(Exception ex)
				{
					trans.Rollback();
					LogAdapter.WriteFeaturesException(ex);
					throw ex;
				}
				finally
				{
					ConnectionPool.ReturnConnection(conn);
				}
			}
		}
		public static void UpdateBOV(BillOfValidate bov,BusiLog bl)
		{
			//ConnectionPool.IsCenter = false;
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();					
				SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
				try
				{					
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);

					Dept dept = new Dept();
					dept.cnvcDeptID = bov.cnvcDeptID;
					dept = EntityMapping.Get(dept,trans) as Dept;

					OilStorage os = new OilStorage();
					os.cnvcGoodsName = bov.cnvcGoodsName;
					os.cnvcGoodsType = bov.cnvcGoodsType;
					os.cnvcDeptID = bov.cnvcDeptID;
					os = EntityMapping.Get(os,trans) as OilStorage;
					if(null == os ) throw new BusinessException(bexType.noobject,"库存获取错误");

					Guid gd = Guid.NewGuid();

					//判断修改操作类型 改多为入库 改少为出库
					BillOfValidate oldbov = new BillOfValidate();
					oldbov.cnvcDeptID = bov.cnvcDeptID;
					oldbov.cnvcBillNo = bov.cnvcBillNo;
					oldbov = EntityMapping.Get(oldbov,trans) as BillOfValidate;
					string strOperType = "";
					if(oldbov.cnnValidateCount>bov.cnnValidateCount)
						strOperType = InType.BOVModOut;
					else
						strOperType = InType.BOVModIn;

					
					if(bov.cnnValidateCount != oldbov.cnnValidateCount)
					{
						//验收单
						
						//库存日志
						OilStorageLog ol = new OilStorageLog(bov.ToTable());
						ol.cnvcDeptName = dept.cnvcDeptName;	
						ol.cndOperDate=dtSysTime;			
						ol.cnvcOperType = strOperType;
						ol.cnnSerial = gd;
						ol.cnnLastCount = oldbov.cnnValidateCount;//os.cnnStorageCount;
						ol.cnnInOutCount = bov.cnnValidateCount-oldbov.cnnValidateCount;
						ol.cnnCurCount = bov.cnnValidateCount;//os.cnnStorageCount + bov.cnnValidateCount - oldbov.cnnValidateCount;
						EntityMapping.Create(ol,trans);


						OilStorageLogHis olhis = new OilStorageLogHis(ol.ToTable());
						EntityMapping.Create(olhis,trans);

						oldbov.SynchronizeModifyValue(bov);
						oldbov.cnnDistance = bov.cnnDistance;
						oldbov.cnnLose = bov.cnnLose;
						oldbov.cnnOriginalCount = bov.cnnOriginalCount;
						oldbov.cnnOuterLose = bov.cnnQuotaLose;
						oldbov.cnnQuotaLose = bov.cnnQuotaLose;
						oldbov.cnnTransportLose = bov.cnnTransportLose;
						oldbov.cnnValidateCount = bov.cnnValidateCount;
						oldbov.cnvcInType = strOperType;
						EntityMapping.Update(oldbov,trans);

						//库存
						os.cnnStorageCount = os.cnnStorageCount+ol.cnnInOutCount;//ol.cnnCurCount;
						EntityMapping.Update(os,trans);
					}
					//日志
					bl.cnnSerial = gd;
					bl.cnvcComments = "验收单修改，出入库量："+(bov.cnnValidateCount-oldbov.cnnValidateCount);
					bl.cnvcOperType = OperType.OP201;
					bl.cndOperDate = dtSysTime;
					bl.cnvcSource = InSource.cs;
					EntityMapping.Create(bl,trans);

					trans.Commit();

				}
				catch(BusinessException bex)
				{
					trans.Rollback();
					LogAdapter.WriteBusinessException(bex);
					throw bex;
				}
				catch(SqlException sex)
				{
					trans.Rollback();
					LogAdapter.WriteDatabaseException(sex);
					throw sex;
				}
				catch(Exception ex)
				{
					trans.Rollback();
					LogAdapter.WriteFeaturesException(ex);
					throw ex;
				}
				finally
				{
					ConnectionPool.ReturnConnection(conn);
				}
			}
		}

		public static void UpdateBOS(BillOfOutStorage bos,BusiLog bl)
		{
			//ConnectionPool.IsCenter = false;
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();					
				SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
				try
				{					
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);

					Dept dept = new Dept();
					dept.cnvcDeptID = bos.cnvcDeptID;
					dept = EntityMapping.Get(dept,trans) as Dept;

					OilStorage os = new OilStorage();
					os.cnvcGoodsName = bos.cnvcGoodsName;
					os.cnvcGoodsType = bos.cnvcGoodsType;
					os.cnvcDeptID = bos.cnvcDeptID;
					os = EntityMapping.Get(os,trans) as OilStorage;
					if(null == os ) throw new BusinessException(bexType.noobject,"库存获取错误");

					Guid gd = Guid.NewGuid();

					//判断修改操作类型 改多为入库 改少为出库
					BillOfOutStorage oldbos = new BillOfOutStorage();
					oldbos.cnvcBillNo = bos.cnvcBillNo;
					oldbos.cnvcDeptID = bos.cnvcDeptID;
					oldbos = EntityMapping.Get(oldbos,trans) as BillOfOutStorage;

					string strOperType = "";
					if(oldbos.cnnCount>bos.cnnCount)
						strOperType = OutType.BOSIn;
					else
						strOperType = OutType.BOSOut;

					//验收单
					
					if(bos.cnnCount != oldbos.cnnCount)
					{
						

						//库存日志
						OilStorageLog ol = new OilStorageLog(bos.ToTable());
						ol.cnvcDeptName = dept.cnvcDeptName;
						ol.cndOperDate=dtSysTime;	
						ol.cnvcOperType = strOperType;
						ol.cnnSerial = gd;
						ol.cnnLastCount = oldbos.cnnCount;//os.cnnStorageCount;
						ol.cnnInOutCount = oldbos.cnnCount-bos.cnnCount;//bos.cnnCount-oldbos.cnnCount;
						ol.cnnCurCount = bos.cnnCount;//os.cnnStorageCount + oldbos.cnnCount-bos.cnnCount ;
						EntityMapping.Create(ol,trans);

						OilStorageLogHis olhis = new OilStorageLogHis(ol.ToTable());
						EntityMapping.Create(olhis,trans);

						oldbos.SynchronizeModifyValue(bos);
						oldbos.cnnCount = bos.cnnCount;
						oldbos.cnnReceivableCount = bos.cnnReceivableCount;
						oldbos.cnvcOutType = strOperType;
						EntityMapping.Update(oldbos,trans);
						//库存
						os.cnnStorageCount = os.cnnStorageCount+ol.cnnInOutCount;//ol.cnnCurCount;
						EntityMapping.Update(os,trans);
					}
					//日志
					bl.cnnSerial = gd;
					bl.cnvcComments = "出库单修改，出入库量："+(oldbos.cnnCount-bos.cnnCount);//(bos.cnnCount-oldbos.cnnCount);
					bl.cnvcOperType = OperType.OP202;
					bl.cndOperDate = dtSysTime;
					bl.cnvcSource = InSource.cs;
					EntityMapping.Create(bl,trans);

					trans.Commit();

				}
				catch(BusinessException bex)
				{
					trans.Rollback();
					LogAdapter.WriteBusinessException(bex);
					throw bex;
				}
				catch(SqlException sex)
				{
					trans.Rollback();
					LogAdapter.WriteDatabaseException(sex);
					throw sex;
				}
				catch(Exception ex)
				{
					trans.Rollback();
					LogAdapter.WriteFeaturesException(ex);
					throw ex;
				}
				finally
				{
					ConnectionPool.ReturnConnection(conn);
				}
			}
		}

		//重算

		public static void AgainComp(string strBeginDate,string strEndDate,BusiLog bl)
		{
			//ConnectionPool.IsCenter = false;
			using (SqlConnection	conn  =  ConnectionPool.BorrowConnection())
			{
				//conn.Open();					
				SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
				try
				{					
					string strSysTime = SqlHelper.ExecuteScalar(trans, CommandType.Text, "select getdate()").ToString();
					DateTime dtSysTime = DateTime.Parse(strSysTime);

					string strsql = "select * from tbConsItem where CONVERT(varchar(10),cndconsdate,121) between '"+strBeginDate+"' and '"+strEndDate+"'";
					DataTable dtConsItem = SqlHelper.ExecuteDataTable(trans,CommandType.Text,strsql);
					if(dtConsItem.Rows.Count==0) throw new BusinessException("业务异常","没有需要更新的消费记录！");
					strsql = "select * from tbOilPrice where convert(varchar(10),cndpricedate,121) <= '"+strEndDate+"' order by cndPriceDate desc";
					DataTable dtPrice = SqlHelper.ExecuteDataTable(trans,CommandType.Text,strsql);
					if(dtPrice.Rows.Count==0) throw new BusinessException("业务异常","没有需要更新的油价！");
					foreach(DataRow dr in dtConsItem.Rows)
					{
						ConsItem ci = new ConsItem(dr);
						
						DataRow[] drPrices = dtPrice.Select("cnvcGoodsName='" + ci.cnvcGoodsName + "' and cnvcGoodsType='"+ci.cnvcGoodsType+"' and cnvcUnit='KG' and cnvcDeptName='"+ ci.cnvcDeptName+"' and cndpricedate<= '"+ci.cndConsDate.AddDays(1).ToString("yyyy-MM-dd")+"'","cndPriceDate desc");
						if(drPrices.Length==0) continue;
						OilPrice op = new OilPrice(drPrices[0]);
						decimal dFee = ci.cnnKGCount * op.cnnOilPrice;

						if(ci.cnnPrice != op.cnnOilPrice && ci.cnnFee != dFee)
						{
							ConsItemHis cih = new ConsItemHis(ci.ToTable());
							cih.cnnSerial = Guid.NewGuid();	
							cih.cndOperDate = dtSysTime;
							cih.cnvcOperName = bl.cnvcOperName;
							cih.cnvcComments = "|cnnSerial="+ci.cnnSerial.ToString();
							
							
							ci.cnnPrice=op.cnnOilPrice;
							ci.cnnFee = dFee;
							ci.cnvcComments = "老油价："+cih.cnnPrice.ToString()+"，新油价："+ci.cnnPrice.ToString();

							decimal dAddFee = cih.cnnFee-dFee;

							BusiLog busiLog = new BusiLog();
							busiLog.cndOperDate = dtSysTime;
							busiLog.cnnSerial = Guid.NewGuid();
							busiLog.cnvcOperName = bl.cnvcOperName;
							busiLog.cnvcComments = "油价补差充值："+ci.cnvcCardID+"|"+dAddFee.ToString();
							busiLog.cnvcDeptID = bl.cnvcDeptID;
							busiLog.cnvcDeptName = bl.cnvcDeptName;
							busiLog.cnvcOperType = "BS012";
							busiLog.cnvcSource = "网站";

//							FillFee fee = new FillFee();
//							fee.cndOperDate = dtSysTime;
//							fee.cnnFillFee = dAddFee;
//							fee.cnnSerial = busiLog.cnnSerial;							
//							fee.cnvcAcctID = ci.cnvcAcctID;							
//							fee.cnvcCompanyID = ci.cnvcCompanyID;
//							fee.cnvcCompanyName = ci.cnvcCompanyName;
//							fee.cnvcDeptID = ci.cnvcDeptID;
//							fee.cnvcDeptName = ci.cnvcDeptName;
//							fee.cnvcOperName = bl.cnvcOperName;

							SqlHelper.ExecuteNonQuery(trans,CommandType.Text,"update tbMebCompanyPrepay set cnnPrepayFee = cnnPrepayFee+"+dAddFee.ToString()+" where cnvcCompanyID='"+ci.cnvcCompanyID+"'");
							//EntityMapping.Create(fee,trans);
							EntityMapping.Create(busiLog,trans);

							EntityMapping.Create(cih,trans);
							EntityMapping.Update(ci,trans);

						}

					}
					//日志
					bl.cnnSerial = Guid.NewGuid();
					bl.cndOperDate = dtSysTime;
					EntityMapping.Create(bl,trans);

					trans.Commit();

				}
				catch(BusinessException bex)
				{
					trans.Rollback();
					LogAdapter.WriteBusinessException(bex);
					throw bex;
				}
				catch(SqlException sex)
				{
					trans.Rollback();
					LogAdapter.WriteDatabaseException(sex);
					throw sex;
				}
				catch(Exception ex)
				{
					trans.Rollback();
					LogAdapter.WriteFeaturesException(ex);
					throw ex;
				}
				finally
				{
					ConnectionPool.ReturnConnection(conn);
				}
			}
		}

	}
}
