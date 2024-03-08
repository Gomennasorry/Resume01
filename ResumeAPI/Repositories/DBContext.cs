//using BASE.Dto;
using Microsoft.Data.SqlClient;
using ResumeDto;
using System.ComponentModel;
using System.Data;

namespace ResumeAPI.Repositories
{
    public partial class DBContext
    {
        protected ResponseModel response;
        protected readonly string connectionString;
        public DBContext()
        {
            response = new ResponseModel();
            connectionString = App.BaseConnection;
        }

        public static T AsSingle<T>(DataTable dataTable)
        {
            var columnNames = dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();
            var properties = typeof(T).GetProperties();
            DataRow[] rows = dataTable.Select();

            return rows.Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                        pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : row[pro.Name]);
                }

                return objT;
            }).FirstOrDefault();
        }

        public static List<T> AsEnumerable<T>(DataTable dataTable)
        {
            var columnNames = dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();
            var properties = typeof(T).GetProperties();
            DataRow[] rows = dataTable.Select();

            return rows.Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : row[pro.Name]);
                        //pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : Convert.ChangeType(row[pro.Name], pro.PropertyType));
                    }
                }

                return objT;
            }).ToList();
        }

        public static DataTable ReEnumerable<T>(IList<T> list)
        {
            PropertyDescriptorCollection propertyDescriptorCollection = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < propertyDescriptorCollection.Count; i++)
            {
                PropertyDescriptor propertyDescriptor = propertyDescriptorCollection[i];
                Type propType = propertyDescriptor.PropertyType;
                if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    table.Columns.Add(propertyDescriptor.Name, Nullable.GetUnderlyingType(propType));
                }
                else
                {
                    table.Columns.Add(propertyDescriptor.Name, propType);
                }
            }
            object[] values = new object[propertyDescriptorCollection.Count];
            foreach (T listItem in list)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = propertyDescriptorCollection[i].GetValue(listItem);
                }
                table.Rows.Add(values);
            }
            return table;
        }


        public string DBInfo()
        {
            string result = string.Empty;
            //nuget Microsoft.Data.SqlClient / System.Data.SqlClient
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a SqlCommand, and identify it as a stored procedure.
                using (SqlCommand sqlCommand = new SqlCommand("SELECT GETDATE()", connection))
                {
                    sqlCommand.CommandTimeout = 10;
                    try
                    {
                        connection.Open();

                        // Run the stored procedure.
                        var date = sqlCommand.ExecuteScalar();

                        result = $"{date}: {connection.DataSource} [{connection.Database}] ready!";
                    }
                    catch (Exception ex)
                    {
                        result = ex.Message;
                    }
                    finally
                    {
                        try
                        {
                            connection.Close();
                        }
                        catch (Exception ex2)
                        {
                            result += ex2.ToString();
                        }
                    }
                }
            }

            return result;
        }

    }
}
