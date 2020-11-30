using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDBConHelper
{
    public class ConstrHelpers
    {
        public static string GetMvcconstr()
        {
            return "Data Source=DESKTOP-G0B8CNO;Initial Catalog=HRMS;User Id=sivadb;Password=S123a321;Connection Timeout=100;Pooling=true;Min Pool Size=5;Max Pool Size=180";
        }
    }
}
