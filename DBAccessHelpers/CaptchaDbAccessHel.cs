using SqlDBConHelper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccessHelpers
{
    public class CaptchaDbAccessHel
    {
        private readonly SqlConnection _con = null;
        private readonly NameValueCollection _col = null;
        private delegate DataTable Executetable(SqlConnection SCON, string cmdText, CommandType cmdType, NameValueCollection NVCOL, List<SqlParameter> SP = null);

        private CaptchaDbAccessHel()
        {
            _con = new SqlConnection(ConstrHelpers.GetMvcconstr());
            _col = new NameValueCollection();
        }


    }
}
