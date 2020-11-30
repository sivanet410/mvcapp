using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SqlDBConHelper
{
    public class ExceptionlogCl
    {
        public static void Publish_exep(string exception, NameValueCollection Additionalinfo)
        {
            string folder = HttpContext.Current.Server.MapPath("ErrorList");

            StringBuilder strinfo = new StringBuilder();
            if (Additionalinfo != null)
            {
                strinfo.AppendFormat("{0} General Information {0}", Environment.NewLine);
                strinfo.AppendFormat("{0} Additional Information {0}", Environment.NewLine);
                foreach (string i in Additionalinfo)
                {
                    strinfo.AppendFormat("{0} {1} : {2}", Environment.NewLine, i, Additionalinfo.Get(i));
                }
            }
            strinfo.AppendFormat("{0} {0} Exception Information {0} {1}", Environment.NewLine, exception.ToString());
            Task WriteTask = Task.Factory.StartNew(() => SecurityhelCL.Errorlog(strinfo, folder));
        }
    }
}
