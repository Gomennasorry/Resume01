//sing BASE.Dto;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ResumeAPI.Repositories
{
    public interface IOrderRepository
    {
        //Task<IEnumerable<SalesOrderModel>> Search(SearchOrderModel SearchTerm);
        //Task<IEnumerable<SalesOrderModel>> SearchDashBoard(SearchOrderModel SearchTerm);
        //Task<DashBoardOrderModel> SearchDashBoardByStore(SearchOrderModel SearchTerm);

        //Task<IEnumerable<MasterItemModel>> GetShippingProvider(MasterItemModel SearchTerm);

        //Task<WMSOrderModel> GetByDocRefNo(string DocRefNo);
        //Task<WMSOrderModel> GetById(string OrderID);
        //Task<WMSOrderModel> GetDeliveryOrderByDocRefNo(string DocRefNo, string PackTracking);
        //Task<IEnumerable<WMSOrderModel>> GetDeliveryOrderByOrderID(string OrderID, string PackTracking);

        //Task<ResponseModel> Assign(WMSOrderModel DataOrder);
        //Task<ResponseModel> ClearAssignCarrier(WMSOrderModel DataOrder);
        //Task<ResponseModel> ChangeAddress(WMSOrderModel DataOrder);
        //Task<WMSOrderModel> GetDocRefNoByOrderID(string OrderID);
        //Task<SCGEXOrder> GetOrderSCGEXById(string DocRefNo);
        //Task<IEnumerable<MasterItemModel>> GetDistrictByPostalCode(MasterItemModel PostalCodeData);

    }

    public class OrderRepository : DBContext, IOrderRepository
    {

        //public async Task<IEnumerable<SalesOrderModel>> Search(SearchOrderModel SearchTerm)
        //{
        //    List<SalesOrderModel> salesOrders = new List<SalesOrderModel>();

        //    string whereOrders = string.Empty;
        //    string whereCustomers = string.Empty;
        //    string innerJoinMarketPlace = string.Empty;
        //    string whereMarketPlace = string.Empty;
        //    string sqlSelect = @"SELECT CAST(orb.OrderID AS char(36)) AS OrderID, 
        //                                CASE orb.DeleteFlag WHEN 1 THEN 'Cancelled' ELSE orb.OrderStatus END OrderStatus
        //                                , orb.CustomerCode, orb.SourceSystem,  orb.OrderNumber,  orb.OrderType, 
        //                                 orb.OrderCreateDate,  orb.MarketPlace, orb.RequestedDate,
        //                                 orb.ShippingProvider, orb.DeleteFlag, 
								//		 itm.SalesQuantity, itm.UnitPrice
        //                                --, orb.*
        //                                --,CAST(itm.OrderItemID AS char(36)) AS OrderItemID
        //                                --,itm.*, lot.* --, CAST(wob.DocRefNo AS varchar(36)) AS DocRefNo
        //                        FROM OrderBase orb
        //                        {0}
        //                        {1}
        //                        {2}
        //                        INNER JOIN OrderItem itm ON itm.CustomerCode = orb.CustomerCode AND itm.SourceSystem = orb.SourceSystem
        //                                   AND itm.OrderNumber = orb.OrderNumber
        //                        LEFT OUTER JOIN OrderLots lot ON lot.OrderItemID = itm.OrderItemID 
        //                        WHERE (orb.OrderCreateDate between @CreatedDateFr AND @CreatedDateTo ) 
        //                        --WHERE orb.OrderCreateDate between @CreatedDateFr AND DATEADD(day, 1, @CreatedDateTo) 
        //                        {3}
        //                        ";

        //    if (!string.IsNullOrEmpty(SearchTerm.OrderNumbers))
        //    {
        //        List<string> orderNos = new List<string>();
        //        string[] lines = SearchTerm.OrderNumbers.Split(new string[] { "\r\n", "\r", "\n", ",", "\t", " " }, StringSplitOptions.None);
        //        foreach (var item in lines)
        //        {
        //            orderNos.Add(item.Replace(" ", ""));
        //        }
        //        SearchTerm.OrderNumbers = string.Join(",", orderNos);

        //        whereOrders = @" 
        //                        INNER JOIN (SELECT [value]  As OrderNumber
        //                        FROM STRING_SPLIT(@OrderNumbers, ',')
        //                        ) ors ON orb.OrderNumber = ors.OrderNumber  
        //                        ";
        //    }

        //    if (!string.IsNullOrEmpty(SearchTerm.CustomerCode))
        //    {
        //        List<string> customerS = new List<string>();
        //        string[] splitCC = SearchTerm.CustomerCode.Split(new string[] { "\r\n", "\r", "\n", ",", " " }, StringSplitOptions.None);
        //        foreach (var item in splitCC)
        //        {
        //            customerS.Add(item.Replace(" ", ""));
        //        }
        //        SearchTerm.CustomerCode = string.Join(",", customerS);

        //        whereCustomers = @" 
        //                        INNER JOIN (SELECT [value]  As CustomerCode
        //                        FROM STRING_SPLIT(@CustomerCode, ',')
        //                        ) ocu ON ocu.CustomerCode = orb.CustomerCode 
        //                        ";
        //    }
        //    if (!string.IsNullOrEmpty(SearchTerm.MarketPlace))
        //    {
        //        List<string> marketPlaces = new List<string>();
        //        string[] splitCC = SearchTerm.MarketPlace.Split(new string[] { "\r\n", "\r", "\n", ",", " " }, StringSplitOptions.None);
        //        foreach (var item in splitCC)
        //        {
        //            marketPlaces.Add(item.Replace(" ", ""));
        //        }
        //        foreach (var item in marketPlaces)
        //        {
        //            if (item == "LAZ")
        //            {
        //                marketPlaces.Add("LZ");
        //                break;
        //            }
                  
        //        }
        //        //foreach (var item in marketPlaces)
        //        //{
        //        //    if (item == "OTH")
        //        //    {
        //        //        marketPlaces.Add("OTHER");
        //        //        break;
        //        //    }
        //        //}
        //        marketPlaces = marketPlaces.Distinct().ToList();
        //        SearchTerm.MarketPlace = string.Join(",", marketPlaces);
        //        innerJoinMarketPlace = @" 
        //                        INNER JOIN (SELECT [value]  As MarketPlace
        //                        --FROM STRING_SPLIT(@MarketPlace + ',DZY, OTHER, SCG, Stock, OTH, VG', ',')
        //                        FROM STRING_SPLIT(@MarketPlace, ',')
        //                        ) mkp ON mkp.MarketPlace = orb.MarketPlace 

        //                        ";

        //        whereMarketPlace = @"
        //                                AND EXISTS (
        //                                    SELECT 1
        //                                    FROM CustomersMarketPlaceUsers cmp
        //                                    WHERE cmp.MarketPlace = orb.MarketPlace
        //                                      AND cmp.CustomerCode = orb.CustomerCode
        //                                      AND cmp.UserId = @UserId 
        //                                );
        //                            ";
                
                
        //        //whereMarketPlace = @" 
        //        //                INNER JOIN (SELECT [value]  As MarketPlace
        //        //                --FROM STRING_SPLIT(@MarketPlace + ',DZY, OTHER, SCG, Stock, OTH, VG', ',')
        //        //                FROM STRING_SPLIT(@MarketPlace, ',')
        //        //                ) mkp ON mkp.MarketPlace = orb.MarketPlace 

        //        //                --User มาจอยด้วย 
        //        //                INNER JOIN CustomersMarketPlaceUsers cmp ON cmp.CustomerCode = orb.CustomerCode 
        //        //                 AND cmp.MarketPlace = mkp.MarketPlace
        //        //                AND cmp.UserId = @UserId 
        //        //                ";
        //    }
        //    sqlSelect = string.Format(sqlSelect, whereOrders, whereCustomers, innerJoinMarketPlace, whereMarketPlace);

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, connection))
        //            {
        //                adapter.SelectCommand.Parameters.AddWithValue("@CustomerCode", SearchTerm.CustomerCode ?? "");
        //                adapter.SelectCommand.Parameters.AddWithValue("@OrderNumbers", SearchTerm.OrderNumbers ?? "");
        //                adapter.SelectCommand.Parameters.AddWithValue("@SourceSystem", SearchTerm.SourceSystem ?? "");
        //                adapter.SelectCommand.Parameters.AddWithValue("@CreatedDateFr", SearchTerm.CreatedDateFr ?? "");
        //                adapter.SelectCommand.Parameters.AddWithValue("@CreatedDateTo", SearchTerm.CreatedDateTo + " 23:59:59.993" ?? "");
        //                adapter.SelectCommand.Parameters.AddWithValue("@MarketPlace", SearchTerm.MarketPlace);
        //                adapter.SelectCommand.Parameters.AddWithValue("@UserId", SearchTerm.UserId);

        //                //adapter.SelectCommand.Parameters.AddWithValue("@CreatedDateTo", SearchTerm.CreatedDateTo ?? "");

        //                DataTable dtResult = new DataTable();
        //                adapter.Fill(dtResult);

        //                List<SalesOrderModel> orderList = AsEnumerable<SalesOrderModel>(dtResult);
        //                List<OrderItemModel> itemList = AsEnumerable<OrderItemModel>(dtResult);
        //                //List<ItemLotModel> lotList = AsEnumerable<ItemLotModel>(dtResult);
        //                salesOrders = orderList.GroupBy(s => s.OrderNumber).Select(g => g.First()).ToList();

        //                //Slow Because  Match Order And Item    , index page use Item Price+Quantity
        //                //mapping sub model
        //                salesOrders.ForEach(or =>
        //                {
        //                    or.Items = itemList.Where(it => it.OrderNumber == or.OrderNumber)?.ToList();

        //                    //or.Items.ForEach(it =>
        //                    //{
        //                    //    it.Lots = lotList.Where(lt => lt.OrderItemID == it.OrderItemID)?.ToList();
        //                    //});
        //                });
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            this.response.Message = ex.Message;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return await Task.FromResult(salesOrders);
        //}
        //public async Task<SCGEXOrder> GetOrderSCGEXById(string DocRefNo)
        //{
        //    SCGEXOrder scgExdata = new SCGEXOrder();

        //    string whereOrders = string.Empty;
        //    string sqlSelect = @"SELECT orb.Ownercode AS CustomerCode, mc.ShipperCode, mc.CustomerName AS ShipperName , mc.PhoneNumber AS ShipperTel, 
        //                                mc.DistrictName AS ShipperDistrict, mc.ProvinceName AS ShipperProvince , mc.AddressNo AS ShipperAddress, 
        //                                mc.PostalCode AS ShipperZipcode, 
        //                                ISNULL(odb.ShiptoAddress, orb.ShiptoAddress) AS DeliveryAddress, 
        //                                ISNULL(odb.ShiptoPostCode, orb.ShiptoPostalCode) AS Zipcode, 
        //                                orb.ShiptoLongName  AS ContactName, 
        //                                ISNULL(odb.ContactPhone, '-') AS Tel, 
        //                                ISNULL(odb.ShiptoDistrict, orb.ShiptoCity) AS District,
        //                                ISNULL(odb.ShiptoProvince, orb.ShiptoStateOrProvince) AS Province, orb.SONumber AS OrderCode, FORMAT(orb.CreateDate, 'yyyy-MM-dd') AS OrderDate, 
        //                                mc.SCGXPassword, mc.SCGXUsername,
        //                                FORMAT(odb.RequestedDate, 'yyyy-MM-dd')  AS DeliveryDate, pac.CountItem AS TotalBoxs
        //                         FROM WMSOrderBase orb
								// INNER JOIN Customer mc ON orb.Ownercode = mc.CustomerCode
        //                        LEFT OUTER JOIN OrderBase odb ON odb.OrderID = orb.OrderID
								// OUTER APPLY
								// (
								//    SELECT COUNT(pif.PackNumber) AS CountItem
								//    FROM PackingInfo pif
								//    WHERE pif.OrderID = CAST(orb.DocRefNo AS varchar(36))
								// ) pac
        //                         WHERE orb.DocRefNo = @DocRefNo ";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, connection))
        //            {
        //                adapter.SelectCommand.Parameters.AddWithValue("@DocRefNo", DocRefNo);
        //                DataTable dtResult = new DataTable();
        //                adapter.Fill(dtResult);

        //                scgExdata = AsSingle<SCGEXOrder>(dtResult);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            string Message = ex.Message;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return await Task.FromResult(scgExdata);
        //}

        //public async Task<IEnumerable<MasterItemModel>> GetShippingProvider(MasterItemModel SearchTerm)
        //{
        //    ResponseModel response = new ResponseModel();
        //    List<MasterItemModel> items = new List<MasterItemModel>();

        //    string sqlSelect = @"SELECT ProviderCode AS ItemCode, ProviderName AS ItemText
        //                         FROM ShippingProvider  ";

        //    if (SearchTerm.ActiveStatus != "A")
        //    {
        //        sqlSelect += " WHERE IsActive  = @IsActive ";
        //        SearchTerm.IsActive = SearchTerm.ActiveStatus == "F" ? false : true;
        //    }
        //    sqlSelect += " ORDER BY ItemText DESC";

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, connection))
        //            {
        //                //adapter.SelectCommand.Parameters.AddWithValue("@CarrierCode", SearchTerm.ItemCode ?? "");
        //                adapter.SelectCommand.Parameters.AddWithValue("@IsActive", SearchTerm.IsActive);

        //                DataTable dtResult = new DataTable();
        //                adapter.Fill(dtResult);

        //                items = AsEnumerable<MasterItemModel>(dtResult);
        //            }
        //            connection.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message = ex.Message;
        //    }
        //    return await Task.FromResult(items);
        //}

        //public async Task<WMSOrderModel> GetByDocRefNo(string DocRefNo)
        //{
        //    WMSOrderModel salesOrder = new WMSOrderModel();
        //    List<MasterItemModel> districtList = new List<MasterItemModel>();

        //    string sqlSelect = @"SELECT CAST(orb.OrderID AS char(36)) AS OrderID, orb.Ownercode,
        //                                orb.SourceSystem, orb.SOnumber, CAST(orb.DocRefNo AS varchar(36)) AS DocRefNo, orb.DCCode,
        //                                orb.ETA, orb.Remark, orb.InvoiceNo, orb.ShiptoCode, orb.ShiptoLongName, 
								//	    ISNULL(odb.ShiptoAddress, orb.ShiptoAddress) AS ShiptoAddress, 
								//	    ISNULL(odb.ShiptoPostCode, orb.ShiptoPostalCode) AS ShiptoPostalCode,
								//	    ISNULL(odb.ShiptoDistrict, orb.ShiptoCity) AS ShiptoCity,
        //                                ISNULL(odb.ShiptoProvince, orb.ShiptoStateOrProvince) AS ShiptoStateOrProvince, 
								//	    ISNULL(odb.ContactPhone, orb.ShiptoPhoneNo) AS ShiptoPhoneNo, orb.OrderTypeName,
								//	    orb.DeleteFlag, orb.CreateDate, orb.OrderDate,
								//	    orb.OrderBy, odb.RequestedDate AS RequestDate, orb.MPSource, orb.MPSourceOrderNo, orb.TrackingNo,
								//	    orb.FullTaxInvFlag, orb.PostingDate, orb.DocumentDate,
        //                                orb.Reference1, orb.Reference2, orb.Reference3, orb.Reference4, orb.Reference5,
								//	    orb.ShippingLabelPrintLink, CAST(orb.RefNO AS char(36)) AS RefNO, orb.ControlPackID, orb.OrderStatus, orb.CreatedUser,
        //                                orb.ShippingProvider, orb.ProviderCode, orb.ManifestNo,
								//	    CAST(itm.DocRefNo AS varchar(36)) AS OrderItemDocRefNo,
        //                                ISNULL(pit.PackQuantity,itm.SaleUnitQty) AS SaleUnitQty,
        //                                ISNULL(pif.TrackingNo, tkl.TrackingNo ) AS PackTracking,
        //                                pif.ShippingMark, pif.BoxHeight, pif.BoxWidth, pif.BoxLenght, pif.BoxSizeUnit, tki.TotalVolume,
        //                                itm.*, lot.*, ISNULL(odb.ShopID, cus.ShopID) AS ShopID,
								//	    ISNULL(pro.SelectCarrier,'') AS SelectCarrier ,ISNULL(pro.FixProvider,'') AS FixProvider,
        //                                ISNULL(shp.ProviderName, orb.ShippingProvider) AS ProviderName, ctm.CustomerName, ISNULL(ctm.LogoImage,'') AS CustomerLogoImage,
        //                                ctm.CustomerRef, ctm.ShipperCode, ctm.SCGXUsername, ctm.SCGXPassword, --ctm.SCGLToken, ctm.SCGLTokenDelete,
        //                                pac.CountItem AS TotalBoxs, pit.PackNumber, odb.OriginalOrder, orb.Documents, pif.NetWeight, pif.GrossWeight, pif.PackCode, pif.PackName
        //                        FROM WMSOrderBase orb
        //                        INNER JOIN WMSOrderItem itm ON itm.DocRefNo = orb.DocRefNo --AND itm.DeleteDocFlag = 0
        //                        LEFT OUTER JOIN WMSOrderLots lot ON lot.DocRefNo = itm.DocRefNo AND lot.[LineNo] = itm.[LineNo]
        //                        LEFT OUTER JOIN CustomerShop cus ON cus.CustomerCode = orb.Ownercode AND cus.MarketPlace = orb.MPSource
        //                        LEFT OUTER JOIN Customer ctm ON ctm.CustomerCode = orb.Ownercode
        //                        LEFT OUTER JOIN ProviderCondition pro ON pro.ProviderCode = orb.ShippingProvider
        //                        LEFT OUTER JOIN ShippingProvider shp ON shp.ProviderCode = ISNULL(orb.ProviderCode,orb.ShippingProvider) 
        //                        LEFT OUTER JOIN PackingItem pit ON pit.OrderID = itm.DocRefNo AND pit.ItemNumber = itm.[LineNo]
        //                        LEFT OUTER JOIN PackingInfo pif ON pif.OrderID = itm.DocRefNo AND pit.PackNumber = pif.PackNumber
        //                        LEFT OUTER JOIN OrderBase odb ON odb.OrderID = orb.OrderID
        //                        LEFT OUTER JOIN TrackingItem tki ON tki.OrderId = orb.DocRefNo AND tki.OrderNumber = orb.SONumber AND tki.ItemNumber = itm.[LineNo]
        //                        LEFT OUTER JOIN TrackingLabel tkl ON tkl.OrderNumber = orb.SONumber AND tkl.CustomerCode = orb.Ownercode 
        //                                        AND tkl.SourceSystem = orb.SourceSystem AND ISNULL(pif.TrackingNo,'') = '' AND tkl.OrderNumber <> tkl.TrackingNo
        //                                        AND ISNULL(tkl.TrackingNo,'') <> '' AND (CASE WHEN orb.TrackingNo <> orb.SONumber THEN orb.TrackingNo ELSE tkl.TrackingNo END)  = tkl.TrackingNo
								//OUTER APPLY
								// (
								//  SELECT COUNT(pif.PackNumber) AS CountItem
								//  FROM PackingInfo pif
								//  WHERE pif.OrderID = CAST(orb.DocRefNo AS varchar(36))
								// ) pac
        //                        WHERE orb.DocRefNo = @DocRefNo --AND orb.DeleteFlag = 0
        //                        Order By orb.DeleteFlag ASC, orb.CreateDate DESC ";

        //    string sqlDistrict = @"SELECT PostalCode AS ItemCode, DistrictName AS ItemText FROM MstDistrict WHERE PostalCode = @PostalCode";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, connection))
        //            {
        //                adapter.SelectCommand.Parameters.AddWithValue("@DocRefNo", DocRefNo);
        //                DataTable dtResult = new DataTable();
        //                adapter.Fill(dtResult);

        //                salesOrder = AsSingle<WMSOrderModel>(dtResult);
        //                List<WMSOrderItem> itemList = AsEnumerable<WMSOrderItem>(dtResult);
        //                List<WMSItemLot> lotList = AsEnumerable<WMSItemLot>(dtResult);
        //                lotList = lotList.DistinctBy(x => new { x.DocRefNo, x.LineNo, x.LotNo, x.Serial }).ToList();

        //                salesOrder.Items = itemList.GroupBy(s => new { s.LineNo, s.PackNumber }).Select(g => g.First()).ToList();

        //                //mapping sub model
        //                salesOrder.Items.ForEach(it =>
        //                {
        //                    it.Lots = lotList.Where(lt => lt.DocRefNo == it.DocRefNo && lt.LineNo == it.LineNo)?.ToList();
        //                });

        //                adapter.SelectCommand.CommandText = sqlDistrict;
        //                adapter.SelectCommand.Parameters.AddWithValue("@PostalCode", salesOrder.ShiptoPostalCode);

        //                DataTable dtDistrict = new DataTable();
        //                adapter.Fill(dtDistrict);
        //                districtList = AsEnumerable<MasterItemModel>(dtDistrict);
        //                districtList.ForEach(it =>
        //                {
        //                    //it.Lots = lotList.Where(lt => lt.DocRefNo == it.DocRefNo && lt.LineNo == it.LineNo)?.ToList();
        //                    if (it.ItemText == salesOrder.ShiptoCity)
        //                    {
        //                        salesOrder.IsDistrictTrue = true;
        //                    }
        //                });
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            this.response.Message = ex.Message;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return await Task.FromResult(salesOrder);
        //}

        //public async Task<WMSOrderModel> GetById(string OrderID)
        //{
        //    WMSOrderModel salesOrder = new WMSOrderModel();
        //    List<MasterItemModel> districtList = new List<MasterItemModel>();

        //    string sqlSelect = @"SELECT CAST(orb.OrderID AS char(36)) AS OrderID, orb.Ownercode,
        //                                orb.SourceSystem, orb.SOnumber, CAST(orb.DocRefNo AS varchar(36)) AS DocRefNo, orb.DCCode,
        //                                orb.ETA, orb.Remark, orb.InvoiceNo, orb.ShiptoCode, orb.ShiptoLongName, 
								//	    ISNULL(odb.ShiptoAddress, orb.ShiptoAddress) AS ShiptoAddress, 
								//	    ISNULL(odb.ShiptoPostCode, orb.ShiptoPostalCode) AS ShiptoPostalCode,
								//	    ISNULL(odb.ShiptoDistrict, orb.ShiptoCity) AS ShiptoCity,
        //                                ISNULL(odb.ShiptoProvince, orb.ShiptoStateOrProvince) AS ShiptoStateOrProvince, 
								//	    ISNULL(odb.ContactPhone, orb.ShiptoPhoneNo) AS ShiptoPhoneNo, orb.OrderTypeName,
								//	    orb.DeleteFlag, orb.CreateDate, orb.OrderDate,
								//	    orb.OrderBy, odb.RequestedDate AS RequestDate, orb.MPSource, orb.MPSourceOrderNo, orb.TrackingNo,
								//	    orb.FullTaxInvFlag, orb.PostingDate, orb.DocumentDate,
        //                                orb.Reference1, orb.Reference2, orb.Reference3, orb.Reference4, orb.Reference5,
								//	    orb.ShippingLabelPrintLink, CAST(orb.RefNO AS char(36)) AS RefNO, orb.ControlPackID, orb.OrderStatus, orb.CreatedUser,
        //                                orb.ShippingProvider, orb.ProviderCode, orb.ManifestNo,
								//	    CAST(itm.DocRefNo AS varchar(36)) AS OrderItemDocRefNo,
        //                                ISNULL(pit.PackQuantity,itm.SaleUnitQty) AS SaleUnitQty,
        //                                ISNULL(pif.TrackingNo, tkl.TrackingNo ) AS PackTracking,
        //                                pif.ShippingMark, pif.BoxHeight, pif.BoxWidth, pif.BoxLenght, pif.BoxSizeUnit, tki.TotalVolume,
        //                                itm.*, lot.*, ISNULL(odb.ShopID, cus.ShopID) AS ShopID,
								//	    ISNULL(pro.SelectCarrier,'') AS SelectCarrier ,ISNULL(pro.FixProvider,'') AS FixProvider,
        //                                ISNULL(shp.ProviderName, orb.ShippingProvider) AS ProviderName, ctm.CustomerName, ISNULL(ctm.LogoImage,'') AS CustomerLogoImage,
        //                                ctm.CustomerRef, ctm.ShipperCode, ctm.SCGXUsername, ctm.SCGXPassword, --ctm.SCGLToken, ctm.SCGLTokenDelete,
        //                                pac.CountItem AS TotalBoxs, pit.PackNumber, odb.OriginalOrder, orb.Documents, pif.NetWeight, pif.GrossWeight, pif.PackCode, pif.PackName
        //                        FROM WMSOrderBase orb
        //                        INNER JOIN WMSOrderItem itm ON itm.DocRefNo = orb.DocRefNo --AND itm.DeleteDocFlag = 0
        //                        LEFT OUTER JOIN WMSOrderLots lot ON lot.DocRefNo = itm.DocRefNo AND lot.[LineNo] = itm.[LineNo]
        //                        LEFT OUTER JOIN CustomerShop cus ON cus.CustomerCode = orb.Ownercode AND cus.MarketPlace = orb.MPSource
        //                        LEFT OUTER JOIN Customer ctm ON ctm.CustomerCode = orb.Ownercode
        //                        LEFT OUTER JOIN ProviderCondition pro ON pro.ProviderCode = orb.ShippingProvider
        //                        LEFT OUTER JOIN ShippingProvider shp ON shp.ProviderCode = ISNULL(orb.ProviderCode,orb.ShippingProvider) 
        //                        LEFT OUTER JOIN PackingItem pit ON pit.OrderID = itm.DocRefNo AND pit.ItemNumber = itm.[LineNo]
        //                        LEFT OUTER JOIN PackingInfo pif ON pif.OrderID = itm.DocRefNo AND pit.PackNumber = pif.PackNumber
        //                        LEFT OUTER JOIN OrderBase odb ON odb.OrderID = orb.OrderID
        //                        LEFT OUTER JOIN TrackingItem tki ON tki.OrderId = orb.DocRefNo AND tki.OrderNumber = orb.SONumber AND tki.ItemNumber = itm.[LineNo]
        //                        LEFT OUTER JOIN TrackingLabel tkl ON tkl.OrderNumber = orb.SONumber AND tkl.CustomerCode = orb.Ownercode 
        //                                        AND tkl.SourceSystem = orb.SourceSystem AND ISNULL(pif.TrackingNo,'') = '' AND tkl.OrderNumber <> tkl.TrackingNo
        //                                        AND ISNULL(tkl.TrackingNo,'') <> '' AND (CASE WHEN orb.TrackingNo <> orb.SONumber THEN orb.TrackingNo ELSE tkl.TrackingNo END)  = tkl.TrackingNo
								//OUTER APPLY
								// (
								//  SELECT COUNT(pif.PackNumber) AS CountItem
								//  FROM PackingInfo pif
								//  WHERE pif.OrderID = CAST(orb.DocRefNo AS varchar(36))
								// ) pac
        //                        WHERE orb.OrderID = @OrderID --AND orb.DeleteFlag = 0
        //                        Order By orb.DeleteFlag ASC, orb.CreateDate DESC ";

        //    string sqlDistrict = @"SELECT PostalCode AS ItemCode, DistrictName AS ItemText FROM MstDistrict WHERE PostalCode = @PostalCode";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, connection))
        //            {
        //                adapter.SelectCommand.Parameters.AddWithValue("@OrderID", OrderID);
        //                //adapter.SelectCommand.Parameters.AddWithValue("@PostalCode", OrderID);
        //                DataTable dtResult = new DataTable();
        //                adapter.Fill(dtResult);

        //                salesOrder = AsSingle<WMSOrderModel>(dtResult);
        //                List<WMSOrderItem> itemList = AsEnumerable<WMSOrderItem>(dtResult);
        //                List<WMSItemLot> lotList = AsEnumerable<WMSItemLot>(dtResult);
        //                lotList = lotList.DistinctBy(x => new { x.DocRefNo, x.LineNo, x.LotNo, x.Serial }).ToList();

        //                salesOrder.Items = itemList.GroupBy(s => new { s.LineNo, s.PackNumber }).Select(g => g.First()).ToList();

        //                //mapping sub model
        //                salesOrder.Items.ForEach(it =>
        //                {
        //                    it.Lots = lotList.Where(lt => lt.DocRefNo == it.DocRefNo && lt.LineNo == it.LineNo)?.ToList();
        //                });

        //                adapter.SelectCommand.CommandText = sqlDistrict;
        //                adapter.SelectCommand.Parameters.AddWithValue("@PostalCode", salesOrder.ShiptoPostalCode);

        //                DataTable dtDistrict = new DataTable();
        //                adapter.Fill(dtDistrict);
        //                districtList = AsEnumerable<MasterItemModel>(dtDistrict);
        //                districtList.ForEach(it =>
        //                {
        //                    //it.Lots = lotList.Where(lt => lt.DocRefNo == it.DocRefNo && lt.LineNo == it.LineNo)?.ToList();
        //                    if (it.ItemText == salesOrder.ShiptoCity)
        //                    {
        //                        salesOrder.IsDistrictTrue = true;
        //                    }
        //                });
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            this.response.Message = ex.Message;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return await Task.FromResult(salesOrder);
        //}

        //public async Task<WMSOrderModel> GetDocRefNoByOrderID(string OrderID)
        //{
        //    WMSOrderModel salesOrder = new WMSOrderModel();

        //    string sqlSelect = @"SELECT DISTINCT CAST(DocRefNo AS varchar(36)) AS DocRefNo, * 
        //                         From WMSOrderBase
        //                         WHERE OrderID = @OrderID --AND DeleteFlag = 0";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, connection))
        //            {
        //                adapter.SelectCommand.Parameters.AddWithValue("@OrderID", OrderID);
        //                DataTable dtResult = new DataTable();
        //                adapter.Fill(dtResult);

        //                salesOrder = AsSingle<WMSOrderModel>(dtResult);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            string Message = ex.Message;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return await Task.FromResult(salesOrder);
        //}
        ////only Print Delivery Order WMS
        //public async Task<WMSOrderModel> GetDeliveryOrderByDocRefNo(string DocRefNo, string PackTracking)
        //{
        //    WMSOrderModel salesOrder = new WMSOrderModel();

        //    string sqlSelect = @"SELECT CAST(orb.OrderID AS char(36)) AS OrderID, orb.Ownercode, orb.SOnumber, CAST(orb.DocRefNo AS varchar(36)) AS DocRefNo,
        //                                orb.Remark, orb.InvoiceNo, 
        //                                orb.ShiptoCode,
        //                                orb.ShiptoLongName, 
        //                                odb.ShiptoAddress AS ShiptoAddress, 
        //                                odb.ShiptoPostCode AS ShiptoPostalCode,
        //                                odb.ShiptoDistrict AS ShiptoCity,
        //                                odb.ShiptoProvince AS ShiptoStateOrProvince, 
        //                                odb.ContactPhone AS ShiptoPhoneNo,
        //                                odb.ShiptoArea AS ShiptoArea,
        //                                orb.OrderTypeName,
								//	    orb.DeleteFlag, orb.CreateDate, orb.OrderDate,
								//	    orb.OrderBy, odb.RequestedDate AS RequestDate, orb.MPSource, orb.MPSourceOrderNo, orb.TrackingNo,
								//	    orb.FullTaxInvFlag, orb.PostingDate, orb.DocumentDate,
        //                                orb.Reference1, orb.Reference2, orb.Reference3, orb.Reference4, orb.Reference5,
								//	    orb.ShippingLabelPrintLink, CAST(orb.RefNO AS char(36)) AS RefNO, orb.ControlPackID, orb.OrderStatus,
        //                                orb.CreatedUser, ISNULL(orb.ProviderCode,orb.ShippingProvider) AS ShippingProvider,
								//	    CAST(itm.DocRefNo AS varchar(36)) AS OrderItemDocRefNo,
        //                                --ISNULL( pal.Quantity ,ISNULL(pit.PackQuantity,itm.SaleUnitQty)) AS SaleUnitQty,
        //                                ISNULL(pit.PackQuantity,itm.SaleUnitQty) AS SaleUnitQty,
        //                                ISNULL(pif.TrackingNo, tkla.TrackingNo ) AS PackTracking,
        //                                pif.ShippingMark,
								//	    --ISNULL(pal.SerialNo, tkl.SerialNo) AS Serial,
        //                                itm.*, lot.*, ISNULL(odb.ShopID, csh.ShopID) AS ShopID,
								//	    cus.CustomerName, cus.AddressNo + ' ' + cus.DistrictName + ' ' + cus.ProvinceName + ' ' + cus.PostalCode AS CustomerAddress,
								//	    cus.PhoneNumber AS CustomerPhoneNumber, cus.LogoImage AS CustomerLogoImage,
								//	    odb.ShiptoName, odb.ContactPhone, odb.ShiptoAddress + ' ' + odb.ShiptoDistrict + ' ' + odb.ShiptoProvince + ' ' + odb.ShiptoPostCode AS OrderBaseAddress,
								//	    odb.RequestedDate, odb.OrderCreateDate, odb.BilltoCode, odb.OrderNumber, odb.OriginalOrder, odb.PONumber, orb.SourceSystem
        //                                , pif.NetWeight, pif.GrossWeight, shp.ProviderName, pit.PackNumber
        //                        FROM WMSOrderBase orb
        //                        INNER JOIN WMSOrderItem itm ON itm.DocRefNo = orb.DocRefNo AND itm.DeleteDocFlag = 0
        //                        LEFT OUTER JOIN WMSOrderLots lot ON lot.DocRefNo = itm.DocRefNo AND lot.[LineNo] = itm.[LineNo]
        //                        LEFT OUTER JOIN CustomerShop csh ON csh.CustomerCode = orb.Ownercode AND csh.MarketPlace = orb.MPSource
								//LEFT OUTER JOIN Customer cus ON cus.CustomerCode = orb.Ownercode
								//LEFT OUTER JOIN OrderBase odb ON odb.OrderID = orb.OrderID
								//LEFT OUTER JOIN PackingItem pit ON pit.OrderID = itm.DocRefNo AND pit.ItemNumber = itm.[LineNo]
								//LEFT OUTER JOIN PackingInfo pif ON pif.OrderID = itm.DocRefNo AND pit.PackNumber = pif.PackNumber
								//--LEFT OUTER JOIN PackingLots pal ON pal.OrderID = orb.DocRefNo AND pal.ItemNumber = itm.[LineNo] AND 
								//--pal.PackNumber = pit.PackNumber
        //                        --LEFT OUTER JOIN TrackingLots tkl ON tkl.OrderID = orb.DocRefNo AND tkl.ItemNumber = itm.[LineNo]
        //                        LEFT OUTER JOIN TrackingLabel tkla ON tkla.OrderNumber = orb.SONumber AND tkla.CustomerCode = orb.Ownercode 
        //                                        AND tkla.SourceSystem = orb.SourceSystem AND ISNULL(pif.TrackingNo,'') = '' AND tkla.OrderNumber <> tkla.TrackingNo
        //                                        AND ISNULL(tkla.TrackingNo,'') <> '' AND (CASE WHEN orb.TrackingNo <> orb.SONumber THEN orb.TrackingNo ELSE tkla.TrackingNo END)  = tkla.TrackingNo
        //                        LEFT OUTER JOIN ShippingProvider shp ON shp.ProviderCode = orb.ProviderCode
        //                        WHERE orb.DocRefNo = @DocRefNo AND orb.DeleteFlag = '0'  ";

        //    if (!string.IsNullOrEmpty(PackTracking) && PackTracking != "-")
        //        sqlSelect += " AND ISNULL(pif.TrackingNo, tkla.TrackingNo ) = @PackTracking";

        //    string sqlSelectPackingLots = @" SELECT pal.*,pal.OrderID AS DocRefNo, pal.ItemNumber AS [LineNo], pal.SerialNo AS Serial, pal.LotNumber AS LotNo, pal.Quantity AS Qty   FROM PackingLots pal WHERE pal.OrderID = @DocRefNo   ";


        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, connection))
        //            {
        //                adapter.SelectCommand.Parameters.AddWithValue("@DocRefNo", DocRefNo);
        //                adapter.SelectCommand.Parameters.AddWithValue("@PackTracking", PackTracking);
        //                DataTable dtResult = new DataTable();
        //                adapter.Fill(dtResult);

        //                salesOrder = AsSingle<WMSOrderModel>(dtResult);
        //                salesOrder.Items = AsEnumerable<WMSOrderItem>(dtResult);

        //                adapter.SelectCommand.CommandText = sqlSelectPackingLots;
        //                adapter.SelectCommand.Parameters.Clear();
        //                adapter.SelectCommand.Parameters.AddWithValue("@DocRefNo", DocRefNo);
        //                DataTable dtPackingLot = new DataTable();
        //                adapter.Fill(dtPackingLot);
        //                List<WMSItemLot> lotList = AsEnumerable<WMSItemLot>(dtPackingLot);


        //                lotList = lotList.DistinctBy(x => new { x.DocRefNo, x.LineNo, x.LotNo, x.Serial }).ToList();

        //                //mapping sub model

        //                salesOrder.Items.ForEach(it =>
        //                {

        //                    it.Lots = lotList.Where(lt => lt.DocRefNo == it.DocRefNo && lt.LineNo == it.LineNo & lt.PackNumber == it.PackNumber)?.ToList();
        //                    if (it.Lots.Count() > 0)
        //                    {
        //                        it.SaleUnitQty = it.Lots[0].Qty;
        //                    }
        //                    //    it.Lots = lotList.Where(lt => lt.DocRefNo == it.DocRefNo && lt.LineNo == it.LineNo)?.ToList();
        //                });
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            this.response.Message = ex.Message;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return await Task.FromResult(salesOrder);
        //}

        ////only Print Delivery Order ID include Multi Tracking(WMS)
        //public async Task<IEnumerable<WMSOrderModel>> GetDeliveryOrderByOrderID(string OrderID, string PackTracking)
        //{
        //    List<WMSOrderModel> salesOrders = new List<WMSOrderModel>();
        //    //--ISNULL(pal.SerialNo, tkl.SerialNo) AS Serial,  --TrackingLot , PackingLot ต้องมี Lot , Serial เหมือนกัเนเพราะชะนั้นจะไม่หยิบมา แล้วถ้าไม่เหมือนกันแล้วหยิบมา = ดาต้าเบสล่ม
        //    string sqlSelect = @"SELECT CAST(orb.OrderID AS char(36)) AS OrderID, orb.Ownercode, orb.SOnumber, CAST(orb.DocRefNo AS varchar(36)) AS DocRefNo,
        //                                orb.Remark, orb.InvoiceNo, 
        //                                orb.ShiptoCode,
        //                                orb.ShiptoLongName, 
        //                                odb.ShiptoAddress AS ShiptoAddress, 
        //                                odb.ShiptoPostCode AS ShiptoPostalCode,
        //                                odb.ShiptoDistrict AS ShiptoCity,
        //                                odb.ShiptoProvince AS ShiptoStateOrProvince, 
        //                                odb.ContactPhone AS ShiptoPhoneNo,
        //                                odb.ShiptoArea AS ShiptoArea,
        //                                orb.OrderTypeName,
								//	    orb.DeleteFlag, orb.CreateDate, orb.OrderDate,
								//	    orb.OrderBy, odb.RequestedDate AS RequestDate, orb.MPSource, orb.MPSourceOrderNo, orb.TrackingNo,
								//	    orb.FullTaxInvFlag, orb.PostingDate, orb.DocumentDate,
        //                                orb.Reference1, orb.Reference2, orb.Reference3, orb.Reference4, orb.Reference5,
								//	    orb.ShippingLabelPrintLink, CAST(orb.RefNO AS char(36)) AS RefNO, orb.ControlPackID, orb.OrderStatus,
        //                                orb.CreatedUser, ISNULL(orb.ProviderCode,orb.ShippingProvider) AS ShippingProvider,
								//	    CAST(itm.DocRefNo AS varchar(36)) AS OrderItemDocRefNo,
								//	    --ISNULL( pal.Quantity ,ISNULL(pit.PackQuantity,itm.SaleUnitQty)) AS SaleUnitQty, --// C# เชื่อมเอา
								//	    ISNULL(pit.PackQuantity,itm.SaleUnitQty) AS SaleUnitQty,
        //                                ISNULL(pif.TrackingNo, tkla.TrackingNo ) AS PackTracking,
        //                                pif.ShippingMark,
								//	    -- ISNULL(pal.SerialNo, tkl.SerialNo) AS Serial,  -- TrackingLot , PackingLot  ต้องมี Lot , Serial เหมือนกัเนเพราะชะนั้นจะไม่หยิบมา แล้วถ้าไม่เหมือนกันแล้วหยิบมา = ดาต้าเบสล่ม
								//	    --pal.SerialNo AS Serial, --// ไว้ไปหยิบใน c#
        //                                itm.*, lot.*, ISNULL(odb.ShopID, csh.ShopID) AS ShopID,
								//	    cus.CustomerName, cus.AddressNo + ' ' + cus.DistrictName + ' ' + cus.ProvinceName + ' ' + cus.PostalCode AS CustomerAddress,
								//	    cus.PhoneNumber AS CustomerPhoneNumber, cus.LogoImage AS CustomerLogoImage,
								//	    odb.ShiptoName, odb.ContactPhone, odb.ShiptoAddress + ' ' + odb.ShiptoDistrict + ' ' + odb.ShiptoProvince + ' ' + odb.ShiptoPostCode AS OrderBaseAddress,
								//	    odb.RequestedDate, odb.OrderCreateDate, odb.BilltoCode, odb.OrderNumber, odb.OriginalOrder, odb.PONumber, orb.SourceSystem, 
        //                                pif.NetWeight, pif.GrossWeight, shp.ProviderName, pit.PackNumber
        //                        FROM WMSOrderBase orb
        //                        INNER JOIN OrderBase odb ON odb.OrderID = orb.OrderID
								//INNER JOIN Customer cus ON cus.CustomerCode = orb.Ownercode
        //                        INNER JOIN WMSOrderItem itm ON itm.DocRefNo = orb.DocRefNo AND itm.DeleteDocFlag = 0
        //                        LEFT OUTER JOIN CustomerShop csh ON csh.CustomerCode = orb.Ownercode AND csh.MarketPlace = orb.MPSource
        //                        LEFT OUTER JOIN ShippingProvider shp ON shp.ProviderCode = orb.ProviderCode
        //                        LEFT OUTER JOIN WMSOrderLots lot ON lot.DocRefNo = itm.DocRefNo AND lot.[LineNo] = itm.[LineNo]
								//LEFT OUTER JOIN PackingItem pit ON pit.OrderID = itm.DocRefNo AND pit.ItemNumber = itm.[LineNo]
								//LEFT OUTER JOIN PackingInfo pif ON pif.OrderID = itm.DocRefNo AND pit.PackNumber = pif.PackNumber
								//--LEFT OUTER JOIN PackingLots pal ON pal.OrderID = orb.DocRefNo AND pal.ItemNumber = itm.[LineNo] AND 
								//--pal.PackNumber = pit.PackNumber
        //                        --LEFT OUTER JOIN TrackingLots tkl ON tkl.OrderID = orb.DocRefNo AND tkl.ItemNumber = itm.[LineNo] AND tkl.SerialNo = pal.SerialNo AND tkl.LotNumber = pal.LotNumber
        //                        LEFT OUTER JOIN TrackingLabel tkla ON tkla.OrderNumber = orb.SONumber AND tkla.CustomerCode = orb.Ownercode 
        //                                        AND tkla.SourceSystem = orb.SourceSystem AND ISNULL(pif.TrackingNo,'') = '' AND tkla.OrderNumber <> tkla.TrackingNo
        //                                        AND ISNULL(tkla.TrackingNo,'') <> '' AND (CASE WHEN orb.TrackingNo <> orb.SONumber THEN orb.TrackingNo ELSE tkla.TrackingNo END)  = tkla.TrackingNo
        //                        WHERE orb.OrderID = @OrderID AND orb.DeleteFlag = '0'  ";

        //    if (!string.IsNullOrEmpty(PackTracking) && PackTracking != "-")
        //        sqlSelect += " AND ISNULL(pif.TrackingNo, tkla.TrackingNo ) = @PackTracking    ";

        //    string sqlSelectPackingLots = @" SELECT pal.*,pal.OrderID AS DocRefNo, pal.ItemNumber AS [LineNo], pal.SerialNo AS Serial, pal.LotNumber AS LotNo, pal.Quantity AS Qty   FROM PackingLots pal WHERE pal.OrderID = @DocRefNo   ";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, connection))
        //            {
        //                adapter.SelectCommand.Parameters.AddWithValue("@OrderID", OrderID);
        //                adapter.SelectCommand.Parameters.AddWithValue("@PackTracking", PackTracking);
        //                DataTable dtResult = new DataTable();
        //                adapter.Fill(dtResult);

        //                List<WMSOrderModel> orderList = AsEnumerable<WMSOrderModel>(dtResult);
        //                List<WMSOrderItem> itemList = AsEnumerable<WMSOrderItem>(dtResult);
        //                //List<WMSItemLot> lotList = AsEnumerable<WMSItemLot>(dtResult);
        //                //lotList = lotList.DistinctBy(x => new { x.DocRefNo, x.LineNo, x.LotNo, x.Serial }).ToList();
        //                salesOrders = orderList.GroupBy(s => s.DocRefNo).Select(g => g.First()).ToList();

        //                salesOrders.ForEach(or =>
        //                {
        //                    adapter.SelectCommand.CommandText = sqlSelectPackingLots;
        //                    adapter.SelectCommand.Parameters.Clear();
        //                    adapter.SelectCommand.Parameters.AddWithValue("@DocRefNo", or.DocRefNo);

        //                    DataTable dtPackingLot = new DataTable();
        //                    adapter.Fill(dtPackingLot);

        //                    List<WMSItemLot> lotList = AsEnumerable<WMSItemLot>(dtPackingLot);


        //                    or.Items = itemList.Where(it => it.DocRefNo == or.DocRefNo)?.ToList();
        //                    or.Items.ForEach(it =>
        //                    {
        //                        it.Lots = lotList.Where(lt => lt.DocRefNo == it.DocRefNo && lt.LineNo == it.LineNo & lt.PackNumber == it.PackNumber)?.ToList();
        //                        if (it.Lots.Count() > 0)
        //                        {
        //                            it.SaleUnitQty = it.Lots[0].Qty;
        //                        }
        //                    });
        //                });
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            this.response.Message = ex.Message;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return await Task.FromResult(salesOrders);
        //}

        //public async Task<ResponseModel> Assign(WMSOrderModel DataOrder)
        //{

        //    ResponseModel response = new ResponseModel();

        //    string sqlInsert = @"UPDATE WMSOrderBase SET  ProviderCode = @ProviderCode
		      //                          --TrackingNo = @TrackingNo
        //                         WHERE DocRefNo = @DocRefNo

        //                         UPDATE  PackingInfo SET TrackingNo = @TrackingNo, ChangedDate = dbo.SYSDATE() 
								// WHERE OrderID = @DocRefNo AND PackNumber = @PackNumber ";

        //    // delete ก่อน Insert ตัวอย่างเช่น มี TrackingNo ไม่ตรง OrderNumber จะได้สร้างได้ไม่งั้นจะ error ตอน Insert 
        //    string sqlInsertTrackingLabel = @"UPDATE TrackingLabel SET TrackingNo = @TrackingNo
        //                                      WHERE  CustomerCode = @CustomerCode AND SourceSystem = @SourceSystem AND
	       //                                          OrderNumber = @OrderNumber AND TrackingNo = @TrackingNo

        //                                      IF @@ROWCOUNT = 0
                                                
        //                                      BEGIN

        //                                      DELETE TrackingLabel
        //                                      WHERE OrderNumber = @OrderNumber AND CustomerCode = @CustomerCode AND SourceSystem = @SourceSystem

        //                                      INSERT INTO TrackingLabel (CustomerCode, SourceSystem, OrderNumber,
        //                                                  TrackingNo, PackingLabel, LabelFileType)
        //                                      VALUES (@CustomerCode, @SourceSystem, @OrderNumber,
        //                                              @TrackingNo, '', '')

        //                                      END ";

                                            

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                using (SqlCommand command = new SqlCommand(sqlInsert, connection))
        //                {
        //                    command.Parameters.AddWithValue("@ProviderCode", DataOrder.ShippingProvider);
        //                    command.Parameters.AddWithValue("@TrackingNo", DataOrder.TrackingNo);
        //                    command.Parameters.AddWithValue("@DocRefNo", DataOrder.DocRefNo);
        //                    command.Parameters.AddWithValue("@PackNumber", DataOrder.PackNumber);

        //                    command.ExecuteNonQuery();

        //                    response.Status = "S";
        //                    response.Message = $"Save {DataOrder.TrackingNo} has been created! PackInfo";
        //                }

        //                using (SqlCommand command2 = new SqlCommand(sqlInsertTrackingLabel, connection))
        //                {
        //                    //command2.Parameters.Clear();
        //                    command2.Parameters.AddWithValue("@CustomerCode", DataOrder.Ownercode);
        //                    command2.Parameters.AddWithValue("@SourceSystem", DataOrder.SourceSystem);
        //                    command2.Parameters.AddWithValue("@OrderNumber", DataOrder.SOnumber);
        //                    command2.Parameters.AddWithValue("@TrackingNo", DataOrder.TrackingNo);

        //                    command2.ExecuteNonQuery();

        //                    response.Status = "S";
        //                    response.Message += $", Save {DataOrder.TrackingNo} has been created! TrackingLabel";
        //                }


        //            }
        //            catch (Exception ex)
        //            {
        //                response.Message = ex.Message;
        //            }
        //            finally
        //            {
        //                connection.Close();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message = ex.Message;
        //    }
        //    return await Task.FromResult(response);
        //}

        //public async Task<ResponseModel> ClearAssignCarrier(WMSOrderModel DataOrder)
        //{

        //    ResponseModel response = new ResponseModel();

        //    string sqlUpdate = @"UPDATE WMSOrderBase SET ProviderCode = NULL 
        //                                      WHERE DocRefNo = @DocRefNo ";

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                using (SqlCommand command = new SqlCommand(sqlUpdate, connection))
        //                {
        //                    command.Parameters.AddWithValue("@DocRefNo", DataOrder.DocRefNo);

        //                    command.ExecuteNonQuery();

        //                    response.Status = "S";
        //                    response.Message = $"Clear {DataOrder.SOnumber} has been clear! AssignCarrier";
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                response.Message = ex.Message;
        //            }
        //            finally
        //            {
        //                connection.Close();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message = ex.Message;
        //    }
        //    return await Task.FromResult(response);
        //}
        //public async Task<ResponseModel> ChangeAddress(WMSOrderModel DataOrder)
        //{
        //    ResponseModel response = new ResponseModel();

        //    string sqlInsert = @" UPDATE OrderBase SET  ShiptoAddress = @ShiptoAddress, ShiptoDistrict = @ShiptoCity, 
        //                                 ShiptoProvince = @ShiptoStateOrProvince, ShiptoPostCode = @ShiptoPostalCode, 
		      //                           ContactPhone = @ShiptoPhoneNo, RequestedDate = @RequestedDate
        //                          WHERE  OrderID = @OrderID
                                
        //                        --UPDATE WMSOrderBase SET  ShiptoAddress = @ShiptoAddress, ShiptoCity = @ShiptoCity, 
        //                                --ShiptoStateOrProvince = @ShiptoStateOrProvince, ShiptoPostalCode = @ShiptoPostalCode, 
		      //                          --ShiptoPhoneNo = @ShiptoPhoneNo
        //                        --WHERE OrderID = @OrderID ";
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                using (SqlCommand command = new SqlCommand(sqlInsert, connection))
        //                {
        //                    command.Parameters.AddWithValue("@ShiptoAddress", DataOrder.ShiptoAddress);
        //                    command.Parameters.AddWithValue("@ShiptoCity", DataOrder.ShiptoCity);
        //                    command.Parameters.AddWithValue("@ShiptoStateOrProvince", DataOrder.ShiptoStateOrProvince);
        //                    command.Parameters.AddWithValue("@ShiptoPostalCode", DataOrder.ShiptoPostalCode );
        //                    command.Parameters.AddWithValue("@ShiptoPhoneNo", DataOrder.ShiptoPhoneNo ?? "-");
        //                    command.Parameters.AddWithValue("@OrderID", DataOrder.OrderID);
        //                    command.Parameters.AddWithValue("@RequestedDate", DataOrder.RequestDate);

        //                    command.ExecuteNonQuery();

        //                    response.Status = "S";
        //                    response.Message = $"Save {DataOrder.TrackingNo} has Change Address";
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                response.Message = ex.Message;
        //            }
        //            finally
        //            {
        //                connection.Close();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message = ex.Message;
        //    }
        //    return await Task.FromResult(response);
        //}

        //public async Task<IEnumerable<SalesOrderModel>> SearchDashBoard(SearchOrderModel SearchTerm)
        //{
        //    List<SalesOrderModel> salesOrders = new List<SalesOrderModel>();

        //    string whereCustomers = string.Empty;
        //    string sqlSelect = @"SELECT CAST(orb.OrderID AS char(36)) AS OrderID, 
        //                                CASE orb.DeleteFlag WHEN 1 THEN 'Cancelled' ELSE orb.OrderStatus END OrderStatus, 
								//		orb.CustomerCode, orb.SourceSystem,orb.OrderNumber,
								//		orb.OrderType,orb.CustomerName,orb.WarehouseSystem,
        //                            --orb.OrderCreateDate,
        //                            CONVERT(DATE, orb.OrderCreateDate) OrderCreateDate,
								//		orb.MarketPlace,orb.ShippingProvider,orb.DeleteFlag
        //                        FROM OrderBase orb
        //                        {0}
        //                        INNER JOIN OrderItem itm ON itm.CustomerCode = orb.CustomerCode AND itm.SourceSystem = orb.SourceSystem
        //                                   AND itm.OrderNumber = orb.OrderNumber
        //                        LEFT OUTER JOIN OrderLots lot ON lot.OrderItemID = itm.OrderItemID 
        //                        WHERE (orb.OrderCreateDate between @CreatedDateFr AND @CreatedDateTo ) 
        //                        --WHERE orb.OrderCreateDate between @CreatedDateFr AND DATEADD(day, 1, @CreatedDateTo) 
        //                        ";

        //    if (!string.IsNullOrEmpty(SearchTerm.CustomerCode))
        //    {
        //        List<string> customerS = new List<string>();
        //        string[] splitCC = SearchTerm.CustomerCode.Split(new string[] { "\r\n", "\r", "\n", ",", " " }, StringSplitOptions.None);
        //        foreach (var item in splitCC)
        //        {
        //            customerS.Add(item.Replace(" ", ""));
        //        }
        //        SearchTerm.CustomerCode = string.Join(",", customerS);

        //        whereCustomers = @" 
        //                        INNER JOIN (SELECT [value]  As CustomerCode
        //                        FROM STRING_SPLIT(@CustomerCode, ',')
        //                        ) ocu ON ocu.CustomerCode = orb.CustomerCode 
        //                        ";
        //    }
        //    sqlSelect = string.Format(sqlSelect, whereCustomers);

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, connection))
        //            {
        //                adapter.SelectCommand.Parameters.AddWithValue("@CustomerCode", SearchTerm.CustomerCode ?? "");
        //                adapter.SelectCommand.Parameters.AddWithValue("@SourceSystem", SearchTerm.SourceSystem ?? "");
        //                adapter.SelectCommand.Parameters.AddWithValue("@CreatedDateFr", SearchTerm.CreatedDateFr ?? "");
        //                adapter.SelectCommand.Parameters.AddWithValue("@CreatedDateTo", SearchTerm.CreatedDateTo + " 23:59:59.993" ?? "");
        //                //adapter.SelectCommand.Parameters.AddWithValue("@CreatedDateTo", SearchTerm.CreatedDateTo ?? "");

        //                DataTable dtResult = new DataTable();
        //                adapter.Fill(dtResult);

        //                List<SalesOrderModel> orderList = AsEnumerable<SalesOrderModel>(dtResult);
        //                salesOrders = orderList.GroupBy(s => s.OrderNumber).Select(g => g.First()).ToList();
                       
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            this.response.Message = ex.Message;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return await Task.FromResult(salesOrders);
        //}
         

        //public async Task<DashBoardOrderModel> SearchDashBoardByStore(SearchOrderModel SearchTerm)
        //{

        //    DashBoardOrderModel dashboardOrders = new DashBoardOrderModel();
        //    List<DashBoardChartModel> chartOrders = new List<DashBoardChartModel>();
        //    List<TransportDetailModel> transportOrders = new List<TransportDetailModel>();

        //    if (!string.IsNullOrEmpty(SearchTerm.CustomerCode))
        //    {
        //        List<string> customerS = new List<string>();
        //        string[] splitCC = SearchTerm.CustomerCode.Split(new string[] { "\r\n", "\r", "\n", ",", " " }, StringSplitOptions.None);
        //        foreach (var item in splitCC)
        //        {
        //            customerS.Add(item.Replace(" ", ""));
        //        }
        //        SearchTerm.CustomerCode = string.Join(",", customerS);
        //    }

        //    if (!string.IsNullOrEmpty(SearchTerm.MarketPlace))
        //    {
        //        List<string> marketPlaces = new List<string>();
        //        string[] splitCC = SearchTerm.MarketPlace.Split(new string[] { "\r\n", "\r", "\n", ",", " " }, StringSplitOptions.None);
        //        foreach (var item in splitCC)
        //        {
        //            marketPlaces.Add(item.Replace(" ", ""));
        //        }
        //        foreach (var item in marketPlaces)
        //        {
        //            if (item == "LAZ")
        //            {
        //                marketPlaces.Add("LZ");
        //                break;
        //            }
        //        }
        //        //foreach (var item in marketPlaces)
        //        //{
        //        //    if (item == "OTH")
        //        //    {
        //        //        marketPlaces.Add("OTHER");
        //        //        break;
        //        //    }
        //        //}
        //        marketPlaces = marketPlaces.Distinct().ToList();
        //        SearchTerm.MarketPlace = string.Join(",", marketPlaces);
        //    }

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            using (SqlDataAdapter adapter = new SqlDataAdapter("dbo.uspDashBoardOrder", connection))
        //            {
        //                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        //                adapter.SelectCommand.Parameters.AddWithValue("@CustomerCode", SearchTerm.CustomerCode);
        //                adapter.SelectCommand.Parameters.AddWithValue("@CreatedDateFr", SearchTerm.CreatedDateFr);
        //                adapter.SelectCommand.Parameters.AddWithValue("@CreatedDateTo", SearchTerm.CreatedDateTo + " 23:59:59.993" ?? "");
        //                adapter.SelectCommand.Parameters.AddWithValue("@MarketPlace", SearchTerm.MarketPlace);
        //                adapter.SelectCommand.Parameters.AddWithValue("@UserId", SearchTerm.UserId);

        //                DataSet dsResult = new DataSet();
        //                adapter.Fill(dsResult);

        //                dashboardOrders.DashBoardStatus = AsEnumerable<DashBoardStatusModel>(dsResult.Tables[0]);
        //                dashboardOrders.TransportDetail = AsEnumerable<TransportDetailModel>(dsResult.Tables[1]).DistinctBy(x => new { x.MarketPlace, x.ShippingProvider, x.ProviderCode}).ToList();
        //                transportOrders = AsEnumerable<TransportDetailModel>(dsResult.Tables[1]);
        //                dashboardOrders.DashBoardDoughnut = AsEnumerable<DashBoardDoughnutModel>(dsResult.Tables[2]);
        //                chartOrders = AsEnumerable<DashBoardChartModel>(dsResult.Tables[3]);

        //                foreach (var item in dashboardOrders.TransportDetail)
        //                {
        //                    int NumberAllNonStatus = 0;
        //                  List<TransportDetailModel>  transportOrdersTemp = transportOrders.Where(lt => lt.MarketPlace == item.MarketPlace && lt.ShippingProvider == item.ShippingProvider && lt.ProviderCode == item.ProviderCode)?.ToList();
        //                    foreach (var itemByStatus in transportOrdersTemp)
        //                    {
        //                        NumberAllNonStatus = NumberAllNonStatus + itemByStatus.Number;
        //                        item.NumberItemByStatus.Add(new NumberItemByStatusModel { OrderStatus = itemByStatus.OrderStatus, Number = itemByStatus.Number });
        //                    }
        //                    item.OrderStatus = "none";
        //                    item.Number = NumberAllNonStatus;
        //                }

        //                //chartOrders = chartOrders.GroupBy(s => s.OrderCreateDate).Select(cl => new DashBoardChartModel
        //                //{
        //                //    OrderCreateDate = cl.First().OrderCreateDate,
        //                //    Number = cl.Sum(c => c.Number),
        //                //}).ToList();

        //                //Store เปลี่ยน CONVERT > Format,  DateTime > string  จะไม่ต้อง GroupBy C# แต่จะต้องไปเรียง Order String จึงใช้ CONVERT เหมือนเดิม

        //                dashboardOrders.DashBoardChart = chartOrders;
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            this.response.Message = ex.Message;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return await Task.FromResult(dashboardOrders);
        //}

        //public async Task<IEnumerable<MasterItemModel>> GetDistrictByPostalCode(MasterItemModel PostalCodeData)
        //{
        //    List<MasterItemModel> districtList = new List<MasterItemModel>();

        //    string sqlSelect = @"SELECT PostalCode AS ItemCode, DistrictName AS ItemText FROM MstDistrict WHERE PostalCode = @PostalCode";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, connection))
        //            {
        //                adapter.SelectCommand.Parameters.AddWithValue("@PostalCode", PostalCodeData.ItemCode ?? "");

        //                DataTable dtResult = new DataTable();
        //                adapter.Fill(dtResult);

        //                districtList = AsEnumerable<MasterItemModel>(dtResult);

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            this.response.Message = ex.Message;
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return await Task.FromResult(districtList);
        //}

    }
}
