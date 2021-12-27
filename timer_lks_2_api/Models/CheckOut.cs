using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace timer_lks_2_api.Models
{
    public class CheckOut
    {
        public int id_employee { set; get; }
        public int id_customer { set; get; }
        public int id_package { set; get; }
    }
}