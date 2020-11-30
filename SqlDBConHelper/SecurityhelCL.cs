using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDBConHelper
{
    public class SecurityhelCL
    {
        public object Log(dynamic strMsg, string mappath, string unid)
        {
            try
            {
                string strPath = mappath + "\\" + DateTime.Now.ToString("MMddyyyy") + "\\" + unid;
                if (!Directory.Exists(strPath))
                    Directory.CreateDirectory(strPath);
                string path = strPath + "\\" + "Log" + DateTime.Now.ToString("yyyyMMddhhmmssmmm") + serNumber().ToString();
                StreamWriter swLog = new StreamWriter(path + ".txt", true);
                swLog.WriteLine(strMsg);
                swLog.Close();
                swLog.Dispose();
                return "Success";
            }
            catch
            {
                return "Fail";
            }
        }

        public static object Errorlog(dynamic strMsg, string mappath)
        {
            try
            {
                string strpath = mappath + "\\" + DateTime.Now.ToString("MMddyyyy");
                if (!Directory.Exists(strpath))
                    Directory.CreateDirectory(strpath);
                string path = strpath + "\\" + "Log" + DateTime.Now.ToString("yyyyMMddhhmmssmmm");
                StreamWriter swLog = new StreamWriter(path + ".txt", true);
                swLog.WriteLine(strMsg);
                swLog.Close(); swLog.Dispose();
                return "Success";
            }
            catch
            {
                return "Fail";
            }
        }

        public int serNumber()
        {
            Random r = new Random();
            int random_num = r.Next(0, 99999);
            return random_num;
        }

    }
}
