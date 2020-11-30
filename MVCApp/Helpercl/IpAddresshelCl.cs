using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;


namespace MVCApp.Helpercl
{
    public class IpAddresshelCl 
    {
        public static string Ipaddress()
        {
            string IP4Address = String.Empty;
            HttpContext context = HttpContext.Current;
            foreach (IPAddress IPA in Dns.GetHostAddresses(context.Request.ServerVariables["REMOTE_ADDR"].ToString()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }
            if (IP4Address != String.Empty)
            {
                return IP4Address;
            }
            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }
            return IP4Address;
        }

        public static string ClientSystemname()
        {
            HttpContext context = HttpContext.Current;
            string[] computer_name = Dns.GetHostEntry(context.Request.ServerVariables["REMOTE_ADDR"]).HostName.Split(new char[] { '.' });
            return computer_name[0].ToString();
        }
      
    }
}