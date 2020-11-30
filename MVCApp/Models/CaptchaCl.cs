using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApp.Models
{
    public class CaptchaCl
    {
        public string Code { get; set; }
        public string CId { get; set; }
        public string IpAddress { get; set; }
        public string SysAddress { get; set; }
        public string Brow { get; set; }
        public string BrowVer { get; set; }
    }
}