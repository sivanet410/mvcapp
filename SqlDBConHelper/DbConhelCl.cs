using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDBConHelper
{
    public class DbConhelCl
    {
        private static SqlCommand SCMD = null;

        public static DataTable ExecuteDatatable(SqlConnection SCON, string cmdText, CommandType cmdType, NameValueCollection NVCOL, List<SqlParameter> SP = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SCMD = new SqlCommand())
                {
                    if (SCON.State == ConnectionState.Closed)
                    {
                        SCON.Open();
                    }
                    SCMD.Connection = SCON;
                    SCMD.CommandType = cmdType;
                    SCMD.CommandText = cmdText;
                    if (SP != null)
                    {
                        SCMD.Parameters.AddRange(SP.ToArray());
                    }
                    using (SqlDataReader reader = SCMD.ExecuteReader())
                    {
                        dt.BeginLoadData();
                        dt.Load(reader, LoadOption.Upsert);
                        dt.EndLoadData();
                        reader.Close(); reader.Dispose();
                    }
                }
                return dt;
            }
            catch (Exception e)
            {
                ExceptionlogCl.Publish_exep(e.Message.ToString(), NVCOL);
                return null;
            }
            finally
            {
                if (SCON.State == ConnectionState.Open)
                {
                    SCON.Close();
                    SCMD.Dispose();
                }
                if (SCMD != null)
                {
                    SCMD.Dispose();
                }
            }
        }

        public static DataSet ExecuteDataset(SqlConnection Ocon, string cmdtext, CommandType cmdtype, NameValueCollection nvcoll, List<SqlParameter> Op = null)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SCMD = new SqlCommand())
                {
                    if (Ocon.State == ConnectionState.Closed)
                    {
                        Ocon.Open();
                    }
                    SCMD.Connection = Ocon;
                    // Ocmd.InitialLONGFetchSize = -1;
                    SCMD.CommandType = cmdtype;
                    SCMD.CommandText = cmdtext;
                    if (Op != null)
                    {
                        SCMD.Parameters.AddRange(Op.ToArray());
                    }
                    SqlDataAdapter odap = new SqlDataAdapter(SCMD);
                    odap.Fill(ds);
                }
                return ds;
            }
            catch (Exception e)
            {
                ExceptionlogCl.Publish_exep(e.Message.ToString(), nvcoll);
                return null;
            }
            finally
            {
                if (Ocon.State == ConnectionState.Open)
                {
                    Ocon.Close();
                    SCMD.Dispose();
                }
                if (SCMD != null)
                {
                    SCMD.Dispose();
                }
            }
        }

        public static int ExecuteNonquery(SqlConnection Ocon, string cmdtext, CommandType cmdtype, NameValueCollection nvcoll, List<SqlParameter> Op = null)
        {
            int i = 0;
            try
            {
                using (SCMD = new SqlCommand())
                {
                    if (Ocon.State == ConnectionState.Closed)
                    {
                        Ocon.Open();
                    }
                    SCMD.Connection = Ocon;
                    // Ocmd.InitialLONGFetchSize = -1;
                    SCMD.CommandType = cmdtype;
                    SCMD.CommandText = cmdtext;
                    if (Op != null)
                    {
                        SCMD.Parameters.AddRange(Op.ToArray());
                    }
                    i = SCMD.ExecuteNonQuery();
                }
                return i;
            }
            catch (Exception e)
            {
                ExceptionlogCl.Publish_exep(e.Message.ToString(), nvcoll);
                return i;
            }
            finally
            {
                if (Ocon.State == ConnectionState.Open)
                {
                    Ocon.Close();
                    SCMD.Dispose();
                }
                if (SCMD != null)
                {
                    SCMD.Dispose();
                }
            }
        }

    }
}
