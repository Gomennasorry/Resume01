//sing BASE.Dto;
using Microsoft.Data.SqlClient;
using ResumeDto;
using System.Data;

namespace ResumeAPI.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentModel>> SearchStudent(MasterItemModel StudentData);
        Task<ResponseModel> AddStudent(StudentModel StudentData);
        Task<ResponseModel> UpdateStudent(StudentModel StudentData);

        Task<ResponseModel> DeleteStudent(int StudentId);

    }

    public class StudentRepository : DBContext, IStudentRepository
    {

        public async Task<IEnumerable<StudentModel>> SearchStudent(MasterItemModel StudentData)
        {
            List<StudentModel> studentList = new List<StudentModel>();

            string whereOrders = string.Empty;
            string sqlSelectX = @"SELECT TOP 10 * 
                                 FROM Students
                                {0}
                                ";
            
            string sqlSelect = @"SELECT * 
                                 FROM Students
                                {0}
                                ";

            //if (!string.IsNullOrEmpty(SearchTerm.OrderNumbers))
            //{
            //    List<string> orderNos = new List<string>();
            //    string[] lines = SearchTerm.OrderNumbers.Split(new string[] { "\r\n", "\r", "\n", ",", "\t", " " }, StringSplitOptions.None);
            //    foreach (var item in lines)
            //    {
            //        orderNos.Add(item.Replace(" ", ""));
            //    }
            //    SearchTerm.OrderNumbers = string.Join(",", orderNos);

            //    whereOrders = @" 
            //                    INNER JOIN (SELECT [value]  As OrderNumber
            //                    FROM STRING_SPLIT(@OrderNumbers, ',')
            //                    ) ors ON orb.OrderNumber = ors.OrderNumber  
            //                    ";
            //}

            //if (!string.IsNullOrEmpty(SearchTerm.CustomerCode))
            //{
            //    List<string> customerS = new List<string>();
            //    string[] splitCC = SearchTerm.CustomerCode.Split(new string[] { "\r\n", "\r", "\n", ",", " " }, StringSplitOptions.None);
            //    foreach (var item in splitCC)
            //    {
            //        customerS.Add(item.Replace(" ", ""));
            //    }
            //    SearchTerm.CustomerCode = string.Join(",", customerS);

            //    whereCustomers = @" 
            //                    INNER JOIN (SELECT [value]  As CustomerCode
            //                    FROM STRING_SPLIT(@CustomerCode, ',')
            //                    ) ocu ON ocu.CustomerCode = orb.CustomerCode 
            //                    ";
            //}
            //if (!string.IsNullOrEmpty(SearchTerm.MarketPlace))
            //{
            //    List<string> marketPlaces = new List<string>();
            //    string[] splitCC = SearchTerm.MarketPlace.Split(new string[] { "\r\n", "\r", "\n", ",", " " }, StringSplitOptions.None);
            //    foreach (var item in splitCC)
            //    {
            //        marketPlaces.Add(item.Replace(" ", ""));
            //    }
            //    foreach (var item in marketPlaces)
            //    {
            //        if (item == "LAZ")
            //        {
            //            marketPlaces.Add("LZ");
            //            break;
            //        }

            //    }
            //    //foreach (var item in marketPlaces)
            //    //{
            //    //    if (item == "OTH")
            //    //    {
            //    //        marketPlaces.Add("OTHER");
            //    //        break;
            //    //    }
            //    //}
            //    marketPlaces = marketPlaces.Distinct().ToList();
            //    SearchTerm.MarketPlace = string.Join(",", marketPlaces);
            //    innerJoinMarketPlace = @" 
            //                    INNER JOIN (SELECT [value]  As MarketPlace
            //                    --FROM STRING_SPLIT(@MarketPlace + ',DZY, OTHER, SCG, Stock, OTH, VG', ',')
            //                    FROM STRING_SPLIT(@MarketPlace, ',')
            //                    ) mkp ON mkp.MarketPlace = orb.MarketPlace 

            //                    ";

            //    whereMarketPlace = @"
            //                            AND EXISTS (
            //                                SELECT 1
            //                                FROM CustomersMarketPlaceUsers cmp
            //                                WHERE cmp.MarketPlace = orb.MarketPlace
            //                                  AND cmp.CustomerCode = orb.CustomerCode
            //                                  AND cmp.UserId = @UserId 
            //                            );
            //                        ";


            //    //whereMarketPlace = @" 
            //    //                INNER JOIN (SELECT [value]  As MarketPlace
            //    //                --FROM STRING_SPLIT(@MarketPlace + ',DZY, OTHER, SCG, Stock, OTH, VG', ',')
            //    //                FROM STRING_SPLIT(@MarketPlace, ',')
            //    //                ) mkp ON mkp.MarketPlace = orb.MarketPlace 

            //    //                --User มาจอยด้วย 
            //    //                INNER JOIN CustomersMarketPlaceUsers cmp ON cmp.CustomerCode = orb.CustomerCode 
            //    //                 AND cmp.MarketPlace = mkp.MarketPlace
            //    //                AND cmp.UserId = @UserId 
            //    //                ";
            //}
            sqlSelect = string.Format(sqlSelect, whereOrders);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, connection))
                        {
                            //adapter.SelectCommand.Parameters.AddWithValue("@CreatedDateFr", SearchTerm.CreatedDateFr ?? "");
                            //adapter.SelectCommand.Parameters.AddWithValue("@CreatedDateTo", SearchTerm.CreatedDateTo + " 23:59:59.993" ?? "");
                            //adapter.SelectCommand.Parameters.AddWithValue("@MarketPlace", SearchTerm.MarketPlace);

                            DataTable dtResult = new DataTable();
                            adapter.Fill(dtResult);

                            studentList = AsEnumerable<StudentModel>(dtResult);
                            ////List<ItemLotModel> lotList = AsEnumerable<ItemLotModel>(dtResult);
                            //salesOrders = orderList.GroupBy(s => s.OrderNumber).Select(g => g.First()).ToList();

                            ////Slow Because  Match Order And Item    , index page use Item Price+Quantity
                            ////mapping sub model
                            //salesOrders.ForEach(or =>
                            //{
                            //    or.Items = itemList.Where(it => it.OrderNumber == or.OrderNumber)?.ToList();

                            //    //or.Items.ForEach(it =>
                            //    //{
                            //    //    it.Lots = lotList.Where(lt => lt.OrderItemID == it.OrderItemID)?.ToList();
                            //    //});
                            //});
                        }
                    }
                    catch (Exception ex)
                    {
                        this.response.Message = ex.Message;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

          
            return await Task.FromResult(studentList);
        }

        public async Task<ResponseModel> AddStudent(StudentModel StudentData)
        {

            ResponseModel response = new ResponseModel();

            string sqlInsert = @"INSERT INTO Students (StudentName, StudentAge, StudentDescription)
                                 VALUES (@StudentName, @StudentAge, @StudentDescription)
                                 ";

         //   string sqlInsert = @"UPDATE WMSOrderBase SET  ProviderCode = @ProviderCode
         //                         --TrackingNo = @TrackingNo
         //                        WHERE DocRefNo = @DocRefNo

         //                        UPDATE  PackingInfo SET TrackingNo = @TrackingNo, ChangedDate = dbo.SYSDATE() 
         //WHERE OrderID = @DocRefNo AND PackNumber = @PackNumber ";

            // delete ก่อน Insert ตัวอย่างเช่น มี TrackingNo ไม่ตรง OrderNumber จะได้สร้างได้ไม่งั้นจะ error ตอน Insert 
            //string sqlInsertTrackingLabel = @"UPDATE TrackingLabel SET TrackingNo = @TrackingNo
            //                                  WHERE  CustomerCode = @CustomerCode AND SourceSystem = @SourceSystem AND
            //                                      OrderNumber = @OrderNumber AND TrackingNo = @TrackingNo

            //                                  IF @@ROWCOUNT = 0

            //                                  BEGIN

            //                                  DELETE TrackingLabel
            //                                  WHERE OrderNumber = @OrderNumber AND CustomerCode = @CustomerCode AND SourceSystem = @SourceSystem

            //                                  INSERT INTO TrackingLabel (CustomerCode, SourceSystem, OrderNumber,
            //                                              TrackingNo, PackingLabel, LabelFileType)
            //                                  VALUES (@CustomerCode, @SourceSystem, @OrderNumber,
            //                                          @TrackingNo, '', '')

            //                                  END ";



            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(sqlInsert, connection))
                        {
                            command.Parameters.AddWithValue("@StudentName", StudentData.StudentName);
                            command.Parameters.AddWithValue("@StudentAge", StudentData.StudentAge);
                            command.Parameters.AddWithValue("@StudentDescription", StudentData.StudentDescription);

                            command.ExecuteNonQuery();

                            response.Status = "S";
                            response.Message = $"Add Student {StudentData.StudentName} has been created!";
                        }

                        //using (SqlCommand command2 = new SqlCommand(sqlInsertTrackingLabel, connection))
                        //{
                        //    //command2.Parameters.Clear();
                        //    command2.Parameters.AddWithValue("@CustomerCode", DataOrder.Ownercode);
                        //    command2.Parameters.AddWithValue("@SourceSystem", DataOrder.SourceSystem);
                        //    command2.Parameters.AddWithValue("@OrderNumber", DataOrder.SOnumber);
                        //    command2.Parameters.AddWithValue("@TrackingNo", DataOrder.TrackingNo);

                        //    command2.ExecuteNonQuery();

                        //    response.Status = "S";
                        //    response.Message += $", Save {DataOrder.TrackingNo} has been created! TrackingLabel";
                        //}


                    }
                    catch (Exception ex)
                    {
                        response.Message = ex.Message;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return await Task.FromResult(response);
        }

        public async Task<ResponseModel> UpdateStudent(StudentModel StudentData)
        {

            ResponseModel response = new ResponseModel();

            string sqlUpdate = @"UPDATE  Students SET StudentName = @StudentName, StudentAge = @StudentAge, StudentDescription = @StudentDescription
                                 WHERE StudentId = @StudentId
                                 ";

            //   string sqlInsert = @"UPDATE WMSOrderBase SET  ProviderCode = @ProviderCode
            //                         --TrackingNo = @TrackingNo
            //                        WHERE DocRefNo = @DocRefNo

            //                        UPDATE  PackingInfo SET TrackingNo = @TrackingNo, ChangedDate = dbo.SYSDATE() 
            //WHERE OrderID = @DocRefNo AND PackNumber = @PackNumber ";

            // delete ก่อน Insert ตัวอย่างเช่น มี TrackingNo ไม่ตรง OrderNumber จะได้สร้างได้ไม่งั้นจะ error ตอน Insert 
            //string sqlInsertTrackingLabel = @"UPDATE TrackingLabel SET TrackingNo = @TrackingNo
            //                                  WHERE  CustomerCode = @CustomerCode AND SourceSystem = @SourceSystem AND
            //                                      OrderNumber = @OrderNumber AND TrackingNo = @TrackingNo

            //                                  IF @@ROWCOUNT = 0

            //                                  BEGIN

            //                                  DELETE TrackingLabel
            //                                  WHERE OrderNumber = @OrderNumber AND CustomerCode = @CustomerCode AND SourceSystem = @SourceSystem

            //                                  INSERT INTO TrackingLabel (CustomerCode, SourceSystem, OrderNumber,
            //                                              TrackingNo, PackingLabel, LabelFileType)
            //                                  VALUES (@CustomerCode, @SourceSystem, @OrderNumber,
            //                                          @TrackingNo, '', '')

            //                                  END ";



            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(sqlUpdate, connection))
                        {
                            command.Parameters.AddWithValue("@StudentId", StudentData.StudentId);
                            command.Parameters.AddWithValue("@StudentName", StudentData.StudentName);
                            command.Parameters.AddWithValue("@StudentAge", StudentData.StudentAge);
                            command.Parameters.AddWithValue("@StudentDescription", StudentData.StudentDescription);

                            command.ExecuteNonQuery();

                            response.Status = "S";
                            response.Message = $"Update Student No  {StudentData.StudentId} has been Update!";
                        }

                        //using (SqlCommand command2 = new SqlCommand(sqlInsertTrackingLabel, connection))
                        //{
                        //    //command2.Parameters.Clear();
                        //    command2.Parameters.AddWithValue("@CustomerCode", DataOrder.Ownercode);
                        //    command2.Parameters.AddWithValue("@SourceSystem", DataOrder.SourceSystem);
                        //    command2.Parameters.AddWithValue("@OrderNumber", DataOrder.SOnumber);
                        //    command2.Parameters.AddWithValue("@TrackingNo", DataOrder.TrackingNo);

                        //    command2.ExecuteNonQuery();

                        //    response.Status = "S";
                        //    response.Message += $", Save {DataOrder.TrackingNo} has been created! TrackingLabel";
                        //}


                    }
                    catch (Exception ex)
                    {
                        response.Message = ex.Message;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return await Task.FromResult(response);
        }

        public async Task<ResponseModel> DeleteStudent(int StudentId)
        {

            ResponseModel response = new ResponseModel();

            string sqlUpdate = @"DELETE  Students 
                                 WHERE StudentId = @StudentId
                                 ";

            //   string sqlInsert = @"UPDATE WMSOrderBase SET  ProviderCode = @ProviderCode
            //                         --TrackingNo = @TrackingNo
            //                        WHERE DocRefNo = @DocRefNo

            //                        UPDATE  PackingInfo SET TrackingNo = @TrackingNo, ChangedDate = dbo.SYSDATE() 
            //WHERE OrderID = @DocRefNo AND PackNumber = @PackNumber ";

            // delete ก่อน Insert ตัวอย่างเช่น มี TrackingNo ไม่ตรง OrderNumber จะได้สร้างได้ไม่งั้นจะ error ตอน Insert 
            //string sqlInsertTrackingLabel = @"UPDATE TrackingLabel SET TrackingNo = @TrackingNo
            //                                  WHERE  CustomerCode = @CustomerCode AND SourceSystem = @SourceSystem AND
            //                                      OrderNumber = @OrderNumber AND TrackingNo = @TrackingNo

            //                                  IF @@ROWCOUNT = 0

            //                                  BEGIN

            //                                  DELETE TrackingLabel
            //                                  WHERE OrderNumber = @OrderNumber AND CustomerCode = @CustomerCode AND SourceSystem = @SourceSystem

            //                                  INSERT INTO TrackingLabel (CustomerCode, SourceSystem, OrderNumber,
            //                                              TrackingNo, PackingLabel, LabelFileType)
            //                                  VALUES (@CustomerCode, @SourceSystem, @OrderNumber,
            //                                          @TrackingNo, '', '')

            //                                  END ";



            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(sqlUpdate, connection))
                        {
                            command.Parameters.AddWithValue("@StudentId", StudentId);

                            command.ExecuteNonQuery();

                            response.Status = "S";
                            response.Message = $"Delete Student No  {StudentId} has been Deleted!";
                        }

                        //using (SqlCommand command2 = new SqlCommand(sqlInsertTrackingLabel, connection))
                        //{
                        //    //command2.Parameters.Clear();
                        //    command2.Parameters.AddWithValue("@CustomerCode", DataOrder.Ownercode);
                        //    command2.Parameters.AddWithValue("@SourceSystem", DataOrder.SourceSystem);
                        //    command2.Parameters.AddWithValue("@OrderNumber", DataOrder.SOnumber);
                        //    command2.Parameters.AddWithValue("@TrackingNo", DataOrder.TrackingNo);

                        //    command2.ExecuteNonQuery();

                        //    response.Status = "S";
                        //    response.Message += $", Save {DataOrder.TrackingNo} has been created! TrackingLabel";
                        //}


                    }
                    catch (Exception ex)
                    {
                        response.Message = ex.Message;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return await Task.FromResult(response);
        }

    }
}
